using System;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    public sealed class BandGsrSensorReadingChangedEventArgs
    {
        public BandGsrSensorReadingChangedEventArgs(IBandGsrReading sensorReading)
        {
            if (sensorReading == null)
            {
                throw new ArgumentNullException("sensorReading");
            }

            this.SensorReading = sensorReading;
        }

        public IBandGsrReading SensorReading { get; }
    }
}