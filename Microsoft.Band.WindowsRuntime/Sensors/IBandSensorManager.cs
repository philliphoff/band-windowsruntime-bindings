using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    public interface IBandSensorManager
    {
        IBandAccelerometerSensor Accelerometer { get; }

        IBandAltimeterSensor Altimeter { get; }

        IBandAmbientLightSensor AmbientLight { get; }

        IBandBarometerSensor Barometer { get; }

        IBandCaloriesSensor Calories { get; }

        IBandContactSensor Contact { get; }

        IBandDistanceSensor Distance { get; }

        IBandGsrSensor Gsr { get; }

        IBandGyroscopeSensor Gyroscope { get; }

        IBandHeartRateSensor HeartRate { get; }

        IBandPedometerSensor Pedometer { get; }

        IBandRRIntervalSensor RRInterval { get; }

        IBandSkinTemperatureSensor SkinTemperature { get; }
    }
}
