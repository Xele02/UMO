
using XeSys;

public class IAPDFOPPGND
{
	public string ADCMNODJBGJ_EmblemName; // 0x8
	public string FEMMDNIELFC_EmblemDesc; // 0xC
	public int EAHPLCJMPHD_EmblemPic; // 0x10
	public int HMFFHLPNMPH; // 0x14
	public int MDPKLNFFDBO; // 0x18
	private int EILKGEADKGH_EmblemOdr; // 0x1C

	// // RVA: 0x120EB38 Offset: 0x120EB38 VA: 0x120EB38
	public void KHEKNNFCAOI_Init(int ABLOIBMGLFD, int HMFFHLPNMPH)
	{
		IHGBPAJMJFK_Emblem.AKJPPHFGEFG_EmblemInfo emblem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBNBNAFGMDE_Emblem.CDENCMNHNGA_EmblemList[ABLOIBMGLFD - 1];
		MessageBank bank = MessageManager.Instance.GetBank("master");
		ADCMNODJBGJ_EmblemName = bank.GetMessageByLabel("em_nm_" + ABLOIBMGLFD.ToString("D4"));
		FEMMDNIELFC_EmblemDesc = bank.GetMessageByLabel("em_dsc_" + ABLOIBMGLFD.ToString("D4"));
		EAHPLCJMPHD_EmblemPic = emblem.HANMDEBPBHG_Pic;
		this.HMFFHLPNMPH = HMFFHLPNMPH;
		MDPKLNFFDBO = ABLOIBMGLFD;
		EILKGEADKGH_EmblemOdr = emblem.FPOMEEJFBIG_Odr;
	}

	// // RVA: 0x120EDCC Offset: 0x120EDCC VA: 0x120EDCC
	// public void KHEKNNFCAOI_Init(JNMFKOHFAFB FIAMPPHKOOF) { }

	// // RVA: 0x120F0BC Offset: 0x120F0BC VA: 0x120F0BC
	// public static List<IAPDFOPPGND> FKDIMODKKJD(bool CDEOEEHBOBI) { }

	// // RVA: 0x120F5DC Offset: 0x120F5DC VA: 0x120F5DC
	// public static List<IAPDFOPPGND> NEOMKKIEMJJ(BBHNACPENDM KPMOBPNENCD, bool CDEOEEHBOBI) { }

	// // RVA: 0x120FA98 Offset: 0x120FA98 VA: 0x120FA98
	// public static int ODPDHDPHKGK() { }

	// // RVA: 0x120FB74 Offset: 0x120FB74 VA: 0x120FB74
	// public static int EPDPFMFIKFE(int MDPKLNFFDBO) { }
}
