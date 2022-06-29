using System.IO;
using System.Text;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace XeSys.Gfx
{
	public class LayoutAnimationLoader
	{
		private List<string> m_animFileList = new List<string>(64); // 0x8
		private List<byte[]> m_dataLayoutAnim = new List<byte[]>(64); // 0xC
		private ILoader m_loader; // 0x10
		private string m_path; // 0x14
		private Action<string> m_callback; // 0x18

		// public bool IsLoading { get; } 0x1EF85B4
		// public int LoadedCount { get; } 0x1EF863C

		// // RVA: 0x1EF7980 Offset: 0x1EF7980 VA: 0x1EF7980
		// public void Clear() { }

		// // RVA: 0x1EF79F8 Offset: 0x1EF79F8 VA: 0x1EF79F8
		public void Load(ILoader loader, string path, Action<string> callback)
		{
			m_path = path;
			m_loader = loader;
			m_callback = callback;
			loader.Load(path, this.LoadedList);
		}

		// // RVA: 0x1EF7B24 Offset: 0x1EF7B24 VA: 0x1EF7B24
		// public void SetList(string path, byte[] listBytes, Action<string> callback) { }

		// // RVA: 0x1EF7F68 Offset: 0x1EF7F68 VA: 0x1EF7F68
		private bool LoadedList(FileResultObject fro)
		{
			UnityEngine.Debug.LogError("Anim loaded : "+fro.path+" error : "+fro.error);
			string list;
			if(fro.unityObject != null)
			{
				list = (fro.unityObject as TextAsset).text;
				UnityEngine.Debug.LogError("Loading anim "+fro.path+" as text asset "+list);
			}
			else
			{
				list = Encoding.ASCII.GetString(fro.bytes);
				UnityEngine.Debug.LogError("Loading anim "+fro.path+" as bytes asset "+list);
			}
			GenerateAnimationFileList(fro.path, list);
			return true;
		}

		// // RVA: 0x1EF7B8C Offset: 0x1EF7B8C VA: 0x1EF7B8C
		private void GenerateAnimationFileList(string path, string list)
		{
			StringBuilder str = new StringBuilder(path.Length);
			str.Append(path);
			string filename = Path.GetFileName(path);
			str.Length = path.Length - filename.Length;
			StringBuilder str2 = new StringBuilder(str.Length + 64);
			StringReader reader = new StringReader(list);
			m_animFileList.Clear();
			while(true)
			{
				string line = reader.ReadLine();
				if(line == null)
					break;
				str2.Clear();
				str2.Append(str);
				str2.Append(line);
				m_animFileList.Add(str2.ToString());
			}
			reader.Dispose();
			LoadAnimationFile();
		}

		// // RVA: 0x1EF816C Offset: 0x1EF816C VA: 0x1EF816C
		private void LoadAnimationFile()
		{
			for(int i = 0; i < m_animFileList.Count; i++)
			{
				m_loader.Load(m_animFileList[i], this.LoadedLayoutAnim);
			}
		}

		// // RVA: 0x1EF8328 Offset: 0x1EF8328 VA: 0x1EF8328
		private bool LoadedLayoutAnim(FileResultObject fro)
		{
			byte[] data = null;
			if(fro.unityObject == null)
			{
				data = fro.bytes;
			}
			else
			{
				data = (fro.unityObject as TextAsset).bytes;
			}

			m_dataLayoutAnim.Add(data);
			if(m_callback != null)
			{
				if(m_dataLayoutAnim.Count == m_animFileList.Count)
				{
					m_animFileList.Clear();
					m_callback(m_path);
				}
			}
			return true;
		}

		// // RVA: 0x1EF86B4 Offset: 0x1EF86B4 VA: 0x1EF86B4
		public int SettingAnimation(Layout layout)
		{
			if(m_dataLayoutAnim.Count < 1)
				return 0;
			LayoutAnimation anim = new LayoutAnimation();
			for(int i = 0; i < m_dataLayoutAnim.Count; i++)
			{
				anim.LoadFromBytes(m_dataLayoutAnim[i]);
			}
			layout.SettingAnimation(anim);
			return m_dataLayoutAnim.Count;
		}
	}
}
