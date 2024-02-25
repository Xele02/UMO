using System;
using System.Collections;
using UnityEngine;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class UnlockValkyrieScene : TransitionRoot
	{
		[Serializable]
		public class CameraInfo
		{
			public Vector3 CameraPos = Vector3.zero; // 0x8
			public Vector3 TargetPos = Vector3.zero; // 0x14

			// RVA: 0x1653568 Offset: 0x1653568 VA: 0x1653568
			public CameraInfo()
			{
				return;
			}

			// RVA: 0x164E248 Offset: 0x164E248 VA: 0x164E248
			public CameraInfo(Vector3 position, Vector3 target)
			{
				CameraPos = position;
				TargetPos = target;
			}

			//// RVA: 0x1650CA4 Offset: 0x1650CA4 VA: 0x1650CA4
			public Vector3 GetTargetPos()
			{
				return new Vector3(TargetPos.x * Mathf.Clamp01((Screen.width * 1.0f / Screen.height) / 1.494949f), TargetPos.y, TargetPos.z);
			}
		}

		private bool m_IsAllComplete; // 0x45
		private int m_ValkyrieId; // 0x48
		private PNGOLKLFFLH m_ViewData; // 0x4C
		private UnlockValkyrieManager _unlockValkyrieManager; // 0x50

		// RVA: 0x1652740 Offset: 0x1652740 VA: 0x1652740 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			this.StartCoroutineWatched(Co_Initialize());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73315C Offset: 0x73315C VA: 0x73315C
		// // RVA: 0x1652770 Offset: 0x1652770 VA: 0x1652770
		private IEnumerator Co_Initialize()
		{
			string bundleName; // 0x14
			AssetBundleLoadAssetOperation op; // 0x18

			//0x1652D34
			bundleName = "ly/086.xab";
			op = AssetBundleManager.LoadAssetAsync(bundleName, "UnlockValkyrieManager", typeof(GameObject));
			yield return op;
			GameObject go = Instantiate(op.GetAsset<GameObject>());
			go.transform.SetParent(transform, false);
			_unlockValkyrieManager = go.GetComponent<UnlockValkyrieManager>();
			_unlockValkyrieManager.InitializeLayout();
			yield return new WaitWhile(() =>
			{
				//0x1652CA4
				return !_unlockValkyrieManager.IsInitializedLayout;
			});
			_unlockValkyrieManager.PushOkButtonHandler = OnClickOk;
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			IsReady = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7331D4 Offset: 0x7331D4 VA: 0x7331D4
		// // RVA: 0x165281C Offset: 0x165281C VA: 0x165281C
		private IEnumerator Co_Setup()
		{
			//0x16531D0
			UnlockValkyrieArgs arg = Args as UnlockValkyrieArgs;
			m_ValkyrieId = arg.valkyrie_id;
			_unlockValkyrieManager.InitializeValkyrie(m_ValkyrieId);
			m_IsAllComplete = false;
			yield return new WaitWhile(() =>
			{
				//0x1652CD4
				if(_unlockValkyrieManager.IsInitializedValkyrie)
				{
					return !_unlockValkyrieManager.IsInitializedPilotVoice;
				}
				return true;
			});
			m_IsAllComplete = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73324C Offset: 0x73324C VA: 0x73324C
		// // RVA: 0x16528C8 Offset: 0x16528C8 VA: 0x16528C8
		private IEnumerator Co_StartSequence()
		{
			//0x165345C
			yield return null;
			_unlockValkyrieManager.StartDirection();
		}

		// RVA: 0x1652974 Offset: 0x1652974 VA: 0x1652974 Slot: 16
		protected override void OnPreSetCanvas()
		{
			this.StartCoroutineWatched(Co_Setup());
			MenuScene.Instance.BgControl.SetPriority(BgPriority.TopMost);
		}

		// RVA: 0x1652A50 Offset: 0x1652A50 VA: 0x1652A50 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return m_IsAllComplete;
		}

		// RVA: 0x1652A58 Offset: 0x1652A58 VA: 0x1652A58 Slot: 14
		protected override void OnDestoryScene()
		{
			_unlockValkyrieManager.Release();
			GameManager.Instance.SetFPS(30);
			MenuScene.Instance.BgControl.SetPriority(BgPriority.Bottom);
		}

		// RVA: 0x1652B90 Offset: 0x1652B90 VA: 0x1652B90 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			return;
		}

		// RVA: 0x1652B94 Offset: 0x1652B94 VA: 0x1652B94 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return true;
		}

		// RVA: 0x1652B9C Offset: 0x1652B9C VA: 0x1652B9C Slot: 21
		protected override void OnOpenScene()
		{
			this.StartCoroutineWatched(Co_StartSequence());
		}

		// RVA: 0x1652BC0 Offset: 0x1652BC0 VA: 0x1652BC0 Slot: 12
		protected override void OnStartExitAnimation()
		{
			return;
		}

		// RVA: 0x1652BC4 Offset: 0x1652BC4 VA: 0x1652BC4 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return true;
		}

		// // RVA: 0x1652BCC Offset: 0x1652BCC VA: 0x1652BCC
		private void OnClickOk()
		{
			UnlockFadeManager.Release();
			MenuScene.Instance.Return(true);
		}
	}
}
