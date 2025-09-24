
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
		public KPGOMKPPJEE CMCKNKKCNDK_status; // 0xC
		public string JDMIKEEIJFP = ""; // 0x10
		public int KIJAPOFAGPN_ItemId = 0; // 0x14
		public short MHFBCINOJEE_Num; // 0x18 ItemId
		public byte HHACNFODNEF_ItemCategory; // 0x1A
		public int JDLJPNMLFID_ItemCount = 0; // 0x1C

		// RVA: 0x13FBB38 Offset: 0x13FBB38 VA: 0x13FBB38
		//public string LDBPEIMINJB() { }

		// RVA: 0x13FAEB0 Offset: 0x13FAEB0 VA: 0x13FAEB0
		public void GONNICAJNLK(int EIBBIJNFMDJ, HDNKOFNBCEO_RewardInfo LIFCHFOPHDH)
		{
			KIJAPOFAGPN_ItemId = LIFCHFOPHDH.FKNBLDPIPMC_GetGlobalId(EIBBIJNFMDJ);
			MHFBCINOJEE_Num = (short)EKLNMHFCAOI.DEACAHNLMNI_getItemId(KIJAPOFAGPN_ItemId);
			HHACNFODNEF_ItemCategory = (byte)EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(KIJAPOFAGPN_ItemId);
			JDLJPNMLFID_ItemCount = LIFCHFOPHDH.KAINPNMMAEK(EIBBIJNFMDJ);
			JDMIKEEIJFP = MessageManager.Instance.GetBank("master").GetMessageByLabel(EKLNMHFCAOI.FKMCHHDOAAB(KIJAPOFAGPN_ItemId));
		}
	}

	public const int IOEPCKJCLDN = 4;
	public const int IJNFLPDLFII = 4;
	public const int HHNMEMGOECJ = 4;
	public List<LOIJICNJMKA> IOCLNNCJFKA_ClearReward; // 0x8
	public List<LOIJICNJMKA> PDONJHCHBAE_ScoreReward; // 0xC
	public List<LOIJICNJMKA> HFPMKBAANFO_ComboReward; // 0x10

	//// RVA: 0x13FA620 Offset: 0x13FA620 VA: 0x13FA620
	public void JMHCEMHPPCM(int _GHBPLHBNMBK_FreeMusicId, int AKNELONELJK_difficulty, bool _LFGNLKKFOCD_IsLine6, int _MNNHHJBBICA_GameEventType/* = 0*/)
	{
		JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo musicInfo;
		if (_MNNHHJBBICA_GameEventType == 4)
		{
			if(JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.AJLEDCKMFLP_GetEventScore(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6) == null)
			{
				musicInfo = new JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo();
			}
			else
			{
				HLEBAINCOME_EventScore eventData = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.AJLEDCKMFLP_GetEventScore(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6) as HLEBAINCOME_EventScore;
				musicInfo = eventData.JIPPHOKGLIH(false).KJAFPNIFPGP();
			}
		}
		else
		{
			musicInfo = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[_GHBPLHBNMBK_FreeMusicId - 1];
		}
		KEODKEGFDLD_FreeMusicInfo freemusicData = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(_GHBPLHBNMBK_FreeMusicId);
		int musicId = freemusicData.DLAEJOBELBH_MusicId;
		HDNKOFNBCEO_RewardInfo rewardInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NEJKJJPIGKD_GetRewardInfo(freemusicData, AKNELONELJK_difficulty, _LFGNLKKFOCD_IsLine6);
		List<byte> rewardScoreList = _LFGNLKKFOCD_IsLine6 ? musicInfo.DKIIINIEKHP_RewardScoreL6 : musicInfo.JDIDBMEMKBC_RewardScore;
		List<byte> rewardComboList = _LFGNLKKFOCD_IsLine6 ? musicInfo.JNNIOJIDNKM_RewardComboL6 : musicInfo.AGGFHNMMGMN_RewardCombo;
		List<byte> rewardClearList = _LFGNLKKFOCD_IsLine6 ? musicInfo.LGBKKDOLOFP_RewardClearL6 : musicInfo.HNDPLCDMOJF_RewardClear;
		ADDHLABEFKH otherInfo2 = freemusicData.EMJCHPDJHEI(_LFGNLKKFOCD_IsLine6, AKNELONELJK_difficulty);
		PDONJHCHBAE_ScoreReward = new List<LOIJICNJMKA>();
		for(int i = 0; i < 4; i++)
		{
			LOIJICNJMKA lo = new LOIJICNJMKA();
			lo.FCDKJAKLGMB_TargetValue = otherInfo2.KNIFCANOHOC_score[i];
			lo.CMCKNKKCNDK_status = i < rewardScoreList[AKNELONELJK_difficulty] ? LOIJICNJMKA.KPGOMKPPJEE.FJGFAPKLLCL : LOIJICNJMKA.KPGOMKPPJEE.PCNKFALHCDA;
			lo.GONNICAJNLK(i+4, rewardInfo);
			PDONJHCHBAE_ScoreReward.Add(lo);
		}
		HFPMKBAANFO_ComboReward = new List<LOIJICNJMKA>();
		for(int i = 0; i < 4; i++)
		{
			LOIJICNJMKA lo = new LOIJICNJMKA();
			lo.FCDKJAKLGMB_TargetValue = otherInfo2.NLKEBAOBJCM_combo[i];
			lo.CMCKNKKCNDK_status = i < rewardComboList[AKNELONELJK_difficulty] ? LOIJICNJMKA.KPGOMKPPJEE.FJGFAPKLLCL : LOIJICNJMKA.KPGOMKPPJEE.PCNKFALHCDA;
			lo.GONNICAJNLK(i + 8, rewardInfo);
			HFPMKBAANFO_ComboReward.Add(lo);
		}
		IOCLNNCJFKA_ClearReward = new List<LOIJICNJMKA>();
		for (int i = 0; i < 4; i++)
		{
			LOIJICNJMKA lo = new LOIJICNJMKA();
			lo.FCDKJAKLGMB_TargetValue = rewardInfo.GPBKAAMLIBF(i);
			lo.CMCKNKKCNDK_status = i < rewardClearList[AKNELONELJK_difficulty] ? LOIJICNJMKA.KPGOMKPPJEE.FJGFAPKLLCL : LOIJICNJMKA.KPGOMKPPJEE.PCNKFALHCDA;
			lo.GONNICAJNLK(i, rewardInfo);
			IOCLNNCJFKA_ClearReward.Add(lo);
		}
	}

	//// RVA: 0x13FB01C Offset: 0x13FB01C VA: 0x13FB01C
	public void CHOHLJOJKNJ(int GHBPLHBNMBK_FreeMusicId, int AKNELONELJK_difficulty, bool LFGNLKKFOCD_IsLine6, int _MNNHHJBBICA_GameEventType/* = 0*/)
	{
		BBHNACPENDM_ServerSaveData serverData = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData;
		BBHNACPENDM_ServerSaveData prevServerData = CIOECGOMILE.HHCJCDFCLOB.MNJHBCIIHED_PrevServerData;
		JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo musicInfo = null;
		JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo prevMusicInfo = null;
		if (_MNNHHJBBICA_GameEventType == 4)
		{
			HLEBAINCOME_EventScore ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.AJLEDCKMFLP_GetEventScore(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6) as HLEBAINCOME_EventScore;
			if(ev != null)
			{
				musicInfo = ev.JIPPHOKGLIH(false).KJAFPNIFPGP();
				prevMusicInfo = ev.JIPPHOKGLIH(true).KJAFPNIFPGP();
			}
			else
			{
				musicInfo = new JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo();
				prevMusicInfo = new JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo();
			}
		}
		else
		{
			musicInfo = serverData.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[GHBPLHBNMBK_FreeMusicId - 1];
			prevMusicInfo = prevServerData.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[GHBPLHBNMBK_FreeMusicId - 1];
		}
		KEODKEGFDLD_FreeMusicInfo freeMusic = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(GHBPLHBNMBK_FreeMusicId);
		EONOEHOKBEB_Music music = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(freeMusic.DLAEJOBELBH_MusicId);
		HDNKOFNBCEO_RewardInfo rewardInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NEJKJJPIGKD_GetRewardInfo(freeMusic, AKNELONELJK_difficulty, LFGNLKKFOCD_IsLine6);
		ADDHLABEFKH data = freeMusic.EMJCHPDJHEI(LFGNLKKFOCD_IsLine6, AKNELONELJK_difficulty);
		List<byte> rewardScore = !LFGNLKKFOCD_IsLine6 ? musicInfo.JDIDBMEMKBC_RewardScore : musicInfo.DKIIINIEKHP_RewardScoreL6;
		List<byte> prevRewardScore = !LFGNLKKFOCD_IsLine6 ? prevMusicInfo.JDIDBMEMKBC_RewardScore : prevMusicInfo.DKIIINIEKHP_RewardScoreL6;
		PDONJHCHBAE_ScoreReward = new List<LOIJICNJMKA>(4);
		for(int i = 0; i < 4; i++)
		{
			LOIJICNJMKA data2 = new LOIJICNJMKA();
			data2.FCDKJAKLGMB_TargetValue = data.KNIFCANOHOC_score[i];
			data2.CMCKNKKCNDK_status = i < prevRewardScore[AKNELONELJK_difficulty] ? LOIJICNJMKA.KPGOMKPPJEE.FJGFAPKLLCL : LOIJICNJMKA.KPGOMKPPJEE.PCNKFALHCDA;
			if(prevRewardScore[AKNELONELJK_difficulty] <= i)
			{
				if(i < rewardScore[AKNELONELJK_difficulty])
				{
					data2.CMCKNKKCNDK_status = LOIJICNJMKA.KPGOMKPPJEE.JMAFBDCPBJD_Achieved;
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
			data2.FCDKJAKLGMB_TargetValue = data.NLKEBAOBJCM_combo[i];
			data2.CMCKNKKCNDK_status = i < prevRewardCombo[AKNELONELJK_difficulty] ? LOIJICNJMKA.KPGOMKPPJEE.FJGFAPKLLCL : LOIJICNJMKA.KPGOMKPPJEE.PCNKFALHCDA;
			if (prevRewardCombo[AKNELONELJK_difficulty] <= i)
			{
				if (i < rewardCombo[AKNELONELJK_difficulty])
				{
					data2.CMCKNKKCNDK_status = LOIJICNJMKA.KPGOMKPPJEE.JMAFBDCPBJD_Achieved;
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
			data2.CMCKNKKCNDK_status = i < prevRewardClear[AKNELONELJK_difficulty] ? LOIJICNJMKA.KPGOMKPPJEE.FJGFAPKLLCL : LOIJICNJMKA.KPGOMKPPJEE.PCNKFALHCDA;
			if (prevRewardClear[AKNELONELJK_difficulty] <= i)
			{
				if (i < rewardClear[AKNELONELJK_difficulty])
				{
					data2.CMCKNKKCNDK_status = LOIJICNJMKA.KPGOMKPPJEE.JMAFBDCPBJD_Achieved;
				}
			}
			data2.GONNICAJNLK(i, rewardInfo);
			IOCLNNCJFKA_ClearReward.Add(data2);
		}
	}

	//// RVA: 0x13FBAD4 Offset: 0x13FBAD4 VA: 0x13FBAD4
	//public string LDBPEIMINJB() { }
}
