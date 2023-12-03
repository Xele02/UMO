using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;

namespace XeApp.Game.Menu
{
	public class OfferOrderNumLayout : LayoutUGUIScriptBase
	{
		public enum SortOrder
		{
			Small = 0,
			Big = 1,
		}

		[SerializeField]
		private NumberBase orderNum; // 0x14
		[SerializeField]
		private NumberBase orderMaxNum; // 0x18
		[SerializeField]
		private ActionButton m_allGetButton; // 0x1C
		[SerializeField]
		private ActionButton m_updownButton; // 0x20
		[SerializeField]
		private RawImageEx m_updownText; // 0x24
		private SortOrder m_sortOrder = SortOrder.Big; // 0x28
		private TexUVList m_texUvList; // 0x2C
		private AbsoluteLayout m_layoutRoot; // 0x30
		private AbsoluteLayout m_orderLayout; // 0x34
		private static readonly string[] m_orderTextureUvNameTable = new string[2]
			{
				"cmn_btn_orde_fnt_01", "cmn_btn_orde_fnt_02"
			}; // 0x0

		//public static SortOrder DefaultSortOrder { get; } 0x1854208

		// RVA: 0x1854210 Offset: 0x1854210 VA: 0x1854210
		private void Start()
		{
			return;
		}

		// RVA: 0x1854214 Offset: 0x1854214 VA: 0x1854214
		private void Update()
		{
			return;
		}

		// RVA: 0x1854218 Offset: 0x1854218 VA: 0x1854218
		public void NuberSetting(int _orderNumMax, int _orderNum)
		{
			orderNum.SetNumber(_orderNum, 0);
			orderMaxNum.SetNumber(_orderNumMax, 0);
		}

		// RVA: 0x1854290 Offset: 0x1854290 VA: 0x1854290
		public void AllGetButtonAction(Action act)
		{
			m_allGetButton.ClearOnClickCallback();
			m_allGetButton.AddOnClickCallback(() =>
			{
				//0x1854D6C
				act();
			});
		}

		// RVA: 0x1854398 Offset: 0x1854398 VA: 0x1854398
		public void AllGetButtonActDisable()
		{
			m_allGetButton.enabled = false;
		}

		// RVA: 0x18543C8 Offset: 0x18543C8 VA: 0x18543C8
		public void AllGetButtonActEnable()
		{
			m_allGetButton.enabled = true;
		}

		// RVA: 0x18543F8 Offset: 0x18543F8 VA: 0x18543F8
		public void UpDownButtonAction(Action act)
		{
			m_updownButton.ClearOnClickCallback();
			m_updownButton.AddOnClickCallback(() =>
			{
				//0x1854D98
				act();
			});
		}

		// RVA: 0x1854500 Offset: 0x1854500 VA: 0x1854500
		private void UpdateOrderFont()
		{
			m_updownText.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_texUvList.GetUVData(m_orderTextureUvNameTable[(int)m_sortOrder]));
		}

		//// RVA: 0x1854664 Offset: 0x1854664 VA: 0x1854664
		public void ChengeButtonLabel(bool labelFlg)
		{
			m_sortOrder = labelFlg ? SortOrder.Big : SortOrder.Small;
			UpdateOrderFont();
		}

		// RVA: 0x185466C Offset: 0x185466C VA: 0x185466C
		public void Enter()
		{
			m_layoutRoot.StartAllAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x18546F8 Offset: 0x18546F8 VA: 0x18546F8
		public void Leave()
		{
			m_layoutRoot.StartAllAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0x1854784 Offset: 0x1854784 VA: 0x1854784
		//public void Hide() { }

		//// RVA: 0x1854800 Offset: 0x1854800 VA: 0x1854800
		//public void Show() { }

		// RVA: 0x185487C Offset: 0x185487C VA: 0x185487C
		public bool IsPlaying()
		{
			return m_layoutRoot.IsPlayingAll();
		}

		// RVA: 0x18548A8 Offset: 0x18548A8 VA: 0x18548A8
		public void UpDown_ButtonHide(bool IsBeginner)
		{
			m_updownButton.Hidden = IsBeginner;
		}

		// RVA: 0x18548DC Offset: 0x18548DC VA: 0x18548DC
		public void AllGet_ButtonHide(bool IsBeginner)
		{
			m_allGetButton.Hidden = IsBeginner;
		}

		// RVA: 0x1854910 Offset: 0x1854910 VA: 0x1854910
		public void AllGet_ButtonDisable(bool disable)
		{
			m_allGetButton.Disable = disable;
		}

		//// RVA: 0x1854944 Offset: 0x1854944 VA: 0x1854944
		public void OrderNumHide()
		{
			m_orderLayout.enabled = false;
		}

		//// RVA: 0x185497C Offset: 0x185497C VA: 0x185497C
		public void OrderNumShow()
		{
			m_orderLayout.enabled = true;
		}

		// RVA: 0x18549B4 Offset: 0x18549B4 VA: 0x18549B4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewByExId("root_sel_vfo_order_layout_root") as AbsoluteLayout;
			m_orderLayout = layout.FindViewByExId("sw_s_v_order_anim_cmn_win_05_01") as AbsoluteLayout;
			m_texUvList = uvMan.GetTexUVList("cmn_tex_pack");
			m_sortOrder = KDHGBOOECKC.HHCJCDFCLOB.LBKNBKPBAPJ_IsSortDesc() ? SortOrder.Big : SortOrder.Small;
			UpdateOrderFont();
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
