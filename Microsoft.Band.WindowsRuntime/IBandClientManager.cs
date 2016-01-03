using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace Microsoft.Band.WindowsRuntime
{
    public interface IBandClientManager
    {
        IAsyncOperation<IBandClient> ConnectAsync(IBandInfo bandInfo);

        IAsyncOperation<IEnumerable<IBandInfo>> GetBandsAsync();
    }
}
