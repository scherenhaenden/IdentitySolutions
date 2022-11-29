using Microsoft.AspNetCore.Components;

namespace IdentityService.Web.Models.Account;

public class LoginModel
{
    public string Username { get; set; } = null!;

    public string Password { get; set; }= null!;
    
    [Parameter]
    public string[] BindingValue { get; set; }

    [Parameter]
    public EventCallback<string[]> BindingValueChanged { get; set; }
}