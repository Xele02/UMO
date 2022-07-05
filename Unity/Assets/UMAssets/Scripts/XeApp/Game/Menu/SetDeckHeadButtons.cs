using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class SetDeckHeadButtons : MonoBehaviour
	{
		[SerializeField]
		private InOutAnime m_inOut;
		[SerializeField]
		private UGUIButton m_autoSettingButton;
		[SerializeField]
		private UGUIButton m_unitSetButton;
		[SerializeField]
		private UGUIButton m_prismButton;
		[SerializeField]
		private ColorGroup m_prismButtonColor;
		[SerializeField]
		private Image m_prismOnImage;
		[SerializeField]
		private Image m_prismOffImage;
		[SerializeField]
		private Text m_prismOnOffText;
		[SerializeField]
		private List<SpriteAnime> m_prismOnEffectAnimes;
		[SerializeField]
		private Image m_prismLockImage;
		[SerializeField]
		private UGUIButton m_unitButton;
		[SerializeField]
		private UGUIButton m_settingButton;
		
		// // Namespace: 
		// public enum SetDeckHeadButtons.Type // TypeDefIndex: 16425
		// {
		// 	// Fields
		// 	public int value__; // 0x0
		// 	public const SetDeckHeadButtons.Type None = 0;
		// 	public const SetDeckHeadButtons.Type TeamSelect = 1;
		// 	public const SetDeckHeadButtons.Type Prism = 2;
		// 	public const SetDeckHeadButtons.Type TeamEdit = 3;
		// 	public const SetDeckHeadButtons.Type SLive = 4;
		// }

		// // Namespace: 
		// public enum SetDeckHeadButtons.PrismType // TypeDefIndex: 16426
		// {
		// 	// Fields
		// 	public int value__; // 0x0
		// 	public const SetDeckHeadButtons.PrismType ON = 0;
		// 	public const SetDeckHeadButtons.PrismType OFF = 1;
		// 	public const SetDeckHeadButtons.PrismType Lock = 2;
		// }

		// [SerializeField] // RVA: 0x681304 Offset: 0x681304 VA: 0x681304
		// [TooltipAttribute] // RVA: 0x681304 Offset: 0x681304 VA: 0x681304
		// [HeaderAttribute] // RVA: 0x681304 Offset: 0x681304 VA: 0x681304
		// private InOutAnime m_inOut; // 0xC
		// [TooltipAttribute] // RVA: 0x681374 Offset: 0x681374 VA: 0x681374
		// [SerializeField] // RVA: 0x681374 Offset: 0x681374 VA: 0x681374
		// private UGUIButton m_autoSettingButton; // 0x10
		// [TooltipAttribute] // RVA: 0x6813CC Offset: 0x6813CC VA: 0x6813CC
		// [SerializeField] // RVA: 0x6813CC Offset: 0x6813CC VA: 0x6813CC
		// private UGUIButton m_unitSetButton; // 0x14
		// [TooltipAttribute] // RVA: 0x68142C Offset: 0x68142C VA: 0x68142C
		// [SerializeField] // RVA: 0x68142C Offset: 0x68142C VA: 0x68142C
		// private UGUIButton m_prismButton; // 0x18
		// [SerializeField] // RVA: 0x68148C Offset: 0x68148C VA: 0x68148C
		// [TooltipAttribute] // RVA: 0x68148C Offset: 0x68148C VA: 0x68148C
		// private ColorGroup m_prismButtonColor; // 0x1C
		// [SerializeField] // RVA: 0x6814F4 Offset: 0x6814F4 VA: 0x6814F4
		// [TooltipAttribute] // RVA: 0x6814F4 Offset: 0x6814F4 VA: 0x6814F4
		// private Image m_prismOnImage; // 0x20
		// [SerializeField] // RVA: 0x681560 Offset: 0x681560 VA: 0x681560
		// [TooltipAttribute] // RVA: 0x681560 Offset: 0x681560 VA: 0x681560
		// private Image m_prismOffImage; // 0x24
		// [SerializeField] // RVA: 0x6815CC Offset: 0x6815CC VA: 0x6815CC
		// [TooltipAttribute] // RVA: 0x6815CC Offset: 0x6815CC VA: 0x6815CC
		// private Text m_prismOnOffText; // 0x28
		// [TooltipAttribute] // RVA: 0x681640 Offset: 0x681640 VA: 0x681640
		// [SerializeField] // RVA: 0x681640 Offset: 0x681640 VA: 0x681640
		// private List<SpriteAnime> m_prismOnEffectAnimes; // 0x2C
		// [SerializeField] // RVA: 0x681688 Offset: 0x681688 VA: 0x681688
		// [TooltipAttribute] // RVA: 0x681688 Offset: 0x681688 VA: 0x681688
		// private Image m_prismLockImage; // 0x30
		// [TooltipAttribute] // RVA: 0x681708 Offset: 0x681708 VA: 0x681708
		// [SerializeField] // RVA: 0x681708 Offset: 0x681708 VA: 0x681708
		// private UGUIButton m_unitButton; // 0x34
		// [SerializeField] // RVA: 0x681764 Offset: 0x681764 VA: 0x681764
		// [TooltipAttribute] // RVA: 0x681764 Offset: 0x681764 VA: 0x681764
		// private UGUIButton m_settingButton; // 0x38
		// public Action OnClickAutoSettingButton; // 0x3C
		// public Action OnClickUnitSetButton; // 0x40
		// public Action OnClickPrismButton; // 0x44
		// public Action OnClickUnitButton; // 0x48
		// public Action OnClickSettingButton; // 0x4C

		// // Properties
		// public InOutAnime InOut { get; }
		// public UGUIButton AutoSettingButton { get; }

		// // Methods

		// // RVA: 0xA6E4A8 Offset: 0xA6E4A8 VA: 0xA6E4A8
		// public InOutAnime get_InOut() { }

		// // RVA: 0xA6E4B0 Offset: 0xA6E4B0 VA: 0xA6E4B0
		// public UGUIButton get_AutoSettingButton() { }

		// // RVA: 0xA6E4B8 Offset: 0xA6E4B8 VA: 0xA6E4B8
		// private void Awake() { }

		// // RVA: 0xA6E838 Offset: 0xA6E838 VA: 0xA6E838
		// public void SetType(SetDeckHeadButtons.Type type) { }

		// // RVA: 0xA6EDC4 Offset: 0xA6EDC4 VA: 0xA6EDC4
		// public void SetPrismType(SetDeckHeadButtons.PrismType type) { }

		// // RVA: 0xA6F3C4 Offset: 0xA6F3C4 VA: 0xA6F3C4
		// public void .ctor() { }

		// [CompilerGeneratedAttribute] // RVA: 0x730C4C Offset: 0x730C4C VA: 0x730C4C
		// // RVA: 0xA6F3CC Offset: 0xA6F3CC VA: 0xA6F3CC
		// private void <Awake>b__23_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x730C5C Offset: 0x730C5C VA: 0x730C5C
		// // RVA: 0xA6F3E0 Offset: 0xA6F3E0 VA: 0xA6F3E0
		// private void <Awake>b__23_1() { }

		// [CompilerGeneratedAttribute] // RVA: 0x730C6C Offset: 0x730C6C VA: 0x730C6C
		// // RVA: 0xA6F3F4 Offset: 0xA6F3F4 VA: 0xA6F3F4
		// private void <Awake>b__23_2() { }

		// [CompilerGeneratedAttribute] // RVA: 0x730C7C Offset: 0x730C7C VA: 0x730C7C
		// // RVA: 0xA6F408 Offset: 0xA6F408 VA: 0xA6F408
		// private void <Awake>b__23_3() { }

		// [CompilerGeneratedAttribute] // RVA: 0x730C8C Offset: 0x730C8C VA: 0x730C8C
		// // RVA: 0xA6F41C Offset: 0xA6F41C VA: 0xA6F41C
		// private void <Awake>b__23_4() { }
	}
}
