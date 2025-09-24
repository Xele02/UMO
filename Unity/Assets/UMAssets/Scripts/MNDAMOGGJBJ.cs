
using System.Collections.Generic;
using XeSys;

public class MNDAMOGGJBJ
{
	public struct JFJJNPJNBPI
	{
		public int PPFNGGCBJKC_id; // 0x0
		public int HMFFHLPNMPH_count; // 0x4

		//// RVA: 0x7FD6EC Offset: 0x7FD6EC VA: 0x7FD6EC
		public void MBFFGGFGPEN(int BBPHAPFBFHK, int HFJLPAOGLEH)
		{
			PPFNGGCBJKC_id = BBPHAPFBFHK;
			HMFFHLPNMPH_count = HFJLPAOGLEH;
		}
	}

	public enum MNDGNJLBANB
	{
		HJNNKCMLGFL_0_None = 0,
		EDBCFDJBFID_LackUC = 1,
		LNMPDFICAOM_LackItem = 2,
	}

	private EGOLBAPFHHD_Common KCCLEHLLOFG_Common; // 0x8
	public int FBGGEFFJJHB_xor; // 0xC
	private int NEGMNPCHENF; // 0x1C

	public List<JFJJNPJNBPI> MHGAOHAHFDN { get; set; } // 0x10 DJBDDFLFPLE PGKLOONAKPD GLBMFLPHJLB
	public int PGGKBIIJOND { get; set; } // 0x14 PKFNBLMOBCL MKBBJIKHFJD KMOMHPMBMNL
	public List<JFJJNPJNBPI> INLBMFMOHCI_CostItems { get; set; } // 0x18 PIDPINOOAPN KLLCKKLHEHH EBBKKLLCDMB
	public int CMBGGPOFBOO_UcCost { get { return NEGMNPCHENF ^ FBGGEFFJJHB_xor; } set { NEGMNPCHENF = value ^ FBGGEFFJJHB_xor; } } //0x17B00B0 PPKIKKIKGMK 0x17B00C0 HOGAFMDJKPK

	//// RVA: 0x17B00D0 Offset: 0x17B00D0 VA: 0x17B00D0
	public void KHEKNNFCAOI_Init(BBHNACPENDM_ServerSaveData _AHEFHIMGIBI_PlayerData)
	{
		FBGGEFFJJHB_xor = (int)(Utility.GetCurrentUnixTime() * 0x15573);
		if(_AHEFHIMGIBI_PlayerData == null)
		{
			_AHEFHIMGIBI_PlayerData = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData;
		}
		KCCLEHLLOFG_Common = _AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common;
		PGGKBIIJOND = 0;
		CMBGGPOFBOO_UcCost = 0;
		INLBMFMOHCI_CostItems = new List<JFJJNPJNBPI>();
		MHGAOHAHFDN = new List<JFJJNPJNBPI>();
		MDHKGJJBLNL();
	}

	//// RVA: 0x17B024C Offset: 0x17B024C VA: 0x17B024C
	public void MDHKGJJBLNL()
	{
		FBGGEFFJJHB_xor = (int)(Utility.GetCurrentUnixTime() * 0x15573);
		INLBMFMOHCI_CostItems.Clear();
		CMBGGPOFBOO_UcCost = 0;
	}

	//// RVA: 0x17B0310 Offset: 0x17B0310 VA: 0x17B0310
	public void JGAAANGEIFK()
	{
		MHGAOHAHFDN.Clear();
		MHGAOHAHFDN.AddRange(INLBMFMOHCI_CostItems);
		PGGKBIIJOND = CMBGGPOFBOO_UcCost;
	}

	//// RVA: 0x17B03CC Offset: 0x17B03CC VA: 0x17B03CC
	public int JPLMJPGDPAN(int _PPFNGGCBJKC_id)
	{
		if (_PPFNGGCBJKC_id != 0)
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null && IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
				return EKLNMHFCAOI.DLNFNHMPGLI_GetNumClamped(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(INLBMFMOHCI_CostItems[_PPFNGGCBJKC_id - 1].PPFNGGCBJKC_id), EKLNMHFCAOI.DEACAHNLMNI_getItemId(INLBMFMOHCI_CostItems[_PPFNGGCBJKC_id - 1].PPFNGGCBJKC_id), null);
		}
		return 0;
	}

	//// RVA: 0x17B059C Offset: 0x17B059C VA: 0x17B059C
	private int JBMLCIPKFDF_GetNumItemInInventory(int _PPFNGGCBJKC_id)
	{
		if (_PPFNGGCBJKC_id == 0)
			return 0;
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null && IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			return EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database,
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(INLBMFMOHCI_CostItems[_PPFNGGCBJKC_id - 1].PPFNGGCBJKC_id), EKLNMHFCAOI.DEACAHNLMNI_getItemId(INLBMFMOHCI_CostItems[_PPFNGGCBJKC_id - 1].PPFNGGCBJKC_id), null);
		}
		return 0;
	}

	//// RVA: 0x17B076C Offset: 0x17B076C VA: 0x17B076C
	private int CPBDJHKHEFN_GetNumItemLeftAfterUse(int _PPFNGGCBJKC_id)
	{
		return JBMLCIPKFDF_GetNumItemInInventory(_PPFNGGCBJKC_id) - INLBMFMOHCI_CostItems[_PPFNGGCBJKC_id - 1].HMFFHLPNMPH_count;
	}

	//// RVA: 0x17B0810 Offset: 0x17B0810 VA: 0x17B0810
	//public void IDKIMNBOBLA(int _PPFNGGCBJKC_id, int _JBGEEPFKIGG_val) { }

	//// RVA: 0x17B08EC Offset: 0x17B08EC VA: 0x17B08EC
	//public void MBBGCIFMOHC(int JBGJDEELLOP, int _JBGEEPFKIGG_val) { }

	//// RVA: 0x17B09CC Offset: 0x17B09CC VA: 0x17B09CC
	public int ANFHCKKFIEA()
	{
		if(KCCLEHLLOFG_Common != null)
		{
			return KCCLEHLLOFG_Common.NFHLDFJIBKI_have_uc;
		}
		return 0;
	}

	//// RVA: 0x17B09E4 Offset: 0x17B09E4 VA: 0x17B09E4
	//public int DNCBAOLBJON() { }

	//// RVA: 0x17B0A20 Offset: 0x17B0A20 VA: 0x17B0A20
	public int EFFBJDMGIGO_GetBuyPossible()
	{
		int idx = -1;
		for(int i = 0; i < INLBMFMOHCI_CostItems.Count; i++)
		{
			if(INLBMFMOHCI_CostItems[i].HMFFHLPNMPH_count < 1)
			{
				if (INLBMFMOHCI_CostItems[i].HMFFHLPNMPH_count < 0)
					return -2;
			}
			idx = 1;
			if (CPBDJHKHEFN_GetNumItemLeftAfterUse(i + 1) < 0)
				return 0;
		}
		if (CMBGGPOFBOO_UcCost < 1)
		{
			if (CMBGGPOFBOO_UcCost < 0)
				return -2;
			return idx;
		}
		if(KCCLEHLLOFG_Common != null)
		{
			if (KCCLEHLLOFG_Common.NFHLDFJIBKI_have_uc - CMBGGPOFBOO_UcCost < 0)
				return 0;
			return idx;
		}
		if (0 - CMBGGPOFBOO_UcCost < 0)
			return 0;
		return idx;
	}

	//// RVA: 0x17B0BCC Offset: 0x17B0BCC VA: 0x17B0BCC
	public MNDGNJLBANB HDHNAIIAJCP()
	{
		int haveUC = 0;
		if (KCCLEHLLOFG_Common != null)
			haveUC = KCCLEHLLOFG_Common.NFHLDFJIBKI_have_uc;
		MNDGNJLBANB res = haveUC < CMBGGPOFBOO_UcCost ? MNDGNJLBANB.EDBCFDJBFID_LackUC/*1*/ : MNDGNJLBANB.HJNNKCMLGFL_0_None/*0*/;
		for(int i = 0; i < INLBMFMOHCI_CostItems.Count; i++)
		{
			if(INLBMFMOHCI_CostItems[i].HMFFHLPNMPH_count > 0)
			{
				if(INLBMFMOHCI_CostItems[i].HMFFHLPNMPH_count > JBMLCIPKFDF_GetNumItemInInventory(i + 1))
				{
					return (MNDGNJLBANB)((int)res | 2);
				}
			}
		}
		return res;
	}

	//// RVA: 0x17B0D40 Offset: 0x17B0D40 VA: 0x17B0D40
	public int KMIFDLLCBEL()
	{
		int res = EFFBJDMGIGO_GetBuyPossible();
		if(res > 0)
		{
			if(KCCLEHLLOFG_Common != null)
			{
				for(int i = 0; i < 27; i++)
				{
					EGOLBAPFHHD_Common.OFAPDOKONML it = KCCLEHLLOFG_Common.KBMDMEEMGLK_grow_item[i];
					if (it.PFAKPFKJJKA())
						return -20;
				}
				if (KCCLEHLLOFG_Common.NFHLDFJIBKI_have_uc != KCCLEHLLOFG_Common.HIGJEJKADDP_HaveUcCheck)
					return -21;
			}
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null && IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
			{
				for(int i = 0; i < INLBMFMOHCI_CostItems.Count; i++)
				{
					EKLNMHFCAOI.DPHGFMEPOCA_SetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(INLBMFMOHCI_CostItems[i].PPFNGGCBJKC_id), EKLNMHFCAOI.DEACAHNLMNI_getItemId(INLBMFMOHCI_CostItems[i].PPFNGGCBJKC_id), CPBDJHKHEFN_GetNumItemLeftAfterUse(i + 1), null);
				}
				if(CMBGGPOFBOO_UcCost > 0)
				{
					KCCLEHLLOFG_Common.LLEGCIMFPGD(CMBGGPOFBOO_UcCost);
				}
				JGAAANGEIFK();
				MDHKGJJBLNL();
				return 1;
			}
			return 0;
		}
		return res;
	}

	//// RVA: 0x17B1084 Offset: 0x17B1084 VA: 0x17B1084
	//public string MNNKOKNBJNC() { }
}
