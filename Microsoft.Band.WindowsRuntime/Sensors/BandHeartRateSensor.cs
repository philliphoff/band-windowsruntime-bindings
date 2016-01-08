using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Band.Sensors;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal sealed class BandHeartRateSensor : BandSensorBase<Band.Sensors.IBandHeartRateReading, BandHeartRateSensorReadingChangedEventArgs>, IBandHeartRateSensor
    {
        public BandHeartRateSensor(Band.Sensors.IBandSensor<Band.Sensors.IBandHeartRateReading> sensor)
            : base(sensor)
        {
        }

        protected override BandHeartRateSensorReadingChangedEventArgs CreateEventArgs(Band.Sensors.IBandHeartRateReading reading)
        {
            return new BandHeartRateSensorReadingChangedEventArgs(new BandHeartRateReading(reading));
        }
    }
}
