using Microsoft.EntityFrameworkCore;

namespace agrinex_backend.Models;

public class  User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = "";

    public string LastName { get; set; } = "";

    public int RoleId { get; set; } //Foreign Key

    public Role Role { get; set; } = null!; // Navigation of the RoleId

    public string Email { get; set; } = "";

    public string PasswordHash { get; set; } = "";

    public string ContactNumber { get; set; } = "";

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

}