using UserHub.Dto;

namespace UserHub.Services
{
    public interface IAuthService
    {
        public ApiResponse Login(UserLoginDto user);
    }
}
