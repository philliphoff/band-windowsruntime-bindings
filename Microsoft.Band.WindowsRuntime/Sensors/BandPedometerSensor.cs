using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Band.Sensors;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal sealed class BandPedometerSensor : BandSensorBase<Band.Sensors.IBandPedometerReading, BandPedometerSensorReadingChangedEventArgs>, IBandPedometerSensor
    {
        public BandPedometerSensor(Band.Sensors.IBandSensor<Band.Sensors.IBandPedometerReading> sensor)
            : base(sensor)
        {
        }

        protected override BandPedometerSensorReadingChangedEventArgs CreateEventArgs(Band.Sensors.IBandPedometerReading reading)
        {
            return new BandPedometerSensorReadingChangedEventArgs(new BandPedometerReading(reading));
        }
    }
}
