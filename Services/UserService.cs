using Api.Autenticacion.Jwt.Dto;
using Api.Autenticacion.Jwt.Interfaces;

namespace Api.Autenticacion.Jwt.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetByCredentials(string username, string password)
    {
        return await _userRepository.GetUserByCredentials(username, password);
    }
}