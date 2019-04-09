using System.Collections.Generic;

namespace BlackJackViewModels.Account
{
    public class ResponseGetAllAccountView
    {
        public List<PlayerAccountView> PlayersList { get; set; }

        public ResponseGetAllAccountView(List<PlayerAccountView> list)
        {
            PlayersList = list;
        }
    }
}
