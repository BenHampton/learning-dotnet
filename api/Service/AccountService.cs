using api.Dto.Register;
using api.Interface;
using api.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Service;

public class AccountService: IAccountService
{
    
    private readonly UserManager<AppUser> _userManager;
    
    private readonly ITokenService _tokenService;
    
    private readonly SignInManager<AppUser> _signInManager;
    
    public AccountService(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
    }
    
    public async Task<UserDto?> FindLoginUser(LoginDto loginDto)
    {

        var user = await _userManager
            .Users
            .FirstOrDefaultAsync(u => u.UserName == loginDto.Username.ToLower());

        if (user == null)
        {
            return null;
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

        if (!result.Succeeded)
        {
            return null;
        }

        return buildUserDtoFromAppUser(user);
    }
    
    public async Task<UserDto?> RegisterUser(RegisterDto registerDto)
    {
        try
        {

            var appUser = buildAppUser(registerDto);
            
            var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

            if (!createdUser.Succeeded)
            {
                return null;
            }
            
            var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
           
            if (!roleResult.Succeeded)
            {
                return null;
            }

            return buildUserDtoFromAppUser(appUser);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private AppUser buildAppUser(RegisterDto registerDto)
    {
        return new AppUser
        {
            UserName = registerDto.Username,
            Email = registerDto.Email,
        };
    }
    
    private UserDto buildUserDtoFromAppUser(AppUser appUser)
    {
        return new UserDto
        {
            Username = appUser.UserName,
            Email = appUser.Email,
            Token = _tokenService.CreateToken(appUser)
        };
    }
}