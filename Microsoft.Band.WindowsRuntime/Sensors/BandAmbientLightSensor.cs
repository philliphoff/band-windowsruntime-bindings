using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Band.Sensors;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal sealed class BandAmbientLightSensor : BandSensorBase<Band.Sensors.IBandAmbientLightReading, BandAmbientLightSensorReadingEventArgs>, IBandAmbientLightSensor
    {
        public BandAmbientLightSensor(Band.Sensors.IBandSensor<Band.Sensors.IBandAmbientLightReading> sensor)
            : base(sensor)
        {
        }

        protected override BandAmbientLightSensorReadingEventArgs CreateEventArgs(Band.Sensors.IBandAmbientLightReading reading)
        {
            return new BandAmbientLightSensorReadingEventArgs(new BandAmbientLightReading(reading));
        }
    }
}
