using System;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class DegreeSetWindow : LayoutUGUIScriptBase
	{
		private RawImageEx m_image; // 0x14
		private Text m_name; // 0x18
		private Text m_info; // 0x1C
		private NumberBase m_number; // 0x20
		private Action mUpdater; // 0x24

		// RVA: 0x17CED94 Offset: 0x17CED94 VA: 0x17CED94 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_image = transform.Find("sw_sel_deg_pop (AbsoluteLayout)/cmn_degree_03 (AbsoluteLayout)/swtexc_cmn_item (ImageView)").GetComponent<RawImageEx>();
			m_name = transform.Find("sw_sel_deg_pop (AbsoluteLayout)/name_txt_00 (TextView)").GetComponent<Text>();
			m_info = transform.Find("sw_sel_deg_pop (AbsoluteLayout)/telop_txt_00 (TextView)").GetComponent<Text>();
			m_number = transform.Find("sw_sel_deg_pop (AbsoluteLayout)/swnum_sel_deg_num (AbsoluteLayout)").GetComponent<NumberBase>();
			mUpdater = UpdateLoad;
			return true;
		}

		// RVA: 0x17CEFD0 Offset: 0x17CEFD0 VA: 0x17CEFD0
		private void Start()
		{
			return;
		}

		// RVA: 0x17CEFD4 Offset: 0x17CEFD4 VA: 0x17CEFD4
		private void Update()
		{
			if (mUpdater != null)
				mUpdater();
		}

		//// RVA: 0x17CEFE8 Offset: 0x17CEFE8 VA: 0x17CEFE8
		private void UpdateLoad()
		{
			if (!m_number.IsLoaded())
				return;
			mUpdater = UpdateIdle;
		}

		//// RVA: 0x17CF098 Offset: 0x17CF098 VA: 0x17CF098
		private void UpdateIdle()
		{
			return;
		}

		//// RVA: 0x17CF09C Offset: 0x17CF09C VA: 0x17CF09C
		public void Init(IAPDFOPPGND data)
		{
			m_name.text = data.ADCMNODJBGJ_EmblemName;
			m_name.verticalOverflow = UnityEngine.VerticalWrapMode.Overflow;
			m_name.horizontalOverflow = UnityEngine.HorizontalWrapMode.Wrap;
			m_info.text = data.FEMMDNIELFC_EmblemDesc;
			m_number.SetNumber(data.HMFFHLPNMPH + 1, 0);
			SetDegreeImage(data.MDPKLNFFDBO_EmblemId);
		}

		//// RVA: 0x17CF2B8 Offset: 0x17CF2B8 VA: 0x17CF2B8
		//public void Enter() { }

		//// RVA: 0x17CF1A8 Offset: 0x17CF1A8 VA: 0x17CF1A8
		public void SetDegreeImage(int degree_no)
		{
			GameManager.Instance.ItemTextureCache.LoadEmblem(degree_no, (IiconTexture icon) =>
			{
				//0x17CF2C4
				icon.Set(m_image);
			});
		}
	}
}
