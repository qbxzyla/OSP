using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace OSP.Models
{
    [Table("Crews")]
    public class Crew
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Data wyjazdu")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}")]
        public DateTime? DataS { get; set; }

        [ForeignKey("CarId")]
        public int CarId { get; set; }
        public Car? Cars { get; set; }

        [ForeignKey("FirefighterId")]
        public int FirefighterId {  get; set; }
        public virtual ICollection<Firefighter>? Firefighters { get; set; }

        [ForeignKey("DriverId")]
        public int DriverId { get; set; }
        public Firefighter? Driver { get; set; }

        [ForeignKey("IncidentId")]
        public int IncidentId {  get; set; }
        public Incident? Incident { get; set; }

    }
}
