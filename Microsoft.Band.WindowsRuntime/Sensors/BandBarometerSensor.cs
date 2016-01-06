using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Band.Sensors;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal sealed class BandBarometerSensor : BandSensorBase<Band.Sensors.IBandBarometerReading, BandBarometerSensorReadingEventArgs>, IBandBarometerSensor
    {
        public BandBarometerSensor(Band.Sensors.IBandSensor<Band.Sensors.IBandBarometerReading> sensor)
            : base(sensor)
        {
        }

        protected override BandBarometerSensorReadingEventArgs CreateEventArgs(Band.Sensors.IBandBarometerReading reading)
        {
            return new BandBarometerSensorReadingEventArgs(new BandBarometerReading(reading));
        }
    }
}
