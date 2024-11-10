
using System.Collections.Generic;

[System.Obsolete("Use DDEMMEPBOIA_Sns", true)]
public class DDEMMEPBOIA { }
public class DDEMMEPBOIA_Sns : KLFDBFMNLBL_ServerSaveBlock
{
	public class EFIFBJGKPJF
	{
		public bool NEDNDAKLBMJ; // 0x1A
		public sbyte PMKJFKJFDOC_Itm; // 0x1B

		public int HBNIMMAEKHJ_Id { get; set; } // 0x8 MMKPAMLOBNO PPCNBOCPBDB JDCHJKEIEEJ
		public long BEBJKJKBOGH_Date { get; set; } // 0x10 MCIJNMKFMDB DIAPHCJBPFD IHAIKPNEEJE
		public short LDJIMGPHFPA_Cnt { get; set; } // 0x18 BGNCILNJBOP CIDCJMJPLIH KHABJPPLOIB
		//public bool PCHDDIJADBD { get; } 0x17724D0 BINPLPCDDCD
		//public bool FJODMPGPDDD { get; } 0x17742B4 CGKAEMGLHNK

		//// RVA: 0x1772AC8 Offset: 0x1772AC8 VA: 0x1772AC8
		public void ODDIHGPONFL(EFIFBJGKPJF GPBJHKLFCEP)
		{
			HBNIMMAEKHJ_Id = GPBJHKLFCEP.HBNIMMAEKHJ_Id;
			LDJIMGPHFPA_Cnt = GPBJHKLFCEP.LDJIMGPHFPA_Cnt;
			BEBJKJKBOGH_Date = GPBJHKLFCEP.BEBJKJKBOGH_Date;
			PMKJFKJFDOC_Itm = GPBJHKLFCEP.PMKJFKJFDOC_Itm;
		}

		//// RVA: 0x1772D9C Offset: 0x1772D9C VA: 0x1772D9C
		public bool AGBOGBEOFME(EFIFBJGKPJF OIKJFMGEICL)
		{
			if(HBNIMMAEKHJ_Id != OIKJFMGEICL.HBNIMMAEKHJ_Id ||
				LDJIMGPHFPA_Cnt != OIKJFMGEICL.LDJIMGPHFPA_Cnt ||
				BEBJKJKBOGH_Date != OIKJFMGEICL.BEBJKJKBOGH_Date ||
				PMKJFKJFDOC_Itm != OIKJFMGEICL.PMKJFKJFDOC_Itm)
				return false;
			return true;
		}

		//// RVA: 0x1773220 Offset: 0x1773220 VA: 0x1773220
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, DDEMMEPBOIA.EFIFBJGKPJF OHMCIEMIKCE, bool KFCGIKHEEMB) { }
	}

	private const int ECFEMKGFDCE = 2;
	public static string POFDDFCGEGP = "_"; // 0x0

	public List<EFIFBJGKPJF> HAJEJPFGILG { get; private set; } // 0x24 LDFKOFAKEPE DFFEFGAIDGI OMMAOJNEGAG
	public override bool DMICHEJIAJL { get { return true; } } // 0x1774238 NFKFOODCJJB

	// // RVA: 0x1771C6C Offset: 0x1771C6C VA: 0x1771C6C
	public DDEMMEPBOIA_Sns()
	{
		HAJEJPFGILG = new List<EFIFBJGKPJF>(2000);
		KMBPACJNEOF();
	}

	// // RVA: 0x1771D10 Offset: 0x1771D10 VA: 0x1771D10 Slot: 4
	public override void KMBPACJNEOF()
	{
		HAJEJPFGILG.Clear();
		for (int i = 0; i < 2000; i++)
		{
			EFIFBJGKPJF data = new EFIFBJGKPJF();
			data.HBNIMMAEKHJ_Id = i + 1;
			HAJEJPFGILG.Add(data);
		}
	}

	// // RVA: 0x1771E18 Offset: 0x1771E18 VA: 0x1771E18 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data[POFDDFCGEGP] = "";
		for(int i = 0; i < HAJEJPFGILG.Count; i++)
		{
			if(HAJEJPFGILG[i].BEBJKJKBOGH_Date != 0 || HAJEJPFGILG[i].PMKJFKJFDOC_Itm != 0)
			{
				EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
				data2[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id] = HAJEJPFGILG[i].HBNIMMAEKHJ_Id;
				data2[AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt] = HAJEJPFGILG[i].LDJIMGPHFPA_Cnt;
				data2[AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date] = HAJEJPFGILG[i].BEBJKJKBOGH_Date;
				data2[AFEHLCGHAEE_Strings.AIHOJKFNEEN_itm] = HAJEJPFGILG[i].PMKJFKJFDOC_Itm;
				data[POFDDFCGEGP + (i + 1)] = data2;
			}
		}
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = MCKEOKFMLAH;
			data2[JIKKNHIAEKG_BlockName] = data;
			data2[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 2;
			data = data2;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0x1772510 Offset: 0x1772510 VA: 0x1772510 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 2);
		if (!blockMissing)
		{
			if (block == null)
			{
				isInvalid = true;
			}
			else
			{
				BOKMNHAFJHF_Sns snsDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns;
				for(int i = 0; i < snsDb.CDENCMNHNGA_Talks.Count; i++)
				{
					BOKMNHAFJHF_Sns.KEIGMAOCJHK_Talk item = snsDb.CDENCMNHNGA_Talks[i];
					EFIFBJGKPJF data = HAJEJPFGILG[i];
					string str = POFDDFCGEGP + (i + 1).ToString();
					if(block.BBAJPINMOEP_Contains(str))
					{
						EDOHBJAPLPF_JsonData b = block[str];
						data.HBNIMMAEKHJ_Id = item.AIPLIEMLHGC_SnsId;
						data.LDJIMGPHFPA_Cnt = (short)CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt, 0, ref isInvalid);
						data.BEBJKJKBOGH_Date = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date, 0, ref isInvalid);
						data.PMKJFKJFDOC_Itm = (sbyte)CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.AIHOJKFNEEN_itm, 0, ref isInvalid);
					}
				}
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0x17728F8 Offset: 0x17728F8 VA: 0x17728F8 Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		DDEMMEPBOIA_Sns s = GPBJHKLFCEP as DDEMMEPBOIA_Sns;
		for(int i = 0; i < HAJEJPFGILG.Count; i++)
		{
			HAJEJPFGILG[i].ODDIHGPONFL(s.HAJEJPFGILG[i]);
		}
	}

	// // RVA: 0x1772B54 Offset: 0x1772B54 VA: 0x1772B54 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		DDEMMEPBOIA_Sns other = GPBJHKLFCEP as DDEMMEPBOIA_Sns;
		if(HAJEJPFGILG.Count != other.HAJEJPFGILG.Count)
			return false;
		for(int i = 0; i < HAJEJPFGILG.Count; i++)
		{
			if(!HAJEJPFGILG[i].AGBOGBEOFME(other.HAJEJPFGILG[i]))
				return false;
		}
		return true;
	}

	// // RVA: 0x1772E14 Offset: 0x1772E14 VA: 0x1772E14 Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH);
}
