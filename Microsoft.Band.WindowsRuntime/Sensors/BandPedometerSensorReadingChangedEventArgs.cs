using System;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    public sealed class BandPedometerSensorReadingChangedEventArgs
    {
        public BandPedometerSensorReadingChangedEventArgs(IBandPedometerReading sensorReading)
        {
            if (sensorReading == null)
            {
                throw new ArgumentNullException("sensorReading");
            }

            this.SensorReading = sensorReading;
        }

        public IBandPedometerReading SensorReading { get; }
    }
}