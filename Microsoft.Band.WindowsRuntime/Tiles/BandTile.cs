using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Microsoft.Band.WindowsRuntime.Tiles
{
    public sealed class BandTile
    {
        public BandTile(Guid tileId)
        {
            this.AdditionalIcons = new List<WriteableBitmap>();
            this.TileId = tileId;
        }

        public IList<WriteableBitmap> AdditionalIcons { get; }

        public bool IsBadgingEnabled { get; set; }

        public bool IsScreenTimeoutDisabled { get; set; }

        public string Name { get; set; }

        public WriteableBitmap SmallIcon { get; set; }

        public BandTheme Theme { get; set; }

        public WriteableBitmap TileIcon { get; set; }

        public Guid TileId { get; }
    }
}
