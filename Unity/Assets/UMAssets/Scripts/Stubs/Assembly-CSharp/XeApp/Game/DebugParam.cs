using XeSys;
using System.Collections.Generic;

namespace XeApp.Game
{
	public class DebugParam : Singleton<DebugParam>
	{
		public int menu_divaId;
		public int menu_divaModelId;
		public float menu_divaTimeTalkInterval;
		public float menu_divaTimeTalkElapsed;
		public bool menu_musicAllOpen;
		public bool menu_SLiveOpen;
		public bool menu_UnitLiveOpen;
		public bool menu_musicLine6Open;
		public bool menu_musicLine6OpenPopupTest;
		public int loginBonusParam;
		public int loginBonusComeback;
		public List<int> recordPlateIds;
		public List<int> recordPlateCounts;
		public bool recordPlateAllReceive;
		public bool isSnsSave;
		public bool isSnsAllText;
	}
}
