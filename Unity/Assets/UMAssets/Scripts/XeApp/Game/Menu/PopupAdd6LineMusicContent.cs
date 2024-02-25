using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupAdd6LineMusicContent : UIBehaviour, IPopupContent
	{
		private LayoutPopAdd6LineMusic m_layout; // 0x10

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x132DF54 Offset: 0x132DF54 VA: 0x132DF54 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupAdd6LineMusicSetting s = setting as PopupAdd6LineMusicSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			m_layout = setting.Content.GetComponent<LayoutPopAdd6LineMusic>();
			if(m_layout != null)
			{
				m_layout.SetStatus(s.UnlockInfo);
			}
		}

		// RVA: 0x132E180 Offset: 0x132E180 VA: 0x132E180 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x132E188 Offset: 0x132E188 VA: 0x132E188
		public void Update()
		{
			return;
		}

		// RVA: 0x132E18C Offset: 0x132E18C VA: 0x132E18C Slot: 19
		public void Show()
		{
			if(m_layout != null)
				m_layout.Show();
			gameObject.SetActive(true);
		}

		// RVA: 0x132E270 Offset: 0x132E270 VA: 0x132E270 Slot: 20
		public void Hide()
		{
			if(m_layout != null)
				m_layout.Hide();
			gameObject.SetActive(false);
		}

		// RVA: 0x132E354 Offset: 0x132E354 VA: 0x132E354 Slot: 21
		public bool IsReady()
		{
			return m_layout == null || !m_layout.IsLoading();
		}

		// RVA: 0x132E414 Offset: 0x132E414 VA: 0x132E414 Slot: 22
		public void CallOpenEnd()
		{
			if(m_layout != null)
				m_layout.TitleAnimPlay();
		}
	}
}
