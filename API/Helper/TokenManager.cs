using DatabaseAccess;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace API.Helper
{
    public class TokenManager
    {
        public static string secrect = "qweyuiopasdfghjklzxcvbnm";
        public static string generateToken(User user)
        {
            byte[] key = Convert.FromBase64String(secrect);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("ID", user.id),
                    new Claim("FULLNAME", user.fullname),
                    new Claim("ROLE", user.role.ToString()),
                    new Claim("EMAIL", user.email),
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }


        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
                if (jwtToken == null) return null;
                byte[] key = Convert.FromBase64String(secrect);
                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
                SecurityToken securityToken;

                // var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                // if (context.UserName == "admin" && context.Password == "admin")
                // {
                //     identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                //    identity.AddClaim(new Claim("username", "admin"));
                //    identity.AddClaim(new Claim(ClaimTypes.Name, "Hi Admin"));
                //    context.Validated(identity);
                // }

                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, parameters, out securityToken);
                return principal;
            }
            catch
            {
                return null;
            }
        }

        public static User ValidateToken(string token)
        {

            ClaimsPrincipal principal = GetPrincipal(token);
            if (principal == null) return null;
            ClaimsIdentity identity = null;
            try
            {
                identity = (ClaimsIdentity)principal.Identity;
            }
            catch (NullReferenceException)
            {
                return null;
            }

            Claim id = identity.FindFirst("ID");
            Claim fullname = identity.FindFirst("FULLNAME");
            Claim email = identity.FindFirst("EMAIL");
            Claim role = identity.FindFirst("ROLE");
            User user = new User();
            user.id = id.Value;
            user.fullname = fullname.Value;
            user.email = email.Value;
            user.role = Int32.Parse(role.Value);
            return user;
        }
    }
}