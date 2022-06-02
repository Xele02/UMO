using UnityEngine;
using System;

namespace XeSys
{
	public class RotationLinker : MonoBehaviour
	{
		[Serializable]
		public struct AxisData
		{
			public AxisData(RotationLinker.TargetAxis src, float bias, float min, float max, float preoffset, float postoffset) : this()
			{
			}

			public RotationLinker.TargetAxis src;
			public float bias;
			public float min;
			public float max;
			public float preoffset;
			public float postoffset;
		}

		public enum TargetAxis
		{
			X = 0,
			Y = 1,
			Z = 2,
		}

		public Transform from;
		public Transform to;
		public float xy;
		public float yz;
		public float xz;
		public AxisData adX;
		public AxisData adY;
		public AxisData adZ;
	}
}
