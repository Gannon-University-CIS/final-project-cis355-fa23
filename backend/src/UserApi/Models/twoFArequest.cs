namespace UserApi.Models;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// Represents a request to authenticate a user.
/// </summary>
public class twoFArequest
{
    /// <summary>
    /// The 2FA of the user to authenticate.
    /// </summary>
    [Required]
    public string twoFAsecret { get; set; } = null!;

}