
using System.Collections.Generic;
using XeSys;

public class PNGOLKLFFLH
{
	public int GPPEFLKGGGJ_ValkyrieId; // 0x8
	public string[] GJHJBLCPPKE_FormNames = new string[3]; // 0xC
	public string IJBLEJOKEFH_ValkyrieName; // 0x10
	public string MJJCKMPICIK_PilotName; // 0x14
	public string KLMPFGOCBHC_ValkyrieDesc; // 0x18
	public int AIHCEGFANAM_Serie; // 0x1C
	public int KINFGHHNFCF_Atk; // 0x20
	public int NONBCCLGBAO_Hit; // 0x24
	public int GCCNMFHELCB_Form; // 0x28
	public int LFPHDOFDOOE; // 0x2C
	public long NPHOIEOPIJO; // 0x30
	public bool FJODMPGPDDD_Unlocked; // 0x38
	public bool CPGDEPMPMFK; // 0x39
	public int KELFCMEOPPM_EpisodeId; // 0x3C
	public int ENMAEBJGEKL; // 0x40
	public int CNLIAMIIJID_AbilityLevel; // 0x44
	public int AKDKFIPNAOL; // 0x48
	public IEIGOPLPJGI_PilotInfo OPBPKNHIPPE_Pilot = new IEIGOPLPJGI_PilotInfo(); // 0x4C

	// public string COCGOFFMFCO { get; }

	// // RVA: 0xFF1A68 Offset: 0xFF1A68 VA: 0xFF1A68
	// public string GMJIKEHEPPA() { }

	// // RVA: 0xFF1AB0 Offset: 0xFF1AB0 VA: 0xFF1AB0
	public void KHEKNNFCAOI_Init(int GPPEFLKGGGJ_ValkyrieId, int IGBFFCLMAMM_Form = 0, long BEBJKJKBOGH = 0)
	{
		JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo valkDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.GCINIJEMHFK(GPPEFLKGGGJ_ValkyrieId);
		this.GPPEFLKGGGJ_ValkyrieId = GPPEFLKGGGJ_ValkyrieId;
		NPHOIEOPIJO = BEBJKJKBOGH;
		AIHCEGFANAM_Serie = valkDb.AIHCEGFANAM;
		LFPHDOFDOOE = valkDb.DAJGPBLEEOB_ModelId;
		IJBLEJOKEFH_ValkyrieName = MessageManager.Instance.GetMessage("master", "vn_" + GPPEFLKGGGJ_ValkyrieId.ToString("D4"));
		MJJCKMPICIK_PilotName = MessageManager.Instance.GetMessage("master", "v_pn_" + GPPEFLKGGGJ_ValkyrieId.ToString("D4"));
		KLMPFGOCBHC_ValkyrieDesc = MessageManager.Instance.GetMessage("master", "v_dsc_" + GPPEFLKGGGJ_ValkyrieId.ToString("D4"));
		GJHJBLCPPKE_FormNames[0] = "" + IJBLEJOKEFH_ValkyrieName + "(F)";
		GJHJBLCPPKE_FormNames[1] = "" + IJBLEJOKEFH_ValkyrieName + "(G)";
		GJHJBLCPPKE_FormNames[2] = "" + IJBLEJOKEFH_ValkyrieName + "(B)";
		OELFCIKFMLL(IGBFFCLMAMM_Form);
		OPBPKNHIPPE_Pilot.KHEKNNFCAOI_Init(valkDb.PFGJJLGLPAC_PilotId);
		var saveValk = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JJFFBDLIOCF_Valkyrie.CNGNBKNBKGI_ValkList[GPPEFLKGGGJ_ValkyrieId - 1];
		FJODMPGPDDD_Unlocked = saveValk.FJODMPGPDDD;
		KELFCMEOPPM_EpisodeId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.HFAMPKLFFEJ_FindEpisodeForReward(GPPEFLKGGGJ_ValkyrieId);
		CPGDEPMPMFK = false;
		if(KELFCMEOPPM_EpisodeId > 0)
		{
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[KELFCMEOPPM_EpisodeId - 1].BEBJKJKBOGH_Date != 0)
				CPGDEPMPMFK = true;
		}
		int lvl_max = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DIAEPFPGPEP_ValSkill.LPJLEHAJADA("skill_level_max", 4);
		ENMAEBJGEKL = valkDb.BMIJDLBGFNP_SkillId;
		AKDKFIPNAOL = 0;
		GKFMJAHKEMA_ValSkill.CCPFGNNIBDD data = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DIAEPFPGPEP_ValSkill.MNHBHNIHJJH(ENMAEBJGEKL);
		if (data != null)
		{
			AKDKFIPNAOL = data.DOOGFEGEKLG;
			if (lvl_max < AKDKFIPNAOL)
				AKDKFIPNAOL = lvl_max;
		}
		CNLIAMIIJID_AbilityLevel = saveValk.CIEOBFIIPLD_Level;
		if (AKDKFIPNAOL < CNLIAMIIJID_AbilityLevel)
			CNLIAMIIJID_AbilityLevel = AKDKFIPNAOL;
	}

	// // RVA: 0xFF2298 Offset: 0xFF2298 VA: 0xFF2298
	public bool OELFCIKFMLL(int IGBFFCLMAMM_Form)
	{
		var dbValk = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.GCINIJEMHFK(GPPEFLKGGGJ_ValkyrieId);
		if (dbValk.ENIGAEMEAOP(IGBFFCLMAMM_Form))
		{
			GCCNMFHELCB_Form = IGBFFCLMAMM_Form;
			KINFGHHNFCF_Atk = dbValk.OJHINEMKMOP(IGBFFCLMAMM_Form);
			NONBCCLGBAO_Hit = dbValk.PAELLCKLEJP(GCCNMFHELCB_Form);
			return true;
		}
		return false;
	}

	// // RVA: 0xFF240C Offset: 0xFF240C VA: 0xFF240C
	public static List<PNGOLKLFFLH> FKDIMODKKJD(bool OJEBNBLHPNP = false)
	{
		List<PNGOLKLFFLH> res = new List<PNGOLKLFFLH>();
		for(int i = 0; i < 100; i++)
		{
			JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo valkDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_ValkyrieList[i];
			OIGEIIGKMNH_Valkyrie.HLNPGNNPCGO_ValkyrieInfo valkSave = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JJFFBDLIOCF_Valkyrie.CNGNBKNBKGI_ValkList[i];
			if (!valkDb.IPJMPBANBPP_IsEnabled)
				continue;
			int epId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.HFAMPKLFFEJ_FindEpisodeForReward(valkDb.GPPEFLKGGGJ_Id);
			if(OJEBNBLHPNP
				|| (epId == 0 && valkSave.FJODMPGPDDD)
				|| (epId != 0 && CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[epId - 1].BEBJKJKBOGH_Date != 0)
				/*|| RuntimeSettings.CurrentSettings.ForceValkyrieUnlock*/)
			{
				PNGOLKLFFLH data = new PNGOLKLFFLH();
				data.KHEKNNFCAOI_Init(valkDb.GPPEFLKGGGJ_Id, 0, valkSave.BEBJKJKBOGH_Date);
				res.Add(data);
			}
		}
		return res;
	}

	// // RVA: 0xFF290C Offset: 0xFF290C VA: 0xFF290C
	public static List<PNGOLKLFFLH> NEOMKKIEMJJ(BBHNACPENDM_ServerSaveData KPMOBPNENCD, bool OJEBNBLHPNP = false)
	{
		List<PNGOLKLFFLH> res = new List<PNGOLKLFFLH>();
		for(int i = 0; i < 100; i++)
		{
			JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo dbValk = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_ValkyrieList[i];
			OIGEIIGKMNH_Valkyrie.HLNPGNNPCGO_ValkyrieInfo saveValk = KPMOBPNENCD.JJFFBDLIOCF_Valkyrie.CNGNBKNBKGI_ValkList[i];
			if(dbValk.IPJMPBANBPP_IsEnabled)
			{
				if(dbValk.GPPEFLKGGGJ_Id != 1 && !OJEBNBLHPNP)
				{
					if(saveValk.FJODMPGPDDD)
					{
						continue;
					}
				}
				PNGOLKLFFLH data = new PNGOLKLFFLH();
				data.KHEKNNFCAOI_Init(dbValk.GPPEFLKGGGJ_Id, 0, saveValk.BEBJKJKBOGH_Date);
				res.Add(data);
			}
		}
		return res;
	}
}
