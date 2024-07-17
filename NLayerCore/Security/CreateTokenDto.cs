namespace NLayerCore.Security;

public class CreateTokenDto
{
    public JsonWebTokenOptions TokenOptions { get; set; }

    public string UserId { get; set; }

    public string UserEmail { get; set; }

    public string UserName { get; set; }

    public List<string> UserRoles { get; set; }


    public CreateTokenDto()
    {
        TokenOptions = new JsonWebTokenOptions();
        UserRoles = new List<string>();
    }
}
