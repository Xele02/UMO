using System;

namespace XeApp.Game.Common
{
	public class OtherUtility
	{
		// RVA: 0xAF4AA8 Offset: 0xAF4AA8 VA: 0xAF4AA8
		public static void OpenURL(string url, Action finish, float waitTimer = 0.5f)
		{
			NKGJPJPHLIF.HHCJCDFCLOB.NBLAOIPJFGL_OpenURL(url);
			if (finish != null)
				finish();
		}

		//// RVA: 0xAF4B64 Offset: 0xAF4B64 VA: 0xAF4B64
		//public static bool PopupWindowOpenUrlButtonSe(PopupButton.ButtonLabel label, PopupButton.ButtonType type) { }
	}
}
