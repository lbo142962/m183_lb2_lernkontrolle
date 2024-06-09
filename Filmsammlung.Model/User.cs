using System.ComponentModel.DataAnnotations;

namespace Filmsammlung.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Noten> notenListe{ get; set; }
    }
}
