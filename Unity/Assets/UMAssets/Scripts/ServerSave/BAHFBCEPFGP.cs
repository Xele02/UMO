
using UnityEngine;

[System.Obsolete("Use BAHFBCEPFGP_AddMusic", true)]
public class BAHFBCEPFGP { }
public class BAHFBCEPFGP_AddMusic : KLFDBFMNLBL_ServerSaveBlock
{
	private const int ECFEMKGFDCE = 1;
	private const int JDOFFDAJGBO = 300;
	private const int DKKOEGALOPA = 38;
	private byte[] BJFCIFJLJJI_ShowAddUnitLiveDio = new byte[38]; // 0x24
	private byte[] IEGFCNMOCNE_ShowAddUnitLiveTrio = new byte[38]; // 0x28
	private byte[] FALFJCGGDHB_ShowAddUnitLiveQuartet = new byte[38]; // 0x2C
	private byte[] KKPKAMANKOH_ShowAddUnitLiveQuintet = new byte[38]; // 0x30

	public override bool DMICHEJIAJL { get { return true; } } // 0xF15DE4 NFKFOODCJJB

	// // RVA: 0xF14400 Offset: 0xF14400 VA: 0xF14400
	public void DDCBGCODHHN(int DLAEJOBELBH_Id, int HPNLNIFICNI)
	{
		int a = (DLAEJOBELBH_Id - 1) >> 3;
		if(a < 38)
		{
			if(HPNLNIFICNI >= 2 && HPNLNIFICNI < 6)
			{
				byte[] array = null;
				switch (HPNLNIFICNI)
				{
					case 2:
						array = BJFCIFJLJJI_ShowAddUnitLiveDio;
						break;
					case 3:
						array = IEGFCNMOCNE_ShowAddUnitLiveTrio;
						break;
					case 4:
						array = FALFJCGGDHB_ShowAddUnitLiveQuartet;
						break;
					case 5:
						array = KKPKAMANKOH_ShowAddUnitLiveQuintet;
						break;
				}
				array[a] |= (byte)(1 << ((DLAEJOBELBH_Id - 1) & 7));
			}
			else
			{
				Debug.Log(JpStringLiterals.StringLiteral_9528 + DLAEJOBELBH_Id);
			}
		}
	}

	// // RVA: 0xF14574 Offset: 0xF14574 VA: 0xF14574
	public bool CGEPJMFFLLJ(int DLAEJOBELBH_Id, int HPNLNIFICNI)
	{
		int a = (DLAEJOBELBH_Id - 1) >> 3;
		if(a < 38)
		{
			if(HPNLNIFICNI >= 2 && HPNLNIFICNI < 6)
			{
				byte[] array = null;
				switch (HPNLNIFICNI)
				{
					case 2:
						array = BJFCIFJLJJI_ShowAddUnitLiveDio;
						break;
					case 3:
						array = IEGFCNMOCNE_ShowAddUnitLiveTrio;
						break;
					case 4:
						array = FALFJCGGDHB_ShowAddUnitLiveQuartet;
						break;
					case 5:
						array = KKPKAMANKOH_ShowAddUnitLiveQuintet;
						break;
				}
				return ((1 << ((DLAEJOBELBH_Id - 1) & 7)) & array[a]) != 0;
			}
			else
			{
				Debug.Log(JpStringLiterals.StringLiteral_9528 + DLAEJOBELBH_Id.ToString());
			}
		}
		return false;
	}

	// // RVA: 0xF146F4 Offset: 0xF146F4 VA: 0xF146F4
	// public void KDJJJAIPJCA() { }

	// // RVA: 0xF148A4 Offset: 0xF148A4 VA: 0xF148A4 Slot: 4
	public override void KMBPACJNEOF()
	{
		for(int i = 0; i < BJFCIFJLJJI_ShowAddUnitLiveDio.Length; i++)
		{
			BJFCIFJLJJI_ShowAddUnitLiveDio[i] = 0;
		}
		for(int i = 0; i < IEGFCNMOCNE_ShowAddUnitLiveTrio.Length; i++)
		{
			IEGFCNMOCNE_ShowAddUnitLiveTrio[i] = 0;
		}
		for(int i = 0; i < FALFJCGGDHB_ShowAddUnitLiveQuartet.Length; i++)
		{
			FALFJCGGDHB_ShowAddUnitLiveQuartet[i] = 0;
		}
		for(int i = 0; i < KKPKAMANKOH_ShowAddUnitLiveQuintet.Length; i++)
		{
			FALFJCGGDHB_ShowAddUnitLiveQuartet[i] = 0; // Bug, should be KKPKAMANKOH
		}
	}

	// // RVA: 0xF148A8 Offset: 0xF148A8 VA: 0xF148A8 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data["show_addunitlive_dio"] = CEDHHAGBIBA.EHNMFLADJKG_ByteArrayToString(BJFCIFJLJJI_ShowAddUnitLiveDio);
		data["show_addunitlive_trio"] = CEDHHAGBIBA.EHNMFLADJKG_ByteArrayToString(IEGFCNMOCNE_ShowAddUnitLiveTrio);
		data["show_addunitlive_quartet"] = CEDHHAGBIBA.EHNMFLADJKG_ByteArrayToString(FALFJCGGDHB_ShowAddUnitLiveQuartet);
		data["show_addunitlive_quintet"] = CEDHHAGBIBA.EHNMFLADJKG_ByteArrayToString(KKPKAMANKOH_ShowAddUnitLiveQuintet);
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = MCKEOKFMLAH;
			data2[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 1;
			data2[JIKKNHIAEKG_BlockName] = data;
			data = data2;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0xF14CD0 Offset: 0xF14CD0 VA: 0xF14CD0 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 1);
		if (!blockMissing)
		{
			if (block == null)
			{
				isInvalid = true;
			}
			else
			{
				CEDHHAGBIBA.IFOLECIIDPO_StringToByteArray(BJFCIFJLJJI_ShowAddUnitLiveDio, FGCNMLBACGO_ReadString(block, "show_addunitlive_dio", "", ref isInvalid));
				CEDHHAGBIBA.IFOLECIIDPO_StringToByteArray(IEGFCNMOCNE_ShowAddUnitLiveTrio, FGCNMLBACGO_ReadString(block, "show_addunitlive_trio", "", ref isInvalid));
				CEDHHAGBIBA.IFOLECIIDPO_StringToByteArray(FALFJCGGDHB_ShowAddUnitLiveQuartet, FGCNMLBACGO_ReadString(block, "show_addunitlive_quartet", "", ref isInvalid));
				CEDHHAGBIBA.IFOLECIIDPO_StringToByteArray(KKPKAMANKOH_ShowAddUnitLiveQuintet, FGCNMLBACGO_ReadString(block, "show_addunitlive_quintet", "", ref isInvalid));
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0xF14EB8 Offset: 0xF14EB8 VA: 0xF14EB8 Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		BAHFBCEPFGP_AddMusic b = GPBJHKLFCEP as BAHFBCEPFGP_AddMusic;
		for (int i = 0; i < BJFCIFJLJJI_ShowAddUnitLiveDio.Length; i++)
		{
			BJFCIFJLJJI_ShowAddUnitLiveDio[i] = b.BJFCIFJLJJI_ShowAddUnitLiveDio[i];
		}
		for(int i = 0; i < IEGFCNMOCNE_ShowAddUnitLiveTrio.Length; i++)
		{
			IEGFCNMOCNE_ShowAddUnitLiveTrio[i] = b.IEGFCNMOCNE_ShowAddUnitLiveTrio[i];
		}
		for(int i = 0; i < FALFJCGGDHB_ShowAddUnitLiveQuartet.Length; i++)
		{
			FALFJCGGDHB_ShowAddUnitLiveQuartet[i] = b.FALFJCGGDHB_ShowAddUnitLiveQuartet[i];
		}
		for(int i = 0; i < KKPKAMANKOH_ShowAddUnitLiveQuintet.Length; i++)
		{
			KKPKAMANKOH_ShowAddUnitLiveQuintet[i] = b.KKPKAMANKOH_ShowAddUnitLiveQuintet[i];
		}
	}

	// // RVA: 0xF15248 Offset: 0xF15248 VA: 0xF15248 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		BAHFBCEPFGP_AddMusic other = GPBJHKLFCEP as BAHFBCEPFGP_AddMusic;
		for (int i = 0; i < BJFCIFJLJJI_ShowAddUnitLiveDio.Length; i++)
		{
			if(BJFCIFJLJJI_ShowAddUnitLiveDio[i] != other.BJFCIFJLJJI_ShowAddUnitLiveDio[i])
				return false;
		}
		for(int i = 0; i < IEGFCNMOCNE_ShowAddUnitLiveTrio.Length; i++)
		{
			if(IEGFCNMOCNE_ShowAddUnitLiveTrio[i] != other.IEGFCNMOCNE_ShowAddUnitLiveTrio[i])
				return false;
		}
		for(int i = 0; i < FALFJCGGDHB_ShowAddUnitLiveQuartet.Length; i++)
		{
			if(FALFJCGGDHB_ShowAddUnitLiveQuartet[i] != other.FALFJCGGDHB_ShowAddUnitLiveQuartet[i])
				return false;
		}
		for(int i = 0; i < KKPKAMANKOH_ShowAddUnitLiveQuintet.Length; i++)
		{
			if(KKPKAMANKOH_ShowAddUnitLiveQuintet[i] != other.KKPKAMANKOH_ShowAddUnitLiveQuintet[i])
				return false;
		}
		return true;
	}

	// // RVA: 0xF15600 Offset: 0xF15600 VA: 0xF15600 Slot: 10
	public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH)
	{
		TodoLogger.LogError(0, "AGHKODFKOJI");
	}
}
