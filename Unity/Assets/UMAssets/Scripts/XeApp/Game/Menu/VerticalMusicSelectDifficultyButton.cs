using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using TMPro;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectDifficultyButton : MonoBehaviour
	{
		[SerializeField]
		private MusicSelectDifficultScriptableObject m_difficultSprite; // 0xC
		[SerializeField]
		private Image m_onDifficultIcon; // 0x10
		[SerializeField]
		private Image m_offDifficultIcon; // 0x14
		// [HeaderAttribute] // RVA: 0x674434 Offset: 0x674434 VA: 0x674434
		[SerializeField]
		private UGUIToggleButton m_toggleButton; // 0x18
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x67447C Offset: 0x67447C VA: 0x67447C
		private TextMeshProUGUI[] m_musicLevel = new TextMeshProUGUI[2]; // 0x1C
		// [TooltipAttribute] // RVA: 0x6744C4 Offset: 0x6744C4 VA: 0x6744C4
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x6744C4 Offset: 0x6744C4 VA: 0x6744C4
		private GameObject m_clearObj; // 0x20
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x67455C Offset: 0x67455C VA: 0x67455C
		private GameObject m_fullComboObj; // 0x24
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x6745C0 Offset: 0x6745C0 VA: 0x6745C0
		private GameObject m_perfectFullComboObj; // 0x28

		// // RVA: 0xBDB940 Offset: 0xBDB940 VA: 0xBDB940
		private void Awake()
		{
			m_toggleButton.AddOnClickCallback(() =>
			{
				//0xBDBE38
				return;
			});
		}

		// // RVA: 0xBDBA80 Offset: 0xBDBA80 VA: 0xBDBA80
		// public void SetHidden(bool isHidden) { }

		// // RVA: 0xBDBAB4 Offset: 0xBDBAB4 VA: 0xBDBAB4
		public void SetInputEnable(bool isEnable)
		{
			m_toggleButton.IsInputOff = !isEnable;
		}

		// // RVA: 0xBDBAE8 Offset: 0xBDBAE8 VA: 0xBDBAE8
		public void SetEnable(bool isEnable)
		{
			m_toggleButton.Disable = !isEnable;
		}

		// // RVA: 0xBDBB1C Offset: 0xBDBB1C VA: 0xBDBB1C
		public bool IsEnable()
		{
			return !m_toggleButton.Disable;
		}

		// // RVA: 0xBDBB4C Offset: 0xBDBB4C VA: 0xBDBB4C
		public void SetDifficultyIcon(MusicSelectConsts.DifficultIconType iconType)
		{
			m_onDifficultIcon.sprite = m_difficultSprite.GetSpriteSet((int)iconType).on;
			m_offDifficultIcon.sprite = m_difficultSprite.GetSpriteSet((int)iconType).off;
		}

		// // RVA: 0xBDBBE8 Offset: 0xBDBBE8 VA: 0xBDBBE8
		public void SetMusicLevel(string musicLevel)
		{
			for(int i = 0; i < m_musicLevel.Length; i++)
			{
				m_musicLevel[i].text = musicLevel;
			}
		}

		// // RVA: 0xBDBC80 Offset: 0xBDBC80 VA: 0xBDBC80
		public void SetDifficultyStatus(bool isNew, bool isClear, RhythmGameConsts.ResultComboType comboRank)
		{
			m_clearObj.SetActive(false);
			m_fullComboObj.SetActive(false);
			m_perfectFullComboObj.SetActive(false);
			if (!isClear)
				return;
			if (comboRank == RhythmGameConsts.ResultComboType.PerfectFullCombo)
				m_perfectFullComboObj.SetActive(true);
			else if (comboRank == RhythmGameConsts.ResultComboType.FullCombo)
				m_fullComboObj.SetActive(true);
			else
				m_clearObj.SetActive(true);
		}
	}
}
