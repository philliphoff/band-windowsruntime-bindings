using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Band.Sensors;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal sealed class BandAccelerometerSensor : BandSensorBase<Band.Sensors.IBandAccelerometerReading>, IBandAccelerometerSensor
    {
        public BandAccelerometerSensor(Band.Sensors.IBandSensor<Band.Sensors.IBandAccelerometerReading> sensor)
            : base(sensor)
        {
        }

        public event EventHandler<BandAccelerometerSensorReadingEventArgs> ReadingChanged;

        protected override void NotifySensorReadingChanged(BandSensorReadingEventArgs<Band.Sensors.IBandAccelerometerReading> e)
        {
            var handler = ReadingChanged;

            if (handler != null)
            {
                handler(this, new BandAccelerometerSensorReadingEventArgs(new BandAccelerometerReading(e.SensorReading)));
            }
        }
    }
}
