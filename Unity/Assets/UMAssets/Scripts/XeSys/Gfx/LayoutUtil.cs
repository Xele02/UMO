using System;

namespace XeSys.Gfx
{
	internal class LayoutUtil
	{
		private static Func<string, string> mGetTextFromIdDelegate = LayoutUtil.GetMessageFromMsgData; // 0x0

		public static Func<string, string> getTextFromIdDelegate { get { return mGetTextFromIdDelegate; } set { mGetTextFromIdDelegate = value; } }// 0x1F08F0C 0x1F08F98

		// // RVA: 0x1F079AC Offset: 0x1F079AC VA: 0x1F079AC
		// public static void SetupImageViewTex(Layout layout, string imageViewName, TexUVList uvList, string uvId) { }

		// // RVA: 0x1F07B68 Offset: 0x1F07B68 VA: 0x1F07B68
		// public static void SetupImageViewTex(TexUVListManager uv_manager, ImageView img, string uv_id) { }

		// // RVA: 0x1F07C68 Offset: 0x1F07C68 VA: 0x1F07C68
		// public static ImageView SetupImageViewTex(TexUVListManager uv_manager, Layout layout, string image_view_id, string uv_id) { }

		// // RVA: 0x1F07DB8 Offset: 0x1F07DB8 VA: 0x1F07DB8
		// public static ImageButton SetupImageButtonTex(TexUVListManager uv_manager, Layout layout, string button_view_id, string button_uv_id) { }

		// // RVA: 0x1F07F78 Offset: 0x1F07F78 VA: 0x1F07F78
		// public static ImageButton SetupSameImageButtonTex(TexUVListManager uv_manager, Layout layout, string button_view_id, string button_uv_id) { }

		// // RVA: 0x1F08118 Offset: 0x1F08118 VA: 0x1F08118
		// public static ImageButton SetupIndividualImageButtonTex(TexUVListManager uv_manager, Layout layout, string button_view_id, string button_uv_id, string push_button_uv_id) { }

		// // RVA: 0x1F082BC Offset: 0x1F082BC VA: 0x1F082BC
		// public static void SetupSerialNoEnable(Layout layout, string base_id, int no, int start, int end) { }

		// // RVA: 0x1F0838C Offset: 0x1F0838C VA: 0x1F0838C
		// public static void SetupSerialNoEnableOne(Layout layout, string base_id, int no, int start, int end) { }

		// // RVA: 0x1F0845C Offset: 0x1F0845C VA: 0x1F0845C
		// public static void SetupImageViewNoTextureUV(ImageView img, TexUVListManager uv_manager, string base_id, int no) { }

		// // RVA: 0x1F084F8 Offset: 0x1F084F8 VA: 0x1F084F8
		// public static void CheckScrollBarParamEasy(ScrollView scroll_view) { }

		// // RVA: 0x1F088A0 Offset: 0x1F088A0 VA: 0x1F088A0
		// public static bool AddView(Layout layout, string id, ViewBase view) { }

		// // RVA: 0x1F08994 Offset: 0x1F08994 VA: 0x1F08994
		// public static void SetupDateStringFromUNIXTime(Layout layout, long unix_time, string day_id, string time_id) { }

		// // RVA: 0x1F09028 Offset: 0x1F09028 VA: 0x1F09028
		private static string GetMessageFromMsgData(string str)
		{
			int idx = str.IndexOf(":");
			if(idx == -1)
				return JpStringLiterals.StringLiteral_21607;
			string bank = str.Substring(0, idx);
			string label = str.Substring(idx+1);
			return MessageManager.Instance.GetMessage(bank, label);
		}
	}
}
