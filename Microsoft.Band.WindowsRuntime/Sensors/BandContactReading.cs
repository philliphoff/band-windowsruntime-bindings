using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal sealed class BandContactReading : BandSensorReadingBase, IBandContactReading
    {
        private readonly Band.Sensors.IBandContactReading reading;

        public BandContactReading(Band.Sensors.IBandContactReading reading)
            : base(reading)
        {
            if (reading == null)
            {
                throw new ArgumentNullException("reading");
            }

            this.reading = reading;
        }

        #region IBandContactReading Members

        public BandContactState State
        {
            get
            {
                return FromBandContactState(this.reading.State);
            }
        }

        #endregion

        private static BandContactState FromBandContactState(Band.Sensors.BandContactState state)
        {
            switch (state)
            {
                case Band.Sensors.BandContactState.NotWorn: return BandContactState.NotWorn;
                case Band.Sensors.BandContactState.Worn:    return BandContactState.Worn;

                default:

                    throw new ArgumentOutOfRangeException("contactState");
            }
        }
    }
}
