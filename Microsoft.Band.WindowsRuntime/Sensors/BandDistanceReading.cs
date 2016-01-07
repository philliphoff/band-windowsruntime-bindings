using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Band.Sensors;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal sealed class BandDistanceReading : BandSensorReadingBase, IBandDistanceReading
    {
        private readonly Band.Sensors.IBandDistanceReading reading;

        public BandDistanceReading(Band.Sensors.IBandDistanceReading reading)
            : base(reading)
        {
            if (reading == null)
            {
                throw new ArgumentNullException("reading");
            }

            this.reading = reading;
        }

        #region IBandDistanceReading Members

        public MotionType CurrentMotion
        {
            get
            {
                return FromMotionType(this.reading.CurrentMotion);
            }
        }

        public double Pace
        {
            get
            {
                return this.reading.Pace;
            }
        }

        public double Speed
        {
            get
            {
                return this.reading.Speed;
            }
        }

        public long TotalDistance
        {
            get
            {
                return this.reading.TotalDistance;
            }
        }

        #endregion

        private static MotionType FromMotionType(Band.Sensors.MotionType currentMotion)
        {
            switch (currentMotion)
            {
                case Band.Sensors.MotionType.Idle:      return MotionType.Idle;
                case Band.Sensors.MotionType.Jogging:   return MotionType.Jogging;
                case Band.Sensors.MotionType.Running:   return MotionType.Running;
                case Band.Sensors.MotionType.Unknown:   return MotionType.Unknown;
                case Band.Sensors.MotionType.Walking:   return MotionType.Walking;

                default:

                    throw new ArgumentOutOfRangeException("currentMotion");
            }
        }
    }
}
