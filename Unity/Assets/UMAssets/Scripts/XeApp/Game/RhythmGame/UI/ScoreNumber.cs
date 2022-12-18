using UnityEngine;
using XeApp.Game.UI;

namespace XeApp.Game.RhythmGame.UI
{
	public class ScoreNumber : MonoBehaviour
	{
		[SerializeField]
		private NumericMeshMultiPolygon m_numericMesh; // 0xC

		// RVA: 0x1562D94 Offset: 0x1562D94 VA: 0x1562D94
		public void SetValue(int value, int type)
		{
			m_numericMesh.SetNumber(value, type);
		}
	}
}
