using System;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    public sealed class BandContactSensorReadingChangedEventArgs
    {
        public BandContactSensorReadingChangedEventArgs(IBandContactReading sensorReading)
        {
            if (sensorReading == null)
            {
                throw new ArgumentNullException("sensorReading");
            }

            this.SensorReading = sensorReading;
        }

        public IBandContactReading SensorReading { get; }
    }
}