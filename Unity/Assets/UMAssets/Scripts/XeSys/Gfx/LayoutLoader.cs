using System.Collections.Generic;
using UnityEngine;
using System;

namespace XeSys.Gfx
{
	public class LayoutLoader
	{
		private Dictionary<string, object> m_dicData; // 0x8
		private ILoader m_loader; // 0xC
		private List<string> m_pathList; // 0x10
		private Action m_callback; // 0x14
		private LayoutAnimationLoader m_animLoader; // 0x18

		public bool IsLoading { get {
			if(m_pathList != null)
				return m_pathList.Count > 0;
			return false;
		} } // 0x1EFA010
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
		public void Load(ILoader loader, List<string> pathList, Action callback)
		{
			m_loader = loader;
			m_pathList = pathList;
			m_callback = callback;
			for(int i = 0; i < pathList.Count; i++)
			{
				if(!m_dicData.ContainsKey(m_pathList[i]))
				{
					if(m_pathList[i].Contains("_animlist"))
					{
						UnityEngine.Debug.LogError("Will load anim "+m_pathList[i]+" on "+m_loader);
						m_animLoader = new LayoutAnimationLoader();
						m_animLoader.Load(m_loader, m_pathList[i], this.LoadedAnimation);
					}
					else
					{
						UnityEngine.Debug.LogError("Will load asset "+m_pathList[i]+" on "+m_loader);
						m_loader.Load(m_pathList[i], this.LoadedFile);
					}
				}
			}
		}

		// // RVA: 0x1EF9C60 Offset: 0x1EF9C60 VA: 0x1EF9C60
		private bool LoadedFile(FileResultObject fro)
		{
			object obj;
			if(fro.unityObject != null)
			{
				obj = fro.unityObject;
			}
			else
			{
				if(fro.bytes == null)
				{
					if(fro.texture == null)
						return true;
					obj = fro.texture;
				}
				else
				{
					obj = fro.bytes;
				}
			}
			if(obj != null)
			{
				m_dicData.Add(fro.path, obj);
				if(m_dicData.Count == m_pathList.Count)
				{
					m_pathList.Clear();
					if(m_callback != null)
						m_callback();
				}
			}
			return true;
		}

		// // RVA: 0x1EF9ED8 Offset: 0x1EF9ED8 VA: 0x1EF9ED8
		private void LoadedAnimation(string path)
		{
			m_dicData.Add(path, m_animLoader);
			m_animLoader = null;
			if(m_pathList.Count != m_dicData.Count)
				return;
			m_pathList.Clear();
			if(m_callback != null)
			{
				m_callback();
			}
		}

		// // RVA: 0x1EFA094 Offset: 0x1EFA094 VA: 0x1EFA094
		// public int get_LoadedCount() { }

		// // RVA: 0x1EFA10C Offset: 0x1EFA10C VA: 0x1EFA10C
		public byte[] GetBytes(string path)
		{
			object found = null;
			if(m_dicData.TryGetValue(path, out found))
			{
				if(found is TextAsset)
				{
					return (found as TextAsset).bytes;
				}
			}
			return null;
		}

		// // RVA: -1 Offset: -1
		private T GetAsset<T>(string path)
		{
			object found = null;
			if(m_dicData.TryGetValue(path, out found))
			{
				return (T)found;
			}
			return default(T);
		}
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
		public LayoutAnimationLoader GetAnimLoader(string path)
		{
			return GetAsset<LayoutAnimationLoader>(path);
		}

		// // RVA: 0x1EFA35C Offset: 0x1EFA35C VA: 0x1EFA35C
		public TexUVList GetTexUVList(string path)
		{
			return GetAsset<TexUVList>(path);
		}

		// // RVA: 0x1EFA3C8 Offset: 0x1EFA3C8 VA: 0x1EFA3C8
		// public bool CreateLayout(string pathLayout, string[] pathUvlist, string pathAnimList, FontInfo fontInfo, out Layout layout, ref TexUVListManager uvMan) { }

		// // RVA: 0x1EFA424 Offset: 0x1EFA424 VA: 0x1EFA424
		public bool CreateLayout(string pathLayout, string[] pathUvlist, FontInfo fontInfo, out Layout layout, ref TexUVListManager uvMan)
		{
			layout = new Layout();
			if(uvMan == null)
				uvMan = new TexUVListManager();
			ScriptableLayout sl = GetAsset<ScriptableLayout>(pathLayout);
			byte[] bytes = GetBytes(pathLayout);
			if(bytes != null || sl != null)
			{
				for(int i = 0; i < pathUvlist.Length; i++)
				{
					TexUVList uvList = GetTexUVList(pathUvlist[i]);
					if(uvList != null)
					{
						uvMan.Add(uvList, null);
					}
					else
					{
						byte[] uvListByte = GetBytes(pathUvlist[i]);
						if(uvListByte == null)
							return false;
						uvMan.Add(uvListByte, null);
					}
				}
				layout.fontInfo = fontInfo;
				if(sl != null)
				{
					sl.Deserialize(layout);
				}
				else
				{
					layout.LoadFromBytes(bytes);
				}
				layout.SettingTexture(uvMan);
				return true;
			}
			return false;
		}

		// // RVA: 0x1EFA784 Offset: 0x1EFA784 VA: 0x1EFA784
		public int SettingAnimation(Layout layout, string path)
		{
			LayoutAnimationLoader animLoader = GetAnimLoader(path);
			if(animLoader != null)
			{
				return animLoader.SettingAnimation(layout);
			}
			return 0;
		}
	}
}
