using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
    public class Command
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string HowTo { get; set; }
        [MaxLength(255)]
        public string Line { get; set; }
        public string Platform { get; set; }
    }
}