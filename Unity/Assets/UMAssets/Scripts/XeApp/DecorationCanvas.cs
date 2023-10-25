using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeSys;

namespace XeApp
{
	public class DecorationCanvas : MonoBehaviour
	{
		private static readonly Rect BgImageUVRect = new Rect(0.0234375f, 0.1425781f, 0.953125f, 0.7148438f); // 0x0
		private const string BgImageBundle = "ct/bg/hm/";
		public static DecorationCanvas instance; // 0x10
		[SerializeField]
		private RawImage m_bgImage; // 0xC
		[SerializeField]
		private Material m_posterKiraMaterial; // 0x10
		[SerializeField]
		private Material m_posterKiraMaterialFlip; // 0x14
		private GameObject m_bgEffect; // 0x18
		private Transform m_decorationItemRoot; // 0x1C
		private RectTransform m_decorationItemRootRect; // 0x20
		private DecorationBgManager m_decorationBgManager; // 0x24
		private DecorationItemManager m_decorationItemManager; // 0x28
		private DecorationContoller m_decorationController; // 0x2C
		private Camera m_decoCanvasCamera; // 0x30
		private TransitionUniqueId m_currentTransitionUniqueId; // 0x34
		public DecorationContoller.touchDelegate m_touchDelegate; // 0x38
		public Action<string> m_hitDelegate; // 0x3C
		private StringBuilder m_strBuilder = new StringBuilder(128); // 0x40
		public Action<DecorationItemBase> SelectCallback; // 0x48
		public Action<bool> EnablePostCallback; // 0x4C
		public Action<DecorationItemBase> PointerDownCallback; // 0x50
		public Action<DecorationItemBase> ClickCallback; // 0x54
		public Action TouchLeaveCallback; // 0x58
		public Action<DecorationItemBase> CreateItemCallback; // 0x5C
		public Action<DecorationItemBase, bool> ChangeKiraCallback; // 0x60
		private List<KDKFHGHGFEK> m_viewDecoItemDataList = new List<KDKFHGHGFEK>(); // 0x64
		public MDDBFCFOKFC DecoLocalSaveData = new MDDBFCFOKFC(); // 0x6C

		public DecorationItemManager ItemManager { get { return m_decorationItemManager; } } //0x1AB8A4C
		public Material PosterKiraMaterial { get { return m_posterKiraMaterial; } } //0x1AB8A54
		public Material PosterKiraMaterialFlip { get { return m_posterKiraMaterialFlip; } } //0x1AB8A5C
		public IntimacyController m_intimacyController { get; private set; } // 0x44
		public Action<DecorationItemBase> OnClickSerifButton { set { m_decorationItemManager.SerifButtonCallback = value; } } //0x1AB8A74
		public Action OnClickPriorityButton { set { m_decorationItemManager.PriorityButtonCallback = value; } } //0x1AB8A9C
		public Action OnClickFlipButton { set { m_decorationItemManager.FlipButtonCallback = value; } } //0x1AB8AC4
		//public List<KDKFHGHGFEK> ViewDecoItemDataList { get; } 0x1AB8AEC
		public bool IsReadyCanvas { get; private set; } // 0x68
		public bool IsLoaded { get; private set; } // 0x69
		public bool IsLoadedDecoration { get; private set; } // 0x6A
		public bool IsLoadedBgDecoration { get { return m_decorationBgManager.IsLodedTexture; } } //0x1AB8B24
		public bool IsLoadedItemDecoration { get { return m_decorationItemManager.IsLoadedItemManager; } } //0x1AB8B50
		public bool IsLoadedItem { get; private set; } // 0x6B
		public bool IsClearedSprite { get; private set; } // 0x70

		// RVA: 0x1AB8B8C Offset: 0x1AB8B8C VA: 0x1AB8B8C
		private void Awake()
		{
			m_decoCanvasCamera = GetComponentInChildren<Camera>(true);
#if UNITY_EDITOR || UNITY_STANDALONE
			if(m_posterKiraMaterial != null)
				BundleShaderInfo.Instance.FixMaterialShader(m_posterKiraMaterial);
			if(m_posterKiraMaterialFlip != null)
				BundleShaderInfo.Instance.FixMaterialShader(m_posterKiraMaterialFlip);
#endif
		}

		// RVA: 0x1AB8BF8 Offset: 0x1AB8BF8 VA: 0x1AB8BF8
		private void OnDestroy()
		{
			instance = null;
		}

		// RVA: 0x1AB8C88 Offset: 0x1AB8C88 VA: 0x1AB8C88
		private void Update()
		{
			TransitionUniqueId id = (TransitionUniqueId)MenuScene.Instance.GetCurrentScene().uniqueId;
			if (id == m_currentTransitionUniqueId)
				return;
			bool enabled = false;
			if(id < TransitionUniqueId.DECO_DECOVISIT_DECOVISITLIST_PROFIL_LOBBYMAIN)
			{
				enabled = false;
				if(id >= TransitionUniqueId.DECO && id <= TransitionUniqueId.DECO_DECOVISIT_DECOVISITLIST_PROFIL)
				{
					enabled = ((0x3b >> (((id - TransitionUniqueId.DECO) & 0x3f) & 0xff)) & 1) != 0;
				}
			}
			else
			{
				enabled = false;
				if (id >= TransitionUniqueId.DECO_DECOVISITLIST && id <= TransitionUniqueId.DECO_FRIENDSEARCH_PROFIL)
				{
					enabled = ((0x6013 >> (((id - TransitionUniqueId.DECO_DECOVISITLIST) & 0x7fff) & 0xff)) & 1) != 0;
				}
			}
			m_decoCanvasCamera.enabled = enabled;
			m_currentTransitionUniqueId = id;
		}

		//// RVA: 0x1AB8DC8 Offset: 0x1AB8DC8 VA: 0x1AB8DC8
		public int GetHaveDecorationItemCount()
		{
			int cnt = 0;
			foreach(var c in m_viewDecoItemDataList)
			{
				if(c.NPADACLCNAN_Category == EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj ||
					c.NPADACLCNAN_Category == EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif)
				{
					cnt += c.BFINGCJHOHI;
				}
			}
			return cnt;
		}

		//// RVA: 0x1AB8F80 Offset: 0x1AB8F80 VA: 0x1AB8F80
		//public KDKFHGHGFEK FindViewDecoItemData(Predicate<KDKFHGHGFEK> comparer) { }

		//// RVA: 0x1AB9000 Offset: 0x1AB9000 VA: 0x1AB9000
		public void LoadResource()
		{
			if(IsReadyCanvas)
				return;
			IsLoaded = false;
			this.StartCoroutineWatched(Co_LoadData());
		}

		//// RVA: 0x1AB90C8 Offset: 0x1AB90C8 VA: 0x1AB90C8
		public void ReloadIntimacyController()
		{
			if(m_intimacyController == null)
			{
				m_intimacyController = MenuScene.Instance.IntimacyControl;
			}
			m_intimacyController.InitDeco(MenuScene.Instance.GetCurrentTransitionRoot(), () =>
			{
				//0x1ABFF20
				m_intimacyController.SetEnableDecoCounter(GetDivaCount() > 0, true);
			});
		}

		//// RVA: 0x1AB9274 Offset: 0x1AB9274 VA: 0x1AB9274
		public bool IsIntimacyControllerLoaded()
		{
			if (m_intimacyController == null)
				return true;
			return !m_intimacyController.IsLoading();
		}

		//// RVA: 0x1AB9334 Offset: 0x1AB9334 VA: 0x1AB9334
		public void OnDestoryScene()
		{
			if (m_intimacyController == null)
				return;
			m_intimacyController.OnDestoryScene();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AAE1C Offset: 0x6AAE1C VA: 0x6AAE1C
		//// RVA: 0x1AB903C Offset: 0x1AB903C VA: 0x1AB903C
		private IEnumerator Co_LoadData()
		{
			//0x1AC1A1C
			yield return this.StartCoroutineWatched(Co_LoadCanvas());
			m_decorationBgManager = GetComponent<DecorationBgManager>();
			m_decorationItemManager = GetComponent<DecorationItemManager>();
			m_decorationController = GetComponent<DecorationContoller>();
			InitItemManager();
			yield return this.StartCoroutineWatched(Co_LoadBgResource());
			InitController();
			yield return this.StartCoroutineWatched(Co_LoadControllerLayout());
			yield return this.StartCoroutineWatched(m_decorationItemManager.Co_CreateLayoutCache());
			IsLoaded = true;
			IsReadyCanvas = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AAE94 Offset: 0x6AAE94 VA: 0x6AAE94
		//// RVA: 0x1AB9408 Offset: 0x1AB9408 VA: 0x1AB9408
		private IEnumerator Co_LoadCanvas()
		{
			//0x1AC1268
			Transform t = transform.Find(DecorationConstants.ItemRoot2 + "SpriteBase");
			m_decorationItemRoot = t.transform;
			m_decorationItemRootRect = m_decorationItemRoot.GetComponent<RectTransform>();
			yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AAF0C Offset: 0x6AAF0C VA: 0x6AAF0C
		//// RVA: 0x1AB94B4 Offset: 0x1AB94B4 VA: 0x1AB94B4
		//private IEnumerator Co_LoadBgImage() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AAF84 Offset: 0x6AAF84 VA: 0x6AAF84
		//// RVA: 0x1AB9560 Offset: 0x1AB9560 VA: 0x1AB9560
		public IEnumerator Co_LoadBgEffect()
		{
			int effId; // 0x1C
			string bn; // 0x20
			AssetBundleLoadAllAssetOperationBase op; // 0x24

			//0x1AC0470
			if (m_bgEffect != null)
			{
				DestroyImmediate(m_bgEffect);
				m_bgEffect = null;
			}
			long ct = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			ViewDecoBgEffect found = new ViewDecoBgEffect();
			if (!found.Init(ct))
				yield break;
			if(found.CanShowPopup())
			{
				bool isWait = true;
				PopupFirstBgEffectSetting(found, (PopupButton.ButtonLabel _) =>
				{
					//0x1AC00D8
					isWait = false;
					found.SetLastShowTime(ct);
					found.SetShowStatus(_ == PopupButton.ButtonLabel.GrowthConfirm);
				});
				while (isWait)
					yield return null;
				found.Save();
			}
			if (!found.IsEnableBgEffect())
				yield break;
			effId = found.EffectId;
			if (effId < 1)
				yield break;
			bn = string.Format("dc/bg/eff/{0:D2}.xab", effId);
			op = AssetBundleManager.LoadAllAssetAsync(bn);
			yield return op;
			GameObject eff = op.GetAsset<GameObject>(string.Format("bg_eff_{0:D2}", effId));
			if(eff != null)
			{
				m_bgEffect = Instantiate(eff, m_decorationItemRoot, false);
			}
			AssetBundleManager.UnloadAssetBundle(bn, false);
		}

		//// RVA: 0x1AB960C Offset: 0x1AB960C VA: 0x1AB960C
		public void SetActiveBgEffect(bool isActive)
		{
			if(m_bgEffect != null)
				m_bgEffect.SetActive(isActive);
		}

		//// RVA: 0x1AB96C8 Offset: 0x1AB96C8 VA: 0x1AB96C8
		private void PopupFirstBgEffectSetting(ViewDecoBgEffect view, Action<PopupButton.ButtonLabel> callback)
		{
			TodoLogger.LogError(0, "PopupFirstBgEffectSetting");
			if (callback != null)
				callback(PopupButton.ButtonLabel.Ok);
		}

		//// RVA: 0x1AB9BF4 Offset: 0x1AB9BF4 VA: 0x1AB9BF4
		private void InitItemManager()
		{
			m_decorationItemManager.Create(gameObject, this);
			SetItemManagerCallback();
		}

		//// RVA: 0x1AB9F04 Offset: 0x1AB9F04 VA: 0x1AB9F04
		public void LoadDecoration(DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN decoSet)
		{
			IsLoadedDecoration = false;
			this.StartCoroutineWatched(Co_LoadDecoration(decoSet));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AAFFC Offset: 0x6AAFFC VA: 0x6AAFFC
		//// RVA: 0x1AB9F34 Offset: 0x1AB9F34 VA: 0x1AB9F34
		public IEnumerator Co_LoadDecoration(DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN decoSet)
		{
			//0x1AC1F58
			yield return Co.R(Co_TryInstall(decoSet));
			LoadBgResource(decoSet.KIDHLCNFCKN_FloorId, decoSet.DJCJMCHMIMA_WallLId, decoSet.KCMEAABOIOA_WallRId, false);
			yield return new WaitUntil(() =>
			{
				//0x1ABFF64
				return IsLoadedBgDecoration;
			});
			IsClearedSprite = false;
			this.StartCoroutineWatched(Co_ClearSprite());
			yield return new WaitUntil(() =>
			{
				//0x1ABFF68
				return IsClearedSprite;
			});
			foreach(var c in decoSet.HBHMAKNGKFK_Items)
			{
				yield return this.StartCoroutineWatched(Co_LoadItem(c));
			}
			yield return this.StartCoroutineWatched(Co_LoadDecorationSerif());
			LoadedItem();
			IsLoadedDecoration = true;
		}

		//// RVA: 0x1AB9FFC Offset: 0x1AB9FFC VA: 0x1AB9FFC
		public void LoadItem(DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.MHODOAJPNHD item)
		{
			IsLoadedItem = false;
			this.StartCoroutineWatched(Co_LoadItem(item));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AB074 Offset: 0x6AB074 VA: 0x6AB074
		//// RVA: 0x1ABA02C Offset: 0x1ABA02C VA: 0x1ABA02C
		private IEnumerator Co_LoadItem(DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.MHODOAJPNHD item)
		{
			//0x1AC2D34
			if(item.HAJKNHNAIKL_ItemId != 0)
			{
				KDKFHGHGFEK data = new KDKFHGHGFEK();
				data.KHEKNNFCAOI(EKLNMHFCAOI.DEACAHNLMNI_getItemId(item.HAJKNHNAIKL_ItemId), EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(item.HAJKNHNAIKL_ItemId));
				DecorationItemBaseSetting s = new DecorationItemBaseSetting(data);
				s.InitPosition.x = item.GHPLINIACBB_PosX;
				s.InitPosition.y = item.PMBEODGMMBB_PosY;
				s.InitOrder = item.BNHOEFJAAKK_Prio;
				s.InitFlip = item.BDEEIPPDCLE_Rvs;
				s.InitWord = item.BEJGNPAAKNB_Word;
				s.InitStatusFlag = item.PMIPFEJFIHA_StatusFlag;
				DecorationItemArgsBase args = GenerateArgs(item.HAJKNHNAIKL_ItemId);
				LoadItemResource(item.HAJKNHNAIKL_ItemId, s, 0, args);
				yield return new WaitUntil(() =>
				{
					//0x1ABFF70
					return m_decorationItemManager.IsLoadedItemManager;
				});
				IsLoadedItem = true;
			}
		}

		//// RVA: 0x1ABA0F4 Offset: 0x1ABA0F4 VA: 0x1ABA0F4
		public void LoadDecorationSerif()
		{
			this.StartCoroutineWatched(Co_LoadDecorationSerif());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AB0EC Offset: 0x6AB0EC VA: 0x6AB0EC
		//// RVA: 0x1ABA118 Offset: 0x1ABA118 VA: 0x1ABA118
		private IEnumerator Co_LoadDecorationSerif()
		{
			//0x1AC24C8
			m_decorationItemManager.InitSerifResource(m_decorationItemRoot);
			yield return new WaitUntil(() =>
			{
				//0x1ABFF94
				return m_decorationItemManager.IsLoadedItemManager;
			});

		}

		//// RVA: 0x1ABA1C4 Offset: 0x1ABA1C4 VA: 0x1ABA1C4
		private DecorationItemArgsBase GenerateArgs(int resourceId)
		{
			if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(resourceId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara)
			{
				DecorationCharaArgs arg = new DecorationCharaArgs();
				arg.decorationBgManager = m_decorationBgManager;
				arg.decorationCanvas = this;
				arg.decorationController = m_decorationController;
				return arg;
			}
			else if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(resourceId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster)
			{
				DecorationPosterArgs arg = new DecorationPosterArgs(null, null);
				return arg;
			}
			else if(((int)EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(resourceId) & 0xfe) == 34)
			{
				DecorationPosterArgs arg = new DecorationPosterArgs(m_posterKiraMaterial, m_posterKiraMaterialFlip);
				return arg;
			}
			return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AB164 Offset: 0x6AB164 VA: 0x6AB164
		//// RVA: 0x1ABA33C Offset: 0x1ABA33C VA: 0x1ABA33C
		private IEnumerator Co_TryInstall(DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN decoSet)
		{
			//0x1AC34A8
			TryInstall(decoSet.KIDHLCNFCKN_FloorId, DecorationConstants.Attribute.Type.BgFloor);
			TryInstall(decoSet.DJCJMCHMIMA_WallLId, DecorationConstants.Attribute.Type.BgWallL);
			TryInstall(decoSet.KCMEAABOIOA_WallRId, DecorationConstants.Attribute.Type.BgWallR);
			for(int i = 0; i < decoSet.HBHMAKNGKFK_Items.Count; i++)
			{
				if(decoSet.HBHMAKNGKFK_Items[i].BEJGNPAAKNB_Word > 0)
				{
					TryInstall(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif, decoSet.HBHMAKNGKFK_Items[i].BEJGNPAAKNB_Word), DecorationConstants.Attribute.Type.None);
				}
				if(decoSet.HBHMAKNGKFK_Items[i].HAJKNHNAIKL_ItemId > 0)
				{
					TryInstall(decoSet.HBHMAKNGKFK_Items[i].HAJKNHNAIKL_ItemId, DecorationConstants.Attribute.Type.None);
				}
			}
			m_strBuilder.Set("dc/ch/cmn.xab");
			KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(m_strBuilder.ToString());
			m_strBuilder.Set("dc/sf/9001.xab");
			KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(m_strBuilder.ToString());
			m_strBuilder.Set("dc/sf/9002.xab");
			KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(m_strBuilder.ToString());
			while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
		}

		//// RVA: 0x1ABA404 Offset: 0x1ABA404 VA: 0x1ABA404
		private void TryInstall(int itemId, DecorationConstants.Attribute.Type attr)
		{
			KDKFHGHGFEK data = new KDKFHGHGFEK();
			data.KHEKNNFCAOI(EKLNMHFCAOI.DEACAHNLMNI_getItemId(itemId), EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemId));
			string str = DecorationConstants.GetItemBundleName(data, false, attr);
			if(str != "")
			{
				KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(str);
			}
			str = DecorationConstants.GetThumbnailBundleName(data, attr);
			if(str != "")
			{
				KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(str);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AB1DC Offset: 0x6AB1DC VA: 0x6AB1DC
		//// RVA: 0x1ABA9F4 Offset: 0x1ABA9F4 VA: 0x1ABA9F4
		private IEnumerator Co_LoadBgResource()
		{
			//0x1AC108C
			m_decorationBgManager.LoadResource();
			yield return new WaitUntil(() =>
			{
				//0x1ABFFB8
				return m_decorationBgManager.IsLoded;
			});
			BgSetActive(true);
		}

		//// RVA: 0x1ABAAA0 Offset: 0x1ABAAA0 VA: 0x1ABAAA0
		public void LoadBgResource(int floorId = -1, int wallLId = -1, int wallRId = -1, bool isInit = false)
		{
			m_decorationBgManager.LoadTexutre(new DecorationBgManager.AreaData() { m_floorId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(floorId), m_wallLId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(wallLId), m_wallRId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(wallRId) }, isInit);
		}

		//// RVA: 0x1ABAB90 Offset: 0x1ABAB90 VA: 0x1ABAB90
		//public void ReturnBg() { }

		//// RVA: 0x1AB9C80 Offset: 0x1AB9C80 VA: 0x1AB9C80
		private void SetItemManagerCallback()
		{
			m_decorationItemManager.OnMoveCallback = ItemMoveCallback;
			m_decorationItemManager.OnSelectCallback = ItemSelectCallback;
			m_decorationItemManager.OnLeaveCallback = ItemLeaveCallback;
			m_decorationItemManager.PointerDownCallback = ItemPointerDownCallback;
			m_decorationItemManager.ItemClickCallback = ItemClickCallback;
			m_decorationItemManager.CreateItemCallback = ItemCreateCallback;
			m_decorationItemManager.ChangeKiraCallback = ChangeKiraCallback;
		}

		//// RVA: 0x1ABABBC Offset: 0x1ABABBC VA: 0x1ABABBC
		private void InitController()
		{
			List<DecorationControllerBase.ControlData> l = new List<DecorationControllerBase.ControlData>();
			GameObject g = GameObject.Find(DecorationConstants.ItemRoot);
			l.Add(new DecorationControllerBase.ControlData() { scaler = g.transform.parent.GetComponent<CanvasScaler>(), transform = g.GetComponent<RectTransform>() });
			g = GameObject.Find(DecorationConstants.BgRoot);
			l.Add(new DecorationControllerBase.ControlData() { scaler = g.transform.parent.GetComponent<CanvasScaler>(), transform = g.GetComponent<RectTransform>() });
			m_decorationController.Create(l, m_decorationBgManager, GetComponentInChildren<Camera>(), m_touchDelegate);
			m_decorationItemRoot = transform.Find(DecorationConstants.ItemRoot2 + "SpriteBase").transform;
			m_decorationItemRootRect = m_decorationItemRoot.GetComponent<RectTransform>();
			m_decorationController.SetAcive(true);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AB254 Offset: 0x6AB254 VA: 0x6AB254
		//// RVA: 0x1ABB390 Offset: 0x1ABB390 VA: 0x1ABB390
		private IEnumerator Co_LoadControllerLayout()
		{
			//0x1AC14E4
			DecorationItemControllerLayout deco = transform.Find(DecorationConstants.ItemRoot2 + "ControllerLayout").gameObject.GetComponent<DecorationItemControllerLayout>();
			deco.SetPossibleMaker(transform.Find(DecorationConstants.ItemRoot2 + "PossibleMarker").gameObject);
			deco.LoadResource();
			yield return new WaitUntil(() =>
			{
				//0x1AC0228
				return deco.IsLoadedResource;
			});
			m_decorationItemManager.SetItemControllerLayout(deco);
		}

		//// RVA: 0x1ABB43C Offset: 0x1ABB43C VA: 0x1ABB43C
		public void LoadItemResource(int resourceId, DecorationItemBaseSetting setting, DecorationItemManager.PostType postType, DecorationItemArgsBase args)
		{
			if(args == null)
				args = GenerateArgs(resourceId);
			m_decorationItemManager.LoadItem(resourceId, m_decorationItemRoot.transform, setting, postType, args);
		}

		//// RVA: 0x1ABB684 Offset: 0x1ABB684 VA: 0x1ABB684
		public void LoadedItem()
		{
			m_decorationItemManager.SpriteBase.SetActive(false);
			m_decorationItemManager.Show();
		}

		//// RVA: 0x1ABB854 Offset: 0x1ABB854 VA: 0x1ABB854
		private void ItemCreateCallback(DecorationItemBase item)
		{
			EnableCanvasController(false);
			CreateItemCallback.Invoke(item);
		}

		//// RVA: 0x1ABB910 Offset: 0x1ABB910 VA: 0x1ABB910
		private void ItemSelectCallback(DecorationItemBase item)
		{
			SelectCallback.Invoke(item);
		}

		//// RVA: 0x1ABB990 Offset: 0x1ABB990 VA: 0x1ABB990
		private void ItemLeaveCallback()
		{
			TouchLeaveCallback.Invoke();
		}

		//// RVA: 0x1ABB9BC Offset: 0x1ABB9BC VA: 0x1ABB9BC
		private void ItemPointerDownCallback(DecorationItemBase item)
		{
			PointerDownCallback.Invoke(item);
		}

		//// RVA: 0x1ABBA3C Offset: 0x1ABBA3C VA: 0x1ABBA3C
		private void ItemClickCallback(DecorationItemBase item)
		{
			ClickCallback.Invoke(item);
		}

		//// RVA: 0x1ABBABC Offset: 0x1ABBABC VA: 0x1ABBABC
		private void ItemMoveCallback(DecorationItemBase item)
		{
			Vector2 v = item.Position;
			if(m_decorationBgManager.CheckAdjustPosition(item, ref v))
			{
				item.Position = v;
			}
			DecorationConstants.Attribute.Type attr = m_decorationBgManager.GetAttribute(item, v);
			bool b = m_decorationItemManager.HitCheck(item, item.Position);
			EnablePost(!b);
			item.IsEnablePost = !b;
			item.AutoFlip();
			if(m_hitDelegate != null)
			{
				m_hitDelegate.Invoke(string.Concat(new string[11]
				{
					"", "Item ", item.Position.ToString(), "World ",
					item.GetWorldPosition().ToString(), "ItemAtr ", 
					item.Setting.AttributeType == DecorationConstants.Attribute.Type.BgWallL ? "WALL_L" : 
					(item.Setting.AttributeType == DecorationConstants.Attribute.Type.BgWallR ? "WALL_R" : 
					(item.Setting.AttributeType == DecorationConstants.Attribute.Type.BgFloor ? "FLOOR" : 
					(item.Setting.AttributeType == DecorationConstants.Attribute.Type.BgBoth ? "ALL" : "NONE"))),
					"Adjust ", v.ToString(), "HitAtr ", 
					(attr == DecorationConstants.Attribute.Type.BgWallL ? "WALL_L" :
					(attr == DecorationConstants.Attribute.Type.BgWallR ? "WALL_R" :
					(attr == DecorationConstants.Attribute.Type.BgFloor ? "FLOOR" : 
					(attr == DecorationConstants.Attribute.Type.BgBoth ? "ALL" : "NONE"))))
				}));
			}
		}

		//// RVA: 0x1ABC5B8 Offset: 0x1ABC5B8 VA: 0x1ABC5B8
		private void EnablePost(bool isEnable)
		{
			m_decorationItemManager.EnablePost(isEnable);
			EnablePostCallback(isEnable);
		}

		//// RVA: 0x1ABC854 Offset: 0x1ABC854 VA: 0x1ABC854
		public void SetActive(bool active)
		{
			gameObject.SetActive(active);
		}

		//// RVA: 0x1ABC890 Offset: 0x1ABC890 VA: 0x1ABC890
		public void EnableItemController(DecorationItemManager.EnableControlType type)
		{
			m_decorationItemManager.EnableController(type);
			if(type != DecorationItemManager.EnableControlType.Unique)
				return;
			StartAnimation();
		}

		//// RVA: 0x1ABB8E0 Offset: 0x1ABB8E0 VA: 0x1ABB8E0
		public void EnableCanvasController(bool isEnable)
		{
			m_decorationController.SetAcive(isEnable);
		}

		//// RVA: 0x1ABCC88 Offset: 0x1ABCC88 VA: 0x1ABCC88
		public void StartAnimation()
		{
			m_decorationItemManager.StartAnimation();
		}

		//// RVA: 0x1ABCE08 Offset: 0x1ABCE08 VA: 0x1ABCE08
		//public void StopAnimation() { }

		//// RVA: 0x1ABCF88 Offset: 0x1ABCF88 VA: 0x1ABCF88
		public void TapSetItemClear()
		{
			m_decorationItemManager.TapSetItemClear();
		}

		//// RVA: 0x1ABD028 Offset: 0x1ABD028 VA: 0x1ABD028
		public void UpdateViewDecoItemList()
		{
			KDKFHGHGFEK.FKDIMODKKJD(ref m_viewDecoItemDataList);
		}

		//// RVA: 0x1ABD0B0 Offset: 0x1ABD0B0 VA: 0x1ABD0B0
		//public void GetItemList(DecorationDecorator.DecoratorType type, out List<int> idList, out List<DecorationConstants.Attribute.Type> attrTypeList, out List<int> postIdList) { }

		//// RVA: 0x1ABD8E4 Offset: 0x1ABD8E4 VA: 0x1ABD8E4
		public List<DecorationItemBase> GetItemList()
		{
			List<int> res = new List<int>();
			return m_decorationItemManager.GetItemList(ref res);
		}

		//// RVA: 0x1ABDAE8 Offset: 0x1ABDAE8 VA: 0x1ABDAE8
		//public int GetItemCount() { }

		//// RVA: 0x1ABDC94 Offset: 0x1ABDC94 VA: 0x1ABDC94
		public int GetCanEditItemCount()
		{
			return m_decorationItemManager.GetCanEditItemCount();
		}

		//// RVA: 0x1ABDE20 Offset: 0x1ABDE20 VA: 0x1ABDE20
		public int GetObjectCount()
		{
			return m_decorationItemManager.GetItemCount() - m_decorationItemManager.GetCharaCount();
		}

		//// RVA: 0x1ABDE7C Offset: 0x1ABDE7C VA: 0x1ABDE7C
		public int GetCharaCount()
		{
			return m_decorationItemManager.GetCharaCount();
		}

		//// RVA: 0x1ABE00C Offset: 0x1ABE00C VA: 0x1ABE00C
		public int GetDivaCount()
		{
			return m_decorationItemManager.GetDivaCount();
		}

		//// RVA: 0x1ABE1F4 Offset: 0x1ABE1F4 VA: 0x1ABE1F4
		//public void RemoveEditItem() { }

		//// RVA: 0x1ABE308 Offset: 0x1ABE308 VA: 0x1ABE308
		//public int GetItemPostId(DecorationItemBase item) { }

		//// RVA: 0x1ABE450 Offset: 0x1ABE450 VA: 0x1ABE450
		public void HideLayoutController()
		{
			m_decorationItemManager.HideLayoutController();
		}

		//// RVA: 0x1ABE4A0 Offset: 0x1ABE4A0 VA: 0x1ABE4A0
		public void GetBgResourceId(out int floorId, out int wallLId, out int wallRId)
		{
			floorId = m_decorationBgManager.GetId(DecorationConstants.Attribute.Type.BgFloor);
			wallLId = m_decorationBgManager.GetId(DecorationConstants.Attribute.Type.BgWallL);
			wallRId = m_decorationBgManager.GetId(DecorationConstants.Attribute.Type.BgWallR);
		}

		//// RVA: 0x1ABE534 Offset: 0x1ABE534 VA: 0x1ABE534
		//public bool CanUndoBg() { }

		//// RVA: 0x1ABE560 Offset: 0x1ABE560 VA: 0x1ABE560
		//public void UndoBg(DecorationConstants.Attribute.Type type) { }

		//// RVA: 0x1ABE594 Offset: 0x1ABE594 VA: 0x1ABE594
		public Rect GetFloorRect()
		{
			return m_decorationBgManager.GetFloorRect();
		}

		//// RVA: 0x1ABE5C8 Offset: 0x1ABE5C8 VA: 0x1ABE5C8
		public Rect GetVisibilityRect()
		{
			return m_decorationController.VisibilityRect;
		}

		//// RVA: 0x1ABE608 Offset: 0x1ABE608 VA: 0x1ABE608
		public void GetBgCenterLine(DecorationConstants.Attribute.Type type, ref Vector2[] line)
		{
			m_decorationBgManager.GetCenterLine(type, ref line);
		}

		//// RVA: 0x1ABE644 Offset: 0x1ABE644 VA: 0x1ABE644
		//public void RemoveSelectItem() { }

		//// RVA: 0x1ABE66C Offset: 0x1ABE66C VA: 0x1ABE66C
		public void RemoveItem(DecorationItemBase item)
		{
			m_decorationItemManager.RemoveItem(item);
		}

		//// RVA: 0x1ABE788 Offset: 0x1ABE788 VA: 0x1ABE788
		//public DecorationItemManager.EnableControlType GetItemControlType() { }

		//// RVA: 0x1ABE7B4 Offset: 0x1ABE7B4 VA: 0x1ABE7B4
		public void AutoZoomOut()
		{
			m_decorationController.AutoZoomOut();
		}

		//// RVA: 0x1ABE95C Offset: 0x1ABE95C VA: 0x1ABE95C
		public DecorationItemBase GetEditItem()
		{
			return m_decorationItemManager.GetEditItem();
		}

		//// RVA: 0x1ABE988 Offset: 0x1ABE988 VA: 0x1ABE988
		public void EnablePostArea(DecorationConstants.Attribute.Type type)
		{
			m_decorationBgManager.SetEnablePostArea(type);
		}

		//// RVA: 0x1ABE9BC Offset: 0x1ABE9BC VA: 0x1ABE9BC
		public void DisablePostArea()
		{
			m_decorationBgManager.SetEnablePostArea(DecorationConstants.Attribute.Type.None);
		}

		//[ConditionalAttribute] // RVA: 0x6AB2CC Offset: 0x6AB2CC VA: 0x6AB2CC
		//// RVA: 0x1ABE9EC Offset: 0x1ABE9EC VA: 0x1ABE9EC
		//public void dbg_GetCharaList(Action<List<DecorationItemBase>> rcv) { }

		//// RVA: 0x1ABEAC8 Offset: 0x1ABEAC8 VA: 0x1ABEAC8
		//public bool IsEdit() { }

		//// RVA: 0x1ABEB7C Offset: 0x1ABEB7C VA: 0x1ABEB7C
		//public void RemoveAllItem() { }

		//// RVA: 0x1ABECEC Offset: 0x1ABECEC VA: 0x1ABECEC
		public void HideSelectItemLayout()
		{
			HideLayoutController();
			DisablePostArea();
		}

		//// RVA: 0x1ABED08 Offset: 0x1ABED08 VA: 0x1ABED08
		public void EditItem(DecorationItemBase item)
		{
			m_decorationItemManager.EditItem(item, m_decorationController.scrollController);
			EnablePostArea(item.Setting.AttributeType);
		}

		//// RVA: 0x1ABEE84 Offset: 0x1ABEE84 VA: 0x1ABEE84
		public void RestoreEditItem()
		{
			m_decorationItemManager.RestroreEditItem();
		}

		//// RVA: 0x1ABF0BC Offset: 0x1ABF0BC VA: 0x1ABF0BC
		public void CanvasFollowTouch(bool isEnable)
		{
			m_decorationController.scrollController.IsFollowTouch = isEnable;
		}

		//// RVA: 0x1ABF104 Offset: 0x1ABF104 VA: 0x1ABF104
		public int InitSortOrder(DecorationItemBaseSetting.PriorityControlType priorityControlType)
		{
			return m_decorationItemManager.InitSortingOrder(priorityControlType);
		}

		//// RVA: 0x1ABF1C4 Offset: 0x1ABF1C4 VA: 0x1ABF1C4
		public bool IsItemTouch()
		{
			return m_decorationItemManager.IsItemTouch();
		}

		//// RVA: 0x1ABF358 Offset: 0x1ABF358 VA: 0x1ABF358
		public void WaitingChara(bool isWait)
		{
			m_decorationItemManager.WaitingChara(isWait);
		}

		//// RVA: 0x1ABF388 Offset: 0x1ABF388 VA: 0x1ABF388
		public void SetEnableIntimacyCounter(bool isEnable)
		{
			if(m_intimacyController != null)
			{
				m_intimacyController.SetEnableDecoCounter(isEnable && GetDivaCount() > 0, false);
			}
		}

		//// RVA: 0x1ABF478 Offset: 0x1ABF478 VA: 0x1ABF478
		//public void ClearSprite() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AB320 Offset: 0x6AB320 VA: 0x6AB320
		//// RVA: 0x1ABF4A8 Offset: 0x1ABF4A8 VA: 0x1ABF4A8
		private IEnumerator Co_ClearSprite()
		{
			//0x1AC0258
			m_decorationItemManager.Clear();
			yield return new WaitWhile(() =>
			{
				//0x1ABFFE4
				return m_decorationItemManager.IsClearing();
			});
			IsClearedSprite = true;
		}

		//// RVA: 0x1ABF554 Offset: 0x1ABF554 VA: 0x1ABF554
		public RectTransform GetItemRootRectTransform()
		{
			return m_decorationItemRootRect;
		}

		//// RVA: 0x1ABF55C Offset: 0x1ABF55C VA: 0x1ABF55C
		public void BgSetActive(bool active)
		{
			m_decorationBgManager.SetActive(active);
		}

		//// RVA: 0x1ABF590 Offset: 0x1ABF590 VA: 0x1ABF590
		public void MakeVisitItem(out int resourceId, out DecorationItemBaseSetting setting)
		{
			resourceId = 0;
			setting = null;
			Rect r = GetFloorRect();
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
			{
                NDBFKHKMMCE_DecoItem.FIDBAFHNGCF item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMONECJCJFK_Sp.Find((NDBFKHKMMCE_DecoItem.FIDBAFHNGCF p) =>
				{
					//0x1AC008C
					return p.GBJFNGCDKPM_SpType == 11;
				});
				if(item != null)
				{
					setting = new DecorationItemBaseSetting(item);
					setting.PriorityControl = DecorationItemBaseSetting.PriorityControlType.Front;
					setting.IsOverlay = true;
					setting.InitPosition = r.center;
					setting.InitOrder = InitSortOrder(setting.PriorityControl);
					resourceId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp, item.PPFNGGCBJKC_Id);
				}
            }
		}

		//// RVA: 0x1ABFA9C Offset: 0x1ABFA9C VA: 0x1ABFA9C
		public void ItemLock()
		{
			m_decorationItemManager.Lock();
		}

		//// RVA: 0x1ABFC1C Offset: 0x1ABFC1C VA: 0x1ABFC1C
		public void ItemUnLock()
		{
			m_decorationItemManager.UnLock();
		}
	}
}
