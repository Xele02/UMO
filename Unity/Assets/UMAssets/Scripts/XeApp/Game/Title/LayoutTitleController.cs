using System;
using XeApp.Game.Menu;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using XeSys;

namespace XeApp.Game.Title
{
	public class LayoutTitleController : IDisposable
	{
		private List<GameObject> titleObjectList = new List<GameObject>(); // 0x34
		private const int SiblingIndex = 2;

		public LayoutTitleButtons Buttons { get; private set; } // 0x8
		public LayoutTitleScreen Screen { get; private set; } // 0xC
		public LayoutTitleScreenTap ScreenTap { get; private set; } // 0x10
		public LayoutTitleTexts Texts { get; private set; } // 0x14
		public LayoutTitleCopyRight CopyRight { get; private set; } // 0x18
		public LayoutTitleLeftBottomButtons LbButtons { get; private set; } // 0x1C
		public LayoutTitleLogo TitleLogo { get; private set; } // 0x20
		public LayoutTitleArButton ArButton { get; private set; } // 0x24
		public LayoutMonthlyPassTakeover MonthlyPass { get; private set; } // 0x28
		public GameObject Parent { get; set; } // 0x2C
		public bool IsSupportPopupOpen { get; set; } // 0x30
		public bool IsSetup { get; private set; } // 0x31

		// // RVA: 0xE3646C Offset: 0xE3646C VA: 0xE3646C
		public void LayoutSetup()
		{
			UnityEngine.Debug.LogWarning("TODO LayoutTitleController LayoutSetup");
		}

		// // RVA: 0xE36478 Offset: 0xE36478 VA: 0xE36478
		public void Show()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xE367F4 Offset: 0xE367F4 VA: 0xE367F4
		public void ShowArButton()
		{
			UnityEngine.Debug.LogError("TODO");
		}

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
    		UnityEngine.Debug.LogError("Enter LoadLayoutScreen");
			UnityEngine.Debug.LogWarning("TODO LoadLayoutScreen");
    		UnityEngine.Debug.LogError("Exit LoadLayoutScreen");
			callback();
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B31D8 Offset: 0x6B31D8 VA: 0x6B31D8
		// // RVA: 0xE36B88 Offset: 0xE36B88 VA: 0xE36B88
		public IEnumerator LoadLayoutScreenTap(Action callback)
		{
    		UnityEngine.Debug.LogError("Enter LoadLayoutScreenTap");
			UnityEngine.Debug.LogWarning("TODO LoadLayoutScreenTap");
    		UnityEngine.Debug.LogError("Exit LoadLayoutScreenTap");
			callback();
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B3250 Offset: 0x6B3250 VA: 0x6B3250
		// // RVA: 0xE36C50 Offset: 0xE36C50 VA: 0xE36C50
		public IEnumerator LoadLayoutButtons(Action callback)
		{
    		UnityEngine.Debug.LogError("Enter LoadLayoutButtons");
			UnityEngine.Debug.LogWarning("TODO LoadLayoutButtons");
    		UnityEngine.Debug.LogError("Exit LoadLayoutButtons");
			callback();
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B32C8 Offset: 0x6B32C8 VA: 0x6B32C8
		// // RVA: 0xE36D18 Offset: 0xE36D18 VA: 0xE36D18
		public IEnumerator LoadLayoutTexts(Action callback)
		{
    		UnityEngine.Debug.LogError("Enter LoadLayoutTexts");
			UnityEngine.Debug.LogWarning("TODO LoadLayoutTexts");
    		UnityEngine.Debug.LogError("Exit LoadLayoutTexts");
			callback();
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B3340 Offset: 0x6B3340 VA: 0x6B3340
		// // RVA: 0xE36DE0 Offset: 0xE36DE0 VA: 0xE36DE0
		public IEnumerator LoadLayoutCopyRight(Action callback)
		{
    		UnityEngine.Debug.LogError("Enter LoadLayoutCopyRight");
			UnityEngine.Debug.LogWarning("TODO LoadLayoutCopyRight");
    		UnityEngine.Debug.LogError("Exit LoadLayoutCopyRight");
			callback();
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B33B8 Offset: 0x6B33B8 VA: 0x6B33B8
		// // RVA: 0xE36EA8 Offset: 0xE36EA8 VA: 0xE36EA8
		public IEnumerator LoadLayoutLbButtons(Action callback)
		{
    		UnityEngine.Debug.LogError("Enter LoadLayoutLbButtons");
			UnityEngine.Debug.LogWarning("TODO LoadLayoutLbButtons");
    		UnityEngine.Debug.LogError("Exit LoadLayoutLbButtons");
			callback();
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B3430 Offset: 0x6B3430 VA: 0x6B3430
		// // RVA: 0xE36F70 Offset: 0xE36F70 VA: 0xE36F70
		public IEnumerator LoadLayoutTitleLogo(Action callback)
		{
    		UnityEngine.Debug.LogError("Enter LoadLayoutTitleLogo");
			//0xE39440
			yield return LoadLayoutBase("Layout/startup/root_start_logo_layout_root", (GameObject instance) => {
				//0xE37768
				TitleLogo = instance.GetComponent<LayoutTitleLogo>();
				titleObjectList.Add(instance);
			});

			while(!TitleLogo.IsLoaded())
			{
				yield return null;
			}
			if(callback != null)
			{
				callback();
			}

    		UnityEngine.Debug.LogError("Exit LoadLayoutTitleLogo");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B34A8 Offset: 0x6B34A8 VA: 0x6B34A8
		// // RVA: 0xE37038 Offset: 0xE37038 VA: 0xE37038
		public IEnumerator LoadLayoutArButton(Action callback)
		{
    		UnityEngine.Debug.LogError("Enter LoadLayoutArButton");
			UnityEngine.Debug.LogWarning("TODO LoadLayoutArButton");
    		UnityEngine.Debug.LogError("Exit LoadLayoutArButton");
			callback();
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B3520 Offset: 0x6B3520 VA: 0x6B3520
		// // RVA: 0xE37100 Offset: 0xE37100 VA: 0xE37100
		public IEnumerator LoadLayoutMonthlyPass(Action callback)
		{
    		UnityEngine.Debug.LogError("Enter LoadLayoutMonthlyPass");
			UnityEngine.Debug.LogWarning("TODO LoadLayoutMonthlyPass");
    		UnityEngine.Debug.LogError("Exit LoadLayoutMonthlyPass");
			callback();
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B3598 Offset: 0x6B3598 VA: 0x6B3598
		// // RVA: 0xE371C8 Offset: 0xE371C8 VA: 0xE371C8
		private IEnumerator LoadLayoutBase(string path, Action<GameObject> callback)
		{
    		UnityEngine.Debug.LogError("Enter LoadLayoutBase");
			//0xE3843C

			bool isLoading = false;
			GameObject obj = null;
			//0xE37EFC
			LoadLayoutInner(path, (GameObject instance) => {
				//0xE37EFC
				if(Parent != null)
				{
					instance.transform.SetParent(Parent.transform, false);
					instance.transform.SetSiblingIndex(2);
					obj = instance;
				}
				isLoading = true;
				titleObjectList.Add(instance);
			});
			while(!isLoading)
			{
				yield return null;
			}
			if(callback != null)
			{
				callback(obj);
			}

    		UnityEngine.Debug.LogError("Exit LoadLayoutBase");
		}

		// // RVA: 0xE372A8 Offset: 0xE372A8 VA: 0xE372A8
		private void LoadLayoutInner(string resourceName, Action<GameObject> callback)
		{
			ResourcesManager.Instance.Request(resourceName, (FileResultObject flo) => {
				// 0xE380B4
				GameObject obj = UnityEngine.Object.Instantiate(flo.unityObject) as GameObject;
				if(callback != null)
					callback(obj);
				titleObjectList.Add(obj);
				return true;
			});
			ResourcesManager.Instance.Load();
		}

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
