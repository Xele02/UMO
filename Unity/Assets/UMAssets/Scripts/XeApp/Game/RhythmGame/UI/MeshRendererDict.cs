using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
	public class MeshRendererDict : MonoBehaviour
	{
		private Dictionary<int, MeshRenderer> rendererDict; // 0xC

		// RVA: 0x15624C4 Offset: 0x15624C4 VA: 0x15624C4
		private void Awake()
		{
			rendererDict = new Dictionary<int, MeshRenderer>();
			MeshRenderer[] mrs = GetComponentsInChildren<MeshRenderer>(true);
			for(int i = 0; i < mrs.Length; i++)
			{
				rendererDict.Add(mrs[i].name.GetHashCode(), mrs[i]);
			}
		}

		// RVA: 0x1562650 Offset: 0x1562650 VA: 0x1562650
		public MeshRenderer GetRenderer(int hashCode)
		{
			MeshRenderer res = null;
			rendererDict.TryGetValue(hashCode, out res);
			return res;
		}
	}
}
