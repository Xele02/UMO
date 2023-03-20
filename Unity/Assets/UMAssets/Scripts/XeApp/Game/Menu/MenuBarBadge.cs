using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class MenuBarBadge : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_text; // 0x14
		[SerializeField]
		private LayoutUGUIRuntime m_runtime; // 0x18

		public LayoutUGUIRuntime runtime { get { return m_runtime; } } //0xEC3518

		// // RVA: 0xEC3520 Offset: 0xEC3520 VA: 0xEC3520
		public void Set(BadgeConstant.ID id, string text)
		{
			switch(id)
			{
				case BadgeConstant.ID.None:
					gameObject.SetActive(false);
					return;
				case BadgeConstant.ID.Label:
					gameObject.SetActive(true);
					m_text.text = text;
					return;
				/*	case BadgeConstant.ID.New:

				Gacha_Update = 3,
				Gacha_FreeMorning = 4,
				Gacha_FreeNoon = 5,
				Gacha_FreeNight = 6,
				Menu_ShopCheck = 7,
				Menu_NewFuncAdd = 8,
				Menu_ResvMsg = 9,*/
				default:
					TodoLogger.Log(0, "MenuBarBadge.Set");
					break;
			}
		}

		// // RVA: 0xEC379C Offset: 0xEC379C VA: 0xEC379C
		public void Initialize(GameObject parent, AbsoluteLayout parentLayout)
		{
			transform.SetParent(parent.transform, false);
			transform.SetAsLastSibling();
			if(parentLayout == null)
				return;
			parentLayout.AddView(m_runtime.Layout.Root);
		}

		// // RVA: 0xEC3890 Offset: 0xEC3890 VA: 0xEC3890 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			Loaded();
			return true;
		}
	}
}
