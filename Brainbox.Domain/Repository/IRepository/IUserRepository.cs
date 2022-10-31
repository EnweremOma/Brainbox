using Brainbox.Domain.Models;

namespace Brainbox.Domain.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        void Update(User obj);
        void Save();
    }
}
