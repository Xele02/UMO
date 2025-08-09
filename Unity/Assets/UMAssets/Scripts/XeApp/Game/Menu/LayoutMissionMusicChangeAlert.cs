using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutMissionMusicChangeAlert : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_desc; // 0x14
		[SerializeField]
		private Text m_caution; // 0x18
		private AbsoluteLayout m_layout; // 0x1C

		// RVA: 0x1D69A30 Offset: 0x1D69A30 VA: 0x1D69A30 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layout = layout.FindViewByExId("root_sel_music_eve2_pop_02_sw_sel_music_pop_02") as AbsoluteLayout;
			ClearLoadedCallback();
			return true;
		}

		// RVA: 0x1D69B08 Offset: 0x1D69B08 VA: 0x1D69B08
		public void UpdateContent(int descType, bool isUpdateLimitedMusic, bool isUpdateBonusMusicSchedule, bool isExclusionBonusMusic)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_desc.text = MakeDescriptionMessage(descType, isUpdateLimitedMusic, isUpdateBonusMusicSchedule);
			m_caution.text = MakeCautionMessage(isUpdateLimitedMusic, isExclusionBonusMusic);
			if(string.IsNullOrEmpty(m_caution.text))
			{
				m_layout.StartChildrenAnimGoStop("03");
			}
			else if(isUpdateLimitedMusic)
			{
				m_layout.StartChildrenAnimGoStop("01");
			}
			else if(isExclusionBonusMusic)
			{
				m_layout.StartChildrenAnimGoStop("02");
			}
		}

		// // RVA: 0x1D69CF4 Offset: 0x1D69CF4 VA: 0x1D69CF4
		private string MakeDescriptionMessage(int descType, bool isUpdateLimitedMusic, bool isUpdateBonusMusicSchedule)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			string res = "";
			if(isUpdateBonusMusicSchedule)
			{
				res = bk.GetMessageByLabel("event_mission_changemusic_desc_003");
			}
			string s1 = "";
			string s2 = "";
			if(isUpdateLimitedMusic)
			{
				s2 = bk.GetMessageByLabel(string.Format("event_mission_changemusic_desc_{0:D3}", descType));
				s1 = "\n";
				if(string.IsNullOrEmpty(res))
				{
					s1 = "";
					res = s2;
					s2 = "";
				}
			}
			return string.Format(bk.GetMessageByLabel("event_mission_changemusic_format"), res, s1, s2);
		}

		// // RVA: 0x1D69ED4 Offset: 0x1D69ED4 VA: 0x1D69ED4
		private string MakeCautionMessage(bool isUpdateLimitedMusic, bool isExclusionBonusMusic)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(isUpdateLimitedMusic)
			{
				return bk.GetMessageByLabel("event_mission_changemusic_caution");
			}
			else if(isExclusionBonusMusic)
			{
				return bk.GetMessageByLabel("event_mission_changemusic_caution2");
			}
			else
			{
				return "";
			}
		}
	}
}
