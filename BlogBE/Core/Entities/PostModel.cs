using System.ComponentModel.DataAnnotations;

namespace BlogBE.Core.Entities
{
    public class PostModel : BaseEntity
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Img { get; set; }
        [MaxLength(10000)]
        public string Content { get; set; }

        //Relations
        public long UserId { get; set; } // Kullanıcıya referans için FK
        public UserModel User { get; set; } // Kullanıcı nesnesi
    }
}