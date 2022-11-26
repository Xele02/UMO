using UnityEngine;
using XeSys.Gfx;

namespace XeSys
{
	public enum TouchState
	{
		BEGAN = 0,
		ENDED = 1,
		MOVED = 2,
		ILLEGAL = 3,
	}
	
	public enum TouchSwipeDirection
	{
		None = 0,
		Up = 1,
		Down = 2,
		Left = 3,
		Right = 4,
	}

	public class TouchInfo
	{
		public int id { get; set; } // 0x8
		public TouchState state { get; set; } // 0xC
		public float time { get; set; } // 0x10
		public Vector3 position { get; set; } // 0x14
		public Vector3 appPosition { get; set; } // 0x20
		public Vector3 nativePosition { get; set; } // 0x2C
		// public float x { get; } 0x23A0454
		// public float y { get; } 0x23A045C
		public bool isBegan { get { return state == TouchState.BEGAN; } } //0x23A6690
		// public bool isMoved { get; } 0x23A66A4
		public bool isEnded { get { return state == TouchState.ENDED; } } //0x2389C4C
		public bool isIllegal { get { return state == TouchState.ILLEGAL; } } //0x23A66B8

		// // RVA: 0x23A66CC Offset: 0x23A66CC VA: 0x23A66CC
		public TouchInfo()
		{
			Initialize();
		}

		// // RVA: 0x23A66EC Offset: 0x23A66EC VA: 0x23A66EC
		public void Initialize()
		{
			state = TouchState.ILLEGAL;
			id = -1;
			time = 0.0f;
			position = Vector3.zero;
			appPosition = Vector3.zero;
			nativePosition = Vector3.zero;
		}

		// // RVA: 0x23A67D4 Offset: 0x23A67D4 VA: 0x23A67D4
		public void Copy(TouchInfo src)
		{
			id = src.id;
			state = src.state;
			time = src.time;
			position = src.position;
			appPosition = src.appPosition;
			nativePosition = src.nativePosition;
		}

		// // RVA: 0x23A68A0 Offset: 0x23A68A0 VA: 0x23A68A0
		public void Setup(int id, TouchState state, Vector3 pos)
		{
			this.id = id;
			this.state = state;
			time = Time.time;
			nativePosition = pos;
			position = new Vector3(pos.x , SystemManager.ScreenSize.y - pos.y ,pos.z);
			appPosition = RenderManager.ScreenToAppPosition(pos);
		}
	}
}
