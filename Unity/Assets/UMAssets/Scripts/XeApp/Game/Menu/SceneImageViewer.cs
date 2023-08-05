using mcrs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class SceneImageViewer : MonoBehaviour
	{
		public enum ScenePage
		{
			NORMAL = 0,
			EVOLV = 1,
			KIRA = 2,
		}

		private enum ChildObject
		{
			SwaipTouch = 3,
			LeftArrow = 4,
			RightArrow = 5,
			Page = 6,
			Close = 7,
		}

		[SerializeField]
		private SceneViewerArrow leftArrow; // 0xC
		[SerializeField]
		private SceneViewerArrow rightArrow; // 0x10
		[SerializeField]
		private RawImageEx m_kiraEffectImage; // 0x14
		[SerializeField]
		private RawImageEx m_kiraOverlayEffectImage; // 0x18
		private List<ActionButton> m_arrowButton = new List<ActionButton>(); // 0x1C
		private List<GameObject> m_arrowButtonObject = new List<GameObject>(); // 0x20
		private ActionButton m_closeButton; // 0x24
		private GameObject m_closeButtonObject; // 0x28
		private ZoomSceneFrame[] m_frameInstance = new ZoomSceneFrame[2]; // 0x2C
		private GameObject m_frameRootObject; // 0x30
		private RawImageEx m_sceneImage; // 0x34
		private RectTransform m_rectTransform; // 0x38
		private const string AssetBundleName = "ly/016.xab";
		private readonly string[] framePrefabNames = new string[9]
		{
			"PlateFrame001", "PlateFrame002", "PlateFrame003", "PlateFrame004", 
			"PlateFrame005", "PlateFrame006", "PlateFrame007_1", "PlateFrame007_2",
			"PlateFrame003_4"
		}; // 0x40
		private Material material; // 0x44
		private int m_page = 1; // 0x48
		private bool m_isKira; // 0x4C
		private bool m_EndViewer; // 0x4D
		private bool IsRArrowEnable; // 0x4E
		private bool IsLArrowEnable; // 0x4F
		private static Vector2 CardSize = new Vector2(244, 138); // 0x0
		private static Vector2 CardSizeHighRare = new Vector2(1184, 666); // 0x8
		private static Rect CardUv = new Rect(0.0234375f, 0.2319336f, 0.9526367f, 0.5366211f); // 0x10
		private static Rect CardUvHighRare = new Rect(0.0f, 0.21875f, 1.0f, 0.5625f); // 0x20
		private SceneViewerPageLamp m_pageLamp; // 0x50
		//[CompilerGeneratedAttribute] // RVA: 0x67B82C Offset: 0x67B82C VA: 0x67B82C
		public UnityAction<int> onLeftArrow; // 0x54
		//[CompilerGeneratedAttribute] // RVA: 0x67B83C Offset: 0x67B83C VA: 0x67B83C
		public UnityAction<int> onRightArrow; // 0x58
		//[CompilerGeneratedAttribute] // RVA: 0x67B84C Offset: 0x67B84C VA: 0x67B84C
		public UnityAction onClose; // 0x5C
		private bool m_isEventCall; // 0x60
		private bool m_isEvolv; // 0x61
		private bool m_isVisible; // 0x62
		private bool m_isToucheDisable; // 0x63
		private bool m_isTouchImage; // 0x64
		private bool m_isScroll; // 0x65
		private SwaipTouch m_swaipTouch; // 0x68
		private Button m_touchButton; // 0x6C
		private Rect m_cardUv; // 0x70

		public bool IsZoomable { get; set; } // 0x3C

		// RVA: 0x1372C38 Offset: 0x1372C38 VA: 0x1372C38
		private void Start()
		{
			m_arrowButtonObject.Add(transform.GetChild(4).gameObject);
			m_arrowButtonObject.Add(transform.GetChild(5).gameObject);
			for(int i = 0; i < m_arrowButtonObject.Count; i++)
			{
				m_arrowButton.Add(m_arrowButtonObject[i].GetComponentInChildren<ActionButton>(true));
			}
			m_pageLamp = GetComponentInChildren<SceneViewerPageLamp>(true);
			m_closeButtonObject = transform.GetChild(7).gameObject;
			m_closeButton = m_closeButtonObject.GetComponentInChildren<ActionButton>(true);
			m_arrowButton[0].AddOnClickCallback(PushLeftArrow);
			m_arrowButton[1].AddOnClickCallback(PushRightArrow);
			m_closeButton.AddOnClickCallback(OnPushClose);
			m_swaipTouch = GetComponentInChildren<SwaipTouch>(true);
			m_swaipTouch.SetMute(true);
			m_touchButton = GetComponent<Button>();
			m_touchButton.onClick.AddListener(OnUiToggle);
			m_sceneImage = GetComponentInChildren<RawImageEx>(true);
			m_frameRootObject = new GameObject("FrameRoot");
			m_frameRootObject.AddComponent<RectTransform>();
			m_frameRootObject.transform.SetParent(m_sceneImage.transform, false);
			m_rectTransform = GetComponent<RectTransform>();
			material = new Material(m_sceneImage.material);
			material.SetFloat("_MipmapBias", -0.5f);
			m_sceneImage.material = material;
			m_sceneImage.MaterialMul = material;
		}

		// // RVA: 0x137334C Offset: 0x137334C VA: 0x137334C
		// public void SetTexture(Texture2D texture) { }

		// // RVA: 0x1373544 Offset: 0x1373544 VA: 0x1373544
		public void SetTexture(IiconTexture texture)
		{
			if(texture != null && texture is SceneCardTexture)
			{
				SceneCardTexture tex = texture as SceneCardTexture;
				material.SetTexture("_MainTex", tex.BaseTexture);
				material.SetTexture("_MaskTex", Texture2D.whiteTexture);
				material.SetFloat("_MipmapBias", -0.5f);
				m_sceneImage.texture = null;
				m_sceneImage.material = tex.Material;
				m_sceneImage.MaterialMul = tex.Material;
				if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.EJPFDDOOKJI(SystemInfo.graphicsDeviceName))
				{
					material.EnableKeyword("FIXEDBIAS");
				}
				m_sceneImage.texture = tex.BaseTexture;
			}
			else
			{
				m_sceneImage.texture = null;
				if(texture == null)
				{
					m_sceneImage.material = null;
					m_sceneImage.MaterialMul = null;
				}
				else
				{
					m_sceneImage.material = texture.Material;
					m_sceneImage.MaterialMul = texture.Material;
				}
			}
		}

		// // RVA: 0x1373BA8 Offset: 0x1373BA8 VA: 0x1373BA8
		private void OnLeftArrow()
		{
			if (onLeftArrow != null)
				onLeftArrow(m_page);
		}

		// // RVA: 0x1373C18 Offset: 0x1373C18 VA: 0x1373C18
		private void OnRightArrow()
		{
			if (onRightArrow != null)
				onRightArrow(m_page);
		}

		// // RVA: 0x1373C88 Offset: 0x1373C88 VA: 0x1373C88
		private void PushLeftArrow()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_Scroll(1));
		}

		// // RVA: 0x1373DA8 Offset: 0x1373DA8 VA: 0x1373DA8
		private void PushRightArrow()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_Scroll(-1));
		}

		// // RVA: 0x1373E20 Offset: 0x1373E20 VA: 0x1373E20
		private void OnPushClose()
		{
			if(onClose != null)
			{
				onClose();
				m_EndViewer = true;
			}
		}

		// // RVA: 0x1373E4C Offset: 0x1373E4C VA: 0x1373E4C
		public void Initialize(bool isEvolv, int baseRare, bool isKira = false)
		{
			m_page = isKira ? 2 : (isEvolv ? 1 : 0);
			for(int i = 0; i < m_arrowButtonObject.Count; i++)
			{
				m_arrowButtonObject[i].SetActive(true);
			}
			m_closeButtonObject.SetActive(false);
			m_isEvolv = isEvolv;
			m_isToucheDisable = true;
			SetPage(m_page);
			m_isTouchImage = false;
			m_isVisible = true;
			transform.GetComponent<RectTransform>().sizeDelta = GetComponentInParent<Canvas>().transform.GetComponent<RectTransform>().sizeDelta;
			m_cardUv = GetCardUv(baseRare);
			GameManager.Instance.SceneIconCache.ChangeKiraMaterial_2048(m_kiraEffectImage);
			GameManager.Instance.SceneIconCache.ChangeKiraMaterial_holo(m_kiraOverlayEffectImage);
			m_kiraEffectImage.rectTransform.sizeDelta = m_sceneImage.rectTransform.sizeDelta;
			m_kiraEffectImage.uvRect = m_sceneImage.uvRect;
			m_kiraOverlayEffectImage.rectTransform.sizeDelta = m_sceneImage.rectTransform.sizeDelta;
			m_kiraOverlayEffectImage.uvRect = m_sceneImage.uvRect;
			m_isKira = isKira;
			int mp = 1;
			if (m_isKira)
				mp = 2;
			if (!isEvolv)
				mp = 1;
			m_pageLamp.SetMaxPage(mp, isKira && !isEvolv);
			UpdateArrow(m_page);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70F68C Offset: 0x70F68C VA: 0x70F68C
		// // RVA: 0x137482C Offset: 0x137482C VA: 0x137482C
		public IEnumerator Co_LoadRareFrame(int baseRare)
		{
			AssetBundleLoadAssetOperation op;

			//0x1376F04
			if (baseRare == 3)
			{
				op = AssetBundleManager.LoadAssetAsync("ly/016.xab", framePrefabNames[2], typeof(GameObject));
				yield return op;
				m_frameInstance[0] = Instantiate(op.GetAsset<GameObject>()).GetComponent<ZoomSceneFrame>();
				op = null;
				op = AssetBundleManager.LoadAssetAsync("ly/016.xab", framePrefabNames[framePrefabNames.Length - 1], typeof(GameObject));
				yield return op;
				m_frameInstance[1] = Instantiate(op.GetAsset<GameObject>()).GetComponent<ZoomSceneFrame>();
				op = null;
			}
			else if(baseRare == 6)
			{
				op = AssetBundleManager.LoadAssetAsync("ly/016.xab", framePrefabNames[6], typeof(GameObject));
				yield return op;
				m_frameInstance[0] = Instantiate(op.GetAsset<GameObject>()).GetComponent<ZoomSceneFrame>();
				op = null;
				op = AssetBundleManager.LoadAssetAsync("ly/016.xab", framePrefabNames[baseRare + 1], typeof(GameObject));
				yield return op;
				m_frameInstance[1] = Instantiate(op.GetAsset<GameObject>()).GetComponent<ZoomSceneFrame>();
				op = null;
			}
			else
			{
				op = AssetBundleManager.LoadAssetAsync("ly/016.xab", framePrefabNames[baseRare - 1], typeof(GameObject));
				yield return op;
				m_frameInstance[0] = Instantiate(op.GetAsset<GameObject>()).GetComponent<ZoomSceneFrame>();
				op = null;
				op = AssetBundleManager.LoadAssetAsync("ly/016.xab", framePrefabNames[baseRare], typeof(GameObject));
				yield return op;
				m_frameInstance[1] = Instantiate(op.GetAsset<GameObject>()).GetComponent<ZoomSceneFrame>();
				op = null;
			}
			AssetBundleManager.UnloadAssetBundle("ly/016.xab", false);
			AssetBundleManager.UnloadAssetBundle("ly/016.xab", false);
			op = null;
			for(int i = 0; i < m_frameInstance.Length; i++)
			{
				m_frameInstance[i].transform.SetParent(m_frameRootObject.transform, false);
				m_frameInstance[i].gameObject.SetActive(false);
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70F704 Offset: 0x70F704 VA: 0x70F704
		// // RVA: 0x13748F4 Offset: 0x13748F4 VA: 0x13748F4
		public IEnumerator Co_ReleaseRareFrame()
		{
			//0x1377F80
			for(int i = 0; i < m_frameInstance.Length; i++)
			{
				Destroy(m_frameInstance[i].gameObject);
				m_frameInstance[i] = null;
			}
			m_kiraEffectImage.MaterialAdd = null;
			m_kiraEffectImage.MaterialMul = null;
			m_kiraEffectImage.material = null;
			m_kiraOverlayEffectImage.MaterialAdd = null;
			m_kiraOverlayEffectImage.MaterialMul = null;
			m_kiraOverlayEffectImage.material = null;
			yield return null;
			Resources.UnloadUnusedAssets();
			yield return null;
		}

		// // RVA: 0x13749A0 Offset: 0x13749A0 VA: 0x13749A0
		public void Show()
		{
			m_isToucheDisable = false;
			m_closeButtonObject.SetActive(true);
			m_pageLamp.Hide();
			if(m_isEvolv || m_isKira)
			{
				m_pageLamp.Show();
			}
			UpdateArrow(m_pageLamp.Page);
			m_isVisible = true;
			InputEnable();
			m_swaipTouch.ResetCanvas();
			m_EndViewer = false;
		}

		// // RVA: 0x1374BD8 Offset: 0x1374BD8 VA: 0x1374BD8
		public void Close()
		{
			m_isToucheDisable = true;
			for(int i = 0; i < m_arrowButton.Count; i++)
			{
				m_arrowButton[i].Hidden = true;
			}
			m_closeButtonObject.SetActive(false);
			if (m_isEvolv || m_isKira)
				m_pageLamp.Hide();
			m_isVisible = false;
		}

		// // RVA: 0x1374D20 Offset: 0x1374D20 VA: 0x1374D20
		public void InputDisable()
		{
			m_closeButton.IsInputOff = true;
			m_arrowButton[0].IsInputOff = true;
			m_arrowButton[1].IsInputOff = true;
			m_isToucheDisable = true;
			m_touchButton.interactable = false;
		}

		// // RVA: 0x1374A94 Offset: 0x1374A94 VA: 0x1374A94
		public void InputEnable()
		{
			m_closeButton.IsInputOff = false;
			m_arrowButton[0].IsInputOff = false;
			m_arrowButton[1].IsInputOff = false;
			m_isToucheDisable = false;
			m_touchButton.interactable = true;
		}

		// // RVA: 0x13743A4 Offset: 0x13743A4 VA: 0x13743A4
		public void SetPage(int page)
		{
			UpdateArrow(page);
			m_pageLamp.SetPage(page);
			ChangeEnableKiraEffect(page == 2);
		}

		// // RVA: 0x1374E64 Offset: 0x1374E64 VA: 0x1374E64
		private void ChangeEnableKiraEffect(bool _isKira)
		{
			if(m_kiraEffectImage != null)
			{
				m_kiraEffectImage.gameObject.SetActive(_isKira);
			}
			if(m_kiraOverlayEffectImage != null)
			{
				m_kiraOverlayEffectImage.gameObject.SetActive(_isKira);
			}
		}

		// // RVA: 0x13744D4 Offset: 0x13744D4 VA: 0x13744D4
		private void UpdateArrow(int page)
		{
			if (!m_isKira)
			{
				if (!m_isEvolv)
				{
					m_arrowButton[0].Hidden = true;
					m_arrowButton[1].Hidden = true;
				}
				else
				{
					m_arrowButton[0].Hidden = page != 1;
					m_arrowButton[1].Hidden = page != 0;
				}
			}
			else if(!m_isEvolv)
			{
				m_arrowButton[0].Hidden = page != 2;
				m_arrowButton[1].Hidden = page != 1;
			}
			else
			{
				m_arrowButton[0].Hidden = page < 1 || page > 2;
				m_arrowButton[1].Hidden = (page == 0) != (page != 1);
			}
			IsLArrowEnable = !m_arrowButton[0].Hidden;
			IsRArrowEnable = !m_arrowButton[1].Hidden;
			ArrowLayoutChange();
		}

		// // RVA: 0x137503C Offset: 0x137503C VA: 0x137503C
		private void OnUiToggle()
		{
			if(!m_swaipTouch.IsStop())
			{
				if (m_swaipTouch.IsSwaiping())
					return;
				if(!m_swaipTouch.IsMoveFlickDistance() && !m_EndViewer)
				{
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					if(!m_isVisible)
					{
						Show();
						m_touchButton.enabled = false;
						this.StartCoroutineWatched(Co_ImageSizeChange(false, () =>
						{
							//0x1376030
							m_frameRootObject.SetActive(true);
							m_touchButton.enabled = true;
							m_isToucheDisable = false;
						}));
					}
					else
					{
						Close();
						m_frameRootObject.SetActive(false);
						m_touchButton.enabled = false;
						this.StartCoroutineWatched(Co_ImageSizeChange(true, () =>
						{
							//0x1375FF8
							m_isToucheDisable = true;
							m_touchButton.enabled = true;
						}));
					}
				}
			}
		}

		// // RVA: 0x1375338 Offset: 0x1375338 VA: 0x1375338
		public static Vector2 GetCardSize(float screenWidth)
		{
			return new Vector2(screenWidth / 1184.0f * 1184.0f, screenWidth / 1184.0f * 666.0f);
		}

		// // RVA: 0x1375380 Offset: 0x1375380 VA: 0x1375380
		public static Vector3 GetStartScale(int baseRare, float width)
		{
			if (baseRare < 4)
				return new Vector3(244.0f / width, 244.0f / width, 1);
			else
				return new Vector3(256.0f / width, 256.0f / width, 1);
		}

		// // RVA: 0x13753D8 Offset: 0x13753D8 VA: 0x13753D8
		public static float GetEndScale(int baseRare)
		{
			return 1.0f;
		}

		// // RVA: 0x13743F8 Offset: 0x13743F8 VA: 0x13743F8
		public static Rect GetCardUv(int baseRare)
		{
			if (baseRare < 4)
				return CardUv;
			else
				return CardUvHighRare;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70F77C Offset: 0x70F77C VA: 0x70F77C
		// // RVA: 0x1375278 Offset: 0x1375278 VA: 0x1375278
		private IEnumerator Co_ImageSizeChange(bool isZoom, UnityAction endCb)
		{
			float startSize; // 0x1C
			float endSize; // 0x20
			Rect startUv; // 0x24
			Rect endUv; // 0x34
			bool isExecute; // 0x44
			Vector2 cardSize; // 0x48
			float time; // 0x50
			float WaitTime; // 0x54

			//0x1376170
			isExecute = true;
			endUv = Rect.zero;
			startUv = Rect.zero;
			startSize = 0;
			endSize = 0;
			if(IsZoomable)
			{
				cardSize = new Vector2(m_rectTransform.sizeDelta.x / 1184 * 1184, m_rectTransform.sizeDelta.x / 1184 * 666);
				if(!isZoom)
				{
					startSize = m_sceneImage.rectTransform.sizeDelta.y;
					endSize = cardSize.y;
					startUv = m_sceneImage.uvRect;
					endUv = m_cardUv;
					isExecute = endSize - startSize < 0;
				}
				else
				{
					startSize = m_sceneImage.rectTransform.sizeDelta.y;
					endSize = m_rectTransform.sizeDelta.y;
					startUv = m_sceneImage.uvRect;
					endUv = m_sceneImage.uvRect;
					endUv.height = m_rectTransform.sizeDelta.y / m_rectTransform.sizeDelta.x;
					endUv.y = ((m_rectTransform.sizeDelta.x - m_rectTransform.sizeDelta.y) * -0.5f / m_rectTransform.sizeDelta.x + 1) - endUv.height;
					isExecute = endSize - startSize >= 0;
				}
				time = 0;
				WaitTime = Mathf.Clamp(Mathf.Abs(endSize - startSize), 0.01f, 0.1f);
				while(isExecute && time / WaitTime < 1)
				{
					float r = time / WaitTime;
					m_sceneImage.rectTransform.sizeDelta = new Vector2(cardSize.x, Mathf.Lerp(startSize, endSize, r));
					m_sceneImage.uvRect = new Rect(startUv.x, Mathf.Lerp(startUv.y, endUv.y, r), startUv.width, Mathf.Lerp(startUv.height, endUv.height, r));
					m_kiraEffectImage.rectTransform.sizeDelta = m_sceneImage.rectTransform.sizeDelta;
					m_kiraEffectImage.uvRect = m_sceneImage.uvRect;
					m_kiraOverlayEffectImage.rectTransform.sizeDelta = m_sceneImage.rectTransform.sizeDelta;
					m_kiraOverlayEffectImage.uvRect = m_sceneImage.uvRect;
					yield return null;
					time += TimeWrapper.deltaTime;
				}
				m_sceneImage.rectTransform.sizeDelta = new Vector2(cardSize.x, endSize);
				m_sceneImage.uvRect = new Rect(startUv.x, endUv.y, startUv.width, endUv.height);
				m_kiraEffectImage.rectTransform.sizeDelta = m_sceneImage.rectTransform.sizeDelta;
				m_kiraEffectImage.uvRect = m_sceneImage.uvRect;
				m_kiraOverlayEffectImage.rectTransform.sizeDelta = m_sceneImage.rectTransform.sizeDelta;
				m_kiraOverlayEffectImage.uvRect = m_sceneImage.uvRect;
			}
			if (endCb != null)
				endCb();
		}

		// RVA: 0x1375400 Offset: 0x1375400 VA: 0x1375400
		private void Update()
		{
			if (!m_isEvolv && !m_isKira)
				return;
			if (m_isToucheDisable)
				return;
			if(m_swaipTouch.IsSwaip(SwaipTouch.Direction.RIGHT) || !m_swaipTouch.IsFlickNoSwaip(SwaipTouch.Direction.RIGHT))
			{
				if(IsLArrowEnable)
				{
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_004);
					this.StartCoroutineWatched(Co_Scroll(1));
				}
			}
			if (m_swaipTouch.IsSwaip(SwaipTouch.Direction.LEFT) || !m_swaipTouch.IsFlickNoSwaip(SwaipTouch.Direction.LEFT))
			{
				if (IsRArrowEnable)
				{
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_004);
					this.StartCoroutineWatched(Co_Scroll(-1));
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70F7F4 Offset: 0x70F7F4 VA: 0x70F7F4
		// // RVA: 0x1373D00 Offset: 0x1373D00 VA: 0x1373D00
		private IEnumerator Co_Scroll(int dir)
		{
			//0x13782D8
			m_isScroll = true;
			m_arrowButton.ForEach((ActionButton x) =>
			{
				//0x137610C
				x.enabled = false;
			});
			if(dir < 0)
			{
				m_page++;
				OnRightArrow();
				SetPage(m_page);
			}
			else if(dir > 0)
			{
				m_page--;
				OnLeftArrow();
				SetPage(m_page);
			}
			UpdateArrow(m_pageLamp.Page);
			yield return null;
			m_isScroll = false;
			m_arrowButton.ForEach((ActionButton x) =>
			{
				//0x137613C
				x.enabled = true;
			});
		}

		// // RVA: 0x13755EC Offset: 0x13755EC VA: 0x13755EC
		// private void ScrollRight() { }

		// // RVA: 0x137561C Offset: 0x137561C VA: 0x137561C
		// private void ScrollLeft() { }

		// // RVA: 0x1374FCC Offset: 0x1374FCC VA: 0x1374FCC
		private void ArrowLayoutChange()
		{
			leftArrow.ChangeArrowText(m_page != 2);
			rightArrow.ChangeArrowText(m_page != 1);
		}

		// // RVA: 0x137564C Offset: 0x137564C VA: 0x137564C
		public void SetFrame(int baseRare, int attr, bool isRankUp)
		{
			for(int i = 0; i < m_frameInstance.Length; i++)
			{
				m_frameInstance[i].gameObject.SetActive(false);
			}
			m_frameInstance[isRankUp ? 1 : 0].SetAttribute(attr);
			m_frameInstance[isRankUp ? 1 : 0].SetRarity(baseRare, isRankUp);
			m_frameInstance[isRankUp ? 1 : 0].gameObject.SetActive(true);
			m_frameRootObject.transform.localScale = new Vector3(m_rectTransform.sizeDelta.x / 1184, m_rectTransform.sizeDelta.x / 1184, 1);
		}

		// // RVA: 0x1375904 Offset: 0x1375904 VA: 0x1375904
		public void PerformClick()
		{
			if(!m_closeButton.IsInputOff)
			{
				if(!m_closeButton.Disable)
				{
					if (!m_closeButtonObject.activeSelf)
						return;
					m_closeButton.PerformClick();
				}
			}
		}
	}
}
