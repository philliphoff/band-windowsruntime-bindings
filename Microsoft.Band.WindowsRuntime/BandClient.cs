using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace Microsoft.Band.WindowsRuntime
{
    internal sealed class BandClient : IBandClient
    {
        private readonly Band.IBandClient bandClient;

        public BandClient(Band.IBandClient bandClient)
        {
            if (bandClient == null)
            {
                throw new ArgumentNullException("bandClient");
            }

            this.bandClient = bandClient;
        }

        #region IBandClient Members

        public IAsyncOperation<string> GetFirmwareVersionAsync()
        {
            return AsyncInfo.Run(cancellationToken => this.bandClient.GetFirmwareVersionAsync(cancellationToken));
        }

        public IAsyncOperation<string> GetHardwareVersionAsync()
        {
            return AsyncInfo.Run(cancellationToken => this.bandClient.GetHardwareVersionAsync(cancellationToken));
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this.bandClient.Dispose();
        }

        #endregion
    }
}
