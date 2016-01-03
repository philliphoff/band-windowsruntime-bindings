using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace Microsoft.Band.WindowsRuntime.Notifications
{
    public interface IBandNotificationManager
    {
        IAsyncAction SendMessageAsync(Guid tileId, string title, string body, DateTimeOffset timestamp);
        IAsyncAction SendMessageAsync(Guid tileId, string title, string body, DateTimeOffset timestamp, MessageFlags flags);

        IAsyncAction ShowDialogAsync(Guid tileId, string title, string body);

        IAsyncAction VibrateAsync(VibrationType vibrationType);
    }
}
