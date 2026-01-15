using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Models.Abstractions
{
    public interface ISyncStateStore
    {
        DateTime? GetLastSuccessfulSync(string entityName);
        Task SaveLastSuccessfulSyncAsync(string entityName, DateTime utc);
    }
}
