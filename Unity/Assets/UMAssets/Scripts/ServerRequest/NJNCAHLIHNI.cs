
using System.Collections.Generic;
using UnityEngine;

public delegate bool MEIEDGPOMOO(int _BMBBDIAEOMP_i, int _EHGBICNIBKE_player_id, long _IFNLEKOILPM_updated_at, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _NMICBJDPLOH_player);

[System.Obsolete("Use NJNCAHLIHNI_GetPlayerData", true)]
public class NJNCAHLIHNI { }
public class NJNCAHLIHNI_GetPlayerData : CACGCMBKHDI_NetBaseAction
{
	public class OKMDAFICFHJ
	{
		public int EHGBICNIBKE_player_id; // 0x8
		public long IFNLEKOILPM_updated_at; // 0x10
		public EDOHBJAPLPF_JsonData HJDBGMMPPEF_PlayerData; // 0x18
		public long IFCJDGINBGF_facebook_uid; // 0x20
	}

	public class JFNMOPPICNP
	{
		public List<OKMDAFICFHJ> AIGKNOKPMEJ_Players; // 0x8
	}

	public List<int> FAMHAPONILI_PlayerIds; // 0x7C
	public List<string> HHIHCJKLJFF_Names; // 0x80
	public const int GLOLJBMGDNP = 50;
	public MEIEDGPOMOO PINPBOCDKLI_OnPlayerCb; // 0x84

	public JFNMOPPICNP NFEAMMJIMPG_Result { get; set; } // 0x88 OHEIOONIIKB_bgs LFOJDJCNOHB_bgs KMKEGMGKCBA_bgs
	public override bool EBPLLJGPFDA_HasResult { get { return NFEAMMJIMPG_Result != null; } } //0x18ABEC8 HGPAELCGELL_bgs

	// RVA: 0x18ABC90 Offset: 0x18ABC90 VA: 0x18ABC90 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoPlayerData.GetPlayerData(FAMHAPONILI_PlayerIds.ToArray(), HHIHCJKLJFF_Names.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x18ABE0C Offset: 0x18ABE0C VA: 0x18ABE0C Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = null;
		BNJPAKLNOPA_WorkerThreadQueue.Add(DIAMDBHBKBH);
	}

	// RVA: 0x18ABED8 Offset: 0x18ABED8 VA: 0x18ABED8 Slot: 15
	public override void NLDKLFODOJJ()
	{
		return;
	}

	//// RVA: 0x18ABEDC Offset: 0x18ABEDC VA: 0x18ABEDC
	private void DIAMDBHBKBH()
	{
		JFNMOPPICNP res = new JFNMOPPICNP();
		EDOHBJAPLPF_JsonData data = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result);
		res.AIGKNOKPMEJ_Players = new List<OKMDAFICFHJ>(data["players"].HNBFOAJIIAL_Count);
		for (int i = 0; i < data["players"].HNBFOAJIIAL_Count; i++)
		{
			EDOHBJAPLPF_JsonData p = data["players"][i];
			OKMDAFICFHJ d = new OKMDAFICFHJ();
			d.EHGBICNIBKE_player_id = (int)p["player_id"];
			d.IFNLEKOILPM_updated_at = (int)p["updated_at"];
			d.HJDBGMMPPEF_PlayerData = p["player_data"];
			res.AIGKNOKPMEJ_Players.Add(d);
		}
		if(PINPBOCDKLI_OnPlayerCb != null)
		{
			for(int i = 0; i < res.AIGKNOKPMEJ_Players.Count; i++)
			{
				bool b = PINPBOCDKLI_OnPlayerCb(i, res.AIGKNOKPMEJ_Players[i].EHGBICNIBKE_player_id, res.AIGKNOKPMEJ_Players[i].IFNLEKOILPM_updated_at, HHIHCJKLJFF_Names, res.AIGKNOKPMEJ_Players[i].HJDBGMMPPEF_PlayerData);
				if(!b)
				{
					DLKLLHPLANH = true;
				}
			}
		}
		NFEAMMJIMPG_Result = res;
	}
}
