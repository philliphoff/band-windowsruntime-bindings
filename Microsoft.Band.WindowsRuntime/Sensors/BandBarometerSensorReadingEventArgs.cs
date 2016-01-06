using System;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    public sealed class BandBarometerSensorReadingEventArgs
    {
        public BandBarometerSensorReadingEventArgs(IBandBarometerReading sensorReading)
        {
            if (sensorReading == null)
            {
                throw new ArgumentNullException("sensorReading");
            }

            this.SensorReading = sensorReading;
        }

        public IBandSensorReading SensorReading { get; }
    }
}