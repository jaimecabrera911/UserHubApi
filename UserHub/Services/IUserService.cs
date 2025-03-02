using UserHub.Dto;

namespace UserHub.Services;

public interface IUserService
{
    IEnumerable<FindUserDto> GetUsers();
    FindUserDto GetUser(string idNumber);

    FindUserDto GetUserByEmail(string email);
    void CreateUser(CreateUserDto user);
    CreateUserDto UpdateUser(string idNumber, CreateUserDto user);
    void DeleteUser(string idNumber);
}
