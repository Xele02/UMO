using System.Collections.Generic;

namespace XeSys
{
	public static class ListExtension
	{

		// RVA: -1 Offset: -1
		public static bool IsEmpty<T>(this List<T> list)
		{
			if (list != null)
				return list.Count == 0;
			return true;
		}
		///* GenericInstMethod :
		//|
		//|-RVA: 0x1A0DFD8 Offset: 0x1A0DFD8 VA: 0x1A0DFD8
		//|-ListExtension.IsEmpty<DAJBODHMLAB.MMLACIFMNBN.MHODOAJPNHD>
		//|-ListExtension.IsEmpty<JKHBHIGMJIC>
		//|-ListExtension.IsEmpty<KEPNMGHABPI.CAIPMAMHNJP>
		//|-ListExtension.IsEmpty<KEPNMGHABPI.LNCLNAOPNKF>
		//|-ListExtension.IsEmpty<object>
		//|-ListExtension.IsEmpty<string>
		//|-ListExtension.IsEmpty<GameManager.PushBackButtonHandler>
		//|-ListExtension.IsEmpty<LogRecorder.EventInfo>
		//|-ListExtension.IsEmpty<EventGoDivaScene.MusicPosInfo>
		//|-ListExtension.IsEmpty<FriendListInfo>
		//|-ListExtension.IsEmpty<GuestListInfo>
		//|-ListExtension.IsEmpty<ViewOfferGetItem>
		//|
		//|-RVA: 0x1A0E010 Offset: 0x1A0E010 VA: 0x1A0E010
		//|-ListExtension.IsEmpty<PopupAutoSettingContent.SortParam>
		//*/

		//[ExtensionAttribute] // RVA: 0x690400 Offset: 0x690400 VA: 0x690400
		//// RVA: -1 Offset: -1
		//public static bool IsEmpty<T>(LinkedList<T> list) { }
		///* GenericInstMethod :
		//|
		//|-RVA: 0x1A0DFA0 Offset: 0x1A0DFA0 VA: 0x1A0DFA0
		//|-ListExtension.IsEmpty<object>
		//*/
	}
}
