using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal sealed class BandCaloriesReading : BandSensorReadingBase, IBandCaloriesReading
    {
        private readonly Band.Sensors.IBandCaloriesReading reading;

        public BandCaloriesReading(Band.Sensors.IBandCaloriesReading reading)
            : base(reading)
        {
            if (reading == null)
            {
                throw new ArgumentNullException("reading");
            }

            this.reading = reading;
        }

        #region IBandCaloriesReading Members

        public long Calories
        {
            get
            {
                return this.reading.Calories;
            }
        }

        #endregion
    }
}
