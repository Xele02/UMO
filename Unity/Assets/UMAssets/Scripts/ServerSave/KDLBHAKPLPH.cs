
using System.Collections.Generic;

[System.Obsolete("Use KDLBHAKPLPH_ArMarker", true)]
public class KDLBHAKPLPH { }
public class KDLBHAKPLPH_ArMarker : KLFDBFMNLBL_ServerSaveBlock
{
	public class KGFJLMLOFED
	{
		public int HIEKBDMHKLP_MarkerNo { get; set; } // 0x8 MICLNMBOAJD_bgs FEDEEOKEBBH_get_MarkerNo AJEOEBDGIEJ_set_MarkerNo
		public long BEBJKJKBOGH_date { get; set; } // 0x10 MCIJNMKFMDB_bgs DIAPHCJBPFD_get_date IHAIKPNEEJE_set_date
		//public bool FJODMPGPDDD_Unlocked { get; } 0xE7D534 CGKAEMGLHNK_get_Unlocked

		//// RVA: 0xE7D51C Offset: 0xE7D51C VA: 0xE7D51C
		//public void GLHANCMGNDM_Unlock(long _JGNBPFCJLKI_d) { }

		//// RVA: 0xE7C4C4 Offset: 0xE7C4C4 VA: 0xE7C4C4
		public void ODDIHGPONFL_Copy(KGFJLMLOFED GPBJHKLFCEP)
		{
			HIEKBDMHKLP_MarkerNo = GPBJHKLFCEP.HIEKBDMHKLP_MarkerNo;
			BEBJKJKBOGH_date = GPBJHKLFCEP.BEBJKJKBOGH_date;
		}

		//// RVA: 0xE7C788 Offset: 0xE7C788 VA: 0xE7C788
		public bool AGBOGBEOFME(KGFJLMLOFED OIKJFMGEICL)
		{
			if(HIEKBDMHKLP_MarkerNo != OIKJFMGEICL.HIEKBDMHKLP_MarkerNo ||
				BEBJKJKBOGH_date != OIKJFMGEICL.BEBJKJKBOGH_date)
				return false;
			return true;
		}

		//// RVA: 0xE7CBEC Offset: 0xE7CBEC VA: 0xE7CBEC
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string _JIKKNHIAEKG_BlockName, string MJBACHKCIHA, int _OIPCCBHIKIA_index, KDLBHAKPLPH_ArMarker.KGFJLMLOFED _OHMCIEMIKCE_t, bool KFCGIKHEEMB) { }
	}

	private const int ECFEMKGFDCE_CurrentVersion = 2;
	private const int KDNHEMPAGIE = 100;
	public static string POFDDFCGEGP_Underscore = "_"; // 0x0

	public List<KGFJLMLOFED> DNKNFFPLGNM { get; private set; } // 0x24 PKCJOFJIEEA_bgs MJGPHKECNEO_bgs KGHIIDAKJOI_bgs
	public override bool DMICHEJIAJL { get { return true; } } // 0xE7D4A0 NFKFOODCJJB_bgs

	// // RVA: 0xE7B884 Offset: 0xE7B884 VA: 0xE7B884
	public KDLBHAKPLPH_ArMarker()
	{
		DNKNFFPLGNM = new List<KGFJLMLOFED>(100);
		KMBPACJNEOF_Reset();
	}

	// // RVA: 0xE7B928 Offset: 0xE7B928 VA: 0xE7B928 Slot: 4
	public override void KMBPACJNEOF_Reset()
	{
		DNKNFFPLGNM.Clear();
		for(int i = 0; i < 100; i++)
		{
			KGFJLMLOFED data = new KGFJLMLOFED();
			data.HIEKBDMHKLP_MarkerNo = i + 1;
			data.BEBJKJKBOGH_date = 0;
			DNKNFFPLGNM.Add(data);
		}
	}

	// // RVA: 0xE7BA60 Offset: 0xE7BA60 VA: 0xE7BA60 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long _MCKEOKFMLAH_SaveId)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data[POFDDFCGEGP_Underscore] = "";
		for(int i = 0; i < DNKNFFPLGNM.Count; i++)
		{
			if(DNKNFFPLGNM[i].BEBJKJKBOGH_date != 0)
			{
				EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
				data2[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id] = DNKNFFPLGNM[i].HIEKBDMHKLP_MarkerNo;
				data2[AFEHLCGHAEE_Strings.BEBJKJKBOGH_date] = DNKNFFPLGNM[i].BEBJKJKBOGH_date;
				data[POFDDFCGEGP_Underscore + (i + 1)] = data2;
			}
		}
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = _MCKEOKFMLAH_SaveId;
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

	// // RVA: 0xE7C078 Offset: 0xE7C078 VA: 0xE7C078 Slot: 6
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
				for(int i = 0; i < DNKNFFPLGNM.Count; i++)
				{
					string str = POFDDFCGEGP_Underscore + (i + 1).ToString();
					if(block.BBAJPINMOEP_Contains(str))
					{
						EDOHBJAPLPF_JsonData b = block[str];
						KGFJLMLOFED data = DNKNFFPLGNM[i];
						data.HIEKBDMHKLP_MarkerNo = i + 1;
						data.BEBJKJKBOGH_date = DKMPHAPBDLH_GetLong(b, AFEHLCGHAEE_Strings.BEBJKJKBOGH_date, 0, ref isInvalid);
					}
				}
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0xE7C2F4 Offset: 0xE7C2F4 VA: 0xE7C2F4 Slot: 7
	public override void BMGGKONLFIC_Copy(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		KDLBHAKPLPH_ArMarker a = GPBJHKLFCEP as KDLBHAKPLPH_ArMarker;
		for(int i = 0; i < DNKNFFPLGNM.Count; i++)
		{
			DNKNFFPLGNM[i].ODDIHGPONFL_Copy(a.DNKNFFPLGNM[i]);
		}
	}

	// // RVA: 0xE7C510 Offset: 0xE7C510 VA: 0xE7C510 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		KDLBHAKPLPH_ArMarker other = GPBJHKLFCEP as KDLBHAKPLPH_ArMarker;
		if(DNKNFFPLGNM.Count != other.DNKNFFPLGNM.Count)
			return false;
		for(int i = 0; i < DNKNFFPLGNM.Count; i++)
		{
			if(!DNKNFFPLGNM[i].AGBOGBEOFME(other.DNKNFFPLGNM[i]))
				return false;
		}
		return true;
	}

	// // RVA: 0xE7C7E0 Offset: 0xE7C7E0 VA: 0xE7C7E0 Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock _GJLFANGDGCL_Target, long _MCKEOKFMLAH_SaveId);
}
