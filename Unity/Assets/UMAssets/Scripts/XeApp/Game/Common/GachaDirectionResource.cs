using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Gacha;
using XeApp.Game.Menu;
using XeSys;

namespace XeApp.Game.Common
{
	public class GachaDirectionResource : MonoBehaviour
	{
		private SceneCardTextureCache m_sceneCardCache; // 0x14
		private SceneFrameTextureCache m_sceneFrameCache; // 0x18

		private StringBuilder bundleName { get; set; } // 0xC
		private StringBuilder assetName { get; set; } // 0x10
		public bool isLoading { get {
				return isMainLoading || isDelayLoading;
			} } //0x1C1EA98
		public GameObject startSetPrefab { get; private set; } // 0x1C
		public GameObject trailSetPrefab { get; private set; } // 0x20
		public GameObject quartzSetPrefab { get; private set; } // 0x24
		public GameObject cutinSetPrefab { get; private set; } // 0x28
		public List<GameObject> commonRareSetPrefab { get; private set; } // 0x2C
		public GameObject cardSetPrefab { get; private set; } // 0x30
		public GameObject stonePrefab { get; private set; } // 0x34
		public GameObject cardNamePrefab { get; private set; } // 0x38
		public GameObject cardFramePrefab { get; private set; } // 0x3C
		public RuntimeAnimatorController cameraAnimator { get; private set; } // 0x40
		public GameObject mainHudPrefab { get; private set; } // 0x44
		public GameObject resultUiPrefab { get; private set; } // 0x48
		public GameObject resultButtonUiPrefab { get; private set; } // 0x4C
		public GameObject userInfoUiPrefab { get; private set; } // 0x50
		public List<IiconTexture> resultCardTex { get; private set; } // 0x54
		public List<IiconTexture> resultCardFrameTex { get; private set; } // 0x58
		public bool isLoadedStartSet { get; private set; } // 0x5C
		public bool isLoadedTrailSet { get; private set; } // 0x5D
		public bool isLoadedQuartzSet { get; private set; } // 0x5E
		public bool isLoadedCutinSet { get; private set; } // 0x5F
		public bool isLoadedRareSet { get; private set; } // 0x60
		public bool isLoadedCardSet { get; private set; } // 0x61
		public bool isLoadedStone { get; private set; } // 0x62
		public bool isLoadedCardName { get; private set; } // 0x63
		public bool isLoadedCardFrame { get; private set; } // 0x64
		public bool isLoadedCameraAnimator { get; private set; } // 0x65
		public bool isLoadedMainHud { get; private set; } // 0x66
		public bool isLoadedResultUi { get; private set; } // 0x67
		public bool isLoadedResultButtonUi { get; private set; } // 0x68
		public bool isLoadedCardTex { get; private set; } // 0x69
		public bool isLoadedUserInfoUi { get; private set; } // 0x6A
		private bool isMainLoading { get; set; } // 0x6B
		public bool isAllLoaded { get
		{
			return isLoadedStartSet && isLoadedTrailSet && 
				isLoadedQuartzSet && isLoadedCutinSet && 
				isLoadedRareSet && isLoadedCardSet && 
				isLoadedStone && isLoadedCardName && 
				isLoadedCardFrame && isLoadedCameraAnimator && 
				isLoadedMainHud && isLoadedResultUi && 
				isLoadedResultButtonUi && isLoadedUserInfoUi && 
				isLoadedCardTex;
		} } //0x1C1EEE4
		private bool isDelayLoading { get; set; } // 0x6C
		public bool isDelayLoaded { get; private set; } // 0x6D
		public Material cardMaterial { get; private set; } // 0x70
		public Texture2D cardTexture { get; private set; } // 0x74
		public GameObject rareSetPrefab { get; private set; } // 0x78

		// RVA: 0x1C1EACC Offset: 0x1C1EACC VA: 0x1C1EACC
		private void Awake()
		{
			bundleName = new StringBuilder();
			assetName = new StringBuilder();
			m_sceneCardCache = new SceneCardTextureCache();
			m_sceneFrameCache = new SceneFrameTextureCache();
		}

		// RVA: 0x1C1EBA8 Offset: 0x1C1EBA8 VA: 0x1C1EBA8
		private void Update()
		{
			m_sceneCardCache.Update();
			m_sceneFrameCache.Update();
		}

		// RVA: 0x1C1EBF8 Offset: 0x1C1EBF8 VA: 0x1C1EBF8
		public void OnDestroy()
		{
			mainHudPrefab = null;
			resultUiPrefab = null;
			resultButtonUiPrefab = null;

			cutinSetPrefab = null;
			commonRareSetPrefab = null;
			cardSetPrefab = null;
			stonePrefab = null;
			startSetPrefab = null;
			trailSetPrefab = null;
			quartzSetPrefab = null;
			cutinSetPrefab = null;

			resultCardFrameTex.Clear();
			m_sceneCardCache.Terminated();
			m_sceneFrameCache.Terminated();
			isDelayLoaded = false;
			cardMaterial = null;
			cardTexture = null;
			rareSetPrefab = null;

			resultCardTex.Clear();
		}

		// RVA: 0x1C1EF88 Offset: 0x1C1EF88 VA: 0x1C1EF88
		public void LoadResources(DirectionInfo directionInfo, bool retryTime = false)
		{
			isMainLoading = true;
			if(retryTime)
			{
				isLoadedResultUi = false;
				Destroy(resultUiPrefab);
				resultUiPrefab = null;
				this.StartCoroutineWatched(Co_LoadRetryResources(directionInfo));
			}
			else
			{
				isLoadedCameraAnimator = false;
				isLoadedMainHud = false;
				isLoadedResultUi = false;
				isLoadedResultButtonUi = false;

				isLoadedCardSet = false;
				isLoadedStone = false;
				isLoadedCardName = false;
				isLoadedCardFrame = false;

				isLoadedStartSet = false;
				isLoadedTrailSet = false;
				isLoadedQuartzSet = false;
				isLoadedCutinSet = false;

				isLoadedRareSet = false;
				isLoadedCardSet = false;
				isLoadedStone = false;
				isLoadedCardName = false;

				isLoadedUserInfoUi = false;
				this.StartCoroutineWatched(Co_LoadResources(directionInfo));
			}
		}

		//// RVA: 0x1C1F1C8 Offset: 0x1C1F1C8 VA: 0x1C1F1C8
		//private void LoadCardResources(DirectionInfo directionInfo) { }

		//[IteratorStateMachineAttribute] // RVA: 0x738CD0 Offset: 0x738CD0 VA: 0x738CD0
		//// RVA: 0x1C1F120 Offset: 0x1C1F120 VA: 0x1C1F120
		private IEnumerator Co_LoadResources(DirectionInfo directionInfo)
		{
			int bundleLoadCount; // 0x1C
			XeSys.FontInfo font; // 0x20
			AssetBundleLoadLayoutOperationBase lytOperation; // 0x24

			//0x1C210D8
			bool isEndedChangeCueSheet = false;
			SoundManager.Instance.voDiva.RequestChangeCueSheet(directionInfo.divaId, () =>
			{
				//0x1C1FCBC
				isEndedChangeCueSheet = true;
			});
			while (!isEndedChangeCueSheet)
				yield return null;
			bundleName.Set("gc/cmn.xab");
			AssetBundleLoadAllAssetOperationBase operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;
			assetName.Set(directionInfo.isPaid ? "gc_cmn_start_set_accounting_prefab" : "gc_cmn_start_set_prefab");
			startSetPrefab = operation.GetAsset<GameObject>(assetName.ToString());
			isLoadedStartSet = true;
			assetName.Set("gacha_valkyrie_set_prefab");
			trailSetPrefab = operation.GetAsset<GameObject>(assetName.ToString());
			isLoadedTrailSet = true;
			assetName.Set("gc_cmn_quartz_set_prefab");
			quartzSetPrefab = operation.GetAsset<GameObject>(assetName.ToString());
			isLoadedQuartzSet = true;
			assetName.Set("gacha_quartz_cutin_set_prefab");
			cutinSetPrefab = operation.GetAsset<GameObject>(assetName.ToString());
			isLoadedCutinSet = true;
			commonRareSetPrefab = new List<GameObject>();
			assetName.Set("gc_cmn_rare_set_prefab");
			commonRareSetPrefab.Add(operation.GetAsset<GameObject>(assetName.ToString()));
			assetName.Set("gc_cmn_rare_set_S6_prefab");
			commonRareSetPrefab.Add(operation.GetAsset<GameObject>(assetName.ToString()));
			isLoadedRareSet = true;
			assetName.Set("gc_cmn_card_set_prefab");
			cardSetPrefab = operation.GetAsset<GameObject>(assetName.ToString());
			isLoadedCardSet = true;
			assetName.Set("gc_cmn_stone_prefab");
			stonePrefab = operation.GetAsset<GameObject>(assetName.ToString());
			isLoadedStone = true;
			assetName.Set("gc_cmn_card_name_prefab");
			cardNamePrefab = operation.GetAsset<GameObject>(assetName.ToString());
			isLoadedCardName = true;
			assetName.Set("gc_cmn_frame_set_prefab");
			cardFramePrefab = operation.GetAsset<GameObject>(assetName.ToString());
			isLoadedCardFrame = true;
			assetName.Set("cam_animator");
			cameraAnimator = operation.GetAsset<RuntimeAnimatorController>(assetName.ToString());
			isLoadedCameraAnimator = true;
			List<GachaDirectionEffectFactory> l = new List<GachaDirectionEffectFactory>();
			l.Add(startSetPrefab.GetComponent<GachaDirectionEffectFactory>());
			l.Add(quartzSetPrefab.GetComponent<GachaDirectionEffectFactory>());
			for(int i = 0; i < commonRareSetPrefab.Count; i++)
			{
				l.Add(commonRareSetPrefab[i].GetComponent<GachaDirectionEffectFactory>());
			}
			l.Add(cardSetPrefab.GetComponent<GachaDirectionEffectFactory>());
			l.RemoveAll((GachaDirectionEffectFactory elem) =>
			{
				//0x1C1FC2C
				return elem == null;
			});
			for (int i = 0; i < l.Count; i++)
			{
				l[i].Redirection((string name) =>
				{
					//0x1C1FCC8
					return operation.GetAsset<GameObject>(name);
				});
			}
			assetName.Set("gc_cmn_hud_prefab");
			mainHudPrefab = operation.GetAsset<GameObject>(assetName.ToString());
			isLoadedMainHud = true;
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			bundleLoadCount = 0;
			font = GameManager.Instance.GetSystemFont();
			bundleName.Set("ly/037.xab");
			assetName.Set(directionInfo.cardNum == 1 ? "UI_GachaResultOnce" : "UI_GachaResult");
			lytOperation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), assetName.ToString());
			yield return lytOperation;
			yield return Co.R(lytOperation.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0x1C1FD64
				resultUiPrefab = instance;
			}));
			bundleLoadCount++;
			yield return null;
			isLoadedResultUi = true;
			assetName.Set("UI_GachaResultButtonSet");
			lytOperation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), assetName.ToString());
			yield return lytOperation;
			yield return Co.R(lytOperation.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0x1C1FD8C
				resultButtonUiPrefab = instance;
			}));
			bundleLoadCount++;
			yield return null;
			isLoadedResultButtonUi = true;
			for(int i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
			bundleName.Set("ly/004.xab");
			assetName.Set("UI_MenuTop");
			lytOperation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), assetName.ToString());
			yield return lytOperation;
			yield return Co.R(lytOperation.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0x1C1FDB4
				userInfoUiPrefab = instance;
			}));
			yield return null;
			isLoadedUserInfoUi = true;
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			isLoadedCardTex = false;
			this.StartCoroutineWatched(Co_LoadCardResources(directionInfo));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x738D48 Offset: 0x738D48 VA: 0x738D48
		//// RVA: 0x1C1F078 Offset: 0x1C1F078 VA: 0x1C1F078
		private IEnumerator Co_LoadRetryResources(DirectionInfo directionInfo)
		{
			int bundleLoadCount; // 0x18
			XeSys.FontInfo font; // 0x1C
			AssetBundleLoadLayoutOperationBase lytOperation; // 0x20

			//0x1C2292C
			bundleLoadCount = 0;
			font = GameManager.Instance.GetSystemFont();
			bundleName.Set("ly/037.xab");
			assetName.Set(directionInfo.cardNum == 1 ? "UI_GachaResultOnce" : "UI_GachaResult");
			lytOperation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), assetName.ToString());
			yield return lytOperation;
			yield return Co.R(lytOperation.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0x1C1F740
				resultUiPrefab = instance;
			}));
			bundleLoadCount++;
			yield return null;
			isLoadedResultUi = true;
			for(int i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
			isLoadedCardTex = false;
			this.StartCoroutineWatched(Co_LoadCardResources(directionInfo));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x738DC0 Offset: 0x738DC0 VA: 0x738DC0
		//// RVA: 0x1C1F1F8 Offset: 0x1C1F1F8 VA: 0x1C1F1F8
		private IEnumerator Co_LoadCardResources(DirectionInfo directionInfo)
		{
			bool isOnce; // 0x18
			SceneIconTextureCache sceneIconCache; // 0x1C
			CardInfo cardInfo; // 0x20
			int i; // 0x24

			//0x1C202F8
			isOnce = directionInfo.cardNum == 1;
			yield return Co.R(m_sceneCardCache.Initialize(isOnce));
			sceneIconCache = GameManager.Instance.SceneIconCache;
			if(resultCardTex == null)
			{
				resultCardTex = new List<IiconTexture>(directionInfo.cardNum);
			}
			if(resultCardFrameTex == null)
			{
				resultCardFrameTex = new List<IiconTexture>(directionInfo.cardNum);
			}
			resultCardTex.Clear();
			resultCardFrameTex.Clear();
			yield return Co.R(Co_InstallCardResources(directionInfo));
			if(isOnce)
			{
				cardInfo = directionInfo.GetCardInfo(0);
				m_sceneCardCache.Load(cardInfo.cardId, 1, (IiconTexture icon) =>
				{
					//0x1C1F748
					resultCardTex.Add(icon);
				});
				//LAB_01c20694
				while (m_sceneCardCache.IsLoading())
					yield return null;
				m_sceneFrameCache.Load((GameAttribute.Type)cardInfo.attrId, cardInfo.starNum, 1, (IiconTexture icon) =>
				{
					//0x1C1F7C8
					resultCardFrameTex.Add(icon);
				});
				while (m_sceneFrameCache.IsLoading())
					yield return null;
			}
			else
			{
				for(i = 0; i < directionInfo.cardNum; i++)
				{
					sceneIconCache.Load(directionInfo.GetCardInfo(i).cardId, 1, (IiconTexture icon) =>
					{
						//0x1C1F848
						resultCardTex.Add(icon);
					});
					while (sceneIconCache.IsLoading())
						yield return null;
					resultCardFrameTex.Add(null);
				}
			}
			//LAB_01c2095c
			isLoadedCardTex = true;
			isMainLoading = false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x738E38 Offset: 0x738E38 VA: 0x738E38
		//// RVA: 0x1C1F300 Offset: 0x1C1F300 VA: 0x1C1F300
		private IEnumerator Co_InstallCardResources(DirectionInfo directionInfo)
		{
			//0x1C1FDE0
			bool b3 = false;
			for(int i = 0; i < directionInfo.cardNum; i++)
			{
				CardInfo info = directionInfo.GetCardInfo(i);
				bundleName.SetFormat("ct/sc/me/01/{0:D6}_{1:D2}.xab", info.cardId, 1);
				bool b1 = TryInstall(bundleName);
				bundleName.SetFormat("ct/sc/me/02/{0:D6}_{1:D2}.xab", info.cardId, 1);
				bool b2 = TryInstall(bundleName);
				b3 |= b1 | b2;
				if(info.hasSpAnim)
				{
					if(info.spAnimId > -1)
					{
						bundleName.SetFormat("gc/{0:D6}.xab", info.spAnimId);
						b3 |= TryInstall(bundleName);
					}
				}
			}
			if (!b3)
				yield break;
			Debug.Log("install start");
			while (KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
			Debug.Log("install end");
		}

		//// RVA: 0x1C1F3C8 Offset: 0x1C1F3C8 VA: 0x1C1F3C8
		private bool TryInstall(StringBuilder bundleName)
		{
			if(!KDLPEDBKMID.HHCJCDFCLOB.EGIFDIFALKK(bundleName.ToString()))
			{
				Debug.Log("install cancelled : " + bundleName.ToString());
				return false;
			}
			else
			{
				if(KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(bundleName.ToString()))
				{
					Debug.Log("install request : " + bundleName.ToString());
					return true;
				}
				return false;
			}
		}

		//// RVA: 0x1C1ED84 Offset: 0x1C1ED84 VA: 0x1C1ED84
		//private void DestroyDelayResources() { }

		// RVA: 0x1C1F630 Offset: 0x1C1F630 VA: 0x1C1F630
		public void LoadDelayResources(CardInfo cardInfo)
		{
			isDelayLoading = true;
			isDelayLoaded = false;
			cardMaterial = null;
			cardTexture = null;
			rareSetPrefab = null;
			this.StartCoroutineWatched(Co_LoadDelayResources(cardInfo));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x738F50 Offset: 0x738F50 VA: 0x738F50
		//// RVA: 0x1C1F670 Offset: 0x1C1F670 VA: 0x1C1F670
		private IEnumerator Co_LoadDelayResources(CardInfo cardInfo)
		{
			bool useCommonRareSet; // 0x18
			AssetBundleLoadAllAssetOperationBase operation; // 0x1C

			//0x1C20A80
			m_sceneCardCache.Load(cardInfo.cardId, 1, (IiconTexture image) =>
			{
				//0x1C1F8C8
				cardTexture = image.BaseTexture;
				cardMaterial = image.Material;
				cardMaterial.SetTexture("_MainTex", cardTexture);
				cardMaterial.SetTexture("_MaskTex", image.MaskTexture);
			});
			while(m_sceneCardCache.IsLoading())
				yield return null;
			if(cardInfo.hasSpAnim)
			{
				if(cardInfo.spAnimId >= 0)
				{
					bundleName.SetFormat("gc/{0:D6}.xab", cardInfo.spAnimId);
					useCommonRareSet = false;
					if(KDLPEDBKMID.HHCJCDFCLOB.EGIFDIFALKK(bundleName.ToString()))
					{
						operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
						yield return operation;
						assetName.SetFormat("gc_{0:D6}_rare_set_prefab", cardInfo.spAnimId);
						rareSetPrefab = operation.GetAsset<GameObject>(assetName.ToString());
						if (operation.IsError())
							useCommonRareSet = true;
						AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
						operation = null;
					}
					else
					{
						useCommonRareSet = true;
					}
					if (useCommonRareSet)
					{
						rareSetPrefab = commonRareSetPrefab[0];
						Debug.LogError("StringLiteral_13923 " + bundleName.ToString());
					}
				}
			}
			//LAB_01c20fd8
			isDelayLoading = false;
			isDelayLoaded = true;
		}
	}
}
