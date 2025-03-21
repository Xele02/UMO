using XeSys;

namespace XeApp.Game.Common
{
	public class ViewSNSNotificationData
	{
		public int snsId; // 0x8
		public int charaId; // 0xC
		public int charaPictId; // 0x10
		public string roomName; // 0x14
		public string bodyText; // 0x18

		// RVA: 0xD336E4 Offset: 0xD336E4 VA: 0xD336E4
		public bool Init(int snsId)
		{
			this.snsId = snsId;
			roomName = "";
			bodyText = "";
            BOKMNHAFJHF_Sns.KEIGMAOCJHK_Talk dbSns = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA_Talks[snsId - 1];
            SNSRoomTextData.Header header = Database.Instance.roomText.textData.FindHeader(dbSns.AJIDLAGFPGM_TalkId);
            if (header != null)
			{
				charaId = Database.Instance.roomText.textData.FindData(header.startIndex).charaId;
				charaPictId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.KHCACDIKJLG_Characters[charaId - 1].EAHPLCJMPHD_PicId;
				roomName = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.NPKPBDIDBBG_Rooms[dbSns.MALFHCHNEFN_RoomId].OPFGFINHFCE_Name;
				bodyText = string.Format(MessageManager.Instance.GetMessage("menu", "sns_notify_fmt"), IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.KHCACDIKJLG_Characters[charaId - 1].OPFGFINHFCE_Name);
				return true;
			}
			return false;
		}
	}
}
