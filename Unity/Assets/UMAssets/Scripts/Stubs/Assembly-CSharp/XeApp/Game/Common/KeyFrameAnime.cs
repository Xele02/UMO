using UnityEngine;
using System;

namespace XeApp.Game.Common
{
	public class KeyFrameAnime : MonoBehaviour
	{
		[Serializable]
		public class KeyFrame
		{
			public Sprite sprite;
			public float time;
			public Vector2 pos;
			public float angle;
			public Vector2 scale;
			public Color color;
			public bool lerp;
		}

		public enum PlayType
		{
			Loop = 0,
			Once = 1,
		}

		[SerializeField]
		protected PlayType m_playType;
		[SerializeField]
		protected bool m_autoAnime;
		[SerializeField]
		protected bool m_smoothSeams;
		[SerializeField]
		protected Component m_image;
		[SerializeField]
		protected KeyFrameAnime m_syncAnime;
		[SerializeField]
		protected int m_playIndex;
		[SerializeField]
		protected KeyFrame[] m_animeTable;
	}
}
