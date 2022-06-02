using UnityEngine;

namespace XeApp.Game
{
	public class MusicDirectionBoolParam : ScriptableObject
	{
		public enum DirectionType
		{
			None = -1,
			DivaAdjustXZ = 0,
		}

		[SerializeField]
		private DirectionType[] m_directionTypeList;
	}
}
