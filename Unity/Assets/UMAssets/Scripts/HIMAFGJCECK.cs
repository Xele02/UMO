
using System.Collections.Generic;

public class HIMAFGJCECK
{
	public string KLMPFGOCBHC_Desc; // 0x8
	public List<BPADANIKFHP> OJGPPOKENLG_ProbabilityPerGroupKey; // 0xC
	public List<IJPECOFPOCH> DDGPEFEEKFP_Items; // 0x10
	public IKMBBPDBECA KACECFNECON; // 0x14

	// // RVA: 0x18373CC Offset: 0x18373CC VA: 0x18373CC
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK, IKMBBPDBECA KPCLJMBJEOI)
	{
		KLMPFGOCBHC_Desc = (string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.KLMPFGOCBHC_description];
		KACECFNECON = KPCLJMBJEOI;
		EDOHBJAPLPF_JsonData d = IDLHJIOMJBK[AFEHLCGHAEE_Strings.PNIFJJPHLDH_probability_per_group_key];
		OJGPPOKENLG_ProbabilityPerGroupKey = new List<BPADANIKFHP>();
		for(int i = 0; i < BPADANIKFHP.GIFAIIDJPND.Count; i++)
		{
			string s = BPADANIKFHP.GIFAIIDJPND[BPADANIKFHP.GIFAIIDJPND.Count - 1 - i];
			if (d.BBAJPINMOEP_Contains(s))
			{
				BPADANIKFHP data = new BPADANIKFHP();
				data.EKLIPGELKCL = BPADANIKFHP.GIFAIIDJPND.Count - i;
				data.MMOJHIPAAIK = (string)d[s];
				data.HBHMAKNGKFK = new List<KFKCGKGKBJL>();
				OJGPPOKENLG_ProbabilityPerGroupKey.Add(data);
			}
		}
		d = IDLHJIOMJBK[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items];
		DDGPEFEEKFP_Items = new List<IJPECOFPOCH>();
		List<KFKCGKGKBJL> l2 = new List<KFKCGKGKBJL>(d.HNBFOAJIIAL_Count);
		for(int i = 0; i < d.HNBFOAJIIAL_Count; i++)
		{
			KFKCGKGKBJL data = new KFKCGKGKBJL();
			data.KHEKNNFCAOI(d[i]);
			data.EILKGEADKGH_Idx = i;
			if(KACECFNECON != null)
			{
				int idx = KACECFNECON.FLADABCFDFA_Pickup.FindIndex((CEBFFLDKAEC_SecureInt GHPLINIACBB) =>
				{
					//0x1838588
					return GHPLINIACBB.DNJEJEANJGL_Value == data.NANNGLGOFKH_Value;
				});
				if(idx > -1)
				{
					data.JOPPFEHKNFO_IsPickup = true;
				}
				idx = DDGPEFEEKFP_Items.FindIndex((IJPECOFPOCH GHPLINIACBB) =>
				{
					//0x18385EC
					return GHPLINIACBB.GDEJFKCMNAC_EpisodeId == data.GDEJFKCMNAC_EpisodeId;
				});
				if(idx < 0)
				{
					IJPECOFPOCH data2 = new IJPECOFPOCH();
					data2.GDEJFKCMNAC_EpisodeId = data.GDEJFKCMNAC_EpisodeId;
					if (KACECFNECON == null)
						data2.MGJBGEFMPIL = 500000 + data.GDEJFKCMNAC_EpisodeId;
					else
						data2.MGJBGEFMPIL = KACECFNECON.GGBDGHNAIDG(data.GDEJFKCMNAC_EpisodeId);
					data2.HBHMAKNGKFK = new List<KFKCGKGKBJL>();
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
			return DPFKCJEKIHA.EILKGEADKGH_Idx.CompareTo(IJAOGPFKDBP.EILKGEADKGH_Idx);
		});
		DDGPEFEEKFP_Items.Sort((IJPECOFPOCH DPFKCJEKIHA, IJPECOFPOCH IJAOGPFKDBP) =>
		{
			//0x1838518
			return DPFKCJEKIHA.MGJBGEFMPIL.CompareTo(IJAOGPFKDBP.MGJBGEFMPIL);
		});
		for(int i = 0; i < d.HNBFOAJIIAL_Count; i++)
		{
			KFKCGKGKBJL data = l2[i];
			int idx = OJGPPOKENLG_ProbabilityPerGroupKey.FindIndex((BPADANIKFHP GHPLINIACBB) =>
			{
				//0x1838650
				return GHPLINIACBB.EKLIPGELKCL == data.FJNGOPBGEOI_GroupIdx;
			});
			if(idx > -1)
			{
				OJGPPOKENLG_ProbabilityPerGroupKey[idx].HBHMAKNGKFK.Add(data);
			}
			idx = DDGPEFEEKFP_Items.FindIndex((IJPECOFPOCH GHPLINIACBB) =>
			{
				//0x18386B4
				return GHPLINIACBB.GDEJFKCMNAC_EpisodeId == data.GDEJFKCMNAC_EpisodeId;
			});
			if(idx > -1)
			{
				DDGPEFEEKFP_Items[idx].HBHMAKNGKFK.Add(data);
			}
		}
	}

	// // RVA: 0x18382E8 Offset: 0x18382E8 VA: 0x18382E8
	// public string BHHCKIIKKDD(string LJNAKDMILMC) { }
}
