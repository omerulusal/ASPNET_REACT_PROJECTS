using Management_Backend.Core.Enums;

namespace Management_Backend.Core.Dtos.Company;

public class CompanyGetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public CompanySize Size { get; set; }//Enum
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
//Firma ya Get istegi yapılırken gosterilmesi istenilen girdiler