using System.ComponentModel.DataAnnotations;

namespace SSD_A1.Models
{
    public class Company
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public int YearsInBusiness { get; set; }
        [Required, Url]
        public string Website { get; set; }
        public string? Province { get; set; }
    }
}
