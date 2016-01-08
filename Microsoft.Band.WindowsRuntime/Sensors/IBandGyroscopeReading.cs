using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    public interface IBandGyroscopeReading : IBandAccelerometerReading
    {
        double AngularVelocityX { get; }

        double AngularVelocityY { get; }

        double AngularVelocityZ { get; }
    }
}
