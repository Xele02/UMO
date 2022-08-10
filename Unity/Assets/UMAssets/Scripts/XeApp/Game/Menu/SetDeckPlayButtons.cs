using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System;

namespace XeApp.Game.Menu
{
	public class SetDeckPlayButtons : MonoBehaviour
	{
		public enum SkipButtoType
		{
			Hide = 0,
			Enable = 1,
			Disable = 2,
			Lock = 3,
		}
		
		public enum PlayButtonType
		{
			Play = 0,
			Play_EN = 1,
			Play_AP = 2,
			Support_AP = 3,
		}
	
		public enum PosType
		{
			Normal = 0,
			SLive = 1,
		}

		[SerializeField]
		// [TooltipAttribute] // RVA: 0x682004 Offset: 0x682004 VA: 0x682004
		private InOutAnime m_inOut; // 0xC
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x68204C Offset: 0x68204C VA: 0x68204C
		private UGUIPositionTable m_posTable; // 0x10
		// [TooltipAttribute] // RVA: 0x682094 Offset: 0x682094 VA: 0x682094
		[SerializeField]
		private UGUIButton m_skipButton; // 0x14
		// [TooltipAttribute] // RVA: 0x6820EC Offset: 0x6820EC VA: 0x6820EC
		[SerializeField]
		private ColorGroup m_skipButtonColorGroup; // 0x18
		// [TooltipAttribute] // RVA: 0x682154 Offset: 0x682154 VA: 0x682154
		[SerializeField]
		private Text m_skipRestCountText; // 0x1C
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x6821BC Offset: 0x6821BC VA: 0x6821BC
		private Image m_skipButtonLockImage; // 0x20
		// [TooltipAttribute] // RVA: 0x682230 Offset: 0x682230 VA: 0x682230
		[SerializeField]
		private UGUIButton m_playButton; // 0x24
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x682284 Offset: 0x682284 VA: 0x682284
		private GameObject m_playObject; // 0x28
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x6822E4 Offset: 0x6822E4 VA: 0x6822E4
		private GameObject m_supportObject; // 0x2C
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x682344 Offset: 0x682344 VA: 0x682344
		private GameObject m_energyObject; // 0x30
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x6823AC Offset: 0x6823AC VA: 0x6823AC
		private Text m_energyNameText; // 0x34
		// [TooltipAttribute] // RVA: 0x682410 Offset: 0x682410 VA: 0x682410
		[SerializeField]
		private Text m_energyText; // 0x38
		// public Action OnClickSkipButton; // 0x3C
		public Action OnClickPlayButton; // 0x40

		// public InOutAnime InOut { get; } 0xA730C0

		// // RVA: 0xA730C8 Offset: 0xA730C8 VA: 0xA730C8
		private void Awake()
		{
			TodoLogger.Log(0, "SetDeckPlayButtons Awake");
			if(m_playButton != null)
				m_playButton.AddOnClickCallback(() => {
					//0xA7363C
					if(OnClickPlayButton != null)
						OnClickPlayButton();
				});
		}

		// // RVA: 0xA7325C Offset: 0xA7325C VA: 0xA7325C
		// public void Set(SetDeckPlayButtons.SkipButtoType skipType, int skipRestCount, SetDeckPlayButtons.PlayButtonType playType, int energy) { }

		// // RVA: 0xA735EC Offset: 0xA735EC VA: 0xA735EC
		// public void SetPosType(SetDeckPlayButtons.PosType posType) { }

		// [CompilerGeneratedAttribute] // RVA: 0x730CCC Offset: 0x730CCC VA: 0x730CCC
		// // RVA: 0xA73628 Offset: 0xA73628 VA: 0xA73628
		// private void <Awake>b__19_0() { }
	}
}
