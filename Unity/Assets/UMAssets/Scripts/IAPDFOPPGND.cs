
using System.Collections.Generic;
using XeSys;

public class IAPDFOPPGND
{
	public string ADCMNODJBGJ_EmblemName; // 0x8
	public string FEMMDNIELFC_EmblemDesc; // 0xC
	public int EAHPLCJMPHD_EmblemPic; // 0x10
	public int HMFFHLPNMPH; // 0x14
	public int MDPKLNFFDBO_EmblemId; // 0x18
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
		MDPKLNFFDBO_EmblemId = ABLOIBMGLFD;
		EILKGEADKGH_EmblemOdr = emblem.FPOMEEJFBIG_Odr;
	}

	// // RVA: 0x120EDCC Offset: 0x120EDCC VA: 0x120EDCC
	// public void KHEKNNFCAOI_Init(JNMFKOHFAFB FIAMPPHKOOF) { }

	// // RVA: 0x120F0BC Offset: 0x120F0BC VA: 0x120F0BC
	public static List<IAPDFOPPGND> FKDIMODKKJD(bool CDEOEEHBOBI_ForceAll)
	{
		List<JGGLDGNKELI_Emblem.AAHAAJEJNLJ> saveEmblems = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.OFAJDLJBMEM_Emblem.MDKOHOCONKE;
		List<IHGBPAJMJFK_Emblem.AKJPPHFGEFG_EmblemInfo> dbEmblem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBNBNAFGMDE_Emblem.CDENCMNHNGA_EmblemList;
		int cnt = saveEmblems.Count;
		if (dbEmblem.Count < cnt)
			cnt = dbEmblem.Count;
		List<IAPDFOPPGND> res = new List<IAPDFOPPGND>();
		for (int i = 0; i < cnt; i++)
		{
			if (dbEmblem[i].PLALNIIBLOF_En == 2)
			{
				if(saveEmblems[i].FJODMPGPDDD_Unlocked || CDEOEEHBOBI_ForceAll)
				{
					IAPDFOPPGND data = new IAPDFOPPGND();
					data.KHEKNNFCAOI_Init(i + 1, saveEmblems[i].FHCAFLCLGAA_Cnt);
					res.Add(data);
				}
			}
		}
		res.Sort((IAPDFOPPGND HKICMNAACDA, IAPDFOPPGND BNKHBCBJBKI) =>
		{
			//0x120FDFC
			int r = HKICMNAACDA.EILKGEADKGH_EmblemOdr.CompareTo(BNKHBCBJBKI.EILKGEADKGH_EmblemOdr);
			if(r == 0)
				r = HKICMNAACDA.MDPKLNFFDBO_EmblemId.CompareTo(BNKHBCBJBKI.MDPKLNFFDBO_EmblemId);
			return r;
		});
		return res;
	}

	// // RVA: 0x120F5DC Offset: 0x120F5DC VA: 0x120F5DC
	public static List<IAPDFOPPGND> NEOMKKIEMJJ(BBHNACPENDM_ServerSaveData KPMOBPNENCD, bool CDEOEEHBOBI)
	{
		int cnt = KPMOBPNENCD.OFAJDLJBMEM_Emblem.MDKOHOCONKE.Count;
		int dbCount = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBNBNAFGMDE_Emblem.CDENCMNHNGA_EmblemList.Count;
		if (dbCount < cnt)
			cnt = dbCount;
		List<IAPDFOPPGND> res = new List<IAPDFOPPGND>();
		for(int i = 1; i < cnt; i++)
		{
			IHGBPAJMJFK_Emblem.AKJPPHFGEFG_EmblemInfo dbEmblem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBNBNAFGMDE_Emblem.CDENCMNHNGA_EmblemList[i];
			JGGLDGNKELI_Emblem.AAHAAJEJNLJ saveEmblem = KPMOBPNENCD.OFAJDLJBMEM_Emblem.MDKOHOCONKE[i];
			if (dbEmblem.PLALNIIBLOF_En == 2)
			{
				if(saveEmblem.FJODMPGPDDD_Unlocked || CDEOEEHBOBI)
				{
					IAPDFOPPGND data = new IAPDFOPPGND();
					data.KHEKNNFCAOI_Init(i + 1, saveEmblem.FHCAFLCLGAA_Cnt);
					res.Add(data);
				}
			}
		}
		res.Sort((IAPDFOPPGND HKICMNAACDA, IAPDFOPPGND BNKHBCBJBKI) =>
		{
			//0x120FE58
			int r = HKICMNAACDA.EILKGEADKGH_EmblemOdr.CompareTo(BNKHBCBJBKI.EILKGEADKGH_EmblemOdr);
			if(r == 0)
				r = HKICMNAACDA.MDPKLNFFDBO_EmblemId.CompareTo(BNKHBCBJBKI.MDPKLNFFDBO_EmblemId);
			return r;
		});
		return res;
	}

	// // RVA: 0x120FA98 Offset: 0x120FA98 VA: 0x120FA98
	// public static int ODPDHDPHKGK() { }

	// // RVA: 0x120FB74 Offset: 0x120FB74 VA: 0x120FB74
	// public static int EPDPFMFIKFE(int MDPKLNFFDBO) { }
}
