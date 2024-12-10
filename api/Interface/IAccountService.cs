using api.Dto.Register;

namespace api.Interface;

public interface IAccountService
{
    public Task<UserDto?> FindLoginUser(LoginDto loginDto);

    public Task<UserDto?> RegisterUser(RegisterDto registerDto);
}