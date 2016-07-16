using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCL.Model.Nomenclatures
{
    [Table("Position", Schema = "Nom")]
    public class Position : BaseNomEntity
    {
        [InverseProperty("Position")]
        public virtual ICollection<Player> Players { get; set; }
    }
}
