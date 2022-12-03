using System.ComponentModel.DataAnnotations;

namespace MyStatWebApplication.Models;

public class Homework
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(1028)]
    public string? Description { get; set; }
    [Required]
    public DateTime DateTime { get; set; }
}
