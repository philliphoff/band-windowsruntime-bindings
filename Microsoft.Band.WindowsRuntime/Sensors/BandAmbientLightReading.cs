using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal sealed class BandAmbientLightReading : BandSensorReadingBase, IBandAmbientLightReading
    {
        private readonly Band.Sensors.IBandAmbientLightReading reading;

        public BandAmbientLightReading(Band.Sensors.IBandAmbientLightReading reading)
            : base(reading)
        {
            if (reading == null)
            {
                throw new ArgumentNullException("reading");
            }

            this.reading = reading;
        }

        #region IBandAmbientLightReading Members

        public int Brightness
        {
            get
            {
                return this.reading.Brightness;
            }
        }

        #endregion
    }
}
