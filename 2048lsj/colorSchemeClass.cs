using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048lsj
{
    /// <summary>
    /// Class for handling different color schemes.
    /// </summary>
    class colorSchemeClass
    {
        /// <summary>
        /// The actual color scheme is stored in colordict. Index to the dictionary is one of the 
        /// possible square values in the game (2^n, n=1..25)
        /// </summary>

        private Dictionary<int, Color> colordict = new Dictionary<int, Color>();

        /// <summary>
        /// The constructor take a string argument with the name of the color scheme. 
        /// Defaults to the one called "Default" if value is unrecognized.
        /// </summary>
        /// <param name="scheme">
        /// Name of color scheme to be used.
        /// </param>
        /// <list type="table">
        /// <item>
        /// <term>Classic</term>
        /// <description>
        /// Something close to what I think the original game used.
        /// </description>
        /// </item>
        /// <item>
        /// <term>Red</term>
        /// <description>
        /// Various shades of red.
        /// </description>
        /// </item>
        /// <item>
        /// <term>Green</term>
        /// <description>
        /// Various shades of green.
        /// </description>
        /// </item>
        /// <item>
        /// <term>Blue</term>
        /// <description>
        /// Various shades of blue.
        /// </description>
        /// </item>
        /// <item>
        /// <term>Default</term>
        /// <description>
        /// Color scheme that makes an orderly progression through hue-saturation-brightness space.
        /// </description>
        /// </item>
        /// </list>
        public colorSchemeClass(string scheme)
        {
            switch (scheme)
            {
                case "Classic":
                    colordict.Add(2, Color.Red);
                    colordict.Add(4, Color.OrangeRed);
                    colordict.Add(8, Color.Orange);
                    colordict.Add(16, Color.Yellow);
                    colordict.Add(32, Color.YellowGreen);
                    colordict.Add(64, Color.LightGreen);
                    colordict.Add(128, Color.Green);
                    colordict.Add(256, Color.Turquoise);
                    colordict.Add(512, Color.Blue);
                    colordict.Add(1024, Color.BlueViolet);
                    colordict.Add(2048, Color.Violet);
                    colordict.Add(4096, Color.Lavender);
                    colordict.Add(8192, Color.Magenta);
                    colordict.Add(16384, Color.Beige);
                    colordict.Add(32768, Color.Beige);
                    colordict.Add(65536, Color.Beige);
                    colordict.Add(131072, Color.Beige);
                    colordict.Add(262144, Color.Beige);
                    colordict.Add(524288, Color.Beige);
                    colordict.Add(1048576, Color.Beige);
                    break;
                case "Red":
                    singleHueScheme(0);
                    break;
                case "Green":
                    singleHueScheme(0.333);
                    break;
                case "Blue":
                    singleHueScheme(0.666);
                    break;
                case "Default":
                default:
                    int k = 2;
                    double hue = 0;
                    double sat = 1;
                    double light = 0.8;
                    for (int i = 0; i < 25; i++)
                    {
                        colordict.Add(k, RGBfromHueSatLight(hue, sat, light));
                        k *= 2;
                        hue += 0.07;
                        if (hue > 1)
                        {
                            hue = 0;
                            light -= 0.25;
                        }
                    }
                    break;
            }
        }

        private void singleHueScheme(double hue)
        {
            int k = 2;
            double sat = 1;
            double light = 0.6;
            for (int i = 0; i < 25; i++)
            {
                colordict.Add(k, RGBfromHueSatLight(hue, sat, light));
                k *= 2;
                sat -= 0.15;
                if (sat < 0)
                {
                    sat = 1;
                    light -= 0.25;
                    if (light < 0)
                        light = 0.8;
                }
            }
        }

        /// <summary>
        /// Returns the appropriate Color for square value k,
        /// in the chosen color scheme. Defaults to black if value is out of range.
        /// </summary>
        public Color getColor(int k)
        {
            if (colordict.ContainsKey(k))
                return colordict[k];
            else
                return Color.Black;
        }

        /// <summary>
        /// Returns the appropriate Color for text in square value k,
        /// in the chosen color scheme. White if the square has a dark color, black otherwise.
        /// </summary>
        public Color getTextColor(int k)
        {
            Color cc = getColor(k);

            if (cc.GetBrightness() > 0.49)
                return Color.Black;
            else
                return Color.White;
        }

        /// <summary>
        /// Calculates RGB color from hue-saturation-brightness,
        /// algorithm adapted from https://geekymonkey.com/Programming/CSharp/RGB2HSL_HSL2RGB.htm
        /// and https://www.rapidtables.com/convert/color/hsl-to-rgb.html
        /// </summary>
        private static Color RGBfromHueSatLight(double hue, double saturation, double lightness)
        {
            double c;
            double m = 0;
            double r, g, b;

            r = lightness;
            g = lightness;
            b = lightness;

            c = saturation * (1.0 - Math.Abs(2.0 * lightness - 1));  //C = (1 - |2L - 1|) × S

            if (c > 0) //always true for valid input, except all zeroes in which case it defaults to gray
            {
                double x;
                int huesector;

                //m = 2*lightness-c;
                //sv = (c - m) / c;
                double hueangle = hue*360.0; //polar angle around the color circle
                huesector = (int)(hueangle/60.0); //which of six sectors
                //fract = 6.0*hue - huesector; //fractional angle into sector

                x = c * (1.0 - Math.Abs((hueangle / 60.0) % 2 - 1.0));  //X = C × (1 - |(H / 60°) mod 2 - 1|)
                m = lightness - c / 2;

                //vsf = c * sv * fract;
                //mid1 = m + vsf;
                //mid2 = c - vsf;
                switch (huesector)
                {
                    case 0:
                        r = c;
                        g = x;
                        b = 0;
                        break;
                    case 1:
                        r = x;
                        g = c;
                        b = 0;
                        break;
                    case 2:
                        r = 0;
                        g = c;
                        b = x;
                        break;
                    case 3:
                        r = 0;
                        g = x;
                        b = c;
                        break;
                    case 4:
                        r = x;
                        g = 0;
                        b = c;
                        break;
                    case 5:
                        r = c;
                        g = 0;
                        b = x;
                        break;
                }
            }

            //return Color.FromArgb(Convert.ToByte(r * 255.0f), Convert.ToByte(g * 255.0f), Convert.ToByte(b * 255.0f));
            return Color.FromArgb(Convert.ToByte((r+m) * 255.0f), Convert.ToByte((g+m) * 255.0f), Convert.ToByte((b+m) * 255.0f));

        }


    }
}
