using XeApp.Game.Menu;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class MenuDivaObject : DivaObject
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private MenuDivaGazeControl.Data gazeControlData;
	}
}
