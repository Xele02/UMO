using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class UnlockValkyrieObject : MonoBehaviour
	{
		private GameObject m_Object; // 0x28
		private ValkyrieResource m_Resource; // 0x2C
		private MenuValkyrieObject m_ValkyrieObject; // 0x30
		private GameObject m_CameraObj; // 0x34
		private Camera m_Camera; // 0x38
		private UnlockValkyrieScene.CameraInfo m_FinishCameraInfo; // 0x3C
		private int m_ValkyrieId; // 0x40
		private bool m_IsLoaded; // 0x44
		private bool m_IsEntered; // 0x45
		private bool m_IsFinished; // 0x46

		public UnlockValkyrieScene.CameraInfo DefaultCameraInfo { get; set; } // 0xC
		public UnlockValkyrieScene.CameraInfo FinishCameraInfo { get; set; } // 0x10
		public List<UnlockValkyrieScene.CameraInfo> FinishCameraInfoList { get; set; } // 0x14
		public float CameraFieldOfView { get; set; } // 0x18
		public float CameraFarClip { get; set; } // 0x1C
		public float CameraNearClip { get; set; } // 0x20
		public float CameraLerpTime { get; set; } // 0x24
		public Camera Camera { get { return m_Camera; } } //0x1650A1C

		// RVA: 0x1650AF4 Offset: 0x1650AF4 VA: 0x1650AF4
		public void Awake()
		{
			return;
		}

		// RVA: 0x16509F8 Offset: 0x16509F8 VA: 0x16509F8
		public void LoadResource(int valkyrie_id)
		{
			this.StartCoroutineWatched(Co_LoadResource(valkyrie_id));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x732E0C Offset: 0x732E0C VA: 0x732E0C
		//// RVA: 0x1650AF8 Offset: 0x1650AF8 VA: 0x1650AF8
		private IEnumerator Co_LoadResource(int valkyrie_id)
		{
			//0x1651E58
			m_Object = new GameObject("ValkyrieResource");
			m_Resource = m_Object.AddComponent<ValkyrieResource>();
			yield return null;
			m_Resource.LoadResourcesForMenu(valkyrie_id);
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0x1651260
				return !m_Resource.isAllLoaded;
			});
			m_ValkyrieObject = new GameObject("MenuValkyrieObject").AddComponent<MenuValkyrieObject>();
			m_ValkyrieObject.AddUseEffectName("EF_Con_vernier");
			m_ValkyrieObject.Initialize(m_Resource);
			m_ValkyrieObject.Activate(true);
			m_ValkyrieObject.SetForm(0);
			m_ValkyrieObject.transform.SetParent(m_Object.transform, false);
			Hide();
			m_CameraObj = new GameObject("Valkyrie Camera");
			m_CameraObj.transform.SetParent(m_Object.transform, false);
			m_Camera = m_CameraObj.AddComponent<Camera>();
			m_Camera.clearFlags = CameraClearFlags.Nothing;
			m_Camera.cullingMask = 1 << LayerMask.NameToLayer("Valkyrie");
			m_Camera.fieldOfView = CameraFieldOfView;
			m_Camera.farClipPlane = CameraFarClip;
			m_Camera.nearClipPlane = CameraNearClip;
			m_Camera.transform.localPosition = DefaultCameraInfo.CameraPos;
			m_Camera.transform.LookAt(DefaultCameraInfo.GetTargetPos());
			bool b = true;
			if(SystemManager.isLongScreenDevice)
			{
				m_Camera.fieldOfView = Mathf.CeilToInt(m_Camera.fieldOfView * MenuScene.GetLongScreenScale());
				b = false;
			}
			FlexibleCameraChanger.AddComponent(m_CameraObj, true, b, 0, 0);
			m_ValkyrieId = valkyrie_id;
			m_FinishCameraInfo = FinishCameraInfo;
			if (valkyrie_id > 0 && valkyrie_id - 1 < FinishCameraInfoList.Count)
			{
				m_FinishCameraInfo = FinishCameraInfoList[valkyrie_id - 1];
			}
			m_IsLoaded = true;
		}

		// RVA: 0x164F144 Offset: 0x164F144 VA: 0x164F144
		public bool IsLoaded()
		{
			return m_IsLoaded;
		}

		// RVA: 0x164ED64 Offset: 0x164ED64 VA: 0x164ED64
		public void Release()
		{
			Destroy(m_Object);
			m_IsFinished = false;
			m_IsLoaded = false;
			m_IsEntered = false;
			m_Object = null;
			m_Resource = null;
			m_ValkyrieObject = null;
			m_CameraObj = null;
			m_Camera = null;
		}

		// RVA: 0x164EB60 Offset: 0x164EB60 VA: 0x164EB60
		public void Reset()
		{
			m_IsEntered = false;
			m_IsFinished = false;
			Hide();
			m_Camera.transform.localPosition = DefaultCameraInfo.CameraPos;
			m_Camera.transform.LookAt(DefaultCameraInfo.GetTargetPos());
			m_FinishCameraInfo = FinishCameraInfo;
			if (m_ValkyrieId > 0)
			{
				if(m_ValkyrieId - 1 < FinishCameraInfoList.Count)
				{
					m_FinishCameraInfo = FinishCameraInfoList[m_ValkyrieId - 1];
				}
			}
		}

		//// RVA: 0x1650DA0 Offset: 0x1650DA0 VA: 0x1650DA0
		private void Show()
		{
			Renderer[] rs = m_Object.GetComponentsInChildren<Renderer>();
			for (int i = 0; i < rs.Length; i++)
			{
				rs[i].enabled = true;
			}
		}

		//// RVA: 0x1650BC0 Offset: 0x1650BC0 VA: 0x1650BC0
		private void Hide()
		{
			Renderer[] rs = m_Object.GetComponentsInChildren<Renderer>();
			for (int i = 0; i < rs.Length; i++)
			{
				rs[i].enabled = false;
			}
		}

		// RVA: 0x164F1DC Offset: 0x164F1DC VA: 0x164F1DC
		public FKGMGBHBNOC.HPJOCKGKNCC_Form GetCurrentForm()
		{
			if(!m_ValkyrieObject.fighter.activeSelf)
			{
				if(!m_ValkyrieObject.gerwalk.activeSelf)
				{
					if (!m_ValkyrieObject.battroid.activeSelf)
						return FKGMGBHBNOC.HPJOCKGKNCC_Form.AEFCOHJBLPO_Num;
					return FKGMGBHBNOC.HPJOCKGKNCC_Form.GBLPNIGCPAP_Battroid;
				}
				return FKGMGBHBNOC.HPJOCKGKNCC_Form.MOGAKDMDCJB_Gerwalk;
			}
			return FKGMGBHBNOC.HPJOCKGKNCC_Form.MABDGNNOPCB_Fighter;
		}

		// RVA: 0x16500D0 Offset: 0x16500D0 VA: 0x16500D0
		public void Enter()
		{
			this.StartCoroutineWatched(Co_Enter());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x732E84 Offset: 0x732E84 VA: 0x732E84
		//// RVA: 0x1650E84 Offset: 0x1650E84 VA: 0x1650E84
		private IEnumerator Co_Enter()
		{
			//0x1651824
			Show();
			m_ValkyrieObject.Unlock();
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0x1651290
				if(m_ValkyrieObject != null)
				{
					return m_ValkyrieObject.IsPlayingUnlockAnim();
				}
				return false;
			});
			m_IsEntered = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x732EFC Offset: 0x732EFC VA: 0x732EFC
		//// RVA: 0x1650F30 Offset: 0x1650F30 VA: 0x1650F30
		//private IEnumerator Co_EnterWatch() { }

		// RVA: 0x1650FDC Offset: 0x1650FDC VA: 0x1650FDC
		public void ValkyrieAnimSkip(float speed)
		{
			m_ValkyrieObject.AnimSpeedChenge(speed);
		}

		// RVA: 0x164F30C Offset: 0x164F30C VA: 0x164F30C
		public bool IsEntered()
		{
			return m_IsEntered;
		}

		//// RVA: 0x16500F4 Offset: 0x16500F4 VA: 0x16500F4
		public void Finish()
		{
			this.StartCoroutineWatched(Co_Finish());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x732F74 Offset: 0x732F74 VA: 0x732F74
		//// RVA: 0x1651010 Offset: 0x1651010 VA: 0x1651010
		private IEnumerator Co_Finish()
		{
			//0x1651C5C
			float elapsed = 0;
			yield return new WaitWhile(() =>
			{
				//0x1651408
				elapsed += Time.deltaTime;
				float r = Mathf.Clamp(elapsed / CameraLerpTime, 0, 1);
				if(r >= 1)
				{
					m_Camera.transform.localPosition = m_FinishCameraInfo.CameraPos;
					m_Camera.transform.LookAt(m_FinishCameraInfo.GetTargetPos());
					return false;
				}
				else
				{
					m_Camera.transform.localPosition = Vector3.Lerp(DefaultCameraInfo.CameraPos, m_FinishCameraInfo.CameraPos, r);
					m_Camera.transform.LookAt(Vector3.Lerp(DefaultCameraInfo.GetTargetPos(), m_FinishCameraInfo.GetTargetPos(), r));
					return true;
				}
			});
			m_IsFinished = true;
		}

		//// RVA: 0x16510BC Offset: 0x16510BC VA: 0x16510BC
		//public void watchValkyrie() { }

		//// RVA: 0x164F3DC Offset: 0x164F3DC VA: 0x164F3DC
		public bool IsFinished()
		{
			return m_IsFinished;
		}

		// RVA: 0x1651254 Offset: 0x1651254 VA: 0x1651254
		public void Update()
		{
			return;
		}
		
		//[CompilerGeneratedAttribute] // RVA: 0x73300C Offset: 0x73300C VA: 0x73300C
		//// RVA: 0x1651348 Offset: 0x1651348 VA: 0x1651348
		//private bool <Co_EnterWatch>b__51_0() { }
	}
}
