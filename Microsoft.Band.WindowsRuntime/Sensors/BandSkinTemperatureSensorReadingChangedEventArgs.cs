using System;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    public sealed class BandSkinTemperatureSensorReadingChangedEventArgs
    {
        public BandSkinTemperatureSensorReadingChangedEventArgs(IBandSkinTemperatureReading sensorReading)
        {
            if (sensorReading == null)
            {
                throw new ArgumentNullException("sensorReading");
            }

            this.SensorReading = sensorReading;
        }

        public IBandSkinTemperatureReading SensorReading { get; }
    }
}