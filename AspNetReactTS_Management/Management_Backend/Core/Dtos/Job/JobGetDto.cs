using Management_Backend.Core.Entities;
using Management_Backend.Core.Enums;

namespace Management_Backend.Core.Dtos.Job
{
    public class JobGetDto
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public JobLevel Level { get; set; }
        public long CompanyId { get; set; }
        public string CompanyName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
//Is Bilgileri icin Get istegi atilirken gosterilecek girdiler