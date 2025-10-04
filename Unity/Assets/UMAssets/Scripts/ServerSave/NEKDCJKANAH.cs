
using System.Collections.Generic;

[System.Obsolete("Use NEKDCJKANAH_StoryRecord", true)]
public class NEKDCJKANAH { }
public class NEKDCJKANAH_StoryRecord : KLFDBFMNLBL_ServerSaveBlock
{
	public class HKDNILFKCFC
	{
		public const int PIHLDCHFFGL = 1;
		public const int CABPJNMPHEJ = 2;
		public const int POBMLOCCLND = 4;
		public const int OIPLHJIPFPD = 8;
		public const int NKBCBKHPLNP = 0;
		public const int BGCLPLAKANE = 1;
		public const int OJPKNLIBPIP = 2;
		public const int AJOHDNLHJBG = 3;
		public const int KOOCNAOFMJC = 4;
		public int BMPFHHHCNJC_story_id; // 0x8
		public int EALOBDHOCHP_stat; // 0xC
		public int NDFOAINJPIN_pos; // 0x10
		public int OKJMIFELDMD_Opn; // 0x14
		public int EJKHAFIALGK_mclr; // 0x18
		public int PDNJGJNGPNJ_MaxCombo; // 0x1C
		public int ODEHJGPDFCL_Score; // 0x20
		public int ABFNAEKEGOB_ComboRank; // 0x24
		public bool ICCJMCCJCBG; // 0x28
		public bool HCENOJKNCMK; // 0x29

		public bool HALOKFOJMLA_IsCompleted { get { return EALOBDHOCHP_stat > 3; } } //0x1AE98B8 LKOICFDJNDD_bgs

		// RVA: 0x1AE6C08 Offset: 0x1AE6C08 VA: 0x1AE6C08
		public HKDNILFKCFC()
		{
			EJKHAFIALGK_mclr = 0;
			BMPFHHHCNJC_story_id = 0;
			EALOBDHOCHP_stat = 0;
			NDFOAINJPIN_pos = 0;
			OKJMIFELDMD_Opn = 0;
		}

		//// RVA: 0x1AE6C34 Offset: 0x1AE6C34 VA: 0x1AE6C34
		//public void LHPDDGIJKNB_Reset() { }

		//// RVA: 0x1AE7410 Offset: 0x1AE7410 VA: 0x1AE7410
		//public bool CHFOOMPEABN() { }

		//// RVA: 0x1AE7E38 Offset: 0x1AE7E38 VA: 0x1AE7E38
		public bool AGBOGBEOFME(HKDNILFKCFC OIKJFMGEICL)
		{
			if(BMPFHHHCNJC_story_id != OIKJFMGEICL.BMPFHHHCNJC_story_id ||
				EALOBDHOCHP_stat != OIKJFMGEICL.EALOBDHOCHP_stat ||
				NDFOAINJPIN_pos != OIKJFMGEICL.NDFOAINJPIN_pos ||
				OKJMIFELDMD_Opn != OIKJFMGEICL.OKJMIFELDMD_Opn ||
				EJKHAFIALGK_mclr != OIKJFMGEICL.EJKHAFIALGK_mclr)
				return false;
			return true;
		}

		//// RVA: 0x1AE7B24 Offset: 0x1AE7B24 VA: 0x1AE7B24
		public void ODDIHGPONFL_Copy(HKDNILFKCFC GPBJHKLFCEP)
		{
			BMPFHHHCNJC_story_id = GPBJHKLFCEP.BMPFHHHCNJC_story_id;
			EALOBDHOCHP_stat = GPBJHKLFCEP.EALOBDHOCHP_stat;
			NDFOAINJPIN_pos = GPBJHKLFCEP.NDFOAINJPIN_pos;
			OKJMIFELDMD_Opn = GPBJHKLFCEP.OKJMIFELDMD_Opn;
			EJKHAFIALGK_mclr = GPBJHKLFCEP.EJKHAFIALGK_mclr;
		}

		//// RVA: 0x1AE8420 Offset: 0x1AE8420 VA: 0x1AE8420
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string _JIKKNHIAEKG_BlockName, string MJBACHKCIHA, int _OIPCCBHIKIA_index, NEKDCJKANAH_StoryRecord.HKDNILFKCFC _OHMCIEMIKCE_t, bool EFOEPDLNLJG) { }
	}

	private const int ECFEMKGFDCE_CurrentVersion = 2;
	public static string POFDDFCGEGP_Underscore = "_"; // 0x0
	private const int FLPFFEIKAKM = 200;
	private const int FLGCFMIACIN = 3;
	private const int KOLKCGMGLMN = 99999;
	private const int GCAHAAADBEH = 45684125; // 0x2b9159d
	private const int GKIDNIKODDK = 52143548; // 0x31ba5bc
	private int AKLLPNDJFCN_Complete_Crypted; // 0x24

	public bool EOHHFADHHBL_Complete { get { return AKLLPNDJFCN_Complete_Crypted == GCAHAAADBEH; } set { AKLLPNDJFCN_Complete_Crypted = value ? GCAHAAADBEH : GKIDNIKODDK; } } //FPOHKGALENL_bgs 0x1AE66D8  HCFHGHNGPJK_bgs 0x1AE66F4
	public List<HKDNILFKCFC> MMKAJBFBKNH { get; private set; } // 0x28 JAKKBNNDGOM_bgs BLJEKMOEHCM_bgs FJAHCOJOEJO_bgs
	public override bool DMICHEJIAJL { get { return true; } } // 0x1AE9734 NFKFOODCJJB_bgs

	// // RVA: 0x1AE6720 Offset: 0x1AE6720 VA: 0x1AE6720
	public int FKJMJELHGGG()
	{
		int res = 0;
		for(int i = 0; i < MMKAJBFBKNH.Count; i++)
		{
			if (MMKAJBFBKNH[i].NDFOAINJPIN_pos > 0)
				res++;
		}
		return res;
	}

	// // RVA: 0x1AE6804 Offset: 0x1AE6804 VA: 0x1AE6804
	public int ODOKNPHEIFN(int _LFLLLOPAKCO_StoryId, int _EALOBDHOCHP_stat)
	{
		MMKAJBFBKNH[_LFLLLOPAKCO_StoryId - 1].BMPFHHHCNJC_story_id = _LFLLLOPAKCO_StoryId;
		MMKAJBFBKNH[_LFLLLOPAKCO_StoryId - 1].EALOBDHOCHP_stat = _EALOBDHOCHP_stat;
		MMKAJBFBKNH[_LFLLLOPAKCO_StoryId - 1].NDFOAINJPIN_pos = FKJMJELHGGG() + 1;
		MMKAJBFBKNH[_LFLLLOPAKCO_StoryId - 1].OKJMIFELDMD_Opn = 0;
		return MMKAJBFBKNH[_LFLLLOPAKCO_StoryId - 1].NDFOAINJPIN_pos - 1;
	}

	// // RVA: 0x1AE68FC Offset: 0x1AE68FC VA: 0x1AE68FC
	// public void NDANPOKGFAN() { }

	// // RVA: 0x1AE6A30 Offset: 0x1AE6A30 VA: 0x1AE6A30
	public NEKDCJKANAH_StoryRecord()
	{
		MMKAJBFBKNH = new List<HKDNILFKCFC>(200);
		KMBPACJNEOF_Reset();
	}

	// // RVA: 0x1AE6AD4 Offset: 0x1AE6AD4 VA: 0x1AE6AD4 Slot: 4
	public override void KMBPACJNEOF_Reset()
	{
		MMKAJBFBKNH.Clear();
		for(int i = 0; i < 200; i++)
		{
			HKDNILFKCFC data = new HKDNILFKCFC();
			data.BMPFHHHCNJC_story_id = i + 1;
			MMKAJBFBKNH.Add(data);
		}
	}

	// // RVA: 0x1AE6C4C Offset: 0x1AE6C4C VA: 0x1AE6C4C Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long _MCKEOKFMLAH_SaveId)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data[POFDDFCGEGP_Underscore] = "";
		for(int i = 0; i < MMKAJBFBKNH.Count; i++)
		{
			if(MMKAJBFBKNH[i].EALOBDHOCHP_stat != 0 || MMKAJBFBKNH[i].NDFOAINJPIN_pos != 0 ||
				MMKAJBFBKNH[i].OKJMIFELDMD_Opn != 0 || MMKAJBFBKNH[i].EJKHAFIALGK_mclr != 0)
			{
				EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
				data2[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id] = MMKAJBFBKNH[i].BMPFHHHCNJC_story_id;
				data2[AFEHLCGHAEE_Strings.EALOBDHOCHP_stat] = MMKAJBFBKNH[i].EALOBDHOCHP_stat;
				data2[AFEHLCGHAEE_Strings.NDFOAINJPIN_pos] = MMKAJBFBKNH[i].NDFOAINJPIN_pos;
				data2[AFEHLCGHAEE_Strings.EJKHAFIALGK_mclr] = MMKAJBFBKNH[i].EJKHAFIALGK_mclr;
				data2[AFEHLCGHAEE_Strings.DPOGAFBDEOH_opn] = MMKAJBFBKNH[i].OKJMIFELDMD_Opn;
				data[POFDDFCGEGP_Underscore + (i + 1)] = data2;
			}
		}
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = _MCKEOKFMLAH_SaveId;
			data2[JIKKNHIAEKG_BlockName] = data;
			data2["complete"] = EOHHFADHHBL_Complete ? 1 : 0;
			data2[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 2;
			data = data2;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0x1AE7448 Offset: 0x1AE7448 VA: 0x1AE7448 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 2);
		if(!blockMissing)
		{
			if(block == null)
			{
				isInvalid = true;
			}
			else
			{
				LAEGMENIEDB_Story storyDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story;
				for(int i = 0; i < storyDb.CDENCMNHNGA_table.Count; i++)
				{
					string str = POFDDFCGEGP_Underscore + (i + 1).ToString();
					if(block.BBAJPINMOEP_Contains(str))
					{
						EDOHBJAPLPF_JsonData b = block[str];
						HKDNILFKCFC data = MMKAJBFBKNH[i];
						data.BMPFHHHCNJC_story_id = CJAENOMGPDA_GetInt(b, AFEHLCGHAEE_Strings.PPFNGGCBJKC_id, i + 1, ref isInvalid);
						data.EALOBDHOCHP_stat = CJAENOMGPDA_GetInt(b, AFEHLCGHAEE_Strings.EALOBDHOCHP_stat, 0, ref isInvalid);
						data.NDFOAINJPIN_pos = CJAENOMGPDA_GetInt(b, AFEHLCGHAEE_Strings.NDFOAINJPIN_pos, 0, ref isInvalid);
						data.OKJMIFELDMD_Opn = CJAENOMGPDA_GetInt(b, AFEHLCGHAEE_Strings.DPOGAFBDEOH_opn, 0, ref isInvalid);
						data.EJKHAFIALGK_mclr = CJAENOMGPDA_GetInt(b, AFEHLCGHAEE_Strings.EJKHAFIALGK_mclr, 0, ref isInvalid);
					}
				}
				EDOHBJAPLPF_JsonData b2 = OILEIIEIBHP[JIKKNHIAEKG_BlockName];
				EOHHFADHHBL_Complete = CJAENOMGPDA_GetInt(b2, "complete", 0, ref isInvalid) != 0;
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0x1AE7928 Offset: 0x1AE7928 VA: 0x1AE7928 Slot: 7
	public override void BMGGKONLFIC_Copy(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		NEKDCJKANAH_StoryRecord s = GPBJHKLFCEP as NEKDCJKANAH_StoryRecord;
		for(int i = 0; i < MMKAJBFBKNH.Count; i++)
		{
			MMKAJBFBKNH[i].ODDIHGPONFL_Copy(s.MMKAJBFBKNH[i]);
		}
		EOHHFADHHBL_Complete = s.EOHHFADHHBL_Complete;
	}

	// // RVA: 0x1AE7BC4 Offset: 0x1AE7BC4 VA: 0x1AE7BC4 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		NEKDCJKANAH_StoryRecord other = GPBJHKLFCEP as NEKDCJKANAH_StoryRecord;
		if(MMKAJBFBKNH.Count != other.MMKAJBFBKNH.Count)
			return false;
		for(int i = 0; i < MMKAJBFBKNH.Count; i++)
		{
			if(!MMKAJBFBKNH[i].AGBOGBEOFME(other.MMKAJBFBKNH[i]))
				return false;
		}
		return EOHHFADHHBL_Complete == other.EOHHFADHHBL_Complete;
	}

	// // RVA: 0x1AE7F14 Offset: 0x1AE7F14 VA: 0x1AE7F14 Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock _GJLFANGDGCL_Target, long _MCKEOKFMLAH_SaveId);

	// // RVA: g Offset: 0x1AE6928 VA: 0x1AE6928
	public void LOAOLBNFNNP_InitDefault()
	{
		MMKAJBFBKNH[0].EALOBDHOCHP_stat = 4;
		MMKAJBFBKNH[0].NDFOAINJPIN_pos = 1;
		MMKAJBFBKNH[0].OKJMIFELDMD_Opn = 15;
		MMKAJBFBKNH[0].ICCJMCCJCBG = false;
		MMKAJBFBKNH[0].HCENOJKNCMK = false;
	}

	// // RVA: 0x1AE973C Offset: 0x1AE973C VA: 0x1AE973C
	// public void GGKLNCHMPFC(int _LFLLLOPAKCO_StoryId) { }
}
