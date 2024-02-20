using BlogBE.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace BlogBE.Core.Dtos.Post
{
    public class GetPostDto
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Img { get; set; }
        public string Content { get; set; }
        public long UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
