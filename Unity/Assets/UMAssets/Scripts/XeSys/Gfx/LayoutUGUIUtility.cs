using UnityEngine;

namespace XeSys.Gfx
{
	public class LayoutUGUIUtility
	{
		public delegate bool SearchParentCallback(Transform transform);
		private static string[] delimiter = new string[1] { " (" }; // 0x0

		// // RVA: 0x1F015E8 Offset: 0x1F015E8 VA: 0x1F015E8
		public static string GetViewIDFromUGUIName(string uguiName)
		{
			return uguiName.Split(delimiter, System.StringSplitOptions.RemoveEmptyEntries)[0];
		}

		// // RVA: 0x1F066BC Offset: 0x1F066BC VA: 0x1F066BC
		public static bool SearchParentGameObject(Transform transform, LayoutUGUIUtility.SearchParentCallback callback)
		{
			while(transform.parent != null)
			{
				transform = transform.parent;
				if(callback(transform))
					return true;
			}
			return false;
		}

		// // RVA: -1 Offset: -1
		public static T GetParentComponent<T>(Transform transform)
		{
			T parent = default(T);
			SearchParentGameObject(transform, (Transform tr) => 
			{
				//0x30A6320
				parent = tr.gameObject.GetComponent<T>();
				return parent != null;
			});
			return parent;
		}
		// /* GenericInstMethod :
		// |
		// |-RVA: 0x20925C8 Offset: 0x20925C8 VA: 0x20925C8
		// |-LayoutUGUIUtility.GetParentComponent<object>
		// |-LayoutUGUIUtility.GetParentComponent<LayoutUGUIRuntime>
		// */

		// // RVA: 0x1EFAD08 Offset: 0x1EFAD08 VA: 0x1EFAD08
		public static LayoutUGUIRuntime GetParentRuntime(Transform transform)
		{
			return GetParentComponent<LayoutUGUIRuntime>(transform);
		}

		// // RVA: 0x1EFB130 Offset: 0x1EFB130 VA: 0x1EFB130
		public static void AddView(GameObject parentObj, AbsoluteLayout parentView, GameObject childObj)
		{
			childObj.transform.SetParent(parentObj.transform, false);
			if (parentView == null)
				return;
			LayoutUGUIRuntime run = childObj.GetComponent<LayoutUGUIRuntime>();
			if (run == null)
				return;
			parentView.AddView(run.Layout.Root);
		}

		// // RVA: 0x1EFB344 Offset: 0x1EFB344 VA: 0x1EFB344
		public static void RemoveView(GameObject parentObj, AbsoluteLayout parentView, GameObject childObj)
		{
			childObj.transform.SetParent(null, false);
			if (parentView == null)
				return;
			LayoutUGUIRuntime runtime = childObj.GetComponent<LayoutUGUIRuntime>();
			if (runtime == null)
				return;
			parentView.RemoveView(runtime.Layout.Root);
		}

		// // RVA: 0x1EFF750 Offset: 0x1EFF750 VA: 0x1EFF750
		public static Rect MakeUnityUVRect(TexUVData uvData)
		{
			return new Rect(uvData.u, (1.0f - uvData.v) - uvData.height, uvData.width, uvData.height);
		}

		// // RVA: 0x1EFF4B0 Offset: 0x1EFF4B0 VA: 0x1EFF4B0
		// public static Rect MakeUnitySpriteTextureRect(Texture tex, TexUVData uvData) { }

		// // RVA: 0x1F07000 Offset: 0x1F07000 VA: 0x1F07000
		// public static bool ApplyTextUGUI(LayoutUGUIRuntime runtime, string viewEXID) { }

		// // RVA: 0x1F0710C Offset: 0x1F0710C VA: 0x1F0710C
		// public static bool ApplyTextUGUI(LayoutUGUIRuntime runtime, TextView view) { }

		// // RVA: -1 Offset: -1
		// public static T SearchComponent<T>(LayoutUGUIRuntime runtime, ViewBase view) { }
		// /* GenericInstMethod :
		// |
		// |-RVA: 0x20926DC Offset: 0x20926DC VA: 0x20926DC
		// |-LayoutUGUIUtility.SearchComponent<object>
		// |-LayoutUGUIUtility.SearchComponent<Text>
		// */

		// // RVA: -1 Offset: -1
		// public static T[] SearchComponentsInChildren<T>(LayoutUGUIRuntime runtime, ViewBase view) { }
		// /* GenericInstMethod :
		// |
		// |-RVA: 0x20A0280 Offset: 0x20A0280 VA: 0x20A0280
		// |-LayoutUGUIUtility.SearchComponentsInChildren<object>
		// */

		// // RVA: 0x1F07248 Offset: 0x1F07248 VA: 0x1F07248
		public static void SetImageRaycastTarget(GameObject obj, bool enable)
		{
			IAlphaTexture[] imgs = obj.GetComponentsInChildren<IAlphaTexture>(true);
			for(int i = 0; i < imgs.Length; i++)
			{
				imgs[i].raycastTarget = enable;
			}
		}

		// // RVA: 0x1F073A0 Offset: 0x1F073A0 VA: 0x1F073A0
		// public static void SetTextRaycastTarget(GameObject obj, bool enable) { }

		// // RVA: 0x1F07490 Offset: 0x1F07490 VA: 0x1F07490
		// public static void ApplyAlignment(RectTransform rectTrans, LayoutUGUIUtility.Alignment align) { }

		// // RVA: 0x1F076CC Offset: 0x1F076CC VA: 0x1F076CC
		// public static void ApplyAlignment(GameObject gameObject, LayoutUGUIUtility.Alignment align) { }

		// // RVA: 0x1F07780 Offset: 0x1F07780 VA: 0x1F07780
		// public static void ApplyAlignment(Component component, LayoutUGUIUtility.Alignment align) { }

		// // RVA: 0x1F075C0 Offset: 0x1F075C0 VA: 0x1F075C0
		// private static Vector2 GetAnchorPos(LayoutUGUIUtility.Alignment align) { }
	}
}
