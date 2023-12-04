using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class OfferSortCamAnimController : MonoBehaviour
	{
		private readonly string[] camAnimState = new string[3]
		{
			"val_go_cam_F", "val_go_cam_G", "val_go_cam_B"
		}; // 0xC
		private readonly string[] camAnimClipName = new string[3]
		{
			"val_go_cam_F", "val_go_cam_G", "val_go_cam_B"
		}; // 0x10
		private GameObject m_camObj; // 0x14
		private Animator m_camAnim; // 0x18
		private Vector3[] m_camDefPosList = new Vector3[3]; // 0x1C
		private Quaternion[] m_camDefRotList = new Quaternion[3]; // 0x20
		private Vector3[] m_camDefTgtPosList = new Vector3[3]; // 0x24
		private bool IsAnimation; // 0x28

		// [IteratorStateMachineAttribute] // RVA: 0x6FC584 Offset: 0x6FC584 VA: 0x6FC584
		// RVA: 0x170F81C Offset: 0x170F81C VA: 0x170F81C
		public IEnumerator Co_loadAssets(int from, Action LoadEndCallback)
		{
			string bundleName; // 0x1C
			AssetBundleLoadAllAssetOperationBase operation;

			//0x170FEA4
			bundleName = "mn/of/go.xab";
			operation = AssetBundleManager.LoadAllAssetAsync("mn/of/go.xab");
			yield return operation;
			m_camObj = gameObject;
			m_camAnim = m_camObj.AddComponent<Animator>();
			m_camAnim.runtimeAnimatorController = operation.GetAsset<RuntimeAnimatorController>("val_go_cam");
			List<AnimationClip> l = new List<AnimationClip>();
			for(int i = 0; i < 3; i++)
			{
				l.Add(operation.GetAsset<AnimationClip>(camAnimClipName[i]));
			}
			for(int i = 0; i < 3; i++)
			{
				l[i].SampleAnimation(m_camObj, 1);
				m_camDefPosList[i] = m_camObj.transform.position;
				m_camDefRotList[i] = m_camObj.transform.rotation;
				m_camDefTgtPosList[i] = Vector3.zero;
				Vector3 a = (m_camObj.transform.rotation * -Vector3.forward).normalized;
				Vector3 b = Vector3.up;
				float f1 = 1 - Vector3.Dot(a, b) * Vector3.Dot(a, b);
				if(f1 != 0)
				{
					Vector3 c = Vector3.zero - m_camObj.transform.position;
					m_camDefTgtPosList[i] = m_camObj.transform.position + (Vector3.Dot(a, c) - Vector3.Dot(a, b) * Vector3.Dot(b, c)) / f1 * a;
				}
			}
			if(LoadEndCallback != null)
				LoadEndCallback();
			AnimStart(from);
			yield return null;
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			yield return null;
		}

		// // RVA: 0x170F8FC Offset: 0x170F8FC VA: 0x170F8FC
		// public void ResetCameraPosition() { }

		// // RVA: 0x170FA04 Offset: 0x170FA04 VA: 0x170FA04
		public void AnimStart(int formType)
		{
			IsAnimation = true;
			m_camAnim.Play(camAnimState[formType], 0);
		}

		// RVA: 0x170FA7C Offset: 0x170FA7C VA: 0x170FA7C
		public bool IsPlayingAnim()
		{
			return m_camAnim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
		}

		// RVA: 0x170FB10 Offset: 0x170FB10 VA: 0x170FB10
		private void Start()
		{
			return;
		}

		// RVA: 0x170FB14 Offset: 0x170FB14 VA: 0x170FB14
		private void Update()
		{
			return;
		}
	}
}
