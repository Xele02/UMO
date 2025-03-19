using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutBattleClassListItem : LayoutShopListElemBase
	{
		[SerializeField]
		private Text m_textLock; // 0x20
		[SerializeField]
		private NumberBase m_numScore; // 0x24
		[SerializeField]
		private RawImageEx m_imageClass; // 0x28
		[SerializeField]
		private ActionButton m_button; // 0x2C
		private AbsoluteLayout m_layoutRoot; // 0x30
		private int m_emblemId; // 0x34
		private IHGLIHBAOII m_view; // 0x38

		public IHGLIHBAOII View { get { return m_view; } } //0x14C011C
		protected override ButtonBase selectButton { get { return m_button; } } //0x14C0124

		// // RVA: 0x14C012C Offset: 0x14C012C VA: 0x14C012C
		// public bool IsLoaded() { }

		// RVA: 0x14C0134 Offset: 0x14C0134 VA: 0x14C0134
		public void Setup(IHGLIHBAOII view)
		{
			m_view = view;
			m_emblemId = view.MDPKLNFFDBO_EmblemId;
			m_imageClass.enabled = false;
			GameManager.Instance.ItemTextureCache.Load(ItemTextureCache.MakeEmblemIconTexturePath(m_emblemId), (IiconTexture icon) =>
			{
				//0x14C06AC
				if(m_emblemId != m_view.MDPKLNFFDBO_EmblemId)
					return;
				m_imageClass.enabled = true;
				icon.Set(m_imageClass);
			});
			if(m_view.MNAKKLEJBFG_IsUnlocked)
			{
				m_layoutRoot.StartChildrenAnimGoStop("01");
				m_numScore.SetNumber(m_view.PMNGBEJMECI_Score, 0);
				m_button.IsInputOff = false;
			}
			else
			{
				m_layoutRoot.StartChildrenAnimGoStop("02");
				m_textLock.text = string.Format(MessageManager.Instance.GetMessage("menu", "music_event_battle_class_next_01"), m_view.JFLOBDBGIKL.GIDPPGJPOJA_Id) + Environment.NewLine + string.Format(MessageManager.Instance.GetMessage("menu", "music_event_battle_class_next_02"), m_view.JFLOBDBGIKL.PMNGBEJMECI_Score);
				m_button.IsInputOff = true;
			}
		}

		// RVA: 0x14C05CC Offset: 0x14C05CC VA: 0x14C05CC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewById("swtbl_s_m_btl_class_list_01") as AbsoluteLayout;
			Loaded();
			return true;
		}
    }
}
