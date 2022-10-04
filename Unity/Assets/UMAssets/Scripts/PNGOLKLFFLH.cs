
using XeSys;

public class PNGOLKLFFLH
{
	public int GPPEFLKGGGJ_ValkyrieId; // 0x8
	public string[] GJHJBLCPPKE_FormNames = new string[3]; // 0xC
	public string IJBLEJOKEFH_ValkyrieName; // 0x10
	public string MJJCKMPICIK_PilotName; // 0x14
	public string KLMPFGOCBHC_ValkyrieDesc; // 0x18
	public int AIHCEGFANAM; // 0x1C
	public int KINFGHHNFCF; // 0x20
	public int NONBCCLGBAO; // 0x24
	public int GCCNMFHELCB_Form; // 0x28
	public int LFPHDOFDOOE; // 0x2C
	public long NPHOIEOPIJO; // 0x30
	public bool FJODMPGPDDD; // 0x38
	public bool CPGDEPMPMFK; // 0x39
	public int KELFCMEOPPM; // 0x3C
	public int ENMAEBJGEKL; // 0x40
	public int CNLIAMIIJID; // 0x44
	public int AKDKFIPNAOL; // 0x48
	public IEIGOPLPJGI_PilotInfo OPBPKNHIPPE = new IEIGOPLPJGI_PilotInfo(); // 0x4C

	// public string COCGOFFMFCO { get; }

	// // RVA: 0xFF1A68 Offset: 0xFF1A68 VA: 0xFF1A68
	// public string GMJIKEHEPPA() { }

	// // RVA: 0xFF1AB0 Offset: 0xFF1AB0 VA: 0xFF1AB0
	public void KHEKNNFCAOI_Init(int GPPEFLKGGGJ_ValkyrieId, int IGBFFCLMAMM_Form = 0, long BEBJKJKBOGH = 0)
	{
		JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo valkDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.GCINIJEMHFK(GPPEFLKGGGJ_ValkyrieId);
		this.GPPEFLKGGGJ_ValkyrieId = GPPEFLKGGGJ_ValkyrieId;
		NPHOIEOPIJO = BEBJKJKBOGH;
		AIHCEGFANAM = valkDb.AIHCEGFANAM;
		LFPHDOFDOOE = valkDb.DAJGPBLEEOB_ModelId;
		IJBLEJOKEFH_ValkyrieName = MessageManager.Instance.GetMessage("master", "vn_" + GPPEFLKGGGJ_ValkyrieId.ToString("D4"));
		MJJCKMPICIK_PilotName = MessageManager.Instance.GetMessage("master", "v_pn_" + GPPEFLKGGGJ_ValkyrieId.ToString("D4"));
		KLMPFGOCBHC_ValkyrieDesc = MessageManager.Instance.GetMessage("master", "v_dsc_" + GPPEFLKGGGJ_ValkyrieId.ToString("D4"));
		GJHJBLCPPKE_FormNames[0] = "" + IJBLEJOKEFH_ValkyrieName + "(F)";
		GJHJBLCPPKE_FormNames[1] = "" + IJBLEJOKEFH_ValkyrieName + "(G)";
		GJHJBLCPPKE_FormNames[2] = "" + IJBLEJOKEFH_ValkyrieName + "(B)";
		OELFCIKFMLL(IGBFFCLMAMM_Form);
		OPBPKNHIPPE.KHEKNNFCAOI_Init(valkDb.PFGJJLGLPAC);
		var saveValk = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JJFFBDLIOCF_Valkyrie.CNGNBKNBKGI_ValkList[GPPEFLKGGGJ_ValkyrieId - 1];
		FJODMPGPDDD = saveValk.FJODMPGPDDD;
		KELFCMEOPPM = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.HFAMPKLFFEJ_FindEpisodeForReward(GPPEFLKGGGJ_ValkyrieId);
		CPGDEPMPMFK = false;
		if(KELFCMEOPPM > 0)
		{
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[KELFCMEOPPM - 1].BEBJKJKBOGH_Date != 0)
				CPGDEPMPMFK = true;
		}
		int lvl_max = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DIAEPFPGPEP_ValSkill.LPJLEHAJADA("skill_level_max", 4);
		ENMAEBJGEKL = valkDb.BMIJDLBGFNP;
		AKDKFIPNAOL = 0;
		GKFMJAHKEMA_ValSkill.CCPFGNNIBDD data = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DIAEPFPGPEP_ValSkill.MNHBHNIHJJH(ENMAEBJGEKL);
		if (data != null)
		{
			AKDKFIPNAOL = data.DOOGFEGEKLG;
			if (lvl_max < AKDKFIPNAOL)
				AKDKFIPNAOL = lvl_max;
		}
		CNLIAMIIJID = saveValk.CIEOBFIIPLD_FPt;
		if (AKDKFIPNAOL < CNLIAMIIJID)
			CNLIAMIIJID = AKDKFIPNAOL;
	}

	// // RVA: 0xFF2298 Offset: 0xFF2298 VA: 0xFF2298
	public bool OELFCIKFMLL(int IGBFFCLMAMM_Form)
	{
		var dbValk = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.GCINIJEMHFK(GPPEFLKGGGJ_ValkyrieId);
		if (dbValk.ENIGAEMEAOP(IGBFFCLMAMM_Form))
		{
			GCCNMFHELCB_Form = IGBFFCLMAMM_Form;
			KINFGHHNFCF = dbValk.OJHINEMKMOP(IGBFFCLMAMM_Form);
			NONBCCLGBAO = dbValk.PAELLCKLEJP(GCCNMFHELCB_Form);
			return true;
		}
		return false;
	}

	// // RVA: 0xFF240C Offset: 0xFF240C VA: 0xFF240C
	// public static List<PNGOLKLFFLH> FKDIMODKKJD(bool OJEBNBLHPNP = False) { }

	// // RVA: 0xFF290C Offset: 0xFF290C VA: 0xFF290C
	// public static List<PNGOLKLFFLH> NEOMKKIEMJJ(BBHNACPENDM KPMOBPNENCD, bool OJEBNBLHPNP = False) { }
}
