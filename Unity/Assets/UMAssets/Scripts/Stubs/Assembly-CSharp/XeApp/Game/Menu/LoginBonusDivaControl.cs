using System;
using System.Collections;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LoginBonusDivaControl : MenuDivaControlBase
	{
		public enum Type
		{
			Regular = 0,
			Comeback_001 = 1,
			Comeback_002 = 2,
		}

		private Coroutine m_changeDivaSerif; // 0x18
		private Coroutine m_loginVoiceWait; // 0x1C
		private Coroutine m_loginLoopBreak; // 0x20

		public Action CallbackChangeDivaSerif { get; set; } // 0x10
		public bool IsVoicePlaying { get; set; } // 0x14
		public bool IsBreakReactionPlaying { get; set; } // 0x15

		// RVA: 0xD233DC Offset: 0xD233DC VA: 0xD233DC
		public void OnLoginIdle()
		{
			if(DivaObject == null)
				return;
			DivaManager.DivaTransformReset();
			DivaObject.LoginIdle();
		}

		// // RVA: 0xD234D4 Offset: 0xD234D4 VA: 0xD234D4
		// public void RequestLoginBonus(LoginBonusDivaControl.Type type) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C6B3C Offset: 0x6C6B3C VA: 0x6C6B3C
		// // RVA: 0xD234F8 Offset: 0xD234F8 VA: 0xD234F8
		// private IEnumerator Co_RequestLoginBonus(LoginBonusDivaControl.Type type) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C6BB4 Offset: 0x6C6BB4 VA: 0x6C6BB4
		// // RVA: 0xD235C0 Offset: 0xD235C0 VA: 0xD235C0
		// private IEnumerator Co_LoginVoiceWait() { }

		// RVA: 0xD2366C Offset: 0xD2366C VA: 0xD2366C
		public void RequestLoginAnimLoopBreak()
		{
			m_loginLoopBreak = StartCoroutine(Co_RequestLoginAnimLoopBreak());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C6C2C Offset: 0x6C6C2C VA: 0x6C6C2C
		// // RVA: 0xD23694 Offset: 0xD23694 VA: 0xD23694
		private IEnumerator Co_RequestLoginAnimLoopBreak()
		{
			//0xD23BEC
			IsBreakReactionPlaying = true;
			DivaObject.LoginReactionLoopBreak();
			yield return new WaitWhile(() =>
			{
				//0xD23850
				return DivaObject != null && !DivaObject.IsLoginIdle();
			});
			IsBreakReactionPlaying = false;
			m_loginLoopBreak = null;
		}

		// RVA: 0xD23740 Offset: 0xD23740 VA: 0xD23740
		public void Stop()
		{
			if(m_changeDivaSerif != null)
				StopCoroutine(m_changeDivaSerif);
			if(m_loginVoiceWait != null)
				StopCoroutine(m_loginVoiceWait);
			if(m_loginLoopBreak != null)
				StopCoroutine(m_loginLoopBreak);
		}

		// RVA: 0xD23798 Offset: 0xD23798 VA: 0xD23798 Slot: 9
		protected override void OnEndControl()
		{
			Stop();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C6CA4 Offset: 0x6C6CA4 VA: 0x6C6CA4
		// // RVA: 0xD2379C Offset: 0xD2379C VA: 0xD2379C
		// private IEnumerator Coroutine_ChangeDivaSerif() { }
	}
}
