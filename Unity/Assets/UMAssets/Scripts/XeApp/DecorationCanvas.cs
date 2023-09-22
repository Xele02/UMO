using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Menu;

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
		//public DecorationContoller.touchDelegate m_touchDelegate; // 0x38
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
		//public Material PosterKiraMaterial { get; } 0x1AB8A54
		//public Material PosterKiraMaterialFlip { get; } 0x1AB8A5C
		public IntimacyController m_intimacyController { get; private set; } // 0x44
		//public Action<DecorationItemBase> OnClickSerifButton { set; } 0x1AB8A74
		//public Action OnClickPriorityButton { set; } 0x1AB8A9C
		//public Action OnClickFlipButton { set; } 0x1AB8AC4
		//public List<KDKFHGHGFEK> ViewDecoItemDataList { get; } 0x1AB8AEC
		public bool IsReadyCanvas { get; private set; } // 0x68
		public bool IsLoaded { get; private set; } // 0x69
		public bool IsLoadedDecoration { get; private set; } // 0x6A
		//public bool IsLoadedBgDecoration { get; } 0x1AB8B24
		//public bool IsLoadedItemDecoration { get; } 0x1AB8B50
		public bool IsLoadedItem { get; private set; } // 0x6B
		public bool IsClearedSprite { get; private set; } // 0x70

		// RVA: 0x1AB8B8C Offset: 0x1AB8B8C VA: 0x1AB8B8C
		private void Awake()
		{
			m_decoCanvasCamera = GetComponentInChildren<Camera>(true);
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
		//public int GetHaveDecorationItemCount() { }

		//// RVA: 0x1AB8F80 Offset: 0x1AB8F80 VA: 0x1AB8F80
		//public KDKFHGHGFEK FindViewDecoItemData(Predicate<KDKFHGHGFEK> comparer) { }

		//// RVA: 0x1AB9000 Offset: 0x1AB9000 VA: 0x1AB9000
		//public void LoadResource() { }

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
		//private IEnumerator Co_LoadData() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AAE94 Offset: 0x6AAE94 VA: 0x6AAE94
		//// RVA: 0x1AB9408 Offset: 0x1AB9408 VA: 0x1AB9408
		//private IEnumerator Co_LoadCanvas() { }

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
		//public void SetActiveBgEffect(bool isActive) { }

		//// RVA: 0x1AB96C8 Offset: 0x1AB96C8 VA: 0x1AB96C8
		private void PopupFirstBgEffectSetting(ViewDecoBgEffect view, Action<PopupButton.ButtonLabel> callback)
		{
			TodoLogger.LogError(0, "PopupFirstBgEffectSetting");
			if (callback != null)
				callback(PopupButton.ButtonLabel.Ok);
		}

		//// RVA: 0x1AB9BF4 Offset: 0x1AB9BF4 VA: 0x1AB9BF4
		//private void InitItemManager() { }

		//// RVA: 0x1AB9F04 Offset: 0x1AB9F04 VA: 0x1AB9F04
		//public void LoadDecoration(DAJBODHMLAB.MMLACIFMNBN decoSet) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AAFFC Offset: 0x6AAFFC VA: 0x6AAFFC
		//// RVA: 0x1AB9F34 Offset: 0x1AB9F34 VA: 0x1AB9F34
		//public IEnumerator Co_LoadDecoration(DAJBODHMLAB.MMLACIFMNBN decoSet) { }

		//// RVA: 0x1AB9FFC Offset: 0x1AB9FFC VA: 0x1AB9FFC
		//public void LoadItem(DAJBODHMLAB.MMLACIFMNBN.MHODOAJPNHD item) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AB074 Offset: 0x6AB074 VA: 0x6AB074
		//// RVA: 0x1ABA02C Offset: 0x1ABA02C VA: 0x1ABA02C
		//private IEnumerator Co_LoadItem(DAJBODHMLAB.MMLACIFMNBN.MHODOAJPNHD item) { }

		//// RVA: 0x1ABA0F4 Offset: 0x1ABA0F4 VA: 0x1ABA0F4
		//public void LoadDecorationSerif() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AB0EC Offset: 0x6AB0EC VA: 0x6AB0EC
		//// RVA: 0x1ABA118 Offset: 0x1ABA118 VA: 0x1ABA118
		//private IEnumerator Co_LoadDecorationSerif() { }

		//// RVA: 0x1ABA1C4 Offset: 0x1ABA1C4 VA: 0x1ABA1C4
		//private DecorationItemArgsBase GenerateArgs(int resourceId) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AB164 Offset: 0x6AB164 VA: 0x6AB164
		//// RVA: 0x1ABA33C Offset: 0x1ABA33C VA: 0x1ABA33C
		//private IEnumerator Co_TryInstall(DAJBODHMLAB.MMLACIFMNBN decoSet) { }

		//// RVA: 0x1ABA404 Offset: 0x1ABA404 VA: 0x1ABA404
		//private void TryInstall(int itemId, DecorationConstants.Attribute.Type attr) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AB1DC Offset: 0x6AB1DC VA: 0x6AB1DC
		//// RVA: 0x1ABA9F4 Offset: 0x1ABA9F4 VA: 0x1ABA9F4
		//private IEnumerator Co_LoadBgResource() { }

		//// RVA: 0x1ABAAA0 Offset: 0x1ABAAA0 VA: 0x1ABAAA0
		//public void LoadBgResource(int floorId = -1, int wallLId = -1, int wallRId = -1, bool isInit = False) { }

		//// RVA: 0x1ABAB90 Offset: 0x1ABAB90 VA: 0x1ABAB90
		//public void ReturnBg() { }

		//// RVA: 0x1AB9C80 Offset: 0x1AB9C80 VA: 0x1AB9C80
		//private void SetItemManagerCallback() { }

		//// RVA: 0x1ABABBC Offset: 0x1ABABBC VA: 0x1ABABBC
		//private void InitController() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AB254 Offset: 0x6AB254 VA: 0x6AB254
		//// RVA: 0x1ABB390 Offset: 0x1ABB390 VA: 0x1ABB390
		//private IEnumerator Co_LoadControllerLayout() { }

		//// RVA: 0x1ABB43C Offset: 0x1ABB43C VA: 0x1ABB43C
		//public void LoadItemResource(int resourceId, DecorationItemBaseSetting setting, DecorationItemManager.PostType postType, DecorationItemArgsBase args) { }

		//// RVA: 0x1ABB684 Offset: 0x1ABB684 VA: 0x1ABB684
		//public void LoadedItem() { }

		//// RVA: 0x1ABB854 Offset: 0x1ABB854 VA: 0x1ABB854
		//private void ItemCreateCallback(DecorationItemBase item) { }

		//// RVA: 0x1ABB910 Offset: 0x1ABB910 VA: 0x1ABB910
		//private void ItemSelectCallback(DecorationItemBase item) { }

		//// RVA: 0x1ABB990 Offset: 0x1ABB990 VA: 0x1ABB990
		//private void ItemLeaveCallback() { }

		//// RVA: 0x1ABB9BC Offset: 0x1ABB9BC VA: 0x1ABB9BC
		//private void ItemPointerDownCallback(DecorationItemBase item) { }

		//// RVA: 0x1ABBA3C Offset: 0x1ABBA3C VA: 0x1ABBA3C
		//private void ItemClickCallback(DecorationItemBase item) { }

		//// RVA: 0x1ABBABC Offset: 0x1ABBABC VA: 0x1ABBABC
		//private void ItemMoveCallback(DecorationItemBase item) { }

		//// RVA: 0x1ABC5B8 Offset: 0x1ABC5B8 VA: 0x1ABC5B8
		//private void EnablePost(bool isEnable) { }

		//// RVA: 0x1ABC854 Offset: 0x1ABC854 VA: 0x1ABC854
		public void SetActive(bool active)
		{
			gameObject.SetActive(active);
		}

		//// RVA: 0x1ABC890 Offset: 0x1ABC890 VA: 0x1ABC890
		//public void EnableItemController(DecorationItemManager.EnableControlType type) { }

		//// RVA: 0x1ABB8E0 Offset: 0x1ABB8E0 VA: 0x1ABB8E0
		//public void EnableCanvasController(bool isEnable) { }

		//// RVA: 0x1ABCC88 Offset: 0x1ABCC88 VA: 0x1ABCC88
		public void StartAnimation()
		{
			m_decorationItemManager.StartAnimation();
		}

		//// RVA: 0x1ABCE08 Offset: 0x1ABCE08 VA: 0x1ABCE08
		//public void StopAnimation() { }

		//// RVA: 0x1ABCF88 Offset: 0x1ABCF88 VA: 0x1ABCF88
		//public void TapSetItemClear() { }

		//// RVA: 0x1ABD028 Offset: 0x1ABD028 VA: 0x1ABD028
		//public void UpdateViewDecoItemList() { }

		//// RVA: 0x1ABD0B0 Offset: 0x1ABD0B0 VA: 0x1ABD0B0
		//public void GetItemList(DecorationDecorator.DecoratorType type, out List<int> idList, out List<DecorationConstants.Attribute.Type> attrTypeList, out List<int> postIdList) { }

		//// RVA: 0x1ABD8E4 Offset: 0x1ABD8E4 VA: 0x1ABD8E4
		//public List<DecorationItemBase> GetItemList() { }

		//// RVA: 0x1ABDAE8 Offset: 0x1ABDAE8 VA: 0x1ABDAE8
		//public int GetItemCount() { }

		//// RVA: 0x1ABDC94 Offset: 0x1ABDC94 VA: 0x1ABDC94
		//public int GetCanEditItemCount() { }

		//// RVA: 0x1ABDE20 Offset: 0x1ABDE20 VA: 0x1ABDE20
		//public int GetObjectCount() { }

		//// RVA: 0x1ABDE7C Offset: 0x1ABDE7C VA: 0x1ABDE7C
		//public int GetCharaCount() { }

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
		//public void HideLayoutController() { }

		//// RVA: 0x1ABE4A0 Offset: 0x1ABE4A0 VA: 0x1ABE4A0
		//public void GetBgResourceId(out int floorId, out int wallLId, out int wallRId) { }

		//// RVA: 0x1ABE534 Offset: 0x1ABE534 VA: 0x1ABE534
		//public bool CanUndoBg() { }

		//// RVA: 0x1ABE560 Offset: 0x1ABE560 VA: 0x1ABE560
		//public void UndoBg(DecorationConstants.Attribute.Type type) { }

		//// RVA: 0x1ABE594 Offset: 0x1ABE594 VA: 0x1ABE594
		//public Rect GetFloorRect() { }

		//// RVA: 0x1ABE5C8 Offset: 0x1ABE5C8 VA: 0x1ABE5C8
		//public Rect GetVisibilityRect() { }

		//// RVA: 0x1ABE608 Offset: 0x1ABE608 VA: 0x1ABE608
		//public void GetBgCenterLine(DecorationConstants.Attribute.Type type, ref Vector2[] line) { }

		//// RVA: 0x1ABE644 Offset: 0x1ABE644 VA: 0x1ABE644
		//public void RemoveSelectItem() { }

		//// RVA: 0x1ABE66C Offset: 0x1ABE66C VA: 0x1ABE66C
		//public void RemoveItem(DecorationItemBase item) { }

		//// RVA: 0x1ABE788 Offset: 0x1ABE788 VA: 0x1ABE788
		//public DecorationItemManager.EnableControlType GetItemControlType() { }

		//// RVA: 0x1ABE7B4 Offset: 0x1ABE7B4 VA: 0x1ABE7B4
		//public void AutoZoomOut() { }

		//// RVA: 0x1ABE95C Offset: 0x1ABE95C VA: 0x1ABE95C
		//public DecorationItemBase GetEditItem() { }

		//// RVA: 0x1ABE988 Offset: 0x1ABE988 VA: 0x1ABE988
		//public void EnablePostArea(DecorationConstants.Attribute.Type type) { }

		//// RVA: 0x1ABE9BC Offset: 0x1ABE9BC VA: 0x1ABE9BC
		//public void DisablePostArea() { }

		//[ConditionalAttribute] // RVA: 0x6AB2CC Offset: 0x6AB2CC VA: 0x6AB2CC
		//// RVA: 0x1ABE9EC Offset: 0x1ABE9EC VA: 0x1ABE9EC
		//public void dbg_GetCharaList(Action<List<DecorationItemBase>> rcv) { }

		//// RVA: 0x1ABEAC8 Offset: 0x1ABEAC8 VA: 0x1ABEAC8
		//public bool IsEdit() { }

		//// RVA: 0x1ABEB7C Offset: 0x1ABEB7C VA: 0x1ABEB7C
		//public void RemoveAllItem() { }

		//// RVA: 0x1ABECEC Offset: 0x1ABECEC VA: 0x1ABECEC
		//public void HideSelectItemLayout() { }

		//// RVA: 0x1ABED08 Offset: 0x1ABED08 VA: 0x1ABED08
		//public void EditItem(DecorationItemBase item) { }

		//// RVA: 0x1ABEE84 Offset: 0x1ABEE84 VA: 0x1ABEE84
		//public void RestoreEditItem() { }

		//// RVA: 0x1ABF0BC Offset: 0x1ABF0BC VA: 0x1ABF0BC
		//public void CanvasFollowTouch(bool isEnable) { }

		//// RVA: 0x1ABF104 Offset: 0x1ABF104 VA: 0x1ABF104
		//public int InitSortOrder(DecorationItemBaseSetting.PriorityControlType priorityControlType) { }

		//// RVA: 0x1ABF1C4 Offset: 0x1ABF1C4 VA: 0x1ABF1C4
		public bool IsItemTouch()
		{
			return m_decorationItemManager.IsItemTouch();
		}

		//// RVA: 0x1ABF358 Offset: 0x1ABF358 VA: 0x1ABF358
		//public void WaitingChara(bool isWait) { }

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
		//private IEnumerator Co_ClearSprite() { }

		//// RVA: 0x1ABF554 Offset: 0x1ABF554 VA: 0x1ABF554
		public RectTransform GetItemRootRectTransform()
		{
			return m_decorationItemRootRect;
		}

		//// RVA: 0x1ABF55C Offset: 0x1ABF55C VA: 0x1ABF55C
		//public void BgSetActive(bool active) { }

		//// RVA: 0x1ABF590 Offset: 0x1ABF590 VA: 0x1ABF590
		//public void MakeVisitItem(out int resourceId, out DecorationItemBaseSetting setting) { }

		//// RVA: 0x1ABFA9C Offset: 0x1ABFA9C VA: 0x1ABFA9C
		//public void ItemLock() { }

		//// RVA: 0x1ABFC1C Offset: 0x1ABFC1C VA: 0x1ABFC1C
		//public void ItemUnLock() { }
		
		//[CompilerGeneratedAttribute] // RVA: 0x6AB3A8 Offset: 0x6AB3A8 VA: 0x6AB3A8
		//// RVA: 0x1ABFF64 Offset: 0x1ABFF64 VA: 0x1ABFF64
		//private bool <Co_LoadDecoration>b__81_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6AB3B8 Offset: 0x6AB3B8 VA: 0x6AB3B8
		//// RVA: 0x1ABFF68 Offset: 0x1ABFF68 VA: 0x1ABFF68
		//private bool <Co_LoadDecoration>b__81_1() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6AB3C8 Offset: 0x6AB3C8 VA: 0x6AB3C8
		//// RVA: 0x1ABFF70 Offset: 0x1ABFF70 VA: 0x1ABFF70
		//private bool <Co_LoadItem>b__83_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6AB3D8 Offset: 0x6AB3D8 VA: 0x6AB3D8
		//// RVA: 0x1ABFF94 Offset: 0x1ABFF94 VA: 0x1ABFF94
		//private bool <Co_LoadDecorationSerif>b__85_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6AB3E8 Offset: 0x6AB3E8 VA: 0x6AB3E8
		//// RVA: 0x1ABFFB8 Offset: 0x1ABFFB8 VA: 0x1ABFFB8
		//private bool <Co_LoadBgResource>b__89_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6AB3F8 Offset: 0x6AB3F8 VA: 0x6AB3F8
		//// RVA: 0x1ABFFE4 Offset: 0x1ABFFE4 VA: 0x1ABFFE4
		//private bool <Co_ClearSprite>b__150_0() { }
	}
}
