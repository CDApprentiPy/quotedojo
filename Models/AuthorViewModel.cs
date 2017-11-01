using System.ComponentModel.DataAnnotations;

namespace newqd.Models
{
    public class AuthorViewmodel : BaseEntity
    {
        [MinLength(6)]
        // [Required]
        public string name { get; set;}
    }
}