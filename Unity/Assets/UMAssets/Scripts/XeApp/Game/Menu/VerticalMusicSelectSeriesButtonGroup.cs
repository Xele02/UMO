using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using TMPro;
using System;
using mcrs;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectSeriesButtonGroup : MonoBehaviour
	{
		private static readonly MusicSelectConsts.SeriesType[] BUTTON_LIST_TYPE = new MusicSelectConsts.SeriesType[6] 
		{
			MusicSelectConsts.SeriesType.All, MusicSelectConsts.SeriesType.First, MusicSelectConsts.SeriesType.Seven, MusicSelectConsts.SeriesType.Frontia,
			MusicSelectConsts.SeriesType.Delta, MusicSelectConsts.SeriesType.Other
		}; // 0x0
		public static readonly SeriesAttr.Type[] CONVERT_SERIES_LIST = new SeriesAttr.Type[6] {
			SeriesAttr.Type.None, SeriesAttr.Type.First, SeriesAttr.Type.Seven, SeriesAttr.Type.Frontia, SeriesAttr.Type.Delta, SeriesAttr.Type.Plus
		}; // 0x4
		[SerializeField]
		private UGUIToggleButtonGroup m_toggleButtonGroup; // 0xC
		[SerializeField]
		private InOutAnime m_inOut; // 0x10
		[SerializeField]
		private UGUIButton m_pullDownButton; // 0x14
		[SerializeField]
		private InOutAnime m_pullDownInOut; // 0x18
		[SerializeField]
		private Sprite[] m_seriesSprites = new Sprite[6]; // 0x1C
		[SerializeField]
		private Image[] m_btnImage = new Image[6]; // 0x20
		[SerializeField]
		private TextMeshProUGUI[] m_btnText = new TextMeshProUGUI[6]; // 0x24
		[SerializeField]
		private Image m_pullDownBtnImage; // 0x28
		[SerializeField]
		private TextMeshProUGUI m_pullDownBtnText; // 0x2C

		public Action<int> OnButtonClickListener { private get; set; } // 0x30

		// // RVA: 0xAD92EC Offset: 0xAD92EC VA: 0xAD92EC
		private void Awake()
		{
			for(int i = 0; i < m_btnImage.Length; i++)
			{
				SetLogo(m_btnImage[i], i);
			}
			m_toggleButtonGroup.OnSelectToggleButtonEvent.RemoveAllListeners();
			m_toggleButtonGroup.OnSelectToggleButtonEvent.AddListener((int index) =>
			{
				//0xAD9C2C
				if (OnButtonClickListener != null)
				{
					OnButtonClickListener(index);
					SetLogo(m_pullDownBtnImage, index);
					SetPullDownText(index);
				}
			});
			m_pullDownButton.ClearOnClickCallback();
			m_pullDownButton.AddOnClickCallback(() =>
			{
				//0xAD9CBC
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				if(m_pullDownInOut.IsEnter)
				{
					m_pullDownInOut.ForceLeave(null);
				}
				else
				{
					m_pullDownInOut.ForceEnter(null);
				}
			});
		}

		// // RVA: 0xAD9714 Offset: 0xAD9714 VA: 0xAD9714
		public void SetSeriesButton(int series)
		{
			m_toggleButtonGroup.SelectGroupButton(series);
			SetLogo(m_pullDownBtnImage, series);
			SetPullDownText(series);
		}

		// // RVA: 0xAD98E4 Offset: 0xAD98E4 VA: 0xAD98E4
		public void Enter()
		{
			m_inOut.ForceEnter(null);
		}

		// // RVA: 0xAD9914 Offset: 0xAD9914 VA: 0xAD9914
		public void Leave()
		{
			if (!gameObject.activeSelf)
				return;
			m_inOut.ForceLeave(null);
		}

		// // RVA: 0xAD9978 Offset: 0xAD9978 VA: 0xAD9978
		public bool IsPlaying()
		{
			return m_inOut.IsPlaying();
		}

		// // RVA: 0xAD99A4 Offset: 0xAD99A4 VA: 0xAD99A4
		// public void SetEnable(bool isEneble) { }

		// // RVA: 0xAD9A28 Offset: 0xAD9A28 VA: 0xAD9A28
		public void SetPullDownEnable(bool isEneble)
		{
			m_pullDownButton.Disable = !isEneble;
			if(!isEneble)
			{
				m_pullDownInOut.Leave(0.1f, true);
			}
		}

		// // RVA: 0xAD94F8 Offset: 0xAD94F8 VA: 0xAD94F8
		private void SetLogo(Image spriteImage, int btnIndex)
		{
			if(BUTTON_LIST_TYPE[btnIndex] == MusicSelectConsts.SeriesType.All)
			{
				spriteImage.enabled = false;
				m_btnText[0].enabled = true;
			}
			else
			{
				m_btnText[(int)BUTTON_LIST_TYPE[btnIndex]].enabled = false;
				spriteImage.enabled = true;
				spriteImage.sprite = m_seriesSprites[(int)BUTTON_LIST_TYPE[btnIndex]];
			}
		}

		// // RVA: 0xAD9768 Offset: 0xAD9768 VA: 0xAD9768
		private void SetPullDownText(int btnIndex)
		{
			if(BUTTON_LIST_TYPE[btnIndex] != MusicSelectConsts.SeriesType.All)
			{
				m_pullDownBtnText.enabled = false;
			}
			else
			{
				m_pullDownBtnText.enabled = true;
				m_pullDownBtnText.text = m_btnText[0].text;
			}
		}
	}
}
