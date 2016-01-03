using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace Microsoft.Band.WindowsRuntime
{
    public sealed class BandClientManager : IBandClientManager
    {
        private static readonly Lazy<IBandClientManager> instance = new Lazy<IBandClientManager>(() => new BandClientManager());

        public static IBandClientManager Instance
        {
            get
            {
                return instance.Value;
            }
        }

        private BandClientManager()
        {
        }

        public IAsyncOperation<IBandClient> ConnectAsync(IBandInfo bandInfo)
        {
            var myBandInfo = bandInfo as BandInfo;

            if (myBandInfo == null)
            {
                throw new ArgumentException("Unrecognized IBandInfo implementation.");
            }

            return
                Band
                    .BandClientManager
                    .Instance
                    .ConnectAsync(myBandInfo.ProxiedBandInfo)
                    .ContinueWith<IBandClient>(task => new BandClient(task.Result))
                    .AsAsyncOperation();
        }

        public IAsyncOperation<IEnumerable<IBandInfo>> GetBandsAsync()
        {
            return
                Band
                    .BandClientManager
                    .Instance
                    .GetBandsAsync()
                    .ContinueWith<IEnumerable<IBandInfo>>(task => task.Result.Select(bandInfo => new BandInfo(bandInfo)).ToArray<IBandInfo>())
                    .AsAsyncOperation();
        }
    }
}
