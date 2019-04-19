using System.Collections.Generic;

namespace BlackJackViewModels.Account
{
    public class ResponseGetUsersAccount
    {
        public List<string> UserNames { get; set; }

        public ResponseGetUsersAccount(List<string> list)
        {
            UserNames = list;
        }
    }
}
