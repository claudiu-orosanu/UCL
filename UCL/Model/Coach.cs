using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCL.Model
{
    [Table("Coach", Schema = "UCL")]
    public class Coach : VersionedEntity
    {
        [Required]
        [MaxLength(25)]
        public virtual string FirstName { get; set; }

        [Required]
        [MaxLength(25)]
        public virtual string LastName { get; set; }

        public virtual int StartYear { get; set; }

        // 1 - primary coach; 2 - secondary coach
        public virtual int Type { get; set; }

        public virtual long? TeamId { get; set; }
        [ForeignKey("TeamId")]
        public virtual Team Team { get; set; }

        [NotMapped]
        public virtual string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

    }
}
