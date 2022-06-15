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
		public int id { get; set; } // 0x8
		public TouchState state { get; set; } // 0xC
		public float time { get; set; } // 0x10
		public Vector3 position { get; set; } // 0x14
		public Vector3 appPosition { get; set; } // 0x20
		public Vector3 nativePosition { get; set; } // 0x2C
		// public float x { get; }
		// public float y { get; }
		// public bool isBegan { get; }
		// public bool isMoved { get; }
		// public bool isEnded { get; }
		// public bool isIllegal { get; }

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
		public TouchInfo()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x23A66EC Offset: 0x23A66EC VA: 0x23A66EC
		// public void Initialize() { }

		// // RVA: 0x23A67D4 Offset: 0x23A67D4 VA: 0x23A67D4
		// public void Copy(TouchInfo src) { }

		// // RVA: 0x23A68A0 Offset: 0x23A68A0 VA: 0x23A68A0
		// public void Setup(int id, TouchState state, Vector3 pos) { }
	}
}
