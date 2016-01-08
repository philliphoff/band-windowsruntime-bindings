using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal sealed class BandGsrReading : BandSensorReadingBase, IBandGsrReading
    {
        private readonly Band.Sensors.IBandGsrReading reading;

        public BandGsrReading(Band.Sensors.IBandGsrReading reading)
            : base(reading)
        {
            if (reading == null)
            {
                throw new ArgumentNullException("reading");
            }

            this.reading = reading;
        }

        #region IBandGsrReading Members

        public int Resistance
        {
            get
            {
                return this.reading.Resistance;
            }
        }

        #endregion
    }
}
