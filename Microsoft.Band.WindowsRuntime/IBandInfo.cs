using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Band.WindowsRuntime
{
    public interface IBandInfo
    {
        BandConnectionType ConnectionType { get; }

        string Name { get; }
    }
}
