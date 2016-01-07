using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    public interface IBandDistanceReading : IBandSensorReading
    {
        MotionType CurrentMotion { get; }

        double Pace { get; }

        double Speed { get; }

        long TotalDistance { get; }
    }
}
