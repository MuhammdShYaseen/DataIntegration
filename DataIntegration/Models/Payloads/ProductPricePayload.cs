using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Models.Payloads
{
    public record ProductPricePayload(string Unit, decimal Price);
}
