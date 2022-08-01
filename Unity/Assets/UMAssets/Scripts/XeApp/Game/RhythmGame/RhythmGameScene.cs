using XeApp.Core;
using UnityEngine.UI;
using UnityEngine;
using System;
using XeApp.Game.Menu;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameScene : MainSceneBase
	{
		[SerializeField]
		private Button prevSceneButton; // 0x28
		public bool isReady; // 0x2C
		private DenominationManager denomControl; // 0x30
		public Action onChangeScene; // 0x34

		public DenominationManager DenomControl { get { return denomControl; } } // get_DenomControl 0xBFD62C

		// // RVA: 0xBFD634 Offset: 0xBFD634 VA: 0xBFD634 Slot: 9
		protected override void DoAwake()
		{
			CNGFKOJANNP c = CNGFKOJANNP.HHCJCDFCLOB;
			if(c != null)
				c.IKHJJMKLAEP();

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

		// // RVA: 0xBFD848 Offset: 0xBFD848 VA: 0xBFD848 Slot: 12
		protected override bool DoUpdateEnter()
		{
			if(isReady && !enableFade)
			{
				GameManager.Instance.NowLoading.Hide();
				enableFade = true;
				return true;
			}
			return false;
		}

		// // RVA: 0xBFD978 Offset: 0xBFD978 VA: 0xBFD978 Slot: 14
		protected override bool DoUpdateLeave()
		{
			SoundManager.Instance.bgmPlayer.source.Stop();
			SoundManager.Instance.bgmPlayer.source.Pause(false);
			SoundManager.Instance.bgmPlayer.requestDecCacheClear = true;
			DebugFPS.Instance.StopMeasureAvg();
			return true;
		}

		// // RVA: 0xBFDB40 Offset: 0xBFDB40 VA: 0xBFDB40
		// public void GotoPrevScene() { }

		// // RVA: 0xBFDCE0 Offset: 0xBFDCE0 VA: 0xBFDCE0
		public void GotoMenuScene()
		{
			if(CNGFKOJANNP.HHCJCDFCLOB != null)
			{
				CNGFKOJANNP.HHCJCDFCLOB.KANPNADDJBK();
			}
			if (onChangeScene != null)
				onChangeScene();
			NextScene("Menu");
		}

		// // RVA: 0xBFDD74 Offset: 0xBFDD74 VA: 0xBFDD74
		// public void GotoTitleScene() { }

		// // RVA: 0xBFDE98 Offset: 0xBFDE98 VA: 0xBFDE98
		// public bool IsDebugFlow() { }

		// // RVA: 0xBFDEA0 Offset: 0xBFDEA0 VA: 0xBFDEA0
		public bool IsEnableTransionResult()
		{
			return true;
		}
	}
}
