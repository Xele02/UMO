using UnityEngine;
using System.Collections.Generic;

namespace XeSys.Gfx
{
	public class ScriptableLayout : ScriptableObject
	{
		[SerializeField]
		private List<SerializableView> serializableViews;
	}
}
