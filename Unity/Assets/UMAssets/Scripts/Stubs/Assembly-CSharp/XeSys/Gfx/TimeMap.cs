using System;
using UnityEngine;

namespace XeSys.Gfx
{
	[Serializable]
	public class TimeMap
	{
		public TimeMap(int count)
		{
		}

		[SerializeField]
		private TimeMapData[] m_DataList;
	}
}
