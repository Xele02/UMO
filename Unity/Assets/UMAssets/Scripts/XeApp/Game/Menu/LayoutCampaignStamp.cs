using System.Collections;
using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutCampaignStamp : SwapScrollListContent
	{
		private AbsoluteLayout m_layout; // 0x20

		// [IteratorStateMachineAttribute] // RVA: 0x6CB2C4 Offset: 0x6CB2C4 VA: 0x6CB2C4
		// // RVA: 0x19D99AC Offset: 0x19D99AC VA: 0x19D99AC
		public IEnumerator StartStamp()
		{
			//0x19D9B68
			m_layout.StartChildrenAnimGoStop("go_in", "st_in");
			yield return new WaitWhile(() =>
			{
				//0x19D9B38
				return m_layout.IsPlayingChildren();
			});
		}

		// // RVA: 0x19D9A58 Offset: 0x19D9A58 VA: 0x19D9A58 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layout = layout.FindViewById("get_anim") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
