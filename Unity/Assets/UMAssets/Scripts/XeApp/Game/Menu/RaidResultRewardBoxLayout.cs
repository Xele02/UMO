using System;
using System.Collections;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class RaidResultRewardBoxLayout : MonoBehaviour
	{
		public Action onFinished; // 0xC
		public Action onClickButton; // 0x10
		private PLFJMDBBAJD m_view; // 0x14
		private Matrix23 m_identity; // 0x18
		private Coroutine m_coroutine; // 0x30
		private bool m_isSkiped; // 0x34
		private bool m_isChargeBonus; // 0x35
		[SerializeField] // RVA: 0x67D22C Offset: 0x67D22C VA: 0x67D22C
		private ModelRaidRewardBox m_boxModel; // 0x38

		// RVA: 0x1BE166C Offset: 0x1BE166C VA: 0x1BE166C
		private void OnDisable()
		{
			if(SoundManager.Instance.sePlayerResultLoop.status != CriWare.CriAtomSource.Status.Playing)
				return;
			SoundManager.Instance.sePlayerResultLoop.Stop();
		}

		// RVA: 0x1BE1710 Offset: 0x1BE1710 VA: 0x1BE1710
		public void Setup(PLFJMDBBAJD view)
		{
			m_isSkiped = false;
			m_view = view;
			m_boxModel.Setup();
		}

		// // RVA: 0x1BE1748 Offset: 0x1BE1748 VA: 0x1BE1748
		public void SkipBeginAnim()
		{
			m_isSkiped = true;
			HideBox();
			m_boxModel.isSkip = true;
		}

		// // RVA: 0x1BE1800 Offset: 0x1BE1800 VA: 0x1BE1800
		public void StartBeginAnim()
		{
			m_coroutine = this.StartCoroutineWatched(Co_BeginAnim());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71FF9C Offset: 0x71FF9C VA: 0x71FF9C
		// // RVA: 0x1BE1828 Offset: 0x1BE1828 VA: 0x1BE1828
		private IEnumerator Co_BeginAnim()
		{
			//0x1BE18E0
			m_boxModel.AdjustCamera();
			yield return this.StartCoroutineWatched(m_boxModel.Enter());
			if(onFinished != null)
				onFinished();
		}

		// // RVA: 0x1BE177C Offset: 0x1BE177C VA: 0x1BE177C
		public void HideBox()
		{
			m_boxModel.Hide();
			m_boxModel.transform.SetParent(transform);
		}
	}
}
