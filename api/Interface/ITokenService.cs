using api.Model;

namespace api.Interface;

public interface ITokenService
{
    string CreateToken(AppUser user);
}