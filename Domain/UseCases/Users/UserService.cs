using Auth.Models;
using Microsoft.AspNetCore.Identity;

namespace Domain.Services;

public class UserService(UserManager<ApplicationUser> userManager)
{
    public async Task<string> GetUserIdByUserNameAsync(string userName)
    {
        var user = await userManager.FindByNameAsync(userName)
            ?? throw new KeyNotFoundException($"User with username {userName} not found");

        return user.Id;
    }
}
