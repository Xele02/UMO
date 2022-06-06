using UnityEngine;

namespace XeSys
{
	public enum TouchState
	{
		BEGAN = 0,
		ENDED = 1,
		MOVED = 2,
		ILLEGAL = 3,
	}

	public class TouchInfo
	{
		// [CompilerGeneratedAttribute] // RVA: 0x652E3C Offset: 0x652E3C VA: 0x652E3C
		// private int <id>k__BackingField; // 0x8
		// [CompilerGeneratedAttribute] // RVA: 0x652E4C Offset: 0x652E4C VA: 0x652E4C
		// private TouchState <state>k__BackingField; // 0xC
		// [CompilerGeneratedAttribute] // RVA: 0x652E5C Offset: 0x652E5C VA: 0x652E5C
		// private float <time>k__BackingField; // 0x10
		// [CompilerGeneratedAttribute] // RVA: 0x652E6C Offset: 0x652E6C VA: 0x652E6C
		// private Vector3 <position>k__BackingField; // 0x14
		// [CompilerGeneratedAttribute] // RVA: 0x652E7C Offset: 0x652E7C VA: 0x652E7C
		// private Vector3 <appPosition>k__BackingField; // 0x20
		// [CompilerGeneratedAttribute] // RVA: 0x652E8C Offset: 0x652E8C VA: 0x652E8C
		// private Vector3 <nativePosition>k__BackingField; // 0x2C

		public int id { get; set; }
		public TouchState state { get; set; }
		public float time { get; set; }
		public Vector3 position { get; set; }
		public Vector3 appPosition { get; set; }
		public Vector3 nativePosition { get; set; }
		public float x { get; }
		public float y { get; }
		public bool isBegan { get; }
		public bool isMoved { get; }
		public bool isEnded { get; }
		public bool isIllegal { get; }

		// Methods

		// // RVA: 0x23A0454 Offset: 0x23A0454 VA: 0x23A0454
		// public float get_x() { }

		// // RVA: 0x23A045C Offset: 0x23A045C VA: 0x23A045C
		// public float get_y() { }

		// // RVA: 0x23A6690 Offset: 0x23A6690 VA: 0x23A6690
		// public bool get_isBegan() { }

		// // RVA: 0x23A66A4 Offset: 0x23A66A4 VA: 0x23A66A4
		// public bool get_isMoved() { }

		// // RVA: 0x2389C4C Offset: 0x2389C4C VA: 0x2389C4C
		// public bool get_isEnded() { }

		// // RVA: 0x23A66B8 Offset: 0x23A66B8 VA: 0x23A66B8
		// public bool get_isIllegal() { }

		// // RVA: 0x23A66CC Offset: 0x23A66CC VA: 0x23A66CC
		// public void .ctor() { }

		// // RVA: 0x23A66EC Offset: 0x23A66EC VA: 0x23A66EC
		// public void Initialize() { }

		// // RVA: 0x23A67D4 Offset: 0x23A67D4 VA: 0x23A67D4
		// public void Copy(TouchInfo src) { }

		// // RVA: 0x23A68A0 Offset: 0x23A68A0 VA: 0x23A68A0
		// public void Setup(int id, TouchState state, Vector3 pos) { }
	}
}
