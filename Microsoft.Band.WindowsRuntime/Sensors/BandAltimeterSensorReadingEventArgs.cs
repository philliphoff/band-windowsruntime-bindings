using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    public sealed class BandAltimeterSensorReadingEventArgs
    {
        public BandAltimeterSensorReadingEventArgs(IBandAltimeterReading sensorReading)
        {
            this.SensorReading = sensorReading;
        }

        public IBandAltimeterReading SensorReading { get; }
    }
}
