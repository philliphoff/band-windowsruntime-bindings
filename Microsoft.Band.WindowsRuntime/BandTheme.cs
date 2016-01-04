using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace Microsoft.Band.WindowsRuntime
{
    public sealed class BandTheme
    {
        public Color Base { get; set; }
        
        public Color HighContrast { get; set; }

        public Color Highlight { get; set; }

        public Color Lowlight { get; set; }

        public Color Muted { get; set; }

        public Color SecondaryText { get; set; }
    }
}
