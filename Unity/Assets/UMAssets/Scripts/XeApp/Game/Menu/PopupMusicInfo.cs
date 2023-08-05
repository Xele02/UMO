using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupMusicInfo : UIBehaviour, IPopupContent
	{
		private EEDKAACNBBG_MusicData m_data = new EEDKAACNBBG_MusicData(); // 0x10
		private int m_musicId; // 0x14
		private bool m_flameDisplay; // 0x18
		private bool m_isValidMusicUrl; // 0x19
		private MusicInfoWindow m_musicWindow; // 0x1C

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x16961D8 Offset: 0x16961D8 VA: 0x16961D8 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			MusicInfoPopupSetting s = setting as MusicInfoPopupSetting;
			m_musicId = s.musicId;
			Parent = setting.m_parent;
			m_flameDisplay = s.flameDisplay;
			m_isValidMusicUrl = s.isValidMusicUrl;
			m_data.KHEKNNFCAOI(m_musicId);
			gameObject.SetActive(true);
			transform.localPosition = Vector3.zero;
			m_musicWindow = transform.GetComponent<MusicInfoWindow>();
			m_musicWindow.SetActiveFlame(m_flameDisplay);
			m_musicWindow.SetMusicBuyButtonEnable(!m_flameDisplay && m_isValidMusicUrl);
			m_musicWindow.SetMusicData(m_data, m_flameDisplay == false);
			m_musicWindow.OnClickMusicButton = s.onClickMusicButton;
		}

		// RVA: 0x169652C Offset: 0x169652C VA: 0x169652C Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1696534 Offset: 0x1696534 VA: 0x1696534 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x169656C Offset: 0x169656C VA: 0x169656C Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x16965A4 Offset: 0x16965A4 VA: 0x16965A4 Slot: 21
		public bool IsReady()
		{
			if(m_musicWindow.IsLoaded() && !m_musicWindow.IsLoading())
			{
				m_musicWindow.Enter();
				return true;
			}
			return false;
		}

		// RVA: 0x1696634 Offset: 0x1696634 VA: 0x1696634 Slot: 22
		public void CallOpenEnd()
		{
			m_musicWindow.CallOpenEnd();
		}
	}
}
