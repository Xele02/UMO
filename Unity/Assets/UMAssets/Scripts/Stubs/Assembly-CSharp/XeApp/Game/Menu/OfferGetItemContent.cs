using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using XeSys;
using mcrs;

namespace XeApp.Game.Menu
{
	public class OfferGetItemContent : SwapScrollListContent
	{
		public enum DropItemLayoutType
		{
			CONFIRM = 0,
			RARE = 1,
			NOMAL = 2,
		}

		private const int DropItemTypeNum = 3;
		[SerializeField]
		private RawImageEx m_itemIcon; // 0x20
		[SerializeField]
		private Text m_itemNum; // 0x24
		[SerializeField]
		private RawImageEx[] imageRarityFrame = new RawImageEx[3]; // 0x28
		[SerializeField]
		private RawImageEx[] imageitem = new RawImageEx[3]; // 0x2C
		[SerializeField]
		private Text[] textCounts; // 0x30
		[SerializeField]
		private Text[] textBonus; // 0x34
		[SerializeField]
		private ActionButton m_ItemDetailsButton; // 0x38
		private AbsoluteLayout[] IconLayoutRoot = new AbsoluteLayout[3]; // 0x3C
		private AbsoluteLayout layoutNumAnim; // 0x40
		private AbsoluteLayout pfctIcon; // 0x44
		private float normalAnimEndRate = 0.75f; // 0x48
		private float rareAnimEndRate = 0.75f; // 0x4C
		public Action onFinished; // 0x50
		private AbsoluteLayout layoutRoot; // 0x54
		private AbsoluteLayout layoutStateTable; // 0x58
		private AbsoluteLayout layoutNumStateTable; // 0x5C
		private AbsoluteLayout shadowAnime; // 0x60
		private Rect[] uvRectRarityFrame = new Rect[ItemRarity.ArrayNum]; // 0x64
		private AbsoluteLayout layoutSceneStatusAnim; // 0x68
		private AbsoluteLayout layoutSceneStatusType; // 0x6C
		private Transform newMarkIconRoot; // 0x70
		private NewMarkIcon newMarkIcon; // 0x74
		private int m_itemTypeNum; // 0x78
		private AbsoluteLayout itemNumStateTabel; // 0x7C
		private AbsoluteLayout itemNumAnim; // 0x80
		private bool m_is_bonus; // 0x84
		private ViewOfferGetItem m_view; // 0x88

		public float Width { get { return layoutRoot.Width; } set { return; } } //0x152BAD4 0x152BB00

		// RVA: 0x152BB04 Offset: 0x152BB04 VA: 0x152BB04
		private void Start()
		{
			return;
		}

		// RVA: 0x152BB08 Offset: 0x152BB08 VA: 0x152BB08
		private void Update()
		{
			return;
		}

		//// RVA: 0x152BB0C Offset: 0x152BB0C VA: 0x152BB0C
		public void Setup(ViewOfferGetItem view)
		{
			m_view = view;
		}

		// RVA: 0x152BB14 Offset: 0x152BB14 VA: 0x152BB14
		public void SetStatus()
		{
			if (m_view.itemType < ViewOfferGetItem.ItemType.NUM)
				m_itemTypeNum = new int[4] { 0, 1, 1, 2 }[(int)m_view.itemType];
			imageRarityFrame[m_itemTypeNum].uvRect = uvRectRarityFrame[EKLNMHFCAOI.FABCKNDLPDH_GetItemRarity(m_view.itemId) - 1];
			MenuScene.Instance.ItemTextureCache.Load(m_view.itemId, (IiconTexture image) =>
			{
				//0x152DCA0
				imageitem[m_itemTypeNum].enabled = true;
				image.Set(imageitem[m_itemTypeNum]);
			});
			SetBounsText();
			m_ItemDetailsButton.ClearOnClickCallback();
			m_ItemDetailsButton.AddOnClickCallback(() =>
			{
				//0x152DE14
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				if (IsSceneCardItem())
					ShowSceneCardItem();
				else
					MenuScene.Instance.ShowItemDetail(m_view.itemId, m_view.itemNum, null);
			});
		}

		//// RVA: 0x152C050 Offset: 0x152C050 VA: 0x152C050
		private void ShowSceneCardItem()
		{
			GCIJNCFDNON_SceneInfo card = new GCIJNCFDNON_SceneInfo();
			card.KHEKNNFCAOI(m_view.itemId - 40000, null, null, 0, 0, 0, false, 0, 0);
			MenuScene.Instance.ShowSceneStatusPopupWindow(card, GameManager.Instance.ViewPlayerData, false, TransitionList.Type.UNDEFINED, null, false, true, 0, false);
		}

		//// RVA: 0x152C204 Offset: 0x152C204 VA: 0x152C204
		//private void SetText() { }

		//// RVA: 0x152BE04 Offset: 0x152BE04 VA: 0x152BE04
		private void SetBounsText()
		{
			itemNumStateTabel.StartChildrenAnimGoStop("01");
			for(int i = 0; i < textCounts.Length; i++)
			{
				textCounts[i].text = string.Format(JpStringLiterals.StringLiteral_14007, m_view.itemNum);
			}
			for(int i = 0; i < textBonus.Length; i++)
			{
				textBonus[i].text = string.Format(JpStringLiterals.StringLiteral_17754, m_view.bonusNum);
			}
		}

		// RVA: 0x152C3EC Offset: 0x152C3EC VA: 0x152C3EC
		public void StartBeginAnim()
		{
			switch(m_view.itemType)
			{
				case ViewOfferGetItem.ItemType.CONFIRM:
					layoutStateTable.StartChildrenAnimGoStop("03");
					layoutNumStateTable.StartChildrenAnimGoStop("01");
					IconLayoutRoot[0].StartChildrenAnimGoStop("go_hiraki", "st_hiraki");
					shadowAnime.StartChildrenAnimGoStop("go_hiraki", "st_hiraki");
					SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_017);
					pfctIcon.StartChildrenAnimGoStop("02");
					break;
				case ViewOfferGetItem.ItemType.GREATERARE:
					layoutStateTable.StartChildrenAnimGoStop("02");
					layoutNumStateTable.StartChildrenAnimGoStop("01");
					IconLayoutRoot[1].StartChildrenAnimGoStop("go_hiraki", "st_hiraki");
					shadowAnime.StartChildrenAnimGoStop("go_hiraki", "st_hiraki");
					SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_017);
					pfctIcon.StartChildrenAnimGoStop("01");
					break;
				case ViewOfferGetItem.ItemType.RARE:
					layoutStateTable.StartChildrenAnimGoStop("02");
					layoutNumStateTable.StartChildrenAnimGoStop("01");
					IconLayoutRoot[1].StartChildrenAnimGoStop("go_hiraki", "st_hiraki");
					pfctIcon.StartChildrenAnimGoStop("02");
					shadowAnime.StartChildrenAnimGoStop("go_hiraki", "st_hiraki");
					SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_017);
					pfctIcon.StartChildrenAnimGoStop("02");
					break;
				case ViewOfferGetItem.ItemType.NOMAL:
					layoutStateTable.StartChildrenAnimGoStop("01");
					layoutNumStateTable.StartChildrenAnimGoStop("01");
					IconLayoutRoot[2].StartChildrenAnimGoStop("go_in", "st_in");
					shadowAnime.StartChildrenAnimGoStop("go_in", "anim_end");
					SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_016);
					pfctIcon.StartChildrenAnimGoStop("02");
					break;
				default:
					SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_017);
					pfctIcon.StartChildrenAnimGoStop("02");
					break;
			}
		}

		// RVA: 0x152C980 Offset: 0x152C980 VA: 0x152C980
		public void ShowBeginAnim()
		{
			switch(m_view.itemType)
			{
				case ViewOfferGetItem.ItemType.CONFIRM:
					layoutStateTable.StartChildrenAnimGoStop("03");
					layoutNumStateTable.StartChildrenAnimGoStop("01");
					IconLayoutRoot[0].StartChildrenAnimGoStop("st_hiraki", "st_hiraki");
					pfctIcon.StartChildrenAnimGoStop("02");
					break;
				case ViewOfferGetItem.ItemType.GREATERARE:
					layoutStateTable.StartChildrenAnimGoStop("02");
					layoutNumStateTable.StartChildrenAnimGoStop("01");
					IconLayoutRoot[1].StartChildrenAnimGoStop("st_hiraki", "st_hiraki");
					pfctIcon.StartChildrenAnimGoStop("01");
					break;
				case ViewOfferGetItem.ItemType.RARE:
					layoutStateTable.StartChildrenAnimGoStop("02");
					layoutNumStateTable.StartChildrenAnimGoStop("01");
					IconLayoutRoot[1].StartChildrenAnimGoStop("st_hiraki", "st_hiraki");
					pfctIcon.StartChildrenAnimGoStop("02");
					break;
				case ViewOfferGetItem.ItemType.NOMAL:
					layoutStateTable.StartChildrenAnimGoStop("01");
					layoutNumStateTable.StartChildrenAnimGoStop("01");
					IconLayoutRoot[2].StartChildrenAnimGoStop("st_in");
					pfctIcon.StartChildrenAnimGoStop("02");
					break;
			}
			shadowAnime.StartChildrenAnimGoStop("anim_end");
		}

		//// RVA: 0x152CDBC Offset: 0x152CDBC VA: 0x152CDBC
		public void BounsNumAnumStart()
		{
			itemNumAnim.StartChildrenAnimGoStop("go_in", "loen");
		}

		//// RVA: 0x152CE48 Offset: 0x152CE48 VA: 0x152CE48
		public void BounsNumAnumShow()
		{
			itemNumAnim.StartChildrenAnimGoStop("loen", "loen");
		}

		// RVA: 0x152CEC8 Offset: 0x152CEC8 VA: 0x152CEC8
		public void Hide()
		{
			for(int i = 0; i < IconLayoutRoot.Length; i++)
			{
				IconLayoutRoot[i].StartChildrenAnimGoStop("st_wait");
			}
			shadowAnime.StartChildrenAnimGoStop("st_wait_01");
		}

		// RVA: 0x152CFD4 Offset: 0x152CFD4 VA: 0x152CFD4
		public bool IsPlayng()
		{
			return IconLayoutRoot[m_itemTypeNum].IsPlayingAll();
		}

		//// RVA: 0x152D038 Offset: 0x152D038 VA: 0x152D038
		public bool IsSceneCardItem()
		{
			return m_view != null && EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(m_view.itemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene;
		}

		// RVA: 0x152D0E4 Offset: 0x152D0E4 VA: 0x152D0E4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			layoutRoot = layout.FindViewById("sw_getitem_set") as AbsoluteLayout;
			layoutStateTable = layoutRoot.FindViewById("swtbl_item") as AbsoluteLayout;
			layoutNumStateTable = layoutRoot.FindViewById("swtbl_num_drop") as AbsoluteLayout;
			pfctIcon = layout.FindViewByExId("sw_inotes_anim_swtbl_icon_pfct") as AbsoluteLayout;
			IconLayoutRoot[2] = layoutStateTable.FindViewByExId("swtbl_item_sw_getitem_anim") as AbsoluteLayout;
			layoutNumAnim = layoutNumStateTable.FindViewById("sw_num_bonus_anim") as AbsoluteLayout;
			IconLayoutRoot[1] = layoutStateTable.FindViewByExId("swtbl_item_sw_inotes_anim") as AbsoluteLayout;
			layoutSceneStatusAnim = layoutRoot.FindViewById("sw_status_anim") as AbsoluteLayout;
			layoutSceneStatusType = layoutSceneStatusAnim.FindViewById("swtbl_status") as AbsoluteLayout;
			IconLayoutRoot[0] = layoutStateTable.FindViewByExId("swtbl_item_sw_inotes_anim_02") as AbsoluteLayout;
			itemNumStateTabel = layout.FindViewByExId("sw_getitem_set_swtbl_num_drop") as AbsoluteLayout;
			itemNumAnim = layout.FindViewByExId("swtbl_num_drop_sw_num_bonus_anim") as AbsoluteLayout;
			StringBuilder str = new StringBuilder(32);
			for(int i = 0; i < ItemRarity.ArrayNum; i++)
			{
				str.SetFormat("g_r_drop_itemfr_{0}", i + 1);
				TexUVData data = uvMan.GetUVData(str.ToString());
				if (data != null)
					uvRectRarityFrame[i] = LayoutUGUIUtility.MakeUnityUVRect(data);
			}
			newMarkIconRoot = transform.Find("sw_getitem_set (AbsoluteLayout)").Find("sw_status_anim (AbsoluteLayout)/swtbl_status (AbsoluteLayout)/icon_new01 (AbsoluteLayout)");
			shadowAnime = layout.FindViewByExId("sw_getitem_btn_anim_sw_drop_frm_base_anim") as AbsoluteLayout;
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
