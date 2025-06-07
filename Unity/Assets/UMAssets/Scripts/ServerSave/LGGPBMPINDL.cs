
using System.Text;
using XeSys;

[System.Obsolete("Use LGGPBMPINDL_EventRaidPlayer", true)]
public class LGGPBMPINDL { }
public class LGGPBMPINDL_EventRaidPlayer : KLFDBFMNLBL_ServerSaveBlock
{
	private const int ECFEMKGFDCE = 1;
	public int MEBHCFJCKFE_LobbyId; // 0x24
	public int OBGBAOLONDD; // 0x28
	public long NFIOKIBPJCJ_Uptime; // 0x30
	public int KDMPHHFADMC_ClusterId; // 0x38

	public override bool DMICHEJIAJL { get { return false; } } // 0xD74474 NFKFOODCJJB

	// // RVA: 0xD73940 Offset: 0xD73940 VA: 0xD73940
	public void KHEKNNFCAOI_Init(int GPLGIGCNNAD)
	{
		MEBHCFJCKFE_LobbyId = 0;
		OBGBAOLONDD = GPLGIGCNNAD;
		UnityEngine.Debug.LogError("Set OBGBAOLONDD "+OBGBAOLONDD);
		NFIOKIBPJCJ_Uptime = 0;
		KDMPHHFADMC_ClusterId = 0;
	}

	// // RVA: 0xD7395C Offset: 0xD7395C VA: 0xD7395C
	public bool IPLBEGCODDC(int EKANGPODCEP)
	{
		return EKANGPODCEP == OBGBAOLONDD && EKANGPODCEP != 0 && OBGBAOLONDD != 0 && MEBHCFJCKFE_LobbyId != 0;
	}

	// // RVA: 0xD73990 Offset: 0xD73990 VA: 0xD73990
	public LGGPBMPINDL_EventRaidPlayer()
	{
		KMBPACJNEOF();
	}

	// // RVA: 0xD739BC Offset: 0xD739BC VA: 0xD739BC Slot: 4
	public override void KMBPACJNEOF()
	{
		return;
	}

	// // RVA: 0xD739C0 Offset: 0xD739C0 VA: 0xD739C0 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		StringBuilder str = new StringBuilder(32);
		str.SetFormat("lobby_id_{0:D5}", OBGBAOLONDD);
		UnityEngine.Debug.LogError("Save OBGBAOLONDD "+str.ToString()+" "+MEBHCFJCKFE_LobbyId);
		data[str.ToString()] = MEBHCFJCKFE_LobbyId;
		data[AFEHLCGHAEE_Strings.NFIOKIBPJCJ_uptime] = NFIOKIBPJCJ_Uptime;
		data[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = MCKEOKFMLAH;
		data[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 1;
		str.SetFormat("lobby_cluster_id_{0:D5}", OBGBAOLONDD);
		data[str.ToString()] = KDMPHHFADMC_ClusterId;
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0xD73D14 Offset: 0xD73D14 VA: 0xD73D14 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		if(!OILEIIEIBHP.BBAJPINMOEP_Contains(JIKKNHIAEKG_BlockName))
			return false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = OILEIIEIBHP[JIKKNHIAEKG_BlockName];
		if(block.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev))
		{
			if((int)block[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] != 1)
				isInvalid = true;
		}
		else
			isInvalid = true;
		OBGBAOLONDD = 0;
		StringBuilder str = new StringBuilder(32);
		StringBuilder str2 = new StringBuilder(32);
		for(int i = 13001; i < 13999; i++)
		{
			str.SetFormat("lobby_id_{0:D5}", i);
			str2.SetFormat("lobby_cluster_id_{0:D5}", i);
			if(block.BBAJPINMOEP_Contains(str.ToString()))
			{
				OBGBAOLONDD = i;
				MEBHCFJCKFE_LobbyId = CJAENOMGPDA_ReadInt(block, str.ToString(), 0, ref isInvalid);
				KDMPHHFADMC_ClusterId = CJAENOMGPDA_ReadInt(block, str2.ToString(), 0, ref isInvalid);
				break;
			}
		}
		if(OBGBAOLONDD == 0)
		{
			MEBHCFJCKFE_LobbyId = CJAENOMGPDA_ReadInt(block, "lobby_id_00000", 0, ref isInvalid);
			KDMPHHFADMC_ClusterId = CJAENOMGPDA_ReadInt(block, "lobby_cluster_id_", 0, ref isInvalid);
		}
		UnityEngine.Debug.LogError("Read Lobby "+OBGBAOLONDD+" "+MEBHCFJCKFE_LobbyId);
		NFIOKIBPJCJ_Uptime = DKMPHAPBDLH_ReadLong(block, AFEHLCGHAEE_Strings.NFIOKIBPJCJ_uptime, 0, ref isInvalid);
		KFKDMBPNLJK_BlockInvalid = isInvalid;
		return true;
	}

	// // RVA: 0xD741C0 Offset: 0xD741C0 VA: 0xD741C0 Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		LGGPBMPINDL_EventRaidPlayer other = GPBJHKLFCEP as LGGPBMPINDL_EventRaidPlayer;
		MEBHCFJCKFE_LobbyId = other.MEBHCFJCKFE_LobbyId;
		OBGBAOLONDD = other.OBGBAOLONDD;
		NFIOKIBPJCJ_Uptime = other.NFIOKIBPJCJ_Uptime;
		KDMPHHFADMC_ClusterId = other.KDMPHHFADMC_ClusterId;
	}

	// // RVA: 0xD74318 Offset: 0xD74318 VA: 0xD74318 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		LGGPBMPINDL_EventRaidPlayer other = GPBJHKLFCEP as LGGPBMPINDL_EventRaidPlayer;
		if(MEBHCFJCKFE_LobbyId != other.MEBHCFJCKFE_LobbyId)
			return false;
		if(OBGBAOLONDD != other.OBGBAOLONDD)
			return false;
		if(NFIOKIBPJCJ_Uptime != other.NFIOKIBPJCJ_Uptime)
			return false;
		if(KDMPHHFADMC_ClusterId != other.KDMPHHFADMC_ClusterId)
			return false;
		return true;
	}

	// // RVA: 0xD74470 Offset: 0xD74470 VA: 0xD74470 Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH);
}
