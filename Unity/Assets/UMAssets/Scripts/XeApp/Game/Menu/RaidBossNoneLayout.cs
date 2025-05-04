using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeSys;

namespace XeApp.Game.Menu
{
	public class RaidBossNoneLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_infoText1; // 0x14
		[SerializeField]
		private Text m_infoText2; // 0x18
		private AbsoluteLayout m_layoutMain; // 0x1C
		private bool m_isShow; // 0x20

		// RVA: 0x145D0D8 Offset: 0x145D0D8 VA: 0x145D0D8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutMain = layout.FindViewByExId("root_sel_music_raid_boss_none_cc_sw_sel_music_raid_boss_none_cc_anim") as AbsoluteLayout;
			m_isShow = false;
			Hide();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_infoText1.text = bk.GetMessageByLabel("raid_bossselect_none_text01");
			m_infoText2.text = string.Format(bk.GetMessageByLabel("raid_bossselect_none_text02"), NKOBMDPHNGP_EventRaidLobby.GPNELLFNPLA());
			Loaded();
			return true;
		}

		// // RVA: 0x145D394 Offset: 0x145D394 VA: 0x145D394
		// public void SetText1(string str) { }

		// // RVA: 0x145D3D0 Offset: 0x145D3D0 VA: 0x145D3D0
		// public void SetText2(string str) { }

		// // RVA: 0x145D40C Offset: 0x145D40C VA: 0x145D40C
		// public void Show() { }

		// RVA: 0x145D30C Offset: 0x145D30C VA: 0x145D30C
		public void Hide()
		{
			m_isShow = false;
			m_layoutMain.StartChildrenAnimGoStop("st_out", "st_out");
		}

		// RVA: 0x145D494 Offset: 0x145D494 VA: 0x145D494
		public void Enter()
		{
			if(!m_isShow)
			{
				m_layoutMain.StartChildrenAnimGoStop("go_in", "st_in");
			}
			m_isShow = true;
		}

		// // RVA: 0x145D534 Offset: 0x145D534 VA: 0x145D534
		public void Leave()
		{
			if(m_isShow)
			{
				m_layoutMain.StartChildrenAnimGoStop("go_out", "st_out");
			}
			m_isShow = false;
		}

		// // RVA: 0x145D5D4 Offset: 0x145D5D4 VA: 0x145D5D4
		public bool IsPlaying()
		{
			return m_layoutMain.IsPlayingChildren();
		}
	}
}
