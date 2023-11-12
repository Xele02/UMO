using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using System.Collections;
using mcrs;

namespace XeApp.Game.Menu
{
	public class LayoutGetBingoReward : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx ItemIcon; // 0x14
		[SerializeField]
		private RawImageEx SceneIcon; // 0x18
		[SerializeField]
		private Text ItemName; // 0x1C
		[SerializeField]
		private ActionButton ItemIconButton; // 0x20
		[SerializeField]
		private ActionButton SceneIconButton; // 0x24
		private AbsoluteLayout BingoCountAnim; // 0x28
		private AbsoluteLayout BingoCountEfAnim; // 0x2C
		private AbsoluteLayout TitleLayout; // 0x30
		private AbsoluteLayout GetItemChange; // 0x34
		private bool m_IconLoaded; // 0x38

		// RVA: 0x1D4F9DC Offset: 0x1D4F9DC VA: 0x1D4F9DC
		private void Start()
		{
			return;
		}

		// RVA: 0x1D4F9E0 Offset: 0x1D4F9E0 VA: 0x1D4F9E0
		private void Update()
		{ 
			return;
		}

		// RVA: 0x1D4F9E4 Offset: 0x1D4F9E4 VA: 0x1D4F9E4
		public void SetUp(int itemId, int bingoCount, int getItemCount)
		{
            EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemId);
            int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(itemId);
			string itemName = EKLNMHFCAOI.INCKKODFJAP_GetItemName(cat, id);
			string itemStr = EKLNMHFCAOI.NDBLEADIDLA(cat, 0);
			ItemName.text = itemName + " " + getItemCount.ToString() + itemStr;
			SettingLayout(bingoCount, itemId);
		}

		// RVA: 0x1D4FB28 Offset: 0x1D4FB28 VA: 0x1D4FB28
		public void SettingLayout(int _bingoCount, int _itemId)
		{
			m_IconLoaded = false;
			BingoCountAnim.StartChildrenAnimGoStop(_bingoCount.ToString("D2"));
			BingoCountEfAnim.StartChildrenAnimGoStop(_bingoCount.ToString("D2"));
			if(IsScene(_itemId))
			{
				GetItemChange.StartChildrenAnimGoStop("01");
				GCIJNCFDNON_SceneInfo scene = new GCIJNCFDNON_SceneInfo();
				scene.KHEKNNFCAOI(_itemId - 40000, null, null, 0, 0, 0, false, 0, 0);
				GameManager.Instance.SceneIconCache.Load(_itemId - 40000, scene.JOKJBMJBLBB_Single ? 2 : 1, (IiconTexture icon) =>
				{
					//0x1D50700
					icon.Set(SceneIcon);
					m_IconLoaded = true;
				});
			}
			else
			{
				GetItemChange.StartChildrenAnimGoStop("02");
				GameManager.Instance.ItemTextureCache.Load(_itemId, 0, (IiconTexture icon) =>
				{
					//0x1D50810
					icon.Set(ItemIcon);
					m_IconLoaded = true;
				});
			}
			ItemIconButton.AddOnClickCallback(() =>
			{
				//0x1D50920
				SetIconButton(_itemId);
			});
			SceneIconButton.AddOnClickCallback(() =>
			{
				//0x1D50950
				SetIconButton(_itemId);
			});
		}

		// RVA: 0x1D4FFDC Offset: 0x1D4FFDC VA: 0x1D4FFDC
		private bool IsScene(int _itemId)
		{
			return EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(_itemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene;
		}

		// RVA: 0x1D50070 Offset: 0x1D50070 VA: 0x1D50070
		public void ShowTitle()
		{
			TitleLayout.StartChildrenAnimGoStop("go_in", "st_in");
			this.StartCoroutineWatched(TitleLoopAnim());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7002AC Offset: 0x7002AC VA: 0x7002AC
		// RVA: 0x1D50114 Offset: 0x1D50114 VA: 0x1D50114
		private IEnumerator TitleLoopAnim()
		{
			//0x1D50984
			yield return null;
			while(TitleLayout.IsPlayingChildren())
				yield return null;
			TitleLayout.StartChildrenAnimLoop("logo_up");
		}

		// RVA: 0x1D501C0 Offset: 0x1D501C0 VA: 0x1D501C0
		public bool IsIconLoaded()
		{
			return m_IconLoaded;
		}

		// RVA: 0x1D501C8 Offset: 0x1D501C8 VA: 0x1D501C8
		public void SetIconButton(int itemId)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			{
				ShowSceneCardItem(itemId);
			}
			else
			{
				MenuScene.Instance.ShowItemDetail(itemId, 0, null);
			}
		}

		// RVA: 0x1D5031C Offset: 0x1D5031C VA: 0x1D5031C
		private void ShowSceneCardItem(int _itemId)
		{
			GCIJNCFDNON_SceneInfo scene = new GCIJNCFDNON_SceneInfo();
			scene.KHEKNNFCAOI(_itemId - 40000, null, null, 0, 0, 0, false, 0, 0);
			MenuScene.Instance.ShowSceneStatusPopupWindow(scene, GameManager.Instance.ViewPlayerData, false, TransitionList.Type.UNDEFINED, null, false, true, SceneStatusParam.PageSave.None, false);
		}

		// RVA: 0x1D504B8 Offset: 0x1D504B8 VA: 0x1D504B8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			BingoCountAnim = layout.FindViewByExId("sw_pop_bingo_title_anim_swtbl_pop_bingo_num") as AbsoluteLayout;
			BingoCountEfAnim = layout.FindViewByExId("sw_pop_bingo_title_anim_swtbl_pop_bingo_num_ef") as AbsoluteLayout;
			TitleLayout = layout.FindViewByExId("sw_pop_bingo_rwd_get_sw_pop_vfo_title_02_anim") as AbsoluteLayout;
			GetItemChange = layout.FindViewByExId("sw_pop_bingo_rwd_get_swtbl_reward") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
