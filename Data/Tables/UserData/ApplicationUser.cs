using Microsoft.AspNetCore.Identity;

namespace JMPPAD.Data.Tables.UserData;

public class ApplicationUser : IdentityUser
{
    public bool DarkMode { get; set; }
}