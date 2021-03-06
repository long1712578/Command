using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    public class CommandCreateDto
    {
        [Required]
        public string HowTo { get; set; }
        [MaxLength(255)]
        public string Line { get; set; }
        public string Platform { get; set; }
    }
}