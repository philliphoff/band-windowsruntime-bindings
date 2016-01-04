using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    internal abstract class BandSensorBase<T> : IBandSensor where T : Band.Sensors.IBandSensorReading
    {
        private readonly Band.Sensors.IBandSensor<T> sensor;
        private readonly SemaphoreSlim readingLock = new SemaphoreSlim(1, 1);
        private bool isSubscribed;

        public BandSensorBase(Band.Sensors.IBandSensor<T> sensor)
        {
            if (sensor == null)
            {
                throw new ArgumentNullException("sensor");
            }

            this.sensor = sensor;
        }

        #region IBandSensor Members

        public bool IsSupported
        {
            get
            {
                return this.sensor.IsSupported;
            }
        }

        public TimeSpan ReportingInterval
        {
            get
            {
                return this.sensor.ReportingInterval;
            }
        }

        public IEnumerable<TimeSpan> SupportedReportingIntervals
        {
            get
            {
                return this.sensor.SupportedReportingIntervals;
            }
        }

        public UserConsent GetCurrentUserConsent()
        {
            return ToUserConsent(this.sensor.GetCurrentUserConsent());
        }

        public IAsyncOperation<bool> RequestUserConsentAsync()
        {
            return AsyncInfo.Run(cancellationToken => this.sensor.RequestUserConsentAsync(cancellationToken));
        }

        public IAsyncOperation<bool> StartReadingsAsync()
        {
            return AsyncInfo.Run(
                async cancellationToken =>
                {
                    if (!this.isSubscribed)
                    {
                        await this.readingLock.WaitAsync(cancellationToken);

                        try
                        {
                            if (!this.isSubscribed)
                            {
                                this.sensor.ReadingChanged += OnSensorReadingChanged;

                                this.isSubscribed = true;
                            }
                        }
                        finally
                        {
                            this.readingLock.Release();
                        }
                    }

                    return await this.sensor.StartReadingsAsync(cancellationToken);
                });
        }

        public IAsyncAction StopReadingsAsync()
        {
            return AsyncInfo.Run(
                async cancellationToken =>
                {
                    if (this.isSubscribed)
                    {
                        await this.readingLock.WaitAsync(cancellationToken);

                        try
                        {
                            if (this.isSubscribed)
                            {
                                this.sensor.ReadingChanged -= OnSensorReadingChanged;

                                this.isSubscribed = false;
                            }
                        }
                        finally
                        {
                            this.readingLock.Release();
                        }
                    }

                    await this.sensor.StopReadingsAsync(cancellationToken);
                });
        }

        #endregion

        protected abstract void NotifySensorReadingChanged(Band.Sensors.BandSensorReadingEventArgs<T> e);

        private void OnSensorReadingChanged(object sender, Band.Sensors.BandSensorReadingEventArgs<T> e)
        {
            NotifySensorReadingChanged(e);
        }

        private UserConsent ToUserConsent(Band.UserConsent userConsent)
        {
            switch (userConsent)
            {
                case Band.UserConsent.Declined:     return UserConsent.Declined;
                case Band.UserConsent.Granted:      return UserConsent.Granted;
                case Band.UserConsent.NotSpecified: return UserConsent.NotSpecified;

                default:

                    throw new ArgumentOutOfRangeException("userConsent");
            }
        }
    }
}
