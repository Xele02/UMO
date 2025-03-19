using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class DivaChangePopup : UIBehaviour, IPopupContent
	{
		private RectTransform m_rectTransform; // 0x10
		private PopupWindowControl m_popupControl; // 0x14
		// [TooltipAttribute] // RVA: 0x67FCE4 Offset: 0x67FCE4 VA: 0x67FCE4
		[SerializeField]
		private List<Text> m_divaNameTexts; // 0x18
		// [TooltipAttribute] // RVA: 0x67FD40 Offset: 0x67FD40 VA: 0x67FD40
		[SerializeField]
		private List<RawImage> m_divaImages; // 0x1C
		// [TooltipAttribute] // RVA: 0x67FD90 Offset: 0x67FD90 VA: 0x67FD90
		[SerializeField]
		private Text m_messageText; // 0x20
		private int m_textureLoadingCount; // 0x24

		public Transform Parent { get; set; } // 0xC

		// RVA: 0x17D1C84 Offset: 0x17D1C84 VA: 0x17D1C84
		private void Awake()
		{
			m_rectTransform = transform as RectTransform;
		}

		// RVA: 0x17D1D0C Offset: 0x17D1D0C VA: 0x17D1D0C Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			DivaChangePopupSetting s = setting as DivaChangePopupSetting;
			m_popupControl = control;
			Parent = s.m_parent;
			FFHPBEPOMAK_DivaInfo[] info = new FFHPBEPOMAK_DivaInfo[2] { s.BeforeDiva, s.AfterDiva };
			m_textureLoadingCount = 0;
			for(int i = 0; i < info.Length; i++)
			{
				if(info[i] == null)
				{
					UnitWindowConstant.SetInvalidText(m_divaNameTexts[i], TextAnchor.MiddleCenter);
					m_textureLoadingCount++;
					RawImage divaImage = m_divaImages[i];
					MenuScene.Instance.DivaIconCache.LoadStateIcon(0, 0, 0, (IiconTexture texture) =>
					{
						//0x17D27C8
						texture.Set(divaImage);
						m_textureLoadingCount--;
					});
				}
				else
				{
					m_divaNameTexts[i].text = info[i].OPFGFINHFCE_Name;
					m_textureLoadingCount++;
					RawImage divaImage = m_divaImages[i];
					MenuScene.Instance.DivaIconCache.LoadStateIcon(info[i].AHHJLDLAPAN_DivaId, info[i].FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, info[i].EKFONBFDAAP_ColorId, (IiconTexture texture) =>
					{
						//0x17D26B4
						texture.Set(divaImage);
						m_textureLoadingCount--;
					});
				}
			}
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_messageText.text = bk.GetMessageByLabel("popup_diva_change_text");
			gameObject.SetActive(true);
		}

		// RVA: 0x17D261C Offset: 0x17D261C VA: 0x17D261C Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x17D2624 Offset: 0x17D2624 VA: 0x17D2624 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x17D265C Offset: 0x17D265C VA: 0x17D265C Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x17D2694 Offset: 0x17D2694 VA: 0x17D2694 Slot: 21
		public bool IsReady()
		{ 
			return m_textureLoadingCount < 1;
		}

		// RVA: 0x17D26A8 Offset: 0x17D26A8 VA: 0x17D26A8 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
