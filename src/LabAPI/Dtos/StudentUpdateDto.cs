using System.ComponentModel.DataAnnotations;
namespace LabAPI.Dtos
{
    public class StudentUpdateDto
    {
   
   [Required]
    public int Index {get; set;}
   
    [Required]
    public int Score {get; set;}
    [Required]
    public int Grade {get; set;}
    
    [Required]
    [MaxLength(25)]
    public string Name {get; set;}
    
    [Required]
    [MaxLength(50)]
    public string Surrname {get; set;}
    
    [Required]
    [MaxLength(250)]
    public string Description {get; set;}
    }       
}