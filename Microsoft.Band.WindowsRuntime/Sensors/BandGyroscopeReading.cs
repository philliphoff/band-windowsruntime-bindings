using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal sealed class BandGyroscopeReading : BandAccelerometerReading, IBandGyroscopeReading
    {
        private readonly Band.Sensors.IBandGyroscopeReading reading;

        public BandGyroscopeReading(Band.Sensors.IBandGyroscopeReading reading)
            : base(reading)
        {
            if (reading == null)
            {
                throw new ArgumentNullException("reading");
            }

            this.reading = reading;
        }

        #region IBandGyroscopeReading Members

        public double AngularVelocityX
        {
            get
            {
                return this.reading.AngularVelocityX;
            }
        }

        public double AngularVelocityY
        {
            get
            {
                return this.reading.AngularVelocityY;
            }
        }

        public double AngularVelocityZ
        {
            get
            {
                return this.reading.AngularVelocityZ;
            }
        }

        #endregion
    }
}
