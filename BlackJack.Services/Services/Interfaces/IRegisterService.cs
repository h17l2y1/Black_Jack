using BlackJackViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackServices.Services.Interfaces
{
    public interface IRegisterService
    {
        Task  RegisterAsync(RegisterViewModel model);
    }
}
