using System;
using UnityEngine;

public class CriAtomEx
{
	[Serializable]
	public struct Randomize3dConfig
	{
		public Randomize3dConfig(int dummy) : this()
		{
		}

		[SerializeField]
		private bool followsOriginalSource;
		[SerializeField]
		private CriAtomEx.Randomize3dCalcType calculationType;
		[SerializeField]
		private float[] calculationParameters;
	}

	public enum Randomize3dCalcType
	{
		None = -1,
		Rectangle = 0,
		Cuboid = 1,
		Circle = 2,
		Cylinder = 3,
		Sphere = 4,
		List = 6,
	}

	public enum SoundRendererType
	{
		Default = 0,
		Native = 1,
		Asr = 2,
		Hw1 = 1,
		Hw2 = 9,
	}

}
