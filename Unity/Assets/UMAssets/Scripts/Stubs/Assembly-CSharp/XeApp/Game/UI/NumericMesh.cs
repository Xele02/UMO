using UnityEngine;

namespace XeApp.Game.UI
{
	public class NumericMesh : MonoBehaviour
	{
		[SerializeField]
		private MeshFilter[] meshFilters;
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
