using UnityEngine;
using System.Collections.Generic;

namespace XeSys
{
	public static class InputManagerExtension
	{
		private static List<TouchInfoRecord> touchListTempList = new List<TouchInfoRecord>(6); // 0x0

		// RVA: 0x2389A94 Offset: 0x2389A94 VA: 0x2389A94
		public static bool IsScreenTouch(this InputManager self)
		{
			TouchInfoRecord recordInfo = self.GetFirstInScreenTouchRecord();
			if(recordInfo != null)
			{
				Vector2 startPos = recordInfo.beganInfo.GetSceneInnerPosition();
				Vector2 curPos = recordInfo.currentInfo.GetSceneInnerPosition();
				if(recordInfo.currentInfo.state == TouchState.ENDED)
				{
					if(self.IsTouchPositionInScreen(curPos))
					{
						return self.IsTouchPositionInScreen(startPos);
					}
				}
			}
			return false;
		}
	}
}
