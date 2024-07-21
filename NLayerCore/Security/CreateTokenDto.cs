﻿namespace NLayerCore.Security;

public class CreateTokenDto
{
    public string UserId { get; set; }

    public string UserEmail { get; set; }

    public string UserName { get; set; }

    public List<string> UserRoles { get; set; }


    public CreateTokenDto()
    {
        UserRoles = new List<string>();
    }

    public CreateTokenDto(string userId, string userEmail, string userName, List<string> userRoles)
    {
        UserId = userId;
        UserEmail = userEmail;
        UserName = userName;
        UserRoles = userRoles;
    }
}
