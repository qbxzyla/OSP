using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OSP.Models
{
    [Table ("Drive")]
    public class Drive
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("FirefighterId")]
        public int FirefighterId { get; set; }

        public Firefighter Firefighter { get; set; }

        [Display(Name = "test")]
        public virtual ICollection<Firefighter> Firefighters { get; }

        [ForeignKey("IncidentId")]
        public int IncidentId { get; set; }

        public Incident Incident { get; set; }

        [Display(Name = "test1")]
        public virtual ICollection<Incident> Incidents{ get; }

    }
}
