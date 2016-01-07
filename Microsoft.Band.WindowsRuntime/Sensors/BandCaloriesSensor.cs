using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Band.Sensors;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal sealed class BandCaloriesSensor : BandSensorBase<Band.Sensors.IBandCaloriesReading, BandCaloriesSensorReadingChangedEventArgs>, IBandCaloriesSensor
    {
        public BandCaloriesSensor(Band.Sensors.IBandSensor<Band.Sensors.IBandCaloriesReading> sensor)
            : base(sensor)
        {
        }

        protected override BandCaloriesSensorReadingChangedEventArgs CreateEventArgs(Band.Sensors.IBandCaloriesReading reading)
        {
            return new BandCaloriesSensorReadingChangedEventArgs(new BandCaloriesReading(reading));
        }
    }
}
