using BlackJackEntities.Entities;

namespace BlackJackServices.Jwt
{
	public interface IJwtTokenProvider
	{
		string GetTokenString(Player user);
	}
}
