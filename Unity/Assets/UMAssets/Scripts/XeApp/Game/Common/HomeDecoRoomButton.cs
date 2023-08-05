using System;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class HomeDecoRoomButton : MonoBehaviour
	{
		//[HeaderAttribute] // RVA: 0x689AEC Offset: 0x689AEC VA: 0x689AEC
		[SerializeField]
		private ButtonBase m_button; // 0xC
		//[HeaderAttribute] // RVA: 0x689B34 Offset: 0x689B34 VA: 0x689B34
		[SerializeField]
		private GameObject m_unlock; // 0x10
		//[HeaderAttribute] // RVA: 0x689BA0 Offset: 0x689BA0 VA: 0x689BA0
		[SerializeField]
		private InOutAnime m_inOutAnime; // 0x14
		[SerializeField]
		private ColorGroup m_contentColorGroup; // 0x1C
		[SerializeField]
		private Color m_colorNormal = Color.black; // 0x20
		[SerializeField]
		private Color m_colorLock = Color.black; // 0x30

		public Action onClickButton { private get; set; } // 0x18

		// RVA: 0xEA911C Offset: 0xEA911C VA: 0xEA911C
		private void Start()
		{
			m_button.ClearOnClickCallback();
			m_button.AddOnClickCallback(() =>
			{
				//0xEA9244
				if (onClickButton != null)
					onClickButton();
			});
		}

		//// RVA: 0xEA85C0 Offset: 0xEA85C0 VA: 0xEA85C0
		public void Setup()
		{
			int requirelLevel;
			bool enable;
			HNDLICBDEMI.FMLGCFKNKIA_GetDecoPlayerLevelAndEnabled(out requirelLevel, out enable);
			if(requirelLevel == 0)
			{
				m_button.gameObject.SetActive(false);
			}
			else
			{
				if(!enable)
				{
					m_unlock.SetActive(true);
					m_contentColorGroup.color = m_colorLock;
				}
				else
				{
					m_unlock.SetActive(false);
					m_contentColorGroup.color = m_colorNormal;
				}
				m_contentColorGroup.SetMaterialDirty();
			}
		}

		//// RVA: 0xEA8924 Offset: 0xEA8924 VA: 0xEA8924
		public void Enter()
		{
			m_inOutAnime.Enter(false, null);
		}

		//// RVA: 0xEA8B44 Offset: 0xEA8B44 VA: 0xEA8B44
		//public void Enter(float animTime) { }

		//// RVA: 0xEA8D14 Offset: 0xEA8D14 VA: 0xEA8D14
		public void Leave()
		{
			m_inOutAnime.Leave(false, null);
		}

		//// RVA: 0xEA8F34 Offset: 0xEA8F34 VA: 0xEA8F34
		//public void Leave(float animTime) { }

		//// RVA: 0xEA90E0 Offset: 0xEA90E0 VA: 0xEA90E0
		public bool IsPlaying()
		{
			return m_inOutAnime.IsPlaying();
		}
	}
}
