using System.Collections.Concurrent;
using Microsoft.AspNetCore.Identity;

namespace JMPPAD.Services;

public class LoginInfo
{
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}

public class LoginMiddleware
{
    private readonly RequestDelegate _next;

    public LoginMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public static IDictionary<Guid, LoginInfo> Logins { get; } = new ConcurrentDictionary<Guid, LoginInfo>();

    public async Task Invoke(HttpContext context, SignInManager<IdentityUser> signInMgr)
    {
        // Login request
        if (context.Request.Path == "/login" && context.Request.Query.ContainsKey("key"))
        {
            var key = Guid.Parse(context.Request.Query["key"]!);
            var info = Logins[key];

            if (info is {Username: { }, Password: { }})
            {
                var result = await signInMgr.PasswordSignInAsync(info.Username, info.Password, false, true);
                info.Password = null;
                if (!result.Succeeded) throw new Exception("Login failed. Please contact support for assistance.");
            }

            Logins.Remove(key);
            context.Response.Redirect("/");
            return;
        }

        // Logout request
        if (context.Request.Path == "/logout")
        {
            if (signInMgr.IsSignedIn(context.User)) await signInMgr.SignOutAsync();

            context.Response.Redirect("/");
            return;
        }

        // Register request
        if (context.Request.Path == "/register" && context.Request.Query.ContainsKey("key"))
        {
            var key = Guid.Parse(context.Request.Query["key"]!);
            var info = Logins[key];

            var user = new IdentityUser
            {
                UserName = info.Username,
                NormalizedUserName = info.Username?.ToUpper(),
                Email = info.Email,
                NormalizedEmail = info.Email?.ToUpper()
            };

            if (info.Password != null)
            {
                var registerResult = await signInMgr.UserManager.CreateAsync(user, info.Password);
                if (!registerResult.Succeeded) throw new Exception(string.Join(", ", registerResult.Errors.Select(i => i.Description)));
            }

            if (info is {Username: { }, Password: { }})
            {
                var signInResult = await signInMgr.PasswordSignInAsync(info.Username, info.Password, false, true);
                info.Password = null;
                if (!signInResult.Succeeded) throw new Exception("Login failed. Please contact support for assistance.");
            }

            Logins.Remove(key);
            context.Response.Redirect("/");
            return;
        }

        await _next.Invoke(context);
    }
}