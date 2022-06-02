using System;
using UnityEngine;

namespace XeSys.Gfx
{
	[Serializable]
	public class TexOffsetAnimation
	{
		[SerializeField]
		private int width;
		[SerializeField]
		private int height;
		[SerializeField]
		private int count;
		[SerializeField]
		private float changeTime;
	}
}
