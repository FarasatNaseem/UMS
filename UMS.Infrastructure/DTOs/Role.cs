namespace UMS.Infrastructure.DTOs
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents a role in the system with additional attributes.
    /// </summary>
    public class Role : IdentityRole<int>
    {
        /// <summary>
        /// Gets or sets the code associated with the role.
        /// </summary>
        [Required, StringLength(maximumLength: 10, MinimumLength = 2)]
        public string? Code { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the role is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user who made the entry.
        /// </summary>
        public int? EntryBy { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the entry was made.
        /// </summary>
        public DateTime? EntryDate { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user who last updated the role.
        /// </summary>
        public int? UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the role was last updated.
        /// </summary>
        public DateTime? UpdatedDate { get; set; }
    }
}