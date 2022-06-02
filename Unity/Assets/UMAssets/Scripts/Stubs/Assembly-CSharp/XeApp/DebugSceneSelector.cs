using System;
using System.Collections.Generic;

namespace XeApp
{
	[Serializable]
	public class DebugSceneSelector
	{
		public int x;
		public int y;
		public int buttonWidth;
		public int buttonHeight;
		public List<DebugSceneInfo> sceneList;
	}
}
