namespace CriWare
{
	public class CriFsBindRequest : CriFsRequest
	{
		public enum BindType
		{
			Cpk = 0,
			Directory = 1,
			File = 2,
		}

		public string path { get; private set; } // 0x28
		public uint bindId { get; private set; } // 0x2C

		// // RVA: 0x2943FE4 Offset: 0x2943FE4 VA: 0x2943FE4
		// public void .ctor(CriFsBindRequest.BindType type, CriFsBinder targetBinder, CriFsBinder srcBinder, string path) { }

		// // RVA: 0x2944354 Offset: 0x2944354 VA: 0x2944354 Slot: 6
		public override void Stop()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x2944358 Offset: 0x2944358 VA: 0x2944358 Slot: 8
		public override void Update()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x29444CC Offset: 0x29444CC VA: 0x29444CC Slot: 7
		protected override void Dispose(bool disposing)
		{
			UnityEngine.Debug.LogError("TODO");
		}
	}
}