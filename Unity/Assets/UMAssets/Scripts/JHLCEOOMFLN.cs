
public class JHLCEOOMFLN
{
	private const int NDNOHAEBIFB = 9;

	//// RVA: 0x13498E8 Offset: 0x13498E8 VA: 0x13498E8
	//public static bool KLLKOOBKHHD() { }

	// RVA: 0x1349B78 Offset: 0x1349B78 VA: 0x1349B78
	public static bool NAMDJCPDJDD()
	{
		if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance != null && CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance != null)
		{
			return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("rareup_item_forced_convert_count", 120)
				<= EKLNMHFCAOI_ItemManager.ALHCGDMEMID_GetNumItems(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 9, null);
		}
		return false;
	}

	//// RVA: 0x1349DA8 Offset: 0x1349DA8 VA: 0x1349DA8
	public static void PBKLIKNOMEG()
	{
		if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance != null && CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance != null)
		{
			int cnt = EKLNMHFCAOI_ItemManager.ALHCGDMEMID_GetNumItems(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 9, null);
			int fullId = EKLNMHFCAOI_ItemManager.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 9);
			int rareup_item_convert_count = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("rareup_item_convert_count", 100);
			if(rareup_item_convert_count <= cnt)
			{
				int part = cnt / rareup_item_convert_count;
				int mod = cnt % rareup_item_convert_count;
				string str = string.Concat(new object[8]
				{
					"UseItemId => ", fullId, " : BeforeItemCount => ", cnt, " : UseItemCount => ",
					part * rareup_item_convert_count, " : AfterItemCount => ", mod
				});
				CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ_Clear();
				CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH_InventoryAddType.LLMGBJKCBHI_40_RareUpAutoConversion, str);
				CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.JANMJPOKLFL_InventoryUtil.CPIICACGNBH_AddItem(CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.CIOGEKJNMBB_RareUpItem, 1, part, null, 0);
				EKLNMHFCAOI_ItemManager.DPHGFMEPOCA_SetNumItems(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 9, mod, null);
			}
		}
	}
}
