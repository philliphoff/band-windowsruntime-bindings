using System;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    public sealed class BandGyroscopeSensorReadingChangedEventArgs
    {
        public BandGyroscopeSensorReadingChangedEventArgs(IBandGyroscopeReading sensorReading)
        {
            if (sensorReading == null)
            {
                throw new ArgumentNullException("sensorReading");
            }

            this.SensorReading = sensorReading;
        }

        public IBandGyroscopeReading SensorReading { get; }
    }
}