using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Media.Imaging;

namespace Microsoft.Band.WindowsRuntime.Personalization
{
    public interface IBandPersonalizationManager
    {
        IAsyncOperation<WriteableBitmap> GetMeTileImageAsync();

        IAsyncOperation<BandTheme> GetThemeAsync();

        IAsyncAction SetMeTileImageAsync(WriteableBitmap image);

        IAsyncAction SetThemeAsync(BandTheme theme);
    }
}
