using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal sealed class BandRRIntervalReading : BandSensorReadingBase, IBandRRIntervalReading
    {
        private readonly Band.Sensors.IBandRRIntervalReading reading;

        public BandRRIntervalReading(Band.Sensors.IBandRRIntervalReading reading)
            : base(reading)
        {
            if (reading == null)
            {
                throw new ArgumentNullException("reading");
            }

            this.reading = reading;
        }

        #region IBandRRIntervalReading Members

        public double Interval
        {
            get
            {
                return this.reading.Interval;
            }
        }

        #endregion
    }
}
