
using System.Collections.Generic;
using UnityEngine;
using XeSys;

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
			CHDDDCCHJJH_Replace = !IDLHJIOMJBK.BLOCFLFHCFJ_Keep;
			OHNJJIMGKGK_Names = IDLHJIOMJBK.KFGDPMNCCFO_NaespaceForSave;
			MCKEOKFMLAH = IDLHJIOMJBK.MCKEOKFMLAH;
			KJPDHNJGEAH_RaidBossId = PPFNGGCBJKC;
		}
	}

	public class LKFHBFHOLBG
	{
		public long OJCCKOICMJK_CreatedAt; // 0x8
		public long LPJIIDJJKOE_UpdatedAt; // 0x10
		public int ICEMJDBBDMG_DataStatus; // 0x18

		// RVA: 0x15C8DD4 Offset: 0x15C8DD4 VA: 0x15C8DD4
		public LKFHBFHOLBG(EDOHBJAPLPF_JsonData DLENPPIJNPA)
		{
			OJCCKOICMJK_CreatedAt = JsonUtil.GetLong(DLENPPIJNPA, "created_at", 0);
			LPJIIDJJKOE_UpdatedAt = JsonUtil.GetLong(DLENPPIJNPA, "updated_at", 0);
			ICEMJDBBDMG_DataStatus = (int)DLENPPIJNPA["data_status"];
		}
	}

	public EIJBGBDMLKK BIHCCEHLAOD = new EIJBGBDMLKK(); // 0x7C
	public LKFHBFHOLBG NFEAMMJIMPG; // 0x80
	
	// RVA: 0x15C8B38 Offset: 0x15C8B38 VA: 0x15C8B38 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoRaidboss.SetRaidbossRewardsReceivedAndSave(BIHCCEHLAOD.KJPDHNJGEAH_RaidBossId, BIHCCEHLAOD.OHNJJIMGKGK_Names.ToArray(), 
			BIHCCEHLAOD.AHEFHIMGIBI_PlayerData, BIHCCEHLAOD.CHDDDCCHJJH_Replace, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x15C8CBC Offset: 0x15C8CBC VA: 0x15C8CBC Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		PJKLMCGEJMK.DALFMJFKCGJ = BIHCCEHLAOD.MCKEOKFMLAH;
		NFEAMMJIMPG = new LKFHBFHOLBG(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}

	// RVA: 0x15C8EF8 Offset: 0x15C8EF8 VA: 0x15C8EF8 Slot: 17
	public List<string> KPIDBPEKMFD_GetNamespaceForSave()
	{
		return BIHCCEHLAOD.OHNJJIMGKGK_Names;
	}

	// RVA: 0x15C8F1C Offset: 0x15C8F1C VA: 0x15C8F1C Slot: 18
	public long DPKGNBIAFDO_GetUpdatedAt()
	{
		return NFEAMMJIMPG.LPJIIDJJKOE_UpdatedAt;
	}

	// RVA: 0x15C8F40 Offset: 0x15C8F40 VA: 0x15C8F40 Slot: 19
	public int JNFCOPCBHAP_GetDataStatus()
	{
		return NFEAMMJIMPG.ICEMJDBBDMG_DataStatus;
	}
}
