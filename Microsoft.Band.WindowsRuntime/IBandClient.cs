using Microsoft.Band.WindowsRuntime.Notifications;
using Microsoft.Band.WindowsRuntime.Personalization;
using Microsoft.Band.WindowsRuntime.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;

namespace Microsoft.Band.WindowsRuntime
{
    public interface IBandClient : IDisposable
    {
        IBandNotificationManager NotificationManager { get; }

        IBandPersonalizationManager PersonalizationManager { get; }

        IBandSensorManager SensorManager { get; }

        IAsyncOperation<string> GetFirmwareVersionAsync();

        IAsyncOperation<string> GetHardwareVersionAsync();
    }
}
