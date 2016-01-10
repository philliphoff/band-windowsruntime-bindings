using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal sealed class BandPedometerReading : BandSensorReadingBase, IBandPedometerReading
    {
        private readonly Band.Sensors.IBandPedometerReading reading;

        public BandPedometerReading(Band.Sensors.IBandPedometerReading reading)
            : base(reading)
        {
            if (reading == null)
            {
                throw new ArgumentNullException("reading");
            }

            this.reading = reading;
        }

        #region IBandPedometerReading Members

        public long TotalSteps
        {
            get
            {
                return this.reading.TotalSteps;
            }
        }

        #endregion
    }
}
