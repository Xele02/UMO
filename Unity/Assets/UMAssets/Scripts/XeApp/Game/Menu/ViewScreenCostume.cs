using System;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class ViewScreenCostume : MonoBehaviour
	{
		private Camera m_divaCamera; // 0xC
		private GameObject m_cameraObj; // 0x10
		private ViewModeCameraManCs m_cameraMan; // 0x14
		private MenuDivaGazeControl m_gazeControl; // 0x18
		private Action m_onEntered; // 0x1C
		private Action m_onFinished; // 0x20

		//public Action OnEntered { set; } 0x1CE5FB0
		//public Action OnFinished { set; } 0x1CE5FB8

		// RVA: 0x1CE5FC0 Offset: 0x1CE5FC0 VA: 0x1CE5FC0
		private void Start()
		{
			GameManager.Instance.SetFPS(60);
			m_divaCamera = MenuScene.Instance.divaManager.GetComponentInChildren<Camera>();
			m_cameraObj = new GameObject("View camera");
			if(m_cameraObj != null)
			{
				m_cameraObj.transform.SetParent(transform, false);
				m_cameraObj.AddComponent<Camera>();
				m_cameraObj.AddComponent<OptimalFXAA>();
				m_cameraMan = m_cameraObj.AddComponent<ViewModeCameraManCs>();
				if(m_cameraMan != null)
				{
					m_cameraMan.SetReferenceCamera(m_divaCamera);
					m_cameraMan.SetTargetObject(MenuScene.Instance.divaManager.gameObject);
					m_cameraMan.SetOperationType(ViewModeCameraManCs.OperationType.VERTICAL_MOVE_Y);
				}
				if(SystemManager.isLongScreenDevice)
				{
					FlexibleCameraChanger flex = FlexibleCameraChanger.AddComponent(m_cameraObj, true, false, 0, 0);
					flex.Initialize();
				}
			}
			MenuScene.Instance.divaManager.SetActive(true, false);
			if(m_gazeControl == null)
			{
				MenuDivaObject mdo = MenuScene.Instance.divaManager.GetComponentInChildren<MenuDivaObject>(true);
				m_gazeControl = mdo.StartGazeControl();
				m_gazeControl.TargetObj = m_cameraObj;
			}
		}

		// RVA: 0x1CE65A0 Offset: 0x1CE65A0 VA: 0x1CE65A0
		private void OnDestroy()
		{
			if(MenuScene.Instance != null)
			{
				if(MenuScene.Instance.divaManager != null)
				{
					MenuDivaObject mdo = MenuScene.Instance.divaManager.GetComponentInChildren<MenuDivaObject>(true);
					if(mdo != null)
					{
						mdo.FinishGazeControl();
						m_gazeControl = null;
					}
				}
			}
		}

		// RVA: 0x1CE67F4 Offset: 0x1CE67F4 VA: 0x1CE67F4
		private void Update()
		{
			if(m_cameraMan != null)
			{
				if(m_onEntered != null)
				{
					if(m_cameraMan.IsEntered())
					{
						m_onEntered();
						m_onEntered = null;
					}
				}
				if(m_cameraMan.IsFinished())
				{
					Destroy(gameObject);
					if (m_onFinished != null)
						m_onFinished();
				}
			}
		}

		//// RVA: 0x1CE696C Offset: 0x1CE696C VA: 0x1CE696C
		//public void StartUpdate() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6CD824 Offset: 0x6CD824 VA: 0x6CD824
		//// RVA: 0x1CE6990 Offset: 0x1CE6990 VA: 0x1CE6990
		//private IEnumerator Co_StartUpdate() { }

		//// RVA: 0x1CE6A3C Offset: 0x1CE6A3C VA: 0x1CE6A3C
		public void Goodbye()
		{
			if(m_cameraMan != null)
			{
				m_cameraMan.Restore();
				GameManager.Instance.SetFPS(30);
			}
			if(m_gazeControl != null)
			{
				m_gazeControl.Restore();
			}
		}

		//// RVA: 0x1CE6BB0 Offset: 0x1CE6BB0 VA: 0x1CE6BB0
		//public static GameObject Create() { }

		//// RVA: 0x1CE6D34 Offset: 0x1CE6D34 VA: 0x1CE6D34
		//public static void Enter(GameObject obj, Action onEntered) { }

		//// RVA: 0x1CE6E88 Offset: 0x1CE6E88 VA: 0x1CE6E88
		public static void Leave(GameObject obj, Action onFinished)
		{
			if(obj != null)
			{
				ViewScreenCostume v = obj.GetComponent<ViewScreenCostume>();
				if(v != null)
				{
					v.Goodbye();
					v.m_onFinished = onFinished;
				}
				GameManager.Instance.SetTouchEffectVisible(true);
			}
		}

		//// RVA: 0x1CE7014 Offset: 0x1CE7014 VA: 0x1CE7014
		//public void Reinstate() { }

		//// RVA: 0x1CE7064 Offset: 0x1CE7064 VA: 0x1CE7064
		//public void InputOn() { }

		//// RVA: 0x1CE70B4 Offset: 0x1CE70B4 VA: 0x1CE70B4
		//public void InputOff() { }

		//// RVA: 0x1CE7104 Offset: 0x1CE7104 VA: 0x1CE7104
		//public void SetDivaTargetObject() { }

		//// RVA: 0x1CE7254 Offset: 0x1CE7254 VA: 0x1CE7254
		//public void InitChangeDiva() { }

		//// RVA: 0x1CE73C4 Offset: 0x1CE73C4 VA: 0x1CE73C4
		//public void InitCameraRot() { }

		//// RVA: 0x1CE73F0 Offset: 0x1CE73F0 VA: 0x1CE73F0
		//public int GetState() { }

		//// RVA: 0x1CE74A8 Offset: 0x1CE74A8 VA: 0x1CE74A8
		//public float GetTgtRotCamZ() { }

		//// RVA: 0x1CE7560 Offset: 0x1CE7560 VA: 0x1CE7560
		//public void ClearCameraRot() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6CD89C Offset: 0x6CD89C VA: 0x6CD89C
		//// RVA: 0x1CE761C Offset: 0x1CE761C VA: 0x1CE761C
		//private bool <Co_StartUpdate>b__14_0() { }
	}
}
