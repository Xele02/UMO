using System.Collections.Generic;

public class GDMKJMAFJAG
{
	public HNJKJCDDIMG_SetInfo GEDOFFFKIFN; // 0x8
	public OPGDJANLKBM_RateInfo CGLAEOLPEGN; // 0xC

	//// RVA: 0x16B5520 Offset: 0x16B5520 VA: 0x16B5520
	//private int CEOEMJIFFBC(int _EKLIPGELKCL_Rarity) { }

	// RVA: 0x16B5530 Offset: 0x16B5530 VA: 0x16B5530
	public void KHEKNNFCAOI_Init(HNJKJCDDIMG_SetInfo FOPEBIFPPCJ, OPGDJANLKBM_RateInfo GOIIICHHHCL)
	{
		if(GOIIICHHHCL == null)
		{
			GEDOFFFKIFN = FOPEBIFPPCJ;
			CGLAEOLPEGN = null;
		}
		else
		{
			List<List<int>> l = new List<List<int>>();
			for(int i = 0; i < 11; i++)
			{
				l.Add(new List<int>());
			}
			GEDOFFFKIFN = new HNJKJCDDIMG_SetInfo();
			GEDOFFFKIFN.ODDIHGPONFL_Copy(FOPEBIFPPCJ);
			CGLAEOLPEGN = new OPGDJANLKBM_RateInfo();
			CGLAEOLPEGN.ODDIHGPONFL_Copy(GOIIICHHHCL);
			for (int i = 0; i < 20; i++)
			{
				if (GEDOFFFKIFN.FKNBLDPIPMC_GetItemCode(i) != 0)
				{
					if(GOIIICHHHCL.ADKDHKMPMHP_rate[i] > 0)
					{
						if(GOIIICHHHCL.HMFFHLPNMPH_count[i] > 0)
						{
							if(EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(GEDOFFFKIFN.FKNBLDPIPMC_GetItemCode(i)) == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem)
							{
								int itemId = EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(GEDOFFFKIFN.FKNBLDPIPMC_GetItemCode(i));
								KEEKEFEPKFN_GrowItem.MDFGLOIGAFE_GrowItemData item = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.NKDGLGCAPEI_GrowItem.CDENCMNHNGA_table[itemId - 1];
								if(item.INDDJNMPONH_type > 1)
								{
									if(item.INDDJNMPONH_type < 6)
									{
										l[item.EKLIPGELKCL_Rarity].Add(i);
									}
								}
							}
						}
					}
				}
			}
			for(int i = 0; i < l.Count; i++)
			{
				int j = 1;
				if (i == 1)
					j = 2;
				int b = 0;
				for(; j < l[i].Count;)
				{
					int v = UnityEngine.Random.Range(0, l[i].Count);
					int val = l[i][v];
					l[i].RemoveAt(v);
					b += CGLAEOLPEGN.ADKDHKMPMHP_rate[val];
					CGLAEOLPEGN.ADKDHKMPMHP_rate[val] = 0;
				}
				if(b > 0)
				{
					int c = 0;
					for (j = 0; j < l[i].Count; j++)
					{
						c += CGLAEOLPEGN.ADKDHKMPMHP_rate[l[i][j]];
					}
					if (c != 0)
					{
						for (j = 0; j < l[i].Count; j++)
						{
							CGLAEOLPEGN.ADKDHKMPMHP_rate[l[i][j]] = (CGLAEOLPEGN.ADKDHKMPMHP_rate[l[i][j]] * b) / c;
						}
					}
				}
			}
		}
	}
}

[System.Obsolete("Use HNJKJCDDIMG_SetInfo", true)]
public class HNJKJCDDIMG { }
[UMOClass()]
public class HNJKJCDDIMG_SetInfo
{
	public static int FBGGEFFJJHB_xor = 0x317f5543; // 0x0
	private int KDICDKHJJDD_SIdCrypted; // 0x8
	private List<int> PNFIBNJIOAN_Items = new List<int>(20); // 0xC

	[UMOMember()]
	public int LIHEBNPAIFI_SId { get { return KDICDKHJJDD_SIdCrypted ^ FBGGEFFJJHB_xor; } set { KDICDKHJJDD_SIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x15FBED0 GHOJKNLICON_bgs 0x15FBF68 EGONAJNHBEL_bgs

	//UMO
	[UMOMember()]
	private List<int> Items { get {
		List<int> Res = new List<int>();
		for(int i = 0; i < PNFIBNJIOAN_Items.Count; i++)
		{
			Res.Add(FKNBLDPIPMC_GetItemCode(i));
		}
		return Res;
	} }

	// RVA: 0x15FC004 Offset: 0x15FC004 VA: 0x15FC004
	public HNJKJCDDIMG_SetInfo()
	{
		for(int i = 0; i < 20; i++)
		{
			PNFIBNJIOAN_Items.Add(FBGGEFFJJHB_xor);
		}
	}

	//// RVA: 0x15FC124 Offset: 0x15FC124 VA: 0x15FC124
	//public uint CAOGDCBPBAN() { }

	//// RVA: 0x15FC250 Offset: 0x15FC250 VA: 0x15FC250
	public int FKNBLDPIPMC_GetItemCode(int _OIPCCBHIKIA_index)
	{
		return PNFIBNJIOAN_Items[_OIPCCBHIKIA_index] ^ FBGGEFFJJHB_xor;
	}

	//// RVA: 0x15FC31C Offset: 0x15FC31C VA: 0x15FC31C
	public void OEFHMMJFEKC_SetItemId(int _OIPCCBHIKIA_index, int _PPFNGGCBJKC_id)
	{
		PNFIBNJIOAN_Items[_OIPCCBHIKIA_index] = FBGGEFFJJHB_xor ^ _PPFNGGCBJKC_id;
	}

	//// RVA: 0x15FC3E8 Offset: 0x15FC3E8 VA: 0x15FC3E8
	public int KAINPNMMAEK_GetItemCount()
	{
		return PNFIBNJIOAN_Items.Count;
	}

	//// RVA: 0x15FC460 Offset: 0x15FC460 VA: 0x15FC460
	public void ODDIHGPONFL_Copy(HNJKJCDDIMG_SetInfo GPBJHKLFCEP)
	{
		LIHEBNPAIFI_SId = GPBJHKLFCEP.LIHEBNPAIFI_SId;
		for(int i = 0; i < GPBJHKLFCEP.KAINPNMMAEK_GetItemCount(); i++)
		{
			OEFHMMJFEKC_SetItemId(i, GPBJHKLFCEP.FKNBLDPIPMC_GetItemCode(i));
		}
	}
}

[System.Obsolete("Use OPGDJANLKBM_RateInfo", true)]
public class OPGDJANLKBM { }
[UMOClass()]
public class OPGDJANLKBM_RateInfo
{
	[UMOMember()]
	public int BFOLFCOBBJD_RateId; // 0x8
	[UMOMember()]
	public List<int> HMFFHLPNMPH_count; // 0xC
	[UMOMember()]
	public List<int> ADKDHKMPMHP_rate; // 0x10
	[UMOMember()]
	public List<int> DOOGFEGEKLG_max; // 0x14

	// RVA: 0xCB2388 Offset: 0xCB2388 VA: 0xCB2388
	public OPGDJANLKBM_RateInfo()
	{
		HMFFHLPNMPH_count = new List<int>(20);
		for(int i = 0; i < 20; i++)
		{
			HMFFHLPNMPH_count.Add(0);
		}
		ADKDHKMPMHP_rate = new List<int>(20);
		for (int i = 0; i < 20; i++)
		{
			ADKDHKMPMHP_rate.Add(0);
		}
		DOOGFEGEKLG_max = new List<int>(20);
		for (int i = 0; i < 20; i++)
		{
			DOOGFEGEKLG_max.Add(0);
		}
	}

	// RVA: 0xCB2554 Offset: 0xCB2554 VA: 0xCB2554
	//public uint CAOGDCBPBAN() { }

	// RVA: 0xCB2664 Offset: 0xCB2664 VA: 0xCB2664
	public void ODDIHGPONFL_Copy(OPGDJANLKBM_RateInfo GPBJHKLFCEP)
	{
		BFOLFCOBBJD_RateId = GPBJHKLFCEP.BFOLFCOBBJD_RateId;
		for(int i = 0; i < 20; i++)
		{
			ADKDHKMPMHP_rate[i] = GPBJHKLFCEP.ADKDHKMPMHP_rate[i];
			DOOGFEGEKLG_max[i] = GPBJHKLFCEP.DOOGFEGEKLG_max[i];
			HMFFHLPNMPH_count[i] = GPBJHKLFCEP.HMFFHLPNMPH_count[i];
		}
	}
}
