using System;
using System.Collections;
using mcrs;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutLuckyleaf : LayoutUGUIScriptBase
	{
		private AbsoluteLayout layoutRoot; // 0x14
		private AbsoluteLayout layoutEffect; // 0x18
		private AbsoluteLayout[] layoutSlot; // 0x1C
		private AbsoluteLayout[] layoutSlotEffect; // 0x20
		private LimitOverControl.AnimType type; // 0x24
		private int nowLevel; // 0x28
		private int nowMaxLevel; // 0x2C
		private int prevMaxLevel; // 0x30
		private bool isSkiped; // 0x34
		private Action onEndAnim; // 0x38

		// RVA: 0x1D66F90 Offset: 0x1D66F90 VA: 0x1D66F90
		private void Update()
		{
			if(!IsLoaded())
				return;
			CheckSkipStep();
		}

		// RVA: 0x1D67084 Offset: 0x1D67084 VA: 0x1D67084 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			layoutRoot = layout.FindViewById("sw_luckyleaf_anim") as AbsoluteLayout;
			layoutRoot.StartChildrenAnimGoStop("st_wait");
			layoutEffect = layout.FindViewById("ef_g_01") as AbsoluteLayout;
			layoutEffect.StartAnimGoStop("st_wait");
			layoutEffect.StartChildrenAnimLoop("lo_");
			layoutSlot = new AbsoluteLayout[5];
			layoutSlotEffect = new AbsoluteLayout[5];
			for(int i = 0; i < 5; i++)
			{
				string s = "sw_luckyleaf_anim_on_" + (i + 1).ToString("D2");
				string s2 = "sw_luckyleaf_anim_on_ef_" + (i + 1).ToString("D2");
				layoutSlot[i] = layout.FindViewByExId(s) as AbsoluteLayout;
				layoutSlotEffect[i] = layout.FindViewByExId(s2) as AbsoluteLayout;
			}
			Loaded();
			return true;
		}

		// RVA: 0x1D67590 Offset: 0x1D67590 VA: 0x1D67590
		public void SetStatus(LimitOverControl.AnimType type, int nowLevel, int prevMaxLevel, int nowMaxLevel)
		{
			this.type = type;
			this.nowLevel = nowLevel;
			this.nowMaxLevel = nowMaxLevel;
			this.prevMaxLevel = prevMaxLevel;
			int a1 = prevMaxLevel;
			if(type != LimitOverControl.AnimType.Add)
			{
				a1 = 0;
				if(type == LimitOverControl.AnimType.Release)
					a1 = nowMaxLevel;
			}
			string s = "st_in_add_" + a1.ToString("D2");
			layoutRoot.StartChildrenAnimGoStop(s, s);
			for(int i = 0; i < layoutSlot.Length; i++)
			{
				if(nowLevel == i + 1)
				{
					if(type == LimitOverControl.AnimType.Add)
					{
						SetSlotEnable(nowLevel, true);
					}
					else if(type == LimitOverControl.AnimType.Release)
					{
						SetSlotEnable(nowLevel, false);
					}
				}
				else
				{
					if(i + 1 < nowLevel)
					{
						SetSlotEnable(i + 1, true);
					}
					else
					{
						SetSlotEnable(i + 1, false);
					}
				}
			}
		}

		// // RVA: 0x1D6772C Offset: 0x1D6772C VA: 0x1D6772C
		private void SetSlotEnable(int level, bool enable)
		{
			if(enable)
			{
				layoutSlot[level - 1].StartChildrenAnimGoStop("st_in_on", "st_in_on");
				layoutSlotEffect[level - 1].StartChildrenAnimGoStop("st_in_on", "st_in_on");
			}
			else
			{
				layoutSlot[level - 1].StartChildrenAnimGoStop("st_wait", "st_wait");
				layoutSlotEffect[level - 1].StartChildrenAnimGoStop("st_wait", "st_wait");
			}
		}

		// // RVA: 0x1D66FB8 Offset: 0x1D66FB8 VA: 0x1D66FB8
		private void CheckSkipStep()
		{
			if(!isSkiped)
			{
				if(InputManager.Instance.GetInScreenTouchCount() < 1)
					return;
				if(IsTouch())
					SkipAnim();
			}
		}

		// // RVA: 0x1D678D4 Offset: 0x1D678D4 VA: 0x1D678D4
		private bool IsTouch()
		{
			TouchInfoRecord record = InputManager.Instance.GetFirstInScreenTouchRecord();
			if(record != null)
			{
				Vector2 pos = record.currentInfo.GetSceneInnerPosition();
				return SystemManager.rawAppScreenRect.x < pos.x && 
					pos.x <= SystemManager.rawAppScreenRect.xMax && 
					SystemManager.rawAppScreenRect.y < pos.y && 
					pos.y <= SystemManager.rawAppScreenRect.yMax && record.currentInfo.isEnded;

			}
			return false;
		}

		// RVA: 0x1D67AF4 Offset: 0x1D67AF4 VA: 0x1D67AF4
		public void StartAnim(Action onEndAnim)
		{
			this.onEndAnim = onEndAnim;
			this.StartCoroutineWatched(Co_StartAnim(type == LimitOverControl.AnimType.Release ? nowLevel : prevMaxLevel + 1));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7248C4 Offset: 0x7248C4 VA: 0x7248C4
		// // RVA: 0x1D67B44 Offset: 0x1D67B44 VA: 0x1D67B44
		private IEnumerator Co_StartAnim(int level)
		{
			//0x1D68944
			isSkiped = false;
			layoutRoot.StartAnimGoStop("go_in", "st_in");
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0x1D67E78
				return layoutRoot.IsPlayingSibling();
			});
			if(type == LimitOverControl.AnimType.Release)
			{
				yield return Co.R(Co_ReleaseAnim(level));
			}
			else if(type == LimitOverControl.AnimType.Add)
			{
				yield return Co.R(Co_AddAnim(level));
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x72493C Offset: 0x72493C VA: 0x72493C
		// // RVA: 0x1D67C0C Offset: 0x1D67C0C VA: 0x1D67C0C
		private IEnumerator Co_AddAnim(int level)
		{
			//0x1D67F88
			while(nowMaxLevel >= level)
			{
				if(nowMaxLevel == level)
					isSkiped = true;
				layoutRoot.StartChildrenAnimGoStop("go_in_add_" + level.ToString("D2"), "st_in_add_" + level.ToString("D2"));
				SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_SETTING_009);
				yield return null;
				yield return new WaitWhile(() =>
				{
					//0x1D67EA4
					return layoutRoot.IsPlayingChildren();
				});
				level++;
			}
			layoutEffect.StartAnimGoStop("go_in", "st_in");
			SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_SETTING_008);
			if(onEndAnim != null)
			{
				onEndAnim();
				onEndAnim = null;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7249B4 Offset: 0x7249B4 VA: 0x7249B4
		// // RVA: 0x1D67CD4 Offset: 0x1D67CD4 VA: 0x1D67CD4
		private IEnumerator Co_ReleaseAnim(int level)
		{
			//0x1D68544
			layoutSlot[level - 1].StartChildrenAnimGoStop("go_in_on", "st_in_on");
			layoutSlotEffect[level - 1].StartChildrenAnimGoStop("go_in_on", "st_in_on");
			SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_SETTING_008);
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0x1D67F04
				return layoutSlot[level - 1].IsPlayingChildren();
			});
			layoutEffect.StartAnimGoStop("go_in", "st_in");
			if(onEndAnim != null)
			{
				onEndAnim();
				onEndAnim = null;
			}
		}

		// RVA: 0x1D67D9C Offset: 0x1D67D9C VA: 0x1D67D9C
		public void CloseAnim(Action onEndAnim)
		{
			this.onEndAnim = onEndAnim;
			this.StartCoroutineWatched(Co_CloseAnim());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x724A2C Offset: 0x724A2C VA: 0x724A2C
		// // RVA: 0x1D67DC4 Offset: 0x1D67DC4 VA: 0x1D67DC4
		private IEnumerator Co_CloseAnim()
		{
			//0x1D68314
			layoutRoot.StartSiblingAnimGoStop("go_out", "st_out");
			yield return new WaitWhile(() =>
			{
				//0x1D67ED0
				return layoutRoot.IsPlayingSibling();
			});
			if(onEndAnim != null)
			{
				onEndAnim();
			}
		}

		// // RVA: 0x1D67AB0 Offset: 0x1D67AB0 VA: 0x1D67AB0
		private void SkipAnim()
		{
			if(type != LimitOverControl.AnimType.Add)
				return;
			this.StopAllCoroutinesWatched();
			this.StartCoroutineWatched(Co_AddAnim(nowMaxLevel));
		}
	}
}
