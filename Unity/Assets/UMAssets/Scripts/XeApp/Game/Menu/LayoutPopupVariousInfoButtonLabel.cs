using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutPopupVariousInfoButtonLabel : LayoutUGUIScriptBase
	{
		public enum eLabelType
		{
			None = 0,
			Wiki = 1,
			Twitter = 2,
			Byelaw = 3,
			Policy = 4,
			Transaction = 5,
			Settlement = 6,
			CopyRight = 7,
			Credit = 8,
			OfficialSite = 9,
			PortalSite = 10,
			FAQ = 11,
			Num = 12,
		}

		[SerializeField]
		private RawImageEx m_imageFont; // 0x14
		[SerializeField]
		private eLabelType m_labelType; // 0x18
		private TexUVList m_texUvList; // 0x1C

		public eLabelType ButtonLabel { get { return m_labelType; } } //0x1870468

		//// RVA: 0x1870470 Offset: 0x1870470 VA: 0x1870470
		//public void SetStatus() { }

		// RVA: 0x1870474 Offset: 0x1870474 VA: 0x1870474
		public void Reset()
		{
			return;
		}

		//// RVA: 0x1870478 Offset: 0x1870478 VA: 0x1870478
		//public void Show() { }

		//// RVA: 0x187047C Offset: 0x187047C VA: 0x187047C
		//public void Hide() { }

		// RVA: 0x1870480 Offset: 0x1870480 VA: 0x1870480
		public void SetLabel(eLabelType type)
		{
			if(m_imageFont != null && type > eLabelType.None && type < eLabelType.Num)
			{
				m_imageFont.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_texUvList.GetUVData(string.Format("sel_opt_btn_fnt_pop_{0:d2}", (int)type)));
				m_labelType = type;
			}
		}

		// RVA: 0x1870600 Offset: 0x1870600 VA: 0x1870600 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_texUvList = uvMan.GetTexUVList("sel_option_pack");
			Loaded();
			return true;
		}
	}
}
