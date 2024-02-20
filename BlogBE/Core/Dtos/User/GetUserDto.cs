using BlogBE.Core.Enum;

namespace BlogBE.Core.Dtos.User
{
    public class GetUserDto
    {
        public long ID { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string UserImg { get; set; }
        public RoleEnum Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}