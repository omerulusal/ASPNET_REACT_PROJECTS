using Management_Backend.Core.Enums;

namespace Management_Backend.Core.Entities;

public class Job : BaseEntity
{
    public string Title { get; set; }
    public JobLevel Level { get; set; }

    //Relation
    public long CompanyId { get; set; }
    public Company Company { get; set; }

    public ICollection<Candidate> Candidates { get; set; }//bir işe birden çok aday olabilir.

}
