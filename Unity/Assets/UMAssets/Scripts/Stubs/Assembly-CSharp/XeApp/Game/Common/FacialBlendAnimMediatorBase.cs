using UnityEngine;

namespace XeApp.Game.Common
{
	public class FacialBlendAnimMediatorBase : MonoBehaviour
	{
		public Transform eyeLookUTransforms;
		public Transform eyeLookVTransforms;
		[SerializeField]
		private SkinnedMeshRenderer eyeMeshRenderer;
		[SerializeField]
		private SkinnedMeshRenderer cheekMeshRenderer;
	}
}
