using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetAPP.Core.Entities
{
    public class Projet_Intervenant
    {
        public int Projet_IntervenantId { get; set; }

        [ForeignKey(nameof(IntervenantId))]
        public int IntervenantId { get; set; }
        public virtual Intervenant Intervenant { get; set; }

        [ForeignKey(nameof(ProjetId))]
        public int ProjetId { get; set; }
        public virtual Projet Projet { get; set; }
    }
}
