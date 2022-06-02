using UnityEngine;

namespace XeApp.Game.Common
{
	public class MikeStandObject : MonoBehaviour
	{
		public float[] HightScaleFactor;
		public float[] AdjustScaleFactor;
		public float[] AdjustRotationFactor;
		public Animator animator;
		[SerializeField]
		private Transform scaleAsjustPoint;
		[SerializeField]
		private Transform hightAsjustPoint;
		[SerializeField]
		private Transform mikeAttachPoint;
	}
}
