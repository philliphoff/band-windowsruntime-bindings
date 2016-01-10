using System;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    public sealed class BandUVSensorReadingChangedEventArgs
    {
        public BandUVSensorReadingChangedEventArgs(IBandUVReading sensorReading)
        {
            if (sensorReading == null)
            {
                throw new ArgumentNullException("sensorReading");
            }

            this.SensorReading = sensorReading;
        }

        public IBandUVReading SensorReading { get; }
    }
}