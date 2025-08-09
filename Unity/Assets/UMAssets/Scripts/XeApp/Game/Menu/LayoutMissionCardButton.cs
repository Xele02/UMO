using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Text;
using UnityEngine.Events;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutMissionCardButton : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_desc; // 0x14
		[SerializeField]
		private Text m_pointText; // 0x18
		[SerializeField]
		private RawImageEx m_levelImage; // 0x1C
		[SerializeField]
		private ActionButton m_button; // 0x20
		private AbsoluteLayout m_layout; // 0x24
		private AbsoluteLayout m_dangerLay; // 0x28
		private TexUVListManager m_uvMan; // 0x2C
		private StringBuilder m_strBuilder = new StringBuilder(128); // 0x30
		private int m_index; // 0x34
		//[CompilerGeneratedAttribute] // RVA: 0x672E74 Offset: 0x672E74 VA: 0x672E74
		public UnityAction<int> PushButtonListener; // 0x38

		// RVA: 0x1D68DF4 Offset: 0x1D68DF4 VA: 0x1D68DF4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_uvMan = uvMan;
			string str;
			if(m_button != null)
			{
				m_button.AddOnClickCallback(OnPushButton);
				str = transform.parent.parent.name.Replace(" (AbsoluteLayout)", "") + "_" + transform.parent.name.Replace(" (AbsoluteLayout)", "");
				m_layout = (layout.FindViewByExId(str) as AbsoluteLayout).FindViewByExId("sw_sel_music_eve_card_btn_anim_swtbl_sel_music_eve_card") as AbsoluteLayout;
			}
			else
			{
				str = transform.parent.name.Replace(" (AbsoluteLayout)", "") + "_" + transform.name.Replace(" (AbsoluteLayout)", "");
				m_layout = layout.FindViewByExId(str) as AbsoluteLayout;
			}
			m_dangerLay = m_layout.FindViewByExId("swtbl_sel_music_eve_card_swtbl_card_dng") as AbsoluteLayout;
			ClearLoadedCallback();
			return true;
		}

		// // RVA: 0x1D692F0 Offset: 0x1D692F0 VA: 0x1D692F0
		public void UpdateContent(IAFDICLEOPF.HBCHKPLFHHF info, int missionIndex, int layoutIndex, IBJAKJJICBC musicData, bool is6Line, Difficulty.Type diffculty)
		{
			m_desc.text = GameMessageManager.ReplaceMessageTag(info.FEMMDNIELFC_Desc, (string tag) =>
			{
				//0x1D69944
				return GameMessageManager.MissionMessageTagFunc(m_strBuilder, tag, musicData == null ? 0 : musicData.GHBPLHBNMBK_FreeMusicId, is6Line, diffculty);
			});
			m_pointText.text = string.Format(MessageManager.Instance.GetMessage("menu", "event_mission_message_000"), info.DJJGNDCMNHF);
			m_levelImage.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData(string.Format("s_m_e_card_lv_{0:D2}", info.CIEOBFIIPLD)));
			m_index = missionIndex;
			m_layout.StartChildrenAnimGoStop(info.JKPDKNPDEBC ? "04" : info.CIEOBFIIPLD.ToString("00"));
			m_dangerLay.StartChildrenAnimGoStop(layoutIndex == 0 ? "01" : "02");
		}

		// // RVA: 0x1D696D4 Offset: 0x1D696D4 VA: 0x1D696D4
		public void ShowDanger(int layoutIndex)
		{
			m_dangerLay.StartChildrenAnimGoStop(layoutIndex == 0 ? "01" : "02");
		}

		// // RVA: 0x1D69768 Offset: 0x1D69768 VA: 0x1D69768
		public void ButtonReset()
		{
			if(m_button != null)
				m_button.SetOff();
		}

		// // RVA: 0x1D69824 Offset: 0x1D69824 VA: 0x1D69824
		private void OnPushButton()
		{
			if(PushButtonListener != null)
				PushButtonListener(m_index);
			m_dangerLay.StartChildrenAnimGoStop("02");
		}
	}
}
