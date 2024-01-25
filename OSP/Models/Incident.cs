using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OSP.Models
{
    [Table ("Incidents")]
    public class Incident
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength (250)]
        public string? Discription { get; set; }

        [Required]
        [StringLength(60)]
        public string? PlaceName { get; set; }

        [Display(Name = "Data zdarzenia")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}")]
        public DateTime? DataS { get; set; }

        [Display(Name ="Ekipa")]
        public Crew? Crew { get; set; }

        public string IN => PlaceName + " " + DataS;

    }
}
