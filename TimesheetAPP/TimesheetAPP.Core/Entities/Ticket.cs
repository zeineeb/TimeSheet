using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetAPP.Core.Entities
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string NomTicket { get; set; }
        public string DecriptionTicket { get; set; }
        public Priority Priority { get; set; }
        public Severity Severity { get; set; }
        public State State  { get; set; }

        [ForeignKey(nameof(ConsomationId))]
        public int ConsomationId { get; set; }
        public virtual Consomation Consomation { get; set; }

        [ForeignKey(nameof(SolutionId))]
        public int SolutionId { get; set; }
        public virtual Solution Solution { get; set; }


    }
}
