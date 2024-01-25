using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OSP.Models
{
    [Table("Firefighter")]
    public class Firefighter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Imie")]
        public string? Name { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nazwisko")]
        public string? Surname { get; set; }

        [Display(Name = "Ważność badań")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataS { get; set; }

        [Display (Name = "Kierowca")]
        public bool Driver { get; set; }
        [Display (Name = "Dowódca")]
        public bool Commander { get; set; }


    }
}
