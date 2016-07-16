using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCL.Model.Nomenclatures;

namespace UCL.Model
{
    [Table("Player", Schema = "UCL")]
    public class Player : VersionedEntity
    {
        [Required]
        [MaxLength(25)]
        public virtual string FirstName { get; set; }

        [Required]
        [MaxLength(25)]
        public virtual string LastName { get; set; }

        public virtual DateTime? DateOfBirth { get; set; }

        [MaxLength(25)]
        [Index("IX_Nationality")]
        public virtual string Nationality { get; set; }

        public virtual decimal? Salary { get; set; }

        public virtual int StartYear { get; set; }

        public virtual bool Available { get; set; }

        public virtual long? TeamId { get; set; }
        [ForeignKey("TeamId")]
        public virtual Team Team { get; set; }

        public virtual long? CaptainId { get; set; }
        [ForeignKey("CaptainId")]
        public virtual Player Captain { get; set; }

        public virtual long? PositionId { get; set; }
        [ForeignKey("PositionId")]
        public virtual Position Position { get; set; }

        [InverseProperty("Player")]
        public virtual ICollection<MatchPlayer> MatchPlayer { get; set; }

        [NotMapped]
        public virtual string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        [NotMapped]
        public virtual int Age
        {
            get
            {
                var Now = DateTime.Now;
                int Age = Now.Year - DateOfBirth.Value.Year;

                if (Now.Month < DateOfBirth.Value.Month ||
                    (Now.Month == DateOfBirth.Value.Month && Now.Day < DateOfBirth.Value.Day))
                    Age--;

                return Age;
            }

        }
    }
}
