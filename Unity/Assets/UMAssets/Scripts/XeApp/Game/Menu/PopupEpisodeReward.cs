using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupEpisodeReward : UIBehaviour, IPopupContent
	{
		private int m_episodeId; // 0x10
		private EpisodeRewardWindow m_rewardWindow; // 0x14

		public Transform Parent { get; private set; } // 0xC
		private EpisodeRewardWindow RewardWindow { get
			{
				if (m_rewardWindow == null)
					m_rewardWindow = GetComponent<EpisodeRewardWindow>();
				return m_rewardWindow;
			}
		} //0xF8BB70

		// RVA: 0xF8BC24 Offset: 0xF8BC24 VA: 0xF8BC24 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			EpisodeRewardPopupSetting s = setting as EpisodeRewardPopupSetting;
			Parent = setting.m_parent;
			m_episodeId = s.episodeId;
			gameObject.SetActive(true);
			transform.localPosition = Vector3.zero;
			RewardWindow.ResetScrollPosition();
		}

		// RVA: 0xF8BDFC Offset: 0xF8BDFC VA: 0xF8BDFC Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xF8BE04 Offset: 0xF8BE04 VA: 0xF8BE04 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
			RewardWindow.Enter(m_episodeId);
		}

		// RVA: 0xF8BE70 Offset: 0xF8BE70 VA: 0xF8BE70 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0xF8BEA8 Offset: 0xF8BEA8 VA: 0xF8BEA8 Slot: 21
		public bool IsReady()
		{
			return RewardWindow.IsInitialized;
		}

		// RVA: 0xF8BED8 Offset: 0xF8BED8 VA: 0xF8BED8 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
