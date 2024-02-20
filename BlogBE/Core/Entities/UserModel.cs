using BlogBE.Core.Enum;

namespace BlogBE.Core.Entities
{
    public class UserModel : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string UserImg { get; set; } = "https://st3.depositphotos.com/6672868/13701/v/450/depositphotos_137014128-stock-illustration-user-profile-icon.jpg";
        public RoleEnum Role { get; set; } = RoleEnum.User;
        public List<PostModel> Posts { get; set; } // Kullanıcının postları
    }
}
