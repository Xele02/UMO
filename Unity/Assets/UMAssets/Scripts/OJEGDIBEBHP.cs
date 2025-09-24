using System.Collections.Generic;
using XeSys;

public class OJEGDIBEBHP
{
	public int ADJBIEOILPJ_ItemPresentId; // 0x8
	public int PNJICDLDCAE; // 0xC
	public string OPFGFINHFCE_name = ""; // 0x10
	public int JONPKLHMOBL_Category; // 0x14
	public int KIJAPOFAGPN_ItemId; // 0x18
	public int GLHBKPNFLOP_Count; // 0x1C
	public int BMBACIHEICJ; // 0x20

	//// RVA: 0x148C24C Offset: 0x148C24C VA: 0x148C24C
	public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id)
	{
		if(_PPFNGGCBJKC_id > 0)
		{
			GJALOMELEHD_Intimacy.ELAIMNHBCFB db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.CJAEGOMDICD[_PPFNGGCBJKC_id - 1];
			EGOLBAPFHHD_Common.DEEGPPKGGLK save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.DHJFHILPKLB_IntimacyPresent[_PPFNGGCBJKC_id - 1];
			ADJBIEOILPJ_ItemPresentId = _PPFNGGCBJKC_id;
			PNJICDLDCAE = db.JBGEEPFKIGG_val;
			OPFGFINHFCE_name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(EKLNMHFCAOI.FKGCBLHOOCL_Category.DLBHNNOHLMM_PresentItem, _PPFNGGCBJKC_id);
			JONPKLHMOBL_Category = db.JONPKLHMOBL_Category;
			KIJAPOFAGPN_ItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.DLBHNNOHLMM_PresentItem, _PPFNGGCBJKC_id);
			GLHBKPNFLOP_Count = save.BFINGCJHOHI_cnt;
			BMBACIHEICJ = db.JKFLOJNPLIJ;
		}
	}

	//// RVA: 0x148C500 Offset: 0x148C500 VA: 0x148C500
	//public bool FBANBDCOEJL() { }

	//// RVA: 0x148C700 Offset: 0x148C700 VA: 0x148C700
	public bool MCLFHOABKGP(int _AHHJLDLAPAN_DivaId)
	{
		if(_AHHJLDLAPAN_DivaId > 0)
		{
			return (BMBACIHEICJ & (1 << _AHHJLDLAPAN_DivaId - 1)) != 0;
		}
		return false;
	}

	//// RVA: 0x148C72C Offset: 0x148C72C VA: 0x148C72C
	public static List<OJEGDIBEBHP> FKDIMODKKJD()
	{
		List<OJEGDIBEBHP> res = new List<OJEGDIBEBHP>();
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
			{
				int num = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.CJAEGOMDICD.Count;
				int num2 = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.DHJFHILPKLB_IntimacyPresent.Count;
				if (num2 < num)
					num = num2;
				for(int i = 0; i < num; i++)
				{
					OJEGDIBEBHP data = new OJEGDIBEBHP();
					data.KHEKNNFCAOI_Init(i + 1);
					if(data.GLHBKPNFLOP_Count > 0)
					{
						res.Add(data);
					}
				}
				res.Sort((OJEGDIBEBHP _HKICMNAACDA_a, OJEGDIBEBHP _BNKHBCBJBKI_b) =>
				{
					//0x148CF24
					int r = _HKICMNAACDA_a.JONPKLHMOBL_Category.CompareTo(_BNKHBCBJBKI_b.JONPKLHMOBL_Category);
					if(r == 0)
					{
						r = _HKICMNAACDA_a.PNJICDLDCAE.CompareTo(_BNKHBCBJBKI_b.PNJICDLDCAE);
						if(r == 0)
							r = _HKICMNAACDA_a.KIJAPOFAGPN_ItemId.CompareTo(_BNKHBCBJBKI_b.KIJAPOFAGPN_ItemId);
					}
					return r;
				});
			}
		}
		return res;
	}

	//// RVA: 0x148CB50 Offset: 0x148CB50 VA: 0x148CB50
	public static string DDICENAFJDP_GetName(int _ADJBIEOILPJ_ItemPresentId)
	{
		return MessageManager.Instance.GetMessage("master", "itp_nm_"+_ADJBIEOILPJ_ItemPresentId.ToString("D4"));
	}

	//// RVA: 0x148CC28 Offset: 0x148CC28 VA: 0x148CC28
	public static string LJKBBAGJLFP_GetDesc(int _ADJBIEOILPJ_ItemPresentId)
	{
		return MessageManager.Instance.GetMessage("master", "itp_dsc_" + _ADJBIEOILPJ_ItemPresentId.ToString("D4"));
	}

	//// RVA: 0x148CD00 Offset: 0x148CD00 VA: 0x148CD00
	public static string MPKLLGIOBIP_GetDesc2(int _ADJBIEOILPJ_ItemPresentId)
	{
		return MessageManager.Instance.GetMessage("master", "itp_dsc2_" + _ADJBIEOILPJ_ItemPresentId.ToString("D4"));
	}

	//// RVA: 0x148CDD8 Offset: 0x148CDD8 VA: 0x148CDD8
	//public static void HCDGELDHFHB(List<OJEGDIBEBHP> NNDGIAEFMOG) { }
}
