using XeApp.Core;
using UnityEngine;
using System.Collections;

namespace XeApp.Game.DownLoad
{
	public class DownLoadScene : MainSceneBase
	{
		[SerializeField]
		private GameObject m_questionaryPrefab; // 0x28
		private LayoutDownLoad m_Layout; // 0x2C
		private LayoutQuestionary m_questionary; // 0x30
		// private MBLFHJJEHLH m_anketoMrg = new MBLFHJJEHLH(); // 0x34
		private bool m_IsFinish; // 0x38
		private bool m_IsDispDownLoadUI; // 0x39
		private bool m_IsExecuteQuestionary; // 0x3A
		private string m_NextSceneName = string.Empty; // 0x3C

		// RVA: 0x11BE484 Offset: 0x11BE484 VA: 0x11BE484 Slot: 9
		protected override void DoAwake()
		{
			enableFade = false;
			base.DoAwake();
		}

		// RVA: 0x11BE4AC Offset: 0x11BE4AC VA: 0x11BE4AC Slot: 10
		protected override void DoStart()
		{
			base.DoStart();
		}

		// RVA: 0x11BE4B4 Offset: 0x11BE4B4 VA: 0x11BE4B4 Slot: 12
		protected override bool DoUpdateEnter()
		{
			StartCoroutine(Co_MainProc());
			return base.DoUpdateEnter();
		}

		// RVA: 0x11BE570 Offset: 0x11BE570 VA: 0x11BE570
		// private void LoadResource() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6B4FF0 Offset: 0x6B4FF0 VA: 0x6B4FF0
		// // RVA: 0x11BE4E4 Offset: 0x11BE4E4 VA: 0x11BE4E4
		private IEnumerator Co_MainProc()
		{
			UnityEngine.Debug.Log("Enter Co_MainProc");
			//0x11BFC54 
			yield return StartCoroutine(Co_InitializeQuestionary());

			yield return StartCoroutine(Co_InitializeUnionDataProc());

			NextScene("Menu");

			UnityEngine.Debug.LogError("TODO");
			UnityEngine.Debug.Log("Exit Co_MainProc");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B5068 Offset: 0x6B5068 VA: 0x6B5068
		// // RVA: 0x11BE7E4 Offset: 0x11BE7E4 VA: 0x11BE7E4
		private IEnumerator Co_InitializeQuestionary()
		{
			UnityEngine.Debug.Log("Enter Co_InitializeQuestionary");
			//0x11BF7A4
			yield return null;

			UnityEngine.Debug.LogError("TODO");
			UnityEngine.Debug.Log("Exit Co_InitializeQuestionary");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B50E0 Offset: 0x6B50E0 VA: 0x6B50E0
		// // RVA: 0x11BE890 Offset: 0x11BE890 VA: 0x11BE890
		// private IEnumerator Co_QuestionayProc() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6B5158 Offset: 0x6B5158 VA: 0x6B5158
		// // RVA: 0x11BE93C Offset: 0x11BE93C VA: 0x11BE93C
		// private IEnumerator Co_DownLoadProc() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6B51D0 Offset: 0x6B51D0 VA: 0x6B51D0
		// // RVA: 0x11BE9E8 Offset: 0x11BE9E8 VA: 0x11BE9E8
		private IEnumerator Co_InitializeUnionDataProc()
		{
			//0x11BFA78
			GameManager.Instance.InitializeUnionData();
			while(!GameManager.Instance.IsUnionDataInitialized)
			{
				yield return null;
			}
		}

		// // RVA: 0x11BEA7C Offset: 0x11BEA7C VA: 0x11BEA7C
		// private void FinishDownLoad() { }

		// // RVA: 0x11BEAA4 Offset: 0x11BEAA4 VA: 0x11BEAA4
		// private void DownLoadError() { }

		// // RVA: 0x11BEB0C Offset: 0x11BEB0C VA: 0x11BEB0C
		// private void OnQuestionaryOk(LayoutQuestionaryButton[] buttons, int qIndex) { }

		// // RVA: 0x11BEC9C Offset: 0x11BEC9C VA: 0x11BEC9C Slot: 13
		protected override void DoUpdateMain()
		{
			return;
		}

		// // RVA: 0x11BECA0 Offset: 0x11BECA0 VA: 0x11BECA0
		// private bool InstallGuiEvent(int type, float per) { }

		// // RVA: 0x11BEA90 Offset: 0x11BEA90 VA: 0x11BEA90
		// private void Downloaded() { }

		// // RVA: 0x11BEEF8 Offset: 0x11BEEF8 VA: 0x11BEEF8
		// private bool IsFinish() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B5248 Offset: 0x6B5248 VA: 0x6B5248
		// // RVA: 0x11BF104 Offset: 0x11BF104 VA: 0x11BF104
		// private bool <Co_DownLoadProc>b__15_1() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B5258 Offset: 0x6B5258 VA: 0x6B5258
		// // RVA: 0x11BF12C Offset: 0x11BF12C VA: 0x11BF12C
		// private bool <Co_DownLoadProc>b__15_2() { }
	}
}
