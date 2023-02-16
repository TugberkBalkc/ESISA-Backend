using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Security.Authentication
{
    public class AccessToken 
    {
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }


        public AccessToken()
        {

        }

        public AccessToken(string token, DateTime expirationDate)
        {
            Token = token;
            ExpirationDate = expirationDate;
        }
    }
}
