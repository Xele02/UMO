
using System.Collections.Generic;
using UnityEngine;

public class LNGMNNNJBJP : CACGCMBKHDI_Request
{
	public class JNHAEJLAPDC_PlayerInfo
	{
		public int EHGBICNIBKE_PlayerId; // 0x8
		public int NANNGLGOFKH; // 0xC
		public bool MLEHCBKPNGK_IsFriend; // 0x10
		public long IFNLEKOILPM_UpdatedAt; // 0x18
		public EDOHBJAPLPF_JsonData HJDBGMMPPEF_Data; // 0x20
		public long IFCJDGINBGF; // 0x28
	}

	public class FKNFPJEGMOO
	{
		public List<LNGMNNNJBJP.JNHAEJLAPDC_PlayerInfo> AIGKNOKPMEJ_Players; // 0x8
		public int CJNNMLLEKEF_PreviousPage; // 0xC
		public int GPPOJHNNINK_CurrentPage; // 0x10
		public int MDIBIIHAAPN_NextPage; // 0x14
	}

	public delegate bool CCHAFMBDGOB(int BMBBDIAEOMP, int EHGBICNIBKE, long IFNLEKOILPM, bool DMBJLEIGCCG, List<string> OHNJJIMGKGK, EDOHBJAPLPF_JsonData NMICBJDPLOH);

	public const int GBBILKJEBCO = 100;
	public List<string> HHIHCJKLJFF_ServerInfoBlockList; // 0x80
	public CCHAFMBDGOB PINPBOCDKLI_OnFriendCb; // 0x84
	public SakashoPlayerData.SearchOrder EILKGEADKGH_SearchOrder; // 0x88 GINMIBJOABO  Slot: 7
	public int IGNIIEBMFIN_Page = 1; // 0x90
	public int MLPLGFLKKLI_Ipp = 15; // 0x94

	//public override bool OIDCBBGLPHL { get; } 0x10C387C
	public SakashoPlayerCriteria IPKCADIAAPG_SakashoCrit { get; set; } // 0x7C GOKPJIPOKCK FLHEFBEHCKK EIDLJIDFPFG
	public FKNFPJEGMOO NFEAMMJIMPG_FriendsResult { get; set; } // 0x8C OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA
	public override bool EBPLLJGPFDA_HasResult { get { return NFEAMMJIMPG_FriendsResult != null; } } //0x10C3AC8 HGPAELCGELL

	// RVA: 0x10C38A4 Offset: 0x10C38A4 VA: 0x10C38A4 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoPlayerData.SearchForPlayer(IPKCADIAAPG_SakashoCrit, HHIHCJKLJFF_ServerInfoBlockList.ToArray(), EILKGEADKGH_SearchOrder, IGNIIEBMFIN_Page, MLPLGFLKKLI_Ipp, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x10C3A0C Offset: 0x10C3A0C VA: 0x10C3A0C Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG_FriendsResult = null;
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
		res.CJNNMLLEKEF_PreviousPage = (int)json["previous_page"];
		res.GPPOJHNNINK_CurrentPage = (int)json["current_page"];
		res.MDIBIIHAAPN_NextPage = (int)json["next_page"];
		res.AIGKNOKPMEJ_Players = new List<JNHAEJLAPDC_PlayerInfo>();
		for(int i = 0; i < num; i++)
		{
			EDOHBJAPLPF_JsonData playerJson = json["players"][i];
			JNHAEJLAPDC_PlayerInfo data = new JNHAEJLAPDC_PlayerInfo();
			data.EHGBICNIBKE_PlayerId = (int)playerJson["player_id"];
			data.NANNGLGOFKH = (int)playerJson["value"];
			if(!playerJson["updated_at"].MDDJBLEDMBJ_IsInt)
			{
				if(playerJson["updated_at"].DCPEFFOMOOK_IsLong)
				{
					data.IFNLEKOILPM_UpdatedAt = (long)playerJson["updated_at"];
				}
			}
			else
			{
				data.IFNLEKOILPM_UpdatedAt = (int)playerJson["updated_at"];
			}
			data.HJDBGMMPPEF_Data = playerJson["player_data"];
			data.MLEHCBKPNGK_IsFriend = (bool)playerJson["is_friend"];
			res.AIGKNOKPMEJ_Players.Add(data);
		}
		if(PINPBOCDKLI_OnFriendCb != null && num > 0)
		{
			for(int i = 0; i < num; i++)
			{
				PINPBOCDKLI_OnFriendCb(i, res.AIGKNOKPMEJ_Players[i].EHGBICNIBKE_PlayerId, res.AIGKNOKPMEJ_Players[i].IFNLEKOILPM_UpdatedAt, res.AIGKNOKPMEJ_Players[i].MLEHCBKPNGK_IsFriend, HHIHCJKLJFF_ServerInfoBlockList, res.AIGKNOKPMEJ_Players[i].HJDBGMMPPEF_Data);
			}
		}
		NFEAMMJIMPG_FriendsResult = res;
	}
}
