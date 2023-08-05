using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;
using System.Collections;
using mcrs;

namespace XeApp.Game.Menu
{
	public class LayoutPopAddMusicMulti : LayoutUGUIScriptBase
	{
		[SerializeField]
		private SwapScrollList scrollList; // 0x14
		private AbsoluteLayout popupTitleAnimeLayout; // 0x18

		// RVA: 0x15DCE10 Offset: 0x15DCE10 VA: 0x15DCE10 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			popupTitleAnimeLayout = layout.FindViewByExId("sw_scroll_pop_music_ul_logo_anim") as AbsoluteLayout;
			ClearLoadedCallback();
			return true;
		}

		//// RVA: 0x15DCEE8 Offset: 0x15DCEE8 VA: 0x15DCEE8
		public void AddScrollContent(SwapScrollListContent content)
		{
			scrollList.AddScrollObject(content);
		}

		//// RVA: 0x15DCF1C Offset: 0x15DCF1C VA: 0x15DCF1C
		public void ApplyScrollContent()
		{
			scrollList.Apply();
		}

		//// RVA: 0x15DCF48 Offset: 0x15DCF48 VA: 0x15DCF48
		public void VisibleRegionUpdate()
		{
			scrollList.VisibleRegionUpdate();
		}

		//// RVA: 0x15DCF74 Offset: 0x15DCF74 VA: 0x15DCF74
		public void SetUpdateFunc(Action<int, SwapScrollListContent> updateFunc)
		{
			scrollList.OnUpdateItem.AddListener((int index, SwapScrollListContent content) =>
			{
				//0x15DD220
				updateFunc(index, content);
			});
		}

		//// RVA: 0x15DD094 Offset: 0x15DD094 VA: 0x15DD094
		public void SetItemCount(int count)
		{
			scrollList.SetItemCount(count);
		}

		//// RVA: 0x15DD0C8 Offset: 0x15DD0C8 VA: 0x15DD0C8
		public void Show()
		{
			popupTitleAnimeLayout.StartChildrenAnimGoStop("go_in", "st_in");
			this.StartCoroutineWatched(Co_ShowTitleLogo());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70FD54 Offset: 0x70FD54 VA: 0x70FD54
		//// RVA: 0x15DD16C Offset: 0x15DD16C VA: 0x15DD16C
		private IEnumerator Co_ShowTitleLogo()
		{
			//0x15DD2AC
			yield return null;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_004);
			while (popupTitleAnimeLayout.IsPlayingChildren())
				yield return null;
			popupTitleAnimeLayout.StartAllAnimLoop("logo_up", "loen_up");
		}
	}
}
