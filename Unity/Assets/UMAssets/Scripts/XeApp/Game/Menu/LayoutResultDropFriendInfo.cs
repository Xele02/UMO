using System;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutResultDropFriendInfo : LayoutUGUIScriptBase
	{
		private bool isSetupFinished; // 0x11
		public Action onFinished; // 0x14
		private AbsoluteLayout layoutRootAnim; // 0x18
		private AbsoluteLayout layoutRoot; // 0x1C
		private Text textPlayerName; // 0x20
		private Text textPlayerRank; // 0x24
		private Text textSingRank; // 0x28
		private RawImageEx imageSingRank; // 0x2C
		private AbsoluteLayout layoutDivaImage; // 0x30
		private RawImageEx imageDiva; // 0x34
		private DivaIconDecoration divaIconDecoration; // 0x38
		private AbsoluteLayout layoutSceneImage; // 0x3C
		private RawImageEx imageScene; // 0x40
		private SceneIconDecoration sceneIconDecoration; // 0x44
		private ActionButton sendFriendRequest; // 0x48
		public Action onClickSendFriendRequestCallback; // 0x4C

		// RVA: 0x1D8E64C Offset: 0x1D8E64C VA: 0x1D8E64C
		private void Start()
		{
			return;
		}

		// RVA: 0x1D8E650 Offset: 0x1D8E650 VA: 0x1D8E650
		private void Update()
		{
			return;
		}

		// RVA: 0x1D8E654 Offset: 0x1D8E654 VA: 0x1D8E654 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			layoutRootAnim = layout.FindViewById("sw_guest_set_anim") as AbsoluteLayout;
			layoutRoot = layoutRootAnim.FindViewById("sw_guest_set") as AbsoluteLayout;
			layoutDivaImage = layoutRoot.FindViewById("swtex_cmn_diva_icon") as AbsoluteLayout;
			layoutSceneImage = layoutRoot.FindViewById("swtex_cmn_scene_icon") as AbsoluteLayout;
			Transform t = transform.Find("sw_guest_set_anim (AbsoluteLayout)/sw_guest_set (AbsoluteLayout)");
			imageDiva = t.Find("swtexc_cmn_diva_icon (ImageView)").GetComponent<RawImageEx>();
			imageScene = t.Find("swtex_cmn_scene_icon (ImageView)").GetComponent<RawImageEx>();
			imageSingRank = t.Find("cmn_musicrate (AbsoluteLayout)/cmn_musicrate (ImageView)").GetComponent<RawImageEx>();
			textPlayerName = t.Find("g_name (TextView)").GetComponent<Text>();
			textPlayerRank = t.Find("g_lv (TextView)").GetComponent<Text>();
			textSingRank = t.Find("lv_txt_00 (TextView)").GetComponent<Text>();
			sendFriendRequest = t.Find("sw_btn_friend (AbsoluteLayout)").GetComponent<ActionButton>();
			sendFriendRequest.AddOnClickCallback(OnClickSendFriendRequest);
			Loaded();
			return true;
		}

		// // RVA: 0x1D8EBB8 Offset: 0x1D8EBB8 VA: 0x1D8EBB8
		// public void Setup(EAJCBFGKKFA friendData) { }

		// // RVA: 0x1D8F208 Offset: 0x1D8F208 VA: 0x1D8F208
		public void Release()
		{
			if(divaIconDecoration != null)
				divaIconDecoration.Release();
			if(sceneIconDecoration != null)
				sceneIconDecoration.Release();
		}

		// // RVA: 0x1D8F240 Offset: 0x1D8F240 VA: 0x1D8F240
		public void StartBeginAnim()
		{
			TodoLogger.Log(0, "StartBeginAnim");
			if(onFinished != null)
				onFinished();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7190D4 Offset: 0x7190D4 VA: 0x7190D4
		// // RVA: 0x1D8F2F0 Offset: 0x1D8F2F0 VA: 0x1D8F2F0
		// private IEnumerator Co_PlayingAnim() { }

		// // RVA: 0x1D8F39C Offset: 0x1D8F39C VA: 0x1D8F39C
		// public void SkipBeginAnim() { }

		// // RVA: 0x1D8F1D8 Offset: 0x1D8F1D8 VA: 0x1D8F1D8
		// public void HiddenFriendRequestButton() { }

		// // RVA: 0x1D8F424 Offset: 0x1D8F424 VA: 0x1D8F424
		// public void DisableFriendRequestButton() { }

		// // RVA: 0x1D8F454 Offset: 0x1D8F454 VA: 0x1D8F454
		private void OnClickSendFriendRequest()
		{
			TodoLogger.LogNotImplemented("OnClickSendFriendRequest");
		}

		// [CompilerGeneratedAttribute] // RVA: 0x71914C Offset: 0x71914C VA: 0x71914C
		// // RVA: 0x1D8F470 Offset: 0x1D8F470 VA: 0x1D8F470
		// private bool <Co_PlayingAnim>b__22_0() { }
	}
}
