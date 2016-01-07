using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Band.Sensors;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal sealed class BandDistanceSensor : BandSensorBase<Band.Sensors.IBandDistanceReading, BandDistanceSensorReadingEventArgs>, IBandDistanceSensor
    {
        public BandDistanceSensor(Band.Sensors.IBandSensor<Band.Sensors.IBandDistanceReading> sensor)
            : base(sensor)
        {
        }

        protected override BandDistanceSensorReadingEventArgs CreateEventArgs(Band.Sensors.IBandDistanceReading reading)
        {
            return new BandDistanceSensorReadingEventArgs(new BandDistanceReading(reading));
        }
    }
}
