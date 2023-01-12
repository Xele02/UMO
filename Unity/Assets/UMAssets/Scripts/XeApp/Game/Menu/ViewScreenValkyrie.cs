using System;
using System.Collections;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class ViewScreenValkyrie : MonoBehaviour
	{
		private static readonly float VALKYRIE_TRANSFORM_CANCEL = 0.7f; // 0x0
		private static readonly float VALKYRIE_TRANSFORM_TIME = 0.6f; // 0x4
		private static readonly float VALKYRIE_TRANSFORM_WAIT_TIME = VALKYRIE_TRANSFORM_CANCEL + VALKYRIE_TRANSFORM_TIME; // 0x8
		private ValkyrieResource m_valkyrieRes; // 0xC
		private MenuValkyrieObject m_valkyrieObj; // 0x10
		private GameObject m_cameraObj; // 0x14
		private Camera m_camera; // 0x18
		private Vector3 m_valkyriePoseAngle = new Vector3(-14, -15, 0); // 0x1C
		private int m_vfId; // 0x28
		private int m_form; // 0x2C
		private int m_nextVfId; // 0x30
		private int m_nextForm; // 0x34
		private int m_currentForm; // 0x38
		private bool m_loading; // 0x3C
		private bool m_is_loaded; // 0x3D
		private int m_cnt; // 0x40
		private int m_life; // 0x44
		private Action ShowLoadingEffect; // 0x48
		private Action HideLoadingEffect; // 0x4C
		private bool IsCreateCameraMan = true; // 0x50

		//public Camera ValkyrieCamera { get; } 0x1CE786C
		//public bool IsLoading { get; } 0x1CE7874

		// RVA: 0x1CE787C Offset: 0x1CE787C VA: 0x1CE787C
		private void Start()
		{
			m_valkyrieRes = gameObject.AddComponent<ValkyrieResource>();
			m_nextVfId = m_vfId;
			m_nextForm = m_form;
			StartCoroutine(Co_loadAssets());
		}

		// RVA: 0x1CE79B8 Offset: 0x1CE79B8 VA: 0x1CE79B8
		private void Update()
		{
			if (m_loading)
				return;

			if (m_nextVfId != m_vfId)
			{
				m_vfId = m_nextVfId;
				m_form = m_nextForm;
				if (m_valkyrieObj != null)
				{
					Destroy(m_valkyrieObj.gameObject);
				}
				StartCoroutine(Co_loadAssets());
				m_life = 0;
				return;
			}
			if (m_life == 0)
			{
				m_valkyrieObj.SetForm(m_form);
				Renderer[] rs = m_valkyrieObj.GetComponentsInChildren<Renderer>();
				for(int i = 0; i < rs.Length; i++)
				{
					rs[i].enabled = true;
				}
			}
			m_is_loaded = true;
			m_life++;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7343A4 Offset: 0x7343A4 VA: 0x7343A4
		//// RVA: 0x1CE792C Offset: 0x1CE792C VA: 0x1CE792C
		private IEnumerator Co_loadAssets()
		{
			//0x1CE8AE4
			m_loading = true;
			m_is_loaded = false;
			yield return Resources.UnloadUnusedAssets();

			ShowLoadingEffect();
			m_valkyrieRes.LoadResourcesForMenu(m_vfId);
			yield return null;

			while (!m_valkyrieRes.isAllLoaded)
				yield return null;

			m_cnt++;
			GameObject go = new GameObject("ValkyrieObject" + m_cnt);
			m_valkyrieObj = go.AddComponent<MenuValkyrieObject>();
			m_valkyrieObj.Initialize(m_valkyrieRes);
			m_valkyrieObj.Activate(true);
			m_valkyrieObj.SetForm(m_nextForm);
			m_valkyrieObj.transform.SetParent(transform, false);
			Renderer[] rs = m_valkyrieObj.GetComponentsInChildren<Renderer>();
			for(int i = 0; i < rs.Length; i++)
			{
				rs[i].enabled = false;
			}
			if(m_cameraObj == null)
			{
				m_cameraObj = new GameObject("View camera");
				m_cameraObj.transform.SetParent(transform, false);
				m_camera = m_cameraObj.AddComponent<Camera>();
				m_cameraObj.AddComponent<OptimalFXAA>();
				if(IsCreateCameraMan)
				{
					ViewModeCameraMan camMan = m_cameraObj.AddComponent<ViewModeCameraMan>();
					yield return camMan.Co_loadAssets();
					if(!SystemManager.isLongScreenDevice)
					{
						FlexibleCameraChanger f = FlexibleCameraChanger.AddComponent(m_cameraObj, true, false, 0, 0);
						f.Initialize();
					}
				}
			}
			ViewModeCameraMan v = m_cameraObj.GetComponent<ViewModeCameraMan>();
			if(v != null)
			{
				v.SetTargetObject(m_valkyrieObj.gameObject);
				v.SetOperationType(0);
				v.SetDefaultAngle(0, m_valkyriePoseAngle);
				!!!
			}
		}

		//// RVA: 0x1CE7CB8 Offset: 0x1CE7CB8 VA: 0x1CE7CB8
		//public void Show() { }

		//// RVA: 0x1CE7DE4 Offset: 0x1CE7DE4 VA: 0x1CE7DE4
		//public void Hide() { }

		//// RVA: 0x1CE7F10 Offset: 0x1CE7F10 VA: 0x1CE7F10
		//public bool IsShow() { }

		//// RVA: 0x1CE8000 Offset: 0x1CE8000 VA: 0x1CE8000
		//public bool IsLoaded() { }

		//// RVA: 0x1CE8008 Offset: 0x1CE8008 VA: 0x1CE8008
		//public bool IsChangeValkyrie() { }

		//// RVA: 0x1CE8020 Offset: 0x1CE8020 VA: 0x1CE8020
		//public void ChangeValkyrie(int vfid, int form) { }

		//// RVA: 0x1CE802C Offset: 0x1CE802C VA: 0x1CE802C
		//public void ChangeFormType(int formType, bool changeAnimFlag) { }

		//[IteratorStateMachineAttribute] // RVA: 0x73441C Offset: 0x73441C VA: 0x73441C
		//// RVA: 0x1CE829C Offset: 0x1CE829C VA: 0x1CE829C
		//public IEnumerator Co_WaitEnableTransformation(Action ChangeFormEndCallBack) { }

		//// RVA: 0x1CE8364 Offset: 0x1CE8364 VA: 0x1CE8364
		//public int GetValkyrieId() { }

		//// RVA: 0x1CE836C Offset: 0x1CE836C VA: 0x1CE836C
		//public int GetFormType() { }

		//// RVA: 0x1CE8374 Offset: 0x1CE8374 VA: 0x1CE8374
		//public float GetChangeWaitTime() { }

		//// RVA: 0x1CE8400 Offset: 0x1CE8400 VA: 0x1CE8400
		//public static GameObject Create(int vfId, int form, Action _ShowLodingEffect, Action _HideLodingEffect, bool _IsCameraMan = True) { }

		//// RVA: 0x1CE85B8 Offset: 0x1CE85B8 VA: 0x1CE85B8
		//public void ValkyrieChenge(int NextVfId, int NextForm) { }

		//// RVA: 0x1CE8684 Offset: 0x1CE8684 VA: 0x1CE8684
		//public void ValkyrieAllRelease() { }

		// RVA: 0x1CE7BD0 Offset: 0x1CE7BD0 VA: 0x1CE7BD0
		public static void Destroy(GameObject obj)
		{
			if(obj!= null)
			{
				Destroy(obj);
			}
		}
	}
}
