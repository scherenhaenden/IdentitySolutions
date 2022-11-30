using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;

namespace IdentityService.Web.Models.Account;

public class LoginModel
{
    [Required]
    public string Username { get; set; } = null!;
    
    [Required]
    public string Password { get; set; }= null!;
    
    [Parameter]
    public string[] BindingValue { get; set; }

    [Parameter]
    public EventCallback<string[]> BindingValueChanged { get; set; }
}