using Management_Backend.Core.Enums;

namespace Management_Backend.Core.Dtos.Job;
public class JobCreateDto
{
    public string Title { get; set; }
    public JobLevel Level { get; set; }
    public long CompanyId { get; set; }
}
//Is olusturmak icin girilmesi gerekilen girdiler