using Management_Backend.Core.Enums;

namespace Management_Backend.Core.Entities;
public class Company : BaseEntity
{
    public string Name { get; set; }
    public CompanySize Size { get; set; } //Enum sınıfı(small,medium,large)
    public ICollection<Job> Jobs { get; set; } //Job classından kolleksiyon tutar.
}