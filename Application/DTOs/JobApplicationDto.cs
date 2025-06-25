using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class JobApplicationDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "CompanyName is required.")]
        public required string CompanyName { get; set; }

        [Required(ErrorMessage = "Position is required.")]
        public required string Position { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public required string Status { get; set; }

        [Required(ErrorMessage = "Applied date is required.")]
        public required DateTime ApplicationDate { get; set; }
    }
}
