using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Band.Sensors;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal sealed class BandRRIntervalSensor : BandSensorBase<Band.Sensors.IBandRRIntervalReading, BandRRIntervalSensorReadingChangedEventArgs>, IBandRRIntervalSensor
    {
        public BandRRIntervalSensor(Band.Sensors.IBandSensor<Band.Sensors.IBandRRIntervalReading> sensor)
            : base(sensor)
        {
        }

        protected override BandRRIntervalSensorReadingChangedEventArgs CreateEventArgs(Band.Sensors.IBandRRIntervalReading reading)
        {
            return new BandRRIntervalSensorReadingChangedEventArgs(new BandRRIntervalReading(reading));
        }
    }
}
