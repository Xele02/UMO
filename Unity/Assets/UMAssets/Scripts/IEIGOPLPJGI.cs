
using XeSys;

[System.Obsolete("Use IEIGOPLPJGI_PilotInfo", true)]
public class IEIGOPLPJGI { }
public class IEIGOPLPJGI_PilotInfo
{
	public int PFGJJLGLPAC_PilotId; // 0x8
	public string OPFGFINHFCE_name; // 0xC
	public int AIHCEGFANAM_SerieAttr; // 0x10
	public int CHIMPKJDCPP_Pid; // 0x14

	// // RVA: 0x11ED364 Offset: 0x11ED364 VA: 0x11ED364
	public void KHEKNNFCAOI_Init(int _PFGJJLGLPAC_PilotId)
	{
		PFGJJLGLPAC_PilotId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OBGGLAKOHKP_Pilot.GCINIJEMHFK_Get(_PFGJJLGLPAC_PilotId).PFGJJLGLPAC_PilotId;
		AIHCEGFANAM_SerieAttr = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OBGGLAKOHKP_Pilot.GCINIJEMHFK_Get(_PFGJJLGLPAC_PilotId).AIHCEGFANAM_SerieAttr;
		CHIMPKJDCPP_Pid = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OBGGLAKOHKP_Pilot.GCINIJEMHFK_Get(_PFGJJLGLPAC_PilotId).CHIMPKJDCPP_Pid;
		OPFGFINHFCE_name = MessageManager.Instance.GetMessage("master", "plt_nm_" + _PFGJJLGLPAC_PilotId.ToString("D4"));
	}
}
