namespace XeApp.Game.Menu
{
	public class PlayerListInfo
	{
		private bool isNew = true; // 0xE
		protected bool isLoad; // 0xF
		public EAJCBFGKKFA_FriendInfo friend; // 0x10
		public string name = ""; // 0x14

		public bool IsNew { get { return IsAvailable && isNew; } } //0xDE6CB8
		public int ListIndex { get; set; } // 0x8
		public bool IsInvalid { get; set; } // 0xC
		public bool IsAvailable { get; set; } // 0xD

		// RVA: 0xDE6D08 Offset: 0xDE6D08 VA: 0xDE6D08
		public PlayerListInfo()
		{
			return;
		}

		// RVA: 0xDE6D7C Offset: 0xDE6D7C VA: 0xDE6D7C
		public void SetFriListInfo(int Index, bool isAvailable, EAJCBFGKKFA_FriendInfo fr)
		{
			IsAvailable = isAvailable;
			ListIndex = Index;
			friend = fr;
			name = fr.PCEGKKLKFNO.LBODHBDOMGK_Name;
		}

		// RVA: 0xDE6DD0 Offset: 0xDE6DD0 VA: 0xDE6DD0
		public PlayerListInfo(int titleIndex, bool isAvailable)
		{
			ListIndex = titleIndex;
			IsAvailable = isAvailable;
			isLoad = false;
		}

		//// RVA: 0xDE6E5C Offset: 0xDE6E5C VA: 0xDE6E5C
		//public bool IsReady() { }

		// RVA: 0xDE6E70 Offset: 0xDE6E70 VA: 0xDE6E70 Slot: 4
		public virtual void TryInstall()
		{
			return;
		}
	}
}
