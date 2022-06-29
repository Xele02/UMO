using UnityEngine;
using System.Collections.Generic;

namespace XeSys.Gfx
{
	public class ScriptableLayout : ScriptableObject
	{
		[SerializeField]
		private List<SerializableView> serializableViews; // 0xC

		public int ViewsCount { get {
			if(serializableViews != null)
				return serializableViews.Count;
			return 0;
		} } //0x1F02A7C

		// // RVA: 0x1F1119C Offset: 0x1F1119C VA: 0x1F1119C
		// public void Serialize(Layout layout) { }

		// // RVA: 0x1EFA7B4 Offset: 0x1EFA7B4 VA: 0x1EFA7B4
		public void Deserialize(Layout layout)
		{
			if(serializableViews.Count < 1)
				return;

			serializableViews[0].Deserialize(serializableViews, layout);
		}
	}
}
