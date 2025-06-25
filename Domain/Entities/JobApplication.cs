using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class JobApplication
    {
        public JobApplication(string companyName, string position, string status, DateTime applicationDate)
        {
            CompanyName = companyName;
            Position = position;
            Status = status;
            ApplicationDate = applicationDate;
        }

        public JobApplication(int id, string companyName, string position, string status, DateTime applicationDate)
        {
            Id = id;
            CompanyName = companyName;
            Position = position;
            Status = status;
            ApplicationDate = applicationDate;
        }

        public int Id { get; private set; }

        [Required]
        public string CompanyName { get; private set; }

        [Required]
        public string Position { get; private set; }

        [Required]
        public string Status { get; private set; } // e.g., Applied, Interview, Offer, Rejected

        [Required]
        public DateTime ApplicationDate { get; private set; }
    }
}
