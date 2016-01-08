using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Band.Sensors;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal sealed class BandHeartRateReading : BandSensorReadingBase, IBandHeartRateReading
    {
        private readonly Band.Sensors.IBandHeartRateReading reading;

        public BandHeartRateReading(Band.Sensors.IBandHeartRateReading reading)
            : base(reading)
        {
            if (reading == null)
            {
                throw new ArgumentNullException("reading");
            }

            this.reading = reading;
        }

        #region IBandHeartRateReading Members

        public int HeartRate
        {
            get
            {
                return this.reading.HeartRate;
            }
        }

        public HeartRateQuality Quality
        {
            get
            {
                return FromBandQuality(this.reading.Quality);
            }
        }

        #endregion

        private HeartRateQuality FromBandQuality(Band.Sensors.HeartRateQuality quality)
        {
            switch (quality)
            {
                case Band.Sensors.HeartRateQuality.Acquiring:   return HeartRateQuality.Acquiring;
                case Band.Sensors.HeartRateQuality.Locked:      return HeartRateQuality.Locked;

                default:

                    throw new ArgumentOutOfRangeException("quality");
            }
        }
    }
}
