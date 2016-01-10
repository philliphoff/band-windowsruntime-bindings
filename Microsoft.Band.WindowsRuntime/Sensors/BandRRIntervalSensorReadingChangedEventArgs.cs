using System;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    public sealed class BandRRIntervalSensorReadingChangedEventArgs
    {
        public BandRRIntervalSensorReadingChangedEventArgs(IBandRRIntervalReading sensorReading)
        {
            if (sensorReading == null)
            {
                throw new ArgumentNullException("sensorReading");
            }

            this.SensorReading = sensorReading;
        }

        public IBandRRIntervalReading SensorReading { get; }
    }
}