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

        internal static BandTheme FromBandTheme(Band.BandTheme theme)
        {
            if (theme == null)
            {
                return null;
            }

            return new BandTheme
            {
                Base = theme.Base.ToColor(),
                HighContrast = theme.HighContrast.ToColor(),
                Highlight = theme.Highlight.ToColor(),
                Lowlight = theme.Lowlight.ToColor(),
                Muted = theme.Muted.ToColor(),
                SecondaryText = theme.SecondaryText.ToColor()
            };
        }

        internal static Band.BandTheme ToBandTheme(BandTheme theme)
        {
            if (theme == null)
            {
                return null;
            }

            return new Band.BandTheme
            {
                Base = theme.Base.ToBandColor(),
                HighContrast = theme.HighContrast.ToBandColor(),
                Highlight = theme.Highlight.ToBandColor(),
                Lowlight = theme.Lowlight.ToBandColor(),
                Muted = theme.Muted.ToBandColor(),
                SecondaryText = theme.SecondaryText.ToBandColor()
            };
        }
    }
}
