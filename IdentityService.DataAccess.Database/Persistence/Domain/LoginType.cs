using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Domain.InnerTenant;
using Microsoft.EntityFrameworkCore;

//using Org.BouncyCastle.Asn1.X509.Qualified;

namespace IdentityService.DataAccess.Database.Persistence.Domain;

[Index(nameof(TypeString), IsUnique = true)]
public class LoginType :BaseEntity,  ILoginType
{
    
    
    [Column("LoginTypeName")]
    public string TypeString
    {
        get { return LoginTypeName.ToString(); }
        set { LoginTypeName= value.ParseEnum<LoginTypes>(); }
    }
    
    [NotMapped]
    public LoginTypes LoginTypeName { get; set; }

    public string? Description { get; set; }
}

public enum LoginTypes  
{
    [Description("BasicEmailAndPassword")]
    BasicEmailAndPassword,
    [Description("BasicUserAndPassword")]
    BasicUserAndPassword
}
public static class StringExtensions
{
    public static T ParseEnum<T>(this string value)
    {
        return (T)Enum.Parse(typeof(T), value, true);
    }
}

/*
public enum LoginTypes : int
{
    [Description("Email")]
    Email = 1,
    [Description("Phone")]
    Phone = 2,
    [Description("Username")]
    Username = 3,
    [Description("Facebook")]
    Facebook = 4,
    [Description("Google")]
    Google = 5,
    [Description("Twitter")]
    Twitter = 6,
    [Description("LinkedIn")]
    LinkedIn = 7,
    [Description("Instagram")]
    Instagram = 8,
    [Description("GitHub")]
    GitHub = 9,
    [Description("Yahoo")]
    Yahoo = 10,
    [Description("Microsoft")]
    Microsoft = 11,
    [Description("Apple")]
    Apple = 12,
    [Description("Amazon")]
    Amazon = 13,
    [Description("PayPal")]
    PayPal = 14,
    [Description("Other")]
    Other = 15
}*/