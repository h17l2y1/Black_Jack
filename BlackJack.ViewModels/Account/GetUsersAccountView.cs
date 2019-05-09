using System.Collections.Generic;

namespace BlackJackViewModels.Account
{
    public class GetUsersAccountView
    {
        public List<string> UserNames { get; set; }

		public GetUsersAccountView()
		{
		}

		public GetUsersAccountView(List<string> list)
        {
            UserNames = list;
        }
    }
}
