using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal sealed class BandSkinTemperatureReading : BandSensorReadingBase, IBandSkinTemperatureReading
    {
        private readonly Band.Sensors.IBandSkinTemperatureReading reading;

        public BandSkinTemperatureReading(Band.Sensors.IBandSkinTemperatureReading reading)
            : base(reading)
        {
            if (reading == null)
            {
                throw new ArgumentNullException("reading");
            }

            this.reading = reading;
        }

        #region IBandSkinTemperatureReading Members

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
