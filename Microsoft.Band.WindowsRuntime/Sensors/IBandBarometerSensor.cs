using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    public interface IBandBarometerSensor : IBandSensor
    {
        event EventHandler<BandBarometerSensorReadingEventArgs> ReadingChanged;
    }
}
