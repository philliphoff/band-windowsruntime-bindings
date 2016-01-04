using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace Microsoft.Band.WindowsRuntime.Sensors
{
    public interface IBandSensor
    {
        bool IsSupported { get; }

        TimeSpan ReportingInterval { get; }

        IEnumerable<TimeSpan> SupportedReportingIntervals { get; }

        UserConsent GetCurrentUserConsent();

        IAsyncOperation<bool> RequestUserConsentAsync();

        IAsyncOperation<bool> StartReadingsAsync();

        IAsyncAction StopReadingsAsync();
    }
}
