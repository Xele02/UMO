using mcrs;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutResultDropItem : LayoutUGUIScriptBase
	{
		private struct NormalItem
		{
			public AbsoluteLayout layoutRoot; // 0x0
			public AbsoluteLayout layoutNumAnim; // 0x4
			public RawImageEx imageRarityFrame; // 0x8
			public RawImageEx imageItem1; // 0xC
		}

		private struct RareItem
		{
			public AbsoluteLayout layoutRoot; // 0x0
			public RawImageEx imageRarityFrame; // 0x4
			public RawImageEx imageItem; // 0x8
		}

		private struct EventRareItem
		{
			public AbsoluteLayout layoutRoot; // 0x0
			public RawImageEx imageRarityFrame; // 0x4
			public RawImageEx imageItem; // 0x8
		}

		private float normalAnimEndRate = 0.75f; // 0x14
		private float rareAnimEndRate = 0.75f; // 0x18
		public MOLKENLNCPE_DropData.CEFIOPJKEIC itemInfo; // 0x1C
		public Action onFinished; // 0x20
		private AbsoluteLayout layoutRoot; // 0x24
		private AbsoluteLayout layoutStateTable; // 0x28
		private AbsoluteLayout layoutNumStateTable; // 0x2C
		private AbsoluteLayout shadowAnime; // 0x30
		private NormalItem normalItem; // 0x34
		private RareItem rareItem; // 0x44
		private EventRareItem eventRareItem; // 0x50
		private Text[] textCounts; // 0x5C
		private Text[] textBonus; // 0x60
		private Rect[] uvRectRarityFrame = new Rect[ItemRarity.ArrayNum]; // 0x64
		private AbsoluteLayout layoutSceneStatusAnim; // 0x68
		private AbsoluteLayout layoutSceneStatusType; // 0x6C
		private Transform newMarkIconRoot; // 0x70
		private NewMarkIcon newMarkIcon; // 0x74
		private bool m_is_bonus; // 0x78
		private bool isOpenRecordPlateInfo; // 0x79
		private bool isCountUpBonus; // 0x7A

		public float Width { get { return layoutRoot.Width; } private set { return; } } //0x1D8F988 0x1D8F9B4
		public bool IsOpenRecordPlateInfo { get { return isOpenRecordPlateInfo; } } //0x1D8F9B8
		//public bool IsCountUpBonus { get; } 0x1D8F9C0

		// RVA: 0x1D8F9C8 Offset: 0x1D8F9C8 VA: 0x1D8F9C8
		private void OnDestroy()
		{
			if(newMarkIcon != null)
			{
				newMarkIcon.Release();
			}
		}

		// RVA: 0x1D8F9DC Offset: 0x1D8F9DC VA: 0x1D8F9DC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Transform t1 = transform.Find("sw_getitem_set (AbsoluteLayout)");
			Transform t2 = t1.Find("sw_getitem_btn_anim (AbsoluteLayout)/swtbl_item (AbsoluteLayout)");
			layoutRoot = layout.FindViewById("sw_getitem_set") as AbsoluteLayout;
			layoutStateTable = layoutRoot.FindViewById("swtbl_item") as AbsoluteLayout;
			layoutNumStateTable = layoutRoot.FindViewById("swtbl_num_drop") as AbsoluteLayout;

			normalItem.layoutRoot = layoutStateTable.FindViewById("sw_getitem_anim") as AbsoluteLayout;
			normalItem.layoutNumAnim = layoutNumStateTable.FindViewById("sw_num_bonus_anim") as AbsoluteLayout;
			Transform t3 = t2.Find("sw_getitem_anim (AbsoluteLayout)");;
			normalItem.imageRarityFrame = t3.Find("sw_itemframe (AbsoluteLayout)/swtexf_g_r_drop_itemfr (ImageView)").GetComponent<RawImageEx>();
			normalItem.imageItem1 = t3.Find("sw_cmn_item_1 (AbsoluteLayout)/swtexc_cmn_item (ImageView)").GetComponent<RawImageEx>();

			rareItem.layoutRoot = layoutStateTable.FindViewById("sw_inotes_anim") as AbsoluteLayout;
			t3 = t2.Find("sw_inotes_anim (AbsoluteLayout)"); ;
			rareItem.imageRarityFrame = t3.Find("sw_itemframe (AbsoluteLayout)/swtexf_g_r_drop_itemfr (ImageView)").GetComponent<RawImageEx>();
			rareItem.imageItem = t3.Find("sw_cmn_item (AbsoluteLayout)/swtexc_cmn_item (ImageView)").GetComponent<RawImageEx>();

			layoutSceneStatusAnim = layoutRoot.FindViewById("sw_status_anim") as AbsoluteLayout;
			layoutSceneStatusType = layoutSceneStatusAnim.FindViewById("swtbl_status") as AbsoluteLayout;

			eventRareItem.layoutRoot = layoutStateTable.FindViewById("sw_inotes_anim_02") as AbsoluteLayout;
			t3 = t2.Find("sw_inotes_anim_02 (AbsoluteLayout)"); ;
			eventRareItem.imageRarityFrame = t3.Find("sw_itemframe (AbsoluteLayout)/swtexf_g_r_drop_itemfr (ImageView)").GetComponent<RawImageEx>();
			eventRareItem.imageItem = t3.Find("sw_cmn_item (AbsoluteLayout)/swtexc_cmn_item (ImageView)").GetComponent<RawImageEx>();

			StayButton stb = GetComponentInChildren<StayButton>(true);
			stb.AddOnStayCallback(OnStay);
			stb.AddOnClickCallback(OnStay);

			Text[] txts = t1.GetComponentsInChildren<Text>(true);
			textCounts = txts.Where((Text _) =>
			{
				//0x1D92928
				return _.name == "num (TextView)";
			}).ToArray();
			for(int i = 0; i < textCounts.Length; i++)
			{
				textCounts[i].horizontalOverflow = HorizontalWrapMode.Overflow;
			}
			textBonus = txts.Where((Text _) =>
			{
				//0x1D929A8
				return _.name == "add (TextView)";
			}).ToArray();
			for(int i = 0; i < textBonus.Length; i++)
			{
				textBonus[i].horizontalOverflow = HorizontalWrapMode.Overflow;
			}
			StringBuilder str = new StringBuilder(32);
			for(int i = 0; i < 5; i++)
			{
				str.SetFormat("g_r_drop_itemfr_{0}", i + 1);
				uvRectRarityFrame[i] = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData(str.ToString()));
			}
			newMarkIconRoot = t1.Find("sw_status_anim (AbsoluteLayout)/swtbl_status (AbsoluteLayout)/icon_new01 (AbsoluteLayout)");
			shadowAnime = layout.FindViewByExId("sw_getitem_btn_anim_sw_drop_frm_base_anim") as AbsoluteLayout;
			Loaded();
			return true;
		}

		//// RVA: 0x1D90884 Offset: 0x1D90884 VA: 0x1D90884
		public void Setup(MOLKENLNCPE_DropData.CEFIOPJKEIC itemInfo, bool is_bonus)
		{
			this.itemInfo = itemInfo;
			if(!itemInfo.BAKFIPIFDLE_IsEventRareItem)
			{
				if(!itemInfo.PHJHJGDLPED_IsRareItem)
				{
					normalItem.imageRarityFrame.uvRect = uvRectRarityFrame[itemInfo.LIDBKCIMCKE_Rarity - 1];
					MenuScene.Instance.ItemTextureCache.Load(itemInfo.KIJAPOFAGPN_ItemId, OnLoadedNormalItemTexture);
				}
				else
				{
					rareItem.imageRarityFrame.uvRect = uvRectRarityFrame[itemInfo.LIDBKCIMCKE_Rarity - 1];
					MenuScene.Instance.ItemTextureCache.Load(itemInfo.KIJAPOFAGPN_ItemId, OnLoadedRareItemTexture);
				}
			}
			else
			{
				eventRareItem.imageRarityFrame.uvRect = uvRectRarityFrame[itemInfo.LIDBKCIMCKE_Rarity - 1];
				MenuScene.Instance.ItemTextureCache.Load(itemInfo.KIJAPOFAGPN_ItemId, OnLoadedEventRareItemTexture);
			}
			if(itemInfo != null && itemInfo.HHACNFODNEF_Category == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene && itemInfo.LHEDLDEMPPG_IsNew)
			{
				newMarkIcon = new NewMarkIcon();
				newMarkIcon.Initialize(newMarkIconRoot.gameObject);
			}
			for(int i = 0; i < textCounts.Length; i++)
			{
				textCounts[i].enabled = false;
			}
			for(int i = 0; i < textBonus.Length; i++)
			{
				textBonus[i].enabled = false;
			}
		}

		//// RVA: 0x1D90E2C Offset: 0x1D90E2C VA: 0x1D90E2C
		public bool IsPlaying()
		{
			if (itemInfo == null)
				return false;
			if(!itemInfo.BAKFIPIFDLE_IsEventRareItem)
			{
				if(!itemInfo.PHJHJGDLPED_IsRareItem)
				{
					if (normalItem.layoutRoot.IsPlayingChildren())
						return true;
					if (normalItem.layoutNumAnim.IsPlayingChildren())
						return true;
				}
				else
				{
					if (rareItem.layoutRoot.IsPlayingChildren())
						return true;
				}
			}
			else
			{
				if (eventRareItem.layoutRoot.IsPlayingChildren())
					return true;
			}
			return false;
		}

		//// RVA: 0x1D90EEC Offset: 0x1D90EEC VA: 0x1D90EEC
		//public bool IsExistBonus() { }

		//// RVA: 0x1D90F28 Offset: 0x1D90F28 VA: 0x1D90F28
		private void OnLoadedNormalItemTexture(IiconTexture iconTexture)
		{
			iconTexture.Set(normalItem.imageItem1);
		}

		//// RVA: 0x1D91008 Offset: 0x1D91008 VA: 0x1D91008
		private void OnLoadedRareItemTexture(IiconTexture iconTexture)
		{
			iconTexture.Set(rareItem.imageItem);
		}

		//// RVA: 0x1D910E8 Offset: 0x1D910E8 VA: 0x1D910E8
		private void OnLoadedEventRareItemTexture(IiconTexture iconTexture)
		{
			iconTexture.Set(eventRareItem.imageItem);
		}

		//// RVA: 0x1D911C8 Offset: 0x1D911C8 VA: 0x1D911C8
		public void StartBeginAnim()
		{
			if(!itemInfo.BAKFIPIFDLE_IsEventRareItem)
			{
				if(!itemInfo.PHJHJGDLPED_IsRareItem)
				{
					layoutStateTable.StartChildrenAnimGoStop("01", "01");
					layoutNumStateTable.StartChildrenAnimGoStop(m_is_bonus ? "01" : "02", m_is_bonus ? "01" : "02");
					normalItem.layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
					shadowAnime.StartChildrenAnimGoStop("go_in", "st_in");
					this.StartCoroutineWatched(Co_PlayingAnim(normalItem.layoutRoot, normalAnimEndRate));
					PlayNormalItemSE();
				}
				else
				{
					layoutStateTable.StartChildrenAnimGoStop("02", "02");
					layoutNumStateTable.StartChildrenAnimGoStop("02", "02");
					rareItem.layoutRoot.StartChildrenAnimGoStop("go_hiraki", "st_hiraki");
					shadowAnime.StartChildrenAnimGoStop("go_hiraki", "st_hiraki");
					this.StartCoroutineWatched(Co_PlayingAnim(rareItem.layoutRoot, rareAnimEndRate));
					PlayRareItemSE();
				}
			}
			else
			{
				layoutStateTable.StartChildrenAnimGoStop("03", "03");
				layoutNumStateTable.StartChildrenAnimGoStop("02", "02");
				eventRareItem.layoutRoot.StartChildrenAnimGoStop("go_hiraki", "st_hiraki");
				shadowAnime.StartChildrenAnimGoStop("go_hiraki", "st_hiraki");
				this.StartCoroutineWatched(Co_PlayingAnim(eventRareItem.layoutRoot, rareAnimEndRate));
				PlayRareItemSE();
			}
			if (itemInfo == null)
				return;
			if (itemInfo.HHACNFODNEF_Category != EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
				return;
			layoutSceneStatusAnim.StartChildrenAnimGoStop("go_in", "st_in");
			SetupItemStatusType();
		}

		//// RVA: 0x1D9182C Offset: 0x1D9182C VA: 0x1D9182C
		public void StartMoveNum()
		{
			if (itemInfo.PHJHJGDLPED_IsRareItem)
				return;
			normalItem.layoutNumAnim.StartChildrenAnimGoStop("go_in", "st_in");
		}

		//// RVA: 0x1D918D8 Offset: 0x1D918D8 VA: 0x1D918D8
		public void StartShowBonus()
		{
			if (itemInfo.PHJHJGDLPED_IsRareItem)
				return;
			normalItem.layoutNumAnim.StartChildrenAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0x1D91984 Offset: 0x1D91984 VA: 0x1D91984
		public void StartAnimBonus()
		{
			if(!itemInfo.PHJHJGDLPED_IsRareItem && !itemInfo.BAKFIPIFDLE_IsEventRareItem)
			{
				if (itemInfo.DJJGNDCMNHF_BonusCount < 1)
					return;
				normalItem.layoutNumAnim.StartChildrenAnimGoStop("go_act_01", "st_act_01");
			}
		}

		//// RVA: 0x1D91A60 Offset: 0x1D91A60 VA: 0x1D91A60
		public void StartAnimBonusAdd()
		{
			if(!itemInfo.PHJHJGDLPED_IsRareItem && !itemInfo.BAKFIPIFDLE_IsEventRareItem)
			{
				if (itemInfo.DJJGNDCMNHF_BonusCount < 1)
					return;
				normalItem.layoutNumAnim.StartChildrenAnimGoStop("go_countup", "st_countup");
			}
		}

		//// RVA: 0x1D91B3C Offset: 0x1D91B3C VA: 0x1D91B3C
		public void StartLoopAnimBonus()
		{
			if(!itemInfo.PHJHJGDLPED_IsRareItem && !itemInfo.BAKFIPIFDLE_IsEventRareItem)
			{
				if (itemInfo.DJJGNDCMNHF_BonusCount < 1)
					return;
				normalItem.layoutNumAnim.StartChildrenAnimLoop("logo", "loen");
			}
		}

		//// RVA: 0x1D91C18 Offset: 0x1D91C18 VA: 0x1D91C18
		//public void StartCountUpBonus(float sec) { }

		//[IteratorStateMachineAttribute] // RVA: 0x7191AC Offset: 0x7191AC VA: 0x7191AC
		//// RVA: 0x1D91C68 Offset: 0x1D91C68 VA: 0x1D91C68
		//private IEnumerator Co_CountUpBonus(float sec) { }

		//// RVA: 0x1D91D3C Offset: 0x1D91D3C VA: 0x1D91D3C
		public void SkipBeginAnim()
		{
			this.StopAllCoroutinesWatched();
			if(!itemInfo.BAKFIPIFDLE_IsEventRareItem)
			{
				if(!itemInfo.PHJHJGDLPED_IsRareItem)
				{
					layoutStateTable.StartChildrenAnimGoStop(0, 0);
					layoutNumStateTable.StartChildrenAnimGoStop(m_is_bonus ? 0 : 1, m_is_bonus ? 0 : 1);
					normalItem.layoutNumAnim.StartChildrenAnimGoStop("st_out");
					shadowAnime.StartChildrenAnimGoStop("st_in");
				}
				else
				{
					layoutStateTable.StartChildrenAnimGoStop(1, 1);
					layoutNumStateTable.StartChildrenAnimGoStop(1, 1);
					rareItem.layoutRoot.StartChildrenAnimGoStop("st_hiraki");
					shadowAnime.StartChildrenAnimGoStop("st_hiraki");
				}
			}
			else
			{
				layoutStateTable.StartChildrenAnimGoStop(2, 2);
				layoutNumStateTable.StartChildrenAnimGoStop(1, 1);
				eventRareItem.layoutRoot.StartChildrenAnimGoStop("st_hiraki");
				shadowAnime.StartChildrenAnimGoStop("st_hiraki");
			}
			if(itemInfo != null && itemInfo.HHACNFODNEF_Category == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			{
				layoutSceneStatusAnim.StartChildrenAnimGoStop("st_in");
				SetupItemStatusType();
			}
			FinalizeBaseCountNumber();
			FinalizeBonusCountNumber();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x719224 Offset: 0x719224 VA: 0x719224
		//// RVA: 0x1D915D0 Offset: 0x1D915D0 VA: 0x1D915D0
		private IEnumerator Co_PlayingAnim(AbsoluteLayout layout, float animEndRate)
		{
			bool prevInput;

			//0x1D92F88
			ViewFrameAnimation frameAnim = layout.GetView(0).FrameAnimation;
			int target_frame = Mathf.RoundToInt(frameAnim.SearchLabelFrame("anim_end"));
			yield return new WaitWhile(() =>
			{
				//0x1D92BAC
				if(!itemInfo.PHJHJGDLPED_IsRareItem)
				{
					if(!itemInfo.BAKFIPIFDLE_IsEventRareItem)
					{
						return frameAnim.FrameCount < target_frame;
					}
				}
				return frameAnim.FrameCount * 1.0f / frameAnim.FrameNum <= animEndRate;
			});
			ChangeBaseCountNumber(itemInfo.HMFFHLPNMPH);
			FinalizeBonusCountNumber();
			if (itemInfo.HHACNFODNEF_Category == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			{
				prevInput = GameManager.Instance.InputEnabled;
				GameManager.Instance.InputEnabled = true;
				isOpenRecordPlateInfo = true;
				this.StartCoroutineWatched(PopupRecordPlate.Show(RecordPlateUtility.eSceneType.Result, () =>
				{
					//0x1D92CC8
					isOpenRecordPlateInfo = false;
				}, false));
				yield return new WaitWhile(() =>
				{
					//0x1D92CF0
					return isOpenRecordPlateInfo;
				});
				GameManager.Instance.InputEnabled = prevInput;
			}
			if (onFinished != null)
				onFinished();
		}

		//// RVA: 0x1D916F4 Offset: 0x1D916F4 VA: 0x1D916F4
		private void PlayNormalItemSE()
		{
			SoundManager.Instance.sePlayerResult.Play(16);
		}

		//// RVA: 0x1D9169C Offset: 0x1D9169C VA: 0x1D9169C
		private void PlayRareItemSE()
		{
			SoundManager.Instance.sePlayerResult.Play(17);
		}

		//// RVA: 0x1D92100 Offset: 0x1D92100 VA: 0x1D92100
		//private bool IsEnableBaseCount() { }

		//// RVA: 0x1D92108 Offset: 0x1D92108 VA: 0x1D92108
		private bool IsEnableBonusCount()
		{
			return itemInfo.HHACNFODNEF_Category != EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene && !itemInfo.PHJHJGDLPED_IsRareItem;
		}

		//// RVA: 0x1D9216C Offset: 0x1D9216C VA: 0x1D9216C
		private void ChangeBaseCountNumber(int number)
		{
			StringBuilder str = new StringBuilder(16);
			str.SetFormat(JpStringLiterals.StringLiteral_14007, number);
			for(int i = 0; i < textCounts.Length; i++)
			{
				textCounts[i].text = str.ToString();
				textCounts[i].enabled = true;
			}
		}

		//// RVA: 0x1D9205C Offset: 0x1D9205C VA: 0x1D9205C
		public void FinalizeBaseCountNumber()
		{
			ChangeBaseCountNumber(itemInfo.DJJGNDCMNHF_BonusCount + itemInfo.HMFFHLPNMPH);
		}

		//// RVA: 0x1D9232C Offset: 0x1D9232C VA: 0x1D9232C
		private void ChangeBonusCountNumber(int number)
		{
			if(IsEnableBonusCount())
			{
				StringBuilder str = new StringBuilder(16);
				str.SetFormat(JpStringLiterals.StringLiteral_17754, number);
				for(int i = 0; i < textBonus.Length; i++)
				{
					textBonus[i].text = str.ToString();
					textBonus[i].enabled = true;
				}
			}
		}

		//// RVA: 0x1D920B0 Offset: 0x1D920B0 VA: 0x1D920B0
		private void FinalizeBonusCountNumber()
		{
			ChangeBonusCountNumber(itemInfo.DJJGNDCMNHF_BonusCount);
		}

		//// RVA: 0x1D90E08 Offset: 0x1D90E08 VA: 0x1D90E08
		//public bool IsSceneCardItem() { }

		//// RVA: 0x1D924FC Offset: 0x1D924FC VA: 0x1D924FC
		private void OnStay()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if(itemInfo != null && itemInfo.HHACNFODNEF_Category == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			{
				ShowSceneCardItem();
				return;
			}
			MenuScene.Instance.ShowItemDetail(itemInfo.KIJAPOFAGPN_ItemId, itemInfo.MHFBCINOJEE_Count, null);
		}

		//// RVA: 0x1D92660 Offset: 0x1D92660 VA: 0x1D92660
		private void ShowSceneCardItem()
		{
			MenuScene.Instance.ShowSceneStatusPopupWindow(GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes[EKLNMHFCAOI.DEACAHNLMNI_getItemId(itemInfo.KIJAPOFAGPN_ItemId) - 1], GameManager.Instance.ViewPlayerData, false, TransitionList.Type.UNDEFINED, null, false, true, SceneStatusParam.PageSave.None, false);
		}

		//// RVA: 0x1D9174C Offset: 0x1D9174C VA: 0x1D9174C
		private void SetupItemStatusType()
		{
			if(itemInfo.LHEDLDEMPPG_IsNew)
			{
				layoutSceneStatusType.StartChildrenAnimGoStop("new");
				newMarkIcon.SetActive(true);
			}
			else
			{
				layoutSceneStatusType.StartChildrenAnimGoStop("non");
			}
		}
	}
}
