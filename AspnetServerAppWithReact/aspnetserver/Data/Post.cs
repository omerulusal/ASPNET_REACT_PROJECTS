using System.ComponentModel.DataAnnotations;

namespace aspnetserver.Data;
internal sealed class Post
{
    [Key]
    public int PostId { get; set; }// VeriTabanındaki Primary Key

    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MaxLength(100000)]
    public string Content { get; set; } = string.Empty; // string.Empty başlangıçta boş demektir.
}
/*!
 * internal: Aynı proje içindeki diğer kodlar tarafından erişilebilir olmasını sağlar, ancak dışarıdan erişilemez. 
 * sealed:Sınıfın başka sınıflar tarafından miras alınamayacağını belirtir.
 * Post.cs Veri Tabanındaki Oluşacak Olan Modeldir.
 */
