
using System.Collections.Generic;
using UnityEngine;

public delegate bool MEIEDGPOMOO(int BMBBDIAEOMP, int EHGBICNIBKE, long IFNLEKOILPM, List<string> OHNJJIMGKGK, EDOHBJAPLPF_JsonData NMICBJDPLOH);

[System.Obsolete("Use NJNCAHLIHNI_GetPlayerData", true)]
public class NJNCAHLIHNI { }
public class NJNCAHLIHNI_GetPlayerData : CACGCMBKHDI_Request
{
	public class OKMDAFICFHJ
	{
		public int EHGBICNIBKE_PlayerId; // 0x8
		public long IFNLEKOILPM_UpdatedAt; // 0x10
		public EDOHBJAPLPF_JsonData HJDBGMMPPEF_PlayerData; // 0x18
		public long IFCJDGINBGF; // 0x20
	}

	public class JFNMOPPICNP
	{
		public List<OKMDAFICFHJ> AIGKNOKPMEJ; // 0x8
	}

	public List<int> FAMHAPONILI_Ids; // 0x7C
	public List<string> HHIHCJKLJFF_BlockNames; // 0x80
	public const int GLOLJBMGDNP = 50;
	public MEIEDGPOMOO PINPBOCDKLI; // 0x84

	public JFNMOPPICNP NFEAMMJIMPG { get; set; } // 0x88 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA
	public override bool EBPLLJGPFDA_HasResult { get { return NFEAMMJIMPG != null; } } //0x18ABEC8 HGPAELCGELL

	// RVA: 0x18ABC90 Offset: 0x18ABC90 VA: 0x18ABC90 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoPlayerData.GetPlayerData(FAMHAPONILI_Ids.ToArray(), HHIHCJKLJFF_BlockNames.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x18ABE0C Offset: 0x18ABE0C VA: 0x18ABE0C Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = null;
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
		res.AIGKNOKPMEJ = new List<OKMDAFICFHJ>(data["players"].HNBFOAJIIAL_Count);
		for (int i = 0; i < data["players"].HNBFOAJIIAL_Count; i++)
		{
			EDOHBJAPLPF_JsonData p = data["players"][i];
			OKMDAFICFHJ d = new OKMDAFICFHJ();
			d.EHGBICNIBKE_PlayerId = (int)p["player_id"];
			d.IFNLEKOILPM_UpdatedAt = (int)p["updated_at"];
			d.HJDBGMMPPEF_PlayerData = p["player_data"];
			res.AIGKNOKPMEJ.Add(d);
		}
		if(PINPBOCDKLI != null)
		{
			for(int i = 0; i < res.AIGKNOKPMEJ.Count; i++)
			{
				bool b = PINPBOCDKLI(i, res.AIGKNOKPMEJ[i].EHGBICNIBKE_PlayerId, res.AIGKNOKPMEJ[i].IFNLEKOILPM_UpdatedAt, HHIHCJKLJFF_BlockNames, res.AIGKNOKPMEJ[i].HJDBGMMPPEF_PlayerData);
				if(!b)
				{
					DLKLLHPLANH = true;
				}
			}
		}
		NFEAMMJIMPG = res;
	}
}
