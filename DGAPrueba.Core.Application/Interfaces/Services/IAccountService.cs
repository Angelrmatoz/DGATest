using DGAPrueba.Core.Application.DTOS.Client.Account;
using Microsoft.AspNetCore.Identity.Data;
using RegisterRequest = DGAPrueba.Core.Application.DTOS.Client.Account.RegisterRequest;

namespace DGAPrueba.Core.application.Interfaces.Services;

public interface IAccountService
{
    Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
    Task<Boolean> DeleteUserByIdAsync(int code);
    Task<RegisterResponse> RegisterAsync(RegisterRequest vm);
    
    Task SignOutAsync();
    Task<List<SaveUserDTO>> GetAllAsync();
}