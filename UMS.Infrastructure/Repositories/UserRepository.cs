namespace UMS.Infrastructure.Repositories
{
    using Microsoft.AspNetCore.Identity;
    using UMS.Infrastructure.Data;
    using UMS.Infrastructure.DTOs;
    using UMS.Infrastructure.Interfaces;

    /// <summary>
    /// Repository class for user-related operations utilizing Microsoft.AspNetCore.Identity in the UMS Infrastructure module.
    /// </summary>
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IUserContext _userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context for user-related data access.</param>
        /// <param name="userManager">The UserManager for managing user-related operations.</param>
        /// <param name="roleManager">The RoleManager for managing role-related operations.</param>
        /// <param name="userContext">The user context providing information about the current user.</param>
        public UserRepository(UMSDbContext dbContext, UserManager<User> userManager, RoleManager<Role> roleManager, IUserContext userContext) : base(dbContext)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._userContext = userContext;
        }

        /// <summary>
        /// Adds a new user to the repository, associating them with a specified role.
        /// </summary>
        /// <param name="user">The user object containing registration information.</param>
        /// <returns>An IdentityResult indicating the success or failure of the user addition.</returns>
        public async Task<IdentityResult> Add(User user)
        {
            // Find the role associated with the user by its Id
            var role = await this._roleManager.FindByIdAsync(user.RoleId.ToString());

            // Check if the role exists
            if (role == null)
            {
                return IdentityResult.Failed(new IdentityError { Code = "RoleNotFound", Description = $"Role with Id {user.RoleId} not found." });
            }

            // Check if the role is active
            if (!role.IsActive)
            {
                return IdentityResult.Failed(new IdentityError { Code = "RoleInactive", Description = $"Inactive Role" });
            }

            // Set additional user properties before creation
            user.EntryBy = Convert.ToInt32(this._userContext.Id);
            user.EntryDate = DateTime.Now;
            user.IsActive = true;

            // Create the user using UserManager
            var response = await this._userManager.CreateAsync(user, user.Password);

            // If user creation is successful, add them to the specified role
            if (response.Succeeded)
            {
                var result = this._userManager.AddToRoleAsync(user, role.Name);
            }

            return response;
        }
    }
}
