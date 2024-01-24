using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OSP.Models
{
    [Table("CarInAction")]
    public class CarInAction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("IncidentId")]
        public int IncidentId { get; set; }
        public Incident Incident { get; set; }
        [ForeignKey("CarId")]
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
