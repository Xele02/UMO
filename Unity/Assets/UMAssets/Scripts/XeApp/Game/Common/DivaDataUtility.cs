using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class DivaDataUtility
	{
		// RVA: 0x1BE8C7C Offset: 0x1BE8C7C VA: 0x1BE8C7C
		public static GCIJNCFDNON_SceneInfo GetSceneData(FFHPBEPOMAK_DivaInfo diva, List<GCIJNCFDNON_SceneInfo> sceneList, int sceneSlotIndex)
		{
			if(sceneSlotIndex == 0)
			{
				if(diva.FGFIBOBAPIA_SceneId < 1)
					return null;
				return sceneList[diva.FGFIBOBAPIA_SceneId - 1];
			}
			else
			{
				if(diva.DJICAKGOGFO_SubSceneIds[sceneSlotIndex - 1] < 1)
					return null;
				return sceneList[diva.DJICAKGOGFO_SubSceneIds[sceneSlotIndex - 1] - 1];
			}
		}

	}
}
