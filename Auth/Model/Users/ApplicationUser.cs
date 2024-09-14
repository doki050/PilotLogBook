using Microsoft.AspNetCore.Identity;

namespace Auth.Model.Users;

public class ApplicationUser : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}
