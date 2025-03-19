namespace XeApp.Game.Menu
{
	public class MusicRewardStat
	{
		public int achievedScoreNum { get; private set; } = 0; // 0x8
		public int achievedComboNum { get; private set; } = 0; // 0xC
		public int achievedClearCountNum { get; private set; } = 0; // 0x10
		public int allAchievedNum { get; private set; } = 0; // 0x14
		public int allRewardNum { get; private set; } = 0; // 0x18
		public bool isScoreComplete { get; private set; } = false; // 0x1C
		public bool isComboComplete { get; private set; } = false; // 0x1D
		public bool isClearCountComplete { get; private set; } = false; // 0x1E
		public bool isAllComplete { get; private set; } = false; // 0x1F

		public MusicRewardStat()
		{
			return;
		}

		//// RVA: 0x1054754 Offset: 0x1054754 VA: 0x1054754
		public MusicRewardStat(FPGEMAIAMBF_RewardData rewardData)
		{
			Init(rewardData);
		}

		//// RVA: 0x1054738 Offset: 0x1054738 VA: 0x1054738
		public void Clear()
		{
			allRewardNum = 0;
			isScoreComplete = false;
			isComboComplete = false;
			achievedScoreNum = 0;
			achievedComboNum = 0;
			achievedClearCountNum = 0;
			allAchievedNum = 0;
		}

		//// RVA: 0x105477C Offset: 0x105477C VA: 0x105477C
		public void Init(FPGEMAIAMBF_RewardData rewardData)
		{
			achievedScoreNum = 0;
			achievedComboNum = 0;
			achievedClearCountNum = 0;
			for(int i = 0; i < rewardData.PDONJHCHBAE_ScoreReward.Count; i++)
			{
				if(rewardData.PDONJHCHBAE_ScoreReward[i].CMCKNKKCNDK_Achieved != 0)
				{
					achievedScoreNum++;
				}
			}
			for (int i = 0; i < rewardData.HFPMKBAANFO_ComboReward.Count; i++)
			{
				if (rewardData.HFPMKBAANFO_ComboReward[i].CMCKNKKCNDK_Achieved != 0)
				{
					achievedComboNum++;
				}
			}
			for (int i = 0; i < rewardData.IOCLNNCJFKA_ClearReward.Count; i++)
			{
				if (rewardData.IOCLNNCJFKA_ClearReward[i].CMCKNKKCNDK_Achieved != 0)
				{
					achievedClearCountNum++;
				}
			}
			allRewardNum = 12;
			isAllComplete = achievedScoreNum == 4 && achievedClearCountNum == 4 && achievedComboNum == 4;
			allAchievedNum = achievedScoreNum + achievedClearCountNum + achievedComboNum;
			isScoreComplete = achievedScoreNum == 4;
			isComboComplete = achievedComboNum == 4;
			isClearCountComplete = achievedClearCountNum == 4;
		}
	}
}
