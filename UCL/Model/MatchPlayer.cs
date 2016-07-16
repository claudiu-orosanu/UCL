using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCL.Model
{
    [Table("MatchPlayer", Schema = "UCL")]
    public class MatchPlayer : VersionedEntity
    {
        public virtual int? MinutesPlayed { get; set; }

        //rating-ul jucatorului: 0 - 100
        public virtual int Rating { get; set; }

        public virtual int Goals { get; set; }

        public virtual int RedCards { get; set; }

        public virtual int YellowCards { get; set; }

        [Index("UX_PlayerIdAndMatchId", 1, IsUnique = true)]
        public virtual long? PlayerId { get; set; }
        [ForeignKey("PlayerId")]
        public virtual Player Player { get; set; }

        [Index("UX_PlayerIdAndMatchId", 2, IsUnique = true)]
        public virtual long? MatchId { get; set; }
        [ForeignKey("MatchId")]
        public virtual Match Match { get; set; }
    }
}
