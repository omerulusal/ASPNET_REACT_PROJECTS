namespace Management_Backend.Core.Dtos.Candidate;

public class CandidateCreateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int Phone { get; set; }
    public string CoverLetter { get; set; }
    public long JobId { get; set; }
}
//Aday Olusturmak icin gereken girdiler
//DTO : Data Transfer Object