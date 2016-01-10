using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    public interface IBandPedometerSensor : IBandSensor
    {
        event EventHandler<BandPedometerSensorReadingChangedEventArgs> ReadingChanged;
    }
}
