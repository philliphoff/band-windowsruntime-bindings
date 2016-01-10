using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Band.Sensors;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal sealed class BandSkinTemperatureSensor : BandSensorBase<Band.Sensors.IBandSkinTemperatureReading, BandSkinTemperatureSensorReadingChangedEventArgs>, IBandSkinTemperatureSensor
    {
        public BandSkinTemperatureSensor(Band.Sensors.IBandSensor<Band.Sensors.IBandSkinTemperatureReading> sensor)
            : base(sensor)
        {
        }

        protected override BandSkinTemperatureSensorReadingChangedEventArgs CreateEventArgs(Band.Sensors.IBandSkinTemperatureReading reading)
        {
            return new BandSkinTemperatureSensorReadingChangedEventArgs(new BandSkinTemperatureReading(reading));
        }
    }
}
