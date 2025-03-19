using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;
using System.Linq;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class MusicSelectSLiveButton : LayoutUGUIScriptBase
	{
		public enum Style
		{
			BasicLive = 0,
			SimulationLive = 1,
			Num = 2,
		}

		[SerializeField] // RVA: 0x673E34 Offset: 0x673E34 VA: 0x673E34
		private ActionButton button; // 0x18
		[SerializeField] // RVA: 0x673E44 Offset: 0x673E44 VA: 0x673E44
		private RawImageEx imageBg; // 0x1C
		[SerializeField] // RVA: 0x673E54 Offset: 0x673E54 VA: 0x673E54
		private RawImageEx imageFont; // 0x20
		private Rect[] imageBgRectList = new Rect[2]; // 0x24
		private Rect[] imageFontRectList = new Rect[2]; // 0x28
		private AbsoluteLayout layoutRoot; // 0x2C
		private NumberBase numUnlockRank; // 0x30
		private bool isShow; // 0x34

		public Style style { get; private set; } // 0x14
		public Action<int> onClickButton { private get; set; } // 0x38

		// // RVA: 0x167DD64 Offset: 0x167DD64 VA: 0x167DD64
		// public void TryEnter() { }

		// // RVA: 0x167DE08 Offset: 0x167DE08 VA: 0x167DE08
		public void TryLeave()
		{
			if(isShow)
				Leave();
		}

		// // RVA: 0x167DD74 Offset: 0x167DD74 VA: 0x167DD74
		public void Enter()
		{
			isShow = true;
			layoutRoot.StartChildrenAnimGoStop("go_in_02", "st_in_02");
		}

		// // RVA: 0x167DE18 Offset: 0x167DE18 VA: 0x167DE18
		public void Leave()
		{
			isShow = false;
			layoutRoot.StartChildrenAnimGoStop("go_out_02", "st_out_02");
		}

		// // RVA: 0x167DEAC Offset: 0x167DEAC VA: 0x167DEAC
		// public void Show() { }

		// // RVA: 0x167DF30 Offset: 0x167DF30 VA: 0x167DF30
		public void Hide()
		{
			isShow = false;
			layoutRoot.StartChildrenAnimGoStop("st_wait");
		}

		// // RVA: 0x167DFB4 Offset: 0x167DFB4 VA: 0x167DFB4
		public bool IsPlaying()
		{
			return layoutRoot.IsPlaying();
		}

		// // RVA: 0x167DFE0 Offset: 0x167DFE0 VA: 0x167DFE0
		public void SetOptionStyle(Style style)
		{
			this.style = style;
			imageBg.uvRect = imageBgRectList[(int)style];
			imageFont.uvRect = imageFontRectList[(int)style];

		}

		// // RVA: 0x167E0EC Offset: 0x167E0EC VA: 0x167E0EC
		public void SetUnlockRank(int nowRank, int unlockRank)
		{
			if(nowRank < unlockRank)
			{
				numUnlockRank.SetNumber(unlockRank, 0);
			}
			button.Disable = nowRank < unlockRank;
		}

		// // RVA: 0x167E168 Offset: 0x167E168 VA: 0x167E168
		private void OnClickButton()
		{
			SoundManager.Instance.sePlayerMenu.Play((int)mcrs.cs_se_menu.SE_BTN_006);
			this.StartCoroutineWatched(Co_ChangeStyle(style));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F53BC Offset: 0x6F53BC VA: 0x6F53BC
		// // RVA: 0x167E1E0 Offset: 0x167E1E0 VA: 0x167E1E0
		private IEnumerator Co_ChangeStyle(Style style)
		{
			Style changeStyle;
			
			//0x167E8FC
			changeStyle = style;
			if(style == Style.SimulationLive)
				changeStyle = Style.BasicLive;
			else if(style == Style.BasicLive)
				changeStyle = Style.SimulationLive;
			if(onClickButton != null)
				onClickButton((int)changeStyle);
			layoutRoot.StartChildrenAnimGoStop("go_out", "st_out");
			while(layoutRoot.IsPlayingChildren())
				yield return null;
			SetOptionStyle(changeStyle);
			layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x167E2A8 Offset: 0x167E2A8 VA: 0x167E2A8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			imageBgRectList[1] = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("s_m_btn_simu_02"));
			imageBgRectList[0] = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("s_m_btn_simu_01"));
			imageFontRectList[1] = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("s_m_btn_simu_fnt_02"));
			imageFontRectList[0] = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("s_m_btn_simu_fnt_01"));
			layoutRoot = layout.FindViewById("sw_sel_music_btn_simu_transition_anim") as AbsoluteLayout;
			NumberBase[] numbers = transform.GetComponentsInChildren<NumberBase>(true);
			numUnlockRank = numbers.Where((NumberBase _) =>
			{
				//0x167E878
				return _.name == "swnum_simu_off (AbsoluteLayout)";
			}).First();
			button.AddOnClickCallback(OnClickButton);
			Loaded();
			return true;
		}
	}
}
