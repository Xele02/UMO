using XeSys.Gfx;
using System;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationRightButtons01 : LayoutUGUIScriptBase
	{
		[Serializable]
		public class EditLayout
		{
			public ActionButton m_button; // 0xC
			public ActionButton m_maxButton; // 0x10
			public AbsoluteLayout m_newIcon; // 0x14
			public AbsoluteLayout m_newIconMax; // 0x18
			public AbsoluteLayout m_maxTbl; // 0x1C

			public bool IsNew { get; private set; } // 0x8

			// // RVA: 0x18B1C90 Offset: 0x18B1C90 VA: 0x18B1C90
			public void SetNewIcon(bool isNew)
			{
				IsNew = isNew;
				if(isNew)
				{
					m_newIcon.StartChildrenAnimGoStop(0, 0);
					if(m_newIconMax != null)
						m_newIconMax.StartChildrenAnimGoStop(0, 0);
				}
				else
				{
					m_newIcon.StartChildrenAnimGoStop(1, 1);
					if(m_newIconMax != null)
						m_newIconMax.StartChildrenAnimGoStop(1, 1);
				}
			}
		}

		public static readonly string AssetName = "root_deco_right_btn_01_layout_root"; // 0x0
		[SerializeField]
		private ActionButton m_takeButton; // 0x14
		[SerializeField]
		private ActionButton m_mapChangeButton; // 0x18
		[SerializeField]
		private ActionButton m_mapNameEditButton; // 0x1C
		[SerializeField]
		private Text m_mapNameText; // 0x20
		[SerializeField]
		private EditLayout m_showEditButton; // 0x24
		[SerializeField]
		private List<EditLayout> m_edits = new List<EditLayout>(); // 0x28
		[SerializeField]
		private ActionButton m_decoButton; // 0x2C
		[SerializeField]
		private NumberBase m_decoNumber; // 0x30
		[SerializeField]
		private ActionButton m_optionButton; // 0x34
		[SerializeField]
		private ActionButton m_playerSearchButton; // 0x38
		private AbsoluteLayout m_editFrameAnim; // 0x3C
		private AbsoluteLayout m_mapNameAnim; // 0x40
		private AbsoluteLayout m_decoNumAnim; // 0x44
		private AbsoluteLayout m_editButtonsAnim; // 0x48
		public Action OnClickMapChangeButton; // 0x4C
		public Action OnClickMapNameEditButton; // 0x50
		public Action<bool> OnClickShowEditButton; // 0x54
		//[CompilerGeneratedAttribute] // RVA: 0x66BD88 Offset: 0x66BD88 VA: 0x66BD88
		public Action ClickTakeButtonListener; // 0x58
		public Action OnClickOptionButtonListner; // 0x5C
		public Action<DecorationDecorator.DecoratorType> OnClickEditButton; // 0x60
		public Action<DecorationDecorator.DecoratorType> OnClickEditMaxButton; // 0x64
		public Action OnClickDecoButton; // 0x68
		public Action OnClickDecoPlayerSearchButton; // 0x6C
		private bool m_isEnter; // 0x70
		private bool m_isMapEnter; // 0x71
		private bool m_isInEditButtons; // 0x72
		private AbsoluteLayout m_showEditButtonsAnim; // 0x74
		private AbsoluteLayout m_showEditNewIcon; // 0x78

		// RVA: 0x18B0DE4 Offset: 0x18B0DE4 VA: 0x18B0DE4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_mapNameAnim = layout.FindViewById("sw_deco_name_01_anim") as AbsoluteLayout;
			m_decoNumAnim = layout.FindViewById("sw_deco_edit_btn_inout_anim") as AbsoluteLayout;
			m_editFrameAnim = layout.FindViewById("sw_deco_edit_anim") as AbsoluteLayout;
			m_editButtonsAnim = layout.FindViewById("sw_deco_edit_btn_inout_anim_02") as AbsoluteLayout;
			m_isInEditButtons = false;
			m_showEditButtonsAnim = layout.FindViewById("swtbl_deco_edit_btn_anim") as AbsoluteLayout;
			m_takeButton.AddOnClickCallback(() => {
				//0x18B28AC
				if(ClickTakeButtonListener != null)
					ClickTakeButtonListener();
			});
			m_mapChangeButton.AddOnClickCallback(() =>
			{
				//0x18B28C0
				OnClickMapChangeButton();
			});
			m_mapNameEditButton.AddOnClickCallback(() =>
			{
				//0x18B28EC
				OnClickMapNameEditButton();
			});
			m_showEditButton.m_button.AddOnClickCallback(() =>
			{
				//0x18B2918
				OnClickShowEditButton(!m_isInEditButtons);
			});
			m_decoButton.AddOnClickCallback(() =>
			{
				//0x18B29A0
				OnClickDecoButton();
			});
			m_optionButton.AddOnClickCallback(() =>
			{
				//0x18B29CC
				if(OnClickOptionButtonListner != null)
					OnClickOptionButtonListner();
			});
			m_playerSearchButton.AddOnClickCallback(() =>
			{
				//0x18B29E0
				if(OnClickDecoPlayerSearchButton != null)
					OnClickDecoPlayerSearchButton();
			});
			for(int i = 0; i < m_edits.Count; i++)
			{
				int index = i;
				m_edits[i].m_newIcon = layout.FindViewByExId(string.Format("sw_deco_b_btn_01_{0:D2}_anim_swtbl_new_icon_01", i + 1)) as AbsoluteLayout;
				m_edits[i].m_newIconMax = layout.FindViewByExId(string.Format("sw_deco_b_btn_01_{0:D2}_02_anim_swtbl_new_icon_01", i + 1)) as AbsoluteLayout;
				m_edits[i].m_maxTbl = layout.FindViewById(string.Format("swtbl_deco_b_btn_01_{0:D2}", i + 1)) as AbsoluteLayout;
				m_edits[i].m_button.ClearOnClickCallback();
				m_edits[i].m_button.AddOnClickCallback(() =>
				{
					//0x18B29F4
					OnClickEditButton((DecorationDecorator.DecoratorType)index);
				});
				if(m_edits[i].m_maxButton != null)
				{
					m_edits[i].m_maxButton.ClearOnClickCallback();
					m_edits[i].m_maxButton.AddOnClickCallback(() =>
					{
						//0x18B2A88
						OnClickEditMaxButton((DecorationDecorator.DecoratorType)index);
					});
				}
			}
			m_showEditButton.m_newIcon = layout.FindViewByExId("sw_deco_edit_btn_anim_swtbl_new_icon_01") as AbsoluteLayout;
			m_showEditNewIcon = layout.FindViewByExId("sw_deco_edit_btn_swtbl_new_icon_01") as AbsoluteLayout;
			m_isInEditButtons = false;
			m_isEnter = false;
			m_isMapEnter = false;
			return true;
		}

		// // RVA: 0x18B1D20 Offset: 0x18B1D20 VA: 0x18B1D20
		public void SetNew(bool isNew)
		{
			m_showEditButton.SetNewIcon(isNew);
			m_showEditNewIcon.StartChildrenAnimGoStop(!m_showEditButton.IsNew ? 1 : 0, !m_showEditButton.IsNew ? 1 : 0);
		}

		// // RVA: 0x18B1DB0 Offset: 0x18B1DB0 VA: 0x18B1DB0
		public void SetEditNew(List<bool> isNew)
		{
			for(int i = 0; i < m_edits.Count; i++)
			{
				m_edits[i].SetNewIcon(isNew[i]);
			}
		}

		// RVA: 0x18B1ED0 Offset: 0x18B1ED0 VA: 0x18B1ED0
		public void InEditButtons()
		{
			if(m_isInEditButtons)
				return;
			m_isInEditButtons = true;
			m_editButtonsAnim.StartChildrenAnimGoStop("go_in", "st_in");
			m_showEditButtonsAnim.StartChildrenAnimGoStop(1, 1);
		}

		// RVA: 0x18B1F98 Offset: 0x18B1F98 VA: 0x18B1F98
		public void OutEditButtons()
		{
			if(!m_isInEditButtons)
				return;
			m_isInEditButtons = false;
			m_editButtonsAnim.StartChildrenAnimGoStop("go_out", "st_out");
			m_showEditButtonsAnim.StartChildrenAnimGoStop(0, 0);
		}

		// RVA: 0x18B2060 Offset: 0x18B2060 VA: 0x18B2060
		public void Setting(string mapName)
		{
			m_mapNameText.text = mapName;
		}

		// RVA: 0x18B20D8 Offset: 0x18B20D8 VA: 0x18B20D8
		public bool IsPlayingEnd()
		{
			return !m_editFrameAnim.IsPlayingChildren() && !m_decoNumAnim.IsPlayingChildren() && !m_mapNameAnim.IsPlayingChildren();
		}

		// RVA: 0x18B2168 Offset: 0x18B2168 VA: 0x18B2168
		public void Enter()
		{
			EnterEditButtons();
			EnterMap();
		}

		// RVA: 0x18B2304 Offset: 0x18B2304 VA: 0x18B2304
		public void Leave()
		{
			LeaveEditButtons();
			LeaveMap();
		}

		// // RVA: 0x18B2320 Offset: 0x18B2320 VA: 0x18B2320
		public void LeaveEditButtons()
		{
			if(!m_isEnter)
				return;
			m_isEnter = false;
			m_editFrameAnim.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// RVA: 0x18B2184 Offset: 0x18B2184 VA: 0x18B2184
		public void EnterEditButtons()
		{
			if(m_isEnter)
				return;
			m_isEnter = true;
			m_editFrameAnim.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x18B24A0 Offset: 0x18B24A0 VA: 0x18B24A0
		// public void Hide() { }

		// RVA: 0x18B23C0 Offset: 0x18B23C0 VA: 0x18B23C0
		public void LeaveMap()
		{
			if(!m_isMapEnter)
				return;
			m_isMapEnter = false;
			m_mapNameAnim.StartChildrenAnimGoStop("go_out", "st_out");
			m_decoNumAnim.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x18B2224 Offset: 0x18B2224 VA: 0x18B2224
		public void EnterMap()
		{
			if(m_isMapEnter)
				return;
			m_isMapEnter = true;
			m_mapNameAnim.StartChildrenAnimGoStop("go_in", "st_in");
			m_decoNumAnim.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x18B209C Offset: 0x18B209C VA: 0x18B209C
		public void ChangeMapName(string mapName)
		{
			m_mapNameText.text = mapName;
		}

		// // RVA: 0x18B2588 Offset: 0x18B2588 VA: 0x18B2588
		public void SetDecoNum(int num)
		{
			m_decoNumber.SetNumber(num, 0);
		}

		// // RVA: 0x18B25C8 Offset: 0x18B25C8 VA: 0x18B25C8
		public void UpdateItemPostMax(bool isMax)
		{
			m_edits[2].m_maxTbl.StartChildrenAnimGoStop(isMax ? 1 : 0, isMax ? 1 : 0);
			m_edits[3].m_maxTbl.StartChildrenAnimGoStop(isMax ? 1 : 0, isMax ? 1 : 0);
		}

		// // RVA: 0x18B26F0 Offset: 0x18B26F0 VA: 0x18B26F0
		public void UpdateCharaPostMax(bool isMax)
		{
			m_edits[1].m_maxTbl.StartChildrenAnimGoStop(isMax ? 1 : 0, isMax ? 1 : 0);
		}
	}
}
