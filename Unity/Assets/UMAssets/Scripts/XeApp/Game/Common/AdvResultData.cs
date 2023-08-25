using XeApp.Game.Menu;

namespace XeApp.Game.Common
{
	public struct AdvSetupParam
	{
		public int eventUniqueId; // 0x0
		public int restorBgmId; // 0x4
		public float restorListPosition; // 0x8
		public AdvReturnBgParam bgParam; // 0xC
		public CCAAJNJGNDO eventStoryData; // 0x1C
	}

	public struct AdvReturnBgParam
	{
		public int bgId; // 0x0
		public BgTextureType textureType; // 0x4
		public BgType bgType; // 0x8
		public GameAttribute.Type attr; // 0xC
	}

	public class AdvResultData
	{
		private string m_returnSceneName; // 0x8
		private TransitionUniqueId m_uniqueId; // 0xC
		private int m_freeMusicId; // 0x10
		private int m_advId; // 0x14
		private int m_eventUniqueId; // 0x18
		private int m_restorBgmId; // 0x1C
		private float m_restoreListPosition; // 0x20
		private AdvReturnBgParam m_restorBgParam; // 0x24
		private CCAAJNJGNDO m_eventStoryData; // 0x34

		public string ReturnSceneName { get { return m_returnSceneName; } } //0xE58000
		//public TransitionUniqueId UniqueId { get; } 0xE5F7A0
		public int FreeMusicId { get { return m_freeMusicId; } } //0xE58084
		//public int EventUniqueId { get; } 0xE5F7A8
		public int AdvId { get { return m_advId; } } //0xE58108
		//public int RestorBgmId { get; } 0xE5F7B0
		//public float RestorListPosition { get; } 0xE5F7B8
		//public AdvReturnBgParam RestorBgParam { get; } 0xE5F7C0
		//public CCAAJNJGNDO EventStoryData { get; } 0xE5F7D0

		//// RVA: 0xE58008 Offset: 0xE58008 VA: 0xE58008
		public bool IsCallRhythmGame()
		{
			return m_returnSceneName == "RhythmGame";
		}

		//// RVA: 0xE5808C Offset: 0xE5808C VA: 0xE5808C
		public bool IsCallAdv()
		{
			return m_returnSceneName == "Adv";
		}

		//// RVA: 0xE58118 Offset: 0xE58118 VA: 0xE58118
		public void Clear()
		{
			m_returnSceneName = "";
		}

		//// RVA: 0xE5F7D8 Offset: 0xE5F7D8 VA: 0xE5F7D8
		public void Setup(string returnSceneName)
		{
			m_returnSceneName = returnSceneName;
		}

		//// RVA: 0xE5F7E0 Offset: 0xE5F7E0 VA: 0xE5F7E0
		public void Setup(int freeMusicId)
		{
			m_freeMusicId = freeMusicId;
			m_returnSceneName = "RhythmGame";
		}

		//// RVA: 0xE5F848 Offset: 0xE5F848 VA: 0xE5F848
		public void SetupNextAdv(short advId)
		{
			m_advId = advId;
			m_returnSceneName = "Adv";
		}

		// RVA: 0xE5F8B0 Offset: 0xE5F8B0 VA: 0xE5F8B0
		public void Setup(string returnSceneName, TransitionUniqueId uniqueId)
		{
			m_returnSceneName = returnSceneName;
			m_uniqueId = uniqueId;
			m_eventUniqueId = 0;
			m_restoreListPosition = 0;
		}

		//// RVA: 0xE5F8C8 Offset: 0xE5F8C8 VA: 0xE5F8C8
		public void Setup(string returnSceneName, TransitionUniqueId uniqueId, AdvSetupParam setupParam)
		{
			m_returnSceneName = returnSceneName;
			m_uniqueId = uniqueId;
			m_eventUniqueId = setupParam.eventUniqueId;
			m_restorBgParam = setupParam.bgParam;
			m_restorBgmId = setupParam.restorBgmId;
			m_eventStoryData = setupParam.eventStoryData;
			m_restoreListPosition = setupParam.restorListPosition;
		}
	}
}
