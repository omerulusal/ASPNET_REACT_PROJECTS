using Management_Backend.Core.Enums;

namespace Management_Backend.Core.Dtos.Company;
public class CompanyCreateDto
{
    public string Name { get; set; }
    public CompanySize Size { get; set; }
}
//Firma olusturmak icin girilmesi gereken girdiler