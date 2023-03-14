using System;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class SnsScreen : MonoBehaviour, IDisposable
	{
		public void Dispose()
		{
			throw new NotImplementedException();
		}

		private void Awake()
		{
			TodoLogger.Log(0, "Implement Monobehaviour");
		}
	}
}
