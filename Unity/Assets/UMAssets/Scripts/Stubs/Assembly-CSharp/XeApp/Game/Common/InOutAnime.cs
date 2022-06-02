using UnityEngine;

namespace XeApp.Game.Common
{
	public class InOutAnime : MonoBehaviour
	{
		public enum InType
		{
			Left = 0,
			Right = 1,
			Top = 2,
			Bottom = 3,
			Scaling = 4,
			ScalingVertical = 5,
			ScalingSide = 6,
			Height = 7,
		}

		public enum State
		{
			None = 0,
			Leave = 1,
			Enter = 2,
		}

		[SerializeField]
		private InType inType;
		[SerializeField]
		private AnimationCurve curve;
		[SerializeField]
		private float animTime;
		[SerializeField]
		private int moveAmount;
		[SerializeField]
		private State state;
	}
}
