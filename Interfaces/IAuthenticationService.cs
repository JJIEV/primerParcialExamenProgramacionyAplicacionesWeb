using Api.Autenticacion.Jwt.Dto;

namespace Api.Autenticacion.Jwt.Interfaces;

public interface IAuthenticationService
{
    Task<bool> Authenticate(string username, string password);
    Task<string> GenerateJwt(User user);
}