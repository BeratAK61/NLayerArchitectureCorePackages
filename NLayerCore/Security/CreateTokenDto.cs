namespace NLayerCore.Security;

public class CreateTokenDto
{
    public string UserId { get; set; }

    public string Name { get; set; }

    public string UserEmail { get; set; }

    public List<string> UserRoles { get; set; }


    public CreateTokenDto()
    {
        UserRoles = new List<string>();
    }

    public CreateTokenDto(string userId, string name, string userEmail, List<string> userRoles)
    {
        UserId = userId;
        Name = name;
        UserEmail = userEmail;
        UserRoles = userRoles;
    }
}
