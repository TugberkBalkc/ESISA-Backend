using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Dtos.Security.Authentication;
using ESISA.Core.Application.Dtos.Security.Authorization;
using ESISA.Core.Application.Interfaces.Handlers;
using ESISA.Core.Application.Options.Authentication;
using ESISA.Core.Application.Utilities.Security.Encryption;
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
    public class JwtAccessTokenHandler : IAccessTokenHandler
    {
        private readonly AccessTokenOptions _accessTokenOptions;

        public JwtAccessTokenHandler(IOptions<AccessTokenOptions> options)
        {
            _accessTokenOptions = options.Value;
        }

        private DateTime expirationDate { get; set; }

        public AccessToken CreateAccessToken(Guid userId, string userFirstName, string userLastName, string userEmail, string[] usersRoleNames)
        {
            expirationDate = DateTime.Now.AddMinutes(_accessTokenOptions.TokenLifeTimeInMinutes);

            var symmetricSercurityKey = SecurityKeyHelper.CreateSymmetricSecurityKey(_accessTokenOptions.SecretKey);

            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentialsBySymmetricSecurityKey(symmetricSercurityKey);

            var jwtSecurityToken = this.CreateJwtSecurityTokenWithRoles(userId, userFirstName, userLastName, userEmail, usersRoleNames, _accessTokenOptions, signingCredentials);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            String token = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            return new(token, expirationDate);
        }

        private JwtSecurityToken CreateJwtSecurityTokenWithRoles(Guid userId, String userFirstName, String userLastName, String userEmail, String[] usersRoleNames, AccessTokenOptions accessTokenOptions, SigningCredentials signingCredentials)
        {
            var jwtSecurityToken = new JwtSecurityToken(
                audience: accessTokenOptions.Audience,
                issuer: accessTokenOptions.Issuer,
                claims: this.SetClaims(userId, userFirstName, userLastName, userEmail, usersRoleNames),
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(_accessTokenOptions.TokenLifeTimeInMinutes),
                signingCredentials: signingCredentials
                );

            return jwtSecurityToken;
        }

        private IEnumerable<Claim> SetClaims(Guid userId, String userFirstName, String userLastName, String userEmail, String[] usersRoleNames)
        {
            var claims = new List<Claim>();

            claims.AddId(userId);
            claims.AddFirstName(userFirstName);
            claims.AddLastName(userLastName);
            claims.AddEmail(userEmail);
            claims.AddRoles(usersRoleNames);

            return claims;
        }
    }
}
