using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Band.Sensors;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal sealed class BandUVReading : BandSensorReadingBase, IBandUVReading
    {
        private readonly Band.Sensors.IBandUVReading reading;

        public BandUVReading(Band.Sensors.IBandUVReading reading)
            : base(reading)
        {
            if (reading == null)
            {
                throw new ArgumentNullException("reading");
            }

            this.reading = reading;
        }

        #region IBandUVReading Members

        public UVIndexLevel IndexLevel
        {
            get
            {
                return FromBandIndexLevel(this.reading.IndexLevel);
            }
        }

        #endregion

        private static UVIndexLevel FromBandIndexLevel(Band.Sensors.UVIndexLevel indexLevel)
        {
            switch (indexLevel)
            {
                case Band.Sensors.UVIndexLevel.None:        return UVIndexLevel.None;
                case Band.Sensors.UVIndexLevel.Low:         return UVIndexLevel.Low;
                case Band.Sensors.UVIndexLevel.Medium:      return UVIndexLevel.Medium;
                case Band.Sensors.UVIndexLevel.High:        return UVIndexLevel.High;
                case Band.Sensors.UVIndexLevel.VeryHigh:    return UVIndexLevel.VeryHigh;

                default:

                    throw new ArgumentOutOfRangeException("indexLevel");
            }
        }
    }
}
