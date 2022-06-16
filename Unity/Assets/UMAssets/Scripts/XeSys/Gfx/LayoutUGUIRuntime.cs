using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace XeSys.Gfx
{
	public class LayoutUGUIRuntime : MonoBehaviour
	{
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
		// private List<LayoutUGUIRuntime.UguiInfo> m_uguiList; // 0x60
		private ResourceRequest layoutRequest; // 0x68
		private ResourceRequest[] uvListRequest; // 0x6C
		private static StringBuilder s_texNameWork = new StringBuilder(0x20); // 0x8

		// public static float CommonTimeScale { get; set; } 0x1EFFBF0 0x1EFFC7C
		// public string LayoutPath { get; set; } 0x1EFFD18 0x1EFBE08
		// public string UvListPath { get; set; } 0x1EFFD28 0x1EFFD20
		// public string TexturePath { get; set; } 0x1EFFD38 0x1EFFD30
		// public string AnimListPath { get; set; } 0x1EFFD40 0x1EFBE20
		// public Font Font { get; set; } 0x1EFFD48 0x1EFBE28
		// public bool IsTextureSplit { get; set; } 0x1EFFD50 0x1EFBF00
		// public bool IsUseImage { get; set; } 0x1EFFD58 0x1EFBF08
		// public string[] UvListPathList { get; set; } 0x1EFFD60 0x1EFBE10
		// public string[] TexturePathList { get; set; } 0x1EFFD68 0x1EFBE18
		// public GameObject[] ActiveObjList { get; set; } 0x1EFFD78 0x1EFFD70
		// public bool IsLayoutAutoLoad { get; set; } 0x1EFFD80 0x1EFFD88
		// public float TimeScale { get; set; } 0x1EFFD90 0x1EFFD98
		// public static bool IsAlwaysUpdateSRT { get; set; } 0x1EFFDA0 0x1EFBF20
		// public Layout Layout { get; set; } 0x1EFFE2C 0x1EFBF10
		// public TexUVListManager UvMan { get; set; } 0x1EFFE34 0x1EFBF18
		// public List<LayoutUGUIRuntime.UguiInfo> UguiInfoList { set; } 0x1EFCE04
		public bool IsReady { get; private set; } // 0x64
		// public bool IsUpdate { get; set; } 0x1EFFE4C 0x1EFFEE4

		// RVA: 0x1F0005C Offset: 0x1F0005C VA: 0x1F0005C
		private void Awake()
		{
			UnityEngine.Debug.LogWarning("TODO LayoutUGUIRuntime Awake");
		}

		// RVA: 0x1F00100 Offset: 0x1F00100 VA: 0x1F00100
		private void Start()
		{
			UnityEngine.Debug.LogWarning("TODO LayoutUGUIRuntime Start");
		}

		// RVA: 0x1F0021C Offset: 0x1F0021C VA: 0x1F0021C
		private void Update()
		{
			UnityEngine.Debug.LogWarning("TODO LayoutUGUIRuntime Update");
		}

		// // RVA: 0x1F00248 Offset: 0x1F00248 VA: 0x1F00248
		// private void UpdateIdle() { }

		// // RVA: 0x1F0024C Offset: 0x1F0024C VA: 0x1F0024C
		// private void UpdateLoad() { }

		// // RVA: 0x1F004E8 Offset: 0x1F004E8 VA: 0x1F004E8
		// private void UpdatePreStart() { }

		// // RVA: 0x1F0079C Offset: 0x1F0079C VA: 0x1F0079C
		// private void UpdateUgui() { }

		// // RVA: 0x1F00110 Offset: 0x1F00110 VA: 0x1F00110
		// public void LoadLayout() { }

		// // RVA: 0x1F00908 Offset: 0x1F00908 VA: 0x1F00908
		// private void LoadScriptableLayout() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6927A0 Offset: 0x6927A0 VA: 0x6927A0
		// // RVA: 0x1F00A1C Offset: 0x1F00A1C VA: 0x1F00A1C
		// private IEnumerator LoadScriptableLayoutCoroutine() { }

		// // RVA: 0x1F00AC8 Offset: 0x1F00AC8 VA: 0x1F00AC8
		// private void LoadXmlLayout() { }

		// // RVA: 0x1F00D6C Offset: 0x1F00D6C VA: 0x1F00D6C
		// private void UpdateLoadAsset() { }

		// // RVA: 0x1F00D70 Offset: 0x1F00D70 VA: 0x1F00D70
		// private void ConnectUguiInfo(int count) { }

		// // RVA: 0x1F00418 Offset: 0x1F00418 VA: 0x1F00418
		// private void ConnectUguiInfo() { }

		// // RVA: 0x1F00E38 Offset: 0x1F00E38 VA: 0x1F00E38
		// private void ConnectUguiInfoInner(AbsoluteLayout rootLayout, Transform rootTrans) { }

		// // RVA: 0x1EFB008 Offset: 0x1EFB008 VA: 0x1EFB008
		// public ViewBase FindViewBase(RectTransform rt) { }

		// // RVA: 0x1F01720 Offset: 0x1F01720 VA: 0x1F01720
		// public RectTransform FindRectTransform(ViewBase view) { }

		// // RVA: 0x1F01790 Offset: 0x1F01790 VA: 0x1F01790
		// public void SetActiveChildren(bool active) { }

		// // RVA: 0x1F01840 Offset: 0x1F01840 VA: 0x1F01840
		// public void PasteTexture(LayoutUGUIRuntime.TextureSet[] texList) { }

		// // RVA: 0x1F01F14 Offset: 0x1F01F14 VA: 0x1F01F14
		// public void DeleteTexture() { }
	}
}
