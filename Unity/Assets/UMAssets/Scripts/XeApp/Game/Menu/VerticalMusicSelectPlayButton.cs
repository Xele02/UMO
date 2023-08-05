using UnityEngine;
using XeApp.Game.Common;
using TMPro;
using System;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectPlayButton : MonoBehaviour
	{
		public enum PlayButtonType
		{
			PlayEn = 0,
			Play = 1,
			Event = 2,
			Download = 3,
			Release = 4,
			Story = 5,
			Num = 6,
		}

		// [HeaderAttribute] // RVA: 0x675590 Offset: 0x675590 VA: 0x675590
		[SerializeField]
		private UGUIButton m_playButton; // 0xC
		// [HeaderAttribute] // RVA: 0x6755D8 Offset: 0x6755D8 VA: 0x6755D8
		[SerializeField]
		private InOutAnime m_inOut; // 0x10
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x675620 Offset: 0x675620 VA: 0x675620
		private GameObject m_playObj; // 0x14
		[SerializeField]
		private GameObject m_enagyObj; // 0x18
		[SerializeField]
		private GameObject m_eventObj; // 0x1C
		[SerializeField]
		private GameObject m_dlObj; // 0x20
		[SerializeField]
		private GameObject m_releaseObj; // 0x24
		[SerializeField]
		private GameObject m_storyObj; // 0x28
		// [HeaderAttribute] // RVA: 0x6756C0 Offset: 0x6756C0 VA: 0x6756C0
		[SerializeField]
		private TextMeshProUGUI m_enagyNumText; // 0x2C
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x675710 Offset: 0x675710 VA: 0x675710
		private GameObject m_weeklyRecovery; // 0x30

		public Action<bool> OnClicButtonListener { private get; set; } // 0x34

		// // RVA: 0xBE5278 Offset: 0xBE5278 VA: 0xBE5278
		private void Awake()
		{
			m_playButton.ClearOnClickCallback();
			m_playButton.AddOnClickCallback(() => {
				//0xBE57B0
				if(OnClicButtonListener != null)
					OnClicButtonListener(false);
			});
		}

		// // RVA: 0xBE5340 Offset: 0xBE5340 VA: 0xBE5340
		public void SetPlayButtonType(VerticalMusicSelectPlayButton.PlayButtonType type)
		{
			m_enagyObj.gameObject.SetActive(false);
			m_playObj.gameObject.SetActive(false);
			m_eventObj.gameObject.SetActive(false);
			m_dlObj.gameObject.SetActive(false);
			m_releaseObj.gameObject.SetActive(false);
			m_storyObj.gameObject.SetActive(false);
			switch (type)
			{
				case PlayButtonType.PlayEn:
					m_enagyObj.gameObject.SetActive(true);
					break;
				case PlayButtonType.Play:
					m_playObj.gameObject.SetActive(true);
					break;
				case PlayButtonType.Event:
					m_eventObj.gameObject.SetActive(true);
					break;
				case PlayButtonType.Download:
					m_dlObj.gameObject.SetActive(true);
					break;
				case PlayButtonType.Release:
					m_releaseObj.gameObject.SetActive(true);
					break;
				case PlayButtonType.Story:
					m_storyObj.gameObject.SetActive(true);
					break;
				default:
					return;
			}
		}

		// // RVA: 0xBE558C Offset: 0xBE558C VA: 0xBE558C
		public void SetEnergy(int energy)
		{
			m_enagyNumText.text = "" + energy;
		}

		// // RVA: 0xBE55D8 Offset: 0xBE55D8 VA: 0xBE55D8
		public void WeeklyRecoveryEnable(bool isEnable)
		{
			m_weeklyRecovery.SetActive(isEnable);
		}

		// // RVA: 0xBE560C Offset: 0xBE560C VA: 0xBE560C
		public void Enter()
		{
			m_inOut.ForceEnter(null);
		}

		// // RVA: 0xBE563C Offset: 0xBE563C VA: 0xBE563C
		public void Leave()
		{
			if (!gameObject.activeSelf)
				return;
			m_inOut.ForceLeave(null);
		}

		// // RVA: 0xBE56A0 Offset: 0xBE56A0 VA: 0xBE56A0
		public bool IsPlaying()
		{
			return m_inOut.IsPlaying();
		}

		// // RVA: 0xBE56CC Offset: 0xBE56CC VA: 0xBE56CC
		public void SetEnable(bool isEneble)
		{
			if(!isEneble)
			{
				m_inOut.ForceEnter(0, null);
			}
			gameObject.SetActive(isEneble);
		}

		// // RVA: 0xBE5740 Offset: 0xBE5740 VA: 0xBE5740
		public void SetButtonEnable(bool isEnable)
		{
			m_playButton.Disable = !isEnable;
		}

		// // RVA: 0xBE5774 Offset: 0xBE5774 VA: 0xBE5774
		public void SetInputEnable(bool isEnable)
		{
			m_playButton.IsInputOff = !isEnable;
		}
	}
}
