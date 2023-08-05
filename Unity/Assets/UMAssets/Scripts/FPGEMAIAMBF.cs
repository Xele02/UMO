
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use FPGEMAIAMBF_RewardData", true)]
public class FPGEMAIAMBF { }
public class FPGEMAIAMBF_RewardData
{
	public class LOIJICNJMKA
	{
		public enum KPGOMKPPJEE
		{
			PCNKFALHCDA = 0,
			FJGFAPKLLCL = 1,
			JMAFBDCPBJD_Achieved = 2,
		}

		public int FCDKJAKLGMB_TargetValue; // 0x8
		public KPGOMKPPJEE CMCKNKKCNDK_Achieved; // 0xC
		public string JDMIKEEIJFP = ""; // 0x10
		public int KIJAPOFAGPN_GlobalItemId = 0; // 0x14
		public short MHFBCINOJEE_ItemId; // 0x18
		public byte HHACNFODNEF_Category; // 0x1A
		public int JDLJPNMLFID = 0; // 0x1C

		// RVA: 0x13FBB38 Offset: 0x13FBB38 VA: 0x13FBB38
		//public string LDBPEIMINJB() { }

		// RVA: 0x13FAEB0 Offset: 0x13FAEB0 VA: 0x13FAEB0
		public void GONNICAJNLK(int EIBBIJNFMDJ, HDNKOFNBCEO_RewardInfo LIFCHFOPHDH)
		{
			KIJAPOFAGPN_GlobalItemId = LIFCHFOPHDH.FKNBLDPIPMC_GetGlobalId(EIBBIJNFMDJ);
			MHFBCINOJEE_ItemId = (short)EKLNMHFCAOI.DEACAHNLMNI_getItemId(KIJAPOFAGPN_GlobalItemId);
			HHACNFODNEF_Category = (byte)EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(KIJAPOFAGPN_GlobalItemId);
			JDLJPNMLFID = LIFCHFOPHDH.KAINPNMMAEK(EIBBIJNFMDJ);
			JDMIKEEIJFP = MessageManager.Instance.GetBank("master").GetMessageByLabel(EKLNMHFCAOI.FKMCHHDOAAB(KIJAPOFAGPN_GlobalItemId));
		}
	}

	public const int IOEPCKJCLDN = 4;
	public const int IJNFLPDLFII = 4;
	public const int HHNMEMGOECJ = 4;
	public List<LOIJICNJMKA> IOCLNNCJFKA_ClearReward; // 0x8
	public List<LOIJICNJMKA> PDONJHCHBAE_ScoreReward; // 0xC
	public List<LOIJICNJMKA> HFPMKBAANFO_ComboReward; // 0x10

	//// RVA: 0x13FA620 Offset: 0x13FA620 VA: 0x13FA620
	public void JMHCEMHPPCM(int GHBPLHBNMBK_MusicId, int AKNELONELJK_Difficulty, bool LFGNLKKFOCD_Is6Line, int MNNHHJBBICA_EventType = 0)
	{
		JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo musicInfo;
		if (MNNHHJBBICA_EventType == 4)
		{
			if(JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.AJLEDCKMFLP(KGCNCBOKCBA.GNENJEHKMHD.EMAMLLFAOJI) == null)
			{
				musicInfo = new JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo();
			}
			else
			{
				HLEBAINCOME_EventScore eventData = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.AJLEDCKMFLP(KGCNCBOKCBA.GNENJEHKMHD.EMAMLLFAOJI) as HLEBAINCOME_EventScore;
				musicInfo = eventData.JIPPHOKGLIH(false).KJAFPNIFPGP();
			}
		}
		else
		{
			musicInfo = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[GHBPLHBNMBK_MusicId - 1];
		}
		KEODKEGFDLD_FreeMusicInfo freemusicData = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(GHBPLHBNMBK_MusicId);
		int musicId = freemusicData.DLAEJOBELBH_MusicId;
		HDNKOFNBCEO_RewardInfo rewardInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NEJKJJPIGKD_GetRewardInfo(freemusicData, AKNELONELJK_Difficulty, LFGNLKKFOCD_Is6Line);
		List<byte> rewardScoreList = LFGNLKKFOCD_Is6Line ? musicInfo.DKIIINIEKHP_RewardScoreL6 : musicInfo.JDIDBMEMKBC_RewardScore;
		List<byte> rewardComboList = LFGNLKKFOCD_Is6Line ? musicInfo.JNNIOJIDNKM_RewardComboL6 : musicInfo.AGGFHNMMGMN_RewardCombo;
		List<byte> rewardClearList = LFGNLKKFOCD_Is6Line ? musicInfo.LGBKKDOLOFP_RewardClearL6 : musicInfo.HNDPLCDMOJF_RewardClear;
		ADDHLABEFKH otherInfo2 = freemusicData.EMJCHPDJHEI(LFGNLKKFOCD_Is6Line, AKNELONELJK_Difficulty);
		PDONJHCHBAE_ScoreReward = new List<LOIJICNJMKA>();
		for(int i = 0; i < 4; i++)
		{
			LOIJICNJMKA lo = new LOIJICNJMKA();
			lo.FCDKJAKLGMB_TargetValue = otherInfo2.KNIFCANOHOC_RankScore[i];
			lo.CMCKNKKCNDK_Achieved = i < rewardScoreList[AKNELONELJK_Difficulty] ? LOIJICNJMKA.KPGOMKPPJEE.FJGFAPKLLCL : LOIJICNJMKA.KPGOMKPPJEE.PCNKFALHCDA;
			lo.GONNICAJNLK(i+4, rewardInfo);
			PDONJHCHBAE_ScoreReward.Add(lo);
		}
		HFPMKBAANFO_ComboReward = new List<LOIJICNJMKA>();
		for(int i = 0; i < 4; i++)
		{
			LOIJICNJMKA lo = new LOIJICNJMKA();
			lo.FCDKJAKLGMB_TargetValue = otherInfo2.NLKEBAOBJCM_RankCombo[i];
			lo.CMCKNKKCNDK_Achieved = i < rewardComboList[AKNELONELJK_Difficulty] ? LOIJICNJMKA.KPGOMKPPJEE.FJGFAPKLLCL : LOIJICNJMKA.KPGOMKPPJEE.PCNKFALHCDA;
			lo.GONNICAJNLK(i + 8, rewardInfo);
			HFPMKBAANFO_ComboReward.Add(lo);
		}
		IOCLNNCJFKA_ClearReward = new List<LOIJICNJMKA>();
		for (int i = 0; i < 4; i++)
		{
			LOIJICNJMKA lo = new LOIJICNJMKA();
			lo.FCDKJAKLGMB_TargetValue = rewardInfo.GPBKAAMLIBF(i);
			lo.CMCKNKKCNDK_Achieved = i < rewardClearList[AKNELONELJK_Difficulty] ? LOIJICNJMKA.KPGOMKPPJEE.FJGFAPKLLCL : LOIJICNJMKA.KPGOMKPPJEE.PCNKFALHCDA;
			lo.GONNICAJNLK(i, rewardInfo);
			IOCLNNCJFKA_ClearReward.Add(lo);
		}
	}

	//// RVA: 0x13FB01C Offset: 0x13FB01C VA: 0x13FB01C
	public void CHOHLJOJKNJ(int GHBPLHBNMBK_FreeMusicId, int AKNELONELJK_Difficulty, bool LFGNLKKFOCD_IsLine6, int MNNHHJBBICA_GameEventType = 0)
	{
		BBHNACPENDM_ServerSaveData serverData = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
		BBHNACPENDM_ServerSaveData prevServerData = CIOECGOMILE.HHCJCDFCLOB.MNJHBCIIHED_PrevServerData;
		JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo musicInfo = null;
		JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo prevMusicInfo = null;
		if (MNNHHJBBICA_GameEventType == 4)
		{
			TodoLogger.LogError(0, "Event");
		}
		else
		{
			musicInfo = serverData.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[GHBPLHBNMBK_FreeMusicId - 1];
			prevMusicInfo = prevServerData.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[GHBPLHBNMBK_FreeMusicId - 1];
		}
		KEODKEGFDLD_FreeMusicInfo freeMusic = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(GHBPLHBNMBK_FreeMusicId);
		EONOEHOKBEB_Music music = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(freeMusic.DLAEJOBELBH_MusicId);
		HDNKOFNBCEO_RewardInfo rewardInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NEJKJJPIGKD_GetRewardInfo(freeMusic, AKNELONELJK_Difficulty, LFGNLKKFOCD_IsLine6);
		ADDHLABEFKH data = freeMusic.EMJCHPDJHEI(LFGNLKKFOCD_IsLine6, AKNELONELJK_Difficulty);
		List<byte> rewardScore = !LFGNLKKFOCD_IsLine6 ? musicInfo.JDIDBMEMKBC_RewardScore : musicInfo.DKIIINIEKHP_RewardScoreL6;
		List<byte> prevRewardScore = !LFGNLKKFOCD_IsLine6 ? prevMusicInfo.JDIDBMEMKBC_RewardScore : prevMusicInfo.DKIIINIEKHP_RewardScoreL6;
		PDONJHCHBAE_ScoreReward = new List<LOIJICNJMKA>(4);
		for(int i = 0; i < 4; i++)
		{
			LOIJICNJMKA data2 = new LOIJICNJMKA();
			data2.FCDKJAKLGMB_TargetValue = data.KNIFCANOHOC_RankScore[i];
			data2.CMCKNKKCNDK_Achieved = i < prevRewardScore[AKNELONELJK_Difficulty] ? LOIJICNJMKA.KPGOMKPPJEE.FJGFAPKLLCL : LOIJICNJMKA.KPGOMKPPJEE.PCNKFALHCDA;
			if(prevRewardScore[AKNELONELJK_Difficulty] <= i)
			{
				if(i < rewardScore[AKNELONELJK_Difficulty])
				{
					data2.CMCKNKKCNDK_Achieved = LOIJICNJMKA.KPGOMKPPJEE.JMAFBDCPBJD_Achieved;
				}
			}
			data2.GONNICAJNLK(i + 4, rewardInfo);
			PDONJHCHBAE_ScoreReward.Add(data2);
		}
		List<byte> rewardCombo = !LFGNLKKFOCD_IsLine6 ? musicInfo.AGGFHNMMGMN_RewardCombo : musicInfo.JNNIOJIDNKM_RewardComboL6;
		List<byte> prevRewardCombo = !LFGNLKKFOCD_IsLine6 ? prevMusicInfo.AGGFHNMMGMN_RewardCombo : prevMusicInfo.JNNIOJIDNKM_RewardComboL6;
		HFPMKBAANFO_ComboReward = new List<LOIJICNJMKA>();
		for (int i = 0; i < 4; i++)
		{
			LOIJICNJMKA data2 = new LOIJICNJMKA();
			data2.FCDKJAKLGMB_TargetValue = data.NLKEBAOBJCM_RankCombo[i];
			data2.CMCKNKKCNDK_Achieved = i < prevRewardCombo[AKNELONELJK_Difficulty] ? LOIJICNJMKA.KPGOMKPPJEE.FJGFAPKLLCL : LOIJICNJMKA.KPGOMKPPJEE.PCNKFALHCDA;
			if (prevRewardCombo[AKNELONELJK_Difficulty] <= i)
			{
				if (i < rewardCombo[AKNELONELJK_Difficulty])
				{
					data2.CMCKNKKCNDK_Achieved = LOIJICNJMKA.KPGOMKPPJEE.JMAFBDCPBJD_Achieved;
				}
			}
			data2.GONNICAJNLK(i + 8, rewardInfo);
			HFPMKBAANFO_ComboReward.Add(data2);
		}
		List<byte> rewardClear = !LFGNLKKFOCD_IsLine6 ? musicInfo.HNDPLCDMOJF_RewardClear : musicInfo.LGBKKDOLOFP_RewardClearL6;
		List<byte> prevRewardClear = !LFGNLKKFOCD_IsLine6 ? prevMusicInfo.HNDPLCDMOJF_RewardClear : prevMusicInfo.LGBKKDOLOFP_RewardClearL6;
		IOCLNNCJFKA_ClearReward = new List<LOIJICNJMKA>();
		for (int i = 0; i < 4; i++)
		{
			LOIJICNJMKA data2 = new LOIJICNJMKA();
			data2.FCDKJAKLGMB_TargetValue = rewardInfo.GPBKAAMLIBF(i);
			data2.CMCKNKKCNDK_Achieved = i < prevRewardClear[AKNELONELJK_Difficulty] ? LOIJICNJMKA.KPGOMKPPJEE.FJGFAPKLLCL : LOIJICNJMKA.KPGOMKPPJEE.PCNKFALHCDA;
			if (prevRewardClear[AKNELONELJK_Difficulty] <= i)
			{
				if (i < rewardClear[AKNELONELJK_Difficulty])
				{
					data2.CMCKNKKCNDK_Achieved = LOIJICNJMKA.KPGOMKPPJEE.JMAFBDCPBJD_Achieved;
				}
			}
			data2.GONNICAJNLK(i, rewardInfo);
			IOCLNNCJFKA_ClearReward.Add(data2);
		}
	}

	//// RVA: 0x13FBAD4 Offset: 0x13FBAD4 VA: 0x13FBAD4
	//public string LDBPEIMINJB() { }
}
