using XeApp.Core;
using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
	public class BattleEvaluateObjectPool : Pool<BattleEvaluateObject>
	{

		// RVA: 0x15599B4 Offset: 0x15599B4 VA: 0x15599B4
		public void Initialize(GameObject parent, BattleEvaluateObject prefab, bool isValkyrieOff)
		{
			Create("", parent, prefab, 16, false);
			if(isValkyrieOff)
			{
				BattleEvaluateObject[] bs = parent.GetComponentsInChildren<BattleEvaluateObject>(true);
				for(int i = 0; i < bs.Length; i++)
				{
					bs[i].SetValkyrieOffPriority();
				}
			}
		}
	}
}
