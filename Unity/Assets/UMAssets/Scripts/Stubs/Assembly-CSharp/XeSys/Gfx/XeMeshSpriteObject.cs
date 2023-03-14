using UnityEngine;

namespace XeSys.Gfx
{
	public class XeMeshSpriteObject : MonoBehaviour
	{
		[SerializeField]
		private Material[] materialPrefab;
		private void Awake()
		{
			TodoLogger.Log(0, "Implement Monobehaviour");
		}
	}
}
