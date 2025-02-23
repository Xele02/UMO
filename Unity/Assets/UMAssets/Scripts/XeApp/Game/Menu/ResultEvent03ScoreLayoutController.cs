using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class ResultEvent03ScoreLayoutController : MonoBehaviour
	{
		public class InitParam
		{
			public GJOOGLGLFID viewEventGameResultData; // 0x8
			public FJIPMALKCBG viewEventMatchResultData; // 0xC
			public LayoutResultOkayButton layoutOkayButton; // 0x10
		}

		private enum Effect
		{
			Player1 = 0,
			Player2 = 1,
			Num = 2,
		}

		private string[] effectPrefabName = new string[2] { "fx_bg_1P", "fx_bg_2P" }; // 0xC
		private Vector3[] effectPosition = new Vector3[2] { new Vector3(2, 15, -27), new Vector3(2, 15, -27) }; // 0x10
		[SerializeField]
		private GameObject[] effectPrefab = new GameObject[2]; // 0x14
		private GameObject[] effectObject = new GameObject[2]; // 0x18
		private GameObject[] effectWinLose = new GameObject[2]; // 0x1C
		private MenuDivaManager myDivaManager; // 0x20
		private ResultDivaControl myDivaControl; // 0x24
		private RivalDivaManager rivalDivaManager; // 0x28
		private GameObject textureObject; // 0x2C
		private DivaCameraRenderSwitch mySwitch; // 0x30
		private RenderTexture myModelRT; // 0x34
		private DivaCameraRenderSwitch rivalSwitch; // 0x38
		private RenderTexture rivalModelRT; // 0x3C
		private Camera clearColorCamera; // 0x40
		private RenderTexture bgCanvasRT; // 0x44
		private GameObject myBgObject; // 0x48
		private GameObject rivalBgObject; // 0x4C
		private LayoutResultEvent03Score layoutScore; // 0x50
		private LayoutResultEvent03Telop layoutTelop; // 0x54
		private LayoutResultOkayButton layoutOkayButton; // 0x58
		public Action onClickOkayButton; // 0x5C
		private const string BundleName = "ly/095.xab";
		private bool isPlayerWin; // 0x60
		private bool isStarted; // 0x61
		private bool isSkiped; // 0x62

		public ResultDivaControl divaControl { get { return myDivaControl; } } //0xD0607C

		// RVA: 0xD06084 Offset: 0xD06084 VA: 0xD06084
		private void Awake()
		{
			layoutScore = transform.Find("Event03Score").GetComponent<LayoutResultEvent03Score>();
			layoutTelop = transform.Find("Event03Telop").GetComponent<LayoutResultEvent03Telop>();
		}

		// RVA: 0xD061A8 Offset: 0xD061A8 VA: 0xD061A8
		private void Update()
		{
			if(IsReady())
			{
				CheckSkipStep();
			}
		}

		// // RVA: 0xD061CC Offset: 0xD061CC VA: 0xD061CC
		public bool IsReady()
		{
			return layoutScore.IsLoaded() && layoutTelop.IsLoaded();
		}

		// // RVA: 0xD06344 Offset: 0xD06344 VA: 0xD06344
		public bool IsDivaReady()
		{
			return rivalDivaManager != null && rivalDivaManager.DivaId > -1;
		}

		// // RVA: 0xD0640C Offset: 0xD0640C VA: 0xD0640C
		public void Initialize(MenuDivaManager myDivaManager, ResultDivaControl myDivaControl)
		{
			this.myDivaManager = myDivaManager;
			this.myDivaControl = myDivaControl;
			myDivaManager.LockBoneSpring();
		}

		// // RVA: 0xD06440 Offset: 0xD06440 VA: 0xD06440
		public void Setup(InitParam initParam)
		{
			this.StartCoroutineWatched(Co_Setup(initParam));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x721E0C Offset: 0x721E0C VA: 0x721E0C
		// // RVA: 0xD06464 Offset: 0xD06464 VA: 0xD06464
		private IEnumerator Co_Setup(InitParam initParam)
		{
			//0xB49834
			if(SystemManager.isLongScreenDevice)
			{
				MenuScene.Instance.FlexibleLayoutCamera.SetDisable();
			}
			yield return AssetBundleManager.LoadUnionAssetBundle("ly/095.xab");
			yield return Co.R(Co_TextureInitialize());
			yield return Co.R(Co_EffectInitialize());
			AssetBundleManager.UnloadAssetBundle("ly/095.xab", false);
			yield return Co.R(Co_DivaInitialize(initParam.viewEventMatchResultData.EKOCEKHBHLE_Rival.FDBOPFEOENF_RivalData));
			isPlayerWin = initParam.viewEventMatchResultData.GGOPOOLMLBA_IsPlayerWin;
			layoutOkayButton = initParam.layoutOkayButton;
			layoutOkayButton.SetupCallback(null, OnClickOkayButton);
			layoutScore.Setup(initParam.viewEventMatchResultData, initParam.viewEventGameResultData.IDBJPDBLIIG_ScoreResultRank);
			layoutTelop.Setup(initParam.viewEventMatchResultData);
			myDivaManager.SetEnableDivaWind(true, false);
			rivalDivaManager.SetEnableDivaWind(true, false);
			myDivaManager.SetActive(true, true);
			myDivaManager.UnlockBoneSpring();
			myDivaControl.OnBattleResultStart();
			SetEffectPos(Effect.Player1, myDivaManager.GetComponentInChildren<Camera>(), initParam.viewEventMatchResultData.HIHPPOFHMNF_Player.FDBOPFEOENF_RivalData.AHHJLDLAPAN_DivaId);
			rivalDivaManager.SetActive(true, true);
			rivalDivaManager.UnlockBoneSpring();
			rivalDivaManager.OnBattleResultStart();
			SetEffectPos(Effect.Player2, rivalDivaManager.GetComponentInChildren<Camera>(), initParam.viewEventMatchResultData.EKOCEKHBHLE_Rival.FDBOPFEOENF_RivalData.AHHJLDLAPAN_DivaId);
			Transform[] ts = new Transform[3]
			{
				myDivaManager.transform,
				rivalDivaManager.transform,
				myDivaManager.transform
			};
			effectObject[0].transform.SetParent(myDivaManager.transform, false);
			effectObject[0].SetActive(true);
			effectObject[1].transform.SetParent(rivalDivaManager.transform, false);
			effectObject[1].SetActive(true);
			myDivaManager.SwitchCameraRender(mySwitch);
			rivalDivaManager.SwitchCameraRender(rivalSwitch);
			textureObject.transform.SetParent(transform, false);
			textureObject.transform.SetAsFirstSibling();
			yield return Co.R(ApplyImageSize());
		}

		// // RVA: 0xD06508 Offset: 0xD06508 VA: 0xD06508
		public void Release(Action callback)
		{
			this.StartCoroutineWatched(Co_Release(callback));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x721E84 Offset: 0x721E84 VA: 0x721E84
		// // RVA: 0xD0652C Offset: 0xD0652C VA: 0xD0652C
		private IEnumerator Co_Release(Action callback)
		{
			//0xB4957C
			yield return Co.R(Co_DivaRelease());
			yield return Co.R(Co_EffectRelease());
			yield return Co.R(Co_TextureRelease());
			if(SystemManager.isLongScreenDevice)
			{
				MenuScene.Instance.FlexibleLayoutCamera.SetEnable();
			}
			if(callback != null)
				callback();
		}

		// // RVA: 0xD065D0 Offset: 0xD065D0 VA: 0xD065D0
		public void StartAnim()
		{
			this.StartCoroutineWatched(Co_StartAnim());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x721EFC Offset: 0x721EFC VA: 0x721EFC
		// // RVA: 0xD065F4 Offset: 0xD065F4 VA: 0xD065F4
		private IEnumerator Co_StartAnim()
		{
			//0xB4A650
			isStarted = true;
			bool done = false;
			layoutScore.StartBeginAnim(() =>
			{
				//0xD075C0
				done = true;
			});
			while(!done)
				yield return null;
			yield return new WaitForSeconds(0.4f);
			done = false;
			layoutTelop.StartAnim((int state) =>
			{
				//0xD075CC
				if(state == 1)
				{
					done = true;
				}
				else if(state == 0)
				{
					OnFinishedAllAnim();
				}
			});
			while(!done)
				yield return null;
			layoutScore.LoopAnim();
			layoutTelop.LoopAnim();
		}

		// // RVA: 0xD0667C Offset: 0xD0667C VA: 0xD0667C
		public void EndAnim(Action onEndCallback)
		{
			layoutScore.StartEndAnim(() =>
			{
				//0xD07610
				onEndCallback();
			});
			layoutTelop.gameObject.SetActive(false);
		}

		// // RVA: 0xD067A8 Offset: 0xD067A8 VA: 0xD067A8
		public void SetActive(bool active)
		{
			layoutScore.gameObject.SetActive(active);
			layoutTelop.gameObject.SetActive(active);
		}

		// // RVA: 0xD06228 Offset: 0xD06228 VA: 0xD06228
		private void CheckSkipStep()
		{
			if(isStarted && !isSkiped)
			{
				if(InputManager.Instance.GetInScreenTouchCount() > 0)
				{
					if(ResultScene.IsScreenTouch())
					{
						isSkiped = true;
						layoutScore.SkipBeginAnim();
						layoutTelop.SkipAnim();
					}
				}
			}
		}

		// // RVA: 0xD06844 Offset: 0xD06844 VA: 0xD06844
		private void OnFinishedAllAnim()
		{
			effectWinLose[0].SetActive(isPlayerWin);
			effectWinLose[1].SetActive(!isPlayerWin);
			myDivaControl.RequestBattleResultAnimStart(isPlayerWin);
			rivalDivaManager.RequestBattleResultAnimStart(!isPlayerWin);
			layoutOkayButton.StartBeginAnim(false);
		}

		// // RVA: 0xD06994 Offset: 0xD06994 VA: 0xD06994
		private void OnClickOkayButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			if(onClickOkayButton != null)
				onClickOkayButton();
		}

		// // RVA: 0xD06A04 Offset: 0xD06A04 VA: 0xD06A04
		private void SetEffectPos(Effect effect, Camera camera, int divaId)
		{
			effectObject[(int)effect].transform.localPosition = new Vector3(effectPosition[(int)effect].x, effectPosition[(int)effect].y + camera.transform.localPosition.y, effectPosition[(int)effect].z);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x721F74 Offset: 0x721F74 VA: 0x721F74
		// // RVA: 0xD06B40 Offset: 0xD06B40 VA: 0xD06B40
		private IEnumerator Co_TextureInitialize()
		{
			AssetBundleLoadAssetOperation operation; // 0x14
			RawImage[] texlist; // 0x18
			Canvas bgCanvas; // 0x1C
			Camera prevCamera; // 0x20
			Camera renderCamera; // 0x24

			//0xB4AA30
			operation = AssetBundleManager.LoadAssetAsync("ly/095.xab", "Event03Diva", typeof(GameObject));
			yield return operation;
			textureObject = Instantiate(operation.GetAsset<GameObject>());
			texlist = textureObject.GetComponentsInChildren<RawImage>(true);
			operation = AssetBundleManager.LoadAssetAsync("ly/095.xab", "RT_Background", typeof(RenderTexture));
			yield return operation;
			RenderTexture rt = operation.GetAsset<RenderTexture>();
			bgCanvasRT = new RenderTexture(rt.width, rt.height, rt.depth, rt.format);
			bgCanvas = MenuScene.Instance.m_bgRootObject.GetComponentInParent<Canvas>();
			prevCamera = bgCanvas.worldCamera;
			renderCamera = Instantiate(prevCamera);
			bgCanvas.worldCamera = renderCamera;
			renderCamera.targetTexture = bgCanvasRT;
			clearColorCamera = new GameObject("ClearColor Camera", new Type[1] { typeof(Camera) }).GetComponent<Camera>();
			clearColorCamera.name = "ClearColor Camera";
			clearColorCamera.cullingMask = 0;
			clearColorCamera.clearFlags = CameraClearFlags.SolidColor;
			clearColorCamera.backgroundColor = Color.blue;
			clearColorCamera.depth = -100;
			clearColorCamera.transform.SetParent(transform, false);
			AssetBundleManager.UnloadAssetBundle("ly/095.xab", false);
			yield return null;
			renderCamera.targetTexture = null;
			bgCanvas.worldCamera = prevCamera;
			Destroy(renderCamera.gameObject);
			bgCanvas = null;
			prevCamera = null;
			renderCamera = null;
			operation = AssetBundleManager.LoadAssetAsync("ly/095.xab", "BG_Quad", typeof(GameObject));
			yield return operation;
			myBgObject = Instantiate(operation.GetAsset<GameObject>());
			myBgObject.name = "My BG Plane";
			myBgObject.SetActive(false);
			myBgObject.layer = 18;
			rivalBgObject = Instantiate(operation.GetAsset<GameObject>());
			rivalBgObject.name = "Rival BG Plane";
			rivalBgObject.SetActive(false);
			rivalBgObject.layer = 18;
            MeshRenderer myRender = myBgObject.GetComponent<MeshRenderer>();
			MeshRenderer rivalRender = rivalBgObject.GetComponent<MeshRenderer>();
            Material m = new Material(myRender.material);
			m.mainTexture = bgCanvasRT;
			myRender.sharedMaterial = m;
			rivalRender.sharedMaterial = m;
			AssetBundleManager.UnloadAssetBundle("ly/095.xab", false);
			SystemManager.OverPermissionAspectResult perm = SystemManager.Instance.CheckOverPermissionAspectRatio();
			RawImage img = texlist.Where((RawImage _) =>
			{
				//0xD073B8
				return _.name == "LeftSide";
			}).First();
			rt = img.texture as RenderTexture;
			myModelRT = new RenderTexture(rt.width, rt.height, rt.depth, rt.format);
			img.texture = myModelRT;
			if(perm != SystemManager.OverPermissionAspectResult.None || SystemManager.isLongScreenDevice)
			{
				img.rectTransform.pivot = new Vector2(1, 0);
				img.rectTransform.anchorMin = new Vector2(1, 0);
				img.rectTransform.anchorMax = new Vector2(1, 0);
				img.rectTransform.anchoredPosition = new Vector2(-SystemManager.BaseScreenHalfSize.x, 0);
				if(perm != SystemManager.OverPermissionAspectResult.None)
				{
					img.rectTransform.sizeDelta = MakeWideScreenImageSize();
				}
			}
			mySwitch = null;
			if(!SystemManager.isLongScreenDevice)
			{
				if(perm == SystemManager.OverPermissionAspectResult.None)
				{
					mySwitch = new DivaCameraRenderSwitch();
				}
				else
				{
					mySwitch = new WideScreenDivaCameraRenderSwitch();
				}
			}
			else
			{
				mySwitch = new LongScreenDivaCameraRenderSwitch();
			}
			mySwitch.Initialize(myModelRT, myBgObject);
			img = texlist.Where((RawImage _) =>
			{
				//0xD07438
				return _.name == "RightSide";
			}).First();
			rt = img.texture as RenderTexture;
			rivalModelRT = new RenderTexture(rt.width, rt.height, rt.depth, rt.format);
			img.texture = rivalModelRT;
			if(perm != SystemManager.OverPermissionAspectResult.None || SystemManager.isLongScreenDevice)
			{
				img.rectTransform.pivot = new Vector2(0, 0);
				img.rectTransform.anchorMin = new Vector2(0, 0);
				img.rectTransform.anchorMax = new Vector2(0, 0);
				img.rectTransform.anchoredPosition = new Vector2(SystemManager.BaseScreenHalfSize.x, 0);
				if(perm != SystemManager.OverPermissionAspectResult.None)
				{
					img.rectTransform.sizeDelta = MakeWideScreenImageSize();
				}
			}
			rivalSwitch = null;
			if(!SystemManager.isLongScreenDevice)
			{
				if(perm == SystemManager.OverPermissionAspectResult.None)
				{
					rivalSwitch = new DivaCameraRenderSwitch();
				}
				else
				{
					rivalSwitch = new WideScreenDivaCameraRenderSwitch();
				}
			}
			else
			{
				rivalSwitch = new LongScreenDivaCameraRenderSwitch();
			}
			rivalSwitch.Initialize(rivalModelRT, rivalBgObject);
			AssetBundleManager.UnloadAssetBundle("ly/095.xab", false);
		}

		// // RVA: 0xD06BC8 Offset: 0xD06BC8 VA: 0xD06BC8
		private Vector2 MakeWideScreenImageSize()
		{
			return new Vector2((((Screen.width * 1.0f) / Screen.height) / 1.494949f) * SystemManager.BaseScreenHalfSize.x, SystemManager.BaseScreenSize.y);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x721FEC Offset: 0x721FEC VA: 0x721FEC
		// // RVA: 0xD06CC4 Offset: 0xD06CC4 VA: 0xD06CC4
		private IEnumerator ApplyImageSize()
		{
			RawImage[] texlist; // 0x14
			RawImage leftImage; // 0x18
			RawImage rightImage; // 0x1C

			//0xD07640
			if(SystemManager.isLongScreenDevice)
			{
				texlist = textureObject.GetComponentsInChildren<RawImage>(true);
				yield return null;
				leftImage = texlist.Where((RawImage _) =>
				{
					//0xD074B8
					return _.name == "LeftSide";
				}).First();
				rightImage = texlist.Where((RawImage _) =>
				{
					//0xD07538
					return _.name == "RightSide";
				}).First();
				leftImage.SetNativeSize();
				rightImage.SetNativeSize();
				yield return null;
				leftImage.rectTransform.localScale = new Vector3(666.0f / leftImage.rectTransform.sizeDelta.y, 666.0f / leftImage.rectTransform.sizeDelta.y, 1);
				texlist = null;
				leftImage = null;
				rightImage = null;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x722064 Offset: 0x722064 VA: 0x722064
		// // RVA: 0xD06D70 Offset: 0xD06D70 VA: 0xD06D70
		private IEnumerator Co_TextureRelease()
		{
			//0xB4C4AC
			Destroy(textureObject);
			textureObject = null;
			myModelRT.Release();
			myModelRT = null;
			rivalModelRT.Release();
			rivalModelRT = null;
			Destroy(myBgObject);
			myBgObject = null;
			Destroy(rivalBgObject);
			rivalBgObject = null;
			Destroy(clearColorCamera.gameObject);
			clearColorCamera = null;
			bgCanvasRT.Release();
			bgCanvasRT = null;
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7220DC Offset: 0x7220DC VA: 0x7220DC
		// // RVA: 0xD06DF8 Offset: 0xD06DF8 VA: 0xD06DF8
		private IEnumerator Co_DivaInitialize(FFHPBEPOMAK_DivaInfo rivalDiva)
		{
			LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo costumeMaster;

			//0xD07BF4
			costumeMaster = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.LBDOLHGDIEB_GetUnlockedCostumeOrDefault(rivalDiva.AHHJLDLAPAN_DivaId, rivalDiva.JPIDIENBGKH_CostumeId);
			KDLPEDBKMID.HHCJCDFCLOB.NMFCNFFFMAC_InstallDivaCostume(rivalDiva.AHHJLDLAPAN_DivaId, costumeMaster.DAJGPBLEEOB_PrismCostumeModelId, false);
			while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
			rivalDivaManager = MenuScene.Instance.GetComponentInChildren<RivalDivaManager>(true);
			rivalDivaManager.gameObject.SetActive(true);
			rivalDivaManager.Load(costumeMaster.AHHJLDLAPAN_PrismDivaId, costumeMaster.DAJGPBLEEOB_PrismCostumeModelId, rivalDiva.EKFONBFDAAP_ColorId);
			rivalDivaManager.LockBoneSpring();
			while(rivalDivaManager.IsLoading)
				yield return null;
			rivalDivaManager.SetActive(false, true);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x722154 Offset: 0x722154 VA: 0x722154
		// // RVA: 0xD06EC0 Offset: 0xD06EC0 VA: 0xD06EC0
		private IEnumerator Co_DivaRelease()
		{
			//0xD08154
			myDivaManager.SetEnableDivaWind(false, false);
			rivalDivaManager.SetEnableDivaWind(false, false);
			myDivaControl.ResetBattleResultTransform();
			rivalDivaManager.ResetBattleResultTransform();
			myDivaManager.RevertCameraRender(mySwitch);
			rivalDivaManager.RevertCameraRender(rivalSwitch);
			rivalDivaManager.SetActive(false, true);
			rivalDivaManager.Release();
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7221CC Offset: 0x7221CC VA: 0x7221CC
		// // RVA: 0xD06F6C Offset: 0xD06F6C VA: 0xD06F6C
		private IEnumerator Co_EffectInitialize()
		{
			int i; // 0x14
			AssetBundleLoadAssetOperation operation; // 0x18

			//0xD08350
			for(i = 0; i < effectPrefabName.Length; i++)
			{
				operation = AssetBundleManager.LoadAssetAsync("ly/095.xab", effectPrefabName[i], typeof(GameObject));
				yield return operation;
				effectObject[i] = Instantiate(operation.GetAsset<GameObject>());
				effectObject[i].SetActive(false);
				effectWinLose[i] = effectObject[i].transform.Find("fx_bg_Aurora").gameObject;
				effectWinLose[i].SetActive(false);
				AssetBundleManager.UnloadAssetBundle("ly/095.xab", false);
				operation = null;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x722244 Offset: 0x722244 VA: 0x722244
		// // RVA: 0xD07018 Offset: 0xD07018 VA: 0xD07018
		private IEnumerator Co_EffectRelease()
		{ 
			//0xB4935C
			for(int i = 0; i < 2; i++)
			{
				Destroy(effectObject[i].gameObject);
				effectObject[i] = null;
				effectWinLose[i] = null;
			}
			yield break;
		}
	}
}
