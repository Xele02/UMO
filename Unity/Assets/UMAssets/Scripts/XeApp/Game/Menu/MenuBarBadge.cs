using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;

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
				case BadgeConstant.ID.New:
					gameObject.SetActive(true);
					m_text.text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("home_footer_badge_text_02");
					return;
				case BadgeConstant.ID.Gacha_Update:
					gameObject.SetActive(true);
					m_text.text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("home_footer_badge_text_03");
					return;
				case BadgeConstant.ID.Gacha_FreeMorning:
					gameObject.SetActive(true);
					m_text.text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("home_footer_badge_text_04");
					return;
				case BadgeConstant.ID.Gacha_FreeNoon:
					gameObject.SetActive(true);
					m_text.text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("home_footer_badge_text_05");
					return;
				case BadgeConstant.ID.Gacha_FreeNight:
					gameObject.SetActive(true);
					m_text.text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("home_footer_badge_text_06");
					return;
				case BadgeConstant.ID.Menu_ShopCheck:
					gameObject.SetActive(true);
					m_text.text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("home_footer_badge_text_07");
					return;
				case BadgeConstant.ID.Menu_NewFuncAdd:
					gameObject.SetActive(true);
					m_text.text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("home_footer_badge_text_08");
					return;
				case BadgeConstant.ID.Menu_ResvMsg:
					gameObject.SetActive(true);
					m_text.text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("home_footer_badge_text_09");
					return;
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
