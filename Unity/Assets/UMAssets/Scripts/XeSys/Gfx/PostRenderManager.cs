using System.Collections.Generic;
using UnityEngine;

namespace XeSys.Gfx
{
	public class PostRenderManager : MonoBehaviour
	{
		//private List<PostRenderManager.CameraSetting> cameraSetting; // 0xC
		[SerializeField]
		private Canvas canvasPrefab; // 0x10
		private List<Canvas> mCanvasList; // 0x14
		[SerializeField]
		private OnPostRenderer renderPrefab; // 0x18
		//private LetterBox mLetterBox; // 0x1C
		public bool mUseGL; // 0x20
		private List<OnPostRenderer> mRendererList; // 0x24
		private static Rect mRenderingRect; // 0x4
		private static Vector2 mOffset; // 0x14
		private static PostRenderManager mInstance; // 0x1C

		//public bool useGL { get; } 0x1F0D2BC
		public static Vector2 offset { get { return mOffset; } } //0x1F0C630
		public static float renderingScale { get; private set; } // 0x0
		public static Rect renderingRect { get { return mRenderingRect; } } //0x1F0DD6C
		//public static PostRenderManager Instance { get; } 0x1F09920
		//public static bool letterBoxEnabled { get; } 0x1F0C944
		//public static float letterBoxCoveredRatio { get; } 0x1F0C6CC

		//// RVA: 0x1F0DE04 Offset: 0x1F0DE04 VA: 0x1F0DE04
		//public static GameObject Create(PostRenderManager prefab) { }

		//// RVA: 0x1F0DF48 Offset: 0x1F0DF48 VA: 0x1F0DF48
		private void Awake()
		{
			TodoLogger.Log(0, "PostRenderManager Awake");
		}

		//// RVA: 0x1F0F308 Offset: 0x1F0F308 VA: 0x1F0F308
		//public static Canvas GetCanvas(int layer_no) { }

		//// RVA: 0x1F0F3C8 Offset: 0x1F0F3C8 VA: 0x1F0F3C8
		private void Start()
		{
			TodoLogger.Log(0, "PostRenderManager Start");
		}

		//// RVA: 0x1F0F028 Offset: 0x1F0F028 VA: 0x1F0F028
		//private void UpdateOffsetAndScale() { }

		//// RVA: 0x1F0F3CC Offset: 0x1F0F3CC VA: 0x1F0F3CC
		private void Update()
		{
			TodoLogger.Log(0, "PostRenderManager Update");
		}

		//// RVA: 0x1F0DA9C Offset: 0x1F0DA9C VA: 0x1F0DA9C
		//public void GL_LoadPixelMatrix() { }

		//// RVA: 0x1F099AC Offset: 0x1F099AC VA: 0x1F099AC
		//public void AddElement(IRenderElement elem, int layer, int group) { }

		//// RVA: 0x1F0F54C Offset: 0x1F0F54C VA: 0x1F0F54C
		//public static Vector3 CalcRenderingPosition(Vector3 screenPosition) { }

		//// RVA: 0x1F0F66C Offset: 0x1F0F66C VA: 0x1F0F66C
		//public static Vector3 CalcScreenPosition(float rx, float ry) { }

		//// RVA: 0x1F0F788 Offset: 0x1F0F788 VA: 0x1F0F788
		public static Vector2 CalcScreenPosition(Vector2 renderingPosition)
		{
			return renderingPosition / renderingScale + offset;
		}

		//// RVA: 0x1F0F89C Offset: 0x1F0F89C VA: 0x1F0F89C
		//public static Vector3 CalcScreenPosition(Vector3 renderingPosition) { }

		//// RVA: 0x1F0F9B8 Offset: 0x1F0F9B8 VA: 0x1F0F9B8
		//public static void UnityScreen2Rendering(Vector3 unityPosi, ref Vector3 renderPosi) { }

		//// RVA: 0x1F0FAB0 Offset: 0x1F0FAB0 VA: 0x1F0FAB0
		public static Rect MakeScreenRect(float rx, float ry, float rw, float rh)
		{
			Vector2 v = CalcScreenPosition(new Vector2(rx, ry));
			Vector2 v2 = CalcScreenPosition(new Vector2(rx + rw, ry + rh));
			return new Rect(v, v2 - v);
		}

		//// RVA: 0x1F0FBFC Offset: 0x1F0FBFC VA: 0x1F0FBFC
		//public void SetLetterBoxRenderer(LetterBoxRenderer renderer) { }

		//// RVA: 0x1F0FC24 Offset: 0x1F0FC24 VA: 0x1F0FC24
		//public void SetLetterBoxColor(Color color) { }

		//// RVA: 0x1F0FC64 Offset: 0x1F0FC64 VA: 0x1F0FC64
		//public void SetLetterBoxDisplay(bool isDisplay) { }

		//// RVA: 0x1F0FC8C Offset: 0x1F0FC8C VA: 0x1F0FC8C
		//public static Rect MakeScreenRect(float x, float y, float w, float h, PostRenderManager.AlignH alignH, PostRenderManager.AlignV alignV) { }
	}
}
