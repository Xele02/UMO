using XeSys.Gfx;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutEventGoDivaAttrFrame : LayoutUGUIScriptBase
	{
		public enum AlignType
		{
			tl = 0,
			tc = 1,
			tr = 2,
			cl = 3,
			cr = 4,
			bl = 5,
			bc = 6,
			br = 7,
			_Num = 8,
		}

		private static readonly string[] s_frameAttrUvFormat = new string[5]
		{
			"sel_me3_frm_jkt_05_{0:D2}", "sel_me3_frm_jkt_01_{0:D2}", "sel_me3_frm_jkt_02_{0:D2}", 
			"sel_me3_frm_jkt_03_{0:D2}", "sel_me3_frm_jkt_04_{0:D2}"
		}; // 0x0
		[SerializeField]
		private List<RawImageEx> m_frameImages; // 0x14
		[SerializeField]
		private TextureListSupport m_texListSupport; // 0x18

		// RVA: 0x18C9BDC Offset: 0x18C9BDC VA: 0x18C9BDC
		public void SetAttribute(GameAttribute.Type attr)
		{
			SetUv(s_frameAttrUvFormat[(int)attr]);
		}

		// // RVA: 0x18C9CAC Offset: 0x18C9CAC VA: 0x18C9CAC
		protected void SetUv(string uvFormat)
		{
			for(int i = 0; i < m_frameImages.Count; i++)
			{
				m_texListSupport.SetImage(m_frameImages[i], string.Format(uvFormat, i + 1));
			}
		}

		// RVA: 0x18C9DE0 Offset: 0x18C9DE0 VA: 0x18C9DE0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			Loaded();
			return true;
		}
	}
}
