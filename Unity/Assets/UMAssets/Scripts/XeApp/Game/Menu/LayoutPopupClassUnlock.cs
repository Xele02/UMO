using System.Collections;
using System.Linq;
using UnityEngine.UI;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupClassUnlock : LayoutUGUIScriptBase
	{
		private RawImageEx m_imageClass; // 0x14
		private Text m_textContent; // 0x18
		private Text m_textScore; // 0x1C
		private AbsoluteLayout m_layoutTitle; // 0x20
		private IHGLIHBAOII m_view; // 0x24

		// RVA: 0x1EBE3B0 Offset: 0x1EBE3B0 VA: 0x1EBE3B0
		public void Setup(IHGLIHBAOII view)
		{
			m_view = view;
			m_imageClass.enabled = false;
			GameManager.Instance.ItemTextureCache.LoadEmblem(view.MDPKLNFFDBO_EmblemId, (IiconTexture icon) =>
			{
				//0x1EBEBD8
				m_imageClass.enabled = true;
				icon.Set(m_imageClass);
			});
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_textScore.text = bk.GetMessageByLabel(JpStringLiterals.StringLiteral_17240) + JpStringLiterals.StringLiteral_367 + view.PMNGBEJMECI_Score.ToString();
		}

		// RVA: 0x1EBE614 Offset: 0x1EBE614 VA: 0x1EBE614
		public void StartAnim()
		{
			this.StartCoroutineWatched(Co_WaitAnim());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x706B74 Offset: 0x706B74 VA: 0x706B74
		// // RVA: 0x1EBE638 Offset: 0x1EBE638 VA: 0x1EBE638
		private IEnumerator Co_WaitAnim()
		{
			//0x1EBEEDC
			m_layoutTitle.StartChildrenAnimGoStop("go_in", "st_in");
			yield return null;
			while(m_layoutTitle.IsPlayingChildren())
				yield return null;
			m_layoutTitle.StartChildrenAnimLoop("logo_up", "loen_up");
		}

		// RVA: 0x1EBE6E4 Offset: 0x1EBE6E4 VA: 0x1EBE6E4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutTitle = layout.FindViewById("title_01_anim") as AbsoluteLayout;
			RawImageEx[] imgs = GetComponentsInChildren<RawImageEx>(true);
			m_imageClass = imgs.Where((RawImageEx _) =>
			{
				//0x1EBED58
				return _.name == "s_m_btl_class_l_01 (ImageView)";
			}).First();
			Text[] txts = GetComponentsInChildren<Text>(true);
			m_textContent = txts.Where((Text _) =>
			{
				//0x1EBEDD8
				return _.name == "txt (TextView)";
			}).First();
			m_textScore = txts.Where((Text _) =>
			{
				//0x1EBEE58
				return _.name == "score (TextView)";
			}).First();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_textContent.text = bk.GetMessageByLabel("music_event_battle_class_lvup");
			Loaded();
			return true;
		}
	}
}
