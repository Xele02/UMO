using UnityEngine;

namespace XeApp.Game.UI
{
	public class NumericMeshMultiPolygon : MonoBehaviour
	{
		[SerializeField]
		private MeshFilter meshFilter;
		[SerializeField]
		private GameObject rootObject;
		[SerializeField]
		private int uvXAdvance;
		[SerializeField]
		private int uvYAdvance;
		[SerializeField]
		private int lineCount;
		[SerializeField]
		private bool isZeroPadding;
		[SerializeField]
		private bool useSpecialCaracter;
		[SerializeField]
		private bool isCentering;
		[SerializeField]
		private int specialCaracterColumn;
		[SerializeField]
		private int specialCaracterRow;
	}
}
