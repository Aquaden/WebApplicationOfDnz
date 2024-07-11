using System.ComponentModel.DataAnnotations;

namespace WebApplicationOfDnz.Data.Entities
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        [Required]  
        public string Name { get; set; }
        [MaxLength(20)]
        public string Surname { get; set;}
        
    }
}
