using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class SetDeckPlayButtons : MonoBehaviour
	{
		[SerializeField]
		private InOutAnime m_inOut;
		[SerializeField]
		private UGUIPositionTable m_posTable;
		[SerializeField]
		private UGUIButton m_skipButton;
		[SerializeField]
		private ColorGroup m_skipButtonColorGroup;
		[SerializeField]
		private Text m_skipRestCountText;
		[SerializeField]
		private Image m_skipButtonLockImage;
		[SerializeField]
		private UGUIButton m_playButton;
		[SerializeField]
		private GameObject m_playObject;
		[SerializeField]
		private GameObject m_supportObject;
		[SerializeField]
		private GameObject m_energyObject;
		[SerializeField]
		private Text m_energyNameText;
		[SerializeField]
		private Text m_energyText;

		// // Namespace: 
		// public enum SetDeckPlayButtons.SkipButtoType // TypeDefIndex: 16434
		// {
		// 	// Fields
		// 	public int value__; // 0x0
		// 	public const SetDeckPlayButtons.SkipButtoType Hide = 0;
		// 	public const SetDeckPlayButtons.SkipButtoType Enable = 1;
		// 	public const SetDeckPlayButtons.SkipButtoType Disable = 2;
		// 	public const SetDeckPlayButtons.SkipButtoType Lock = 3;
		// }

		// // Namespace: 
		// public enum SetDeckPlayButtons.PlayButtonType // TypeDefIndex: 16435
		// {
		// 	// Fields
		// 	public int value__; // 0x0
		// 	public const SetDeckPlayButtons.PlayButtonType Play = 0;
		// 	public const SetDeckPlayButtons.PlayButtonType Play_EN = 1;
		// 	public const SetDeckPlayButtons.PlayButtonType Play_AP = 2;
		// 	public const SetDeckPlayButtons.PlayButtonType Support_AP = 3;
		// }

		// // Namespace: 
		// public enum SetDeckPlayButtons.PosType // TypeDefIndex: 16436
		// {
		// 	// Fields
		// 	public int value__; // 0x0
		// 	public const SetDeckPlayButtons.PosType Normal = 0;
		// 	public const SetDeckPlayButtons.PosType SLive = 1;
		// }

		// // Fields
		// [SerializeField] // RVA: 0x682004 Offset: 0x682004 VA: 0x682004
		// [TooltipAttribute] // RVA: 0x682004 Offset: 0x682004 VA: 0x682004
		// private InOutAnime m_inOut; // 0xC
		// [SerializeField] // RVA: 0x68204C Offset: 0x68204C VA: 0x68204C
		// [TooltipAttribute] // RVA: 0x68204C Offset: 0x68204C VA: 0x68204C
		// private UGUIPositionTable m_posTable; // 0x10
		// [TooltipAttribute] // RVA: 0x682094 Offset: 0x682094 VA: 0x682094
		// [SerializeField] // RVA: 0x682094 Offset: 0x682094 VA: 0x682094
		// private UGUIButton m_skipButton; // 0x14
		// [TooltipAttribute] // RVA: 0x6820EC Offset: 0x6820EC VA: 0x6820EC
		// [SerializeField] // RVA: 0x6820EC Offset: 0x6820EC VA: 0x6820EC
		// private ColorGroup m_skipButtonColorGroup; // 0x18
		// [TooltipAttribute] // RVA: 0x682154 Offset: 0x682154 VA: 0x682154
		// [SerializeField] // RVA: 0x682154 Offset: 0x682154 VA: 0x682154
		// private Text m_skipRestCountText; // 0x1C
		// [SerializeField] // RVA: 0x6821BC Offset: 0x6821BC VA: 0x6821BC
		// [TooltipAttribute] // RVA: 0x6821BC Offset: 0x6821BC VA: 0x6821BC
		// private Image m_skipButtonLockImage; // 0x20
		// [TooltipAttribute] // RVA: 0x682230 Offset: 0x682230 VA: 0x682230
		// [SerializeField] // RVA: 0x682230 Offset: 0x682230 VA: 0x682230
		// private UGUIButton m_playButton; // 0x24
		// [SerializeField] // RVA: 0x682284 Offset: 0x682284 VA: 0x682284
		// [TooltipAttribute] // RVA: 0x682284 Offset: 0x682284 VA: 0x682284
		// private GameObject m_playObject; // 0x28
		// [SerializeField] // RVA: 0x6822E4 Offset: 0x6822E4 VA: 0x6822E4
		// [TooltipAttribute] // RVA: 0x6822E4 Offset: 0x6822E4 VA: 0x6822E4
		// private GameObject m_supportObject; // 0x2C
		// [SerializeField] // RVA: 0x682344 Offset: 0x682344 VA: 0x682344
		// [TooltipAttribute] // RVA: 0x682344 Offset: 0x682344 VA: 0x682344
		// private GameObject m_energyObject; // 0x30
		// [SerializeField] // RVA: 0x6823AC Offset: 0x6823AC VA: 0x6823AC
		// [TooltipAttribute] // RVA: 0x6823AC Offset: 0x6823AC VA: 0x6823AC
		// private Text m_energyNameText; // 0x34
		// [TooltipAttribute] // RVA: 0x682410 Offset: 0x682410 VA: 0x682410
		// [SerializeField] // RVA: 0x682410 Offset: 0x682410 VA: 0x682410
		// private Text m_energyText; // 0x38
		// public Action OnClickSkipButton; // 0x3C
		// public Action OnClickPlayButton; // 0x40

		// // Properties
		// public InOutAnime InOut { get; }

		// // Methods

		// // RVA: 0xA730C0 Offset: 0xA730C0 VA: 0xA730C0
		// public InOutAnime get_InOut() { }

		// // RVA: 0xA730C8 Offset: 0xA730C8 VA: 0xA730C8
		// private void Awake() { }

		// // RVA: 0xA7325C Offset: 0xA7325C VA: 0xA7325C
		// public void Set(SetDeckPlayButtons.SkipButtoType skipType, int skipRestCount, SetDeckPlayButtons.PlayButtonType playType, int energy) { }

		// // RVA: 0xA735EC Offset: 0xA735EC VA: 0xA735EC
		// public void SetPosType(SetDeckPlayButtons.PosType posType) { }

		// // RVA: 0xA73620 Offset: 0xA73620 VA: 0xA73620
		// public void .ctor() { }

		// [CompilerGeneratedAttribute] // RVA: 0x730CCC Offset: 0x730CCC VA: 0x730CCC
		// // RVA: 0xA73628 Offset: 0xA73628 VA: 0xA73628
		// private void <Awake>b__19_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x730CDC Offset: 0x730CDC VA: 0x730CDC
		// // RVA: 0xA7363C Offset: 0xA7363C VA: 0xA7363C
		// private void <Awake>b__19_1() { }
	}
}
