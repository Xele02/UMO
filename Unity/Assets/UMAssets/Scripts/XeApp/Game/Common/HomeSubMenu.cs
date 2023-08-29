using UnityEngine;
using System.Collections.Generic;
using System;

namespace XeApp.Game.Common
{
	public class HomeSubMenu : MonoBehaviour
	{
		//[HeaderAttribute] // RVA: 0x68ACD8 Offset: 0x68ACD8 VA: 0x68ACD8
		[SerializeField]
		private List<HomeSubMenuButton> m_buttons; // 0xC
		//[HeaderAttribute] // RVA: 0x68AD28 Offset: 0x68AD28 VA: 0x68AD28
		[SerializeField]
		private InOutAnime m_inOutAnime; // 0x10
		//[HeaderAttribute] // RVA: 0x68AD70 Offset: 0x68AD70 VA: 0x68AD70
		[SerializeField]
		private CanvasGroup m_canvasGroup; // 0x14

		public Action onClickPresentButton { set { m_buttons[0].onClickButton = value; } } //0xEB16E4
		public Action onClickNoticeButton { set { m_buttons[1].onClickButton = value; } } //0xEB1784
		public Action onClickMPassButton { set { m_buttons[2].onClickButton = value; } } //0xEB181C
		public Action onClickFriendButton { set { m_buttons[3].onClickButton = value; } } //0xEB18B4
		public Action onClickSnsButton { set { m_buttons[4].onClickButton = value; } } //0xEB194C

		//// RVA: 0xEB19E4 Offset: 0xEB19E4 VA: 0xEB19E4
		private void Start()
		{
			for(int i = 0; i < m_buttons.Count; i++)
			{
				m_buttons[i].Init();
			}
		}

		//// RVA: 0xEB1B5C Offset: 0xEB1B5C VA: 0xEB1B5C
		public void ApplyNewIcons()
		{
			m_buttons[0].SetBadgeActive(CIOECGOMILE.HHCJCDFCLOB.KPFKKDDOHCN.GIPGAICOGGL.Count > 0);
			m_buttons[1].SetBadgeActive(false);
			UpdateMonthlyPass();
			m_buttons[3].SetBadgeActive(CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.NMOJPDCBGMK_NumFriendNoFav + CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.JCOBBOMCENL_NumNewRequests > 0);
			m_buttons[4].SetBadgeActive(BIFNGFAIEIL.HHCJCDFCLOB.FMHMCMIAOAC());
		}

		//// RVA: 0xEB1F58 Offset: 0xEB1F58 VA: 0xEB1F58
		public void UpdateMonthlyPass()
		{
			HomeSubMenuPassButton b = m_buttons[2] as HomeSubMenuPassButton;
			int a = NHPDPKHMFEP.HHCJCDFCLOB.OEFMFNICHHH();
			int c = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal, 1);
			if(NHPDPKHMFEP.HHCJCDFCLOB.MENKMJPCELJ() == 0)
			{
				b.SetBadgeActive(true);
				b.Setup(c, a);
				b.SetBadgeActive(a < 1 ? HomeSubMenuPassButton.Type.Purchase : HomeSubMenuPassButton.Type.Switch);
				return;
			}
			if(NHPDPKHMFEP.HHCJCDFCLOB.MENKMJPCELJ() < 1)
			{
				if(NHPDPKHMFEP.HHCJCDFCLOB.MENKMJPCELJ() != -3)
				{
					b.SetActive(false);
					return;
				}
				b.SetActive(true);
			}
			else
			{
				b.SetActive(true);
				b.Setup(c, a);
				if(a > 0)
				{
					b.SetBadgeActive(HomeSubMenuPassButton.Type.RareUpItem);
					return;
				}
			}
			b.SetBadgeActive(0);
		}

		//// RVA: 0xEB24C0 Offset: 0xEB24C0 VA: 0xEB24C0
		public void SetActive(bool active)
		{
			if(active)
			{
				m_canvasGroup.alpha = 1;
				m_canvasGroup.interactable = true;
				m_canvasGroup.blocksRaycasts = true;
			}
			else
			{
				m_canvasGroup.alpha = 0;
				m_canvasGroup.interactable = false;
				m_canvasGroup.blocksRaycasts = false;
			}
		}

		//// RVA: 0xEB2598 Offset: 0xEB2598 VA: 0xEB2598
		public void Enter()
		{
			m_inOutAnime.Enter(false, null);
		}

		//// RVA: 0xEB25CC Offset: 0xEB25CC VA: 0xEB25CC
		//public void Enter(float animTime) { }

		//// RVA: 0xEB2614 Offset: 0xEB2614 VA: 0xEB2614
		public void Leave()
		{
			m_inOutAnime.Leave(false, null);
		}

		//// RVA: 0xEB2648 Offset: 0xEB2648 VA: 0xEB2648
		//public void Leave(float animTime) { }

		//// RVA: 0xEB2690 Offset: 0xEB2690 VA: 0xEB2690
		public bool IsPlaying()
		{
			return m_inOutAnime.IsPlaying();
		}
	}
}
