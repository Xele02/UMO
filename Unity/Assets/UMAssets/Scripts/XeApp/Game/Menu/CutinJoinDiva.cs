using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class CutinJoinDiva : MonoBehaviour, IDisposable
	{
		private List<IEnumerator> m_update = new List<IEnumerator>(4); // 0xC
		private LayoutCutinJoinDivaController m_cjdController = new LayoutCutinJoinDivaController(); // 0x10

		public bool IsClosed { get; private set; } // 0x14
		public bool IsOpen { get; private set; } // 0x15
		public Action OnCallbackClose { get; set; } // 0x18
		public Action CallbackOpen { get; set; } // 0x1C

		// RVA: 0xC5112C Offset: 0xC5112C VA: 0xC5112C
		public static IEnumerator Show(List<int> divaIdList, Transform parent, Action callbackClose)
		{
			return Coroutine_Show(divaIdList, parent, callbackClose);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CF83C Offset: 0x6CF83C VA: 0x6CF83C
		// // RVA: 0xC51130 Offset: 0xC51130 VA: 0xC51130
		private static IEnumerator Coroutine_Show(List<int> divaIdList, Transform parent, Action callbackClose)
		{
			CutinJoinDiva cjd;

			//0xC51ACC
			if(MenuScene.Instance != null)
			{
				MenuScene.Instance.RaycastDisable();
			}
			cjd = CutinJoinDiva.Create(null);
			cjd.CallbackOpen = () =>
			{
				//0xC51990
				if(MenuScene.Instance != null)
				{
					MenuScene.Instance.RaycastEnable();
				}
			};
			cjd.Setup(parent, divaIdList);
			cjd.Show();
			while(!cjd.IsClosed)
				yield return null;
			cjd.Dispose();
			if(callbackClose != null)
				callbackClose();
		}

		// // RVA: 0xC51210 Offset: 0xC51210 VA: 0xC51210
		public static CutinJoinDiva Create(Transform parent)
		{
			return new GameObject("CutinJoinDiva").AddComponent<CutinJoinDiva>();
		}

		// RVA: 0xC512B4 Offset: 0xC512B4 VA: 0xC512B4 Slot: 4
		public void Dispose()
		{
			m_cjdController.Dispose();
			m_cjdController = null;
			Destroy(gameObject);
		}

		// RVA: 0xC51370 Offset: 0xC51370 VA: 0xC51370
		public void Awake()
		{
			return;
		}

		// RVA: 0xC51374 Offset: 0xC51374 VA: 0xC51374
		public void Start()
		{
			return;
		}

		// RVA: 0xC51378 Offset: 0xC51378 VA: 0xC51378
		private void Update()
		{
			if(m_update.Count > 0)
			{
				if(!m_update[0].MoveNext())
					m_update.RemoveAt(0);
				if(m_update.Count == 0)
					IsClosed = true;
			}
			if(m_cjdController != null)
				m_cjdController.Update();
		}

		// // RVA: 0xC5157C Offset: 0xC5157C VA: 0xC5157C
		public void Setup(Transform parent, List<int> divaIdList)
		{
			m_update.Add(SetupInner(parent, divaIdList));
		}

		// // RVA: 0xC516D4 Offset: 0xC516D4 VA: 0xC516D4
		public void Show()
		{
			if(!IsOpen)
				IsOpen = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CF934 Offset: 0x6CF934 VA: 0x6CF934
		// // RVA: 0xC51614 Offset: 0xC51614 VA: 0xC51614
		private IEnumerator SetupInner(Transform parent, List<int> divaIdList)
		{
			//0xC52344
			m_cjdController.Parent = parent.gameObject;
			m_cjdController.Setup(divaIdList);
			m_update.Add(LoadLayout());
			m_update.Add(PhaseDefault());
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CF9AC Offset: 0x6CF9AC VA: 0x6CF9AC
		// // RVA: 0xC51708 Offset: 0xC51708 VA: 0xC51708
		private IEnumerator PhaseDefault()
		{
			//0xC52168
			while(!IsOpen)
				yield return null;
			m_cjdController.SetStatus();
			m_cjdController.Show();
			if(CallbackOpen != null)
				CallbackOpen();
			CallbackOpen = null;
			while(!m_cjdController.IsClosed)
				yield return null;
			m_cjdController.Reset();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CFA24 Offset: 0x6CFA24 VA: 0x6CFA24
		// // RVA: 0xC517B4 Offset: 0xC517B4 VA: 0xC517B4
		private IEnumerator LoadLayout()
		{
			//0xC51E64
			bool isLoading = false;
			this.StartCoroutineWatched(m_cjdController.LoadLayoutFire(() =>
			{
				//0xC51AB0
				isLoading = true;
			}));
			while(!isLoading)
				yield return null;
			isLoading = false;
			this.StartCoroutineWatched(m_cjdController.LoadLayoutStar(() =>
			{
				//0xC51ABC
				isLoading = true;
			}));
			while(!isLoading)
				yield return null;
		}
	}
}
