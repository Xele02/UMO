
using System;
using System.Collections.Generic;
using CriWare;

namespace XeApp.Game.RhythmGame
{
	public class BattleEventResultVoice
	{
		public enum ResultVoiceIndex
		{
			Valkyeri = 0,
			DivaMode = 1,
			Num = 2,
		}

		private List<int>[] cueIndexList; // 0x8
		private readonly string[] cuePrefixList = new string[2]
		{
			"g_bttresult_001", "g_bttresult_002"
		}; // 0xC

		// RVA: 0xF68460 Offset: 0xF68460 VA: 0xF68460
		public BattleEventResultVoice(CriAtomSource divaVoiceSource)
		{
			if(divaVoiceSource == null)
				return;
            CriAtomCueSheet sheet = CriAtom.GetCueSheet(divaVoiceSource.cueSheet);
			if(sheet != null)
			{
				InitializeCueIndex(sheet);
			}
        }

		// // RVA: 0xF68678 Offset: 0xF68678 VA: 0xF68678
		private void InitializeCueIndex(CriAtomCueSheet sheet)
		{
			cueIndexList = new List<int>[cuePrefixList.Length];
			CriAtomEx.CueInfo[] array = sheet.acb.GetCueInfoList();
			List<string> tmpCueList = new List<string>();
			for(int i = 0; i < cuePrefixList.Length; i++)
			{
				cueIndexList[i] = new List<int>(3);
				tmpCueList.Clear();
				for(int j = 0; j < array.Length; j++)
				{
					TodoLogger.LogError(TodoLogger.EventBattle_3, "Check cue found : "+array[j].name+" or "+array[j].userData+" against "+cuePrefixList[i]);
					if(array[j].name.Contains(cuePrefixList[i])) // or userData ?
					{
						tmpCueList.Add(array[j].name);
					}
				}
				tmpCueList.Sort();
				for(int j = 0; j < tmpCueList.Count; j++)
				{
					int idx = Array.FindIndex(array, (CriAtomEx.CueInfo x) =>
					{
						//0xF68EC4
						return tmpCueList[j] == x.name;
					});
					if(idx > -1)
					{
						cueIndexList[i].Add(array[idx].id);
					}
				}
			}
		}

		// // RVA: 0xF68C34 Offset: 0xF68C34 VA: 0xF68C34
		public int GetCueRandomId(ResultVoiceIndex index)
		{
			int rng = UnityEngine.Random.Range(0, cueIndexList[(int)index].Count);
			return cueIndexList[(int)index][rng];
		}

		// // RVA: 0xF68D5C Offset: 0xF68D5C VA: 0xF68D5C
		// public int GetCueId(BattleEventResultVoice.ResultVoiceIndex index, int cueListIndex) { }

		// // RVA: 0xF68E14 Offset: 0xF68E14 VA: 0xF68E14
		// public int GetCueCount(BattleEventResultVoice.ResultVoiceIndex index) { }
	}
}