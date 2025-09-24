
using System.Collections.Generic;
using XeSys;

public class EEDBNJAEKBI
{
	public string OPFGFINHFCE_name; // 0x8
	public string KLMPFGOCBHC_description; // 0xC
	public int HMFFHLPNMPH_count; // 0x10
	public int GLBEAENLHKC_Count; // 0x14 MaxLimit
	public int IILKAJBHLMJ_Value; // 0x18
	public int INFIBMLIHLO_ItemId; // 0x1C

	//// RVA: 0x1C481E0 Offset: 0x1C481E0 VA: 0x1C481E0
	public void KHEKNNFCAOI_Init(int _MHFBCINOJEE_Num)
	{
		KIICLPJJBNL_EpiItem.NKGPGMOHAFM epi = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NEGGMILDEEF_EpiItem.CDENCMNHNGA_table[_MHFBCINOJEE_Num - 1];
		EGOLBAPFHHD_Common.AMCANGCIBEG saveEpi = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.GJODJNIHKKF_epi_item[_MHFBCINOJEE_Num - 1];
		MessageBank bk = MessageManager.Instance.GetBank("master");
		OPFGFINHFCE_name = bk.GetMessageByLabel("ep_i_nm_" + _MHFBCINOJEE_Num.ToString("D4"));
		KLMPFGOCBHC_description = bk.GetMessageByLabel("ep_i_dsc_" + _MHFBCINOJEE_Num.ToString("D4"));
		HMFFHLPNMPH_count = saveEpi.BFINGCJHOHI_cnt;
		GLBEAENLHKC_Count = 9999;
		IILKAJBHLMJ_Value = epi.JBGEEPFKIGG_val;
		INFIBMLIHLO_ItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.MEDAKGBKIMO_EpisodeItem, _MHFBCINOJEE_Num);
	}

	//// RVA: 0x1C48554 Offset: 0x1C48554 VA: 0x1C48554
	public static List<EEDBNJAEKBI> FKDIMODKKJD()
	{
		List<KIICLPJJBNL_EpiItem.NKGPGMOHAFM> epiList = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NEGGMILDEEF_EpiItem.CDENCMNHNGA_table;
		List<EEDBNJAEKBI> res = new List<EEDBNJAEKBI>();
		for(int i = 0; i < epiList.Count; i++)
		{
			EEDBNJAEKBI data = new EEDBNJAEKBI();
			data.KHEKNNFCAOI_Init(epiList[i].PPFNGGCBJKC_id);
			res.Add(data);
		}
		return res;
	}
}
