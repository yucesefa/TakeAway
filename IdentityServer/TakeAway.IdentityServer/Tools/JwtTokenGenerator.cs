﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TakeAway.IdentityServer.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseViewModel GenerateToken(GetCheckAppUserViewModel model)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, model.Id));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, model.Id));
            claims.Add(new Claim("UserName", model.UserName));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
            var signInCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);

            JwtSecurityToken token = new JwtSecurityToken(issuer: JwtTokenDefaults.ValidIssuer, audience: JwtTokenDefaults.ValidAuidence,claims: claims, notBefore: DateTime.UtcNow, expires: expireDate, signingCredentials: signInCredentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return new TokenResponseViewModel(handler.WriteToken(token), expireDate);
        }
    }
}
