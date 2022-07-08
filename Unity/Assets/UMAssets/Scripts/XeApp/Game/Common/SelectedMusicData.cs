namespace XeApp.Game.Common
{
	public class SelectedMusicData
	{
		private EEDKAACNBBG selectedMusic; // 0x8
		//private BKKMNPEEILG ghostData; // 0xC
		private int selectedFreeMusicId; // 0x10

		// RVA: 0x1391C54 Offset: 0x1391C54 VA: 0x1391C54
		public void SetMusicData(IBJAKJJICBC selectedMusic)
		{
			this.selectedMusic = selectedMusic;
			UnityEngine.Debug.LogError("TODO Finish SetMusicData");
		}

		// RVA: 0x1391C84 Offset: 0x1391C84 VA: 0x1391C84
		//public void SetStoryMusic(EEDKAACNBBG storyMusicData) { }

		// RVA: 0x1391C94 Offset: 0x1391C94 VA: 0x1391C94
		//public void SetGhostData(BKKMNPEEILG ghostData) { }

		// RVA: 0x1391C9C Offset: 0x1391C9C VA: 0x1391C9C
		//public EEDKAACNBBG GetSelectedMusicData() { }

		// RVA: 0x1391CA4 Offset: 0x1391CA4 VA: 0x1391CA4
		//public BKKMNPEEILG GetGhostData() { }

		// RVA: 0x1391CAC Offset: 0x1391CAC VA: 0x1391CAC
		//public EJKBKMBJMGL GetEnemyData(Difficulty.Type difficulty) { }

		// RVA: 0x1391DD8 Offset: 0x1391DD8 VA: 0x1391DD8
		//public int GetNeedEnergy(Difficulty.Type difficulty, bool isLine6) { }
	}
}
