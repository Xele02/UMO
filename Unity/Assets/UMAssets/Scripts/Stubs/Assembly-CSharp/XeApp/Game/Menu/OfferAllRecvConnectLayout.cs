using CriWare;
using mcrs;
using System.Collections;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class OfferAllRecvConnectLayout : LayoutUGUIScriptBase
	{
		private AbsoluteLayout rootLayout; // 0x14
		private bool isEnd; // 0x18
		private CriAtomExPlayback m_connectSEPlayback; // 0x1C

		// RVA: 0x151D320 Offset: 0x151D320 VA: 0x151D320
		private void OnDisable()
		{
			m_connectSEPlayback.Stop();
		}

		// RVA: 0x151D32C Offset: 0x151D32C VA: 0x151D32C
		public void BeginAnim()
		{
			this.StartCoroutineWatched(Co_BeginAnim());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F811C Offset: 0x6F811C VA: 0x6F811C
		// RVA: 0x151D3DC Offset: 0x151D3DC VA: 0x151D3DC
		public IEnumerator EndAnim()
		{
			//0x151D828
			isEnd = true;
			rootLayout.StartChildrenAnimGoStop("go_out", "st_out");
			m_connectSEPlayback.Stop();
			while (rootLayout.IsPlayingChildren())
				yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F8194 Offset: 0x6F8194 VA: 0x6F8194
		//// RVA: 0x151D350 Offset: 0x151D350 VA: 0x151D350
		private IEnumerator Co_BeginAnim()
		{
			//0x151D5B4
			m_connectSEPlayback = SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_LOBBY_001);
			rootLayout.StartChildrenAnimGoStop("go_in", "st_in");
			while (rootLayout.IsPlayingChildren())
				yield return null;
			if(!isEnd)
			{
				rootLayout.StartAllAnimLoop("logo_act", "loen_act");
			}
		}

		// RVA: 0x151D4A8 Offset: 0x151D4A8 VA: 0x151D4A8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			rootLayout = layout.Root[0] as AbsoluteLayout;
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
