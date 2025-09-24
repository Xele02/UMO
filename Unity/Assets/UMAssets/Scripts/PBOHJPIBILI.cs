
using UnityEngine;
using XeApp.Game.Menu;

public class PBOHJPIBILI
{
	public const int IBNJHOIDKLH = 100;

	// // RVA: 0xCBD7E8 Offset: 0xCBD7E8 VA: 0xCBD7E8
	public static int PFNBNKCPFLP_GetCannonStockMax()
    {
        return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA_GetIntParam("mcannon_stock_max", 1);
    }

	// RVA: 0xCBD8D8 Offset: 0xCBD8D8 VA: 0xCBD8D8
	public static void GLEPHGKFFLL(out int GGNOGNOBJLP_CurrentStock, out int HLANCDFJFIA_CurrentGauge, out bool ANKEMCJFFIO_IsMax)
    {
        GGNOGNOBJLP_CurrentStock = 0;
        HLANCDFJFIA_CurrentGauge = 0;
        ANKEMCJFFIO_IsMax = false;
        GGNOGNOBJLP_CurrentStock = Mathf.Min(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.IKLFJPAGHJG_McGauge / 100, PFNBNKCPFLP_GetCannonStockMax());
        HLANCDFJFIA_CurrentGauge = GGNOGNOBJLP_CurrentStock * -100 + CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.IKLFJPAGHJG_McGauge;
        ANKEMCJFFIO_IsMax = 99 < HLANCDFJFIA_CurrentGauge && PFNBNKCPFLP_GetCannonStockMax() <= GGNOGNOBJLP_CurrentStock;
    }

	// // RVA: 0xCBDA5C Offset: 0xCBDA5C VA: 0xCBDA5C
	public static int JMJOBHFFBGC_GetMcGauge()
    {
        return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.IKLFJPAGHJG_McGauge;
    }

	// // RVA: 0xCBDB38 Offset: 0xCBDB38 VA: 0xCBDB38
	public static void PGAGKCDGOIN_AddMcGauge(int _OEOIHIIIMCK_add)
    {
        CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.IKLFJPAGHJG_McGauge = Mathf.Min(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.IKLFJPAGHJG_McGauge + _OEOIHIIIMCK_add, PBOHJPIBILI.PFNBNKCPFLP_GetCannonStockMax() * 100 + 100);
    }

	// // RVA: 0xCBDC90 Offset: 0xCBDC90 VA: 0xCBDC90
	public static bool EFOHKCAOFFE_IsMcGaugeMax(bool _DDGFCOPPBBN_test/* = True*/)
    {
        int cnt = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.IKLFJPAGHJG_McGauge;
        if(cnt > 99)
        {
            if(!_DDGFCOPPBBN_test)
            {
                CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.IKLFJPAGHJG_McGauge -= 100;
            }
            return true;
        }
        return false;
    }

	// // RVA: 0xCBDDE0 Offset: 0xCBDDE0 VA: 0xCBDDE0
	public static int DIDALOAJHBE(int _KIJAPOFAGPN_ItemId)
    {
        if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(_KIJAPOFAGPN_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem)
        {
            if(EKLNMHFCAOI.DEACAHNLMNI_getItemId(_KIJAPOFAGPN_ItemId) == 6)
            {
                return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA_GetIntParam("mcannon_gauge_item_value", 100);
            }
        }
        return 0;
    }

	// // RVA: 0xCBDF5C Offset: 0xCBDF5C VA: 0xCBDF5C
	public static int GJPMPGIIPHA(int _KIJAPOFAGPN_ItemId)
    {
        if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(_KIJAPOFAGPN_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem)
        {
            if(EKLNMHFCAOI.DEACAHNLMNI_getItemId(_KIJAPOFAGPN_ItemId) == 6)
            {
                return EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 6, null);
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
            if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PFAKPFKJJKA(true) == null)
            {
                int newNum = Mathf.Max(0, num - 1);
                EKLNMHFCAOI.DPHGFMEPOCA_SetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, 
                    EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(_KIJAPOFAGPN_ItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(_KIJAPOFAGPN_ItemId), newNum, null);
                JMJOBHFFBGC_GetMcGauge();
                int a = DIDALOAJHBE(_KIJAPOFAGPN_ItemId);
                PGAGKCDGOIN_AddMcGauge(a);
                JDDGPJDKHNE.HHCJCDFCLOB.NFNLGGHMEAM();
                JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = true;
                ILCCJNDFFOB.HHCJCDFCLOB.MINOEGPNBIH(a, JMJOBHFFBGC_GetMcGauge(), _KIJAPOFAGPN_ItemId, newNum, "StringLiteral_13052", "");
            }
            MenuScene.SaveWithAchievement(0, () =>
            {
                //0xCBE540
                JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
                _BHFHGFKBOHH_OnSuccess();
            }, null);
            return 1;
        }
        return num;
    }
}
