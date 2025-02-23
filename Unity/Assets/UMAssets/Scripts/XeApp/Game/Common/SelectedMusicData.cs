namespace XeApp.Game.Common
{
	public class SelectedMusicData
	{
		private EEDKAACNBBG_MusicData selectedMusic; // 0x8
		private BKKMNPEEILG ghostData; // 0xC
		private int selectedFreeMusicId; // 0x10

		// RVA: 0x1391C54 Offset: 0x1391C54 VA: 0x1391C54
		public void SetMusicData(IBJAKJJICBC selectedMusic)
		{
			this.selectedMusic = selectedMusic;
			ghostData = selectedMusic.DACLONHOFLA;
		}

		// RVA: 0x1391C84 Offset: 0x1391C84 VA: 0x1391C84
		public void SetStoryMusic(EEDKAACNBBG_MusicData storyMusicData)
		{
			selectedMusic = storyMusicData;
			ghostData = null;
		}

		// RVA: 0x1391C94 Offset: 0x1391C94 VA: 0x1391C94
		//public void SetGhostData(BKKMNPEEILG ghostData) { }

		// RVA: 0x1391C9C Offset: 0x1391C9C VA: 0x1391C9C
		public EEDKAACNBBG_MusicData GetSelectedMusicData()
		{
			return selectedMusic;
		}

		// RVA: 0x1391CA4 Offset: 0x1391CA4 VA: 0x1391CA4
		public BKKMNPEEILG GetGhostData()
		{
			return ghostData;
		}

		// RVA: 0x1391CAC Offset: 0x1391CAC VA: 0x1391CAC
		public EJKBKMBJMGL_EnemyData GetEnemyData(Difficulty.Type difficulty)
		{
			if(selectedMusic != null)
			{
				if (selectedMusic is LIEJFHMGNIA)
					return (selectedMusic as LIEJFHMGNIA).HPBPDHPIBGN_EnnemyData;
				if (selectedMusic is IBJAKJJICBC)
					return (selectedMusic as IBJAKJJICBC).MGJKEJHEBPO_DiffInfos[(int)difficulty].HPBPDHPIBGN_EnemyData;
			}
			return null;
		}

		// RVA: 0x1391DD8 Offset: 0x1391DD8 VA: 0x1391DD8
		public int GetNeedEnergy(Difficulty.Type difficulty, bool isLine6)
		{
			if(selectedMusic != null)
			{
				if (selectedMusic is IBJAKJJICBC)
				{
					MKIKFJKPEHK data = new MKIKFJKPEHK();
					if(!data.DPICLLJJPAC(selectedMusic as IBJAKJJICBC, (int)difficulty, isLine6))
					{
						return (selectedMusic as IBJAKJJICBC).MGJKEJHEBPO_DiffInfos[(int)difficulty].BPLOEAHOPFI_Energy;
					}
					if(Database.Instance.gameSetup.SelectedDashIndex > -1)
					{
						return data.KLOOIJIDKGO_Cost[Database.Instance.gameSetup.SelectedDashIndex];
					}
				}
			}
			return 0;
		}
	}
}
