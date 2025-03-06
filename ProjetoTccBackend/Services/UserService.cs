using ProjetoTccBackend.Database.Requests;
using ProjetoTccBackend.Models;
using ProjetoTccBackend.Services.Interfaces;
//using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace ApiEstoqueASP.Services;

public class UserService : IUserService
{
    //private IMapper _mapper;
    private UserManager<User> _userManager;
    private SignInManager<User> _signInManager;

    public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        this._userManager = userManager;
        this._signInManager = signInManager;
    }

    public async Task<User?> RegisterUser(RegisterUserRequest user)
    {
        //User user = this._mapper.Map<User>(dto);

        // Checa se o email existe
        User? emailExists = _userManager.Users.Where(usr => usr.NormalizedEmail == user.Email.ToUpper()).FirstOrDefault();

        if (emailExists is not null)
        {
            return null;
        }

        User newUser = new User
        {
            UserName = user.UserName,
            Email = user.Email,
            JoinYear = user.JoinYear,
        };

        IdentityResult result = await _userManager.CreateAsync(newUser, user.Password);

        await _signInManager.UserManager.AddClaimAsync(newUser, new System.Security.Claims.Claim("Role", "User"));


        if (result.Succeeded == false)
        {
            return null;
        }

        // Adiciono o usuário registrado ao role "User"
        IdentityResult res = await this._userManager.AddToRoleAsync(newUser, "User");

        if (res.Succeeded == false)
        {
            return null;
        }

        return newUser;
    }

    public async Task<User?> LoginUser(LoginUserRequest usr)
    {
        //Console.WriteLine($"{dto.Email}, {dto.Password}");

        User? existentUser = _signInManager
            .UserManager
            .Users
            .FirstOrDefault(user => user.Email!.Equals(usr.Email));

        if (existentUser == null)
        {
            return null;
        }

        SignInResult result = await this._signInManager.PasswordSignInAsync(existentUser, usr.Password, false, false);

        if (result.Succeeded == false)
        {
            return null;
        }

        return existentUser;
    }
}
