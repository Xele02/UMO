using System;
using UnityEngine;
using XeSys;

namespace XeApp.Game.Common
{
	public class HomeStoryButton : MonoBehaviour
	{
		//[HeaderAttribute] // RVA: 0x68ABE0 Offset: 0x68ABE0 VA: 0x68ABE0
		[SerializeField]
		private ButtonBase m_button; // 0xC
		//[HeaderAttribute] // RVA: 0x68AC28 Offset: 0x68AC28 VA: 0x68AC28
		[SerializeField]
		private UGUICommonInfoWindow m_infoWindow; // 0x10
		//[HeaderAttribute] // RVA: 0x68AC80 Offset: 0x68AC80 VA: 0x68AC80
		[SerializeField]
		private InOutAnime m_inOutAnime; // 0x14
		private LIEJFHMGNIA m_view; // 0x18

		public Action onClickButton { private get; set; } // 0x1C

		// RVA: 0xEB1600 Offset: 0xEB1600 VA: 0xEB1600
		private void Start()
		{
			m_button.ClearOnClickCallback();
			m_button.AddOnClickCallback(() =>
			{
				//0xEB16D0
				if (onClickButton != null)
					onClickButton();
			});
		}

		//// RVA: 0xEA8360 Offset: 0xEA8360 VA: 0xEA8360
		public void Setup()
		{
			m_view = LIEJFHMGNIA.HDKCNAKPAAC(null);
			if(m_view != null)
			{
				if(!m_view.MMEGDFPNONJ_HasDivaId)
				{
					m_infoWindow.Setup(MessageManager.Instance.GetMessage("menu", "home_story_release_music"), null);
				}
				else
				{
					m_infoWindow.Setup(string.Format(MessageManager.Instance.GetMessage("menu", "home_story_release_diva"), MessageManager.Instance.GetMessage("master", string.Format("diva_s_{0:D2}", m_view.AHHJLDLAPAN_DivaId))), null);
				}
			}
		}

		//// RVA: 0xEA8888 Offset: 0xEA8888 VA: 0xEA8888
		public void Enter()
		{
			m_inOutAnime.Enter(false, null);
			if(m_view == null)
				return;
			m_infoWindow.Enter(false);
		}

		//// RVA: 0xEA8A74 Offset: 0xEA8A74 VA: 0xEA8A74
		//public void Enter(float animTime) { }

		//// RVA: 0xEA8C78 Offset: 0xEA8C78 VA: 0xEA8C78
		public void Leave()
		{
			m_inOutAnime.Leave(false, null);
			if(m_view == null)
				return;
			m_infoWindow.Leave(false);
		}

		//// RVA: 0xEA8E64 Offset: 0xEA8E64 VA: 0xEA8E64
		//public void Leave(float animTime) { }

		//// RVA: 0xEA9088 Offset: 0xEA9088 VA: 0xEA9088
		public bool IsPlaying()
		{
			return m_inOutAnime.IsPlaying();
		}
	}
}
