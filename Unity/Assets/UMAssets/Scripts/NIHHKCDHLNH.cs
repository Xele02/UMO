
using System.Collections.Generic;
using System.Text;
using XeSys;

public class NIHHKCDHLNH
{
	public int FBGGEFFJJHB_xor; // 0x8
	public string OPFGFINHFCE_name; // 0xC
	public string KLMPFGOCBHC_description; // 0x10
	public string KHLMJCJAOCC_DescShort; // 0x14
	public int HLMAFFLCCKD_CountCrypted; // 0x18
	public int BOJAGEIAMMA; // 0x1C
	public int OKPOKEIGAPH; // 0x20
	public int IKNHMPPGMNJ_IdCrypted; // 0x24
	public int PNPLHCKGKIL_ItemFullIdCrypted; // 0x28

	public int HMFFHLPNMPH_Count { get { return HLMAFFLCCKD_CountCrypted ^ FBGGEFFJJHB_xor; } set { HLMAFFLCCKD_CountCrypted = value ^ FBGGEFFJJHB_xor; } } //0x18A0634 NJOGDDPICKG 0x18A0644 NBBGMMBICNA
	public int GLBEAENLHKC_Count { get { return BOJAGEIAMMA ^ FBGGEFFJJHB_xor; } set { BOJAGEIAMMA = value ^ FBGGEFFJJHB_xor; } } //0x18A0654 NOAKFOIOJBH 0x18A0664 PBGBHOBHBMG
	public int IILKAJBHLMJ_Value { get { return OKPOKEIGAPH ^ FBGGEFFJJHB_xor; } set { OKPOKEIGAPH = value ^ FBGGEFFJJHB_xor; } } //0x18A0674 LIHGICFGMBF 0x18A0684 ECBDNGPJMOD
	public int PBPOLELIPJI_Id { get { return IKNHMPPGMNJ_IdCrypted ^ FBGGEFFJJHB_xor; } set { IKNHMPPGMNJ_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x18A0694 AJNJOPJNMHL 0x18A06A4 NHLEGIJDHAF
	public int INFIBMLIHLO_ItemId { get { return PNPLHCKGKIL_ItemFullIdCrypted ^ FBGGEFFJJHB_xor; } set { PNPLHCKGKIL_ItemFullIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x18A06B4 CFPCGHEIEBE 0x18A06C4 OGJHBBKDFBL

	// RVA: 0x18A06D4 Offset: 0x18A06D4 VA: 0x18A06D4
	public NIHHKCDHLNH()
    {
        FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA();
        INFIBMLIHLO_ItemId = 0;
        HMFFHLPNMPH_Count = 0;
        GLBEAENLHKC_Count = 0;
        IILKAJBHLMJ_Value = 0;
        PBPOLELIPJI_Id = 0;
    }

	// // RVA: 0x18A0774 Offset: 0x18A0774 VA: 0x18A0774
	public void KHEKNNFCAOI_Init(int _MHFBCINOJEE_Num)
    {
        PLPBJOFICEJ_CosItem.IBEMFIAFIKH_ItemInfo item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GOGFKAECFIP_CosItem.EEOADCECNOM_GetItemById(_MHFBCINOJEE_Num);
        EGOLBAPFHHD_Common.PGENIOHDCDI saveItem = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.EFBKCNNFIPJ(_MHFBCINOJEE_Num);
        MessageBank bk = MessageManager.Instance.GetBank("master");
        StringBuilder str = new StringBuilder(32);
        str.SetFormat("cs_i_nm_{0:D4}", _MHFBCINOJEE_Num);
        OPFGFINHFCE_name = bk.GetMessageByLabel(str.ToString());
        str.SetFormat("cs_i_dsc_{0:D4}", _MHFBCINOJEE_Num);
        KLMPFGOCBHC_description = bk.GetMessageByLabel(str.ToString());
        str.SetFormat("cs_i_dsc_short_{0:D4}", _MHFBCINOJEE_Num);
        KHLMJCJAOCC_DescShort = bk.GetMessageByLabel(str.ToString());
        HMFFHLPNMPH_Count = saveItem.BFINGCJHOHI_Count;
        GLBEAENLHKC_Count = 9999;
        IILKAJBHLMJ_Value = item.JBGEEPFKIGG_Value;
        PBPOLELIPJI_Id = _MHFBCINOJEE_Num;
        INFIBMLIHLO_ItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.NEIIGCODGBA_CostumeItem, _MHFBCINOJEE_Num);
    }

	// RVA: 0x18A0B94 Offset: 0x18A0B94 VA: 0x18A0B94
	public static List<NIHHKCDHLNH> FKDIMODKKJD(int _AHHJLDLAPAN_DivaId)
    {
        int cnt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GOGFKAECFIP_CosItem.MIGONIENGBF_GetItemsCount();;
        List<NIHHKCDHLNH> res = new List<NIHHKCDHLNH>(cnt);
        for(int i = 0; i < cnt; i++)
        {
            PLPBJOFICEJ_CosItem.IBEMFIAFIKH_ItemInfo item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GOGFKAECFIP_CosItem.LOOANCFLPMP_GetItemByIdx(i);
            if(item.FDBOPFEOENF_Diva == 0)
            {
                if(item.INDDJNMPONH_Type == 1)
                {
                    NIHHKCDHLNH data = new NIHHKCDHLNH();
                    data.KHEKNNFCAOI_Init(item.PPFNGGCBJKC_id);
                    res.Add(data);
                }
            }
        }
        return res;
    }

	// // RVA: 0x18A0DD4 Offset: 0x18A0DD4 VA: 0x18A0DD4
	public static string EJOJNFDHDHN(int _MHFBCINOJEE_Num)
    {
        MessageBank bk = MessageManager.Instance.GetBank("master");
        StringBuilder str = new StringBuilder(32);
        str.SetFormat("cs_i_nm_{0:D4}", _MHFBCINOJEE_Num);
        return bk.GetMessageByLabel(str.ToString());
    }
}
