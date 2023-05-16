using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupAddEpisodeContent : UIBehaviour, IPopupContent
	{
		private LayoutPopupAddEpisode m_episode; // 0x10

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x132E748 Offset: 0x132E748 VA: 0x132E748 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupAddEpisodeContentSetting s = setting as PopupAddEpisodeContentSetting;
			Parent = setting.m_parent;
			transform.localPosition = Vector3.zero;
			m_episode = GetComponent<LayoutPopupAddEpisode>();
			if(m_episode != null)
			{
				m_episode.SetStatus(s.EpisodeId, s.Type);
			}
			gameObject.SetActive(true);
		}

		// RVA: 0x132E98C Offset: 0x132E98C VA: 0x132E98C Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x132E994 Offset: 0x132E994 VA: 0x132E994
		public void Update()
		{
			return;
		}

		// RVA: 0x132E998 Offset: 0x132E998 VA: 0x132E998 Slot: 19
		public void Show()
		{
			if(m_episode != null)
			{
				m_episode.Show();
			}
			gameObject.SetActive(true);
		}

		// RVA: 0x132EA7C Offset: 0x132EA7C VA: 0x132EA7C Slot: 20
		public void Hide()
		{
			if(m_episode != null)
			{
				m_episode.Hide();
				m_episode.ResetData();
			}
			gameObject.SetActive(false);
		}

		// RVA: 0x132EB80 Offset: 0x132EB80 VA: 0x132EB80 Slot: 21
		public bool IsReady()
		{
			if(m_episode != null)
			{
				return !m_episode.IsLoading();
			}
			return true;
		}

		// RVA: 0x132EC40 Offset: 0x132EC40 VA: 0x132EC40 Slot: 22
		public void CallOpenEnd()
		{
			if (m_episode != null)
				m_episode.StringIn();
		}
	}
}
