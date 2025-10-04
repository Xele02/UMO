
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use LNGMNNNJBJP_SearchForPlayer", true)]
public abstract class LNGMNNNJBJP { }
public class LNGMNNNJBJP_SearchForPlayer : CACGCMBKHDI_Request
{
	public class JNHAEJLAPDC_PlayerInfo
	{
		public int EHGBICNIBKE_player_id; // 0x8
		public int NANNGLGOFKH_value; // 0xC
		public bool MLEHCBKPNGK_IsFriend; // 0x10
		public long IFNLEKOILPM_updated_at; // 0x18
		public EDOHBJAPLPF_JsonData HJDBGMMPPEF_PlayerData; // 0x20
		public long IFCJDGINBGF_facebook_uid; // 0x28
	}

	public class FKNFPJEGMOO
	{
		public List<LNGMNNNJBJP_SearchForPlayer.JNHAEJLAPDC_PlayerInfo> AIGKNOKPMEJ_Players; // 0x8
		public int CJNNMLLEKEF_previous_page; // 0xC
		public int GPPOJHNNINK_current_page; // 0x10
		public int MDIBIIHAAPN_next_page; // 0x14
	}

	public const int GBBILKJEBCO = 100;
	public List<string> HHIHCJKLJFF_Names; // 0x80
	public CCHAFMBDGOB PINPBOCDKLI_OnPlayerCb; // 0x84
	public SakashoPlayerData.SearchOrder EILKGEADKGH_Order; // 0x88 GINMIBJOABO  Slot: 7
	public int IGNIIEBMFIN_Page = 1; // 0x90
	public int MLPLGFLKKLI_Ipp = 15; // 0x94

	public override bool OIDCBBGLPHL { get { return true; } } //0x10C387C GINMIBJOABO_bgs
	public SakashoPlayerCriteria IPKCADIAAPG_Criteria { get; set; } // 0x7C GOKPJIPOKCK_bgs FLHEFBEHCKK_bgs EIDLJIDFPFG_bgs
	public FKNFPJEGMOO NFEAMMJIMPG_Result { get; set; } // 0x8C OHEIOONIIKB_bgs LFOJDJCNOHB_bgs KMKEGMGKCBA_bgs
	public override bool EBPLLJGPFDA_HasResult { get { return NFEAMMJIMPG_Result != null; } } //0x10C3AC8 HGPAELCGELL_bgs

	// RVA: 0x10C38A4 Offset: 0x10C38A4 VA: 0x10C38A4 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoPlayerData.SearchForPlayer(IPKCADIAAPG_Criteria, HHIHCJKLJFF_Names.ToArray(), EILKGEADKGH_Order, IGNIIEBMFIN_Page, MLPLGFLKKLI_Ipp, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x10C3A0C Offset: 0x10C3A0C VA: 0x10C3A0C Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = null;
		BNJPAKLNOPA_WorkerThreadQueue.Add(DIAMDBHBKBH);
	}

	// RVA: 0x10C3AD8 Offset: 0x10C3AD8 VA: 0x10C3AD8 Slot: 15
	public override void NLDKLFODOJJ()
	{
		return;
	}

	//// RVA: 0x10C3ADC Offset: 0x10C3ADC VA: 0x10C3ADC
	private void DIAMDBHBKBH()
	{
		FKNFPJEGMOO res = new FKNFPJEGMOO();
		EDOHBJAPLPF_JsonData json = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result);
		int num = json["players"].HNBFOAJIIAL_Count;
		res.CJNNMLLEKEF_previous_page = (int)json["previous_page"];
		res.GPPOJHNNINK_current_page = (int)json["current_page"];
		res.MDIBIIHAAPN_next_page = (int)json["next_page"];
		res.AIGKNOKPMEJ_Players = new List<JNHAEJLAPDC_PlayerInfo>();
		for(int i = 0; i < num; i++)
		{
			EDOHBJAPLPF_JsonData playerJson = json["players"][i];
			JNHAEJLAPDC_PlayerInfo data = new JNHAEJLAPDC_PlayerInfo();
			data.EHGBICNIBKE_player_id = (int)playerJson["player_id"];
			data.NANNGLGOFKH_value = (int)playerJson["value"];
			if(!playerJson["updated_at"].MDDJBLEDMBJ_IsInt)
			{
				if(playerJson["updated_at"].DCPEFFOMOOK_IsLong)
				{
					data.IFNLEKOILPM_updated_at = (long)playerJson["updated_at"];
				}
			}
			else
			{
				data.IFNLEKOILPM_updated_at = (int)playerJson["updated_at"];
			}
			data.HJDBGMMPPEF_PlayerData = playerJson["player_data"];
			data.MLEHCBKPNGK_IsFriend = (bool)playerJson["is_friend"];
			res.AIGKNOKPMEJ_Players.Add(data);
		}
		if(PINPBOCDKLI_OnPlayerCb != null && num > 0)
		{
			for(int i = 0; i < num; i++)
			{
				PINPBOCDKLI_OnPlayerCb(i, res.AIGKNOKPMEJ_Players[i].EHGBICNIBKE_player_id, res.AIGKNOKPMEJ_Players[i].IFNLEKOILPM_updated_at, res.AIGKNOKPMEJ_Players[i].MLEHCBKPNGK_IsFriend, HHIHCJKLJFF_Names, res.AIGKNOKPMEJ_Players[i].HJDBGMMPPEF_PlayerData);
			}
		}
		NFEAMMJIMPG_Result = res;
	}
}
