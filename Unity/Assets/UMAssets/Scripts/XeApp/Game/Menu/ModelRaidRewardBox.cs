using System.Collections;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class ModelRaidRewardBox : MonoBehaviour
	{
		[SerializeField]
		private Animator m_animObject; // 0xC
		[SerializeField]
		private Animator m_animCamera; // 0x10
		[SerializeField]
		private Camera m_camera; // 0x14
		public bool isSkip; // 0x18

		// // RVA: 0x1046820 Offset: 0x1046820 VA: 0x1046820
		public void AdjustCamera()
		{
			if(SystemManager.isLongScreenDevice)
			{
				FlexibleLayoutCamera fl = m_camera.GetComponent<FlexibleLayoutCamera>();
				if(fl != null)
				{
					fl.IsEnableFov = false;
					m_camera.fieldOfView = Mathf.CeilToInt(fl.GetDefaultFov(0) * MenuScene.GetLongScreenScale());
				}
			}
		}

		// RVA: 0x1046A3C Offset: 0x1046A3C VA: 0x1046A3C
		public void Setup()
		{
			isSkip = false;
			transform.SetParent(null);
			transform.localPosition = Vector3.zero;
			transform.localScale = Vector3.one;
			transform.localRotation = Quaternion.identity;
			Reset();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x715D44 Offset: 0x715D44 VA: 0x715D44
		// // RVA: 0x1046D88 Offset: 0x1046D88 VA: 0x1046D88
		public IEnumerator Enter()
		{
			//0x1047108
			m_camera.depth = 120;
			m_animObject.gameObject.SetActive(false);
			m_animObject.gameObject.SetActive(true);
			m_animObject.SetTrigger("Start");
			m_animObject.speed = 1;
			m_animCamera.gameObject.SetActive(false);
			m_animCamera.gameObject.SetActive(true);
			m_animCamera.SetTrigger("Start");
			m_animCamera.speed = 1;
			yield return new WaitForSeconds(1.6f);
			SoundManager.Instance.sePlayerResult.Play(43);
			while(m_animObject.GetCurrentAnimatorStateInfo(0).normalizedTime < 1 && !isSkip)
			{
				yield return null;
			}
			while(m_animCamera.GetCurrentAnimatorStateInfo(0).normalizedTime < 1 && !isSkip)
			{
				yield return null;
			}
		}

		// // RVA: 0x1046BF8 Offset: 0x1046BF8 VA: 0x1046BF8
		public void Reset()
		{
			m_animObject.gameObject.SetActive(false);
			m_animObject.gameObject.SetActive(true);
			m_animObject.speed = 0;
			m_animCamera.gameObject.SetActive(false);
			m_animCamera.gameObject.SetActive(true);
			m_animCamera.speed = 0;
			m_camera.depth = 80;
		}

		// // RVA: 0x1046E34 Offset: 0x1046E34 VA: 0x1046E34
		// public void Show() { }

		// // RVA: 0x1046F98 Offset: 0x1046F98 VA: 0x1046F98
		public void Hide()
		{
			if(m_animObject != null)
				m_animObject.gameObject.SetActive(false);
			if(m_animCamera != null)
				m_animCamera.gameObject.SetActive(false);
		}
	}
}
