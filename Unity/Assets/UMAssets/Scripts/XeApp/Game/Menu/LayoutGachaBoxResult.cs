using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutGachaBoxResult : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_layoutRoot; // 0x14
		private AbsoluteLayout m_layoutTitle; // 0x18
		private AbsoluteLayout m_layoutTable; // 0x1C
		private List<AbsoluteLayout> m_layoutResult; // 0x20
		private ActionButton m_buttonOK; // 0x24
		private List<LayoutGachaBoxResultButton> m_buttonResult; // 0x28
		private List<HGFPAFPGIKG.JAKMCKNADCE> m_list; // 0x2C
		private Transform m_parent; // 0x30
		public Action OnClickButtonOK; // 0x34
		public Action<int> OnClickButtonResult; // 0x38
		public bool IsOpen; // 0x3C

		// RVA: 0x19A8DF4 Offset: 0x19A8DF4 VA: 0x19A8DF4
		public void Setup(List<HGFPAFPGIKG.JAKMCKNADCE> list)
		{
			m_list = list;
			m_parent = transform.parent;
			for(int i = 0; i < m_buttonResult.Count; i++)
			{
				if(i < list.Count)
				{
					m_buttonResult[i].Setup(list[i]);
				}
			}
			m_layoutTable.StartChildrenAnimGoStop((m_list == null ? 0 : m_list.Count).ToString("D2"));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6DE54C Offset: 0x6DE54C VA: 0x6DE54C
		// // RVA: 0x19A9334 Offset: 0x19A9334 VA: 0x19A9334
		public IEnumerator Enter(Action callback)
		{
			int i;

			//0x19AADD8
			IsOpen = true;
			transform.SetParent(GameManager.Instance.PopupCanvas.transform.GetChild(0));
			transform.SetAsFirstSibling();
			m_layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
			yield return new WaitWhile(() =>
			{
				//0x19AA780
				return m_layoutRoot.IsPlaying();
			});
			m_layoutTitle.StartChildrenAnimGoStop("go_in", "st_in");
			yield return new WaitWhile(() =>
			{
				//0x19AA7AC
				return m_layoutTitle.IsPlaying();
			});
			m_layoutTitle.StartChildrenAnimLoop("logo_up", "loen_up");
			for(i = 0; i < m_layoutResult.Count; i++)
			{
				m_layoutResult[i].StartChildrenAnimGoStop("go_in", "st_in");
				yield return new WaitWhile(() =>
				{
					//0x19AA91C
					return m_layoutResult[i].IsPlaying();
				});
			}
			if(callback != null)
				callback();
		}

		// // RVA: 0x19A93FC Offset: 0x19A93FC VA: 0x19A93FC
		public void Leave(Action callback)
		{
			IsOpen = false;
			this.StartCoroutineWatched(Co_Leave(callback));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6DE5C4 Offset: 0x6DE5C4 VA: 0x6DE5C4
		// // RVA: 0x19A942C Offset: 0x19A942C VA: 0x19A942C
		private IEnumerator Co_Leave(Action callback)
		{
			//0x19AAAC0
			m_layoutRoot.StartChildrenAnimGoStop("go_out", "st_out");
			yield return new WaitWhile(() =>
			{
				//0x19AA7D8
				return m_layoutRoot.IsPlayingChildren();
			});
			m_layoutTitle.StartChildrenAnimGoStop("st_wait");
			for(int i = 0; i < m_layoutResult.Count; i++)
			{
				m_layoutResult[i].StartChildrenAnimGoStop("st_wait");
			}
			transform.SetParent(m_parent);
			if(callback != null)
				callback();
		}

		// // RVA: 0x19A94F4 Offset: 0x19A94F4 VA: 0x19A94F4
		// public void Show() { }

		// // RVA: 0x19A9694 Offset: 0x19A9694 VA: 0x19A9694
		// public void Hide() { }

		// // RVA: 0x19A9748 Offset: 0x19A9748 VA: 0x19A9748
		// public bool IsPlaying() { }

		// // RVA: 0x19A9774 Offset: 0x19A9774 VA: 0x19A9774
		public void InputDisable()
		{
			m_buttonOK.IsInputOff = true;
			for(int i = 0; i < m_buttonResult.Count; i++)
			{
				m_buttonResult[i].IsInputOff = true;
			}
		}

		// // RVA: 0x19A9878 Offset: 0x19A9878 VA: 0x19A9878
		public void InputEnable()
		{
			m_buttonOK.IsInputOff = false;
			for(int i = 0; i < m_buttonResult.Count; i++)
			{
				m_buttonResult[i].IsInputOff = false;
			}
		}

		// RVA: 0x19A997C Offset: 0x19A997C VA: 0x19A997C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewById("sw_gacha_box_pop_inout_anim") as AbsoluteLayout;
			m_layoutRoot.StartChildrenAnimGoStop("st_wait");
			m_layoutTitle = layout.FindViewById("sw_gacha_box_fnt_result_anim") as AbsoluteLayout;
			m_layoutTable = layout.FindViewById("swtbl_gacha_box_item") as AbsoluteLayout;
			m_layoutResult = new List<AbsoluteLayout>();
			for(int i = 0; i < 10; i++)
			{
				AbsoluteLayout lt = layout.FindViewById(string.Format("sw_gacha_box_item_inout_anim_{0:00}", i + 1)) as AbsoluteLayout;
				lt.StartChildrenAnimGoStop("st_wait");
				m_layoutResult.Add(lt);
			}
			ActionButton[] btns = GetComponentsInChildren<ActionButton>(true);
			m_buttonOK = btns.Where((ActionButton _) =>
			{
				//0x19AA894
				return _.name == "sw_gacha_pr_close_btn_anim (AbsoluteLayout)";
			}).First();
			m_buttonOK.AddOnClickCallback(() =>
			{
				//0x19AA804
				if(OnClickButtonOK != null)
					OnClickButtonOK();
			});
			m_buttonResult = new List<LayoutGachaBoxResultButton>();
			for(int i = 0; i < 10; i++)
			{
				string label = string.Format("sw_gacha_box_item_inout_anim_{0:00} (AbsoluteLayout)", i + 1);
				LayoutGachaBoxResultButton btn = btns.Where((ActionButton _) =>
				{
					//0x19AA948
					return _.transform.name == label;
				}).First() as LayoutGachaBoxResultButton;
				int index = i;
				btn.AddOnClickCallback(() =>
				{
					//0x19AA9A4
					if(OnClickButtonResult != null)
						OnClickButtonResult(m_list[index].GLCLFMGPMAN_ItemId);
				});
				btn.InitializeFromLayout(layout.FindViewById("sw_gacha_box_item_inout_anim_" + (i + 1).ToString("D2")) as AbsoluteLayout, uvMan);
				m_buttonResult.Add(btn);
			}
			Loaded();
			return true;
		}
	}
}
