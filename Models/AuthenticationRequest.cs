namespace Api.Autenticacion.Jwt.Models;

public class AuthenticationRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}