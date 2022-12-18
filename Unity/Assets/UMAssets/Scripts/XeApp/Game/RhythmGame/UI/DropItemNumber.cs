using UnityEngine;
using XeApp.Game.UI;

namespace XeApp.Game.RhythmGame.UI
{
	public class DropItemNumber : MonoBehaviour
	{
		[SerializeField]
		private NumericMeshMultiPolygon[] m_itemNumericMesh; // 0xC

		// RVA: 0x155AEAC Offset: 0x155AEAC VA: 0x155AEAC
		public void SetValue(int index, int value)
		{
			if(m_itemNumericMesh.Length <= index)
				return;
			m_itemNumericMesh[index].SetNumber(Mathf.Min(value, 99), 0);
		}
	}
}
