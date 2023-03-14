using UnityEngine;

namespace XeApp.Game.Common
{
	public class GachaDirectionCamera : GachaDirectionAnimSetBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private Camera m_camera;
	}
}
