
using System.Collections.Generic;

public delegate bool CCHAFMBDGOB(int BMBBDIAEOMP, int EHGBICNIBKE, long IFNLEKOILPM, bool DMBJLEIGCCG, List<string> OHNJJIMGKGK, EDOHBJAPLPF_JsonData NMICBJDPLOH);

public class LBKPFADGHPK : IHFBKJMNIPH<LNGMNNNJBJP_SearchForPlayer>
{
	public List<string> HHIHCJKLJFF_ServerInfoBlockList; // 0x10
	public CCHAFMBDGOB PINPBOCDKLI_OnFriendCb; // 0x14
	public SakashoPlayerData.SearchOrder EILKGEADKGH_SearchOrder; // 0x18
	private int MDEGLGEMHGG_Page; // 0x1C

	public SakashoPlayerCriteria IPKCADIAAPG_SakashoCrit { get; set; } // 0xC GOKPJIPOKCK FLHEFBEHCKK EIDLJIDFPFG
	public bool NELEMPLILIO { get; set; } // 0x20 GDKGAPELKDD KIIKEFBAHMI PLNDPEHALHA

	//// RVA: 0xD995E0 Offset: 0xD995E0 VA: 0xD995E0 Slot: 4
	protected override void LJDCONBNPBM_Initialize()
	{
		NELEMPLILIO = false;
		MDEGLGEMHGG_Page = 1;
	}

	//// RVA: 0xD995F4 Offset: 0xD995F4 VA: 0xD995F4 Slot: 5
	protected override LNGMNNNJBJP_SearchForPlayer JIJACMIFOMB_OnStartAction(PJKLMCGEJMK CPHFEPHDJIB)
	{
		LNGMNNNJBJP_SearchForPlayer res = CPHFEPHDJIB.IFFNCAFNEAG_AddRequest(new LNGMNNNJBJP_SearchForPlayer());
		res.IPKCADIAAPG_SakashoCrit = IPKCADIAAPG_SakashoCrit;
		res.EILKGEADKGH_SearchOrder = EILKGEADKGH_SearchOrder;
		res.MLPLGFLKKLI_Ipp = 100;
		res.HHIHCJKLJFF_ServerInfoBlockList = HHIHCJKLJFF_ServerInfoBlockList;
		res.IGNIIEBMFIN_Page = MDEGLGEMHGG_Page;
		res.PINPBOCDKLI_OnFriendCb = PINPBOCDKLI_OnFriendCb;
		res.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request HKICMNAACDA) =>
		{
			//0xD99834
			MDEGLGEMHGG_Page = (HKICMNAACDA as LNGMNNNJBJP_SearchForPlayer).NFEAMMJIMPG_FriendsResult.MDIBIIHAAPN_NextPage;
		};
		return res;
	}

	//// RVA: 0xD997AC Offset: 0xD997AC VA: 0xD997AC Slot: 6
	protected override bool IMOEHHBDHGN_ContinueAction()
	{
		return MDEGLGEMHGG_Page != 0 && !NELEMPLILIO;
	}
}
