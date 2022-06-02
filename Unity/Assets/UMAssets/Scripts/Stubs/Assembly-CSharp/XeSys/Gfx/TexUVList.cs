using UnityEngine;
using System.Collections.Generic;

namespace XeSys.Gfx
{
	public class TexUVList : ScriptableObject
	{
		[SerializeField]
		private string m_name;
		[SerializeField]
		private int m_width;
		[SerializeField]
		private int m_height;
		[SerializeField]
		private float m_uScale;
		[SerializeField]
		private float m_vScale;
		[SerializeField]
		private List<TexUVData> m_serializeDatas;
	}
}
