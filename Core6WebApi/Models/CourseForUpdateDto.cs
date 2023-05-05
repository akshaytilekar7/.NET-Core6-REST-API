using System.ComponentModel.DataAnnotations;

namespace Core6WebApi.Models;

public class CourseForUpdateDto : CourseForManipulationDto
{
    [Required(ErrorMessage = "You should fill out a description.")]
    public override string Description { 
        get => base.Description; set => base.Description = value; }
}