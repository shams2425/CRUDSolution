using System.ComponentModel.DataAnnotations;

namespace CRUD.Models;

public class Person
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage ="Enter your name")]
    public string Name { get; set; }

    [Range(1,100,ErrorMessage ="Enter age between 1 to 100")]
    public int Age { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string Gender { get; set; }


}
