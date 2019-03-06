using BlackJackDataAccess;
using BlackJackServices.Services.Interfaces;
using BlackJackViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace BlackJackServices.Services
{
    public class RegisterService : IRegisterService
    {
        //  регистрация \
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public RegisterService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task RegisterAsync(RegisterViewModel model)
        {
            User user = new User {
                Email = model.Email,
                UserName = model.Email 
        };
        // добавляем пользователя
         var result = await _userManager.CreateAsync(user, "Qwe123!!");
        }
    }
}
