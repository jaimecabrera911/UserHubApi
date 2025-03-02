namespace UserHub.Dto;

public class CreateUserDto: FindUserDto{
    public required string Password { get; set; }
}