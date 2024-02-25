using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class LayoutPopupLimitOver : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text contentText; // 0x14
		private AbsoluteLayout layoutRoot; // 0x18
		private AbsoluteLayout layoutStringAnim; // 0x1C
		private AbsoluteLayout layoutLeafAnim; // 0x20
		private AbsoluteLayout[] layoutLeafSlot; // 0x24

		// RVA: 0x172F104 Offset: 0x172F104 VA: 0x172F104
		public void SetStatus(AEKDNMPPOJN limitOverData, string text)
		{
			contentText.text = text;
			layoutLeafAnim.StartChildrenAnimGoStop(limitOverData.LJHOOPJACPI_LeafMax.ToString("D2"), limitOverData.LJHOOPJACPI_LeafMax.ToString("D2"));
			for(int i = 0; i < layoutLeafSlot.Length; i++)
			{
				layoutLeafSlot[i].StartChildrenAnimGoStop(limitOverData.DJEHLEJCPEL_LeafNum > i ? "02" : "01", limitOverData.DJEHLEJCPEL_LeafNum > i ? "02" : "01");
			}
		}

		// RVA: 0x172F284 Offset: 0x172F284 VA: 0x172F284
		public bool IsLoading()
		{
			return KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning || !IsLoaded();
		}

		// RVA: 0x172F340 Offset: 0x172F340 VA: 0x172F340
		public void Show()
		{
			return;
		}

		// RVA: 0x172F344 Offset: 0x172F344 VA: 0x172F344
		public void Hide()
		{
			return;
		}

		// RVA: 0x172F348 Offset: 0x172F348 VA: 0x172F348
		public void StringAnimPlay()
		{
			layoutStringAnim.StartAllAnimGoStop("go_in", "st_in");
			this.StartCoroutineWatched(StringAnimWait());
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_WND_003);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x704DEC Offset: 0x704DEC VA: 0x704DEC
		// // RVA: 0x172F438 Offset: 0x172F438 VA: 0x172F438
		private IEnumerator StringAnimWait()
		{
			//0x172F8F0
			while(layoutStringAnim.IsPlayingChildren())
				yield return null;
			layoutStringAnim.StartAllAnimLoop("logo_up", "loen_up");
		}

		// RVA: 0x172F4E4 Offset: 0x172F4E4 VA: 0x172F4E4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			layoutRoot = layout.Root[0] as AbsoluteLayout;
			layoutStringAnim = layout.FindViewByExId("sw_pop_luckyleaf_ability_sw_g_r_event_title_anim") as AbsoluteLayout;
			layoutLeafAnim = layout.FindViewByExId("sw_pop_luckyleaf_ability_sw_add_leaf_anim") as AbsoluteLayout;
			layoutLeafSlot = new AbsoluteLayout[5];
			for(int i = 0; i < 5; i++)
			{
				layoutLeafSlot[i] = layout.FindViewById("pop_luckyleaf_off_" + (i + 1).ToString("D2")) as AbsoluteLayout;
			}
			layoutRoot.StartAllAnimGoStop("st_wait");
			contentText.text = "";
			Loaded();
			return true;
		}
	}
}
