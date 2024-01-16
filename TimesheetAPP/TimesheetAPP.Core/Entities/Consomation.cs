using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetAPP.Core.Entities
{
    public class Consomation
    {
        public int ConsomationId { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public DateTime NbHeure { get; set; }
        public virtual IList<Ticket> Tickets { get; set; }
        public virtual IList<Intervenant> Intervenants { get; set; }



    }
}
