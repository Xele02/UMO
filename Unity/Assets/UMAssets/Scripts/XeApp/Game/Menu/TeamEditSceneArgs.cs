
namespace XeApp.Game.Menu
{
	public class TeamEditSceneArgs : TransitionArgs
	{
		private bool m_isFromBeginner; // 0x20

		public UnitWindowConstant.DispMode Mode { get; set; } // 0x8
		public JLKEOGLJNOD_TeamInfo Unit { get; set; } // 0xC
		public EEDKAACNBBG_MusicData MusicData { get; set; } // 0x10
		public EAJCBFGKKFA_FriendInfo FriendData { get; set; } // 0x14
		public EJKBKMBJMGL_EnemyData EnemyData { get; set; } // 0x18
		public bool IsFromBeginner { get { return m_isFromBeginner; } set { m_isFromBeginner = value; } } //0xF9ECEC 0xF9914C
		public int BeginnerMissionId { get; set; } // 0x1C
	}
}
