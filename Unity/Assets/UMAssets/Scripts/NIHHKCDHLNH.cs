
using System.Collections.Generic;
using System.Text;
using XeSys;

public class NIHHKCDHLNH
{
	public int FBGGEFFJJHB; // 0x8
	public string OPFGFINHFCE_Name; // 0xC
	public string KLMPFGOCBHC_Desc; // 0x10
	public string KHLMJCJAOCC_DescShort; // 0x14
	public int HLMAFFLCCKD_CntCrypted; // 0x18
	public int BOJAGEIAMMA; // 0x1C
	public int OKPOKEIGAPH; // 0x20
	public int IKNHMPPGMNJ_IdCrypted; // 0x24
	public int PNPLHCKGKIL_ItemFullIdCrypted; // 0x28

	public int HMFFHLPNMPH_Cnt { get { return HLMAFFLCCKD_CntCrypted ^ FBGGEFFJJHB; } set { HLMAFFLCCKD_CntCrypted = value ^ FBGGEFFJJHB; } } //0x18A0634 NJOGDDPICKG 0x18A0644 NBBGMMBICNA
	public int GLBEAENLHKC { get { return BOJAGEIAMMA ^ FBGGEFFJJHB; } set { BOJAGEIAMMA = value ^ FBGGEFFJJHB; } } //0x18A0654 NOAKFOIOJBH 0x18A0664 PBGBHOBHBMG
	public int IILKAJBHLMJ_ItemPointValue { get { return OKPOKEIGAPH ^ FBGGEFFJJHB; } set { OKPOKEIGAPH = value ^ FBGGEFFJJHB; } } //0x18A0674 LIHGICFGMBF 0x18A0684 ECBDNGPJMOD
	public int PBPOLELIPJI_Id { get { return IKNHMPPGMNJ_IdCrypted ^ FBGGEFFJJHB; } set { IKNHMPPGMNJ_IdCrypted = value ^ FBGGEFFJJHB; } } //0x18A0694 AJNJOPJNMHL 0x18A06A4 NHLEGIJDHAF
	public int INFIBMLIHLO_ItemFullId { get { return PNPLHCKGKIL_ItemFullIdCrypted ^ FBGGEFFJJHB; } set { PNPLHCKGKIL_ItemFullIdCrypted = value ^ FBGGEFFJJHB; } } //0x18A06B4 CFPCGHEIEBE 0x18A06C4 OGJHBBKDFBL

	// RVA: 0x18A06D4 Offset: 0x18A06D4 VA: 0x18A06D4
	public NIHHKCDHLNH()
    {
        FBGGEFFJJHB = LPDNKHAIOLH.CEIBAFOCNCA();
        INFIBMLIHLO_ItemFullId = 0;
        HMFFHLPNMPH_Cnt = 0;
        GLBEAENLHKC = 0;
        IILKAJBHLMJ_ItemPointValue = 0;
        PBPOLELIPJI_Id = 0;
    }

	// // RVA: 0x18A0774 Offset: 0x18A0774 VA: 0x18A0774
	public void KHEKNNFCAOI(int MHFBCINOJEE)
    {
        PLPBJOFICEJ_CosItem.IBEMFIAFIKH_ItemInfo item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GOGFKAECFIP_CosItem.EEOADCECNOM_GetItemById(MHFBCINOJEE);
        EGOLBAPFHHD_Common.PGENIOHDCDI saveItem = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.EFBKCNNFIPJ(MHFBCINOJEE);
        MessageBank bk = MessageManager.Instance.GetBank("master");
        StringBuilder str = new StringBuilder(32);
        str.SetFormat("cs_i_nm_{0:D4}", MHFBCINOJEE);
        OPFGFINHFCE_Name = bk.GetMessageByLabel(str.ToString());
        str.SetFormat("cs_i_dsc_{0:D4}", MHFBCINOJEE);
        KLMPFGOCBHC_Desc = bk.GetMessageByLabel(str.ToString());
        str.SetFormat("cs_i_dsc_short_{0:D4}", MHFBCINOJEE);
        KHLMJCJAOCC_DescShort = bk.GetMessageByLabel(str.ToString());
        HMFFHLPNMPH_Cnt = saveItem.BFINGCJHOHI_Cnt;
        GLBEAENLHKC = 9999;
        IILKAJBHLMJ_ItemPointValue = item.JBGEEPFKIGG_PointValue;
        PBPOLELIPJI_Id = MHFBCINOJEE;
        INFIBMLIHLO_ItemFullId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.NEIIGCODGBA_CostumeItem, MHFBCINOJEE);
    }

	// RVA: 0x18A0B94 Offset: 0x18A0B94 VA: 0x18A0B94
	public static List<NIHHKCDHLNH> FKDIMODKKJD(int AHHJLDLAPAN)
    {
        int cnt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GOGFKAECFIP_CosItem.MIGONIENGBF_GetItemsCount();;
        List<NIHHKCDHLNH> res = new List<NIHHKCDHLNH>(cnt);
        for(int i = 0; i < cnt; i++)
        {
            PLPBJOFICEJ_CosItem.IBEMFIAFIKH_ItemInfo item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GOGFKAECFIP_CosItem.LOOANCFLPMP_GetItemByIdx(i);
            if(item.FDBOPFEOENF == 0)
            {
                if(item.INDDJNMPONH_Category == 1)
                {
                    NIHHKCDHLNH data = new NIHHKCDHLNH();
                    data.KHEKNNFCAOI(item.PPFNGGCBJKC_Id);
                    res.Add(data);
                }
            }
        }
        return res;
    }

	// // RVA: 0x18A0DD4 Offset: 0x18A0DD4 VA: 0x18A0DD4
	public static string EJOJNFDHDHN(int MHFBCINOJEE)
    {
        MessageBank bk = MessageManager.Instance.GetBank("master");
        StringBuilder str = new StringBuilder(32);
        str.SetFormat("cs_i_nm_{0:D4}", MHFBCINOJEE);
        return bk.GetMessageByLabel(str.ToString());
    }
}
