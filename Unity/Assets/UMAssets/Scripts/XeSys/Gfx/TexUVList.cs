using UnityEngine;
using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;

namespace XeSys.Gfx
{
	public class TexUVList : ScriptableObject, ISerializationCallbackReceiver
	{
		private Texture2D m_Texture; // 0xC
		[SerializeField]
		private string m_name; // 0x10
		[SerializeField]
		private int m_width; // 0x14
		[SerializeField]
		private int m_height; // 0x18
		[SerializeField]
		private float m_uScale; // 0x1C
		[SerializeField]
		private float m_vScale; // 0x20
		[SerializeField]
		private List<TexUVData> m_serializeDatas = new List<TexUVData>(); // 0x24
		private Dictionary<string, TexUVData> m_UVDataDictionary = new Dictionary<string, TexUVData>(); // 0x28

		// public Texture2D Tex { get; } 0x1EE05A8
		public new string name { get { return m_name; } } //0x1EE05B0
		public int width { get { return m_width; } } //0x1EE05B8
		public int height { get { return m_height; } } //0x1EE05C0

		// // RVA: 0x1EE0688 Offset: 0x1EE0688 VA: 0x1EE0688
		public static TexUVList NewInstance()
		{
			return CreateInstance<TexUVList>();
		}

		// // RVA: 0x1EE06E4 Offset: 0x1EE06E4 VA: 0x1EE06E4
		private void ReadUVList(byte[] uvListBytes)
		{
			ReadUVList(Encoding.ASCII.GetString(uvListBytes));
		}

		// // RVA: 0x1EE0738 Offset: 0x1EE0738 VA: 0x1EE0738
		private void ReadUVList(string uvListText)
		{
			m_UVDataDictionary.Clear();
			char[] ch = new char[1];
			ch[0] = '\n';
			string[] strs = uvListText.Split(ch);
			for(int i = 0; i < strs.Length; i++)
			{
				if(strs[i].Length > 0)
				{
					ch[0] = ',';
					string[] strs2 = strs[i].Split(ch);
					if(i == 0)
					{
						m_name = strs2[0];
						m_width = Int32.Parse(strs2[1]);
						m_height = Int32.Parse(strs2[2]);
						m_uScale = 1.0f;
						m_vScale = 1.0f;
					}
					else
					{
						TexUVData data = new TexUVData();
						data.name = strs2[0];
						data.u = Single.Parse(strs2[1]) * m_uScale / m_width;
						data.v = Single.Parse(strs2[2]) * m_vScale / m_height;
						data.width = Single.Parse(strs2[3]) * m_uScale / m_width;
						data.height = Single.Parse(strs2[4]) * m_vScale / m_height;
						m_UVDataDictionary.Add(data.name, data);
					}
				}
			}
		}

		// // RVA: 0x1EE0B94 Offset: 0x1EE0B94 VA: 0x1EE0B94
		public void Initialize(byte[] bytes, Texture2D texture)
		{
			m_Texture = texture;
			ReadUVList(bytes);
		}

		// // RVA: 0x1EE0B9C Offset: 0x1EE0B9C VA: 0x1EE0B9C
		public void Initialize(Texture2D texture)
		{
			m_Texture = texture;
		}

		// // RVA: 0x1EE0BA4 Offset: 0x1EE0BA4 VA: 0x1EE0BA4
		// private void AttachFilterMode(Texture2D texture, string path) { }

		// // RVA: 0x1EE0C48 Offset: 0x1EE0C48 VA: 0x1EE0C48
		// public void InitOneTexture(Texture2D tex, string name) { }

		// // RVA: 0x1EE0DF4 Offset: 0x1EE0DF4 VA: 0x1EE0DF4
		// public void Clear() { }

		// // RVA: 0x1EE0E74 Offset: 0x1EE0E74 VA: 0x1EE0E74
		public TexUVData GetUVData(string key)
		{
			if(m_UVDataDictionary.ContainsKey(key))
			{
				return m_UVDataDictionary[key];
			}
			return null;
		}

		// // RVA: 0x1EE0F34 Offset: 0x1EE0F34 VA: 0x1EE0F34 Slot: 5
		public void OnAfterDeserialize()
		{
			m_UVDataDictionary.Clear();
			for(int i = 0; i < m_serializeDatas.Count; i++)
			{
				m_UVDataDictionary.Add(m_serializeDatas[i].name, m_serializeDatas[i]);
			}
		}

		// // RVA: 0x1EE1094 Offset: 0x1EE1094 VA: 0x1EE1094 Slot: 4
		public void OnBeforeSerialize()
		{
			m_serializeDatas.Clear();
			m_serializeDatas.AddRange(m_UVDataDictionary.Values);
		}

		public List<string> GetKeys()
		{
			return m_UVDataDictionary.Keys.ToList();
		}
	}
}
