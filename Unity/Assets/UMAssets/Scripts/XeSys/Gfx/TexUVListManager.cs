using System.Collections;
using UnityEngine;

namespace XeSys.Gfx
{
	public class TexUVListManager
	{
		private TexUVList[] m_ListList; // 0x8
		private int m_count; // 0xC

		// public int Count { get; } 0x1EE1258
		// public TexUVList this[int index] { get; } 0x1EE1260
		// public bool IsClear { get; } 0x1EE12A8

		// RVA: 0x1EE116C Offset: 0x1EE116C VA: 0x1EE116C
		public TexUVListManager()
		{
			m_ListList = new TexUVList[1];
		}

		// RVA: 0x1EE11E0 Offset: 0x1EE11E0 VA: 0x1EE11E0
		public TexUVListManager(int count)
		{
			m_ListList = new TexUVList[count];
		}

		// // RVA: 0x1EE13B8 Offset: 0x1EE13B8 VA: 0x1EE13B8
		// public void Clear() { }

		// // RVA: 0x1EE1480 Offset: 0x1EE1480 VA: 0x1EE1480
		private void Reserve(int count)
		{
			if(count <= m_ListList.Length)
				return;
			
			TexUVList[] newList = new TexUVList[count];
			for(int i = 0; i < m_ListList.Length; i++)
			{
				newList[i] = m_ListList[i];
			}
			m_ListList = newList;
		}

		// // RVA: 0x1EE15D4 Offset: 0x1EE15D4 VA: 0x1EE15D4
		private void Add(TexUVList list)
		{
			if(m_ListList.Length == m_count)
			{
				Reserve(m_ListList.Length * 2);
			}
			m_ListList[m_count] = list;
			m_count++;
		}

		// // RVA: 0x1EE16A8 Offset: 0x1EE16A8 VA: 0x1EE16A8
		public void Add(byte[] uvList, Texture2D texture)
		{
			TexUVList list = TexUVList.NewInstance();
			list.Initialize(uvList, texture);
			Add(list);
		}

		// [ObsoleteAttribute] // RVA: 0x692458 Offset: 0x692458 VA: 0x692458
		// // RVA: 0x1EE16F4 Offset: 0x1EE16F4 VA: 0x1EE16F4
		// public void Initialize(byte[] uvList, Texture2D texture) { }

		// // RVA: 0x1EE16F8 Offset: 0x1EE16F8 VA: 0x1EE16F8
		public void Add(TexUVList uvList, Texture2D texture)
		{
			uvList.Initialize(texture);
			Add(uvList);
		}

		// // RVA: 0x1EE1730 Offset: 0x1EE1730 VA: 0x1EE1730
		public void Register(int index, TexUVList uvList)
		{
			if(uvList == null)
				UnityEngine.Debug.LogError("Registering a TexUVList null");
			Reserve(index + 1);
			if(m_count <= index)
				m_count = index + 1;
			m_ListList[index] = uvList;
		}

		// // RVA: 0x1EE17C8 Offset: 0x1EE17C8 VA: 0x1EE17C8
		public bool CheckRegistration(int count)
		{
			if(count <= m_ListList.Length)
			{
				for(int i = 0; i < count; i++)
				{
					if(m_ListList[i] == null)
						return false;
				}
				return true;
			}
			return false;
		}

		// // RVA: 0x1EE18DC Offset: 0x1EE18DC VA: 0x1EE18DC
		// public bool LoadAsset(string path, Texture2D texture) { }

		// // RVA: 0x1EE18F8 Offset: 0x1EE18F8 VA: 0x1EE18F8
		// public bool LoadAsset(string path, Texture2D texture, bool loadXml) { }

		// // RVA: 0x1EE1A5C Offset: 0x1EE1A5C VA: 0x1EE1A5C
		public ResourceRequest LoadAssetAsync(string path)
		{
			return Resources.LoadAsync<TexUVList>(path);
		}

		// // RVA: 0x1EE1AC0 Offset: 0x1EE1AC0 VA: 0x1EE1AC0
		public ResourceRequest LoadTextAsync(string path)
		{
			return Resources.LoadAsync<TextAsset>(path);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x69248C Offset: 0x69248C VA: 0x69248C
		// // RVA: 0x1EE1B24 Offset: 0x1EE1B24 VA: 0x1EE1B24
		private IEnumerator LoadAssetAsync(int index, ResourceRequest req, string path, Texture2D texture)
		{
			//0x1EE2300
			UnityEngine.Debug.Log("Enter LoadAssetAsync "+path);
			while(!req.isDone)
			{
				yield return null;
			}
			TexUVList data = req.asset as TexUVList;
			if(data != null)
			{
				Register(index, data);
				UnityEngine.Debug.Log("Exit 2 LoadAssetAsync "+path+" "+data);
				yield break;
			}
			req = LoadTextAsync(path);
			while(!req.isDone)
			{
				yield return null;
			}
			TextAsset asset = req.asset as TextAsset;
			data = TexUVList.NewInstance();
			if(asset != null)
			{
				data.Initialize(asset.bytes, texture);
			}
			Register(index, data);
			UnityEngine.Debug.Log("Exit LoadAssetAsync "+path+" "+data);
		}

		// // RVA: 0x1EE1C3C Offset: 0x1EE1C3C VA: 0x1EE1C3C
		public IEnumerator LoadAssetAsync(int index, string path, Texture2D texture)
		{
			return LoadAssetAsync(index, LoadAssetAsync(path), path, texture);
		}

		// // RVA: 0x1EE1C80 Offset: 0x1EE1C80 VA: 0x1EE1C80
		// public TexUVListManager.LoadAssetResult InitAssetAsync(ResourceRequest request, Texture2D texture) { }

		// // RVA: 0x1EE1ED4 Offset: 0x1EE1ED4 VA: 0x1EE1ED4
		// public ResourceRequest LoadAssetAsync(string path, bool loadXml) { }

		// // RVA: 0x1EE2028 Offset: 0x1EE2028 VA: 0x1EE2028
		public TexUVData GetUVData(string key)
		{
			for(int i = 0; i < m_count; i++)
			{
				if(m_ListList[i] == null)
				{
					UnityEngine.Debug.LogError("GetUVData list is null. key is "+key);
					return null;
				}
				TexUVData res = m_ListList[i].GetUVData(key);
				if(res != null)
					return res;
			}
			return null;
		}

		// // RVA: 0x1EE21A4 Offset: 0x1EE21A4 VA: 0x1EE21A4
		public TexUVData GetTextureData(string key, out TexUVList texUVList)
		{
			texUVList = null;
			for(int i = 0; i < m_count; i++)
			{
				TexUVData data = m_ListList[i].GetUVData(key);
				if(data != null)
				{
					texUVList = m_ListList[i];
					return data;
				}
			}
			return null;
		}

		// // RVA: 0x1EE224C Offset: 0x1EE224C VA: 0x1EE224C
		public TexUVList GetTexUVList(string texName)
		{
			for(int i = 0; i < m_ListList.Length; i++)
			{
				if(m_ListList[i].name == texName)
					return m_ListList[i];
			}
			return null;
		}
	}
}
