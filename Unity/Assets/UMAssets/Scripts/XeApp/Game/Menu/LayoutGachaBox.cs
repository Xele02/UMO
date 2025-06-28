using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutGachaBox : LayoutUGUIScriptBase
	{
		protected AbsoluteLayout m_layoutRoot; // 0x14
		protected AbsoluteLayout m_layoutBeforeAfter; // 0x18
		protected AbsoluteLayout m_layoutRemain; // 0x1C
		protected AbsoluteLayout m_layoutPickup; // 0x20
		protected AbsoluteLayout m_layoutChara; // 0x24
		protected Text m_textPeriod; // 0x28
		protected Text m_textBoxNum; // 0x2C
		protected Text m_textPickupItem; // 0x30
		protected RawImageEx m_imageTitle; // 0x34
		protected RawImageEx[] m_imageCostItem; // 0x38
		protected RawImageEx m_imagePickupFrame; // 0x3C
		protected RawImageEx m_imagePickupPlate; // 0x40
		protected RawImageEx m_imagePickupItem; // 0x44
		protected NumberBase m_numItem; // 0x48
		protected NumberBase m_numGetPlate; // 0x4C
		protected NumberBase m_numMaxPlate; // 0x50
		protected NumberBase m_numRemain; // 0x54
		protected StayButton m_buttonItem; // 0x58
		protected StayButton m_buttonPlate; // 0x5C
		protected ActionButton m_buttonDetail; // 0x60
		protected LayoutGachaBoxButton m_buttonSingle; // 0x64
		protected LayoutGachaBoxButton m_buttonMulti; // 0x68
		protected SceneCardTextureCache m_scenePlate; // 0x6C
		protected SceneFrameTextureCache m_sceneFrame; // 0x70
		protected HGFPAFPGIKG m_view; // 0x74
		protected LimitTimeWatcher m_timeWatcher = new LimitTimeWatcher(); // 0x78
		protected int m_prevTimeCount; // 0x7C
		private TexUVListManager m_uvMan; // 0x80
		public Action<Transform, HGFPAFPGIKG.CMEDMHFOFAH> OnClickButtonPickup; // 0x84
		public Action OnClickButtonDetail; // 0x88
		public Action OnClickButtonSingle; // 0x8C
		public Action<int> OnClickButtonMulti; // 0x90

		// RVA: 0x199D6D0 Offset: 0x199D6D0 VA: 0x199D6D0
		private void Start()
		{
			m_scenePlate = new SceneCardTextureCache(1);
			m_sceneFrame = new SceneFrameTextureCache();
		}

		// RVA: 0x199D768 Offset: 0x199D768 VA: 0x199D768
		private void Update()
		{
			if(m_scenePlate != null)
				m_scenePlate.Update();
			if(m_sceneFrame != null)
				m_sceneFrame.Update();
			if(!NKGJPJPHLIF.HHCJCDFCLOB.DPJBHHIHJJK)
			{
				m_timeWatcher.Update();
			}
		}

		// RVA: 0x199D850 Offset: 0x199D850 VA: 0x199D850 Slot: 6
		public virtual void Setup(int eventId, HGFPAFPGIKG view)
		{
			m_view = view;
			HGFPAFPGIKG.CMEDMHFOFAH it = GetPickupItem(view);
			m_imageTitle.enabled = false;
			GameManager.Instance.QuestEventTextureCache.LoadFont(eventId, (IiconTexture image) =>
			{
				//0x19A1858
				m_imageTitle.enabled = true;
				image.Set(m_imageTitle);
			});
			m_numItem.SetNumber(view.MFHLHIDLKGN_NumTicket, 0);
			m_numGetPlate.SetNumber(it.BFGKGMOLAFL_MaxPlate - it.NNCCGILOOIE, 0);
			m_numMaxPlate.SetNumber(it.BFGKGMOLAFL_MaxPlate, 0);
			m_textBoxNum.text = view.JALHJAPAFLK_BoxCurrent.ToString() + "/" + view.DMPELKEMCCJ_BoxTotal.ToString();
			if(view.ENJLGHMEKEL_Type == HGFPAFPGIKG.KAFHMMOGLKO.FAFCPLEAFCP_0_Summer)
			{
				m_layoutChara.StartChildrenAnimGoStop("01");
			}
			else if(view.ENJLGHMEKEL_Type == HGFPAFPGIKG.KAFHMMOGLKO.DALFBOFBJJL_1_NewYear)
			{
				m_layoutChara.StartChildrenAnimGoStop("02");
			}
			else if(view.ENJLGHMEKEL_Type == HGFPAFPGIKG.KAFHMMOGLKO.AIMPCCIHKAJ_2)
			{
				m_layoutChara.StartChildrenAnimGoStop("03");
			}
			m_buttonSingle.Setup(1, view.AAIKGPGDHIB_Cost);
			int a = view.MFHLHIDLKGN_NumTicket / view.AAIKGPGDHIB_Cost;
			m_buttonSingle.Disable = a < 1;
			int b = Mathf.Clamp(Mathf.Min(new int[2]{view.MFHLHIDLKGN_NumTicket, a}), 0, 10);
			m_buttonMulti.Setup(b, b * view.AAIKGPGDHIB_Cost);
			m_buttonMulti.Disable = a < b;
			DateTime d1 = Utility.GetLocalDateTime(view.JOFAGCFNKIO_Start);
			DateTime d2 = Utility.GetLocalDateTime(view.EBCHFBIINDP_End);
			m_textPeriod.text = string.Format(MessageManager.Instance.GetMessage("menu", "event_gacha_box_period"), new object[10]
			{
				d1.Year, d1.Month, d1.Day, d1.Hour, d1.Minute,
				d2.Year, d2.Month, d2.Day, d2.Hour, d2.Minute
			});
			m_timeWatcher.onElapsedCallback = (long current, long limit, long remain) =>
			{
				//0x19A195C
				TimeSpan t_ = TimeSpan.FromSeconds(remain);
				string s;
				int v;
				if(t_.Days <1)
				{
					if(t_.Hours < 1)
					{
						if(t_.Minutes < 1)
						{
							v = t_.Seconds;
							s = "04";
						}
						else
						{
							v = t_.Minutes;
							s = "03";
						}
					}
					else
					{
						v = t_.Hours;
						s = "02";
					}
				}
				else
				{
					v = t_.Days;
					s = "01";
				}
				if(m_prevTimeCount != v)
				{
					m_numRemain.SetNumber(v, 0);
					m_layoutRemain.StartChildrenAnimGoStop(s);
					m_prevTimeCount = v;
				}
			};
			m_timeWatcher.onEndCallback = (long current) =>
			{
				//0x19A1B40
				SetOpenLayout(true);
			};
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			if(t >= view.JOFAGCFNKIO_Start)
			{
				SetOpenLayout(true);
			}
			else
			{
				m_timeWatcher.WatchStart(m_view.JOFAGCFNKIO_Start, false);
				SetOpenLayout(false);
			}
		}

		// RVA: 0x199EB60 Offset: 0x199EB60 VA: 0x199EB60
		public void SetCostIcon(HGFPAFPGIKG.KAFHMMOGLKO type, int halfTimeId)
		{
			if(m_uvMan != null && m_imageCostItem != null)
			{
                TexUVData uvData = m_uvMan.GetUVData(string.Format("g_b_icon_{0:D2}_{1:D2}", (int)type + 1, halfTimeId));
				for(int i = 0; i < m_imageCostItem.Length; i++)
				{
					m_imageCostItem[i].uvRect = LayoutUGUIUtility.MakeUnityUVRect(uvData);
				}
            }
		}

		// // RVA: 0x199E5D8 Offset: 0x199E5D8 VA: 0x199E5D8
		public void SetOpenLayout(bool isOpen)
		{
			HGFPAFPGIKG.CMEDMHFOFAH it = GetPickupItem(m_view);
			int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(it.GLCLFMGPMAN_ItemId);
            EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(it.GLCLFMGPMAN_ItemId);
            if (isOpen)
			{
				if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
				{
					MLIBEPGADJH_Scene.KKLDOOJBJMN scene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[id - 1];
					SetImagePlate(id, false);
					SetImageFrame(scene.FKDCCLPGKDK_Ma, scene.EKLIPGELKCL_Rarity, 1);
					m_layoutPickup.StartChildrenAnimGoStop("01");
				}
				else
				{
					SetImageItem(it.GLCLFMGPMAN_ItemId, false);
					m_layoutPickup.StartChildrenAnimGoStop("02");
					m_textPickupItem.text = EKLNMHFCAOI.INCKKODFJAP_GetItemName(it.GLCLFMGPMAN_ItemId);
				}
				m_layoutBeforeAfter.StartChildrenAnimGoStop("02");
			}
			else
			{
				if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
				{
					MLIBEPGADJH_Scene.KKLDOOJBJMN scene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[id - 1];
					SetImagePlate(id, false);
					SetImagePlateSilhouette(id);
					SetImageFrame(scene.FKDCCLPGKDK_Ma, scene.EKLIPGELKCL_Rarity, 1);
					m_layoutPickup.StartChildrenAnimGoStop("01");
				}
				else
				{
					SetImageItem(it.GLCLFMGPMAN_ItemId, false);
					m_layoutPickup.StartChildrenAnimGoStop("02");
					m_textPickupItem.text = EKLNMHFCAOI.INCKKODFJAP_GetItemName(it.GLCLFMGPMAN_ItemId);
				}
				m_layoutBeforeAfter.StartChildrenAnimGoStop("01");
			}
		}

		// // RVA: 0x199F0A8 Offset: 0x199F0A8 VA: 0x199F0A8 Slot: 7
		public virtual HGFPAFPGIKG.CMEDMHFOFAH GetPickupItem(HGFPAFPGIKG view)
		{
			if(view.LOMNOJCONHP != null && view.LOMNOJCONHP.Count > 0)
				return view.LOMNOJCONHP[0];
			return null;
		}

		// RVA: 0x199F158 Offset: 0x199F158 VA: 0x199F158
		public void Enter()
		{
			m_layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x199F1E4 Offset: 0x199F1E4 VA: 0x199F1E4
		public void Leave()
		{
			m_layoutRoot.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x199F270 Offset: 0x199F270 VA: 0x199F270
		// public void Show() { }

		// // RVA: 0x199F2EC Offset: 0x199F2EC VA: 0x199F2EC
		// public void Hide() { }

		// RVA: 0x199F368 Offset: 0x199F368 VA: 0x199F368
		public bool IsPlaying()
		{
			return m_layoutRoot.IsPlayingChildren();
		}

		// // RVA: 0x199F394 Offset: 0x199F394 VA: 0x199F394
		// private bool IsLoadingScenePlate() { }

		// // RVA: 0x199F3F0 Offset: 0x199F3F0 VA: 0x199F3F0
		// private void TerminatedScenePlate() { }

		// // RVA: 0x199F450 Offset: 0x199F450 VA: 0x199F450 Slot: 8
		protected virtual void SetImagePlate(int sceneId, bool loadOnly/* = False*/)
		{
			if(!loadOnly)
			{
				m_imagePickupPlate.enabled = false;
			}
			GCIJNCFDNON_SceneInfo scene = new GCIJNCFDNON_SceneInfo();
			scene.KHEKNNFCAOI(sceneId, null, null, 0, 0, 0, false, 0, 0);
			if(!scene.JOKJBMJBLBB_Single)
			{
				m_scenePlate.Load(sceneId, 1, (IiconTexture texture) =>
				{
					//0x19A273C
					if(!loadOnly)
					{
						m_imagePickupPlate.enabled = true;
						texture.Set(m_imagePickupPlate);
					}
				});
			}
			m_scenePlate.Load(sceneId, 2, (IiconTexture texture) =>
			{
				//0x19A1EB0
				return;
			});
			if(!scene.JOKJBMJBLBB_Single)
			{
				GameManager.Instance.SceneIconCache.Load(sceneId, 1, (IiconTexture texture) =>
				{
					//0x19A1EB4
					return;
				});
			}
			GameManager.Instance.SceneIconCache.Load(sceneId, 2, (IiconTexture texture) =>
			{
				//0x19A1EB8
				return;
			});
		}

		// // RVA: 0x199EFB8 Offset: 0x199EFB8 VA: 0x199EFB8
		protected void SetImagePlateSilhouette(int sceneId)
		{
			m_imagePickupPlate.enabled = false;
			m_scenePlate.LoadSilhouette(sceneId, 1, (IiconTexture texture) =>
			{
				//0x19A1B48
				m_imagePickupPlate.enabled = true;
				texture.Set(m_imagePickupPlate);
			});
		}

		// // RVA: 0x199EE18 Offset: 0x199EE18 VA: 0x199EE18
		protected void SetImageItem(int itemId, bool loadOnly/* = False*/)
		{
			if(!loadOnly)
			{
				m_imagePickupItem.enabled = false;
			}
			GameManager.Instance.ItemTextureCache.Load(itemId, (IiconTexture texture) =>
			{
				//0x19A2874
				if(!loadOnly)
				{
					m_imagePickupItem.enabled = true;
					texture.Set(m_imagePickupItem);
				}
			});
		}

		// // RVA: 0x199ED20 Offset: 0x199ED20 VA: 0x199ED20
		private void SetImageFrame(int attrId, int baseRarity, int evolveId)
		{
			m_imagePickupFrame.enabled = false;
			m_sceneFrame.Load((GameAttribute.Type)attrId, baseRarity, evolveId, (IiconTexture texture) =>
			{
				//0x19A1C4C
				m_imagePickupFrame.enabled = true;
				texture.Set(m_imagePickupFrame);
			});
		}

		// // RVA: 0x199FA48 Offset: 0x199FA48 VA: 0x199FA48
		protected void OnClickPickupInfo()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			if(OnClickButtonPickup != null)
			{
				OnClickButtonPickup(transform, GetPickupItem(m_view));
			}
		}

		// RVA: 0x199FB4C Offset: 0x199FB4C VA: 0x199FB4C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_uvMan = uvMan;
			m_layoutRoot = layout.FindViewById("sw_gacha_box_inout_anim") as AbsoluteLayout;
			m_layoutBeforeAfter = layout.FindViewById("swtbl_g_b_before_after") as AbsoluteLayout;
			m_layoutRemain = layout.FindViewById("swtbl_g_b_count") as AbsoluteLayout;
			m_layoutPickup = layout.FindViewById("swtbl_special") as AbsoluteLayout;
			m_layoutChara = layout.FindViewById("g_b_bg") as AbsoluteLayout;
			Text[] txts = GetComponentsInChildren<Text>(true);
			m_textPeriod = Array.Find(txts, (Text _) =>
			{
				//0x19A1EBC
				return _.name == "period (TextView)";
			});
			m_textBoxNum = Array.Find(txts, (Text _) =>
			{
				//0x19A1F3C
				return _.name == "platenum (TextView)";
			});
			m_textPickupItem = Array.Find(txts, (Text _) =>
			{
				//0x19A1FBC
				return _.name == "item_name (TextView)";
			});
			RawImageEx[] imgs = GetComponentsInChildren<RawImageEx>(true);
			m_imageTitle = Array.Find(imgs, (RawImageEx _) =>
			{
				//0x19A203C
				return _.name == "swtexc_cmn_box (ImageView)";
			});
			m_imageTitle.raycastTarget = false;
			m_imageCostItem = Array.FindAll(imgs, (RawImageEx _) =>
			{
				//0x19A20BC
				return _.name == "swtexf_g_b_icon (ImageView)";
			});
			m_imagePickupFrame = Array.Find(imgs, (RawImageEx _) =>
			{
				//0x19A213C
				return _.name == "swtexc_cmn_scene_frame_512 (ImageView)";
			});
			m_imagePickupPlate = Array.Find(imgs, (RawImageEx _) =>
			{
				//0x19A21BC
				return _.name == "swtexc_cmn_scene_m03 (ImageView)";
			});
			m_imagePickupItem = Array.Find(imgs, (RawImageEx _) =>
			{
				//0x19A223C
				return _.name == "swtexc_cmn_item (ImageView)";
			});
			NumberBase[] nbrs = GetComponentsInChildren<NumberBase>(true);
			m_numItem = nbrs.Where((NumberBase _) =>
			{
				//0x19A22BC
				return _.name == "swnum_tkt (AbsoluteLayout)";
			}).First();
			m_numGetPlate = nbrs.Where((NumberBase _) =>
			{
				//0x19A233C
				return _.name == "swnum_get (AbsoluteLayout)";
			}).First();
			m_numMaxPlate = nbrs.Where((NumberBase _) =>
			{
				//0x19A23BC
				return _.name == "swnum_get_denominator (AbsoluteLayout)";
			}).First();
			m_numRemain = nbrs.Where((NumberBase _) =>
			{
				//0x19A243C
				return _.name == "swnum_remaining (AbsoluteLayout)";
			}).First();
			ActionButton[] btns = GetComponentsInChildren<ActionButton>(true);
			m_buttonItem = btns.Where((ActionButton _) =>
			{
				//0x19A24BC
				return _.name == "g_b_frm8 (AbsoluteLayout)";
			}).First() as StayButton;
			m_buttonItem.AddOnClickCallback(OnClickPickupInfo);
			m_buttonItem.AddOnStayCallback(OnClickPickupInfo);
			m_buttonPlate = btns.Where((ActionButton _) =>
			{
				//0x19A253C
				return _.name == "sw_cmn_scene_01 (AbsoluteLayout)";
			}).First() as StayButton;
			m_buttonPlate.AddOnClickCallback(OnClickPickupInfo);
			m_buttonPlate.AddOnStayCallback(OnClickPickupInfo);
			m_buttonDetail = btns.Where((ActionButton _) =>
			{
				//0x19A25BC
				return _.name == "sw_btn_detail_anim (AbsoluteLayout)";
			}).First();
			m_buttonDetail.AddOnClickCallback(() =>
			{
				//0x19A1D50
				if(OnClickButtonDetail != null)
					OnClickButtonDetail();
			});
			m_buttonSingle = btns.Where((ActionButton _) =>
			{
				//0x19A263C
				return _.name == "sw_btn_buy_anime_01 (AbsoluteLayout)";
			}).First() as LayoutGachaBoxButton;
			m_buttonSingle.InitializeFromLayout(layout, m_uvMan);
			m_buttonSingle.AddOnClickCallback(() =>
			{
				//0x19A1D64
				if(OnClickButtonSingle != null)
					OnClickButtonSingle();
			});
			m_buttonMulti = btns.Where((ActionButton _) =>
			{
				//0x19A26BC
				return _.name == "sw_btn_buy_anime_02 (AbsoluteLayout)";
			}).First() as LayoutGachaBoxButton;
			m_buttonMulti.InitializeFromLayout(layout, m_uvMan);
			m_buttonMulti.AddOnClickCallback(() =>
			{
				//0x19A1D78
				if(OnClickButtonMulti != null)
					OnClickButtonMulti(m_buttonMulti.num);
			});
			Loaded();
			return true;
		}
	}
}
