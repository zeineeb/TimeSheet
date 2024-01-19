using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetAPP.Core.Interfaces
{
    public interface ITicketService
    {
        public Task<List<WorkItem>> GetOpenBugsAsync(string project);
    }
}
