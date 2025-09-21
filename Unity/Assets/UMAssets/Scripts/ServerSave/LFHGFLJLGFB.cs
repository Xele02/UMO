
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use LFHGFLJLGFB_FavoritePlayer", true)]
public class LFHGFLJLGFB { }
public class LFHGFLJLGFB_FavoritePlayer : KLFDBFMNLBL_ServerSaveBlock
{
	private const int ECFEMKGFDCE = 1;
	private const int ODDKIBLJKPI = 50;
	private int ENOBDCFHELD; // 0x24
	private int FCEJCHGLFGN; // 0x28
	private List<CEBFFLDKAEC_SecureInt> FNDJLOMNECG; // 0x2C

	//public int KPEBMCLONHK { get; } ??
	public override bool DMICHEJIAJL { get { return false; } } // 0xD6C5FC NFKFOODCJJB

	// // RVA: 0xD6B438 Offset: 0xD6B438 VA: 0xD6B438
	public LFHGFLJLGFB_FavoritePlayer()
	{
		FNDJLOMNECG = new List<CEBFFLDKAEC_SecureInt>(50);
		KMBPACJNEOF_Reset();
	}

	// // RVA: 0xD6B4DC Offset: 0xD6B4DC VA: 0xD6B4DC Slot: 4
	public override void KMBPACJNEOF_Reset()
	{
		ENOBDCFHELD = (int)Utility.GetCurrentUnixTime() ^ 0x5721577;
		FCEJCHGLFGN = (int)Utility.GetCurrentUnixTime() ^ 0x3846732;
		FNDJLOMNECG.Clear();
	}

	// // RVA: 0xD6B5B0 Offset: 0xD6B5B0 VA: 0xD6B5B0
	// private bool AHDJOFBGCKE() { }

	// // RVA: 0xD6B6A0 Offset: 0xD6B6A0 VA: 0xD6B6A0
	public void BNFBKGHBHHN(int _PPFNGGCBJKC_id)
	{
		CEBFFLDKAEC_SecureInt val = new CEBFFLDKAEC_SecureInt();
		val.DNJEJEANJGL_Value = _PPFNGGCBJKC_id;
		FNDJLOMNECG.Add(val);
	}

	// // RVA: 0xD6B79C Offset: 0xD6B79C VA: 0xD6B79C
	public void LJBFHCDHOHP(int _PPFNGGCBJKC_id)
	{
		FNDJLOMNECG.Remove(FNDJLOMNECG.Find((CEBFFLDKAEC_SecureInt GGHLPLMKFFE) =>
		{
			//0xD6C750
			return GGHLPLMKFFE.DNJEJEANJGL_Value == _PPFNGGCBJKC_id;
		}));
	}

	// // RVA: 0xD6B8D0 Offset: 0xD6B8D0 VA: 0xD6B8D0
	public int EFNAAHDHCEL()
	{
		return FNDJLOMNECG.Count;
	}

	// // RVA: 0xD6B948 Offset: 0xD6B948 VA: 0xD6B948
	public int OKAOABMKPGP(int _OIPCCBHIKIA_index)
	{
		return FNDJLOMNECG[_OIPCCBHIKIA_index].DNJEJEANJGL_Value;
	}

	// // RVA: 0xD6B9E8 Offset: 0xD6B9E8 VA: 0xD6B9E8
	public bool FFKIDMKHIOE(int _PPFNGGCBJKC_id)
	{
		return FNDJLOMNECG.Find((CEBFFLDKAEC_SecureInt GGHLPLMKFFE) =>
		{
			//0xD6C6C8
			return GGHLPLMKFFE.DNJEJEANJGL_Value == _PPFNGGCBJKC_id;
		}) != null;
	}

	// // RVA: 0xD6BAF0 Offset: 0xD6BAF0 VA: 0xD6BAF0
	// public void OKIOKKEJCOH() { }

	// // RVA: 0xD6BB68 Offset: 0xD6BB68 VA: 0xD6BB68 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long _MCKEOKFMLAH_SaveId)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int i = 0; i < FNDJLOMNECG.Count; i++)
			{
				data2.Add(FNDJLOMNECG[i].DNJEJEANJGL_Value);
			}
			data["list"] = data2;
		}
		data[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = _MCKEOKFMLAH_SaveId;
		data[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 1;
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0xD6BE50 Offset: 0xD6BE50 VA: 0xD6BE50 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool isInvalid = false;
		if(!OILEIIEIBHP.BBAJPINMOEP_Contains(JIKKNHIAEKG_BlockName))
		{
			return false;
		}
		if (!OILEIIEIBHP.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev))
			isInvalid = true;
		else
		{
			if ((int)OILEIIEIBHP[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] != 1)
				isInvalid = true;
		}
		FNDJLOMNECG.Clear();
		if(OILEIIEIBHP.BBAJPINMOEP_Contains("list"))
		{
			IBCGPBOGOGP_ReadIntArray(OILEIIEIBHP, "list", 0, 50, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
			{
				//0xD6C6B8
				if (_JBGEEPFKIGG_val == 0)
					return;
				BNFBKGHBHHN(_JBGEEPFKIGG_val);
			}, ref isInvalid);
		}
		KFKDMBPNLJK_BlockInvalid = isInvalid;
		return true;
	}

	// // RVA: 0xD6C138 Offset: 0xD6C138 VA: 0xD6C138 Slot: 7
	public override void BMGGKONLFIC_Copy(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		LFHGFLJLGFB_FavoritePlayer f = GPBJHKLFCEP as LFHGFLJLGFB_FavoritePlayer;
		FNDJLOMNECG.Clear();
		for(int i = 0; i < f.FNDJLOMNECG.Count; i++)
		{
			BNFBKGHBHHN(f.FNDJLOMNECG[i].DNJEJEANJGL_Value);
		}
	}

	// // RVA: 0xD6C300 Offset: 0xD6C300 VA: 0xD6C300 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		LFHGFLJLGFB_FavoritePlayer other = GPBJHKLFCEP as LFHGFLJLGFB_FavoritePlayer;
		if (FNDJLOMNECG.Count != other.FNDJLOMNECG.Count)
			return false;
		for(int i = 0; i < FNDJLOMNECG.Count; i++)
		{
			if (other.FNDJLOMNECG.Find((CEBFFLDKAEC_SecureInt JKDKBCPFFEL) =>
			 {
				 //0xD6C70C
				 return JKDKBCPFFEL.DNJEJEANJGL_Value == FNDJLOMNECG[i].DNJEJEANJGL_Value;
			 }) == null)
				return false;
		}
		return true;
	}

	// // RVA: 0xD6C5F8 Offset: 0xD6C5F8 VA: 0xD6C5F8 Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock _GJLFANGDGCL_Target, long _MCKEOKFMLAH_SaveId);

	// // RVA: 0xD6C604 Offset: 0xD6C604 VA: 0xD6C604 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "TODO");
		return null;
	}
}
