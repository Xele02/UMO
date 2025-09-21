
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use DKFCEGODKFJ_GetPlayerCounters", true)]
public class DKFCEGODKFJ { }
public class DKFCEGODKFJ_GetPlayerCounters : CACGCMBKHDI_Request
{
	public class ENKJGMFOJDI
	{
		public string IHALNOJAMLE_PlayerCounterMasterName; // 0x8
		public List<int> FAMHAPONILI_PlayerIds; // 0xC
	}

	public class HJKLBEOACCA
	{
		public Dictionary<int, int> OJCNJFLJCLA; // 0x8

		// RVA: 0x198F458 Offset: 0x198F458 VA: 0x198F458
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("player_counters"))
			{
				OJCNJFLJCLA = new Dictionary<int, int>(OBHAFLMHAKG["player_counters"].HNBFOAJIIAL_Count);
				for(int i = 0; i < OBHAFLMHAKG["player_counters"].HNBFOAJIIAL_Count; i++)
				{
					string s = OBHAFLMHAKG["player_counters"].FLPBHNAOIOB(i);
					OJCNJFLJCLA.Add(int.Parse(s),
						(int)OBHAFLMHAKG["player_counters"][s]["player_count"]);
				}
			}
		}
	}

	public const int HIKCJJJPPOL = 100;
	public ENKJGMFOJDI BIHCCEHLAOD = new ENKJGMFOJDI(); // 0x7C
	public HJKLBEOACCA NFEAMMJIMPG_Result; // 0x80

	// RVA: 0x198F224 Offset: 0x198F224 VA: 0x198F224 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoPlayerCounter.GetPlayerCounters(BIHCCEHLAOD.IHALNOJAMLE_PlayerCounterMasterName, BIHCCEHLAOD.FAMHAPONILI_PlayerIds.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x198F378 Offset: 0x198F378 VA: 0x198F378 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = new HJKLBEOACCA();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
