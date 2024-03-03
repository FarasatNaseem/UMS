namespace UMS.Infrastructure.DTOs
{
    using UMS.Infrastructure.Interfaces;
    public class UserContext : IUserContext
    {
        public UserContext()
        {
            Id = "10";
        }

        public string Id { get; set; }
    }
}