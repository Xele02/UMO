using System;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectDifficultyButtonGroup : MonoBehaviour
	{
		public enum ButtonStyle // TypeDefIndex: 13291
		{
			NormalLine = 0,
			Line6 = 1,
		}

		private static string m_invalidText = "-"; // 0x0
		// [HeaderAttribute] // RVA: 0x674634 Offset: 0x674634 VA: 0x674634
		[SerializeField]
		private GridLayoutGroup m_layoutGroup; // 0xC
		[SerializeField]
		private float m_4LineWidth = 23.0f; // 0x10
		[SerializeField]
		private float m_6LineWidth = 28.0f; // 0x14
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x6746A4 Offset: 0x6746A4 VA: 0x6746A4
		private UGUIToggleButtonGroup m_toggleButtonGroup; // 0x18
		// [HeaderAttribute] // RVA: 0x6746EC Offset: 0x6746EC VA: 0x6746EC
		[SerializeField]
		private VerticalMusicSelectDifficultyButton[] m_diffityButton; // 0x1C
		// [HeaderAttribute] // RVA: 0x674734 Offset: 0x674734 VA: 0x674734
		[SerializeField]
		private InOutAnime m_inOut; // 0x20
		private Vector2 m_spacingVector = new Vector2(0, 0); // 0x28

		public Action<int> OnButtonClickListener { private get; set; } // 0x24

		// // RVA: 0xBDBE4C Offset: 0xBDBE4C VA: 0xBDBE4C
		private void Awake()
		{
			m_toggleButtonGroup.OnSelectToggleButtonEvent.AddListener((int index) =>
			{
				//0xBDD01C
				if (OnButtonClickListener != null)
					OnButtonClickListener(index);
			});
		}

		// // RVA: 0xBDBF2C Offset: 0xBDBF2C VA: 0xBDBF2C
		// public void SetInputEnable(bool isEnable) { }

		// // RVA: 0xBDBFC0 Offset: 0xBDBFC0 VA: 0xBDBFC0
		public void SetDifficultStyle(VerticalMusicSelectUISapporter.MusicInfoStyle style)
		{
			switch (style)
			{
				case VerticalMusicSelectUISapporter.MusicInfoStyle.Music:
				case VerticalMusicSelectUISapporter.MusicInfoStyle.SLlive:
					{
						for (int i = 0; i < m_diffityButton.Length; i++)
						{
							m_diffityButton[i].SetEnable(true);
						}
					}
					break;
				case VerticalMusicSelectUISapporter.MusicInfoStyle.MiniGameEventEntrance:
				case VerticalMusicSelectUISapporter.MusicInfoStyle.OtherEventEntrance:
					{
						for (int i = 0; i < m_diffityButton.Length; i++)
						{
							m_diffityButton[i].SetEnable(false);
							m_diffityButton[i].SetMusicLevel(m_invalidText);
							SetDifficultyStatus(i, false, false, RhythmGameConsts.ResultComboType.Illegal);
						}
					}
					break;
				case VerticalMusicSelectUISapporter.MusicInfoStyle.Lock:
				case VerticalMusicSelectUISapporter.MusicInfoStyle.Unlockable:
					{
						for (int i = 0; i < m_diffityButton.Length; i++)
						{
							m_diffityButton[i].SetEnable(false);
						}
					}
					break;
				case VerticalMusicSelectUISapporter.MusicInfoStyle.NoneFilter:
				case VerticalMusicSelectUISapporter.MusicInfoStyle.None6Line:
					{
						for (int i = 0; i < m_diffityButton.Length; i++)
						{
							m_diffityButton[i].SetEnable(true);
							m_diffityButton[i].SetMusicLevel(m_invalidText);
							SetDifficultyStatus(i, false, false, RhythmGameConsts.ResultComboType.Illegal);
						}
					}
					break;
			}
		}

		// // RVA: 0xBDC448 Offset: 0xBDC448 VA: 0xBDC448
		public void SetDifficultyButton(Difficulty.Type difficulty)
		{
			for(int i = 0; i < m_diffityButton.Length; i++)
			{
				if(m_diffityButton[i].gameObject.activeSelf)
				{
					if (!m_diffityButton[i].IsEnable())
						return;
				}
			}
			m_toggleButtonGroup.SelectGroupButton((int)difficulty);
		}

		// // RVA: 0xBDC580 Offset: 0xBDC580 VA: 0xBDC580
		public void SetDifficultyButtonStyle(ButtonStyle style)
		{
			m_spacingVector.y = 0;
			if(style == ButtonStyle.Line6)
			{
				m_spacingVector.x = m_6LineWidth;
				m_layoutGroup.spacing = m_spacingVector;
				m_diffityButton[0].gameObject.SetActive(false);
				m_diffityButton[1].gameObject.SetActive(false);
				m_diffityButton[2].gameObject.SetActive(true);
				m_diffityButton[3].gameObject.SetActive(true);
				m_diffityButton[4].gameObject.SetActive(true);
				m_diffityButton[2].SetDifficultyIcon(MusicSelectConsts.DifficultIconType.HardPlus);
				m_diffityButton[3].SetDifficultyIcon(MusicSelectConsts.DifficultIconType.VeryHardPlus);
				m_diffityButton[4].SetDifficultyIcon(MusicSelectConsts.DifficultIconType.ExtremePlus);
			}
			else
			{
				m_spacingVector.x = m_4LineWidth;
				m_layoutGroup.spacing = m_spacingVector;
				m_diffityButton[0].gameObject.SetActive(true);
				m_diffityButton[1].gameObject.SetActive(true);
				m_diffityButton[2].gameObject.SetActive(true);
				m_diffityButton[3].gameObject.SetActive(true);
				m_diffityButton[4].gameObject.SetActive(true);
				m_diffityButton[0].SetDifficultyIcon(MusicSelectConsts.DifficultIconType.Easy);
				m_diffityButton[1].SetDifficultyIcon(MusicSelectConsts.DifficultIconType.Normal);
				m_diffityButton[2].SetDifficultyIcon(MusicSelectConsts.DifficultIconType.Hard);
				m_diffityButton[3].SetDifficultyIcon(MusicSelectConsts.DifficultIconType.VeryHard);
				m_diffityButton[4].SetDifficultyIcon(MusicSelectConsts.DifficultIconType.Extreme);

			}
		}

		// // RVA: 0xBDC3CC Offset: 0xBDC3CC VA: 0xBDC3CC
		public void SetDifficultyStatus(int index, bool isNew, bool isClear, RhythmGameConsts.ResultComboType comboRank)
		{
			m_diffityButton[index].SetDifficultyStatus(false, isClear, comboRank);
		}

		// // RVA: 0xBDCD20 Offset: 0xBDCD20 VA: 0xBDCD20
		// public void SetMusicLevel(int index, int musicLevel, VerticalMusicSelectDifficultyButtonGroup.ButtonStyle style) { }

		// // RVA: 0xBDCE0C Offset: 0xBDCE0C VA: 0xBDCE0C
		public void Enter()
		{
			m_inOut.ForceEnter(null);
		}

		// // RVA: 0xBDCE3C Offset: 0xBDCE3C VA: 0xBDCE3C
		// public void Leave() { }

		// // RVA: 0xBDCEA0 Offset: 0xBDCEA0 VA: 0xBDCEA0
		public bool IsPlaying()
		{
			return m_inOut.IsPlaying();
		}

		// // RVA: 0xBDCECC Offset: 0xBDCECC VA: 0xBDCECC
		public void SetEnable(bool isEneble)
		{
			if(!isEneble)
			{
				m_inOut.ForceEnter(0.0f, null);
			}
			gameObject.SetActive(isEneble);
		}
	}
}
