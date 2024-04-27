using System.Collections;
using UnityEngine;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class UnlockDivaArgs : TransitionArgs
	{
		public int diva_id; // 0x8
	}

	public class UnlockDivaScene : TransitionRoot
	{
		private UnlockDivaManager _unlockDivaManager; // 0x48

		// RVA: 0x1264024 Offset: 0x1264024 VA: 0x1264024 Slot: 5
		protected override void Start()
		{
			this.StartCoroutineWatched(ResourceLoad());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7322BC Offset: 0x7322BC VA: 0x7322BC
		// // RVA: 0x1264048 Offset: 0x1264048 VA: 0x1264048
		private IEnumerator ResourceLoad()
		{
			string bundleName; // 0x14
			AssetBundleLoadAssetOperation op; // 0x18

			//0x1264838
			bundleName = "ly/084.xab";
			op = AssetBundleManager.LoadAssetAsync(bundleName, "UnlockDivaManager", typeof(GameObject));
			yield return op;
			GameObject g = Instantiate(op.GetAsset<GameObject>());
			g.transform.SetParent(transform, false);
			_unlockDivaManager = g.GetComponent<UnlockDivaManager>();
			_unlockDivaManager.PushOkButtonHandler += OnClickOkBtn;
			_unlockDivaManager.InitializeLayoutResource();
			while(!_unlockDivaManager.IsLoadedLayout)
				yield return null;
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			IsReady = true;
		}

		// // RVA: 0x12640F4 Offset: 0x12640F4 VA: 0x12640F4
		private void OnClickOkBtn()
		{
			MenuScene.Instance.Return(true);
		}

		// // RVA: 0x1264194 Offset: 0x1264194 VA: 0x1264194
		// private void OnShowTutorialWindow(UnityAction endCallBack) { }

		// [IteratorStateMachineAttribute] // RVA: 0x732334 Offset: 0x732334 VA: 0x732334
		// // RVA: 0x12641B8 Offset: 0x12641B8 VA: 0x12641B8
		// private IEnumerator Co_ShowTutorial(UnityAction endCallBack) { }

		// // RVA: 0x1264280 Offset: 0x1264280 VA: 0x1264280
		// private bool CheckTutorialCodition(TutorialConditionId conditionId) { }

		// RVA: 0x1264334 Offset: 0x1264334 VA: 0x1264334 Slot: 16
		protected override void OnPreSetCanvas()
		{
			int divaId = 1;
			if(Args != null && Args is UnlockDivaArgs)
			{
				divaId = (Args as UnlockDivaArgs).diva_id;
			}
			_unlockDivaManager.InitializeResource(divaId);
			MenuScene.Instance.BgControl.SetPriority(BgPriority.TopMost);
		}

		// RVA: 0x1264478 Offset: 0x1264478 VA: 0x1264478 Slot: 14
		protected override void OnDestoryScene()
		{
			MenuScene.Instance.BgControl.SetPriority(BgPriority.Bottom);
			_unlockDivaManager.Release(false);
			UnlockFadeManager.Release();
			GameManager.Instance.SetFPS(30);
		}

		// RVA: 0x12645E8 Offset: 0x12645E8 VA: 0x12645E8 Slot: 12
		protected override void OnStartExitAnimation()
		{
			base.OnStartExitAnimation();
		}

		// RVA: 0x12645F0 Offset: 0x12645F0 VA: 0x12645F0 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return true;
		}

		// RVA: 0x12645F8 Offset: 0x12645F8 VA: 0x12645F8 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return _unlockDivaManager.IsLoaded3dResource && _unlockDivaManager.IsLoadedLayout;
		}

		// RVA: 0x1264648 Offset: 0x1264648 VA: 0x1264648 Slot: 23
		protected override void OnActivateScene()
		{
			_unlockDivaManager.StartDirection();
		}
	}
}
