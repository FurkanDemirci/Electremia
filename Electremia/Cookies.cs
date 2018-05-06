using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace Electremia
{
    public class Cookies
    {
        private readonly List<Claim> _claims;

        /// <summary>
        /// Creating a cookie with the claims.
        /// </summary>
        /// <param name="username">string username</param>
        /// <param name="userId">string userId</param>
        public Cookies(string username, string userId)
        {
            _claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Sid, userId)
            };
        }

        /// <summary>
        /// Creating a cookie with the claims.
        /// </summary>
        /// <param name="username">string username</param>
        /// <param name="userId">string userId</param>
        /// <param name="role">string role</param>
        public Cookies(string username, string userId, string role)
        {
            _claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Sid, userId),
                new Claim(ClaimTypes.Role, role)
            };
        }

        /// <summary>
        /// Creates ClaimsIdentity using _claims field.
        /// </summary>
        /// <returns>new ClaimsIdentity</returns>
        private ClaimsIdentity ClaimsIdentity()
        {
            return new ClaimsIdentity(_claims, CookieAuthenticationDefaults.AuthenticationScheme);
        }

        /// <summary>
        /// Authentication property's can be added.
        /// </summary>
        /// <returns>new AuthenticationProperties</returns>
        public AuthenticationProperties AuthProperties()
        {
            return new AuthenticationProperties
            {
                // Extra's
            };
        }

        /// <summary>
        /// Getting the claimsPrincipal to add the cookie.
        /// </summary>
        /// <returns></returns>
        public ClaimsPrincipal ClaimsPrincipal()
        {
            return new ClaimsPrincipal(ClaimsIdentity());
        }

        /// <summary>
        /// Get user Id.
        /// </summary>
        /// <param name="user">User principal</param>
        /// <returns>int id</returns>
        public static int GetId(IPrincipal user)
        {
            var identity = (ClaimsIdentity)user.Identity;
            var claims = identity.Claims.ToList();

            try { return Convert.ToInt32(claims[1].Value); }
            catch { return 0; }
        }

        /// <summary>
        /// Get user Name.
        /// </summary>
        /// <param name="user">User principal</param>
        /// <returns>string name</returns>
        public static string GetName(IPrincipal user)
        {
            var identity = (ClaimsIdentity)user.Identity;
            var claims = identity.Claims.ToList();

            try { return claims[0].Value; }
            catch { return null; }
        }

        /// <summary>
        /// Get user Role.
        /// </summary>
        /// <param name="user">User principal</param>
        /// <returns>string role</returns>
        public static string GetRole(IPrincipal user)
        {
            var identity = (ClaimsIdentity)user.Identity;
            var claims = identity.Claims.ToList();

            try { return claims[2].Value; }
            catch { return null; }
        }
    }
}
