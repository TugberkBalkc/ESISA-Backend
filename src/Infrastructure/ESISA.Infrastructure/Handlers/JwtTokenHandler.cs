﻿using ESISA.Core.Application.Dtos.Security.Authentication;
using ESISA.Core.Application.Interfaces.Handlers;
using ESISA.Core.Application.Interfaces.Repositories.Identity.AuthenticationAndAuthorization;
using ESISA.Core.Application.Options.Authentication;
using ESISA.Core.Application.Utilities.Configuration;
using ESISA.Core.Application.Utilities.Security.Encryption;
using ESISA.Core.Domain.Exceptions.BusinessLogic;
using ESISA.Infrastructure.Extensions.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Infrastructure.Handlers
{
    public class JwtTokenHandler : ITokenHandler
    {
        private readonly TokenOptions _tokenOptions;

        private readonly IUserRefreshTokenCommandRepository _userRefreshTokenCommandRepository;
        private readonly IUserRefreshTokenQueryRepository _userRefreshTokenQueryRepository;

        public JwtTokenHandler(IOptions<TokenOptions> options, IUserRefreshTokenCommandRepository userRefreshTokenCommandRepository, IUserRefreshTokenQueryRepository userRefreshTokenQueryRepository, IConfiguration configuration)
        {
            _tokenOptions = options.Value;
            //TODO DUZELT
            _tokenOptions = NonInjectableOptionsTool.GetTokenOptions(configuration);


            _userRefreshTokenCommandRepository = userRefreshTokenCommandRepository;
            _userRefreshTokenQueryRepository = userRefreshTokenQueryRepository;
        }

        private DateTime accessTokenExpirationDate { get; set; }
        private DateTime refreshTokenExpirationDate { get; set; }

        public Token CreateTokenForIndividualStarter(Guid userId, string userFirstName, string userLastName, string userEmail, string[] usersRoleNames)
        {
            accessTokenExpirationDate = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenLifeTimeInMinutes);
            refreshTokenExpirationDate = DateTime.Now.AddMinutes(_tokenOptions.RefreshTokenLifeTimeInMinutes);

            var symmetricSercurityKey = SecurityKeyHelper.CreateSymmetricSecurityKey(_tokenOptions.SecretKey);

            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentialsBySymmetricSecurityKey(symmetricSercurityKey);

            var jwtSecurityToken = this.CreateJwtSecurityTokenForIndividualStarterWithRoles(userId, userFirstName, userLastName, userEmail, usersRoleNames, _tokenOptions, signingCredentials);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            String accessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            return new Token(accessToken, accessTokenExpirationDate, this.CreateRefreshToken(), refreshTokenExpirationDate);
        }

        public Token CreateTokenForCorporateUser(Guid userId, string taxIdentityNumber, string userEmail, string[] usersRoleNames)
        {
            accessTokenExpirationDate = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenLifeTimeInMinutes);
            refreshTokenExpirationDate = DateTime.Now.AddMinutes(_tokenOptions.RefreshTokenLifeTimeInMinutes);

            var symmetricSercurityKey = SecurityKeyHelper.CreateSymmetricSecurityKey(_tokenOptions.SecretKey);

            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentialsBySymmetricSecurityKey(symmetricSercurityKey);

            var jwtSecurityToken = this.CreateJwtSecurityTokenForAuthorizedUserWithRoles(userId, taxIdentityNumber, userEmail, usersRoleNames, _tokenOptions, signingCredentials);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            String accessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            return new Token(accessToken, accessTokenExpirationDate, this.CreateRefreshToken(), refreshTokenExpirationDate);
        }

        public Token CreateTokenForAuthorizedUser(Guid userId, string registryNumber, string userEmail, string[] usersRoleNames)
        {
            accessTokenExpirationDate = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenLifeTimeInMinutes);
            refreshTokenExpirationDate = DateTime.Now.AddMinutes(_tokenOptions.RefreshTokenLifeTimeInMinutes);

            var symmetricSercurityKey = SecurityKeyHelper.CreateSymmetricSecurityKey(_tokenOptions.SecretKey);

            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentialsBySymmetricSecurityKey(symmetricSercurityKey);

            var jwtSecurityToken = this.CreateJwtSecurityTokenForAuthorizedUserWithRoles(userId, registryNumber, userEmail, usersRoleNames, _tokenOptions, signingCredentials);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            String accessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            return new Token(accessToken, accessTokenExpirationDate, this.CreateRefreshToken(), refreshTokenExpirationDate);
        }

        public Token CreateTokenByRefreshToken(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public void RevokeRefreshToken(string refreshToken)
        {
            throw new NotImplementedException();
        }


        private JwtSecurityToken CreateJwtSecurityTokenForIndividualStarterWithRoles(Guid userId, String userFirstName, String userLastName, String userEmail, String[] usersRoleNames, TokenOptions tokenOptions, SigningCredentials signingCredentials)
        {
            var jwtSecurityToken = new JwtSecurityToken(
                audience: tokenOptions.Audience,
                issuer: tokenOptions.Issuer,
                claims: this.SetClaimsForIndividualStarter(userId, userFirstName, userLastName, userEmail, usersRoleNames),
                notBefore: DateTime.Now,
                expires: this.accessTokenExpirationDate,
                signingCredentials: signingCredentials
                );

            return jwtSecurityToken;
        }

        private JwtSecurityToken CreateJwtSecurityTokenForAuthorizedUserWithRoles(Guid userId, String registryNumber, String userEmail, String[] usersRoleNames, TokenOptions tokenOptions, SigningCredentials signingCredentials)
        {
            var jwtSecurityToken = new JwtSecurityToken(
                audience: tokenOptions.Audience,
                issuer: tokenOptions.Issuer,
                claims: this.SetClaimsForAuthorizedUser(userId, registryNumber, userEmail, usersRoleNames),
                notBefore: DateTime.Now,
                expires: this.accessTokenExpirationDate,
                signingCredentials: signingCredentials
                );

            return jwtSecurityToken;
        }

        private JwtSecurityToken CreateJwtSecurityTokenForCorporateUserWithRoles(Guid userId, String taxIdentityNumber, String userEmail, String[] usersRoleNames, TokenOptions tokenOptions, SigningCredentials signingCredentials)
        {
            var jwtSecurityToken = new JwtSecurityToken(
                audience: tokenOptions.Audience,
                issuer: tokenOptions.Issuer,
                claims: this.SetClaimsForCorporateUser(userId, taxIdentityNumber, userEmail, usersRoleNames),
                notBefore: DateTime.Now,
                expires: this.accessTokenExpirationDate,
                signingCredentials: signingCredentials
                );

            return jwtSecurityToken;
        }


        private IEnumerable<Claim> SetClaimsForIndividualStarter(Guid userId, String userFirstName, String userLastName, String userEmail, String[] usersRoleNames)
        {
            var claims = new List<Claim>();

            claims.AddId(userId);
            claims.AddFirstName(userFirstName);
            claims.AddLastName(userLastName);
            claims.AddEmail(userEmail);
            claims.AddRoles(usersRoleNames);

            return claims;
        }

        private IEnumerable<Claim> SetClaimsForCorporateUser(Guid userId, String taxIdentityNumber, String userEmail, String[] usersRoleNames)
        {
            var claims = new List<Claim>();

            claims.AddId(userId);
            claims.AddTaxIdentityNumber(taxIdentityNumber);
            claims.AddEmail(userEmail);
            claims.AddRoles(usersRoleNames);

            return claims;
        }

        private IEnumerable<Claim> SetClaimsForAuthorizedUser(Guid userId, String registryNumber, String userEmail, String[] usersRoleNames)
        {
            var claims = new List<Claim>();

            claims.AddId(userId);
            claims.AddRegistryNumber(registryNumber);
            claims.AddEmail(userEmail);
            claims.AddRoles(usersRoleNames);

            return claims;
        }

        private String CreateRefreshToken()
        {
            var numberByte = new byte[32];

            using var rnd = RandomNumberGenerator.Create();

            rnd.GetBytes(numberByte);

            return Convert.ToBase64String(numberByte);
        }
    }
}
