using XeApp.Core;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Menu;
using System;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameSkipScene : MainSceneBase
	{
		[SerializeField]
		private Button prevSceneButton; // 0x28
		public bool isReady; // 0x2C
		private DenominationManager denomControl; // 0x30
		public Action onChangeScene; // 0x34

		//public DenominationManager DenomControl { get; } 0xC089F8

		// RVA: 0xC08A00 Offset: 0xC08A00 VA: 0xC08A00 Slot: 9
		protected override void DoAwake()
		{
			GameManager.Instance.SetFPS(60);
			enableFade = false;
			isReady = false;
			if(prevSceneButton != null)
			{
				prevSceneButton.transform.parent.gameObject.SetActive(false);
			}
			SoundManager.Instance.Initialize();
			denomControl = DenominationManager.Create(transform);
		}

		// RVA: 0xC08C14 Offset: 0xC08C14 VA: 0xC08C14 Slot: 12
		protected override bool DoUpdateEnter()
		{
			if(isReady && !enableFade)
			{
				GameManager.Instance.NowLoading.Hide();
				enableFade = true;
				GC.Collect();
				return true;
			}
			return false;
		}

		// RVA: 0xC08D44 Offset: 0xC08D44 VA: 0xC08D44 Slot: 14
		protected override bool DoUpdateLeave()
		{
			SoundManager.Instance.bgmPlayer.source.Stop();
			SoundManager.Instance.bgmPlayer.source.Pause(false);
			SoundManager.Instance.bgmPlayer.requestDecCacheClear = true;
			DebugFPS.Instance.StopMeasureAvg();
			return true;
		}

		//// RVA: 0xC05E84 Offset: 0xC05E84 VA: 0xC05E84
		//public void GotoPrevScene() { }

		//// RVA: 0xC05C0C Offset: 0xC05C0C VA: 0xC05C0C
		public void GotoMenuScene()
		{
			if (CNGFKOJANNP.HHCJCDFCLOB != null)
				CNGFKOJANNP.HHCJCDFCLOB.KANPNADDJBK_EnableAutoCheck();
			if (onChangeScene != null)
				onChangeScene();
			NextScene("Menu");
		}

		//// RVA: 0xC0606C Offset: 0xC0606C VA: 0xC0606C
		public void GotoTitleScene()
		{
			if(CNGFKOJANNP.HHCJCDFCLOB != null)
				CNGFKOJANNP.HHCJCDFCLOB.KANPNADDJBK_EnableAutoCheck();
			if(onChangeScene != null)
				onChangeScene();
			PopupWindowManager.Close(null, null);
			GameManager.Instance.ClearPushBackButtonHandler();
			NextScene("Title");
		}

		//// RVA: 0xC05E7C Offset: 0xC05E7C VA: 0xC05E7C
		//public bool IsDebugFlow() { }

		//// RVA: 0xC04854 Offset: 0xC04854 VA: 0xC04854
		//public bool IsEnableTransionResult() { }
	}
}
