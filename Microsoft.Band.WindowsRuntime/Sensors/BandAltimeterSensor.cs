using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Band.Sensors;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal sealed class BandAltimeterSensor : BandSensorBase<Band.Sensors.IBandAltimeterReading, BandAltimeterSensorReadingEventArgs>, IBandAltimeterSensor
    {
        public BandAltimeterSensor(Band.Sensors.IBandSensor<Band.Sensors.IBandAltimeterReading> sensor)
            : base(sensor)
        {
        }

        protected override BandAltimeterSensorReadingEventArgs CreateEventArgs(Band.Sensors.IBandAltimeterReading reading)
        {
            return new BandAltimeterSensorReadingEventArgs(new BandAltimeterReading(reading));
        }
    }
}
