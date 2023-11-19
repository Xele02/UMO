using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupQuestRewardContent : UIBehaviour, IPopupContent
	{
		private LayoutPopupQuestReward m_reward; // 0x10

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x1611550 Offset: 0x1611550 VA: 0x1611550 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupQuestRewardSetting s = setting as PopupQuestRewardSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			m_reward = GetComponent<LayoutPopupQuestReward>();
			if(m_reward != null)
				m_reward.SetStatus(s.ItemInfo);
			gameObject.SetActive(true);
		}

		// RVA: 0x1611784 Offset: 0x1611784 VA: 0x1611784 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x161178C Offset: 0x161178C VA: 0x161178C
		public void Update()
		{
			return;
		}

		// RVA: 0x1611790 Offset: 0x1611790 VA: 0x1611790 Slot: 19
		public void Show()
		{
			if(m_reward != null)
				m_reward.Show();
			gameObject.SetActive(true);
		}

		// RVA: 0x1611874 Offset: 0x1611874 VA: 0x1611874 Slot: 20
		public void Hide()
		{
			if(m_reward != null)
				m_reward.Hide();
			gameObject.SetActive(false);
		}

		// RVA: 0x1611958 Offset: 0x1611958 VA: 0x1611958 Slot: 21
		public bool IsReady()
		{
			return m_reward != null && !m_reward.IsLoading();
		}

		// RVA: 0x1611A18 Offset: 0x1611A18 VA: 0x1611A18 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
