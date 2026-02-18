using RepoDemo.Models;

namespace RepoDemo.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByUsernameAsync(string username);
        Task AddUserAsync(User user);
    }
}
