
using System.Collections.Generic;

public class ABPEPHGCNDA
{
	private const int FBGGEFFJJHB_xor = 0x2541a98f;
	private const sbyte JFOFMKBJBBE_False = 0x13;
	private const sbyte CNECJGKECHK_True = 0x57;
	public sbyte EAJCFBCHIFB_RarityCrypted = JFOFMKBJBBE_False; // 0x8
	public int HLMAFFLCCKD = FBGGEFFJJHB_xor; // 0xC
	public List<BPADANIKFHP> OJGPPOKENLG_ProbabilityPerGroupKey; // 0x10
	public List<IJPECOFPOCH> DDGPEFEEKFP_Items; // 0x14

	public bool EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted == CNECJGKECHK_True; } set { EAJCFBCHIFB_RarityCrypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x15B1454 OEEHBGECGKL 0x15B1468 GHLMHLJJBIG
	public int HMFFHLPNMPH_Count { get { return HLMAFFLCCKD ^ FBGGEFFJJHB_xor; } set { HLMAFFLCCKD = value ^ FBGGEFFJJHB_xor; } } //0x15B1498 NJOGDDPICKG 0x15B14AC NBBGMMBICNA

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
				data.EKLIPGELKCL_Rarity = BPADANIKFHP.GIFAIIDJPND.Count - i;
				data.MMOJHIPAAIK = (string)d[i][s];
				data.HBHMAKNGKFK_Items = new List<KFKCGKGKBJL>();
				OJGPPOKENLG_ProbabilityPerGroupKey.Add(data);
			}
		}
		d = IDLHJIOMJBK[AFEHLCGHAEE_Strings.HBHMAKNGKFK_Items];
		DDGPEFEEKFP_Items = new List<IJPECOFPOCH>(d.HNBFOAJIIAL_Count);
		List<KFKCGKGKBJL> l2 = new List<KFKCGKGKBJL>();
		for(int i = 0; i < d.HNBFOAJIIAL_Count; i++)
		{
			KFKCGKGKBJL data = new KFKCGKGKBJL();
			data.KHEKNNFCAOI(d[i]);
			data.EILKGEADKGH_Order = i;
			int idx = DDGPEFEEKFP_Items.FindIndex((IJPECOFPOCH _GHPLINIACBB_x) =>
			{
				//0x15B26F0
				return _GHPLINIACBB_x.GDEJFKCMNAC_EpisodeId == data.GDEJFKCMNAC_EpisodeId;
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
				data2.HBHMAKNGKFK_Items = new List<KFKCGKGKBJL>();
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
			return DPFKCJEKIHA.EILKGEADKGH_Order.CompareTo(IJAOGPFKDBP.EILKGEADKGH_Order);
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
				int idx = KACECFNECON.PGKIHFOKEHL_Feature.FindIndex((CEBFFLDKAEC_SecureInt _GHPLINIACBB_x) =>
				{
					//0x15B2754
					return _GHPLINIACBB_x.DNJEJEANJGL_Value == l2[i].NANNGLGOFKH_Value;
				});
				if(idx > -1)
				{
					l2[i].FDIJEBNIBIE_IsFeatured = true;
				}
				idx = KACECFNECON.FLADABCFDFA_Pickup.FindIndex((CEBFFLDKAEC_SecureInt _GHPLINIACBB_x) =>
				{
					//0x15B27B8
					return _GHPLINIACBB_x.DNJEJEANJGL_Value == l2[2].NANNGLGOFKH_Value;
				});
				if(idx > -1)
				{
					l2[i].JOPPFEHKNFO_IsPickup = true;
				}
			}
			int idx2 = OJGPPOKENLG_ProbabilityPerGroupKey.FindIndex((BPADANIKFHP _GHPLINIACBB_x) =>
			{
				//0x15B281C
				return _GHPLINIACBB_x.EKLIPGELKCL_Rarity == l2[i].FJNGOPBGEOI_GroupIdx;
			});
			if(idx2 > -1)
			{
				OJGPPOKENLG_ProbabilityPerGroupKey[idx2].HBHMAKNGKFK_Items.Add(l2[i]);
			}
			idx2 = DDGPEFEEKFP_Items.FindIndex((IJPECOFPOCH _GHPLINIACBB_x) =>
			{
				//0x15B2880
				return _GHPLINIACBB_x.GDEJFKCMNAC_EpisodeId == l2[2].GDEJFKCMNAC_EpisodeId;
			});
			if(idx2 > -1)
			{
				DDGPEFEEKFP_Items[idx2].HBHMAKNGKFK_Items.Add(l2[i]);
			}
		}
	}
}
