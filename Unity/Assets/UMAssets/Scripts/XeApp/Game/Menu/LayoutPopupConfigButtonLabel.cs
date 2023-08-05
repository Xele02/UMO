using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigButtonLabel : LayoutUGUIScriptBase
	{
		public enum eLabelType
		{
			None = 0,
			High = 1,
			Low = 2,
			Enable = 3,
			Disable = 4,
			Color1 = 5,
			Color3 = 6,
			Max = 7,
		}

		[SerializeField]
		private RawImageEx m_imageFont; // 0x14
		[SerializeField]
		private eLabelType m_labelType; // 0x18
		private string[] m_fontName = new string[7]
			{
				"", "cmn_con_high_btn_fnt", "cmn_con_low_btn_fnt", "cmn_con_enable_btn_fnt",
				"cmn_con_disable_btn_fnt", "cmn_con_color_btn_fnt_01", "cmn_con_color_btn_fnt_02"
			}; // 0x1C
		private TexUVList m_texUvList; // 0x20

		//// RVA: 0x1EC09CC Offset: 0x1EC09CC VA: 0x1EC09CC
		public void SetLabel(eLabelType type)
		{
			if(m_imageFont != null && type > eLabelType.None && type < eLabelType.Max)
			{
				m_imageFont.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_texUvList.GetUVData(m_fontName[(int)type]));
			}
		}

		// RVA: 0x1EC0B44 Offset: 0x1EC0B44 VA: 0x1EC0B44 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_texUvList = uvMan.GetTexUVList("cmn_config_packtex");
			SetLabel(m_labelType);
			Loaded();
			return true;
		}
	}
}
