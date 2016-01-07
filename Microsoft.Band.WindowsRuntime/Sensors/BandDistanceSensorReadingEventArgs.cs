using System;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    public sealed class BandDistanceSensorReadingEventArgs
    {
        public BandDistanceSensorReadingEventArgs(IBandDistanceReading sensorReading)
        {
            if (sensorReading == null)
            {
                throw new ArgumentNullException("sensorReading");
            }

            this.SensorReading = sensorReading;
        }

        public IBandDistanceReading SensorReading { get; }
    }
}