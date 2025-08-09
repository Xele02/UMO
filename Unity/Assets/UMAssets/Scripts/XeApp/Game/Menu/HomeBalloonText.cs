using UnityEngine;
using System;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class HomeBalloonText : MonoBehaviour
	{
		public enum Style
		{
			Beginner = 0,
			Mission = 1,
			Diva = 2,
			Music = 3,
			Sns = 4,
			Event = 5,
			Num = 6,
		}

		[Serializable]
		public class ReplaceInfo
		{
			public string name; // 0x8
			public Sprite type; // 0xC
			public Sprite text; // 0x10
		}

		// [HeaderAttribute] // RVA: 0x66FE00 Offset: 0x66FE00 VA: 0x66FE00
		[SerializeField]
		private ReplaceInfo[] m_tableReplace = new ReplaceInfo[6]; // 0xC
		// [HeaderAttribute] // RVA: 0x66FE48 Offset: 0x66FE48 VA: 0x66FE48
		[SerializeField]
		private Text m_textScroll; // 0x10
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x66FEA4 Offset: 0x66FEA4 VA: 0x66FEA4
		private ButtonBase m_button; // 0x14
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x66FEEC Offset: 0x66FEEC VA: 0x66FEEC
		private Image m_imageType; // 0x18
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x66FF48 Offset: 0x66FF48 VA: 0x66FF48
		private Image m_imageText; // 0x1C
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x66FFA4 Offset: 0x66FFA4 VA: 0x66FFA4
		private GameObject m_iconOnOff; // 0x20
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x670000 Offset: 0x670000 VA: 0x670000
		private RawImageEx m_imageIcon; // 0x24
		// [HeaderAttribute] // RVA: 0x670048 Offset: 0x670048 VA: 0x670048
		[SerializeField]
		private Image m_imageClear; // 0x28
		// [HeaderAttribute] // RVA: 0x670098 Offset: 0x670098 VA: 0x670098
		[SerializeField]
		private InOutAnime m_inOutAnime; // 0x2C
		// [HeaderAttribute] // RVA: 0x6700E0 Offset: 0x6700E0 VA: 0x6700E0
		[SerializeField]
		private CanvasGroup m_canvasGroup; // 0x30
		private int m_inputBlockCount; // 0x34

		public Action onClickButton { private get; set; } // 0x38
		public bool isEntered { get { return m_inOutAnime.IsEnter; } } //0x956B24

		// RVA: 0x956B50 Offset: 0x956B50 VA: 0x956B50
		private void Start()
		{
			m_button.ClearOnClickCallback();
			m_button.AddOnClickCallback(() =>
			{
				//0x957238
				if (onClickButton != null)
					onClickButton();
			});
			SetExistsItem(false);
		}

		// // RVA: 0x956C58 Offset: 0x956C58 VA: 0x956C58
		public void SetStyle(Style style)
		{
			m_imageType.sprite = m_tableReplace[(int)style].type;
			m_imageText.sprite = m_tableReplace[(int)style].text;
			m_imageClear.enabled = style != Style.Event;
		}

		// // RVA: 0x956C24 Offset: 0x956C24 VA: 0x956C24
		public void SetExistsItem(bool existsItem)
		{
			m_iconOnOff.SetActive(existsItem);
		}

		// // RVA: 0x956D30 Offset: 0x956D30 VA: 0x956D30
		public void SetItemIcon(IiconTexture icon)
		{
			icon.Set(m_imageIcon);
		}

		// // RVA: 0x956E10 Offset: 0x956E10 VA: 0x956E10
		// public void SetDivaIcon(IiconTexture icon) { }

		// // RVA: 0x956E14 Offset: 0x956E14 VA: 0x956E14
		public void SetMessage(string msg)
		{
			if(RuntimeSettings.CurrentSettings.Language == "en" || RuntimeSettings.CurrentSettings.Language == "fr" )
			{
				m_textScroll.text = msg.Replace("\n", " ").Replace("  ", " ");
			}
			else
			{
				m_textScroll.text = msg.Replace("\n", "");
			}
		}

		// // RVA: 0x956ED0 Offset: 0x956ED0 VA: 0x956ED0
		public void SetClearMark(bool isClear)
		{
			m_imageClear.gameObject.SetActive(isClear);
		}

		// // RVA: 0x956F24 Offset: 0x956F24 VA: 0x956F24
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

		// // RVA: 0x956FFC Offset: 0x956FFC VA: 0x956FFC
		public void Enter(bool force = false)
		{
			m_inOutAnime.Enter(force, null);
		}

		// // RVA: 0x957034 Offset: 0x957034 VA: 0x957034
		// public void Enter(float animTime, bool force = False) { }

		// // RVA: 0x957080 Offset: 0x957080 VA: 0x957080
		public void Leave(bool force = false)
		{
			m_inOutAnime.Leave(force, null);
		}

		// // RVA: 0x9570B8 Offset: 0x9570B8 VA: 0x9570B8
		// public void Leave(float animTime, bool force = False) { }

		// // RVA: 0x957104 Offset: 0x957104 VA: 0x957104
		public bool IsPlaying()
		{
			return m_inOutAnime.IsPlaying();
		}

		// // RVA: 0x957130 Offset: 0x957130 VA: 0x957130
		public void SetEnable()
		{
			m_inputBlockCount--;
			if(m_inputBlockCount > 0)
				return;
			m_button.IsInputOff = false;
			m_inputBlockCount = 0;
		}

		// // RVA: 0x957180 Offset: 0x957180 VA: 0x957180
		public void SetDisable()
		{
			m_inputBlockCount++;
			if (m_inputBlockCount < 1)
				return;
			m_button.IsInputOff = true;
		}
	}
}
