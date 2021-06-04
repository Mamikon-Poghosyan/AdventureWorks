using AdventureWorks.Core.Enum;

namespace AdventureWorks.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public Role Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
