using System.ComponentModel.DataAnnotations;
namespace SixMinApi.Models
{
    public class Command
    {
        [Key]
        public int Id{get; set;}
        [Required]
        public string? HotTo {get; set;}
        [Required]
        [MaxLength(5)]
        public string? Platform { get; set;}
        [Required]
        public string? CommandLine {get; set;}

    }
}