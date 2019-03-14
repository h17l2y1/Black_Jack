using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackServices.Services.Interfaces
{
    public interface IGameService
    {
        object StartGame(/*Guid*/ int userId, int countBots);

    }
}
