using UnityEngine;
using System;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class EventGoDivaCamera : MonoBehaviour
	{
		[Serializable]
		private struct OffsetSetting
		{
			public int targetDiva;
			public Vector3 pos;
		}

		[SerializeField]
		private List<EventGoDivaCamera.OffsetSetting> m_offsetSettings;
	}
}
