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
			m_popupControl = control;
			PopupAchieveRewardSetting s = setting as PopupAchieveRewardSetting;
			m_viewFreeReward = s.viewFreeReward;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = new Vector3(0, 0, 0);
			gameObject.SetActive(true);
			if(m_achieveReward == null)
			{
				m_achieveReward = setting.Content.GetComponent<LayoutPopupAchieveReward>();
			}
			if(s.gameEventType == 4)
			{
				TodoLogger.Log(0, "PopupAchieveRewardContent Init Event");
			}
			m_viewMusic.KHEKNNFCAOI(s.selectFreeMusicId, false, 0, 0, 0, s.diff == Difficulty.Type.Extreme, false);
			//LAB_00df0d5c
			ViewInitialize(s);
			if(s.mode == LayoutPopupAchieveReward.eMode.Result)
			{
				m_updateList.Clear();
				m_updateList.Add(PlayStampAnim());
				m_updateList.Add(StampAnimSkip());
				m_updateList.Add(PopupRewardDetail());
				m_updateList.Add(TryShowTutorial());
			}
			if(m_achieveReward != null)
			{
				m_achieveReward.SetupReward(Database.Instance.musicText.Get(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.INJDLHAEPEK_GetMusicInfo(m_viewMusic.GHBPLHBNMBK_FreeMusicId, m_viewMusic.DLAEJOBELBH_MusicId).KNMGEEFGDNI_Nam).musicName,
					(int)s.diff, m_viewFreeReward, m_viewMusic, s.isLine6Mode);
			}
			m_initialized = true;
		}

		//// RVA: 0xDF116C Offset: 0xDF116C VA: 0xDF116C
		private void ViewInitialize(PopupAchieveRewardSetting setup)
		{
			if(setup.selectMusicId > 0)
			{
				m_viewInitialized = true;
				if(m_viewFreeReward == null)
				{
					m_viewFreeReward = new FPGEMAIAMBF_RewardData();
					if(setup.mode == LayoutPopupAchieveReward.eMode.Result)
					{
						m_viewFreeReward.CHOHLJOJKNJ(setup.selectFreeMusicId, (int)setup.diff, setup.isLine6Mode, setup.gameEventType);
					}
					else if(setup.mode == LayoutPopupAchieveReward.eMode.MusicSelect)
					{
						m_viewFreeReward.JMHCEMHPPCM(setup.selectFreeMusicId, (int)setup.diff, setup.isLine6Mode, setup.gameEventType);
					}
				}
			}
		}

		//// RVA: 0xDF1610 Offset: 0xDF1610 VA: 0xDF1610
		//private void GetAchieveNowRewardList(PopupAchieveRewardDetailSetting setting) { }

		// RVA: 0xDF1A04 Offset: 0xDF1A04 VA: 0xDF1A04 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x707424 Offset: 0x707424 VA: 0x707424
		//// RVA: 0xDF13EC Offset: 0xDF13EC VA: 0xDF13EC
		private IEnumerator PlayStampAnim()
		{
			//0xDF24A4
			while (!IsReady())
				yield return null;
			yield return null;
			while (!m_popupControl.IsOpenPopupWindow())
				yield return null;
			yield return null;
			if(m_achieveReward != null)
			{
				m_achieveReward.PlayStampAnim();
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70749C Offset: 0x70749C VA: 0x70749C
		//// RVA: 0xDF1478 Offset: 0xDF1478 VA: 0xDF1478
		private IEnumerator StampAnimSkip()
		{
			//0x132BDBC
			if(m_achieveReward != null)
			{
				while(!m_achieveReward.IsEndAllPlayStampAnim())
				{
					if(ResultScene.GetInScreenTouchCount() > 0 && !ResultScene.IsScreenTouch())
					{
						m_achieveReward.PlayStampSkip();
					}
					yield return null;
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x707514 Offset: 0x707514 VA: 0x707514
		//// RVA: 0xDF1500 Offset: 0xDF1500 VA: 0xDF1500
		private IEnumerator PopupRewardDetail()
		{
			TodoLogger.Log(0, "PopupRewardDetail");
			yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70758C Offset: 0x70758C VA: 0x70758C
		//// RVA: 0xDF1588 Offset: 0xDF1588 VA: 0xDF1588
		private IEnumerator TryShowTutorial()
		{
			TodoLogger.Log(0, "TryShowTutorial");
			yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x707604 Offset: 0x707604 VA: 0x707604
		//// RVA: 0xDF1A2C Offset: 0xDF1A2C VA: 0xDF1A2C
		//private IEnumerator Co_Tutorial() { }

		// RVA: 0xDF1AD8 Offset: 0xDF1AD8 VA: 0xDF1AD8
		public void Update()
		{
			if(m_updateList.Count > 0)
			{
				if (!m_updateList[0].MoveNext())
					m_updateList.RemoveAt(0);
			}
		}

		// RVA: 0xDF1C50 Offset: 0xDF1C50 VA: 0xDF1C50 Slot: 19
		public void Show()
		{
			if(m_achieveReward != null)
			{
				m_achieveReward.Show();
			}
			gameObject.SetActive(true);
		}

		// RVA: 0xDF1D34 Offset: 0xDF1D34 VA: 0xDF1D34 Slot: 20
		public void Hide()
		{
			TodoLogger.Log(0, "Hide");
		}

		// RVA: 0xDF1E18 Offset: 0xDF1E18 VA: 0xDF1E18 Slot: 21
		public bool IsReady()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning && !GameManager.Instance.ItemTextureCache.IsLoading() && m_initialized;
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
