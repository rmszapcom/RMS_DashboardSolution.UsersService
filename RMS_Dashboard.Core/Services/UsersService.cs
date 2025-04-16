using AutoMapper;
using RMS_Dashboard.Core.DTO;
using RMS_Dashboard.Core.Entities;
using RMS_Dashboard.Core.RepositoryContracts;
using RMS_Dashboard.Core.ServiceContracts;

namespace RMS_Dashboard.Core.Services;

internal class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;

    public UsersService(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }


    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
        ApplicationUser? user = await _usersRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

        if (user == null)
        {
            return null;
        }

        //return new AuthenticationResponse(user.UserID, user.Email, user.PersonName, user.Gender, "token", Success: true);
        return _mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = "token" };
    }


    public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
    {
        //Create a new ApplicationUser object from RegisterRequest
        ApplicationUser user = new ApplicationUser()
        {
            PersonName = registerRequest.PersonName,
            Email = registerRequest.Email,
            Password = registerRequest.Password,
            Gender = registerRequest.Gender.ToString()
        };
        ApplicationUser? registeredUser = await _usersRepository.AddUser(user);
        if (registeredUser == null)
        {
            return null;
        }

        //Return success response
        //return new AuthenticationResponse(registeredUser.UserID, registeredUser.Email, registeredUser.PersonName, registeredUser.Gender, "token", Success: true);
        return _mapper.Map<AuthenticationResponse>(registeredUser) with { Success = true, Token = "token" };
    }
}