using UnityEngine;

namespace XeApp.Game.Common
{
	public class LowModeBackgroundResource : MonoBehaviour
	{
		private bool isUnused = true; // 0xC
		private bool isLoaded; // 0xD
		public Texture introTexture; // 0x10
		public Texture cardTexture; // 0x14
		public Texture battleTexture; // 0x18
		public bool isTitleBg; // 0x1C
		public int baseRare = 1; // 0x20

		//public bool isAllLoaded { get; private set; } 0x110AE9C 0x110AEC0

		// RVA: 0x110AA5C Offset: 0x110AA5C VA: 0x110AA5C
		public void OnDestroy()
		{
			TodoLogger.Log(0, "LowModeBackgroundResource OnDestroy");
		}

		//// RVA: 0x110AA70 Offset: 0x110AA70 VA: 0x110AA70
		//public void LoadResouces(int introId, int cardId, int cardRarityId, int baseRare, int battleId, Texture cardTexture) { }

		//[IteratorStateMachineAttribute] // RVA: 0x7401BC Offset: 0x7401BC VA: 0x7401BC
		//// RVA: 0x110AAAC Offset: 0x110AAAC VA: 0x110AAAC
		//private IEnumerator Co_LoadAllResouces(int introId, int cardId, int cardRarityId, int baseRare, int battleId, Texture cardTexture) { }

		//[IteratorStateMachineAttribute] // RVA: 0x740234 Offset: 0x740234 VA: 0x740234
		//// RVA: 0x110ABF4 Offset: 0x110ABF4 VA: 0x110ABF4
		//private IEnumerator Co_LoadIntroResource(int introId) { }

		//[IteratorStateMachineAttribute] // RVA: 0x7402AC Offset: 0x7402AC VA: 0x7402AC
		//// RVA: 0x110ACBC Offset: 0x110ACBC VA: 0x110ACBC
		//private IEnumerator Co_LoadCardResource(int cardId, int cardRarityId, int baseRare, Texture cardTexture) { }

		//[IteratorStateMachineAttribute] // RVA: 0x740324 Offset: 0x740324 VA: 0x740324
		//// RVA: 0x110ADD4 Offset: 0x110ADD4 VA: 0x110ADD4
		//private IEnumerator Co_LoadBattleResource(int battleId) { }
	}
}
