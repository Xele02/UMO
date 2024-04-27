using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class LayoutCutinJoinDivaController : IDisposable
	{
		private LayoutCutinFireDiva m_fireDiva; // 0x10
		private LayoutCutinStarDiva m_starDiva; // 0x14
		private IEnumerator m_updater; // 0x18
		private List<int> m_divaIdList = new List<int>(8); // 0x1C

		// Properties
		public bool IsClosed { get; private set; } // 0x8
		public bool IsOpen { get; private set; } // 0x9
		public GameObject Parent { get; set; } // 0xC

		// RVA: 0x19DA170 Offset: 0x19DA170 VA: 0x19DA170
		public void Setup(List<int> divaIdList)
		{
			m_divaIdList = divaIdList;
		}

		// RVA: 0x19DA178 Offset: 0x19DA178 VA: 0x19DA178
		public void SetStatus() { }

		// RVA: 0x19DA17C Offset: 0x19DA17C VA: 0x19DA17C
		public void Reset()
		{
			return;
		}

		// RVA: 0x19DA188 Offset: 0x19DA188 VA: 0x19DA188
		public void Update()
		{
			if(m_updater != null)
			{
				if(!m_updater.MoveNext())
				{
					IsClosed = true;
					m_updater = null;
				}
			}
		}

		// RVA: 0x19DA26C Offset: 0x19DA26C VA: 0x19DA26C
		public void Show()
		{
			if(IsOpen)
				return;
			IsOpen = true;
			m_updater = ShowCutin();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CFC3C Offset: 0x6CFC3C VA: 0x6CFC3C
		// // RVA: 0x19DA29C Offset: 0x19DA29C VA: 0x19DA29C
		private IEnumerator ShowCutin()
		{
			int i;

			//0x19DB4A4
			for(i = 0; i < m_divaIdList.Count; i++)
			{
				if(m_divaIdList[i] == 8 || m_divaIdList[i] == 9)
				{
					if(m_fireDiva != null)
					{
						m_fireDiva.SetStatus(m_divaIdList[i]);
						m_fireDiva.Show();
						while(m_fireDiva.IsPlaying())
							yield return null;
						m_fireDiva.Hide();
					}
				}
				else
				{
					if(m_starDiva != null)
					{
						m_starDiva.SetStatus(m_divaIdList[i]);
						m_starDiva.Show();
						while(m_starDiva.IsPlaying())
							yield return null;
						m_starDiva.Hide();
					}
				}
			}
		}

		// RVA: 0x19DA348 Offset: 0x19DA348 VA: 0x19DA348 Slot: 4
		public void Dispose()
		{
			if(m_fireDiva != null)
				UnityEngine.Object.Destroy(m_fireDiva.gameObject);
			m_fireDiva = null;
			if(m_starDiva != null)
				UnityEngine.Object.Destroy(m_starDiva.gameObject);
			m_starDiva = null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CFCB4 Offset: 0x6CFCB4 VA: 0x6CFCB4
		// RVA: 0x19DA4EC Offset: 0x19DA4EC VA: 0x19DA4EC
		public IEnumerator LoadLayoutFire(Action callback)
		{
			//0x19DAE54
			int d = m_divaIdList.Find((int _) =>
			{
				//0x19DAAC0
				return _ == 8 || _ == 9;
			});
			if(m_fireDiva == null && d > 0)
			{
				yield return Co.R(LoadLayout("ly/082.xab", "root_cutin_fire_layout_root", (GameObject instance) =>
				{
					//0x19DA7EC
					if(Parent != null)
						instance.transform.SetParent(Parent.transform, false);
					m_fireDiva = instance.GetComponent<LayoutCutinFireDiva>();
				}));
			}
			if(callback != null)
				callback();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CFD2C Offset: 0x6CFD2C VA: 0x6CFD2C
		// RVA: 0x19DA5B4 Offset: 0x19DA5B4 VA: 0x19DA5B4
		public IEnumerator LoadLayoutStar(Action callback)
		{
			//0x19DB17C
			int d = m_divaIdList.Find((int _) =>
			{
				//0x19DAAD4
				return _ != 8 && _ != 9;
			});
			if(d > 0 && m_starDiva == null)
			{
				yield return Co.R(LoadLayout("ly/082.xab", "root_cutin_star_layout_root", (GameObject instance) =>
				{
					//0x19DA918
					if(Parent != null)
						instance.transform.SetParent(Parent.transform, false);
					m_starDiva = instance.GetComponent<LayoutCutinStarDiva>();
				}));
			}
			if(callback != null)
				callback();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CFDA4 Offset: 0x6CFDA4 VA: 0x6CFDA4
		// // RVA: 0x19DA67C Offset: 0x19DA67C VA: 0x19DA67C
		private IEnumerator LoadLayout(string bundleName, string assetName, Action<GameObject> callback)
		{
			Font font; // 0x20
			AssetBundleLoadLayoutOperationBase operation; // 0x24

			//0x19DAB74
			font = GameManager.Instance.GetSystemFont();
			operation = AssetBundleManager.LoadLayoutAsync(bundleName, assetName);
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0x19DAAF0
				callback(instance);
			}));
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
		}
	}
}
