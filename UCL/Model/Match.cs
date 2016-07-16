using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCL.Model
{
    [Table("Match", Schema = "UCL")]
    public class Match : VersionedEntity
    {
        public virtual DateTime Date { get; set; }

        public virtual int HostScore { get; set; }

        public virtual int GuestScore { get; set; }

        // 1 - tur; 2 - retur
        public virtual int Type { get; set; }

        //specifica daca meciul s-a terminat la penalty-uri sau nu
        public virtual bool EndsWithPenalty { get; set; }

        public virtual long? HostId { get; set; }
        [ForeignKey("HostId")]
        public virtual Team Host { get; set; }

        public virtual long? GuestId { get; set; }
        [ForeignKey("GuestId")]
        public virtual Team Guest { get; set; }

        [InverseProperty("Match")]
        public virtual ICollection<MatchPlayer> MatchPlayer { get; set; }

        [NotMapped]
        public virtual Team Winner
        {
            get
            {
                if (HostScore > GuestScore)
                    return Host;
                else if (GuestScore > HostScore)
                    return Guest;
                else
                    return null;

            }
        }

        [NotMapped]
        public virtual string Score
        {
            get
            {
                return $"{HostScore}-{GuestScore}";

            }
        }

    }
}
