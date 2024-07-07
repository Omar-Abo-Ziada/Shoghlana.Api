using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shoghlana.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        [ForeignKey("Client")]
        public int? ClientId { get; set; }

        public Client? Client { get; set; }

        [ForeignKey("Freelancer")]
        public int? FreeLancerId { get; set; }

        public Freelancer? Freelancer { get; set; }

        [ForeignKey("Admin")]
        public int? AdminId { get; set; }

        public Admin? Admin { get; set; }

        public List<RefreshToken>? RefreshTokens { get; set; }

        public string? PasswordResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
    }
}