using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupAddMultiDivaMusicContent : UIBehaviour, IPopupContent
	{
		private LayoutPopAddMultiDivaMusic m_multiDivaLive; // 0x10

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x133087C Offset: 0x133087C VA: 0x133087C Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupAddMultiDivaMusicSetting s = setting as PopupAddMultiDivaMusicSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			m_multiDivaLive = setting.Content.GetComponent<LayoutPopAddMultiDivaMusic>();
			if(m_multiDivaLive != null)
			{
				m_multiDivaLive.SetStatus(s.UnlockInfo);
			}
		}

		// RVA: 0x1330AA8 Offset: 0x1330AA8 VA: 0x1330AA8 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1330AB0 Offset: 0x1330AB0 VA: 0x1330AB0
		public void Update()
		{
			return;
		}

		// RVA: 0x1330AB4 Offset: 0x1330AB4 VA: 0x1330AB4 Slot: 19
		public void Show()
		{
			if(m_multiDivaLive != null)
				m_multiDivaLive.Show();
			gameObject.SetActive(true);
		}

		// RVA: 0x1330B98 Offset: 0x1330B98 VA: 0x1330B98 Slot: 20
		public void Hide()
		{
			if(m_multiDivaLive != null)
				m_multiDivaLive.Hide();
			gameObject.SetActive(false);
		}

		// RVA: 0x1330C7C Offset: 0x1330C7C VA: 0x1330C7C Slot: 21
		public bool IsReady()
		{
			return m_multiDivaLive == null || !m_multiDivaLive.IsLoading();
		}

		// RVA: 0x1330D3C Offset: 0x1330D3C VA: 0x1330D3C Slot: 22
		public void CallOpenEnd()
		{
			if(m_multiDivaLive != null)
				m_multiDivaLive.TitleAnimPlay();
		}
	}
}
