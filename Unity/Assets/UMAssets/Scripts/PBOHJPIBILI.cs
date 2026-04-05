
using UnityEngine;
using XeApp.Game.Menu;

public class PBOHJPIBILI
{
	public const int IBNJHOIDKLH = 100;

	// // RVA: 0xCBD7E8 Offset: 0xCBD7E8 VA: 0xCBD7E8
	public static int PFNBNKCPFLP_GetCannonStockMax()
    {
        return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA_GetIntParam("mcannon_stock_max", 1);
    }

	// RVA: 0xCBD8D8 Offset: 0xCBD8D8 VA: 0xCBD8D8
	public static void GLEPHGKFFLL(out int _GGNOGNOBJLP_CurrentStock, out int _HLANCDFJFIA_CurrentGauge, out bool ANKEMCJFFIO_IsMax)
    {
        _GGNOGNOBJLP_CurrentStock = 0;
        _HLANCDFJFIA_CurrentGauge = 0;
        ANKEMCJFFIO_IsMax = false;
        _GGNOGNOBJLP_CurrentStock = Mathf.Min(CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.IKLFJPAGHJG_McGauge / 100, PFNBNKCPFLP_GetCannonStockMax());
        _HLANCDFJFIA_CurrentGauge = _GGNOGNOBJLP_CurrentStock * -100 + CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.IKLFJPAGHJG_McGauge;
        ANKEMCJFFIO_IsMax = 99 < _HLANCDFJFIA_CurrentGauge && PFNBNKCPFLP_GetCannonStockMax() <= _GGNOGNOBJLP_CurrentStock;
    }

	// // RVA: 0xCBDA5C Offset: 0xCBDA5C VA: 0xCBDA5C
	public static int JMJOBHFFBGC_GetMcGauge()
    {
        return CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.IKLFJPAGHJG_McGauge;
    }

	// // RVA: 0xCBDB38 Offset: 0xCBDB38 VA: 0xCBDB38
	public static void PGAGKCDGOIN_AddMcGauge(int _OEOIHIIIMCK_add)
    {
        CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.IKLFJPAGHJG_McGauge = Mathf.Min(CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.IKLFJPAGHJG_McGauge + _OEOIHIIIMCK_add, PBOHJPIBILI.PFNBNKCPFLP_GetCannonStockMax() * 100 + 100);
    }

	// // RVA: 0xCBDC90 Offset: 0xCBDC90 VA: 0xCBDC90
	public static bool EFOHKCAOFFE_IsMcGaugeMax(bool _DDGFCOPPBBN_test/* = True*/)
    {
        int cnt = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.IKLFJPAGHJG_McGauge;
        if(cnt > 99)
        {
            if(!_DDGFCOPPBBN_test)
            {
                CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.IKLFJPAGHJG_McGauge -= 100;
            }
            return true;
        }
        return false;
    }

	// // RVA: 0xCBDDE0 Offset: 0xCBDDE0 VA: 0xCBDDE0
	public static int DIDALOAJHBE(int _KIJAPOFAGPN_ItemId)
    {
        if(EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(_KIJAPOFAGPN_ItemId) == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem)
        {
            if(EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(_KIJAPOFAGPN_ItemId) == 6)
            {
                return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA_GetIntParam("mcannon_gauge_item_value", 100);
            }
        }
        return 0;
    }

	// // RVA: 0xCBDF5C Offset: 0xCBDF5C VA: 0xCBDF5C
	public static int GJPMPGIIPHA(int _KIJAPOFAGPN_ItemId)
    {
        if(EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(_KIJAPOFAGPN_ItemId) == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem)
        {
            if(EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(_KIJAPOFAGPN_ItemId) == 6)
            {
                return EKLNMHFCAOI_ItemManager.ALHCGDMEMID_GetNumItems(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 6, null);
            }
        }
        return -1;
    }

	// // RVA: 0xCBE138 Offset: 0xCBE138 VA: 0xCBE138
	public static int BPAOMGFCODD(int _KIJAPOFAGPN_ItemId, IMCBBOAFION _BHFHGFKBOHH_OnSuccess)
    {
        int num = GJPMPGIIPHA(_KIJAPOFAGPN_ItemId);
        if(num > 0)
        {
            if(CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.PFAKPFKJJKA(true) == null)
            {
                int newNum = Mathf.Max(0, num - 1);
                EKLNMHFCAOI_ItemManager.DPHGFMEPOCA_SetNumItems(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, 
                    EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(_KIJAPOFAGPN_ItemId), EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(_KIJAPOFAGPN_ItemId), newNum, null);
                JMJOBHFFBGC_GetMcGauge();
                int a = DIDALOAJHBE(_KIJAPOFAGPN_ItemId);
                PGAGKCDGOIN_AddMcGauge(a);
                JDDGPJDKHNE.HHCJCDFCLOB_Instance.NFNLGGHMEAM();
                JDDGPJDKHNE.HHCJCDFCLOB_Instance.FCMCNIMEAEA = true;
                ILCCJNDFFOB.HHCJCDFCLOB_Instance.MINOEGPNBIH_McCharge(a, JMJOBHFFBGC_GetMcGauge(), _KIJAPOFAGPN_ItemId, newNum, "StringLiteral_13052", "");
            }
            MenuScene.SaveWithAchievement(0, () =>
            {
                //0xCBE540
                JDDGPJDKHNE.HHCJCDFCLOB_Instance.FCMCNIMEAEA = false;
                _BHFHGFKBOHH_OnSuccess();
            }, null);
            return 1;
        }
        return num;
    }
}
