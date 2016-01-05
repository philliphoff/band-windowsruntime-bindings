using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal sealed class BandAltimeterReading : BandSensorReadingBase, IBandAltimeterReading
    {
        private readonly Band.Sensors.IBandAltimeterReading reading;

        public BandAltimeterReading(Band.Sensors.IBandAltimeterReading reading)
            : base(reading)
        {
            if (reading == null)
            {
                throw new ArgumentNullException("reading");
            }

            this.reading = reading;
        }

        #region IBandAltimeterReading Members

        public long FlightsAscended
        {
            get
            {
                return this.reading.FlightsAscended;
            }
        }

        public long FlightsDescended
        {
            get
            {
                return this.reading.FlightsDescended;
            }
        }

        public float Rate
        {
            get
            {
                return this.reading.Rate;
            }
        }

        public long SteppingGain
        {
            get
            {
                return this.reading.SteppingGain;
            }
        }

        public long SteppingLoss
        {
            get
            {
                return this.reading.SteppingLoss;
            }
        }

        public long StepsAscended
        {
            get
            {
                return this.reading.StepsAscended;
            }
        }

        public long StepsDescended
        {
            get
            {
                return this.reading.StepsDescended;
            }
        }

        public long TotalGain
        {
            get
            {
                return this.reading.TotalGain;
            }
        }

        public long TotalLoss
        {
            get
            {
                return this.reading.TotalLoss;
            }
        }

        #endregion
    }
}
