namespace UserHub.Dto;

public class FindUserDto{

    public required string IdNumber { get; set; }
    public required string Names { get; set; }
    public required string Surnames { get; set; }
    public required string Email { get; set; }
    public required string Role { get; set; }
    public DateTime LastSessionDate { get; set; }

}