using System.Collections;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutObjectCacheUtility
	{
		private static readonly string[] m_prefabNameTbl = new string[1] { "root_set_deck_layout_root" }; // 0x0
		private static readonly int[] m_prefabPoolCount = new int[1] { 1 }; // 0x4

		// [IteratorStateMachineAttribute] // RVA: 0x6E7AEC Offset: 0x6E7AEC VA: 0x6E7AEC
		// RVA: 0x15CFB4C Offset: 0x15CFB4C VA: 0x15CFB4C
		public static IEnumerator InitializeLayoutUnitSetting(MonoBehaviour mb)
		{
			int reqCount; // 0x18

			//0x15CFD7C
			int loadCount = 0;
			reqCount = 0;
			for(int i = 0; i < m_prefabNameTbl.Length; i++)
			{
				if(GameManager.Instance.LayoutObjectCache.IsLoadedObject(m_prefabNameTbl[i]))
				{
					loadCount++;
				}
				else
				{
					mb.StartCoroutineWatched(GameManager.Instance.LayoutObjectCache.Create("ly/013.xab", m_prefabNameTbl[i], "ly/tx/013.xab", m_prefabPoolCount[i], () =>
					{
						//0x15CFD68
						loadCount++;
					}));
					reqCount++;
				}
			}
			while(loadCount < reqCount)
				yield return null;
		}
	}
}
