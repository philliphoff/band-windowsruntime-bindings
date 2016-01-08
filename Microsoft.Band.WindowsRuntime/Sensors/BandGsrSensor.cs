using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Band.Sensors;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal sealed class BandGsrSensor : BandSensorBase<Band.Sensors.IBandGsrReading, BandGsrSensorReadingChangedEventArgs>, IBandGsrSensor
    {
        public BandGsrSensor(Band.Sensors.IBandSensor<Band.Sensors.IBandGsrReading> sensor)
            : base(sensor)
        {
        }

        protected override BandGsrSensorReadingChangedEventArgs CreateEventArgs(Band.Sensors.IBandGsrReading reading)
        {
            return new BandGsrSensorReadingChangedEventArgs(new BandGsrReading(reading));
        }
    }
}
