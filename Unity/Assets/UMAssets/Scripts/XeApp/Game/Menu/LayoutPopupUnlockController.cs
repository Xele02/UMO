using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class LayoutPopupUnlockController : IDisposable
	{
		private List<IEnumerator> m_mainUpdate = new List<IEnumerator>(8); // 0x14
		private PopupUnlock.UnlockInfo m_info; // 0x1C
		private string[] m_bundleNames = new string[1] { "ly/047.xab" }; // 0x20
		private Dictionary<string, int> m_bundleCounter = new Dictionary<string, int>(8); // 0x24

		public bool IsClosed { get; private set; } // 0x8
		public bool IsOpen { get; private set; } // 0x9
		public GameObject Parent { get; set; } // 0xC
		public GameObject CanvasParent { get; set; } // 0x10
		public LayoutPopupUnlockMusicDirection MusicDirection { get; private set; } // 0x18
		public bool IsLoadBundle { get; private set; } // 0x28

		// // RVA: 0x178A2C8 Offset: 0x178A2C8 VA: 0x178A2C8
		public void Setup()
		{
			CanvasParent = GameObject.Find("Canvas-Popup");
		}

		// // RVA: 0x178A330 Offset: 0x178A330 VA: 0x178A330
		public void SetStatus(PopupUnlock.UnlockInfo info)
		{
			if (info == null)
				return;
			if (info.param != null)
				m_info = info;
		}

		// // RVA: 0x178A360 Offset: 0x178A360 VA: 0x178A360
		// public void Reset() { }

		// // RVA: 0x178A3D8 Offset: 0x178A3D8 VA: 0x178A3D8
		public void Update()
		{
			if(m_mainUpdate.Count > 0)
			{
				if(!m_mainUpdate[0].MoveNext())
				{
					m_mainUpdate.RemoveAt(0);
				}
				if (m_mainUpdate.Count == 0)
					IsClosed = true;
			}
		}

		// // RVA: 0x178A584 Offset: 0x178A584 VA: 0x178A584
		public void Show()
		{
			if (IsOpen)
				return;
			IsOpen = true;
			m_mainUpdate.Add(MainPhase());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7040D4 Offset: 0x7040D4 VA: 0x7040D4
		// // RVA: 0x178A620 Offset: 0x178A620 VA: 0x178A620
		private IEnumerator MainPhase()
		{
			//0x178BA70
			if((int)m_info.param.unlockType -1 < 4)
			{
				switch(m_info.param.unlockType)
				{
					case PopupUnlock.eUnlockType.Music:
						m_mainUpdate.Add(MusicUnlockPhase());
						break;
					case PopupUnlock.eUnlockType.Stage:
						m_mainUpdate.Add(StageUnlockPhase());
						break;
					case PopupUnlock.eUnlockType.Diva:
						m_mainUpdate.Add(DivaUnlockPhase());
						break;
					case PopupUnlock.eUnlockType.DivaNotify:
						m_mainUpdate.Add(DivaNotifyPhase());
						break;
				}
			}
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70414C Offset: 0x70414C VA: 0x70414C
		// // RVA: 0x178A6CC Offset: 0x178A6CC VA: 0x178A6CC
		private IEnumerator MusicUnlockPhase()
		{
			//0x178BCB4
			if(MusicDirection == null)
				yield break;
			MusicDirection.SetStatus(m_info);
			while(MusicDirection.IsLoading())
				yield return null;
			MusicDirection.Show();
			while(!MusicDirection.IsClosed)
				yield return null;
			MusicDirection.Hide();
			if(Parent != null)
			{
				MusicDirection.Hide();
				MusicDirection.gameObject.SetActive(false);
				MusicDirection.transform.SetParent(Parent.transform, false);
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7041C4 Offset: 0x7041C4 VA: 0x7041C4
		// // RVA: 0x178A778 Offset: 0x178A778 VA: 0x178A778
		private IEnumerator StageUnlockPhase()
		{
			//0x178C3B0
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70423C Offset: 0x70423C VA: 0x70423C
		// // RVA: 0x178A80C Offset: 0x178A80C VA: 0x178A80C
		private IEnumerator DivaNotifyPhase()
		{
			//0x178B434
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7042B4 Offset: 0x7042B4 VA: 0x7042B4
		// // RVA: 0x178A8A0 Offset: 0x178A8A0 VA: 0x178A8A0
		private IEnumerator DivaUnlockPhase()
		{
			//0x178B4E8
			yield break;
		}

		// // RVA: 0x178A934 Offset: 0x178A934 VA: 0x178A934 Slot: 4
		public void Dispose()
		{
			if(MusicDirection != null)
			{
				UnityEngine.Object.Destroy(MusicDirection.gameObject);
				MusicDirection = null;
			}
			UnloadAssetBundle();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70432C Offset: 0x70432C VA: 0x70432C
		// // RVA: 0x178AC90 Offset: 0x178AC90 VA: 0x178AC90
		public IEnumerator LoadLayoutMusic(Action callback)
		{
			//0x178B85C
			if(MusicDirection == null)
			{
				yield return LoadLayout("ly/047.xab", "root_pop_music_ul_dir_layout_root", (GameObject instance) =>
				{
					//0x178B23C
					if(CanvasParent != null)
					{
						instance.transform.SetParent(CanvasParent.transform, false);
					}
					MusicDirection = instance.GetComponent<LayoutPopupUnlockMusicDirection>();
					MusicDirection.transform.SetAsLastSibling();
				});
			}
			if (callback != null)
				callback();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7043A4 Offset: 0x7043A4 VA: 0x7043A4
		// // RVA: 0x178AD58 Offset: 0x178AD58 VA: 0x178AD58
		private IEnumerator LoadLayout(string bundleName, string assetName, Action<GameObject> callback)
		{
			Font font; // 0x24
			AssetBundleLoadLayoutOperationBase operation; // 0x28

			//0x178B59C
			font = GameManager.Instance.GetSystemFont();
			operation = AssetBundleManager.LoadLayoutAsync(bundleName, assetName);
			yield return operation;
			yield return operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0x178B3B0
				callback(instance);
			});
			AddBundleCounter(bundleName);
		}

		// // RVA: 0x178AE60 Offset: 0x178AE60 VA: 0x178AE60
		private void AddBundleCounter(string bundleName)
		{
			if(m_bundleCounter.ContainsKey(bundleName))
			{
				m_bundleCounter[bundleName]++;
			}
			else
			{
				m_bundleCounter.Add(bundleName, 1);
			}
		}

		// // RVA: 0x178AF74 Offset: 0x178AF74 VA: 0x178AF74
		// public void LoadAssetBundle() { }

		// [IteratorStateMachineAttribute] // RVA: 0x70443C Offset: 0x70443C VA: 0x70443C
		// // RVA: 0x178B02C Offset: 0x178B02C VA: 0x178B02C
		// private IEnumerator UnionBundle() { }

		// // RVA: 0x178AA34 Offset: 0x178AA34 VA: 0x178AA34
		public void UnloadAssetBundle()
		{
			foreach(var b in m_bundleCounter)
			{
				for(int i = 0; i < b.Value; i++)
				{
					AssetBundleManager.UnloadAssetBundle(b.Key);
				}
			}
		}
	}
}
