using System.Collections;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeSys.uGUI;

namespace XeApp.Game.MiniGame
{
	public class MiniGameScene : MainSceneBase
	{
		public static int miniGameId = 1; // 0x0
		public static int stageNum = 1; // 0x4
		private bool isUseCustomInputModle; // 0x28

		// RVA: 0x1CF0AD4 Offset: 0x1CF0AD4 VA: 0x1CF0AD4 Slot: 9
		protected override void DoAwake()
		{
			enableFade = false;
			isUseCustomInputModle = GameManager.Instance.EventSystemControl.SwitchDefaultInputModule();
		}

		// RVA: 0x1CF0BA8 Offset: 0x1CF0BA8 VA: 0x1CF0BA8
		public void OnDestroy()
		{
			if (!isUseCustomInputModle)
				return;
			GameManager.Instance.EventSystemControl.SwitchCustomInputModle();
			isUseCustomInputModle = false;
		}

		// RVA: 0x1CF0C7C Offset: 0x1CF0C7C VA: 0x1CF0C7C Slot: 10
		protected override void DoStart()
		{
			base.DoStart();
		}

		// RVA: 0x1CF0C84 Offset: 0x1CF0C84 VA: 0x1CF0C84 Slot: 12
		protected override bool DoUpdateEnter()
		{
			this.StartCoroutineWatched(LoadAssetBundle());
			GameManager.Instance.NowLoading.Hide();
			return base.DoUpdateEnter();
		}

		// RVA: 0x1CF0DF4 Offset: 0x1CF0DF4 VA: 0x1CF0DF4 Slot: 13
		protected override void DoUpdateMain()
		{
			base.DoUpdateMain();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6B10A8 Offset: 0x6B10A8 VA: 0x6B10A8
		//// RVA: 0x1CF0D68 Offset: 0x1CF0D68 VA: 0x1CF0D68
		private IEnumerator LoadAssetBundle()
		{
			string bundleName; // 0x14
			AssetBundleLoadAssetOperation op; // 0x18

			//0x1CF183C
			bundleName = string.Format("ap/{0:D3}.xab", miniGameId);
			string assetName = string.Format("MiniGame{0:D3}", miniGameId);
			op = AssetBundleManager.LoadAssetAsync(bundleName, assetName, typeof(GameObject));
			yield return op;
			GameObject g = Instantiate(op.GetAsset<GameObject>());
			g.transform.SetParent(transform.GetChild(0), false);
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
		}

		//// RVA: 0x1CED560 Offset: 0x1CED560 VA: 0x1CED560
		public void BackScene()
		{
			NextScene(prevSceneName);
		}

		//// RVA: 0x1CF0908 Offset: 0x1CF0908 VA: 0x1CF0908
		public bool CheckDateLineAndAssetUpdate()
		{
			return PGIGNJDPCAH.MNANNMDBHMP(() =>
			{
				//0x1CF1090
				this.StartCoroutineWatched(Co_GotoLoginBonus());
			}, () =>
			{
				//0x1CF10B4
				this.StartCoroutineWatched(Co_GotoTitle());
			});
		}

		//// RVA: 0x1CED0E4 Offset: 0x1CED0E4 VA: 0x1CED0E4
		public void GotoTitle()
		{
			this.StartCoroutineWatched(Co_GotoTitle());
		}

		//// RVA: 0x1CF0EA8 Offset: 0x1CF0EA8 VA: 0x1CF0EA8
		//public void GotoLoginBonus() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6B1120 Offset: 0x6B1120 VA: 0x6B1120
		//// RVA: 0x1CF0ECC Offset: 0x1CF0ECC VA: 0x1CF0ECC
		private IEnumerator Co_GotoLoginBonus()
		{
			UGUIFader fade;

			//0x1CF10DC
			GameManager.Instance.ClearPushBackButtonHandler();
			fade = GameManager.Instance.fullscreenFader;
			if(fade.currentColor.a < 1)
			{
				fade.Fade(0.1f, Color.black);
			}
			while(fade.isFading)
				yield return null;
			PopupWindowManager.Close(null, null);
			SoundManager.Instance.bgmPlayer.Stop();
			NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.MBOIDKCMCDL = false;
			MenuScene.ComebackByRestart = true;
			NextScene("Menu");
			yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6B1198 Offset: 0x6B1198 VA: 0x6B1198
		//// RVA: 0x1CF0E1C Offset: 0x1CF0E1C VA: 0x1CF0E1C
		private IEnumerator Co_GotoTitle()
		{
			UGUIFader fade;

			//0x1CF14A8
			GameManager.Instance.ClearPushBackButtonHandler();
			fade = GameManager.Instance.fullscreenFader;
			if(fade.currentColor.a < 1)
			{
				fade.Fade(0.1f, Color.black);
			}
			while(fade.isFading)
				yield return null;
			PopupWindowManager.Close(null, null);
			SoundManager.Instance.bgmPlayer.Stop();
			NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.MBOIDKCMCDL = false;
			NextScene("Title");
			yield return null;
		}
	}
}
