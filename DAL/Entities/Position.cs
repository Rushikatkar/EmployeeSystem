using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("Position")]
    public class Position
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Position is required.")]
        [MaxLength(50, ErrorMessage = "Position cannot exceed 50 characters.")]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }
    }
}
