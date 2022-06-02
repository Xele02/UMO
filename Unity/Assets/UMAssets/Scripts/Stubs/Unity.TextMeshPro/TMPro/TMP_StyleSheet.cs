using System;
using UnityEngine;
using System.Collections.Generic;

namespace TMPro
{
	[Serializable]
	public class TMP_StyleSheet : ScriptableObject
	{
		[SerializeField]
		private List<TMP_Style> m_StyleList;
	}
}
