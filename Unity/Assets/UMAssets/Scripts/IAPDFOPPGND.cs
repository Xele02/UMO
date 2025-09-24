
using System.Collections.Generic;
using XeSys;

public class IAPDFOPPGND
{
	public string ADCMNODJBGJ_title; // 0x8
	public string FEMMDNIELFC_Desc; // 0xC
	public int EAHPLCJMPHD_PId; // 0x10 EmblemPic
	public int HMFFHLPNMPH_count; // 0x14
	public int MDPKLNFFDBO_EmblemId; // 0x18
	private int EILKGEADKGH_Order; // 0x1C

	// // RVA: 0x120EB38 Offset: 0x120EB38 VA: 0x120EB38
	public void KHEKNNFCAOI_Init(int ABLOIBMGLFD_em_id, int _HMFFHLPNMPH_count)
	{
		IHGBPAJMJFK_Emblem.AKJPPHFGEFG_EmblemInfo emblem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBNBNAFGMDE_Emblem.CDENCMNHNGA_table[ABLOIBMGLFD_em_id - 1];
		MessageBank bank = MessageManager.Instance.GetBank("master");
		ADCMNODJBGJ_title = bank.GetMessageByLabel("em_nm_" + ABLOIBMGLFD_em_id.ToString("D4"));
		FEMMDNIELFC_Desc = bank.GetMessageByLabel("em_dsc_" + ABLOIBMGLFD_em_id.ToString("D4"));
		EAHPLCJMPHD_PId = emblem.HANMDEBPBHG_pic;
		this.HMFFHLPNMPH_count = _HMFFHLPNMPH_count;
		MDPKLNFFDBO_EmblemId = ABLOIBMGLFD_em_id;
		EILKGEADKGH_Order = emblem.FPOMEEJFBIG_odr;
	}

	// // RVA: 0x120EDCC Offset: 0x120EDCC VA: 0x120EDCC
	// public void KHEKNNFCAOI_Init(JNMFKOHFAFB FIAMPPHKOOF) { }

	// // RVA: 0x120F0BC Offset: 0x120F0BC VA: 0x120F0BC
	public static List<IAPDFOPPGND> FKDIMODKKJD(bool CDEOEEHBOBI_ForceAll)
	{
		List<JGGLDGNKELI_Emblem.AAHAAJEJNLJ> saveEmblems = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OFAJDLJBMEM_Emblem.MDKOHOCONKE;
		List<IHGBPAJMJFK_Emblem.AKJPPHFGEFG_EmblemInfo> dbEmblem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBNBNAFGMDE_Emblem.CDENCMNHNGA_table;
		int cnt = saveEmblems.Count;
		if (dbEmblem.Count < cnt)
			cnt = dbEmblem.Count;
		List<IAPDFOPPGND> res = new List<IAPDFOPPGND>();
		for (int i = 0; i < cnt; i++)
		{
			if (dbEmblem[i].PLALNIIBLOF_en == 2)
			{
				if(saveEmblems[i].FJODMPGPDDD_Unlocked || CDEOEEHBOBI_ForceAll)
				{
					IAPDFOPPGND data = new IAPDFOPPGND();
					data.KHEKNNFCAOI_Init(i + 1, saveEmblems[i].FHCAFLCLGAA_em_cnt);
					res.Add(data);
				}
			}
		}
		res.Sort((IAPDFOPPGND _HKICMNAACDA_a, IAPDFOPPGND _BNKHBCBJBKI_b) =>
		{
			//0x120FDFC
			int r = _HKICMNAACDA_a.EILKGEADKGH_Order.CompareTo(_BNKHBCBJBKI_b.EILKGEADKGH_Order);
			if(r == 0)
				r = _HKICMNAACDA_a.MDPKLNFFDBO_EmblemId.CompareTo(_BNKHBCBJBKI_b.MDPKLNFFDBO_EmblemId);
			return r;
		});
		return res;
	}

	// // RVA: 0x120F5DC Offset: 0x120F5DC VA: 0x120F5DC
	public static List<IAPDFOPPGND> NEOMKKIEMJJ(BBHNACPENDM_ServerSaveData _KPMOBPNENCD_serverData, bool CDEOEEHBOBI)
	{
		int cnt = _KPMOBPNENCD_serverData.OFAJDLJBMEM_Emblem.MDKOHOCONKE.Count;
		int dbCount = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBNBNAFGMDE_Emblem.CDENCMNHNGA_table.Count;
		if (dbCount < cnt)
			cnt = dbCount;
		List<IAPDFOPPGND> res = new List<IAPDFOPPGND>();
		for(int i = 1; i < cnt; i++)
		{
			IHGBPAJMJFK_Emblem.AKJPPHFGEFG_EmblemInfo dbEmblem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBNBNAFGMDE_Emblem.CDENCMNHNGA_table[i];
			JGGLDGNKELI_Emblem.AAHAAJEJNLJ saveEmblem = _KPMOBPNENCD_serverData.OFAJDLJBMEM_Emblem.MDKOHOCONKE[i];
			if (dbEmblem.PLALNIIBLOF_en == 2)
			{
				if(saveEmblem.FJODMPGPDDD_Unlocked || CDEOEEHBOBI)
				{
					IAPDFOPPGND data = new IAPDFOPPGND();
					data.KHEKNNFCAOI_Init(i + 1, saveEmblem.FHCAFLCLGAA_em_cnt);
					res.Add(data);
				}
			}
		}
		res.Sort((IAPDFOPPGND _HKICMNAACDA_a, IAPDFOPPGND _BNKHBCBJBKI_b) =>
		{
			//0x120FE58
			int r = _HKICMNAACDA_a.EILKGEADKGH_Order.CompareTo(_BNKHBCBJBKI_b.EILKGEADKGH_Order);
			if(r == 0)
				r = _HKICMNAACDA_a.MDPKLNFFDBO_EmblemId.CompareTo(_BNKHBCBJBKI_b.MDPKLNFFDBO_EmblemId);
			return r;
		});
		return res;
	}

	// // RVA: 0x120FA98 Offset: 0x120FA98 VA: 0x120FA98
	// public static int ODPDHDPHKGK() { }

	// // RVA: 0x120FB74 Offset: 0x120FB74 VA: 0x120FB74
	// public static int EPDPFMFIKFE(int _MDPKLNFFDBO_EmblemId) { }
}
