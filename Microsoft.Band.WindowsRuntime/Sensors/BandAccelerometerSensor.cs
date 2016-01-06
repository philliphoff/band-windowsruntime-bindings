using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Band.Sensors;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal sealed class BandAccelerometerSensor : BandSensorBase<Band.Sensors.IBandAccelerometerReading, BandAccelerometerSensorReadingEventArgs>, IBandAccelerometerSensor
    {
        public BandAccelerometerSensor(Band.Sensors.IBandSensor<Band.Sensors.IBandAccelerometerReading> sensor)
            : base(sensor)
        {
        }

        protected override BandAccelerometerSensorReadingEventArgs CreateEventArgs(Band.Sensors.IBandAccelerometerReading reading)
        {
            return new BandAccelerometerSensorReadingEventArgs(new BandAccelerometerReading(reading));
        }
    }
}
