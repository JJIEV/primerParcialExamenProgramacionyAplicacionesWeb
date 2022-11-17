using Api.Autenticacion.Jwt.Dto;

namespace Api.Autenticacion.Jwt.Interfaces;

public interface IUserService
{
    Task<User> GetByCredentials(string username, string password);
}