using System.Collections.Generic;
using XeSys;

public class OJEGDIBEBHP
{
	public int ADJBIEOILPJ_Id; // 0x8
	public int PNJICDLDCAE; // 0xC
	public string OPFGFINHFCE_Name = ""; // 0x10
	public int JONPKLHMOBL; // 0x14
	public int KIJAPOFAGPN_FullItemId; // 0x18
	public int GLHBKPNFLOP_Count; // 0x1C
	public int BMBACIHEICJ; // 0x20

	//// RVA: 0x148C24C Offset: 0x148C24C VA: 0x148C24C
	public void KHEKNNFCAOI(int PPFNGGCBJKC)
	{
		if(PPFNGGCBJKC > 0)
		{
			GJALOMELEHD_Intimacy.ELAIMNHBCFB db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.CJAEGOMDICD[PPFNGGCBJKC - 1];
			EGOLBAPFHHD_Common.DEEGPPKGGLK save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.DHJFHILPKLB_IntimacyPresent[PPFNGGCBJKC - 1];
			ADJBIEOILPJ_Id = PPFNGGCBJKC;
			PNJICDLDCAE = db.JBGEEPFKIGG;
			OPFGFINHFCE_Name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(EKLNMHFCAOI.FKGCBLHOOCL_Category.DLBHNNOHLMM_PresentItem, PPFNGGCBJKC);
			JONPKLHMOBL = db.JONPKLHMOBL;
			KIJAPOFAGPN_FullItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.DLBHNNOHLMM_PresentItem, PPFNGGCBJKC);
			GLHBKPNFLOP_Count = save.BFINGCJHOHI_Cnt;
			BMBACIHEICJ = db.JKFLOJNPLIJ;
		}
	}

	//// RVA: 0x148C500 Offset: 0x148C500 VA: 0x148C500
	//public bool FBANBDCOEJL() { }

	//// RVA: 0x148C700 Offset: 0x148C700 VA: 0x148C700
	public bool MCLFHOABKGP(int AHHJLDLAPAN)
	{
		if(AHHJLDLAPAN > 0)
		{
			return (BMBACIHEICJ & (1 << AHHJLDLAPAN - 1)) != 0;
		}
		return false;
	}

	//// RVA: 0x148C72C Offset: 0x148C72C VA: 0x148C72C
	public static List<OJEGDIBEBHP> FKDIMODKKJD()
	{
		List<OJEGDIBEBHP> res = new List<OJEGDIBEBHP>();
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
			{
				int num = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.CJAEGOMDICD.Count;
				int num2 = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.DHJFHILPKLB_IntimacyPresent.Count;
				if (num2 < num)
					num = num2;
				for(int i = 0; i < num; i++)
				{
					OJEGDIBEBHP data = new OJEGDIBEBHP();
					data.KHEKNNFCAOI(i + 1);
					if(data.GLHBKPNFLOP_Count > 0)
					{
						res.Add(data);
					}
				}
				res.Sort((OJEGDIBEBHP HKICMNAACDA, OJEGDIBEBHP BNKHBCBJBKI) =>
				{
					//0x148CF24
					int r = HKICMNAACDA.JONPKLHMOBL.CompareTo(BNKHBCBJBKI.JONPKLHMOBL);
					if(r == 0)
					{
						r = HKICMNAACDA.PNJICDLDCAE.CompareTo(BNKHBCBJBKI.PNJICDLDCAE);
						if(r == 0)
							r = HKICMNAACDA.KIJAPOFAGPN_FullItemId.CompareTo(BNKHBCBJBKI.KIJAPOFAGPN_FullItemId);
					}
					return r;
				});
			}
		}
		return res;
	}

	//// RVA: 0x148CB50 Offset: 0x148CB50 VA: 0x148CB50
	public static string DDICENAFJDP_GetName(int ADJBIEOILPJ)
	{
		return MessageManager.Instance.GetMessage("master", "itp_nm_"+ADJBIEOILPJ.ToString("D4"));
	}

	//// RVA: 0x148CC28 Offset: 0x148CC28 VA: 0x148CC28
	public static string LJKBBAGJLFP_GetDesc(int ADJBIEOILPJ)
	{
		return MessageManager.Instance.GetMessage("master", "itp_dsc_" + ADJBIEOILPJ.ToString("D4"));
	}

	//// RVA: 0x148CD00 Offset: 0x148CD00 VA: 0x148CD00
	public static string MPKLLGIOBIP_GetDesc2(int ADJBIEOILPJ)
	{
		return MessageManager.Instance.GetMessage("master", "itp_dsc2_" + ADJBIEOILPJ.ToString("D4"));
	}

	//// RVA: 0x148CDD8 Offset: 0x148CDD8 VA: 0x148CDD8
	//public static void HCDGELDHFHB(List<OJEGDIBEBHP> NNDGIAEFMOG) { }
}
