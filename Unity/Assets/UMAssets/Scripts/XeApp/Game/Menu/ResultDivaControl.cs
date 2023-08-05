
using System.Collections;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class ResultDivaControl : MenuDivaControlBase
	{

		//// RVA: 0xCFF2F4 Offset: 0xCFF2F4 VA: 0xCFF2F4
		public void OnResultStart()
		{
			DivaManager.DivaTransformReset();
			DivaObject.Result();
		}

		//// RVA: 0xCFF358 Offset: 0xCFF358 VA: 0xCFF358
		//public void OnBattleResultStart() { }

		//// RVA: 0xCFF454 Offset: 0xCFF454 VA: 0xCFF454 Slot: 9
		protected override void OnEndControl()
		{
			DivaManager.ApplyCameraPos(DivaObject.divaId, Common.DivaMenuParam.CameraPosType.Default);
		}

		//// RVA: 0xCFF4C4 Offset: 0xCFF4C4 VA: 0xCFF4C4
		public void OnResultAnimStart(ResultScoreRank.Type scoreRank)
		{
			DivaObject.ResultAnimStart(DivaResultMotion.UseResultSpecial(DivaObject.divaId, scoreRank));
			int voice = Database.Instance.gameSetup.ForceDivaVoice();
			if (voice > 0)
			{
				SoundManager.Instance.voDiva.RequestChangeCueSheetForReplacement(voice, () => {
					//0xCFFE3C
					SoundManager.Instance.voDiva.Play(DivaVoicePlayer.VoiceCategory.Result, DivaResultMotion.GetVoiceId(scoreRank));
				});
				return;
			}
			SoundManager.Instance.voDiva.Play(DivaVoicePlayer.VoiceCategory.Result, DivaResultMotion.GetVoiceId(scoreRank));
			return;
		}

		//// RVA: 0xCFF6FC Offset: 0xCFF6FC VA: 0xCFF6FC
		public void RequestResultAnimStart(ResultScoreRank.Type scoreRank)
		{
			OnResultAnimStart(scoreRank);
			StartCoroutine(Coroutine_RequestResultAnimStart());
		}

		//// RVA: 0xCFF7B4 Offset: 0xCFF7B4 VA: 0xCFF7B4
		public void OnSimulationResultAnimStart()
		{
			DivaObject.ResultAnimStart(DivaResultMotion.UseResultSpecial(DivaObject.divaId, ResultScoreRank.Type.S));
			int voice = Database.Instance.gameSetup.ForceDivaVoice();
			if(voice < 1)
			{
				SoundManager.Instance.voDiva.Play(DivaVoicePlayer.VoiceCategory.Result, 3);
				return;
			}
			SoundManager.Instance.voDiva.RequestChangeCueSheetForReplacement(voice, () => {
				//0xCFFD20
				SoundManager.Instance.voDiva.Play(DivaVoicePlayer.VoiceCategory.Result, 3);
			});
		}

		//// RVA: 0xCFFA08 Offset: 0xCFFA08 VA: 0xCFFA08
		public void RequestSimulationResultAnimStart()
		{
			OnSimulationResultAnimStart();
			StartCoroutine(Coroutine_RequestResultAnimStart());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C6EAC Offset: 0x6C6EAC VA: 0x6C6EAC
		//// RVA: 0xCFF728 Offset: 0xCFF728 VA: 0xCFF728
		private IEnumerator Coroutine_RequestResultAnimStart()
		{
			//0xCFFEAC
			yield return new WaitWhile(() => {
				//0xCFFD7C
				return SoundManager.Instance.voDiva.isPlaying;
			});
			if(DivaObject != null)
			{
				DivaObject.ResultReactionLoopBreak();
			}
		}

		//// RVA: 0xCFFA54 Offset: 0xCFFA54 VA: 0xCFFA54
		//public void OnBattleResultAnimStart(bool isWin) { }

		//// RVA: 0xCFFC30 Offset: 0xCFFC30 VA: 0xCFFC30
		//public void RequestBattleResultAnimStart(bool isWin) { }

		//// RVA: 0xCFFC68 Offset: 0xCFFC68 VA: 0xCFFC68
		//public void ResetBattleResultTransform() { }
	}
}
