using BlackJackDataAccess;

namespace BlackJackServices.Services.Interfaces
{
    public interface IUserService
    {
        object GetAll();

        object Get(int id);

        //object Find()

        void Add(User user);

        void Update(User user);

        void Remove(int id);
    }
}
