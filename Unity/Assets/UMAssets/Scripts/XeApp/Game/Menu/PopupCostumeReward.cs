using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupCostumeReward : UIBehaviour, IPopupContent
	{
		private LFAFJCNKLML m_CostumeData; // 0x10
		private CostumeRewardWindow m_rewardWindow; // 0x14

		public Transform Parent { get; private set; } // 0xC 
		private CostumeRewardWindow RewardWindow { get
			{
				if (m_rewardWindow == null)
					m_rewardWindow = GetComponent<CostumeRewardWindow>();
				return m_rewardWindow;
			}
		} //0x1343E0C

		// RVA: 0x1343EC0 Offset: 0x1343EC0 VA: 0x1343EC0 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			CostumeRewardPopupSetting s = setting as CostumeRewardPopupSetting;
			Parent = setting.m_parent;
			m_CostumeData = s.CostumeData;
			gameObject.SetActive(true);
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			RewardWindow.ResetScrollPosition();
		}

		// RVA: 0x13440FC Offset: 0x13440FC VA: 0x13440FC Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1344104 Offset: 0x1344104 VA: 0x1344104 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
			RewardWindow.Enter(m_CostumeData);
		}

		// RVA: 0x1344170 Offset: 0x1344170 VA: 0x1344170 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x13441A8 Offset: 0x13441A8 VA: 0x13441A8 Slot: 21
		public bool IsReady()
		{
			return RewardWindow.IsInitialized;
		}

		// RVA: 0x13441D8 Offset: 0x13441D8 VA: 0x13441D8 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
