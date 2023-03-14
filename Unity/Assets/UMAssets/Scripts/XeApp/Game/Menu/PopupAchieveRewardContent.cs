using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupAchieveRewardContent : UIBehaviour, IPopupContent
	{
		private LayoutPopupAchieveReward m_achieveReward; // 0x10
		private IBJAKJJICBC m_viewMusic = new IBJAKJJICBC(); // 0x14
		private bool m_viewInitialized; // 0x18
		private bool m_initialized; // 0x19
		private PopupWindowControl m_popupControl; // 0x1C
		private List<IEnumerator> m_updateList = new List<IEnumerator>(); // 0x20
		private bool isTutorialWait; // 0x24
		private FPGEMAIAMBF_RewardData m_viewFreeReward; // 0x28

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0xDF09B4 Offset: 0xDF09B4 VA: 0xDF09B4 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			TodoLogger.Log(0, "Implement PopupAchieveRewardContent");
		}

		//// RVA: 0xDF116C Offset: 0xDF116C VA: 0xDF116C
		//private void ViewInitialize(PopupAchieveRewardSetting setup) { }

		//// RVA: 0xDF1610 Offset: 0xDF1610 VA: 0xDF1610
		//private void GetAchieveNowRewardList(PopupAchieveRewardDetailSetting setting) { }

		// RVA: 0xDF1A04 Offset: 0xDF1A04 VA: 0xDF1A04 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x707424 Offset: 0x707424 VA: 0x707424
		//// RVA: 0xDF13EC Offset: 0xDF13EC VA: 0xDF13EC
		//private IEnumerator PlayStampAnim() { }

		//[IteratorStateMachineAttribute] // RVA: 0x70749C Offset: 0x70749C VA: 0x70749C
		//// RVA: 0xDF1478 Offset: 0xDF1478 VA: 0xDF1478
		//private IEnumerator StampAnimSkip() { }

		//[IteratorStateMachineAttribute] // RVA: 0x707514 Offset: 0x707514 VA: 0x707514
		//// RVA: 0xDF1500 Offset: 0xDF1500 VA: 0xDF1500
		//private IEnumerator PopupRewardDetail() { }

		//[IteratorStateMachineAttribute] // RVA: 0x70758C Offset: 0x70758C VA: 0x70758C
		//// RVA: 0xDF1588 Offset: 0xDF1588 VA: 0xDF1588
		//private IEnumerator TryShowTutorial() { }

		//[IteratorStateMachineAttribute] // RVA: 0x707604 Offset: 0x707604 VA: 0x707604
		//// RVA: 0xDF1A2C Offset: 0xDF1A2C VA: 0xDF1A2C
		//private IEnumerator Co_Tutorial() { }

		// RVA: 0xDF1AD8 Offset: 0xDF1AD8 VA: 0xDF1AD8
		public void Update()
		{
			TodoLogger.Log(0, "Update");
		}

		// RVA: 0xDF1C50 Offset: 0xDF1C50 VA: 0xDF1C50 Slot: 19
		public void Show()
		{
			TodoLogger.Log(0, "Show");
		}

		// RVA: 0xDF1D34 Offset: 0xDF1D34 VA: 0xDF1D34 Slot: 20
		public void Hide()
		{
			TodoLogger.Log(0, "Hide");
		}

		// RVA: 0xDF1E18 Offset: 0xDF1E18 VA: 0xDF1E18 Slot: 21
		public bool IsReady()
		{
			TodoLogger.Log(0, "Isready");
			return true;
		}

		// RVA: 0xDF1F54 Offset: 0xDF1F54 VA: 0xDF1F54 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}

		//// RVA: 0xDF1F58 Offset: 0xDF1F58 VA: 0xDF1F58
		public static bool CheckAchieve(FPGEMAIAMBF_RewardData viewFreeRewardData)
		{
			for(int i = 0; i < viewFreeRewardData.IOCLNNCJFKA_ClearReward.Count; i++)
			{
				if (viewFreeRewardData.IOCLNNCJFKA_ClearReward[i].CMCKNKKCNDK_Achieved == FPGEMAIAMBF_RewardData.LOIJICNJMKA.KPGOMKPPJEE.JMAFBDCPBJD_Achieved)
					return true;
			}
			for (int i = 0; i < viewFreeRewardData.PDONJHCHBAE_ScoreReward.Count; i++)
			{
				if (viewFreeRewardData.PDONJHCHBAE_ScoreReward[i].CMCKNKKCNDK_Achieved == FPGEMAIAMBF_RewardData.LOIJICNJMKA.KPGOMKPPJEE.JMAFBDCPBJD_Achieved)
					return true;
			}
			for (int i = 0; i < viewFreeRewardData.HFPMKBAANFO_ComboReward.Count; i++)
			{
				if (viewFreeRewardData.HFPMKBAANFO_ComboReward[i].CMCKNKKCNDK_Achieved == FPGEMAIAMBF_RewardData.LOIJICNJMKA.KPGOMKPPJEE.JMAFBDCPBJD_Achieved)
					return true;
			}
			return false;
		}

		//// RVA: 0xDF216C Offset: 0xDF216C VA: 0xDF216C
		//private bool CheckTutorialCondition(TutorialConditionId id) { }
	}
}
