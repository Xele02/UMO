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
			IsSetup = true;
		}

		// // RVA: 0xE36478 Offset: 0xE36478 VA: 0xE36478
		public void Show()
		{
			if(Buttons != null)
			{
				Buttons.Show();
			}
			if(Screen != null)
			{
				Screen.Show();
			}
			if(LbButtons != null)
			{
				LbButtons.Show();
			}
		}

		// // RVA: 0xE367F4 Offset: 0xE367F4 VA: 0xE367F4
		public void ShowArButton()
		{
			TodoLogger.Log(0, "TODO");
		}

		// // RVA: 0xE368A4 Offset: 0xE368A4 VA: 0xE368A4
		public void SetVisible(bool isVisible)
		{
			TodoLogger.Log(5, "Layout Title Controller SetVisible "+isVisible);
		}

		// // RVA: 0xE36A24 Offset: 0xE36A24 VA: 0xE36A24
		// public void Reset() { }

		// // RVA: 0xE36A28 Offset: 0xE36A28 VA: 0xE36A28 Slot: 4
		public void Dispose()
		{
			TodoLogger.Log(0, "TODO");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B3160 Offset: 0x6B3160 VA: 0x6B3160
		// // RVA: 0xE36AC0 Offset: 0xE36AC0 VA: 0xE36AC0
		public IEnumerator LoadLayoutScreen(Action callback)
		{
    		//UnityEngine.Debug.Log("Enter LoadLayoutScreen");
			//0xE38E7C
			yield return Co.R(LoadLayoutBase("Layout/title/root_title_01_layout_root", (GameObject instance) => {
				//0xE37944
				Screen = instance.GetComponent<LayoutTitleScreen>();
				titleObjectList.Add(instance);
				if(callback != null)
					callback();
			}));
    		//UnityEngine.Debug.Log("Exit LoadLayoutScreen");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B31D8 Offset: 0x6B31D8 VA: 0x6B31D8
		// // RVA: 0xE36B88 Offset: 0xE36B88 VA: 0xE36B88
		public IEnumerator LoadLayoutScreenTap(Action callback)
		{
    		//UnityEngine.Debug.Log("Enter LoadLayoutScreenTap");
			// 0xE39068
			yield return Co.R(LoadLayoutBase("Layout/title/root_title_hit_layout_root", (GameObject instance) => {
				//0xE37A38
				ScreenTap = instance.GetComponent<LayoutTitleScreenTap>();
				titleObjectList.Add(instance);
				if(callback != null)
					callback();
			}));

    		//UnityEngine.Debug.Log("Exit LoadLayoutScreenTap");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B3250 Offset: 0x6B3250 VA: 0x6B3250
		// // RVA: 0xE36C50 Offset: 0xE36C50 VA: 0xE36C50
		public IEnumerator LoadLayoutButtons(Action callback)
		{
    		//UnityEngine.Debug.Log("Enter LoadLayoutButtons");
			//0xE386B4 
			yield return Co.R(LoadLayoutBase("Layout/title/root_title_btn_layout_root", (GameObject instance) => {
				//0xE37B2C
				Buttons = instance.GetComponent<LayoutTitleButtons>();
				titleObjectList.Add(instance);
				if(callback != null)
					callback();
			}));
    		//UnityEngine.Debug.Log("Exit LoadLayoutButtons");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B32C8 Offset: 0x6B32C8 VA: 0x6B32C8
		// // RVA: 0xE36D18 Offset: 0xE36D18 VA: 0xE36D18
		public IEnumerator LoadLayoutTexts(Action callback)
		{
    		//UnityEngine.Debug.Log("Enter LoadLayoutTexts");
			//0xE39254
			yield return Co.R(LoadLayoutBase("Layout/title/root_title_id_version_layout_root", (GameObject instance) =>
			{
				//0xE37C20
				Texts = instance.GetComponent<LayoutTitleTexts>();
				titleObjectList.Add(instance);
				if (callback != null)
					callback();
			}));
			//UnityEngine.Debug.Log("Exit LoadLayoutTexts");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B3340 Offset: 0x6B3340 VA: 0x6B3340
		// // RVA: 0xE36DE0 Offset: 0xE36DE0 VA: 0xE36DE0
		public IEnumerator LoadLayoutCopyRight(Action callback)
		{
    		//UnityEngine.Debug.Log("Enter LoadLayoutCopyRight");
			//0xE388A0
			yield return Co.R(LoadLayoutBase("Layout/title/root_title_right_layout_root", (GameObject instance) =>
			{
				//0xE37D14
				CopyRight = instance.GetComponent<LayoutTitleCopyRight>();
				titleObjectList.Add(instance);
				if (callback != null)
					callback();
			}));
			//UnityEngine.Debug.Log("Exit LoadLayoutCopyRight");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B33B8 Offset: 0x6B33B8 VA: 0x6B33B8
		// // RVA: 0xE36EA8 Offset: 0xE36EA8 VA: 0xE36EA8
		public IEnumerator LoadLayoutLbButtons(Action callback)
		{
    		//UnityEngine.Debug.Log("Enter LoadLayoutLbButtons");
			//0xE38A8C
			yield return Co.R(LoadLayoutBase("Layout/title/root_title_google_btn_layout_root", (GameObject instance) => {
				//0xE37E08
				LbButtons = instance.GetComponent<LayoutTitleLeftBottomButtons>();
				titleObjectList.Add(instance);
				if(callback != null)
					callback();
			}));
    		//UnityEngine.Debug.Log("Exit LoadLayoutLbButtons");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B3430 Offset: 0x6B3430 VA: 0x6B3430
		// // RVA: 0xE36F70 Offset: 0xE36F70 VA: 0xE36F70
		public IEnumerator LoadLayoutTitleLogo(Action callback)
		{
    		//UnityEngine.Debug.Log("Enter LoadLayoutTitleLogo");
			//0xE39440
			yield return Co.R(LoadLayoutBase("Layout/startup/root_start_logo_layout_root", (GameObject instance) => {
				//0xE37768
				TitleLogo = instance.GetComponent<LayoutTitleLogo>();
				titleObjectList.Add(instance);
			}));

			while(!TitleLogo.IsLoaded())
			{
				yield return null;
			}
			if(callback != null)
			{
				callback();
			}

    		//UnityEngine.Debug.Log("Exit LoadLayoutTitleLogo");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B34A8 Offset: 0x6B34A8 VA: 0x6B34A8
		// // RVA: 0xE37038 Offset: 0xE37038 VA: 0xE37038
		public IEnumerator LoadLayoutArButton(Action callback)
		{
    		//UnityEngine.Debug.Log("Enter LoadLayoutArButton");
			//0xE38238
			yield return Co.R(LoadLayoutBase("Layout/title/root_title_ar_btn_layout_root", (GameObject instance) =>
			{
				//0xE37814
				ArButton = instance.GetComponent<LayoutTitleArButton>();
				titleObjectList.Add(instance);
			}));
			while (!ArButton.IsLoaded())
				yield return null;
			if (callback != null)
				callback();
			//UnityEngine.Debug.Log("Exit LoadLayoutArButton");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B3520 Offset: 0x6B3520 VA: 0x6B3520
		// // RVA: 0xE37100 Offset: 0xE37100 VA: 0xE37100
		public IEnumerator LoadLayoutMonthlyPass(Action callback)
		{
    		//UnityEngine.Debug.Log("Enter LoadLayoutMonthlyPass");
			//0xE38C78
			yield return Co.R(LoadLayoutBase("Layout/sel_inheriting/root_inh_pop_04_layout_root", (GameObject instance) =>
			{
				//0xE378C0
				MonthlyPass = instance.GetComponent<LayoutMonthlyPassTakeover>();
			}));
			while (!MonthlyPass.IsLoaded())
				yield return null;
			if (callback != null)
				callback();
			//UnityEngine.Debug.Log("Exit LoadLayoutMonthlyPass");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B3598 Offset: 0x6B3598 VA: 0x6B3598
		// // RVA: 0xE371C8 Offset: 0xE371C8 VA: 0xE371C8
		private IEnumerator LoadLayoutBase(string path, Action<GameObject> callback)
		{
    		//UnityEngine.Debug.Log("Enter LoadLayoutBase");
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

    		//UnityEngine.Debug.Log("Exit LoadLayoutBase");
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
		public void PopupShowSupport(Action closeCallback)
		{
			TodoLogger.LogNotImplemented("PopupShowSupport");
		}

		// [CompilerGeneratedAttribute] // RVA: 0x6B3610 Offset: 0x6B3610 VA: 0x6B3610
		// // RVA: 0xE37768 Offset: 0xE37768 VA: 0xE37768
		// private void <LoadLayoutTitleLogo>b__63_0(GameObject instance) { }
	}
}
