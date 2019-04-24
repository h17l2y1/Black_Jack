
namespace BlackJackServices.Services.Interfaces
{
    public interface ICacheWrapperService
    {
        void SaveToCache(string key, Deck data);

        void RemoveFromCache(string key);

		Deck GetFromCache(string key);

    }
}
