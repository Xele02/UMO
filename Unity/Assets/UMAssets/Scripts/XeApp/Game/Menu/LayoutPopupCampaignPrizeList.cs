using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupCampaignPrizeList : LayoutUGUIScriptBase
	{
		public enum ScrollItemType
		{
			Header = 1,
			Item = 2,
		}

		private Text m_textDesc; // 0x14
		private ScrollRect m_ScrollRect; // 0x18
		private Transform m_ScrollContent; // 0x1C
		private FlexibleItemScrollView m_fxScrollView; // 0x20
		private LLBKNDPMGEP m_view; // 0x24

		// public ScrollRect GetScrollRect { get; } 0x1EBC874
		// public Transform GetScrollContent { get; } 0x1EBC87C
		public FlexibleItemScrollView FxScrollView { get { return m_fxScrollView; } } //0x1EBC884

		// RVA: 0x1EBC88C Offset: 0x1EBC88C VA: 0x1EBC88C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Text[] txts = GetComponentsInChildren<Text>(true);
			m_textDesc = txts.Where((Text _) => 
			{
				//0x1EBCDE4
				return _.name == "desc (TextView)";
			}).First();
			m_textDesc.text = MessageManager.Instance.GetMessage("menu", "event_reward_result_present_box2");
			m_ScrollRect = GetComponentInChildren<ScrollRect>(true);
			m_ScrollContent = m_ScrollRect.transform.Find("Content");
			ScrollRect sr = GetComponentInChildren<ScrollRect>(true);
			sr.horizontal = false;
			sr.vertical = true;
			sr.horizontalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHide;
			sr.verticalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHide;
			sr.gameObject.GetComponentInChildren<VerticalLayoutGroup>(true).enabled = false;
			sr.gameObject.GetComponentInChildren<ContentSizeFitter>(true).enabled = false;
			sr.gameObject.GetComponentInChildren<LayoutElement>(true).enabled = false;
			m_fxScrollView = new FlexibleItemScrollView();
			m_fxScrollView.Initialize(m_ScrollRect);
			Loaded();
			return true;
		}
	}
}
