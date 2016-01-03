using Microsoft.Band.WindowsRuntime.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace Microsoft.Band.WindowsRuntime
{
    internal sealed class BandClient : IBandClient, IBandNotificationManager
    {
        private readonly Band.IBandClient bandClient;

        public BandClient(Band.IBandClient bandClient)
        {
            if (bandClient == null)
            {
                throw new ArgumentNullException("bandClient");
            }

            this.bandClient = bandClient;
        }

        #region IBandClient Members

        public IBandNotificationManager NotificationManager
        {
            get
            {
                return this;
            }
        }

        public IAsyncOperation<string> GetFirmwareVersionAsync()
        {
            return AsyncInfo.Run(cancellationToken => this.bandClient.GetFirmwareVersionAsync(cancellationToken));
        }

        public IAsyncOperation<string> GetHardwareVersionAsync()
        {
            return AsyncInfo.Run(cancellationToken => this.bandClient.GetHardwareVersionAsync(cancellationToken));
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this.bandClient.Dispose();
        }

        #endregion

        #region IBandNotificationManager Members

        IAsyncAction IBandNotificationManager.SendMessageAsync(Guid tileId, string title, string body, DateTimeOffset timestamp)
        {
            return AsyncInfo.Run(cancellationToken => this.bandClient.NotificationManager.SendMessageAsync(tileId, title, body, timestamp, Band.Notifications.MessageFlags.None, cancellationToken));
        }

        IAsyncAction IBandNotificationManager.SendMessageAsync(Guid tileId, string title, string body, DateTimeOffset timestamp, MessageFlags flags)
        {
            return AsyncInfo.Run(cancellationToken => this.bandClient.NotificationManager.SendMessageAsync(tileId, title, body, timestamp, ToMessageFlags(flags), cancellationToken));
        }

        IAsyncAction IBandNotificationManager.ShowDialogAsync(Guid tileId, string title, string body)
        {
            return AsyncInfo.Run(cancellationToken => this.bandClient.NotificationManager.ShowDialogAsync(tileId, title, body, cancellationToken));
        }

        IAsyncAction IBandNotificationManager.VibrateAsync(VibrationType vibrationType)
        {
            return AsyncInfo.Run(cancellationToken => this.bandClient.NotificationManager.VibrateAsync(ToVibrationType(vibrationType), cancellationToken));
        }

        private Band.Notifications.MessageFlags ToMessageFlags(MessageFlags flags)
        {
            switch (flags)
            {
                case MessageFlags.None:         return Band.Notifications.MessageFlags.None;
                case MessageFlags.ShowDialog:   return Band.Notifications.MessageFlags.ShowDialog;

                default:

                    throw new ArgumentOutOfRangeException("flags");
            }
        }

        private Band.Notifications.VibrationType ToVibrationType(VibrationType vibrationType)
        {
            switch (vibrationType)
            {
                case VibrationType.NotificationAlarm:   return Band.Notifications.VibrationType.NotificationAlarm;
                case VibrationType.NotificationOneTone: return Band.Notifications.VibrationType.NotificationOneTone;
                case VibrationType.NotificationTimer:   return Band.Notifications.VibrationType.NotificationTimer;
                case VibrationType.NotificationTwoTone: return Band.Notifications.VibrationType.NotificationTwoTone;
                case VibrationType.OneToneHigh:         return Band.Notifications.VibrationType.OneToneHigh;
                case VibrationType.RampDown:            return Band.Notifications.VibrationType.RampDown;
                case VibrationType.RampUp:              return Band.Notifications.VibrationType.RampUp;
                case VibrationType.ThreeToneHigh:       return Band.Notifications.VibrationType.ThreeToneHigh;
                case VibrationType.TwoToneHigh:         return Band.Notifications.VibrationType.TwoToneHigh;

                default:

                    throw new ArgumentOutOfRangeException("vibrationType");
            }
        }

        #endregion
    }
}
