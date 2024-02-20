using BlogBE.Core.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BlogBE.Core.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<PostModel> Posts { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PostModel>()
                .HasOne(p => p.User)//postta bir user var ve User tablosuna gier
                .WithMany(u => u.Posts)//User tablosunda birden çok post vardır
                .HasForeignKey(p => p.UserId);//ve post tablosunun icerisinde user id var(FK)


            modelBuilder.Entity<UserModel>()
           .Property(u => u.Role)
           .HasConversion<string>();
        }
    }
}