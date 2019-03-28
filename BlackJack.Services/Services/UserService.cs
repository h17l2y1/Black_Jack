using BlackJackDataAccess.Repositories.Interfaces;
using BlackJackEntities.Entities;
using BlackJackServices.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackServices.Services
{
    public class UserServices : IUserService
    {
        private readonly IPlayerRepository _repository;

        public UserServices(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public object GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public object Get(string id)
        {
            return _repository.Get(id);
        }

        public Task Add(Player user)
        {
            return _repository.Add(user);
        }

        public void Update(Player user)
        {
            _repository.Update(user);
        }

        public void Remove(string id)
        {
            _repository.Remove(id);
        }

    }
}
