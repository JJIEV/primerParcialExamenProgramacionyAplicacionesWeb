using Api.Autenticacion.Jwt.Dto;
using Api.Autenticacion.Jwt.Interfaces;

namespace Api.Autenticacion.Jwt.Repositories;

public class UsersInMemoryRepository : IUserRepository
{
    private readonly List<User> _users = new List<User>
    {
        new()
        {
            Id       = 1,
            Fullname = "Juan Jose Escobar",
            Username = "jjiev",
            Password = "a.123456"
        },
        new()
        {
            Id = 2,
            Fullname = "Mathias de Mestral",
            Username = "mathias.demestral",
            Password = "a.123456"
        },
        new()
        {
            Id = 3,
            Fullname = "Jose Kuebler",
            Username = "jose.kuebler",
            Password = "caniche"
        }
    };

    public async Task<User?> GetUserByCredentials(string username, string password)
    {
        return _users.FirstOrDefault(p => p.Username.Equals(username) && p.Password.Equals(password));
    }
}
