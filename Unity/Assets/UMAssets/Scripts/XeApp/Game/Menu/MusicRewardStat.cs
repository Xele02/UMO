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
		public MusicRewardStat(FPGEMAIAMBF rewardData)
		{
			Init(rewardData);
		}

		//// RVA: 0x1054738 Offset: 0x1054738 VA: 0x1054738
		//public void Clear() { }

		//// RVA: 0x105477C Offset: 0x105477C VA: 0x105477C
		public void Init(FPGEMAIAMBF rewardData)
		{
			achievedScoreNum = 0;
			achievedComboNum = 0;
			achievedClearCountNum = 0;
			for(int i = 0; i < rewardData.PDONJHCHBAE.Count; i++)
			{
				if(rewardData.PDONJHCHBAE[i].CMCKNKKCNDK != 0)
				{
					achievedScoreNum++;
				}
			}
			for (int i = 0; i < rewardData.HFPMKBAANFO.Count; i++)
			{
				if (rewardData.HFPMKBAANFO[i].CMCKNKKCNDK != 0)
				{
					achievedComboNum++;
				}
			}
			for (int i = 0; i < rewardData.IOCLNNCJFKA.Count; i++)
			{
				if (rewardData.IOCLNNCJFKA[i].CMCKNKKCNDK != 0)
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
