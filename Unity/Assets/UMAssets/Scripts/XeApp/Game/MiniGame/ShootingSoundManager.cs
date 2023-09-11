using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingSoundManager : MonoBehaviour
	{
		public enum BGM_ID
		{
			Title = 1,
			Main = 2,
			MainBoss = 3,
		}

		private string[] BGM_LIST = new string[3]
			{ "cs_bgm_minigame_001", "cs_bgm_minigame_002", "cs_bgm_minigame_003" }; // 0xC
		private bool m_isSeInstall; // 0x10

		//// RVA: 0xC91290 Offset: 0xC91290 VA: 0xC91290
		//public bool IsReady() { }

		//// RVA: 0xC91298 Offset: 0xC91298 VA: 0xC91298
		//public void BgmPlay(ShootingSoundManager.BGM_ID id) { }

		//// RVA: 0xC9137C Offset: 0xC9137C VA: 0xC9137C
		//public void BgmFadeOut(float sec = 1, Action onStop) { }

		// RVA: 0xC8DC78 Offset: 0xC8DC78 VA: 0xC8DC78
		public void SePlay(int id)
		{
			SoundManager.Instance.sePlayerMiniGame.Play(id);
		}

		// RVA: 0xC913E0 Offset: 0xC913E0 VA: 0xC913E0
		public void SystemSePlay(int id)
		{
			SoundManager.Instance.sePlayerBoot.Play(id);
		}

		//// RVA: 0xC9143C Offset: 0xC9143C VA: 0xC9143C
		//public void InstallCueSheet() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6B29D0 Offset: 0x6B29D0 VA: 0x6B29D0
		//// RVA: 0xC917D0 Offset: 0xC917D0 VA: 0xC917D0
		//private void <InstallCueSheet>b__8_0() { }
	}
}
