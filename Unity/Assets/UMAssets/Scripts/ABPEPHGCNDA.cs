
using System.Collections.Generic;

public class ABPEPHGCNDA
{
	private const int FBGGEFFJJHB = 0x2541a98f;
	private const sbyte JFOFMKBJBBE_False = 0x13;
	private const sbyte CNECJGKECHK_True = 0x57;
	public sbyte EAJCFBCHIFB_IsRareCrypted = JFOFMKBJBBE_False; // 0x8
	public int HLMAFFLCCKD = FBGGEFFJJHB; // 0xC
	public List<BPADANIKFHP> OJGPPOKENLG_ProbabilityPerGroupKey; // 0x10
	public List<IJPECOFPOCH> DDGPEFEEKFP_Items; // 0x14

	public bool EKLIPGELKCL_IsRare { get { return EAJCFBCHIFB_IsRareCrypted == CNECJGKECHK_True; } set { EAJCFBCHIFB_IsRareCrypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x15B1454 OEEHBGECGKL 0x15B1468 GHLMHLJJBIG
	public int HMFFHLPNMPH_Count { get { return HLMAFFLCCKD ^ FBGGEFFJJHB; } set { HLMAFFLCCKD = value ^ FBGGEFFJJHB; } } //0x15B1498 NJOGDDPICKG 0x15B14AC NBBGMMBICNA

	// // RVA: 0x15B14C0 Offset: 0x15B14C0 VA: 0x15B14C0
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK, IKMBBPDBECA KACECFNECON)
	{
		HMFFHLPNMPH_Count = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.HMFFHLPNMPH_count];
		EDOHBJAPLPF_JsonData d = IDLHJIOMJBK[AFEHLCGHAEE_Strings.PNIFJJPHLDH_probability_per_group_key];
		OJGPPOKENLG_ProbabilityPerGroupKey = new List<BPADANIKFHP>(d.HNBFOAJIIAL_Count);
		for(int i = 0; i < d.HNBFOAJIIAL_Count; i++)
		{
			string s = BPADANIKFHP.GIFAIIDJPND[BPADANIKFHP.GIFAIIDJPND.Count - 1 - i];
			if (d[i].BBAJPINMOEP_Contains(s))
			{
				BPADANIKFHP data = new BPADANIKFHP();
				data.EKLIPGELKCL = BPADANIKFHP.GIFAIIDJPND.Count - i;
				data.MMOJHIPAAIK = (string)d[i][s];
				data.HBHMAKNGKFK = new List<KFKCGKGKBJL>();
				OJGPPOKENLG_ProbabilityPerGroupKey.Add(data);
			}
		}
		d = IDLHJIOMJBK[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items];
		DDGPEFEEKFP_Items = new List<IJPECOFPOCH>(d.HNBFOAJIIAL_Count);
		List<KFKCGKGKBJL> l2 = new List<KFKCGKGKBJL>();
		for(int i = 0; i < d.HNBFOAJIIAL_Count; i++)
		{
			KFKCGKGKBJL data = new KFKCGKGKBJL();
			data.KHEKNNFCAOI(d[i]);
			data.EILKGEADKGH_Idx = i;
			int idx = DDGPEFEEKFP_Items.FindIndex((IJPECOFPOCH GHPLINIACBB) =>
			{
				//0x15B26F0
				return GHPLINIACBB.GDEJFKCMNAC_EpisodeId == data.GDEJFKCMNAC_EpisodeId;
			});
			if(idx < 0)
			{
				IJPECOFPOCH data2 = new IJPECOFPOCH();
				data2.GDEJFKCMNAC_EpisodeId = data.GDEJFKCMNAC_EpisodeId;
				if(KACECFNECON == null)
				{
					data2.MGJBGEFMPIL = 500000 + data.GDEJFKCMNAC_EpisodeId;
				}
				else
				{
					data2.MGJBGEFMPIL = KACECFNECON.GGBDGHNAIDG(data.GDEJFKCMNAC_EpisodeId);
				}
				data2.HBHMAKNGKFK = new List<KFKCGKGKBJL>();
				DDGPEFEEKFP_Items.Add(data2);
			}
			l2.Add(data);
		}
		l2.Sort((KFKCGKGKBJL DPFKCJEKIHA, KFKCGKGKBJL IJAOGPFKDBP) =>
		{
			//0x15B2530
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
			//0x15B2680
			return DPFKCJEKIHA.MGJBGEFMPIL.CompareTo(IJAOGPFKDBP.MGJBGEFMPIL);
		});
		for(int i = 0; i < d.HNBFOAJIIAL_Count; i++)
		{
			if(KACECFNECON != null)
			{
				int idx = KACECFNECON.PGKIHFOKEHL_Feature.FindIndex((CEBFFLDKAEC_SecureInt GHPLINIACBB) =>
				{
					//0x15B2754
					return GHPLINIACBB.DNJEJEANJGL_Value == l2[i].NANNGLGOFKH_Value;
				});
				if(idx > -1)
				{
					l2[i].FDIJEBNIBIE_IsFeatured = true;
				}
				idx = KACECFNECON.FLADABCFDFA_Pickup.FindIndex((CEBFFLDKAEC_SecureInt GHPLINIACBB) =>
				{
					//0x15B27B8
					return GHPLINIACBB.DNJEJEANJGL_Value == l2[2].NANNGLGOFKH_Value;
				});
				if(idx > -1)
				{
					l2[i].JOPPFEHKNFO_IsPickup = true;
				}
			}
			int idx2 = OJGPPOKENLG_ProbabilityPerGroupKey.FindIndex((BPADANIKFHP GHPLINIACBB) =>
			{
				//0x15B281C
				return GHPLINIACBB.EKLIPGELKCL == l2[i].FJNGOPBGEOI_GroupIdx;
			});
			if(idx2 > -1)
			{
				OJGPPOKENLG_ProbabilityPerGroupKey[idx2].HBHMAKNGKFK.Add(l2[i]);
			}
			idx2 = DDGPEFEEKFP_Items.FindIndex((IJPECOFPOCH GHPLINIACBB) =>
			{
				//0x15B2880
				return GHPLINIACBB.GDEJFKCMNAC_EpisodeId == l2[2].GDEJFKCMNAC_EpisodeId;
			});
			if(idx2 > -1)
			{
				DDGPEFEEKFP_Items[idx2].HBHMAKNGKFK.Add(l2[i]);
			}
		}
	}
}
