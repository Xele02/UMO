
using UnityEngine;

namespace XeApp.Game.Common
{
    public class SystemTextColor
    {
        public static readonly string NormalColor = "#062E49"; // 0x0
        public static readonly string ImportantColor = "#C8087E"; // 0x4
        public static readonly string ConservativeColor = "#5A5A5A"; // 0x8
        public static readonly string LackColor = "#8E0529"; // 0xC
        public static readonly string ImportantYellowColor = "#FF9999"; // 0x10


        // // RVA: 0x1CCE084 Offset: 0x1CCE084 VA: 0x1CCE084
        public static Color GetNormalColor()
        {
            return ColorConvert.Convert(NormalColor);
        }

        // // RVA: 0x1CCE120 Offset: 0x1CCE120 VA: 0x1CCE120
        public static Color GetLackColor()
		{
			return ColorConvert.Convert(LackColor);
		}

        // // RVA: 0x1CCE1BC Offset: 0x1CCE1BC VA: 0x1CCE1BC
        // public static Color GetImportantColor() { }

        // // RVA: 0x1CCE258 Offset: 0x1CCE258 VA: 0x1CCE258
		public static Color GetImportantYellowColor()
		{
			return ColorConvert.Convert(ImportantYellowColor);
		}
    }
}
