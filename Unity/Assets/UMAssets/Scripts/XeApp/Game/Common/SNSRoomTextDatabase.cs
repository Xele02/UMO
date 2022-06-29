namespace XeApp.Game.Common
{
	public class SNSRoomTextDatabase
	{
		private static string s_path = "message_room_text"; // 0x0
		public SNSRoomTextData textData = new SNSRoomTextData(); // 0x8
		public bool isLoading; // 0xC

		// // RVA: 0x138C098 Offset: 0x138C098 VA: 0x138C098
		// public void LoadFromResource() { }

		// // RVA: 0x138C2C4 Offset: 0x138C2C4 VA: 0x138C2C4
		// public void LoadFromBinary(byte[] dataBytes) { }

		// RVA: 0x138C2F8 Offset: 0x138C2F8 VA: 0x138C2F8
		public void LoadFromBinaryTAR(CBBJHPBGBAJ_Archive tar)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// [CompilerGeneratedAttribute] // RVA: 0x73AA64 Offset: 0x73AA64 VA: 0x73AA64
		// // RVA: 0x138C604 Offset: 0x138C604 VA: 0x138C604
		// private bool <LoadFromResource>b__3_0(FileResultObject fro) { }
	}
}
