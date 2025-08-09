using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutGachaBoxMission : LayoutGachaBox
	{
		private Text m_textSerif; // 0x94
		private Text m_textBoxName; // 0x98
		private RawImageEx m_imageNext; // 0x9C
		private RawImageEx m_imageChara; // 0xA0
		private ActionButton m_buttonNext; // 0xA4
		private AbsoluteLayout m_layoutPickup; // 0xA8
		private AbsoluteLayout m_layoutChara; // 0xAC
		private AbsoluteLayout m_layoutGetPickup; // 0xB0
		public Action OnClickButtonNext; // 0xB4

		// RVA: 0x19A5350 Offset: 0x19A5350 VA: 0x19A5350 Slot: 6
		public override void Setup(int eventId, HGFPAFPGIKG view)
		{
			m_view = view;
            HGFPAFPGIKG.CMEDMHFOFAH it = GetPickupItem(view);
			m_numItem.SetNumber(view.MFHLHIDLKGN_NumTicket, 0);
			m_textBoxName.text = string.Format(MessageManager.Instance.GetMessage("menu", "event_gacha_box_list_count"), view.NNCCGILOOIE_ListIdx + 1);
			m_numGetPlate.SetNumber(it.BFGKGMOLAFL_Max - it.NNCCGILOOIE_Remain, 0);
			m_numMaxPlate.SetNumber(it.BFGKGMOLAFL_Max, 0);
			m_layoutGetPickup.StartChildrenAnimGoStop(it.NNCCGILOOIE_Remain < it.BFGKGMOLAFL_Max ? "02" : "01");
			m_buttonNext.Disable = it.NNCCGILOOIE_Remain == it.BFGKGMOLAFL_Max;
			m_textBoxNum.text = view.JALHJAPAFLK_BoxCurrent + "/" + view.DMPELKEMCCJ_BoxTotal;
			m_buttonSingle.Setup(1, view.AAIKGPGDHIB_Cost);
			int a = (view.MFHLHIDLKGN_NumTicket / view.AAIKGPGDHIB_Cost);
			m_buttonSingle.Disable = a < 1;
			int b = Mathf.Clamp(Mathf.Min(new int[2] { view.JALHJAPAFLK_BoxCurrent, a }), 1, 10);
			m_buttonMulti.Setup(b, b * view.AAIKGPGDHIB_Cost);
			m_buttonMulti.Disable = a < b;
			DateTime d1 = Utility.GetLocalDateTime(view.JOFAGCFNKIO_Start);
			DateTime d2 = Utility.GetLocalDateTime(view.EBCHFBIINDP_End);
			m_textPeriod.text = string.Format(MessageManager.Instance.GetMessage("menu", "event_gacha_box_period"), new object[10]
			{
				d1.Year, d1.Month, d1.Day, d1.Hour, d1.Minute,
				d2.Year, d2.Month, d2.Day, d2.Hour, d2.Minute
			});
			if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(it.GLCLFMGPMAN_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			{
				SetImagePlate(EKLNMHFCAOI.DEACAHNLMNI_getItemId(it.GLCLFMGPMAN_ItemId), false);
				m_layoutPickup.StartChildrenAnimGoStop("02");
			}
			else
			{
				SetImageItem(it.GLCLFMGPMAN_ItemId, false);
				m_layoutPickup.StartChildrenAnimGoStop("01");
			}
        }

		// RVA: 0x19A5F3C Offset: 0x19A5F3C VA: 0x19A5F3C
		public void SetupSerif(List<HGFPAFPGIKG.LBEPCOMCHNE> list)
		{
			if(list == null || list.Count < 1)
				return;
			int order = list[0].EILKGEADKGH;
			List<HGFPAFPGIKG.LBEPCOMCHNE> l2 = list.FindAll((HGFPAFPGIKG.LBEPCOMCHNE x) =>
			{
				//0x19A8BE4
				return x.EILKGEADKGH == order;
			});
			HGFPAFPGIKG.LBEPCOMCHNE it = l2[UnityEngine.Random.Range(0, l2.Count)];
			m_layoutChara.StartChildrenAnimGoStop(it.BKCIPBIHKJG_CharaId.ToString("D2"));
			m_textSerif.text = it.EIGFHDMDECG_CharaText;
		}

		// // RVA: 0x19A618C Offset: 0x19A618C VA: 0x19A618C
		// private bool IsLoadingScenePlate() { }

		// // RVA: 0x19A61E8 Offset: 0x19A61E8 VA: 0x19A61E8
		// private void TerminatedScenePlate() { }

		// RVA: 0x19A6248 Offset: 0x19A6248 VA: 0x19A6248 Slot: 8
		protected override void SetImagePlate(int sceneId, bool loadOnly/* = False*/)
		{
			if(!loadOnly)
			{
				m_imagePickupPlate.enabled = false;
			}
			GCIJNCFDNON_SceneInfo scene = new GCIJNCFDNON_SceneInfo();
			scene.KHEKNNFCAOI(sceneId, null, null, 0, 0, 0, false, 0, 0);
			if(!scene.JOKJBMJBLBB_Single)
			{
				GameManager.Instance.SceneIconCache.Load(sceneId, 1, (IiconTexture texture) =>
				{
					//0x19A8C1C
					if(!loadOnly)
					{
						m_imagePickupPlate.enabled = true;
						(texture as IconTexture).Set(m_imagePickupPlate);
					}
				});
			}
			GameManager.Instance.SceneIconCache.Load(sceneId, 2, (IiconTexture texture) =>
			{
				//0x19A8360
				return;
			});
		}

		// RVA: 0x19A6614 Offset: 0x19A6614 VA: 0x19A6614 Slot: 7
		public override HGFPAFPGIKG.CMEDMHFOFAH GetPickupItem(HGFPAFPGIKG view)
		{
            List<HGFPAFPGIKG.CMEDMHFOFAH> l = view.GMENOMFADOH();
            for (int i = 0; i < l.Count; i++)
			{
				if(l[i].JOPPFEHKNFO_IsPickup)
					return l[i];
			}
			return null;
		}

		// RVA: 0x19A673C Offset: 0x19A673C VA: 0x19A673C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewById("sw_gacha_box_inout_anim") as AbsoluteLayout;
			m_layoutRemain = layout.FindViewById("swtbl_g_b_count") as AbsoluteLayout;
			m_layoutPickup = layout.FindViewById("swtbl_item_scene") as AbsoluteLayout;
			m_layoutChara = layout.FindViewById("g_b_bg1") as AbsoluteLayout;
			m_layoutGetPickup = layout.FindViewById("swtbl_item_get") as AbsoluteLayout;
			Text[] txts = GetComponentsInChildren<Text>(true);
			m_textPeriod = txts.Where((Text _) =>
			{
				//0x19A8364
				return _.name == "period (TextView)";
			}).First();
			m_textBoxNum = txts.Where((Text _) =>
			{
				//0x19A83E4
				return _.name == "platenum (TextView)";
			}).First();
			m_textSerif = txts.Where((Text _) =>
			{
				//0x19A8464
				return _.name == "serif (TextView)";
			}).First();
			m_textBoxName = txts.Where((Text _) =>
			{
				//0x19A84E4
				return _.name == "box (TextView)";
			}).First();
			RawImageEx[] imgs = GetComponentsInChildren<RawImageEx>(true);
			m_imagePickupItem = imgs.Where((RawImageEx _) =>
			{
				//0x19A8564
				return _.name == "swtexc_cmn_item (ImageView)";
			}).First();
			m_imagePickupPlate = imgs.Where((RawImageEx _) =>
			{
				//0x19A85E4
				return _.name == "swtexc_cmn_scene_m01 (ImageView)";
			}).First();
			m_imageChara = imgs.Where((RawImageEx _) =>
			{
				//0x19A8664
				return _.name == "g_b_chara_base (ImageView)";
			}).First();
			m_imageChara.raycastTarget = false;
			m_imageNext = transform.Find("sw_gacha_box_inout_anim (AbsoluteLayout)/g_b_window (AbsoluteLayout)/sw_btn_next_anim (AbsoluteLayout)").GetComponentsInChildren<RawImageEx>(true).Where((RawImageEx _) =>
			{
				//0x19A86E4
				return _.name == "swtexf_g_b_btn_fnt_a (ImageView)";
			}).First();
			m_imageNext.uvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("g_b_btn_fnt_a_02"));
			NumberBase[] nbrs = GetComponentsInChildren<NumberBase>(true);
			m_numItem = nbrs.Where((NumberBase _) =>
			{
				//0x19A8764
				return _.name == "swnum_tkt (AbsoluteLayout)";
			}).First();
			m_numGetPlate = nbrs.Where((NumberBase _) =>
			{
				//0x19A87E4
				return _.name == "swnum_get (AbsoluteLayout)";
			}).First();
			m_numMaxPlate = nbrs.Where((NumberBase _) =>
			{
				//0x19A8864
				return _.name == "swnum_get_denominator (AbsoluteLayout)";
			}).First();
			ActionButton[] btns = GetComponentsInChildren<ActionButton>(true);
			m_buttonItem = btns.Where((ActionButton _) =>
			{
				//0x19A88E4
				return _.name == "item2 (AbsoluteLayout)";
			}).First() as StayButton;
			m_buttonItem.AddOnClickCallback(OnClickPickupInfo);
			m_buttonItem.AddOnStayCallback(OnClickPickupInfo);
			m_buttonPlate = btns.Where((ActionButton _) =>
			{
				//0x19A8964
				return _.name == "scene (AbsoluteLayout)";
			}).First() as StayButton;
			m_buttonPlate.AddOnClickCallback(OnClickPickupInfo);
			m_buttonPlate.AddOnStayCallback(OnClickPickupInfo);
			m_buttonDetail = btns.Where((ActionButton _) =>
			{
				//0x19A89E4
				return _.name == "sw_btn_detail_anim (AbsoluteLayout)";
			}).First();
			m_buttonDetail.AddOnClickCallback(() =>
			{
				//0x19A8218
				if(OnClickButtonDetail != null)
					OnClickButtonDetail();
			});
			m_buttonNext = btns.Where((ActionButton _) =>
			{
				//0x19A8A64
				return _.name == "sw_btn_next_anim (AbsoluteLayout)";
			}).First();
			m_buttonNext.AddOnClickCallback(() =>
			{
				//0x19A822C
				if(OnClickButtonNext != null)
					OnClickButtonNext();
			});
			m_buttonSingle = btns.Where((ActionButton _) =>
			{
				//0x19A8AE4
				return _.name == "sw_btn_buy_anime_01 (AbsoluteLayout)";
			}).First() as LayoutGachaBoxButton;
			m_buttonSingle.InitializeFromLayout(layout, uvMan);
			m_buttonSingle.AddOnClickCallback(() =>
			{
				//0x19A8240
				if(OnClickButtonSingle != null)
					OnClickButtonSingle();
			});
			m_buttonMulti = btns.Where((ActionButton _) =>
			{
				//0x19A8B64
				return _.name == "sw_btn_buy_anime_02 (AbsoluteLayout)";
			}).First() as LayoutGachaBoxButton;
			m_buttonMulti.InitializeFromLayout(layout, uvMan);
			m_buttonMulti.AddOnClickCallback(() =>
			{
				//0x19A8254
				if(OnClickButtonMulti != null)
					OnClickButtonMulti(m_buttonMulti.num);
			});
			Loaded();
			return true;
		}
	}
}
