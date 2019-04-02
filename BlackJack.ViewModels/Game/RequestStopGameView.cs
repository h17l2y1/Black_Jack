using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackViewModels.Requests
{
    public class RequestStopGameView
    {
        public string UserId { get; set; }
        public string GameId { get; set; }
    }
}
