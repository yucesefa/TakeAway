using System;

namespace TakeAway.IdentityServer.Tools
{
    public class TokenResponseViewModel
    {
        public TokenResponseViewModel(DateTime expireDate, string token)
        {
            ExpireDate = expireDate;
            Token = token;
        }
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
