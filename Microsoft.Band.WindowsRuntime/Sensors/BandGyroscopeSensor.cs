using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Band.Sensors;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal sealed class BandGyroscopeSensor : BandSensorBase<Band.Sensors.IBandGyroscopeReading, BandGyroscopeSensorReadingChangedEventArgs>, IBandGyroscopeSensor
    {
        public BandGyroscopeSensor(Band.Sensors.IBandSensor<Band.Sensors.IBandGyroscopeReading> sensor)
            : base(sensor)
        {
        }

        protected override BandGyroscopeSensorReadingChangedEventArgs CreateEventArgs(Band.Sensors.IBandGyroscopeReading reading)
        {
            return new BandGyroscopeSensorReadingChangedEventArgs(new BandGyroscopeReading(reading));
        }
    }
}
