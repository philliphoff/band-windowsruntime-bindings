using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal abstract class BandSensorReadingBase : IBandSensorReading
    {
        private readonly Band.Sensors.IBandSensorReading reading;

        protected BandSensorReadingBase(Band.Sensors.IBandSensorReading reading)
        {
            if (reading == null)
            {
                throw new ArgumentNullException("reading");
            }

            this.reading = reading;
        }

        #region IBandSensorReading Members

        public DateTimeOffset Timestamp
        {
            get
            {
                return this.reading.Timestamp;
            }
        }

        #endregion
    }
}
