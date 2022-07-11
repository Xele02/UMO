
using UnityEngine;

namespace XeApp.Game.Common
{
    public static class ColorConvert
    {
        // RVA: 0xE65CCC Offset: 0xE65CCC VA: 0xE65CCC
        public static Color Convert(string colorCode)
        {
            Color col = Color.black;
            ColorUtility.TryParseHtmlString(colorCode, out col);
            return col;
        }
    }
}