using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core6WebApi.Entities;

public class Course
{
    [Key]
    public int Id { get; set; }
     
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }

    [MaxLength(1500)]
    public string? Description { get; set; }

    [ForeignKey("AuthorId")]
    public Author Author { get; set; } = null!;

    public int AuthorId { get; set; }

    public Course(string title)
    {
        Title = title; 
    }
}

