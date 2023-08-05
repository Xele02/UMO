namespace XeApp.Game.Common
{
	public class AdvResultData
	{
		private string m_returnSceneName; // 0x8
		private TransitionUniqueId m_uniqueId; // 0xC
		private int m_freeMusicId; // 0x10
		private int m_advId; // 0x14
		private int m_eventUniqueId; // 0x18
		private int m_restorBgmId; // 0x1C
		private float m_restoreListPosition; // 0x20
		//private AdvReturnBgParam m_restorBgParam; // 0x24
		//private CCAAJNJGNDO m_eventStoryData; // 0x34

		//public string ReturnSceneName { get; } 0xE58000
		//public TransitionUniqueId UniqueId { get; } 0xE5F7A0
		//public int FreeMusicId { get; } 0xE58084
		//public int EventUniqueId { get; } 0xE5F7A8
		//public int AdvId { get; } 0xE58108
		//public int RestorBgmId { get; } 0xE5F7B0
		//public float RestorListPosition { get; } 0xE5F7B8
		//public AdvReturnBgParam RestorBgParam { get; } 0xE5F7C0
		//public CCAAJNJGNDO EventStoryData { get; } 0xE5F7D0

		//// RVA: 0xE58008 Offset: 0xE58008 VA: 0xE58008
		//public bool IsCallRhythmGame() { }

		//// RVA: 0xE5808C Offset: 0xE5808C VA: 0xE5808C
		//public bool IsCallAdv() { }

		//// RVA: 0xE58118 Offset: 0xE58118 VA: 0xE58118
		//public void Clear() { }

		//// RVA: 0xE5F7D8 Offset: 0xE5F7D8 VA: 0xE5F7D8
		//public void Setup(string returnSceneName) { }

		//// RVA: 0xE5F7E0 Offset: 0xE5F7E0 VA: 0xE5F7E0
		//public void Setup(int freeMusicId) { }

		//// RVA: 0xE5F848 Offset: 0xE5F848 VA: 0xE5F848
		//public void SetupNextAdv(short advId) { }

		// RVA: 0xE5F8B0 Offset: 0xE5F8B0 VA: 0xE5F8B0
		public void Setup(string returnSceneName, TransitionUniqueId uniqueId)
		{
			TodoLogger.LogError(0, "Setup");
		}

		//// RVA: 0xE5F8C8 Offset: 0xE5F8C8 VA: 0xE5F8C8
		//public void Setup(string returnSceneName, TransitionUniqueId uniqueId, AdvSetupParam setupParam) { }
	}
}
