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

		// [TooltipAttribute] // RVA: 0x661040 Offset: 0x661040 VA: 0x661040
		[SerializeField]
		private MusicDirectionBoolParam.DirectionType[] m_directionTypeList; // 0xC

		// RVA: 0xC933C0 Offset: 0xC933C0 VA: 0xC933C0
		public bool IsEnabledDirection(MusicDirectionBoolParam.DirectionType type) 
		{
			if(m_directionTypeList != null)
			{
				for(int i = 0; i < m_directionTypeList.Length; i++)
				{
					if(m_directionTypeList[i] == type)
						return true;
				}
			}
			return false;
		}
	}
}
