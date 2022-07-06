using UnityEngine;

namespace XeApp.Game.Common
{
	public class UGUIObject
	{
		public GameObject instanceObject { get; private set; } // 0x8

		//// RVA: 0x1CD92B8 Offset: 0x1CD92B8 VA: 0x1CD92B8
		public UGUIObject(GameObject instance)
		{
			instanceObject = instance;
		}

		//// RVA: 0x1CD92D8 Offset: 0x1CD92D8 VA: 0x1CD92D8
		public void SetParent(Transform positionParent, Transform hierarchyParent)
		{
			instanceObject.transform.SetParent(positionParent, false);
		}
	}
}
