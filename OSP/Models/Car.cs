using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OSP.Models
{
    [Table("Car")]
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        [Display(Name ="Marka")]
        public string Name { get; set; }
        [Required]
        [StringLength(10)]
        [Display(Name ="Model")]
        public string Model { get; set; }
        [Required]
        [Display(Name = "Pojemoność zbiornika wody(l)")]
        public int Liters { get; set; }
    }
}
