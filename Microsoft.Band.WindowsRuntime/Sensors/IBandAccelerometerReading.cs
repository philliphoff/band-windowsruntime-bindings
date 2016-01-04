using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    public interface IBandAccelerometerReading : IBandSensorReading
    {
        double AccelerationX { get; }

        double AccelerationY { get; }

        double AccelerationZ { get; }
    }
}
