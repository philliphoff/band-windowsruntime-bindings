using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Band.Sensors;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal sealed class BandContactSensor : BandSensorBase<Band.Sensors.IBandContactReading, BandContactSensorReadingChangedEventArgs>, IBandContactSensor
    {
        public BandContactSensor(Band.Sensors.IBandSensor<Band.Sensors.IBandContactReading> sensor)
            : base(sensor)
        {
        }

        protected override BandContactSensorReadingChangedEventArgs CreateEventArgs(Band.Sensors.IBandContactReading reading)
        {
            return new BandContactSensorReadingChangedEventArgs(new BandContactReading(reading));
        }
    }
}
