using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System;

namespace XeApp.Game.Menu
{
	public class ExBattleScoreContents : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_jacket; // 0x14
		[SerializeField]
		private ActionButton m_searchBtn; // 0x18
		[SerializeField]
		private Text m_scoreText; // 0x1C
		[SerializeField]
		private string EXID; // 0x20
		private AbsoluteLayout m_newRecordIcon; // 0x24
		private Layout m_layout; // 0x28
		private int m_jacketId; // 0x2C
		private int m_score; // 0x30
		private EMGOCNMMPHC m_view; // 0x34

		// // RVA: 0xB9D5AC Offset: 0xB9D5AC VA: 0xB9D5AC
		private void IconAnimStart()
		{
			m_newRecordIcon.StartChildrenAnimLoop("lo_");
		}

		// // RVA: 0xB9D628 Offset: 0xB9D628 VA: 0xB9D628
		public void IconEnable(bool enable)
		{
			if(m_newRecordIcon != null)
			{
				m_newRecordIcon.StartAnimGoStop(enable ? "01" : "02");
				if(enable)
					IconAnimStart();
				m_newRecordIcon.enabled = enable;
			}
		}

		// // RVA: 0xB9D6E4 Offset: 0xB9D6E4 VA: 0xB9D6E4
		public void setSearchBtnAction(Action<EMGOCNMMPHC> btnCallBack)
		{
			m_searchBtn.ClearOnClickCallback();
			m_searchBtn.AddOnClickCallback(() =>
			{
				//0xB9DCAC
				SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
				btnCallBack.Invoke(m_view);
			});
		}

		// // RVA: 0xB9D804 Offset: 0xB9D804 VA: 0xB9D804
		public void SetUp(EMGOCNMMPHC _view)
		{
			m_view = _view;
			m_jacketId = _view.JNCPEGJGHOG_JackedId;
			m_score = _view.LDIODNEADGG_Hs;
		}

		// // RVA: 0xB9D860 Offset: 0xB9D860 VA: 0xB9D860
		public void SetStatus()
		{
			m_jacket.enabled = false;
			GameManager.Instance.MusicJacketTextureCache.Load(m_jacketId, (IiconTexture image) =>
			{
				//0xB9DBA8
				m_jacket.enabled = true;
				image.Set(m_jacket);
			});
			m_scoreText.text = m_score.ToString();
		}

		// RVA: 0xB9D9D0 Offset: 0xB9D9D0 VA: 0xB9D9D0
		public void ButtonDisable()
		{
			m_searchBtn.IsInputOff = true;
		}

		// RVA: 0xB9DA00 Offset: 0xB9DA00 VA: 0xB9DA00
		public void ButtonEnable()
		{
			m_searchBtn.IsInputOff = false;
		}

		// // RVA: 0xB9DA30 Offset: 0xB9DA30 VA: 0xB9DA30
		public void HideButton()
		{
			m_searchBtn.Hidden = true;
		}

		// RVA: 0xB9DA60 Offset: 0xB9DA60 VA: 0xB9DA60 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_newRecordIcon = (layout.FindViewById(EXID) as AbsoluteLayout).FindViewById("swtbl_g_r_e_newrec_icn") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
