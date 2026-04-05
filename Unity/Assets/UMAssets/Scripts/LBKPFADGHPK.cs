
using System.Collections.Generic;

public delegate bool CCHAFMBDGOB(int _BMBBDIAEOMP_i, int _EHGBICNIBKE_player_id, long _IFNLEKOILPM_updated_at, bool DMBJLEIGCCG, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _NMICBJDPLOH_player);

public class LBKPFADGHPK : IHFBKJMNIPH_NetBaseLoopAction<LNGMNNNJBJP_SearchForPlayer>
{
	public List<string> HHIHCJKLJFF_Names; // 0x10
	public CCHAFMBDGOB PINPBOCDKLI_OnPlayerCb; // 0x14
	public SakashoPlayerData.SearchOrder EILKGEADKGH_Order; // 0x18
	private int MDEGLGEMHGG_Page; // 0x1C

	public SakashoPlayerCriteria IPKCADIAAPG_Criteria { get; set; } // 0xC GOKPJIPOKCK_bgs FLHEFBEHCKK_bgs EIDLJIDFPFG_bgs
	public bool NELEMPLILIO { get; set; } // 0x20 GDKGAPELKDD_bgs KIIKEFBAHMI_bgs PLNDPEHALHA_bgs

	//// RVA: 0xD995E0 Offset: 0xD995E0 VA: 0xD995E0 Slot: 4
	protected override void LJDCONBNPBM_Initialize()
	{
		NELEMPLILIO = false;
		MDEGLGEMHGG_Page = 1;
	}

	//// RVA: 0xD995F4 Offset: 0xD995F4 VA: 0xD995F4 Slot: 5
	protected override LNGMNNNJBJP_SearchForPlayer JIJACMIFOMB_OnStartAction(PJKLMCGEJMK_NetActionManager _CPHFEPHDJIB_ServerRequester)
	{
		LNGMNNNJBJP_SearchForPlayer res = _CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new LNGMNNNJBJP_SearchForPlayer());
		res.IPKCADIAAPG_Criteria = IPKCADIAAPG_Criteria;
		res.EILKGEADKGH_Order = EILKGEADKGH_Order;
		res.MLPLGFLKKLI_Ipp = 100;
		res.HHIHCJKLJFF_Names = HHIHCJKLJFF_Names;
		res.IGNIIEBMFIN_Page = MDEGLGEMHGG_Page;
		res.PINPBOCDKLI_OnPlayerCb = PINPBOCDKLI_OnPlayerCb;
		res.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction _HKICMNAACDA_a) =>
		{
			//0xD99834
			MDEGLGEMHGG_Page = (_HKICMNAACDA_a as LNGMNNNJBJP_SearchForPlayer).NFEAMMJIMPG_Result.MDIBIIHAAPN_next_page;
		};
		return res;
	}

	//// RVA: 0xD997AC Offset: 0xD997AC VA: 0xD997AC Slot: 6
	protected override bool IMOEHHBDHGN_ContinueAction()
	{
		return MDEGLGEMHGG_Page != 0 && !NELEMPLILIO;
	}
}
