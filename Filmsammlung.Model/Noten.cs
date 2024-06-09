using System.ComponentModel.DataAnnotations;

namespace Filmsammlung.Model
{
    public class Noten
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int userId { get; set; }
        public User User { get; set; }

    }
}
