using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameExtension
	{
		// RVA: 0xDC64EC Offset: 0xDC64EC VA: 0xDC64EC
		public static GameDivaObject GetDiva(GameDivaObject main, GameDivaObject[] sub, int subDivaNum, int checkDivaId)
		{
			for(int i = 0; i < subDivaNum; i++)
			{
				if (sub[i].divaId == checkDivaId)
					return sub[i];
			}
			return main;
		}

		// RVA: 0xDC65A8 Offset: 0xDC65A8 VA: 0xDC65A8
		public static List<GameDivaObject> GetDivaListOnPositionId(GameDivaObject a_main, GameDivaObject[] a_sub, int a_stage_diva_num)
		{
			List<GameDivaObject> res = new List<GameDivaObject>();
			for(int i = 0; i < a_stage_diva_num; i++)
			{
				if (a_main.positionId == i + 1)
					res.Add(a_main);
				else
				{
					for(int j = 0; j < a_stage_diva_num - 1; j++)
					{
						if(a_sub[j].positionId == i + 1)
						{
							res.Add(a_sub[j]);
						}
					}
				}
			}
			return res;
		}

		// RVA: -1 Offset: -1
		public static void DestroyExtensionList<Type>(ref List<Type> objectList) where Type : Component
		{
			for(int i = 0; i < objectList.Count; i++)
			{
				UnityEngine.Object.Destroy(objectList[i].gameObject);
			}
			objectList.Clear();
		}
		/* GenericInstMethod :
		|
		|-RVA: 0x1AB4CDC Offset: 0x1AB4CDC VA: 0x1AB4CDC
		|-RhythmGameExtension.DestroyExtensionList<object>
		|-RhythmGameExtension.DestroyExtensionList<DivaCutinObject>
		|-RhythmGameExtension.DestroyExtensionList<DivaExtensionObject>
		|-RhythmGameExtension.DestroyExtensionList<MusicCameraCutinObject>
		|-RhythmGameExtension.DestroyExtensionList<StageExtensionObject>
		|-RhythmGameExtension.DestroyExtensionList<StageLightingAddObject>
		|-RhythmGameExtension.DestroyExtensionList<StageLightingObject>
		*/

		// RVA: -1 Offset: -1
		public static void SettingHierarchy<Type>(ref Type extentionObject, string hierarchyPath) where Type : Component
		{
			GameObject go = GameObject.Find("hierarchyPath");
			if(go != null)
			{
				extentionObject.transform.parent = go.transform;
			}
		}
		/* GenericInstMethod :
		|
		|-RVA: 0x1AB4E44 Offset: 0x1AB4E44 VA: 0x1AB4E44
		|-RhythmGameExtension.SettingHierarchy<object>
		|-RhythmGameExtension.SettingHierarchy<DivaCutinObject>
		|-RhythmGameExtension.SettingHierarchy<DivaExtensionObject>
		|-RhythmGameExtension.SettingHierarchy<MusicCameraCutinObject>
		|-RhythmGameExtension.SettingHierarchy<StageExtensionObject>
		|-RhythmGameExtension.SettingHierarchy<StageLightingAddObject>
		|-RhythmGameExtension.SettingHierarchy<StageLightingObject>
		*/
	}
}
