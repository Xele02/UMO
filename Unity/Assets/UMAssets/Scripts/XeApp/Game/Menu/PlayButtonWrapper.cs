using XeSys;

namespace XeApp.Game.Menu
{
	public abstract class PlayButtonWrapper
	{
		public enum Type
		{
			PlayEn = 0,
			Play = 1,
			Event = 2,
			Download = 3,
			Live = 4,
			Ok = 5,
		}

		public abstract MusicSelectCDSelect baseUI { get; protected set; } // Slot: 4 Slot: 5

		// // RVA: -1 Offset: -1 Slot: 6
		public abstract void Enter(bool immediate/* = False*/);

		// // RVA: -1 Offset: -1 Slot: 7
		public abstract void Leave(bool immediate/* = False*/);

		// // RVA: -1 Offset: -1 Slot: 8
		public abstract void SetDisable(bool disable);

		// // RVA: -1 Offset: -1 Slot: 9
		public abstract void SetType(Type type);

		// // RVA: -1 Offset: -1 Slot: 10
		public abstract void SetNeedEnergy(int en);

		// // RVA: 0xDE2448 Offset: 0xDE2448 VA: 0xDE2448
		public void SetupUnitLive(IBJAKJJICBC musicData, MMOLNAHHDOM saveData)
		{
			if(musicData == null)
				baseUI.SetupUnitLive(null, null);
			else
			{
				baseUI.SetupUnitLive(musicData, saveData);
				if(!musicData.PNKKJEABNFF(IBJAKJJICBC.AAADDDFCKLF.IANFNICOEFE_1))
				{
					SetDisable(true);
				}
				if(!musicData.PNKKJEABNFF(IBJAKJJICBC.AAADDDFCKLF.OGGMDNKPFEB_2))
				{
					int lvl = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("multi_dance_player_level", 3);
					baseUI.ApplyEventEndMessage(string.Format(MessageManager.Instance.GetMessage("menu", "unit_multi_dance_lock_text"), lvl));
					baseUI.ApplyCursorEventStyle(MusicSelectCDSelect.EventStyle.Disable, false);
				}
			}
		}
	}
}
