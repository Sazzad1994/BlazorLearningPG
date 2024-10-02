using System.ComponentModel.DataAnnotations;

namespace CRUDProject.Client.Models
{
    public class PersonModel
    {
        [Required(ErrorMessage = "Name Should be minimum 5 length")]
        [MinLength(5)]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Name Should be minimum 10 length")]
        [MinLength(10)]
        public string? LastName { get; set; }
    }
}
