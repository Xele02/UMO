using System.Collections.Generic;

namespace XeSys.Gfx
{
	public class LayoutLoader
	{
		private Dictionary<string, object> m_dicData; // 0x8
		// private ILoader m_loader; // 0xC
		// private List<string> m_pathList; // 0x10
		// private Action m_callback; // 0x14
		// private LayoutAnimationLoader m_animLoader; // 0x18

		// public bool IsLoading { get; }
		// public int LoadedCount { get; }

		// RVA: 0x1EF9834 Offset: 0x1EF9834 VA: 0x1EF9834
		public LayoutLoader(int defaultCount)
		{
			m_dicData = new Dictionary<string, object>();
			Clear();
		}

		// RVA: 0x1EF9948 Offset: 0x1EF9948 VA: 0x1EF9948
		public LayoutLoader() : this(0)
		{
			return;
		}

		// RVA: 0x1EF98D0 Offset: 0x1EF98D0 VA: 0x1EF98D0
		public void Clear()
		{
			m_dicData.Clear();
		}

		// // RVA: 0x1EF9950 Offset: 0x1EF9950 VA: 0x1EF9950
		// public void Load(ILoader loader, List<string> pathList, Action callback) { }

		// // RVA: 0x1EF9C60 Offset: 0x1EF9C60 VA: 0x1EF9C60
		// private bool LoadedFile(FileResultObject fro) { }

		// // RVA: 0x1EF9ED8 Offset: 0x1EF9ED8 VA: 0x1EF9ED8
		// private void LoadedAnimation(string path) { }

		// // RVA: 0x1EFA010 Offset: 0x1EFA010 VA: 0x1EFA010
		// public bool get_IsLoading() { }

		// // RVA: 0x1EFA094 Offset: 0x1EFA094 VA: 0x1EFA094
		// public int get_LoadedCount() { }

		// // RVA: 0x1EFA10C Offset: 0x1EFA10C VA: 0x1EFA10C
		// public byte[] GetBytes(string path) { }

		// // RVA: -1 Offset: -1
		// private T GetAsset<T>(string path) { }
		// /* GenericInstMethod :
		// |
		// |-RVA: 0x2092460 Offset: 0x2092460 VA: 0x2092460
		// |-LayoutLoader.GetAsset<object>
		// |-LayoutLoader.GetAsset<Texture2D>
		// |-LayoutLoader.GetAsset<LayoutAnimationLoader>
		// |-LayoutLoader.GetAsset<ScriptableLayout>
		// |-LayoutLoader.GetAsset<TexUVList>
		// */

		// // RVA: 0x1EFA284 Offset: 0x1EFA284 VA: 0x1EFA284
		// public Texture2D GetTexture(string path) { }

		// // RVA: 0x1EFA2F0 Offset: 0x1EFA2F0 VA: 0x1EFA2F0
		// public LayoutAnimationLoader GetAnimLoader(string path) { }

		// // RVA: 0x1EFA35C Offset: 0x1EFA35C VA: 0x1EFA35C
		// public TexUVList GetTexUVList(string path) { }

		// // RVA: 0x1EFA3C8 Offset: 0x1EFA3C8 VA: 0x1EFA3C8
		// public bool CreateLayout(string pathLayout, string[] pathUvlist, string pathAnimList, FontInfo fontInfo, out Layout layout, ref TexUVListManager uvMan) { }

		// // RVA: 0x1EFA424 Offset: 0x1EFA424 VA: 0x1EFA424
		// public bool CreateLayout(string pathLayout, string[] pathUvlist, FontInfo fontInfo, out Layout layout, ref TexUVListManager uvMan) { }

		// // RVA: 0x1EFA784 Offset: 0x1EFA784 VA: 0x1EFA784
		// public int SettingAnimation(Layout layout, string path) { }
	}
}
