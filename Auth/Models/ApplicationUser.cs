using Microsoft.AspNetCore.Identity;

namespace Auth.Models;

public class ApplicationUser : IdentityUser
{
    public required string LastName { get; set; }
    public required string FirstName { get; set; }
}
