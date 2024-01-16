using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetAPP.Core.Entities
{
    public class Solution
    {
        public int SolutionId { get; set; }
        public string NomSolution { get; set; }
        public virtual IList<Projet> Projets{ get; set; }
        public virtual IList<Ticket> Tickets { get; set; }


    }
}
