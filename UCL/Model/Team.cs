using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCL.Model
{
    [Table("Team", Schema = "UCL")]
    public class Team : VersionedEntity
    {
        [Required]
        [MaxLength(25)]
        public virtual string Name { get; set; }

        [Required]
        [MaxLength(25)]
        public virtual string Country { get; set; }

        public virtual int? FormationYear { get; set; }

        public virtual bool Eliminated { get; set; }

        [InverseProperty("Team")]
        public virtual ICollection<Player> Players { get; set; }

        [InverseProperty("Team")]
        public virtual ICollection<Coach> Coaches { get; set; }

        [InverseProperty("Host")]
        public virtual ICollection<Match> MatchesPlayedAtHome { get; set; }

        [InverseProperty("Guest")]
        public virtual ICollection<Match> MatchesPlayedAway { get; set; }

        [InverseProperty("Team")]
        public virtual ICollection<Stadium> Stadium { get; set; }

    }
}
