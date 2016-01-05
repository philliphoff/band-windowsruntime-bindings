using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Band.Sensors;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal sealed class BandAltimeterSensor : BandSensorBase<Band.Sensors.IBandAltimeterReading>, IBandAltimeterSensor
    {
        public BandAltimeterSensor(Band.Sensors.IBandSensor<Band.Sensors.IBandAltimeterReading> sensor)
            : base(sensor)
        {
        }

        public event EventHandler<BandAltimeterSensorReadingEventArgs> ReadingChanged;

        protected override void NotifySensorReadingChanged(BandSensorReadingEventArgs<Band.Sensors.IBandAltimeterReading> e)
        {
            var handler = ReadingChanged;

            if (handler != null)
            {
                handler(this, new BandAltimeterSensorReadingEventArgs(new BandAltimeterReading(e.SensorReading)));
            }
        }
    }
}
