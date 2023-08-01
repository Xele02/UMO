using System;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class CutinJoinDiva : MonoBehaviour, IDisposable
	{
		public void Dispose()
		{
			throw new NotImplementedException();
		}

		private void Awake()
		{
			TodoLogger.LogError(0, "Implement Monobehaviour");
		}
	}
}
