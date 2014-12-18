using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace RedditModTools.StaticClasses
{
    public static class GradientPresets
    {

        public static LinearGradientBrush LightGrey
        {
            get 
            {
                return makeBasicGradient("646464", "BBBBBB");
            }
            private set { }
        }


        public static LinearGradientBrush makeBasicGradient(Color topColor, Color bottomColor)
        {
            LinearGradientBrush returnBrush = new LinearGradientBrush();
            returnBrush.StartPoint = new Point(0, 0);
            returnBrush.EndPoint = new Point(0, 1);

            // Create and add Gradient stops
            GradientStop topStop = new GradientStop();
            topStop.Color = topColor;
            topStop.Offset = 0.0;
            returnBrush.GradientStops.Add(topStop);


            GradientStop bottomStop = new GradientStop();
            bottomStop.Color = bottomColor;
            bottomStop.Offset = 1.0;
            returnBrush.GradientStops.Add(bottomStop);

            return returnBrush;
        }
        /// <summary>
        /// overload that can accept hex strings in the following formats:
        /// "#ARGB", "#RGB", "ARGB", "RGB"
        /// </summary>
        /// <param name="topColorHex"></param>
        /// <param name="bottomColorHex"></param>
        /// <returns></returns>
        public static LinearGradientBrush makeBasicGradient(string topColorHex, string bottomColorHex)
        {
            return makeBasicGradient((Color)ColorConverter.ConvertFromString(fixColorHexCodes(topColorHex)), (Color)ColorConverter.ConvertFromString(fixColorHexCodes(bottomColorHex)));
        }

        /// <summary>
        /// Makes a naive attempt to fix hex colour codes that aren't formatted properly.
        /// It is meant to remove the requirement that the string contains the "#" character
        /// as well as to allow for RGB as opposed to ARGB by defaulting the A channel to FF
        /// </summary>
        /// <param name="code">Hex code to possibly 'fix'</param>
        /// <returns>processed version of input code</returns>
        private static string fixColorHexCodes(string code)
        {
            if (code[0] != '#')
                code = "#" + code;

            if (code.Length <= 7)
                code = "#FF" + code.Substring(1);

            return code;
        }
    }
}
