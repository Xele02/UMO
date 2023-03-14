using UnityEngine;

namespace XeSys.Gfx
{
	public class XeMeshSpriteManager : MonoBehaviour
	{
		[SerializeField]
		private XeMeshSpriteObject meshSpritePrefab;
		private void Awake()
		{
			TodoLogger.Log(0, "Implement Monobehaviour");
		}
	}
}
