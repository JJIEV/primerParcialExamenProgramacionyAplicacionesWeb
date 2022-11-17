using Api.Autenticacion.Jwt.Dto;

namespace Api.Autenticacion.Jwt.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserByCredentials(string username, string password);
}
