using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    public interface IBandAltimeterReading : IBandSensorReading
    {
        long FlightsAscended { get; }

        long FlightsDescended { get; }

        float Rate { get; }

        long SteppingGain { get; }

        long SteppingLoss { get; }

        long StepsAscended { get; }

        long StepsDescended { get; }

        long TotalGain { get; }

        long TotalLoss { get; }
    }
}
