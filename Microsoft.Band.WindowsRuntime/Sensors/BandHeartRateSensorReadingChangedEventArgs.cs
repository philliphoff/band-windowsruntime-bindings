using System;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    public sealed class BandHeartRateSensorReadingChangedEventArgs
    {
        public BandHeartRateSensorReadingChangedEventArgs(IBandHeartRateReading sensorReading)
        {
            if (sensorReading == null)
            {
                throw new ArgumentNullException("sensorReading");
            }

            this.SensorReading = sensorReading;
        }

        public IBandHeartRateReading SensorReading { get; }
    }
}