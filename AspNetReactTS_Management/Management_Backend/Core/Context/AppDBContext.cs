using Management_Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Management_Backend.Core.Context;
public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {
    }

    public DbSet<Company> Companies { get; set; }
    //DbSet ler veri tabanı tablolarıdır
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Candidate> Candidates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)//veritabanı modelinin yapılandırılması için kullanılır.
    //override OnModel+Enter yazınca iskelet yapı otomatik oluşturulacak
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Job>()//bire çok ilişki yapısı
            .HasOne(j => j.Company)
            .WithMany(c => c.Jobs)
            .HasForeignKey(j => j.CompanyId);

        modelBuilder.Entity<Candidate>()
            .HasOne(kisi => kisi.Job)//kişinin 1 işi olur
            .WithMany(j => j.Candidates)//işe 1den çok aday basvuru yapabilir
            .HasForeignKey(i => i.JobId);//yabancı anahtar


        //Enum degerlerin veritabanına eklenmesi
        modelBuilder.Entity<Company>()
            .Property(c => c.Size)
            .HasConversion<string>();
        //Propertyler enum değerlerinin veritabanında saklanmasını ve okunmasını düzenler.
        modelBuilder.Entity<Job>()
            .Property(j => j.Level)
            .HasConversion<string>();
    }
}
