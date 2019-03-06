using BlackJackDataAccess;
using BlackJackDataAccess.Repositories.Interfaces;
using BlackJackServices.Services.Interfaces;
using System.Linq;

namespace BlackJackServices.Services
{
    public class UserServices : IUserService 
    {
        private readonly IUserRepository _repository;

        public UserServices(IUserRepository repository)
        {
            _repository = repository;
        }

        public object GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public object Get(int id)
        {
            return _repository.Get(id);
        }

        public void Add(User user)
        {
            _repository.Add(user);
        }

        public void Update(User user)
        {
            _repository.Update(user);
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
        }

    }
}
