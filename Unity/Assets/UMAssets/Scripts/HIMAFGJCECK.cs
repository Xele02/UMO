
using System.Collections.Generic;

public class HIMAFGJCECK
{
	public string KLMPFGOCBHC_description; // 0x8
	public List<BPADANIKFHP> OJGPPOKENLG_Groups; // 0xC OJGPPOKENLG_ProbabilityPerGroupKey
	public List<IJPECOFPOCH> DDGPEFEEKFP_Items; // 0x10
	public IKMBBPDBECA KACECFNECON_extra; // 0x14

	// // RVA: 0x18373CC Offset: 0x18373CC VA: 0x18373CC
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data, IKMBBPDBECA KPCLJMBJEOI)
	{
		KLMPFGOCBHC_description = (string)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.KLMPFGOCBHC_description];
		KACECFNECON_extra = KPCLJMBJEOI;
		EDOHBJAPLPF_JsonData d = _IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.PNIFJJPHLDH_probability_per_group_key];
		OJGPPOKENLG_Groups = new List<BPADANIKFHP>();
		for(int i = 0; i < BPADANIKFHP.GIFAIIDJPND.Count; i++)
		{
			string s = BPADANIKFHP.GIFAIIDJPND[BPADANIKFHP.GIFAIIDJPND.Count - 1 - i];
			if (d.BBAJPINMOEP_Contains(s))
			{
				BPADANIKFHP data = new BPADANIKFHP();
				data.EKLIPGELKCL_Rarity = BPADANIKFHP.GIFAIIDJPND.Count - i;
				data.MMOJHIPAAIK_probability = (string)d[s];
				data.HBHMAKNGKFK_Items = new List<KFKCGKGKBJL>();
				OJGPPOKENLG_Groups.Add(data);
			}
		}
		d = _IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.HBHMAKNGKFK_Items];
		DDGPEFEEKFP_Items = new List<IJPECOFPOCH>();
		List<KFKCGKGKBJL> l2 = new List<KFKCGKGKBJL>(d.HNBFOAJIIAL_Count);
		for(int i = 0; i < d.HNBFOAJIIAL_Count; i++)
		{
			KFKCGKGKBJL data = new KFKCGKGKBJL();
			data.KHEKNNFCAOI_Init(d[i]);
			data.EILKGEADKGH_Order = i;
			if(KACECFNECON_extra != null)
			{
				int idx = KACECFNECON_extra.FLADABCFDFA_Pickup.FindIndex((CEBFFLDKAEC_SecureInt _GHPLINIACBB_x) =>
				{
					//0x1838588
					return _GHPLINIACBB_x.DNJEJEANJGL_Value == data.NANNGLGOFKH_value;
				});
				if(idx > -1)
				{
					data.JOPPFEHKNFO_Pickup = true;
				}
				idx = DDGPEFEEKFP_Items.FindIndex((IJPECOFPOCH _GHPLINIACBB_x) =>
				{
					//0x18385EC
					return _GHPLINIACBB_x.GDEJFKCMNAC_EpisodeId == data.GDEJFKCMNAC_EpisodeId;
				});
				if(idx < 0)
				{
					IJPECOFPOCH data2 = new IJPECOFPOCH();
					data2.GDEJFKCMNAC_EpisodeId = data.GDEJFKCMNAC_EpisodeId;
					if (KACECFNECON_extra == null)
						data2.MGJBGEFMPIL = 500000 + data.GDEJFKCMNAC_EpisodeId;
					else
						data2.MGJBGEFMPIL = KACECFNECON_extra.GGBDGHNAIDG(data.GDEJFKCMNAC_EpisodeId);
					data2.HBHMAKNGKFK_Items = new List<KFKCGKGKBJL>();
					DDGPEFEEKFP_Items.Add(data2);
				}
				l2.Add(data);
			}
		}
		l2.Sort((KFKCGKGKBJL DPFKCJEKIHA, KFKCGKGKBJL IJAOGPFKDBP) =>
		{
			//0x18383C8
			if(DPFKCJEKIHA.FJNGOPBGEOI_GroupIdx != IJAOGPFKDBP.FJNGOPBGEOI_GroupIdx)
			{
				if (IJAOGPFKDBP.FJNGOPBGEOI_GroupIdx < DPFKCJEKIHA.FJNGOPBGEOI_GroupIdx)
					return -1;
				if (DPFKCJEKIHA.FJNGOPBGEOI_GroupIdx < IJAOGPFKDBP.FJNGOPBGEOI_GroupIdx)
					return 1;
			}
			return DPFKCJEKIHA.EILKGEADKGH_Order.CompareTo(IJAOGPFKDBP.EILKGEADKGH_Order);
		});
		DDGPEFEEKFP_Items.Sort((IJPECOFPOCH DPFKCJEKIHA, IJPECOFPOCH IJAOGPFKDBP) =>
		{
			//0x1838518
			return DPFKCJEKIHA.MGJBGEFMPIL.CompareTo(IJAOGPFKDBP.MGJBGEFMPIL);
		});
		for(int i = 0; i < d.HNBFOAJIIAL_Count; i++)
		{
			KFKCGKGKBJL data = l2[i];
			int idx = OJGPPOKENLG_Groups.FindIndex((BPADANIKFHP _GHPLINIACBB_x) =>
			{
				//0x1838650
				return _GHPLINIACBB_x.EKLIPGELKCL_Rarity == data.FJNGOPBGEOI_GroupIdx;
			});
			if(idx > -1)
			{
				OJGPPOKENLG_Groups[idx].HBHMAKNGKFK_Items.Add(data);
			}
			idx = DDGPEFEEKFP_Items.FindIndex((IJPECOFPOCH _GHPLINIACBB_x) =>
			{
				//0x18386B4
				return _GHPLINIACBB_x.GDEJFKCMNAC_EpisodeId == data.GDEJFKCMNAC_EpisodeId;
			});
			if(idx > -1)
			{
				DDGPEFEEKFP_Items[idx].HBHMAKNGKFK_Items.Add(data);
			}
		}
	}

	// // RVA: 0x18382E8 Offset: 0x18382E8 VA: 0x18382E8
	// public string BHHCKIIKKDD(string _LJNAKDMILMC_key) { }
}
