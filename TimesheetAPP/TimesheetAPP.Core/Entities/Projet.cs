using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetAPP.Core.Entities
{
    public class Projet
    {
        public int ProjetId { get; set; }
        public string NomProjet { get; set; }
        public string DescriptionProjet { get; set; }
        public virtual IList<Projet_Intervenant> Projet_Intervenants { get; set; }

        [ForeignKey(nameof(SolutionId))]
        public int SolutionId { get; set; }
        public virtual Solution Solution { get; set; }
        public virtual IList<Ticket> Tickets { get; set; }




    }
}
