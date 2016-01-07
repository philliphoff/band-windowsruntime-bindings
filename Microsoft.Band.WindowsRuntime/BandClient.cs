using Microsoft.Band.WindowsRuntime.Notifications;
using Microsoft.Band.WindowsRuntime.Personalization;
using Microsoft.Band.WindowsRuntime.Sensors;
using Microsoft.Band.WindowsRuntime.Tiles;
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
    internal sealed class BandClient 
        : IBandClient, 
          IBandNotificationManager, 
          IBandPersonalizationManager, 
          IBandSensorManager,
          IBandTileManager
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
            this.altimeter = new Lazy<BandAltimeterSensor>(() => new BandAltimeterSensor(this.bandClient.SensorManager.Altimeter));
            this.ambientLight = new Lazy<BandAmbientLightSensor>(() => new BandAmbientLightSensor(this.bandClient.SensorManager.AmbientLight));
            this.barometer = new Lazy<BandBarometerSensor>(() => new BandBarometerSensor(this.bandClient.SensorManager.Barometer));
            this.calories = new Lazy<BandCaloriesSensor>(() => new BandCaloriesSensor(this.bandClient.SensorManager.Calories));
            this.contact = new Lazy<BandContactSensor>(() => new BandContactSensor(this.bandClient.SensorManager.Contact));
            this.distance = new Lazy<BandDistanceSensor>(() => new BandDistanceSensor(this.bandClient.SensorManager.Distance));
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

        public IBandTileManager TileManager
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

                    return BandTheme.FromBandTheme(bandTheme);
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
            return AsyncInfo.Run(cancellationToken => this.bandClient.PersonalizationManager.SetThemeAsync(BandTheme.ToBandTheme(theme), cancellationToken));
        }

        #endregion

        #region IBandSensorManager Members

        private readonly Lazy<BandAccelerometerSensor> accelerometer;
        private readonly Lazy<BandAltimeterSensor> altimeter;
        private readonly Lazy<BandAmbientLightSensor> ambientLight;
        private readonly Lazy<BandBarometerSensor> barometer;
        private readonly Lazy<BandCaloriesSensor> calories;
        private readonly Lazy<BandContactSensor> contact;
        private readonly Lazy<BandDistanceSensor> distance;

        IBandAccelerometerSensor IBandSensorManager.Accelerometer
        {
            get
            {
                return this.accelerometer.Value;
            }
        }

        IBandAltimeterSensor IBandSensorManager.Altimeter
        {
            get
            {
                return this.altimeter.Value;
            }
        }

        IBandAmbientLightSensor IBandSensorManager.AmbientLight
        {
            get
            {
                return this.ambientLight.Value;
            }
        }

        IBandBarometerSensor IBandSensorManager.Barometer
        {
            get
            {
                return this.barometer.Value;
            }
        }

        IBandCaloriesSensor IBandSensorManager.Calories
        {
            get
            {
                return this.calories.Value;
            }
        }

        IBandContactSensor IBandSensorManager.Contact
        {
            get
            {
                return this.contact.Value;
            }
        }

        IBandDistanceSensor IBandSensorManager.Distance
        {
            get
            {
                return this.distance.Value;
            }
        }

        #endregion

        #region IBandTileManager Members

        IAsyncOperation<bool> IBandTileManager.AddTileAsync(BandTile tile)
        {
            return AsyncInfo.Run(
                cancellationToken =>
                {
                    var bandTile = new Band.Tiles.BandTile(tile.TileId)
                    {
                        IsBadgingEnabled = tile.IsBadgingEnabled,
                        IsScreenTimeoutDisabled = tile.IsScreenTimeoutDisabled,
                        Name = tile.Name,
                        SmallIcon = tile.SmallIcon != null ? tile.SmallIcon.ToBandIcon() : null,
                        Theme = BandTheme.ToBandTheme(tile.Theme),
                        TileIcon = tile.TileIcon != null ? tile.TileIcon.ToBandIcon() : null
                        
                    };

                    foreach (var icon in tile.AdditionalIcons)
                    {
                        bandTile.AdditionalIcons.Add(icon.ToBandIcon());
                    }

                    return this.bandClient.TileManager.AddTileAsync(bandTile, cancellationToken);
                });
        }

        IAsyncOperation<int> IBandTileManager.GetRemainingTileCapacityAsync()
        {
            return AsyncInfo.Run(cancellationToken => this.bandClient.TileManager.GetRemainingTileCapacityAsync(cancellationToken));
        }

        IAsyncOperation<IEnumerable<BandTile>> IBandTileManager.GetTilesAsync()
        {
            return AsyncInfo.Run<IEnumerable<BandTile>>(
                async cancellationToken =>
                {
                    var bandTiles = await this.bandClient.TileManager.GetTilesAsync(cancellationToken);

                    return bandTiles.Select(FromBandTile).ToArray();
                });
        }

        private BandTile FromBandTile(Band.Tiles.BandTile tile)
        {
            var bandTile = new BandTile(tile.TileId)
            {
                IsBadgingEnabled = tile.IsBadgingEnabled,
                IsScreenTimeoutDisabled = tile.IsScreenTimeoutDisabled,
                Name = tile.Name,
                SmallIcon = tile.SmallIcon != null ? tile.SmallIcon.ToWriteableBitmap() : null,
                Theme = BandTheme.FromBandTheme(tile.Theme),
                TileIcon = tile.TileIcon != null ? tile.TileIcon.ToWriteableBitmap() : null

            };

            foreach (var icon in tile.AdditionalIcons)
            {
                bandTile.AdditionalIcons.Add(icon.ToWriteableBitmap());
            }

            return bandTile;
        }

        #endregion
    }
}
