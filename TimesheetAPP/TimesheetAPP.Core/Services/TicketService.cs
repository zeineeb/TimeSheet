using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.VisualStudio.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetAPP.Core.Interfaces;

namespace TimesheetAPP.Core.Services
{
    public class TicketService: ITicketService
    {
        private readonly Uri uri;
        private readonly string personalAccessToken;

        public TicketService(string orgName, string personalAccessToken)
        {
            uri = new Uri($"https://dev.azure.com/{orgName}");
            this.personalAccessToken = personalAccessToken;
        }

        public async Task<List<WorkItem>> GetOpenBugsAsync(string project)
        {
            var credentials = new VssBasicCredential(string.Empty, personalAccessToken);

            var wiql = new Wiql
            {
                Query = $"Select [Id] From WorkItems"
            };

            using (var httpClient = new WorkItemTrackingHttpClient(uri, credentials))
            {
                var result = await httpClient.QueryByWiqlAsync(wiql).ConfigureAwait(false);
                var ids = result.WorkItems.Select(item => item.Id).ToArray();

                if (ids.Length == 0)
                {
                    return new List<WorkItem>();
                }

                var fields = new[] { "System.Id", "System.Title", "System.State" };
                return await httpClient.GetWorkItemsAsync(ids, fields, result.AsOf).ConfigureAwait(false);
            }
        }
    }
}
