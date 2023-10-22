
using UnityEngine;

public class DPDMNBGAONP : IHFBKJMNIPH<DKFCEGODKFJ_GetPlayerCounters>
{
	public DKFCEGODKFJ_GetPlayerCounters.ENKJGMFOJDI BIHCCEHLAOD = new DKFCEGODKFJ_GetPlayerCounters.ENKJGMFOJDI(); // 0xC
	public DKFCEGODKFJ_GetPlayerCounters.HJKLBEOACCA NFEAMMJIMPG = new DKFCEGODKFJ_GetPlayerCounters.HJKLBEOACCA(); // 0x10
	private int HMFFHLPNMPH; // 0x14

	//// RVA: 0x1233CE0 Offset: 0x1233CE0 VA: 0x1233CE0 Slot: 4
	protected override void LJDCONBNPBM_Initialize()
	{
		HMFFHLPNMPH = 0;
		NFEAMMJIMPG.OJCNJFLJCLA = new System.Collections.Generic.Dictionary<int, int>(BIHCCEHLAOD.FAMHAPONILI_PlayerList.Count);
	}

	//// RVA: 0x1233DC4 Offset: 0x1233DC4 VA: 0x1233DC4 Slot: 5
	protected override DKFCEGODKFJ_GetPlayerCounters JIJACMIFOMB_OnStartAction(PJKLMCGEJMK CPHFEPHDJIB)
	{
		DKFCEGODKFJ_GetPlayerCounters res = CPHFEPHDJIB.IFFNCAFNEAG_AddRequest(new DKFCEGODKFJ_GetPlayerCounters());
		if(BIHCCEHLAOD.FAMHAPONILI_PlayerList.Count < 101)
		{
			res.BIHCCEHLAOD = BIHCCEHLAOD;
			HMFFHLPNMPH = res.BIHCCEHLAOD.FAMHAPONILI_PlayerList.Count;
		}
		else
		{
			DKFCEGODKFJ_GetPlayerCounters.ENKJGMFOJDI data = new DKFCEGODKFJ_GetPlayerCounters.ENKJGMFOJDI();
			data.IHALNOJAMLE_CounterName = BIHCCEHLAOD.IHALNOJAMLE_CounterName;
			data.FAMHAPONILI_PlayerList = new System.Collections.Generic.List<int>(100);
			int c = Mathf.Min(BIHCCEHLAOD.FAMHAPONILI_PlayerList.Count, HMFFHLPNMPH + 100);
			for(int i = HMFFHLPNMPH; i < c; i++)
			{
				data.FAMHAPONILI_PlayerList.Add(BIHCCEHLAOD.FAMHAPONILI_PlayerList[i]);
			}
			HMFFHLPNMPH += 100;
			res.BIHCCEHLAOD = data;
		}
		res.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request HKICMNAACDA) =>
		{
			//0x123428C
			DKFCEGODKFJ_GetPlayerCounters req = HKICMNAACDA as DKFCEGODKFJ_GetPlayerCounters;
			foreach(var p in req.NFEAMMJIMPG.OJCNJFLJCLA)
			{
				NFEAMMJIMPG.OJCNJFLJCLA.Add(p.Key, p.Value);
			}
		};
		return res;
	}

	//// RVA: 0x1234140 Offset: 0x1234140 VA: 0x1234140 Slot: 6
	protected override bool IMOEHHBDHGN_ContinueAction()
	{
		return HMFFHLPNMPH < BIHCCEHLAOD.FAMHAPONILI_PlayerList.Count;
	}
}
