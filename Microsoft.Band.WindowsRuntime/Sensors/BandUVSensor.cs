using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Band.Sensors;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal sealed class BandUVSensor : BandSensorBase<Band.Sensors.IBandUVReading, BandUVSensorReadingChangedEventArgs>, IBandUVSensor
    {
        public BandUVSensor(Band.Sensors.IBandSensor<Band.Sensors.IBandUVReading> sensor)
            : base(sensor)
        {
        }

        protected override BandUVSensorReadingChangedEventArgs CreateEventArgs(Band.Sensors.IBandUVReading reading)
        {
            return new BandUVSensorReadingChangedEventArgs(new BandUVReading(reading));
        }
    }
}
