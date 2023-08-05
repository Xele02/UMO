
using System.Collections.Generic;
using XeSys;

public class EEDBNJAEKBI
{
	public string OPFGFINHFCE_Name; // 0x8
	public string KLMPFGOCBHC_Desc; // 0xC
	public int HMFFHLPNMPH_Count; // 0x10
	public int GLBEAENLHKC; // 0x14
	public int IILKAJBHLMJ_Value; // 0x18
	public int INFIBMLIHLO_ItemFullId; // 0x1C

	//// RVA: 0x1C481E0 Offset: 0x1C481E0 VA: 0x1C481E0
	public void KHEKNNFCAOI(int MHFBCINOJEE)
	{
		KIICLPJJBNL_EpiItem.NKGPGMOHAFM epi = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NEGGMILDEEF_EpiItem.CDENCMNHNGA[MHFBCINOJEE - 1];
		EGOLBAPFHHD_Common.AMCANGCIBEG saveEpi = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.GJODJNIHKKF_EpiItem[MHFBCINOJEE - 1];
		MessageBank bk = MessageManager.Instance.GetBank("master");
		OPFGFINHFCE_Name = bk.GetMessageByLabel("ep_i_nm_" + MHFBCINOJEE.ToString("D4"));
		KLMPFGOCBHC_Desc = bk.GetMessageByLabel("ep_i_dsc_" + MHFBCINOJEE.ToString("D4"));
		HMFFHLPNMPH_Count = saveEpi.BFINGCJHOHI_Cnt;
		GLBEAENLHKC = 9999;
		IILKAJBHLMJ_Value = epi.JBGEEPFKIGG_Value;
		INFIBMLIHLO_ItemFullId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.MEDAKGBKIMO_EpisodeItem, MHFBCINOJEE);
	}

	//// RVA: 0x1C48554 Offset: 0x1C48554 VA: 0x1C48554
	public static List<EEDBNJAEKBI> FKDIMODKKJD()
	{
		List<KIICLPJJBNL_EpiItem.NKGPGMOHAFM> epiList = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NEGGMILDEEF_EpiItem.CDENCMNHNGA;
		List<EEDBNJAEKBI> res = new List<EEDBNJAEKBI>();
		for(int i = 0; i < epiList.Count; i++)
		{
			EEDBNJAEKBI data = new EEDBNJAEKBI();
			data.KHEKNNFCAOI(epiList[i].PPFNGGCBJKC_Id);
			res.Add(data);
		}
		return res;
	}
}
