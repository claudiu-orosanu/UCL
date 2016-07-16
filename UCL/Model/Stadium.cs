using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCL.Model
{
    [Table("Stadium", Schema = "UCL")]
    public class Stadium : VersionedEntity
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MaxLength(25)]
        public string City { get; set; }

        public int Capacity { get; set; }

        //index de unicitate pe FK pt ca e relatie 1-1
        [Index("UX_Team", IsUnique = true)]
        public virtual long? TeamId { get; set; }
        [ForeignKey("TeamId")]
        public virtual Team Team { get; set; }
    }
}
