using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.UI;
using System.Collections;

namespace XeSys.Gfx
{
	#if UNITY_EDITOR
	public class DebugLinkInfo : MonoBehaviour
	{
		public GameObject InitializedFrom;
		[Header("View")]
		public ViewBase View;
		public string LayoutId;
		public string LayoutExId;
		[Header("Render")]
		public string shaderName;
		[Header("Animation")]
		public bool EnableDebugAnim;
		public int MaxFrame;
		public int SetFrame = -1;
		public FrameData[] FrameData;

		public void Init(ViewBase view, LayoutUGUIRuntime runtime)
		{
			View = view;
			LayoutId = view.ID;
			LayoutExId = view.EXID;
			InitializedFrom = runtime.gameObject;
			MaxFrame = view.FrameAnimation.FrameDataCount;
			FrameData = view.FrameAnimation.F;
		}

		void Update()
		{
			RawImageEx img = GetComponent<RawImageEx>();
			if(img != null)
			{
				if(img.material != null)
				{
					shaderName = ""+img.material.shader.GetInstanceID();
				}
			}
			if(EnableDebugAnim)
			{
				if(SetFrame != -1)
				{
					View.StartAnimGoStop(SetFrame, SetFrame);
				}
			}
		}
	}
	#endif

	public class LayoutUGUIRuntime : MonoBehaviour
	{
		public class UguiInfo
		{
			protected ViewBase m_view; // 0x8
			protected RectTransform m_rectTrans; // 0xC
			protected IAlphaTexture m_image; // 0x10
			protected Text m_text; // 0x14
			protected bool m_isMaskChild; // 0x18
			protected bool m_isActiveCheck = true; // 0x19
			private bool m_isActive; // 0x1A
			private Vector2 m_posWork; // 0x1C
			private Vector3 m_scaleWork; // 0x24
			private List<RawImageEx> m_ImageList; // 0x30

			public ViewBase View { get { return m_view; } } //0x1F01718
			public RectTransform RectTrans { get { return m_rectTrans; } } //0x1F01710

			// RVA: 0x1EFCFA8 Offset: 0x1EFCFA8 VA: 0x1EFCFA8
			public UguiInfo(ViewBase view, RectTransform rt, bool setView = true)
			{
				m_view = view;
				m_rectTrans = rt;
				if(setView)
				{
					view.UguiInfo = this;
				}
				m_image = rt.GetComponent(typeof(IAlphaTexture)) as IAlphaTexture;
				if(m_image != null)
				{
					m_image.material = m_image.MaterialMul;
				}
				m_text = rt.GetComponent<Text>();
				ViewBase parent = m_view.Parent;
				m_isMaskChild = false;
				if(parent != null)
				{
					if(parent is MaskView)
					{
						m_isMaskChild = true;
					}
				}
				m_isActive = m_view.IsVisible;
			}

			// // RVA: 0x1F02CA0 Offset: 0x1F02CA0 VA: 0x1F02CA0
			protected static void GetViewPos(ViewBase view, ref Vector2 pos)
			{
				pos = new Vector2(view.MoveX + view.X + view.CenterX, -(view.Y + view.CenterY + view.MoveY));
			}

			// // RVA: 0x1F02DEC Offset: 0x1F02DEC VA: 0x1F02DEC
			protected static Quaternion GetViewRot(ViewBase view)
			{
				return Quaternion.AngleAxis(view.Rot * -57.29578f, Vector3.forward);
			}

			// // RVA: 0x1F02F00 Offset: 0x1F02F00 VA: 0x1F02F00
			protected static void GetViewScale(ViewBase view, ref Vector3 scale)
			{
				scale = new Vector3(view.ScaleX, view.ScaleY, 1.0f);
			}

			// // RVA: 0x1F02F80 Offset: 0x1F02F80 VA: 0x1F02F80
			protected void SetRectTrans()
			{
				if(!m_view.IsUpdateSRT)
				{
					if(!IsAlwaysUpdateSRT)
						return;
				}
				GetViewScale(m_view, ref m_scaleWork);
				m_rectTrans.localScale = m_scaleWork;
				Quaternion q = GetViewRot(m_view);
				m_rectTrans.localRotation = q;
				GetViewPos(m_view, ref m_posWork);
				m_rectTrans.anchoredPosition = m_posWork;
			}

			// // RVA: 0x1F030EC Offset: 0x1F030EC VA: 0x1F030EC
			protected void SetImageList(Transform obj)
			{
				if(!obj.gameObject.activeSelf)
				{
					obj.gameObject.SetActive(true);
				}
				if(m_ImageList == null)
				{
					m_ImageList = new List<RawImageEx>();
				}
				for(int i = 0; i < obj.childCount; i++)
				{
					RawImageEx r = obj.GetChild(i).GetComponent<RawImageEx>();
					if(r != null)
					{
						m_ImageList.Add(r);
					}
					SetImageList(obj.GetChild(i));
				}
			}

			// // RVA: 0x1F03330 Offset: 0x1F03330 VA: 0x1F03330
			protected bool SetAlphaZero(Transform obj, bool vis)
			{
				bool set = false;
				m_ImageList.ForEach((RawImageEx raw_image) => {
					//0x1F03B88
					if(!vis)
					{
						if(raw_image.color.a >= 0 || raw_image.enabled)
						{
							raw_image.enabled = false;
							raw_image.color = new Color(raw_image.color.r, raw_image.color.g, raw_image.color.b, 0.0f);
						}
					}
					else
					{
						if(!raw_image.enabled)
						{
							if(raw_image.color.a >= 0)
							{
								raw_image.enabled = true;
								set = true;
							}
						}
					}
				});
				return set;
			}

			// // RVA: 0x1F016D0 Offset: 0x1F016D0 VA: 0x1F016D0
			public void SetActiveCheck(bool act)
			{
				m_isActiveCheck = act;
				if(act == false)
				{
					SetImageList(m_rectTrans);
					if(m_isActive)
						return;
					SetAlphaZero(m_rectTrans, false);
				}
			}

			// // RVA: 0x1F03450 Offset: 0x1F03450 VA: 0x1F03450 Slot: 4
			public virtual void Update()
			{
				if(!m_view.IsVisible)
				{
					if(!m_isActiveCheck)
					{
						if(!m_isActive)
							return;

						m_isActive = false;
					}
					if(!m_rectTrans.gameObject.activeInHierarchy)
						return;
					m_rectTrans.gameObject.SetActive(false);
					return;
				}
				if(!m_rectTrans.gameObject.activeSelf)
				{
					m_rectTrans.gameObject.SetActive(true);
				}
				if(!m_isMaskChild)
				{
					SetRectTrans();
				}
				else
				{
					if(m_view.IsUpdateSRT || IsAlwaysUpdateSRT)
					{
						Transform originParent = m_rectTrans.parent;
						m_rectTrans.SetParent(m_rectTrans.parent.parent.parent, false);
						SetRectTrans();
						m_rectTrans.SetParent(originParent, true);
						GetViewScale(m_view, ref m_scaleWork);
						m_rectTrans.localScale = m_scaleWork;
					}
				}
				if(m_image != null)
				{
					m_image.color = m_view.currentCol;
					Material mat = null;
					if(m_view.BlendType == ViewBase.EBlendType.mul)
					{
						mat = m_image.MaterialMul;
					}
					else
					{
						mat = m_image.MaterialAdd;
					}
					m_image.material = mat;
				}
				if(m_text != null)
				{
					m_text.color = m_view.currentCol;
				}
				if(!m_isActiveCheck && !m_isActive && SetAlphaZero(null, true))
				{
					m_isActive = true;
				}
			}
		}

		public class UguiInfoScrollbar : UguiInfo
		{
			protected Component[] m_images; // 0x34
			private Scrollbar m_scrollbar; // 0x38

			// RVA: 0x1EFF190 Offset: 0x1EFF190 VA: 0x1EFF190
			public UguiInfoScrollbar(ViewBase view, RectTransform rt) : base(view, rt, false)
			{
				m_images = rt.gameObject.GetComponentsInChildren(typeof(IAlphaTexture), true);
				for(int i = 0; i < m_images.Length; i++)
				{
					IAlphaTexture t = m_images[i] as IAlphaTexture;
					t.material = t.MaterialMul;
				}
				m_scrollbar = rt.gameObject.GetComponent<Scrollbar>();
			}

			// RVA: 0x1F04040 Offset: 0x1F04040 VA: 0x1F04040 Slot: 4
			public override void Update()
			{
				if(!m_view.IsVisible || !m_scrollbar.enabled)
				{
					if(!m_rectTrans.gameObject.activeInHierarchy)
						return;
					m_rectTrans.gameObject.SetActive(false);
					return;
				}
				if(!m_rectTrans.gameObject.activeSelf)
				{
					m_rectTrans.gameObject.SetActive(true);
				}
				for(int i = 0; i < m_images.Length; i++)
				{
					IAlphaTexture t = m_images[i] as IAlphaTexture;
					t.color = m_view.currentCol;
					if(m_view.BlendType == ViewBase.EBlendType.mul)
					{
						t.material = t.MaterialMul;
					}
					else if(m_view.BlendType == ViewBase.EBlendType.add)
					{
						t.material = t.MaterialAdd;
					}
					else
					{
						t.material = t.MaterialMul;
					}
				}
			}
		}

		public class UguiInfoMask : UguiInfo
		{
			private Mask m_mask; // 0x34
			private Graphic m_maskGraphic; // 0x38
			private RectTransform m_child; // 0x3C

			// RVA: 0x1EFCE0C Offset: 0x1EFCE0C VA: 0x1EFCE0C
			public UguiInfoMask(ViewBase view, RectTransform rt) : base(view, rt, true)
			{
				m_mask = rt.gameObject.GetComponent<Mask>();
				m_maskGraphic = rt.gameObject.GetComponent<Graphic>();
				m_child = rt as RectTransform;
				m_rectTrans.gameObject.SetActive(true);
			}

			// RVA: g Offset: 0x1F03D10 VA: 0x1F03D10 Slot: 4
			public override void Update()
			{
				SetRectTrans();
				if(m_rectTrans.localScale.x == 0.0f || m_rectTrans.localScale.y == 0.0f)
				{
					m_rectTrans.localScale = Vector3.one;
					m_mask.enabled = false;
					m_maskGraphic.enabled = false;
				}
				else
				{
					m_mask.enabled = m_view.IsVisible;
					m_maskGraphic.enabled = m_view.IsVisible;
				}
				if(!m_view.IsUpdateSRT)
				{
					if(!LayoutUGUIRuntime.IsAlwaysUpdateSRT)
						return;
				}
				m_child.localScale = new Vector3(1.0f / m_rectTrans.localScale.x, 1.0f / m_rectTrans.localScale.y, 1.0f);
			}
		}


		private static float s_commonTimeScale = 1.0f; // 0x0
		[SerializeField]
		private string m_layoutPath = ""; // 0xC
		[SerializeField]
		private string m_uvlistPath = ""; // 0x10
		[SerializeField]
		private string m_texturePath = ""; // 0x14
		[SerializeField]
		private string[] m_uvlistPathList; // 0x18
		[SerializeField]
		private string[] m_texturePathList; // 0x1C
		[SerializeField]
		private string m_animListPath = ""; // 0x20
		[SerializeField]
		private Font m_font; // 0x24
		[SerializeField]
		private bool m_isTextureSplit; // 0x28
		[SerializeField]
		private bool m_isUseImage; // 0x29
		[SerializeField]
		private bool m_isLayoutAutoLoad = true; // 0x2A
		[SerializeField]
		private bool m_isAutoStart = true; // 0x2B
		//[HideInInspector] // RVA: 0x653CF4 Offset: 0x653CF4 VA: 0x653CF4
		[SerializeField]
		private bool m_isPrefabTextureDelete; // 0x2C
		[SerializeField]
		private bool m_isActiveCheck = true; // 0x2D
		[SerializeField]
		private float m_timeScale = 1.0f; // 0x30
		[SerializeField]
		private GameObject[] m_ActiveObjLsit; // 0x34
		[SerializeField]
		private Color m_testColor = Color.white; // 0x38
		private LayoutLoader m_layoutLoader = new LayoutLoader(4); // 0x48
		private Action m_updater; // 0x4C
		private Layout m_layout; // 0x50
		private TexUVListManager m_uvMan; // 0x54
		private int m_initFromLayoutCount; // 0x58
		private Transform m_transform; // 0x5C
		private static bool m_isAlwaysUpdateSRT = false; // 0x4
		private List<LayoutUGUIRuntime.UguiInfo> m_uguiList; // 0x60
		private ResourceRequest layoutRequest; // 0x68
		private ResourceRequest[] uvListRequest; // 0x6C
		private static StringBuilder s_texNameWork = new StringBuilder(0x20); // 0x8

		// public static float CommonTimeScale { get; set; } 0x1EFFBF0 0x1EFFC7C
		public string LayoutPath { get { return m_layoutPath; } set { m_layoutPath = value; } } //0x1EFFD18 0x1EFBE08
		// public string UvListPath { get; set; } 0x1EFFD28 0x1EFFD20
		// public string TexturePath { get; set; } 0x1EFFD38 0x1EFFD30
		public string AnimListPath { get { return m_animListPath; } set { m_animListPath = value; } } //0x1EFFD40 0x1EFBE20
		public Font Font { get { return m_font; } set { m_font = value; } } //0x1EFFD48 0x1EFBE28
		// public bool IsTextureSplit { get; set; } 0x1EFFD50 0x1EFBF00
		// public bool IsUseImage { get; set; } 0x1EFFD58 0x1EFBF08
		public string[] UvListPathList { get { return m_uvlistPathList; } set { m_uvlistPathList = value; } } //0x1EFFD60 0x1EFBE10
		public string[] TexturePathList { get { return m_texturePathList; } set { m_texturePathList = value; } } //0x1EFFD68 0x1EFBE18
		// public GameObject[] ActiveObjList { get; set; } 0x1EFFD78 0x1EFFD70
		public bool IsLayoutAutoLoad { get { return m_isLayoutAutoLoad; } set { m_isLayoutAutoLoad = value; } } //0x1EFFD80 0x1EFFD88
		// public float TimeScale { get; set; } 0x1EFFD90 0x1EFFD98
		public static bool IsAlwaysUpdateSRT { get { return m_isAlwaysUpdateSRT; } set { m_isAlwaysUpdateSRT = value; } } //0x1EFFDA0 0x1EFBF20
		public Layout Layout { get { return m_layout; } set { m_layout = value; } } //0x1EFFE2C 0x1EFBF10
		public TexUVListManager UvMan { get { return m_uvMan; } set { m_uvMan = value; } } //0x1EFFE34 0x1EFBF18
		// public List<LayoutUGUIRuntime.UguiInfo> UguiInfoList { set; } 0x1EFCE04
		public bool IsReady { get; private set; } // 0x64
		// public bool IsUpdate { get; set; } 0x1EFFE4C 0x1EFFEE4

		// RVA: 0x1F0005C Offset: 0x1F0005C VA: 0x1F0005C
		private void Awake()
		{
			IsReady = false;
			m_updater = this.UpdateIdle;
			m_initFromLayoutCount = 0;
			m_transform = transform;
		}

		// RVA: 0x1F00100 Offset: 0x1F00100 VA: 0x1F00100
		private void Start()
		{
#if UNITY_EDITOR
			//UMO
			if (FileSystemProxy.IsTesting)
				return;
			//
#endif
			if(!m_isLayoutAutoLoad)
				return;
			LoadLayout();
		}

		// RVA: 0x1F0021C Offset: 0x1F0021C VA: 0x1F0021C
		private void Update()
		{
			m_updater();
		}

		// // RVA: 0x1F00248 Offset: 0x1F00248 VA: 0x1F00248
		private void UpdateIdle()
		{
			return;
		}

		// // RVA: 0x1F0024C Offset: 0x1F0024C VA: 0x1F0024C
		private void UpdateLoad()
		{
			if(m_layoutLoader.IsLoading)
				return;
			if(m_layout == null)
			{
				FontInfo fi = new FontInfo();
				fi.font = m_font;
				fi.size = 1;
				if(m_layoutLoader.CreateLayout(m_layoutPath, m_uvlistPathList, fi, out m_layout, ref m_uvMan) && !string.IsNullOrEmpty(m_animListPath))
				{
					m_layoutLoader.SettingAnimation(m_layout, m_animListPath);
				}
				m_layoutLoader.Clear();
			}
			ConnectUguiInfo();
			m_updater = this.UpdatePreStart;
			UpdatePreStart();
		}

		// // RVA: 0x1F004E8 Offset: 0x1F004E8 VA: 0x1F004E8
		private void UpdatePreStart()
		{
			m_layout.StartAllAnimDecoLoop();
			Component[] elem = gameObject.GetComponentsInChildren(typeof(ILayoutUGUIPaste), true);
			for(; m_initFromLayoutCount < elem.Length; m_initFromLayoutCount++)
			{
				if(!(elem[m_initFromLayoutCount] as ILayoutUGUIPaste).InitializeFromLayout(m_layout, m_uvMan))
				{
					UnityEngine.Debug.LogError("Faild to init "+this.name);
					return;
				}
			}
			IsReady = true;
			if(!m_isAutoStart)
			{
				m_updater = this.UpdateIdle;
				return;
			}
			m_updater = this.UpdateUgui;
			UpdateUgui();
		}

		// // RVA: 0x1F0079C Offset: 0x1F0079C VA: 0x1F0079C
		private void UpdateUgui()
		{
			ViewBase l = m_layout.Root.Parent;
			if(l == null)
			{
				m_layout.UpdateAllAnimation((TimeWrapper.deltaTime * m_timeScale * s_commonTimeScale) * 2.0f);
				m_layout.UpdateAll(m_testColor);
			}
		}

		// // RVA: 0x1F00110 Offset: 0x1F00110 VA: 0x1F00110
		public void LoadLayout()
		{
			if(!m_isLayoutAutoLoad)
			{
				ConnectUguiInfo();
				m_updater = this.UpdatePreStart;
				return;
			}
			if(IsReady)
				return;
			if(m_updater != this.UpdateIdle)
				return;
			LoadScriptableLayout();
		}

		// // RVA: 0x1F00908 Offset: 0x1F00908 VA: 0x1F00908
		private void LoadScriptableLayout()
		{
			if(IdleProcessManager.Instance.Register(LoadScriptableLayoutCoroutine(), 0, 0) > -1)
			{
				m_updater = this.UpdateLoadAsset;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6927A0 Offset: 0x6927A0 VA: 0x6927A0
		// // RVA: 0x1F00A1C Offset: 0x1F00A1C VA: 0x1F00A1C
		private IEnumerator LoadScriptableLayoutCoroutine()
		{
			UnityEngine.Debug.Log("Enter LoadScriptableLayoutCoroutine "+m_layoutPath);
			// private ResourceRequest <req>5__2; // 0x14
			// private ScriptableLayout <scriptableLayout>5__3; // 0x18
			// private int <i>5__4; // 0x1C
			// private IEnumerator <reqUv>5__5; // 0x20
			 // 0x1F02450
			ResourceRequest req = Resources.LoadAsync<ScriptableLayout>(m_layoutPath);
			if(m_uvMan  == null)
			{
				m_uvMan = new TexUVListManager(m_uvlistPathList.Length);
			}
			for(int i = 0; i < m_uvlistPathList.Length; i++)
			{
				while(true)
				{
					IEnumerator reqUv = m_uvMan.LoadAssetAsync(i, m_uvlistPathList[i], null);
					if(IdleProcessManager.Instance.Register(reqUv, 0, 0) < 0)
					{
						yield return null;
					}
					else
						break;
				}
			}
			while(!req.isDone)
			{
				yield return null;
			}
			ScriptableLayout scriptableLayout = req.asset as ScriptableLayout;
			if(scriptableLayout == null)
			{
				m_updater = this.LoadXmlLayout;
				UnityEngine.Debug.Log("Exit XML LoadScriptableLayoutCoroutine"+m_layoutPath);
				yield break;
			}
			if(m_layout == null)
			{
				m_layout = new Layout();
				if(m_layout.fontInfo == null)	
				{
					m_layout.fontInfo = new FontInfo();
					m_layout.fontInfo.font = m_font;
					m_layout.fontInfo.size = 1;
				}
				scriptableLayout.Deserialize(m_layout);
				yield return null;
			}
			while(!m_uvMan.CheckRegistration(m_uvlistPathList.Length))
			{
				yield return null;
			}
			ConnectUguiInfo(scriptableLayout.ViewsCount);
			m_updater = this.UpdatePreStart;

			UnityEngine.Debug.Log("Exit ScriptableLayout LoadScriptableLayoutCoroutine"+m_layoutPath);
		}

		// // RVA: 0x1F00AC8 Offset: 0x1F00AC8 VA: 0x1F00AC8
		private void LoadXmlLayout()
		{
			UnityEngine.Debug.LogError(m_layoutPath+" "+m_animListPath+" "+m_layout);
			if(!(m_layout == null && !string.IsNullOrEmpty(m_layoutPath)) && string.IsNullOrEmpty(m_animListPath))
			{
				ConnectUguiInfo();
				m_updater = this.UpdatePreStart;
			}
			else
			{
				UnityEngine.Debug.LogError("Will load UV & Anims");
				List<string> lstr = new List<string>(4);
				if(m_layout == null && !string.IsNullOrEmpty(m_layoutPath))
				{
					lstr.Add(m_layoutPath);
					for(int i = 0; i < m_uvlistPathList.Length; i++)
					{
						lstr.Add(m_uvlistPathList[i]);
					}
				}
				if(!string.IsNullOrEmpty(m_animListPath))
				{
					lstr.Add(m_animListPath);
				}
				m_layoutLoader.Load(ResourcesManager.Instance, lstr, null);
				m_updater = this.UpdateLoad;
			}
		}

		// // RVA: 0x1F00D6C Offset: 0x1F00D6C VA: 0x1F00D6C
		private void UpdateLoadAsset()
		{
			return;
		}

		// // RVA: 0x1F00D70 Offset: 0x1F00D70 VA: 0x1F00D70
		private void ConnectUguiInfo(int count)
		{
			m_uguiList = new List<UguiInfo>(count);
			ConnectUguiInfoInner(m_layout.Root, transform);
		}

		// // RVA: 0x1F00418 Offset: 0x1F00418 VA: 0x1F00418
		private void ConnectUguiInfo()
		{
			if(m_uguiList != null)
				return;
			m_uguiList = new List<LayoutUGUIRuntime.UguiInfo>(256);
			ConnectUguiInfoInner(m_layout.Root, transform);
		}

		// // RVA: 0x1F00E38 Offset: 0x1F00E38 VA: 0x1F00E38
		private void ConnectUguiInfoInner(AbsoluteLayout rootLayout, Transform rootTrans)
		{
			for(int i = 0; i < rootTrans.childCount; i++)
			{
				Transform rt = rootTrans.GetChild(i);
				ViewBase view = null;
				for(int j = 0; j < rootLayout.viewCount; j++)
				{
					if(rootLayout[j].ID == LayoutUGUIUtility.GetViewIDFromUGUIName(rt.name))
					{
						view = rootLayout[j];
						break;
					}
				}
				if(view == null)
					continue;
				#if UNITY_EDITOR
				rt.gameObject.AddComponent<DebugLinkInfo>().Init(view, this);
				#endif
				if(rt.name.Contains("ScrollbarH") || rt.name.Contains("ScrollbarV"))
				{
					m_uguiList.Add(new UguiInfoScrollbar(view, rt as RectTransform));
				}
				else if(rt.name.Contains("MaskView"))
				{
					m_uguiList.Add(new UguiInfoMask(view, rt as RectTransform));
					rt = rt.GetChild(0);
				}
				else
				{
					m_uguiList.Add(new UguiInfo(view, rt as RectTransform, true));
				}
				bool found = false;
				for(int j = 0; j < m_ActiveObjLsit.Length; j++)
				{
					if(rt.gameObject == m_ActiveObjLsit[j])
					{
						found = true;
						break;
					}
				}
				if(found)
				{
					m_uguiList[m_uguiList.Count - 1].SetActiveCheck(!m_isActiveCheck);
				}
				else
				{
					m_uguiList[m_uguiList.Count - 1].SetActiveCheck(m_isActiveCheck);
				}
				if(view != null && view is AbsoluteLayout)
				{
					ConnectUguiInfoInner(view as AbsoluteLayout, rt);
				}
			}
		}

		// // RVA: 0x1EFB008 Offset: 0x1EFB008 VA: 0x1EFB008
		public ViewBase FindViewBase(RectTransform rt)
		{
			for(int i = 0; i < m_uguiList.Count; i++)
			{
				if(m_uguiList[i].RectTrans == rt)
					return m_uguiList[i].View;
			}
			return null;
		}

		// // RVA: 0x1F01720 Offset: 0x1F01720 VA: 0x1F01720
		public RectTransform FindRectTransform(ViewBase view)
		{
			if(view.UguiInfo != null)
			{
				return view.UguiInfo.RectTrans;
			}
			return null;
		}

		// // RVA: 0x1F01790 Offset: 0x1F01790 VA: 0x1F01790
		// public void SetActiveChildren(bool active) { }

		// // RVA: 0x1F01840 Offset: 0x1F01840 VA: 0x1F01840
		// public void PasteTexture(LayoutUGUIRuntime.TextureSet[] texList) { }

		// // RVA: 0x1F01F14 Offset: 0x1F01F14 VA: 0x1F01F14
		// public void DeleteTexture() { }
	}
}
