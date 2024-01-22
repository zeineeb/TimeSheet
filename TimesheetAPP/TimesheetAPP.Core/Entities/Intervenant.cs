using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetAPP.Core.Entities
{
    public class Intervenant
    {
        public int IntervenantId { get; set; }
        public string Username { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        public string Password { get; set; }
        public DateTime? DateDeNaissnace { get; set; }
        public bool? ClientExistance { get; set; }
        public virtual IList<Projet_Intervenant>? Projet_Intervenants { get; set; }
        [ForeignKey(nameof(ConsomationId))]
        public int? ConsomationId { get; set; }
        public virtual Consomation? Consomation { get; set; }

        public bool? IsVerified { get; set; }
        public string? ResetToken { get; set; }
        public string? NewPassword { get; set; }


    }
}
