using System.Collections;
using mcrs;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutOfferUnlockPlatoon : LayoutUGUIScriptBase
	{
		private const int RELEASE_LEVEL_MAX = 5;
		private AbsoluteLayout m_Title; // 0x14
		private AbsoluteLayout[] m_PlatoonNum = new AbsoluteLayout[5]; // 0x18
		private AbsoluteLayout m_ReleaseNum; // 0x1C

		// RVA: 0x15D6528 Offset: 0x15D6528 VA: 0x15D6528
		private void Start()
		{
			return;
		}

		// RVA: 0x15D652C Offset: 0x15D652C VA: 0x15D652C
		private void Update()
		{
			return;
		}

		// RVA: 0x15D6530 Offset: 0x15D6530 VA: 0x15D6530
		public void Setup(int platoonNum, int releaseNum)
		{
			if(releaseNum < 2)
			{
				m_ReleaseNum.StartChildrenAnimGoStop("01");
				m_PlatoonNum[0].StartChildrenAnimGoStop(platoonNum.ToString("D2"));
			}
			else
			{
				m_ReleaseNum.StartChildrenAnimGoStop(releaseNum.ToString("D2"));
				for(int i = 0; i < releaseNum; i++)
				{
					m_PlatoonNum[i].StartChildrenAnimGoStop((i + (platoonNum - releaseNum) + 1).ToString("D2"));
				}
			}
		}

		// RVA: 0x15D6720 Offset: 0x15D6720 VA: 0x15D6720
		public void TitleEnter()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_004);
			m_Title.StartChildrenAnimGoStop("go_in", "st_in");
			this.StartCoroutineWatched(TitleLoopAnimStart());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70A284 Offset: 0x70A284 VA: 0x70A284
		// // RVA: 0x15D6810 Offset: 0x15D6810 VA: 0x15D6810
		public IEnumerator TitleLoopAnimStart()
		{
			//0x15D6C24
			yield return null;
			while(m_Title.IsPlaying())
				yield return null;
			m_Title.StartChildrenAnimLoop("logo_up");
		}

		// RVA: 0x15D68BC Offset: 0x15D68BC VA: 0x15D68BC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_Title = layout.FindViewByExId("sw_pop_vfo_02_sw_pop_vfo_title_02_anim") as AbsoluteLayout;
			m_ReleaseNum = layout.FindViewByExId("sw_pop_vfo_02_swtbl_vfo_num_02") as AbsoluteLayout;
			for(int i = 0; i < 5; i++)
			{
				m_PlatoonNum[i] = layout.FindViewByExId(string.Format("swtbl_vfo_num_02_swtbl_vfo_num_{0:D2}", i + 1)) as AbsoluteLayout;
			}
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
