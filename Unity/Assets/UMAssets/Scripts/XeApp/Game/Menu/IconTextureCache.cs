
using System;
using System.IO;
using UnityEngine;
using XeApp.Core;
using XeSys;

namespace XeApp.Game.Menu
{
	public enum IconTextureType
	{
		Texture = 0,
		Material = 1,
	}

	public abstract class IconTextureCache
	{
		private IndexableDictionary<string, IiconTexture> m_iconTextureCache; // 0x8
		private IndexableDictionary<string, IconTextureLodingInfo> m_loadingAssetBundle; // 0xC
		private int m_capacity; // 0x10
		private ulong m_createCount; // 0x18

		// RVA: 0x13DBD3C Offset: 0x13DBD3C VA: 0x13DBD3C
		public IconTextureCache(int capacity = 0)
		{
			m_loadingAssetBundle = new IndexableDictionary<string, IconTextureLodingInfo>();
			m_iconTextureCache = new IndexableDictionary<string, IiconTexture>(capacity);
			m_capacity = capacity;
			m_createCount = 0;
		}

		// // RVA: 0x13DBE18 Offset: 0x13DBE18 VA: 0x13DBE18 Slot: 4
		public virtual void Clear()
		{
			for(int i = 0; i < m_iconTextureCache.Count; i++)
			{
				m_iconTextureCache[i].Release();
			}
			m_iconTextureCache.Clear();
			m_loadingAssetBundle.Clear();
		}

		// // RVA: -1 Offset: -1 Slot: 5
		public abstract void Terminated();

		// // RVA: 0x13DBFC0 Offset: 0x13DBFC0 VA: 0x13DBFC0 Slot: 6
		public virtual void Load(string path, Action<IiconTexture> callBack)
		{
			Load(path, IconTextureType.Texture, callBack);
		}

		// // RVA: 0x13DBFE0 Offset: 0x13DBFE0 VA: 0x13DBFE0
		protected void Load(string path, IconTextureType iconTextureType, Action<IiconTexture> callBack)
		{
			IiconTexture res;
			if(m_iconTextureCache.TryGetValue(path, out res))
			{
				if(m_capacity > 0)
				{
					res.CreateCount = GetCreateCountAndIncrement();
				}
				if(callBack != null)
					callBack(res);
			}
			else
			{
				IconTextureLodingInfo info;
				if(m_loadingAssetBundle.TryGetValue(path, out info))
				{
					info.CallBack += callBack;
				}
				else
				{
					if(m_capacity > 0)
					{
						if(m_iconTextureCache.Count >= m_capacity)
						{
							ulong createCount = m_iconTextureCache[0].CreateCount;
							int idx = 0;
							for(int i = 1; i < m_iconTextureCache.Count; i++)
							{
								if(m_iconTextureCache[i].CreateCount < createCount)
								{
									idx = i;
								}
							}
							m_iconTextureCache.Remove(idx);
						}
					}
					info = new IconTextureLodingInfo(AssetBundleManager.LoadAllAssetAsync(path), path);
					info.CallBack += callBack;
					info.TextureType = iconTextureType;
					m_loadingAssetBundle.Add(path, info);
				}
			}
		}

		// // RVA: 0x13DC6D0 Offset: 0x13DC6D0 VA: 0x13DC6D0
		public void Update()
		{
			for(int i = 0; i < m_loadingAssetBundle.Count; )
			{
				string path = m_loadingAssetBundle.GetKey(i);
				IconTextureLodingInfo info = m_loadingAssetBundle.GetValue(path);
				if(info.Operation.IsDone())
				{
					IiconTexture icon = CreateIconTexture(info);
					if(info.CallBack != null)
						info.CallBack(icon);
					m_iconTextureCache.Add(path, icon);
					m_loadingAssetBundle.Remove(i);
					AssetBundleManager.UnloadAssetBundle(info.Path, false);
				}
				else
				{
					if(info.Operation.IsError())
					{
						TodoLogger.LogError(TodoLogger.Filesystem, "Error loading icon bundle "+info.Path);
						m_loadingAssetBundle.Remove(i);
						AssetBundleManager.UnloadAssetBundle(info.Path, false);
					}
					else
					{
						i++;
					}
				}
			}
		}

		// // RVA: 0x13DC9B4 Offset: 0x13DC9B4 VA: 0x13DC9B4
		public bool IsLoading()
		{
			return m_loadingAssetBundle.Count > 0;
		}

		// // RVA: -1 Offset: -1 Slot: 7
		protected abstract IiconTexture CreateIconTexture(IconTextureLodingInfo info);

		// // RVA: 0x13DCA3C Offset: 0x13DCA3C VA: 0x13DCA3C
		protected void SetupForSplitTexture(IconTextureLodingInfo info, IiconTexture icon)
		{
			string name = Path.GetFileNameWithoutExtension(info.Path);
			icon.Material = new Material(Shader.Find("XeSys/Unlit/SplitTexture"));
			icon.BaseTexture = info.Operation.GetAsset<Texture2D>(name+"_base");
			icon.MaskTexture = info.Operation.GetAsset<Texture2D>(name+"_mask");
			icon.CreateCount = GetCreateCountAndIncrement();
		}

		// // RVA: 0x13DCE74 Offset: 0x13DCE74 VA: 0x13DCE74
		protected void SetupForSplitTexture(IconTextureLodingInfo info, IiconTexture icon, Texture2D maskTexture)
		{
			string name = Path.GetFileNameWithoutExtension(info.Path);
			icon.Material = new Material(Shader.Find("XeSys/Unlit/SplitTexture"));
			icon.BaseTexture = info.Operation.GetAsset<Texture2D>(name);
			icon.MaskTexture = maskTexture;
			icon.CreateCount = GetCreateCountAndIncrement();
		}

		// // RVA: 0x13DD214 Offset: 0x13DD214 VA: 0x13DD214
		protected void SetupForSplitTextureBias(IconTextureLodingInfo info, IiconTexture icon, float mipmapBias)
		{
			string name = Path.GetFileNameWithoutExtension(info.Path);
			icon.Material = new Material(Shader.Find("MCRS/SplitTexture_Bias"));
			icon.Material.SetFloat("_MipmapBias", mipmapBias);
			icon.BaseTexture = info.Operation.GetAsset<Texture2D>(name + "_base");
			icon.MaskTexture = info.Operation.GetAsset<Texture2D>(name + "_mask");
			icon.CreateCount = GetCreateCountAndIncrement();
		}

		// // RVA: 0x13DD70C Offset: 0x13DD70C VA: 0x13DD70C
		protected void SetupForSplitTextureBias(IconTextureLodingInfo info, IiconTexture icon, Texture2D maskTexture, float mipmapBias)
		{
			string name = Path.GetFileNameWithoutExtension(info.Path);
			icon.Material = new Material(Shader.Find("MCRS/SplitTexture_Bias"));
			icon.Material.SetFloat("_MipmapBias", mipmapBias);
			icon.BaseTexture = info.Operation.GetAsset<Texture2D>(name);
			icon.MaskTexture = maskTexture;
			icon.CreateCount = GetCreateCountAndIncrement();
		}

		// // RVA: 0x13DDB7C Offset: 0x13DDB7C VA: 0x13DDB7C
		protected void SetupForSingleTexture(IconTextureLodingInfo info, IiconTexture icon)
		{
			icon.Material = new Material(Shader.Find("XeSys/Unlit/Transparent"));
			icon.BaseTexture = info.Operation.GetAsset<Texture2D>(Path.GetFileNameWithoutExtension(info.Path));
			icon.MaskTexture = null;
			icon.CreateCount = GetCreateCountAndIncrement();
		}

		// // RVA: 0x13DC66C Offset: 0x13DC66C VA: 0x13DC66C
		public ulong GetCreateCountAndIncrement()
		{
			ulong val = m_createCount;
			m_createCount++;
			return val;
		}
	}
}
