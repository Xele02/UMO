
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use AHNHJFCAPCH_SetRaidbossRewardsReceivedAndSave", true)]
public class AHNHJFCAPCH {}
public class AHNHJFCAPCH_SetRaidbossRewardsReceivedAndSave : CACGCMBKHDI_Request, CJIKLGPIPBA
{
	public class EIJBGBDMLKK
	{
		public int KJPDHNJGEAH_RaidBossId; // 0x8
		public List<string> OHNJJIMGKGK_Names; // 0xC
		public string AHEFHIMGIBI_PlayerData; // 0x10
		public bool CHDDDCCHJJH_Replace; // 0x14
		public long MCKEOKFMLAH; // 0x18

		//// RVA: 0x15C9014 Offset: 0x15C9014 VA: 0x15C9014
		public void DOMFHDPMCCO(BBHNACPENDM_ServerSaveData.EMHDCKMFCGE IDLHJIOMJBK, string JCJDPGMKJAJ, int PPFNGGCBJKC)
		{
			AHEFHIMGIBI_PlayerData = JCJDPGMKJAJ;
			CHDDDCCHJJH_Replace = !IDLHJIOMJBK.BLOCFLFHCFJ;
			OHNJJIMGKGK_Names = IDLHJIOMJBK.KFGDPMNCCFO;
			MCKEOKFMLAH = IDLHJIOMJBK.MCKEOKFMLAH;
			KJPDHNJGEAH_RaidBossId = PPFNGGCBJKC;
		}
	}

	public class LKFHBFHOLBG
	{
		public long OJCCKOICMJK; // 0x8
		public long LPJIIDJJKOE; // 0x10
		public int ICEMJDBBDMG; // 0x18

		// RVA: 0x15C8DD4 Offset: 0x15C8DD4 VA: 0x15C8DD4
		public LKFHBFHOLBG(EDOHBJAPLPF_JsonData DLENPPIJNPA)
		{
			TodoLogger.LogError(TodoLogger.EventRaid_11_13, "LKFHBFHOLBG");
		}
	}

	public EIJBGBDMLKK BIHCCEHLAOD = new EIJBGBDMLKK(); // 0x7C
	public LKFHBFHOLBG NFEAMMJIMPG; // 0x80
	
	// RVA: 0x15C8B38 Offset: 0x15C8B38 VA: 0x15C8B38 Slot: 12
	public override void DHLDNIEELHO()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "SetRaidbossRewardsReceivedAndSave DHLDNIEELHO");
	}

	// RVA: 0x15C8CBC Offset: 0x15C8CBC VA: 0x15C8CBC Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "SetRaidbossRewardsReceivedAndSave MGFNKDPHFGI");
	}

	// RVA: 0x15C8EF8 Offset: 0x15C8EF8 VA: 0x15C8EF8 Slot: 17
	public List<string> KPIDBPEKMFD()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "SetRaidbossRewardsReceivedAndSave KPIDBPEKMFD");
		return new List<string>();
	}

	// RVA: 0x15C8F1C Offset: 0x15C8F1C VA: 0x15C8F1C Slot: 18
	public long DPKGNBIAFDO()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "SetRaidbossRewardsReceivedAndSave DPKGNBIAFDO");
		return 0;
	}

	// RVA: 0x15C8F40 Offset: 0x15C8F40 VA: 0x15C8F40 Slot: 19
	public int JNFCOPCBHAP()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "SetRaidbossRewardsReceivedAndSave JNFCOPCBHAP");
		return 0;
	}
}
