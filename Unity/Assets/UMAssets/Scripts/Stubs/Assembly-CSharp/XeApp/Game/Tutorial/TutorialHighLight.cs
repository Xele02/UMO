using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Tutorial
{
	public class TutorialHighLight : MonoBehaviour, IMeshModifier
	{
		[SerializeField]
		private Rect _highLightRect;

		public void ModifyMesh(Mesh mesh)
		{
			//throw new System.NotImplementedException();
		}

		public void ModifyMesh(VertexHelper verts)
		{
			//throw new System.NotImplementedException();
		}

		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement Monobehaviour");
		}
	}
}
