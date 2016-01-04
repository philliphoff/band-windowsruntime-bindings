using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    public sealed class BandAccelerometerSensorReadingEventArgs
    {
        public BandAccelerometerSensorReadingEventArgs(IBandAccelerometerReading sensorReading)
        {
            this.SensorReading = sensorReading;
        }

        public IBandAccelerometerReading SensorReading { get; }
    }
}
