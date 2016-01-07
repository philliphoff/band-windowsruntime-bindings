using System;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    public sealed class BandCaloriesSensorReadingChangedEventArgs
    {
        public BandCaloriesSensorReadingChangedEventArgs(IBandCaloriesReading sensorReading)
        {
            if (sensorReading == null)
            {
                throw new ArgumentNullException("sensorReading");
            }

            this.SensorReading = sensorReading;
        }

        public IBandCaloriesReading SensorReading { get; }
    }
}