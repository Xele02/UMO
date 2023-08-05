using UnityEngine;
using System.Collections.Generic;

namespace XeSys
{
	public class FileResultObject
	{
		public string path { get; set; } // 0x8
		public Dictionary<string, string> args { get; set; } // 0xC
		public int argValue { get; set; } // 0x10
		public int pathHashCode { get; set; } // 0x14
		public bool dispose { get; set; } // 0x18
		public string error { get; set; } // 0x1C
		public Object unityObject { get; set; } // 0x20
		public byte[] bytes { get; set; } // 0x24
		public Texture2D texture { get; set; } // 0x28
		public AssetBundle assetBundle { get; set; } // 0x2C

		// // RVA: 0x203D1E4 Offset: 0x203D1E4 VA: 0x203D1E4
		public FileResultObject() : this(null, null, 0)
		{
			return;
		}

		// // RVA: 0x203D208 Offset: 0x203D208 VA: 0x203D208
		public FileResultObject(string path) : this(path, null, 0)
		{
			return;
		}

		// // RVA: 0x203CDA0 Offset: 0x203CDA0 VA: 0x203CDA0
		public FileResultObject(string path_, Dictionary<string, string> args_, int argValue_)
		{
			dispose = false;
			path = path_;
			args = args_;
			argValue = argValue_;
			unityObject = null;
			texture = null;
			pathHashCode = path.GetHashCode();
			error = null;
		}
	}
}
