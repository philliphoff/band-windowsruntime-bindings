using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Band.WindowsRuntime
{
    internal sealed class BandInfo : IBandInfo
    {
        private readonly Band.IBandInfo bandInfo;

        public BandInfo(Band.IBandInfo bandInfo)
        {
            this.bandInfo = bandInfo;
        }

        #region IBandInfo Members

        public BandConnectionType ConnectionType
        {
            get
            {
                switch (this.bandInfo.ConnectionType)
                {
                    case Band.BandConnectionType.Bluetooth:

                        return BandConnectionType.Bluetooth;

                    case Band.BandConnectionType.Usb:

                        return BandConnectionType.Usb;

                    default:

                        throw new InvalidOperationException("Unknown Band connection type.");
                }
            }
        }

        public string Name
        {
            get
            {
                return this.bandInfo.Name;
            }
        }

        #endregion

        public Band.IBandInfo ProxiedBandInfo
        {
            get
            {
                return this.bandInfo;
            }
        }
    }
}
