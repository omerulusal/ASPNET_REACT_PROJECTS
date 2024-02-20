namespace BlogBE.Core.Dtos.Post
{
    public class UpdatePostDto
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Img { get; set; }
        public string Content { get; set; }
        public long UserId { get; set; }

    }
}
