using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Security.Authentication
{
    public class Token 
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpirationDate { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpirationDate { get; set; }


        public Token()
        {

        }

        public Token(string accessToken, DateTime accessTokenExpirationDate, string refreshToken, DateTime refreshTokenExpirationDate)
        {
            AccessToken = accessToken;
            AccessTokenExpirationDate = accessTokenExpirationDate;
            RefreshToken = refreshToken;
            RefreshTokenExpirationDate = refreshTokenExpirationDate;
        }
    }
}
