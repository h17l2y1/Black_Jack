using BlackJackEntities.Entities;
using BlackJackServices.Services.Auth;
using BlackJackServices.Services.Interfaces;
using BlackJackViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlackJackServices.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<Player> _userManager;
        private readonly SignInManager<Player> _signInManager;

        public AccountService(UserManager<Player> userManager, SignInManager<Player> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<object> GetAllAsync()
        {
            var usersList = await _userManager.Users.ToListAsync();
            return usersList;
        }

        public async Task<object> FindByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;
        }

        public async Task AddAsync(RegisterView model)
        {
            Player user = new Player
            {
                UserName = model.Name,
                Points = model.Points,
                Role = "User"
            };

            await _userManager.CreateAsync(user);
        }

        public JwtSecurityToken GetToken(RegisterView model)
        {
            var identity = GetIdentity(model);

            if (identity == null)
            {
                return null;
            }

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: DateTime.UtcNow,
                    claims: identity.Claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
                    );
            return jwt;
        }

        private ClaimsIdentity GetIdentity(RegisterView model)
        {
            Player user = _userManager.Users.FirstOrDefault(x => x.UserName == model.Name);
            if (user != null)
            {
                var claimsList = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, model.Name),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, model.Role),
                    new Claim("aaa","bb"),


                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                    claimsList,
                    "Token"
                    );

                return claimsIdentity;
            }

            return null;
        }

        public string GetTokenString(JwtSecurityToken jwt)
        {
            var stringToken = new JwtSecurityTokenHandler().WriteToken(jwt);
            return stringToken;
        }

        public async Task RemoveAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
        }

        public bool UserIsExist(string newUser)
        {
            var userIsExist = _userManager.Users.FirstOrDefault(x => x.UserName == newUser);

            if (userIsExist != null)
            {
                return true;
            }
            return false;
        }
    }
}
