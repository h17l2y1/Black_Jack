using BlackJackEntities.Entities;
using System.Threading.Tasks;

namespace BlackJackServices.Services.Interfaces
{
    public interface IPlayerService
    {
        object GetAll();

        object Get(string id);

        Task Add(Player user);

        void Update(Player user);

        void Remove(string id);
    }
}
