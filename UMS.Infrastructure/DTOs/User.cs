namespace UMS.Infrastructure.DTOs
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    public class User : IdentityUser<int>
    {
        [Required, StringLength(maximumLength: 100, MinimumLength = 2)]
        public string? FullName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 12)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public bool IsActive { get; set; }
        [Required]
        public int RoleId { get; set; }
        public int? EntryBy { get; set; }
        public DateTime? EntryDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [ForeignKey(nameof(RoleId))]
        public Role? Role { get; set; }
    }
}
