using BlackJackEntities.Entities;
using System.Threading.Tasks;

namespace BlackJackServices.Services.Interfaces
{
    public interface IUserService
    {
        object GetAll();

        object Get(string id);

        Task Add(User user);

        void Update(User user);

        void Remove(string id);
    }
}
