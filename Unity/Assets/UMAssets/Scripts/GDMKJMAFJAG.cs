using System.Collections.Generic;

public class GDMKJMAFJAG
{
	public HNJKJCDDIMG_SetInfo GEDOFFFKIFN; // 0x8
	public OPGDJANLKBM_RateInfo CGLAEOLPEGN; // 0xC

	//// RVA: 0x16B5520 Offset: 0x16B5520 VA: 0x16B5520
	//private int CEOEMJIFFBC(int EKLIPGELKCL) { }

	// RVA: 0x16B5530 Offset: 0x16B5530 VA: 0x16B5530
	public void KHEKNNFCAOI(HNJKJCDDIMG_SetInfo FOPEBIFPPCJ, OPGDJANLKBM_RateInfo GOIIICHHHCL)
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
			GEDOFFFKIFN.ODDIHGPONFL(FOPEBIFPPCJ);
			CGLAEOLPEGN = new OPGDJANLKBM_RateInfo();
			CGLAEOLPEGN.ODDIHGPONFL(GOIIICHHHCL);
			for (int i = 0; i < 20; i++)
			{
				if (GEDOFFFKIFN.FKNBLDPIPMC_GetItemId(i) != 0)
				{
					if(GOIIICHHHCL.ADKDHKMPMHP_Rate[i] > 0)
					{
						if(GOIIICHHHCL.HMFFHLPNMPH_Cnt[i] > 0)
						{
							if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(GEDOFFFKIFN.FKNBLDPIPMC_GetItemId(i)) == EKLNMHFCAOI.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem)
							{
								int itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(GEDOFFFKIFN.FKNBLDPIPMC_GetItemId(i));
								KEEKEFEPKFN_GrowItem.MDFGLOIGAFE_GrowItemData item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NKDGLGCAPEI_GrowItem.CDENCMNHNGA_GrowItemList[itemId - 1];
								if(item.INDDJNMPONH > 1)
								{
									if(item.INDDJNMPONH < 6)
									{
										l[item.EKLIPGELKCL].Add(i);
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
					b += CGLAEOLPEGN.ADKDHKMPMHP_Rate[val];
					CGLAEOLPEGN.ADKDHKMPMHP_Rate[val] = 0;
				}
				if(b > 0)
				{
					int c = 0;
					for (j = 0; j < l[i].Count; j++)
					{
						c += CGLAEOLPEGN.ADKDHKMPMHP_Rate[l[i][j]];
					}
					if (c != 0)
					{
						for (j = 0; j < l[i].Count; j++)
						{
							CGLAEOLPEGN.ADKDHKMPMHP_Rate[l[i][j]] = (CGLAEOLPEGN.ADKDHKMPMHP_Rate[l[i][j]] * b) / c;
						}
					}
				}
			}
		}
	}
}

[System.Obsolete("Use HNJKJCDDIMG_SetInfo", true)]
public class HNJKJCDDIMG { }
public class HNJKJCDDIMG_SetInfo
{
	public static int FBGGEFFJJHB = 0x317f5543; // 0x0
	private int KDICDKHJJDD_SIdCrypted; // 0x8
	private List<int> PNFIBNJIOAN_Items = new List<int>(20); // 0xC

	public int LIHEBNPAIFI_SId { get { return KDICDKHJJDD_SIdCrypted ^ FBGGEFFJJHB; } set { KDICDKHJJDD_SIdCrypted = value ^ FBGGEFFJJHB; } } //0x15FBED0 GHOJKNLICON 0x15FBF68 EGONAJNHBEL

	// RVA: 0x15FC004 Offset: 0x15FC004 VA: 0x15FC004
	public HNJKJCDDIMG_SetInfo()
	{
		for(int i = 0; i < 20; i++)
		{
			PNFIBNJIOAN_Items.Add(FBGGEFFJJHB);
		}
	}

	//// RVA: 0x15FC124 Offset: 0x15FC124 VA: 0x15FC124
	//public uint CAOGDCBPBAN() { }

	//// RVA: 0x15FC250 Offset: 0x15FC250 VA: 0x15FC250
	public int FKNBLDPIPMC_GetItemId(int OIPCCBHIKIA)
	{
		return PNFIBNJIOAN_Items[OIPCCBHIKIA] ^ FBGGEFFJJHB;
	}

	//// RVA: 0x15FC31C Offset: 0x15FC31C VA: 0x15FC31C
	public void OEFHMMJFEKC_SetItemId(int OIPCCBHIKIA, int PPFNGGCBJKC)
	{
		PNFIBNJIOAN_Items[OIPCCBHIKIA] = FBGGEFFJJHB ^ PPFNGGCBJKC;
	}

	//// RVA: 0x15FC3E8 Offset: 0x15FC3E8 VA: 0x15FC3E8
	public int KAINPNMMAEK_GetItemsCount()
	{
		return PNFIBNJIOAN_Items.Count;
	}

	//// RVA: 0x15FC460 Offset: 0x15FC460 VA: 0x15FC460
	public void ODDIHGPONFL(HNJKJCDDIMG_SetInfo GPBJHKLFCEP)
	{
		LIHEBNPAIFI_SId = GPBJHKLFCEP.LIHEBNPAIFI_SId;
		for(int i = 0; i < GPBJHKLFCEP.KAINPNMMAEK_GetItemsCount(); i++)
		{
			OEFHMMJFEKC_SetItemId(i, GPBJHKLFCEP.FKNBLDPIPMC_GetItemId(i));
		}
	}
}

[System.Obsolete("Use OPGDJANLKBM_RateInfo", true)]
public class OPGDJANLKBM { }
public class OPGDJANLKBM_RateInfo
{
	public int BFOLFCOBBJD_RId; // 0x8
	public List<int> HMFFHLPNMPH_Cnt; // 0xC
	public List<int> ADKDHKMPMHP_Rate; // 0x10
	public List<int> DOOGFEGEKLG_Max; // 0x14

	// RVA: 0xCB2388 Offset: 0xCB2388 VA: 0xCB2388
	public OPGDJANLKBM_RateInfo()
	{
		HMFFHLPNMPH_Cnt = new List<int>(20);
		for(int i = 0; i < 20; i++)
		{
			HMFFHLPNMPH_Cnt.Add(0);
		}
		ADKDHKMPMHP_Rate = new List<int>(20);
		for (int i = 0; i < 20; i++)
		{
			ADKDHKMPMHP_Rate.Add(0);
		}
		DOOGFEGEKLG_Max = new List<int>(20);
		for (int i = 0; i < 20; i++)
		{
			DOOGFEGEKLG_Max.Add(0);
		}
	}

	// RVA: 0xCB2554 Offset: 0xCB2554 VA: 0xCB2554
	//public uint CAOGDCBPBAN() { }

	// RVA: 0xCB2664 Offset: 0xCB2664 VA: 0xCB2664
	public void ODDIHGPONFL(OPGDJANLKBM_RateInfo GPBJHKLFCEP)
	{
		BFOLFCOBBJD_RId = GPBJHKLFCEP.BFOLFCOBBJD_RId;
		for(int i = 0; i < 20; i++)
		{
			ADKDHKMPMHP_Rate[i] = GPBJHKLFCEP.ADKDHKMPMHP_Rate[i];
			DOOGFEGEKLG_Max[i] = GPBJHKLFCEP.DOOGFEGEKLG_Max[i];
			HMFFHLPNMPH_Cnt[i] = GPBJHKLFCEP.HMFFHLPNMPH_Cnt[i];
		}
	}
}
