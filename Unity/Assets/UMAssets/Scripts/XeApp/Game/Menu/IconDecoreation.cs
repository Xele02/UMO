
namespace XeApp.Game.Menu
{ 
	public static class IconDecoreation
	{
		// RVA: 0x13DB2FC Offset: 0x13DB2FC VA: 0x13DB2FC
		public static bool IsValidSceneId(int sceneId)
		{
			return 0 < sceneId;
		}

		// RVA: 0x13DB310 Offset: 0x13DB310 VA: 0x13DB310
		public static int GetSceneId(int sceneId)
		{
			return sceneId - 1;
		}

		// RVA: 0x13DB318 Offset: 0x13DB318 VA: 0x13DB318
		//public static void SetNumber(RawImageEx[] images, TexUVListManager uvMan, string[] uvNames, int value, int digit, bool isZeroVisible = False) { }
	}
}
