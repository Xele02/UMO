using System;
using XeApp.Game.Menu;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace XeApp.Game.Title
{
	public class LayoutTitleController : IDisposable
	{
		// [CompilerGeneratedAttribute] // RVA: 0x665504 Offset: 0x665504 VA: 0x665504
		// private LayoutTitleButtons <Buttons>k__BackingField; // 0x8
		// [CompilerGeneratedAttribute] // RVA: 0x665514 Offset: 0x665514 VA: 0x665514
		// private LayoutTitleScreen <Screen>k__BackingField; // 0xC
		// [CompilerGeneratedAttribute] // RVA: 0x665524 Offset: 0x665524 VA: 0x665524
		// private LayoutTitleScreenTap <ScreenTap>k__BackingField; // 0x10
		// [CompilerGeneratedAttribute] // RVA: 0x665534 Offset: 0x665534 VA: 0x665534
		// private LayoutTitleTexts <Texts>k__BackingField; // 0x14
		// [CompilerGeneratedAttribute] // RVA: 0x665544 Offset: 0x665544 VA: 0x665544
		// private LayoutTitleCopyRight <CopyRight>k__BackingField; // 0x18
		// [CompilerGeneratedAttribute] // RVA: 0x665554 Offset: 0x665554 VA: 0x665554
		// private LayoutTitleLeftBottomButtons <LbButtons>k__BackingField; // 0x1C
		// [CompilerGeneratedAttribute] // RVA: 0x665564 Offset: 0x665564 VA: 0x665564
		// private LayoutTitleLogo <TitleLogo>k__BackingField; // 0x20
		// [CompilerGeneratedAttribute] // RVA: 0x665574 Offset: 0x665574 VA: 0x665574
		// private LayoutTitleArButton <ArButton>k__BackingField; // 0x24
		// [CompilerGeneratedAttribute] // RVA: 0x665584 Offset: 0x665584 VA: 0x665584
		// private LayoutMonthlyPassTakeover <MonthlyPass>k__BackingField; // 0x28
		// [CompilerGeneratedAttribute] // RVA: 0x665594 Offset: 0x665594 VA: 0x665594
		// private GameObject <Parent>k__BackingField; // 0x2C
		// [CompilerGeneratedAttribute] // RVA: 0x6655A4 Offset: 0x6655A4 VA: 0x6655A4
		// private bool <IsSupportPopupOpen>k__BackingField; // 0x30
		// [CompilerGeneratedAttribute] // RVA: 0x6655B4 Offset: 0x6655B4 VA: 0x6655B4
		// private bool <IsSetup>k__BackingField; // 0x31
		private List<GameObject> titleObjectList; // 0x34
		private const int SiblingIndex = 2;

		// Properties
		public LayoutTitleButtons Buttons { get; set; }
		public LayoutTitleScreen Screen { get; set; }
		public LayoutTitleScreenTap ScreenTap { get; set; }
		public LayoutTitleTexts Texts { get; set; }
		public LayoutTitleCopyRight CopyRight { get; set; }
		public LayoutTitleLeftBottomButtons LbButtons { get; set; }
		public LayoutTitleLogo TitleLogo { get; set; }
		public LayoutTitleArButton ArButton { get; set; }
		public LayoutMonthlyPassTakeover MonthlyPass { get; set; }
		public GameObject Parent { get; set; }
		public bool IsSupportPopupOpen { get; set; }
		public bool IsSetup { get; set; }

		// // Methods

		// [CompilerGeneratedAttribute] // RVA: 0x6B2FE0 Offset: 0x6B2FE0 VA: 0x6B2FE0
		// // RVA: 0xE36320 Offset: 0xE36320 VA: 0xE36320
		// public LayoutTitleButtons get_Buttons() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B2FF0 Offset: 0x6B2FF0 VA: 0x6B2FF0
		// // RVA: 0xE36328 Offset: 0xE36328 VA: 0xE36328
		// private void set_Buttons(LayoutTitleButtons value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B3000 Offset: 0x6B3000 VA: 0x6B3000
		// // RVA: 0xE36330 Offset: 0xE36330 VA: 0xE36330
		// public LayoutTitleScreen get_Screen() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B3010 Offset: 0x6B3010 VA: 0x6B3010
		// // RVA: 0xE36338 Offset: 0xE36338 VA: 0xE36338
		// private void set_Screen(LayoutTitleScreen value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B3020 Offset: 0x6B3020 VA: 0x6B3020
		// // RVA: 0xE36340 Offset: 0xE36340 VA: 0xE36340
		// public LayoutTitleScreenTap get_ScreenTap() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B3030 Offset: 0x6B3030 VA: 0x6B3030
		// // RVA: 0xE36348 Offset: 0xE36348 VA: 0xE36348
		// private void set_ScreenTap(LayoutTitleScreenTap value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B3040 Offset: 0x6B3040 VA: 0x6B3040
		// // RVA: 0xE36350 Offset: 0xE36350 VA: 0xE36350
		// public LayoutTitleTexts get_Texts() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B3050 Offset: 0x6B3050 VA: 0x6B3050
		// // RVA: 0xE36358 Offset: 0xE36358 VA: 0xE36358
		// private void set_Texts(LayoutTitleTexts value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B3060 Offset: 0x6B3060 VA: 0x6B3060
		// // RVA: 0xE36360 Offset: 0xE36360 VA: 0xE36360
		// public LayoutTitleCopyRight get_CopyRight() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B3070 Offset: 0x6B3070 VA: 0x6B3070
		// // RVA: 0xE36368 Offset: 0xE36368 VA: 0xE36368
		// private void set_CopyRight(LayoutTitleCopyRight value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B3080 Offset: 0x6B3080 VA: 0x6B3080
		// // RVA: 0xE36370 Offset: 0xE36370 VA: 0xE36370
		// public LayoutTitleLeftBottomButtons get_LbButtons() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B3090 Offset: 0x6B3090 VA: 0x6B3090
		// // RVA: 0xE36378 Offset: 0xE36378 VA: 0xE36378
		// private void set_LbButtons(LayoutTitleLeftBottomButtons value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B30A0 Offset: 0x6B30A0 VA: 0x6B30A0
		// // RVA: 0xE36380 Offset: 0xE36380 VA: 0xE36380
		// public LayoutTitleLogo get_TitleLogo() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B30B0 Offset: 0x6B30B0 VA: 0x6B30B0
		// // RVA: 0xE36388 Offset: 0xE36388 VA: 0xE36388
		// private void set_TitleLogo(LayoutTitleLogo value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B30C0 Offset: 0x6B30C0 VA: 0x6B30C0
		// // RVA: 0xE36390 Offset: 0xE36390 VA: 0xE36390
		// public LayoutTitleArButton get_ArButton() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B30D0 Offset: 0x6B30D0 VA: 0x6B30D0
		// // RVA: 0xE36398 Offset: 0xE36398 VA: 0xE36398
		// private void set_ArButton(LayoutTitleArButton value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B30E0 Offset: 0x6B30E0 VA: 0x6B30E0
		// // RVA: 0xE363A0 Offset: 0xE363A0 VA: 0xE363A0
		// public LayoutMonthlyPassTakeover get_MonthlyPass() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B30F0 Offset: 0x6B30F0 VA: 0x6B30F0
		// // RVA: 0xE363A8 Offset: 0xE363A8 VA: 0xE363A8
		// private void set_MonthlyPass(LayoutMonthlyPassTakeover value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B3100 Offset: 0x6B3100 VA: 0x6B3100
		// // RVA: 0xE363B0 Offset: 0xE363B0 VA: 0xE363B0
		// public GameObject get_Parent() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B3110 Offset: 0x6B3110 VA: 0x6B3110
		// // RVA: 0xE363B8 Offset: 0xE363B8 VA: 0xE363B8
		// public void set_Parent(GameObject value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B3120 Offset: 0x6B3120 VA: 0x6B3120
		// // RVA: 0xE363C0 Offset: 0xE363C0 VA: 0xE363C0
		// public bool get_IsSupportPopupOpen() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B3130 Offset: 0x6B3130 VA: 0x6B3130
		// // RVA: 0xE363C8 Offset: 0xE363C8 VA: 0xE363C8
		// public void set_IsSupportPopupOpen(bool value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B3140 Offset: 0x6B3140 VA: 0x6B3140
		// // RVA: 0xE363D0 Offset: 0xE363D0 VA: 0xE363D0
		// public bool get_IsSetup() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B3150 Offset: 0x6B3150 VA: 0x6B3150
		// // RVA: 0xE363D8 Offset: 0xE363D8 VA: 0xE363D8
		// private void set_IsSetup(bool value) { }

		// // RVA: 0xE363E0 Offset: 0xE363E0 VA: 0xE363E0
		// public void .ctor() { }

		// // RVA: 0xE3646C Offset: 0xE3646C VA: 0xE3646C
		public void LayoutSetup()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xE36478 Offset: 0xE36478 VA: 0xE36478
		// public void Show() { }

		// // RVA: 0xE367F4 Offset: 0xE367F4 VA: 0xE367F4
		// public void ShowArButton() { }

		// // RVA: 0xE368A4 Offset: 0xE368A4 VA: 0xE368A4
		public void SetVisible(bool isVisible)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xE36A24 Offset: 0xE36A24 VA: 0xE36A24
		// public void Reset() { }

		// // RVA: 0xE36A28 Offset: 0xE36A28 VA: 0xE36A28 Slot: 4
		public void Dispose()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B3160 Offset: 0x6B3160 VA: 0x6B3160
		// // RVA: 0xE36AC0 Offset: 0xE36AC0 VA: 0xE36AC0
		public IEnumerator LoadLayoutScreen(Action callback)
		{
			UnityEngine.Debug.LogError("TODO");
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B31D8 Offset: 0x6B31D8 VA: 0x6B31D8
		// // RVA: 0xE36B88 Offset: 0xE36B88 VA: 0xE36B88
		public IEnumerator LoadLayoutScreenTap(Action callback)
		{
			UnityEngine.Debug.LogError("TODO");
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B3250 Offset: 0x6B3250 VA: 0x6B3250
		// // RVA: 0xE36C50 Offset: 0xE36C50 VA: 0xE36C50
		public IEnumerator LoadLayoutButtons(Action callback)
		{
			UnityEngine.Debug.LogError("TODO");
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B32C8 Offset: 0x6B32C8 VA: 0x6B32C8
		// // RVA: 0xE36D18 Offset: 0xE36D18 VA: 0xE36D18
		public IEnumerator LoadLayoutTexts(Action callback)
		{
			UnityEngine.Debug.LogError("TODO");
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B3340 Offset: 0x6B3340 VA: 0x6B3340
		// // RVA: 0xE36DE0 Offset: 0xE36DE0 VA: 0xE36DE0
		public IEnumerator LoadLayoutCopyRight(Action callback)
		{
			UnityEngine.Debug.LogError("TODO");
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B33B8 Offset: 0x6B33B8 VA: 0x6B33B8
		// // RVA: 0xE36EA8 Offset: 0xE36EA8 VA: 0xE36EA8
		public IEnumerator LoadLayoutLbButtons(Action callback)
		{
			UnityEngine.Debug.LogError("TODO");
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B3430 Offset: 0x6B3430 VA: 0x6B3430
		// // RVA: 0xE36F70 Offset: 0xE36F70 VA: 0xE36F70
		public IEnumerator LoadLayoutTitleLogo(Action callback)
		{
			UnityEngine.Debug.LogError("TODO");
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B34A8 Offset: 0x6B34A8 VA: 0x6B34A8
		// // RVA: 0xE37038 Offset: 0xE37038 VA: 0xE37038
		public IEnumerator LoadLayoutArButton(Action callback)
		{
			UnityEngine.Debug.LogError("TODO");
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B3520 Offset: 0x6B3520 VA: 0x6B3520
		// // RVA: 0xE37100 Offset: 0xE37100 VA: 0xE37100
		public IEnumerator LoadLayoutMonthlyPass(Action callback)
		{
			UnityEngine.Debug.LogError("TODO");
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B3598 Offset: 0x6B3598 VA: 0x6B3598
		// // RVA: 0xE371C8 Offset: 0xE371C8 VA: 0xE371C8
		// private IEnumerator LoadLayoutBase(string path, Action<GameObject> callback) { }

		// // RVA: 0xE372A8 Offset: 0xE372A8 VA: 0xE372A8
		// private void LoadLayoutInner(string resourceName, Action<GameObject> callback) { }

		// // RVA: 0xE37424 Offset: 0xE37424 VA: 0xE37424
		// public void PopupShowSupport(Action closeCallback) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B3610 Offset: 0x6B3610 VA: 0x6B3610
		// // RVA: 0xE37768 Offset: 0xE37768 VA: 0xE37768
		// private void <LoadLayoutTitleLogo>b__63_0(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B3620 Offset: 0x6B3620 VA: 0x6B3620
		// // RVA: 0xE37814 Offset: 0xE37814 VA: 0xE37814
		// private void <LoadLayoutArButton>b__64_0(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B3630 Offset: 0x6B3630 VA: 0x6B3630
		// // RVA: 0xE378C0 Offset: 0xE378C0 VA: 0xE378C0
		// private void <LoadLayoutMonthlyPass>b__65_0(GameObject instance) { }
	}
}
