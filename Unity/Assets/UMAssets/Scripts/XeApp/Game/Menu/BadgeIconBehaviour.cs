using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class BadgeIconBehaviour : MonoBehaviour, ILayoutUGUIPaste
	{
		public enum Type
		{
			Image = 0,
			Text = 1,
			Exclamation = 2,
			Hide = 3,
		}

		[SerializeField]
		private Text m_text; // 0xC
		[SerializeField]
		private RawImageEx m_image; // 0x10
		private AbsoluteLayout m_root; // 0x14
		private List<Rect> m_uvRectList; // 0x18
		private static readonly string[] animeLabelTbl = new string[3] { "01", "02", "03" }; // 0x0
		private static readonly string[] uvNameTbl = new string[8] { "cmn_icon01_01", "cmn_icon01_05", "cmn_icon01_02",
			"cmn_icon01_03", "cmn_icon01_04", "cmn_icon01_06", "cmn_icon01_07", "cmn_icon01_08"
			}; // 0x4

		// RVA: 0x1435DB4 Offset: 0x1435DB4 VA: 0x1435DB4 Slot: 5
		public virtual bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.FindViewByExId("root_cmn_badge_swtbl_cmn_icon01") as AbsoluteLayout;
			m_uvRectList = new List<Rect>();
			for(int i = 0; i < uvNameTbl.Length; i++)
			{
				m_uvRectList.Add(LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData(uvNameTbl[i])));
			}
			return true;
		}

		//// RVA: 0x1435B88 Offset: 0x1435B88 VA: 0x1435B88
		//public void SetType(BadgeIconBehaviour.Type type) { }

		//// RVA: 0x1435CBC Offset: 0x1435CBC VA: 0x1435CBC
		//public void SetTextureUv(BadgeConstant.ID id) { }

		//// RVA: 0x1435D78 Offset: 0x1435D78 VA: 0x1435D78
		//public void SetText(string text) { }
	}
}
