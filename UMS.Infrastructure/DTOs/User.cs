namespace UMS.Infrastructure.DTOs
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Represents a user in the system with additional attributes.
    /// </summary>
    public class User : IdentityUser<int>
    {
        /// <summary>
        /// Gets or sets the full name of the user.
        /// </summary>
        [Required, StringLength(maximumLength: 100, MinimumLength = 2)]
        public string? FullName { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 12)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the role associated with the user.
        /// </summary>
        [Required]
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user who made the entry.
        /// </summary>
        public int? EntryBy { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the entry was made.
        /// </summary>
        public DateTime? EntryDate { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user who last updated the user.
        /// </summary>
        public int? UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the user was last updated.
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets the role associated with the user.
        /// </summary>
        [ForeignKey(nameof(RoleId))]
        public Role? Role { get; set; }
    }
}