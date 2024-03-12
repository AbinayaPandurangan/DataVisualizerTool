using System.Drawing;

namespace Snow.DataVisualizer.API.Shared.Utils
{
    public static class Utils
    {
        public static string GetColorCode(string colorname)
        {
            Color ColorValue = Color.FromName(colorname);
            string ColorHex = string.Format("#{0:X2}{1:X2}{2:X2}", ColorValue.R, ColorValue.G, ColorValue.B);

            return ColorHex;
        }
    }
}
