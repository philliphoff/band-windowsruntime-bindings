using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal sealed class BandAccelerometerReading : BandSensorReadingBase, IBandAccelerometerReading
    {
        private readonly Band.Sensors.IBandAccelerometerReading reading;

        public BandAccelerometerReading(Band.Sensors.IBandAccelerometerReading reading)
            : base(reading)
        {
            if (reading == null)
            {
                throw new ArgumentNullException("reading");
            }

            this.reading = reading;
        }

        public double AccelerationX
        {
            get
            {
                return this.reading.AccelerationX;
            }
        }

        public double AccelerationY
        {
            get
            {
                return this.reading.AccelerationY;
            }
        }

        public double AccelerationZ
        {
            get
            {
                return this.reading.AccelerationZ;
            }
        }
    }
}
