using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    public sealed class BandAmbientLightSensorReadingEventArgs
    {
        private readonly IBandAmbientLightReading reading;

        public BandAmbientLightSensorReadingEventArgs(IBandAmbientLightReading sensorReading)
        {
            if (sensorReading == null)
            {
                throw new ArgumentNullException("reading");
            }

            this.SensorReading = sensorReading;
        }

        public IBandAmbientLightReading SensorReading { get; }
    }
}
