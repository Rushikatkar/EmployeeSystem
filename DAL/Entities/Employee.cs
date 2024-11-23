using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(40, ErrorMessage = "Name cannot exceed 40 characters.")]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [MaxLength(200, ErrorMessage = "Name cannot exceed 200 characters.")]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }

        [ForeignKey("Position")]
        [DisplayName("Position")]
        public Nullable<int> PositionId { get; set; }

        public Position? Position { get; set; }

        [Required(ErrorMessage = "Date of Joining is required.")]
        [Display(Name = "Date of Joining")]
        public DateTime Date_Of_Joining { get; set; }
    }
}
