using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;

namespace Microsoft.Band.WindowsRuntime
{
    public interface IBandClient : IDisposable
    {
        IAsyncOperation<string> GetFirmwareVersionAsync();

        IAsyncOperation<string> GetHardwareVersionAsync();
    }
}
