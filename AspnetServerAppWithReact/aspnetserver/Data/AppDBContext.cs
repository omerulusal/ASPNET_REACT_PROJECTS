using Microsoft.EntityFrameworkCore;
namespace aspnetserver.Data;

internal sealed class AppDBContext : DbContext //DbContext:Veritabanı ile iletişim kurmayı sağlar.
{
    public DbSet<Post> Posts { get; set; }
    //DbSet CRUD işlemlerini sağlar. <Post> Dbde kullanacagım Modeldir.
    protected override void OnConfiguring(DbContextOptionsBuilder DbContextOptionsBuilder) => DbContextOptionsBuilder.UseSqlite("Data Source=./Data/AppDB.db");
    //DB Baglantısı SQLite kullanılarak oluşturulde ve .db dosyasının kayıt yeri belirtildi
    protected override void OnModelCreating(ModelBuilder ModelBuilder)
    // DB modelinin oluşturulma kodu
    {
        Post[] postToSeed = new Post[6];//postToSeed, Post Tipinde dizidir ve 6 elemanlı olucak
        for (int i = 1; i <= 6; i++)
        {
            postToSeed[i - 1] = new Post
            {
                PostId = i,
                Title = $"Post {i}",
                Content = $"Content Body {i}",
                //rastgele veri girdim
            };
        }
        ModelBuilder.Entity<Post>().HasData(postToSeed);
        //DB Modeli Post.cs teki Modelden oluşacak verilerde postToSeed dizisinden gelicek
    }
}

//Terminalde Girdigim Komutlar
/*
 * cd .\aspnetserver\ UYGULAMANIN BULUNDUGU DİZİN
 * dotnet add package Microsoft.EntityFrameworkCore.Design  //GEREKLİ PAKET
 * dotnet ef migrations add FirstMigration -o "Data/Migrations"  //OLUŞTURULACAK MIGRATION
 * dotnet ef database update  //MIGRATION GUNCELLEME
*/