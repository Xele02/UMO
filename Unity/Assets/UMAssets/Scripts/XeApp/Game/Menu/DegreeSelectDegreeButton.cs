using System;
using System.Collections.Generic;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class DegreeSelectDegreeButton : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_abs; // 0x14
		private ActionButton m_btn; // 0x18
		private Text m_name; // 0x1C
		private RawImageEx m_image; // 0x20
		private RawImageEx m_set_icon; // 0x24
		private NumberBase m_degree_num; // 0x28
		private List<RawImageEx> m_degree_num_images; // 0x2C
		private Action m_updater; // 0x30
		private const int NAME_LIMIT_ROWS = 2;
		private int m_Degree_no; // 0x34

		// RVA: 0x11E2E90 Offset: 0x11E2E90 VA: 0x11E2E90 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_abs = layout.FindViewById("sw_sel_deg_eff_anim") as AbsoluteLayout;
			m_btn = transform.Find("sw_sel_degree_frame (AbsoluteLayout)").GetComponent<ActionButton>();
			m_name = transform.Find("sw_sel_degree_frame (AbsoluteLayout)/name_txt_00 (TextView)").GetComponent<Text>();
			m_image = transform.Find("sw_sel_degree_frame (AbsoluteLayout)/cmn_degree_01 (AbsoluteLayout)/swtexc_cmn_item (ImageView)").GetComponent<RawImageEx>();
			m_set_icon = transform.Find("sw_sel_degree_frame (AbsoluteLayout)/sel_degree_icon_01 (ImageView)").GetComponent<RawImageEx>();
			m_degree_num = transform.Find("sw_sel_degree_frame (AbsoluteLayout)/swnum_sel_deg_s_num (AbsoluteLayout)").GetComponent<NumberBase>();
			m_degree_num_images = new List<RawImageEx>();
			m_updater = UpdateLoad;
			return true;
		}

		// RVA: 0x11E3220 Offset: 0x11E3220 VA: 0x11E3220
		private void Start()
		{
			return;
		}

		// RVA: 0x11E3224 Offset: 0x11E3224 VA: 0x11E3224
		private void Update()
		{
			if (m_updater != null)
				m_updater();
		}

		//// RVA: 0x11E3238 Offset: 0x11E3238 VA: 0x11E3238
		private void UpdateLoad()
		{
			if(m_degree_num.IsLoaded())
			{
				Loaded();
				m_updater = UpdateIdle;
			}
		}

		//// RVA: 0x11E32F4 Offset: 0x11E32F4 VA: 0x11E32F4
		private void UpdateIdle()
		{
			return;
		}

		//// RVA: 0x11E32F8 Offset: 0x11E32F8 VA: 0x11E32F8
		public void Init(IAPDFOPPGND data)
		{
			if (m_name.horizontalOverflow != UnityEngine.HorizontalWrapMode.Wrap)
				m_name.horizontalOverflow = UnityEngine.HorizontalWrapMode.Wrap;
			TextGeneratorUtility.SetTextRectangleMessage(m_name, data.ADCMNODJBGJ_EmblemName, 2, JpStringLiterals.StringLiteral_12038);
			SetDegreeImage(data.MDPKLNFFDBO_EmblemId);
			if(data.HMFFHLPNMPH > 0)
			{
				SetDegreeNumVisible(true);
				m_degree_num.SetNumber(data.HMFFHLPNMPH, 0);
			}
			else
			{
				SetDegreeNumVisible(false);
			}
		}

		//// RVA: 0x11E374C Offset: 0x11E374C VA: 0x11E374C
		public void ActiveSetIcon(bool enable)
		{
			m_set_icon.enabled = enable;
		}

		//// RVA: 0x11E3780 Offset: 0x11E3780 VA: 0x11E3780
		public void ActiveSelectAnim(bool enable)
		{
			if (enable)
				m_abs.StartChildrenAnimLoop("logo_on", "loen_on");
			else
				m_abs.StartChildrenAnimLoop("st_wait");
		}

		//// RVA: 0x11E3474 Offset: 0x11E3474 VA: 0x11E3474
		public void SetDegreeImage(int degree_no)
		{
			if(degree_no == 1)
			{
				m_image.enabled = false;
			}
			else
			{
				m_Degree_no = degree_no;
				m_image.enabled = false;
				GameManager.Instance.ItemTextureCache.LoadEmblem(degree_no, (IiconTexture icon) =>
				{
					//0x11E3850
					if (m_Degree_no != degree_no)
						return;
					m_image.enabled = true;
					icon.Set(m_image);
				});
			}
		}

		//// RVA: 0x11E3840 Offset: 0x11E3840 VA: 0x11E3840
		public ActionButton GetBtn()
		{
			return m_btn;
		}

		//// RVA: 0x11E3668 Offset: 0x11E3668 VA: 0x11E3668
		private void SetDegreeNumVisible(bool isVisible)
		{
			for(int i = 0; i < m_degree_num_images.Count; i++)
			{
				m_degree_num_images[i].enabled = isVisible;
			}
		}
	}
}
