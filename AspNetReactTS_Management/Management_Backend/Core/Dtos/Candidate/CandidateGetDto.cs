namespace Management_Backend.Core.Dtos.Candidate
{
    public class CandidateGetDto
    {
        public long ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string CoverLetter { get; set; }
        public string ResumeUrl { get; set; }
        public long JobId { get; set; }
        public string JobTitle { get; set; }
    }
}
//Olusturulan adayın Get yapılırken gosterilecek bilgileri