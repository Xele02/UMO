
public class JHLCEOOMFLN
{
	private const int NDNOHAEBIFB = 9;

	//// RVA: 0x13498E8 Offset: 0x13498E8 VA: 0x13498E8
	//public static bool KLLKOOBKHHD() { }

	// RVA: 0x1349B78 Offset: 0x1349B78 VA: 0x1349B78
	public static bool NAMDJCPDJDD()
	{
		if(IMMAOANGPNK.HHCJCDFCLOB != null && CIOECGOMILE.HHCJCDFCLOB != null)
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("rareup_item_forced_convert_count", 120)
				<= EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 9, null);
		}
		return false;
	}

	//// RVA: 0x1349DA8 Offset: 0x1349DA8 VA: 0x1349DA8
	public static void PBKLIKNOMEG()
	{
		if(IMMAOANGPNK.HHCJCDFCLOB != null && CIOECGOMILE.HHCJCDFCLOB != null)
		{
			int cnt = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 9, null);
			int fullId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 9);
			int rareup_item_convert_count = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("rareup_item_convert_count", 100);
			if(rareup_item_convert_count <= cnt)
			{
				int part = cnt / rareup_item_convert_count;
				int mod = cnt % rareup_item_convert_count;
				string str = string.Concat(new object[8]
				{
					"UseItemId => ", fullId, " : BeforeItemCount => ", cnt, " : UseItemCount => ",
					part * rareup_item_convert_count, " : AfterItemCount => ", mod
				});
				CIOECGOMILE.HHCJCDFCLOB.JANMJPOKLFL.JCHLONCMPAJ();
				CIOECGOMILE.HHCJCDFCLOB.JANMJPOKLFL.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.LLMGBJKCBHI_40, str);
				CIOECGOMILE.HHCJCDFCLOB.JANMJPOKLFL.CPIICACGNBH(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.FKGCBLHOOCL_Category.CIOGEKJNMBB_RareUpItem, 1, part, null, 0);
				EKLNMHFCAOI.DPHGFMEPOCA_SetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 9, mod, null);
			}
		}
	}
}
