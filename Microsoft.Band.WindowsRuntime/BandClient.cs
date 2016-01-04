using Microsoft.Band.WindowsRuntime.Notifications;
using Microsoft.Band.WindowsRuntime.Personalization;
using Microsoft.Band.WindowsRuntime.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Media.Imaging;

namespace Microsoft.Band.WindowsRuntime
{
    internal sealed class BandClient : IBandClient, IBandNotificationManager, IBandPersonalizationManager, IBandSensorManager
    {
        private readonly Band.IBandClient bandClient;

        public BandClient(Band.IBandClient bandClient)
        {
            if (bandClient == null)
            {
                throw new ArgumentNullException("bandClient");
            }

            this.bandClient = bandClient;

            this.accelerometer = new Lazy<BandAccelerometerSensor>(() => new BandAccelerometerSensor(this.bandClient.SensorManager.Accelerometer));
        }

        #region IBandClient Members

        public IBandNotificationManager NotificationManager
        {
            get
            {
                return this;
            }
        }

        public IBandPersonalizationManager PersonalizationManager
        {
            get
            {
                return this;
            }
        }

        public IBandSensorManager SensorManager
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

        #region IBandPersonalizationManager Members

        IAsyncOperation<WriteableBitmap> IBandPersonalizationManager.GetMeTileImageAsync()
        {
            return AsyncInfo.Run(
                async cancellationToken =>
                {
                    var bandImage = await this.bandClient.PersonalizationManager.GetMeTileImageAsync(cancellationToken);

                    return bandImage.ToWriteableBitmap();
                });
        }

        IAsyncOperation<BandTheme> IBandPersonalizationManager.GetThemeAsync()
        {
            return AsyncInfo.Run(
                async cancellationToken =>
                {
                    var bandTheme = await this.bandClient.PersonalizationManager.GetThemeAsync(cancellationToken);

                    return new BandTheme
                    {
                        Base            = bandTheme.Base.ToColor(),
                        HighContrast    = bandTheme.HighContrast.ToColor(),
                        Highlight       = bandTheme.Highlight.ToColor(),
                        Lowlight        = bandTheme.Lowlight.ToColor(),
                        Muted           = bandTheme.Muted.ToColor(),
                        SecondaryText   = bandTheme.SecondaryText.ToColor()
                    };
                });
        }

        IAsyncAction IBandPersonalizationManager.SetMeTileImageAsync(WriteableBitmap image)
        {
            return AsyncInfo.Run(
                async cancellationToken =>
                {
                    var bandImage = image.ToBandImage();

                    await this.bandClient.PersonalizationManager.SetMeTileImageAsync(bandImage, cancellationToken);
                });
        }

        IAsyncAction IBandPersonalizationManager.SetThemeAsync(BandTheme theme)
        {
            return AsyncInfo.Run(
                async cancellationToken =>
                {
                    var bandTheme = new Band.BandTheme
                    {
                        Base            = theme.Base.ToBandColor(),
                        HighContrast    = theme.HighContrast.ToBandColor(),
                        Highlight       = theme.Highlight.ToBandColor(),
                        Lowlight        = theme.Lowlight.ToBandColor(),
                        Muted           = theme.Muted.ToBandColor(),
                        SecondaryText   = theme.SecondaryText.ToBandColor()
                    };

                    await this.bandClient.PersonalizationManager.SetThemeAsync(bandTheme, cancellationToken);
                });
        }

        #endregion

        #region IBandSensorManager Members

        private readonly Lazy<BandAccelerometerSensor> accelerometer;

        IBandAccelerometerSensor IBandSensorManager.Accelerometer
        {
            get
            {
                return this.accelerometer.Value;
            }
        }

        #endregion
    }
}
