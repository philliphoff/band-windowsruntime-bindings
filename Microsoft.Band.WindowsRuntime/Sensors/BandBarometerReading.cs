using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Band.Sensors;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal sealed class BandBarometerReading : BandSensorReadingBase, IBandBarometerReading
    {
        private Band.Sensors.IBandBarometerReading reading;

        public BandBarometerReading(Band.Sensors.IBandBarometerReading reading)
            : base(reading)
        {
            if (reading == null)
            {
                throw new ArgumentNullException("reading");
            }

            this.reading = reading;
        }

        #region IBandBarometerReading Members

        public double AirPressure
        {
            get
            {
                return this.reading.AirPressure;
            }
        }

        public double Temperature
        {
            get
            {
                return this.reading.Temperature;
            }
        }

        #endregion
    }
}
