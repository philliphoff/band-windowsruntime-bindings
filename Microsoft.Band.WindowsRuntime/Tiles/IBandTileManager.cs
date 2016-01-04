using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace Microsoft.Band.WindowsRuntime.Tiles
{
    public interface IBandTileManager
    {
        IAsyncOperation<bool> AddTileAsync(BandTile tile);

        IAsyncOperation<int> GetRemainingTileCapacityAsync();

        IAsyncOperation<IEnumerable<BandTile>> GetTilesAsync();
    }
}
