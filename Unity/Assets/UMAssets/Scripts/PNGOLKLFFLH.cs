
using System.Collections.Generic;
using XeSys;

public class PNGOLKLFFLH
{
	public int GPPEFLKGGGJ_ValkyrieId; // 0x8
	public string[] GJHJBLCPPKE_Names = new string[3]; // 0xC
	public string IJBLEJOKEFH_Name; // 0x10
	public string MJJCKMPICIK_PilotName; // 0x14
	public string KLMPFGOCBHC_description; // 0x18
	public int AIHCEGFANAM_SerieAttr; // 0x1C
	public int KINFGHHNFCF_Atk; // 0x20
	public int NONBCCLGBAO_hit; // 0x24
	public int GCCNMFHELCB_Form; // 0x28
	public int LFPHDOFDOOE; // 0x2C
	public long NPHOIEOPIJO_Date; // 0x30
	public bool FJODMPGPDDD_Unlocked; // 0x38
	public bool CPGDEPMPMFK_EpisodeUnlocked; // 0x39
	public int KELFCMEOPPM_EpisodeId; // 0x3C
	public int ENMAEBJGEKL_SkillId; // 0x40
	public int CNLIAMIIJID_AbilityLevel; // 0x44
	public int AKDKFIPNAOL_AbilityLevelMax; // 0x48
	public IEIGOPLPJGI_PilotInfo OPBPKNHIPPE_Pilot = new IEIGOPLPJGI_PilotInfo(); // 0x4C

	// public string COCGOFFMFCO { get; }

	// // RVA: 0xFF1A68 Offset: 0xFF1A68 VA: 0xFF1A68
	// public string GMJIKEHEPPA() { }

	// // RVA: 0xFF1AB0 Offset: 0xFF1AB0 VA: 0xFF1AB0
	public void KHEKNNFCAOI_Init(int GPPEFLKGGGJ_ValkyrieId, int IGBFFCLMAMM_Form/* = 0*/, long _BEBJKJKBOGH_date/* = 0*/)
	{
		JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo valkDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.GCINIJEMHFK(GPPEFLKGGGJ_ValkyrieId);
		this.GPPEFLKGGGJ_ValkyrieId = GPPEFLKGGGJ_ValkyrieId;
		NPHOIEOPIJO_Date = _BEBJKJKBOGH_date;
		AIHCEGFANAM_SerieAttr = valkDb.AIHCEGFANAM_SerieAttr;
		LFPHDOFDOOE = valkDb.DAJGPBLEEOB_ModelId;
		IJBLEJOKEFH_Name = MessageManager.Instance.GetMessage("master", "vn_" + GPPEFLKGGGJ_ValkyrieId.ToString("D4"));
		if(RuntimeSettings.CurrentSettings.DisplayIdInName)
			IJBLEJOKEFH_Name = "["+GPPEFLKGGGJ_ValkyrieId+"] "+IJBLEJOKEFH_Name;
		MJJCKMPICIK_PilotName = MessageManager.Instance.GetMessage("master", "v_pn_" + GPPEFLKGGGJ_ValkyrieId.ToString("D4"));
		KLMPFGOCBHC_description = MessageManager.Instance.GetMessage("master", "v_dsc_" + GPPEFLKGGGJ_ValkyrieId.ToString("D4"));
		GJHJBLCPPKE_Names[0] = "" + IJBLEJOKEFH_Name + "(F)";
		GJHJBLCPPKE_Names[1] = "" + IJBLEJOKEFH_Name + "(G)";
		GJHJBLCPPKE_Names[2] = "" + IJBLEJOKEFH_Name + "(B)";
		OELFCIKFMLL(IGBFFCLMAMM_Form);
		OPBPKNHIPPE_Pilot.KHEKNNFCAOI_Init(valkDb.PFGJJLGLPAC_PilotId);
		var saveValk = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JJFFBDLIOCF_Valkyrie.CNGNBKNBKGI_ValkList[GPPEFLKGGGJ_ValkyrieId - 1];
		FJODMPGPDDD_Unlocked = saveValk.FJODMPGPDDD_Unlocked;
		KELFCMEOPPM_EpisodeId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.HFAMPKLFFEJ_FindEpisodeForReward(GPPEFLKGGGJ_ValkyrieId);
		CPGDEPMPMFK_EpisodeUnlocked = false;
		if(KELFCMEOPPM_EpisodeId > 0)
		{
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[KELFCMEOPPM_EpisodeId - 1].BEBJKJKBOGH_date != 0)
				CPGDEPMPMFK_EpisodeUnlocked = true;
		}
		int lvl_max = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DIAEPFPGPEP_ValSkill.LPJLEHAJADA_GetIntParam("skill_level_max", 4);
		ENMAEBJGEKL_SkillId = valkDb.BMIJDLBGFNP_skill;
		AKDKFIPNAOL_AbilityLevelMax = 0;
		GKFMJAHKEMA_ValSkill.CCPFGNNIBDD data = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DIAEPFPGPEP_ValSkill.MNHBHNIHJJH(ENMAEBJGEKL_SkillId);
		if (data != null)
		{
			AKDKFIPNAOL_AbilityLevelMax = data.DOOGFEGEKLG_max;
			if (lvl_max < AKDKFIPNAOL_AbilityLevelMax)
				AKDKFIPNAOL_AbilityLevelMax = lvl_max;
		}
		CNLIAMIIJID_AbilityLevel = saveValk.CIEOBFIIPLD_Level;
		if (AKDKFIPNAOL_AbilityLevelMax < CNLIAMIIJID_AbilityLevel)
			CNLIAMIIJID_AbilityLevel = AKDKFIPNAOL_AbilityLevelMax;
	}

	// // RVA: 0xFF2298 Offset: 0xFF2298 VA: 0xFF2298
	public bool OELFCIKFMLL(int IGBFFCLMAMM_Form)
	{
		var dbValk = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.GCINIJEMHFK(GPPEFLKGGGJ_ValkyrieId);
		if (dbValk.ENIGAEMEAOP(IGBFFCLMAMM_Form))
		{
			GCCNMFHELCB_Form = IGBFFCLMAMM_Form;
			KINFGHHNFCF_Atk = dbValk.OJHINEMKMOP(IGBFFCLMAMM_Form);
			NONBCCLGBAO_hit = dbValk.PAELLCKLEJP(GCCNMFHELCB_Form);
			return true;
		}
		return false;
	}

	// // RVA: 0xFF240C Offset: 0xFF240C VA: 0xFF240C
	public static List<PNGOLKLFFLH> FKDIMODKKJD(bool OJEBNBLHPNP/* = false*/)
	{
		List<PNGOLKLFFLH> res = new List<PNGOLKLFFLH>();
		for(int i = 0; i < 100; i++)
		{
			JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo valkDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_table[i];
			OIGEIIGKMNH_Valkyrie.HLNPGNNPCGO_ValkyrieInfo valkSave = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JJFFBDLIOCF_Valkyrie.CNGNBKNBKGI_ValkList[i];
			if (!valkDb.IPJMPBANBPP_Enabled)
				continue;
			int epId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.HFAMPKLFFEJ_FindEpisodeForReward(valkDb.GPPEFLKGGGJ_ValkyrieId);
			if(OJEBNBLHPNP
				|| (epId == 0 && valkSave.FJODMPGPDDD_Unlocked)
				|| (epId != 0 && CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[epId - 1].BEBJKJKBOGH_date != 0)
				/*|| RuntimeSettings.CurrentSettings.ForceValkyrieUnlock*/)
			{
				PNGOLKLFFLH data = new PNGOLKLFFLH();
				data.KHEKNNFCAOI_Init(valkDb.GPPEFLKGGGJ_ValkyrieId, 0, valkSave.BEBJKJKBOGH_date);
				res.Add(data);
			}
		}
		return res;
	}

	// // RVA: 0xFF290C Offset: 0xFF290C VA: 0xFF290C
	public static List<PNGOLKLFFLH> NEOMKKIEMJJ(BBHNACPENDM_ServerSaveData _KPMOBPNENCD_serverData, bool OJEBNBLHPNP/* = false*/)
	{
		List<PNGOLKLFFLH> res = new List<PNGOLKLFFLH>();
		for(int i = 0; i < 100; i++)
		{
			JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo dbValk = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_table[i];
			OIGEIIGKMNH_Valkyrie.HLNPGNNPCGO_ValkyrieInfo saveValk = _KPMOBPNENCD_serverData.JJFFBDLIOCF_Valkyrie.CNGNBKNBKGI_ValkList[i];
			if(dbValk.IPJMPBANBPP_Enabled)
			{
				if(dbValk.GPPEFLKGGGJ_ValkyrieId != 1 && !OJEBNBLHPNP)
				{
					if(!saveValk.FJODMPGPDDD_Unlocked)
					{
						continue;
					}
				}
				PNGOLKLFFLH data = new PNGOLKLFFLH();
				data.KHEKNNFCAOI_Init(dbValk.GPPEFLKGGGJ_ValkyrieId, 0, saveValk.BEBJKJKBOGH_date);
				res.Add(data);
			}
		}
		return res;
	}
}
