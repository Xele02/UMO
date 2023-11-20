using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class OfferSelectDivaController : MonoBehaviour
	{
		private const int DIVA_ID = 5;
		private const int MODEL_ID = 1;
		private const float OffsetY = 1000;
		private DivaMenuParam divaMenuParam; // 0xC
		private MenuDivaManager m_divaManager; // 0x10
		private Camera m_divaCamera; // 0x14
		private SimpleDivaObject m_divaObject; // 0x18
		private DivaResource m_divaResource; // 0x1C
		private StringBuilder m_bundleName = new StringBuilder(64); // 0x20
		private StringBuilder m_assetName = new StringBuilder(64); // 0x24
		private List<DivaResource.MotionOverrideClipKeyResource> overrideClipList = new List<DivaResource.MotionOverrideClipKeyResource>(); // 0x28
		private SimpleDivaAnimation m_simpleDivaAnimation; // 0x2C
		private Vector3 DefaultCamRot = new Vector3(-1.5f, -169, 0); // 0x30
		private Vector3 HideCamRot = new Vector3(-1.5f, -140, 0); // 0x3C
		public bool IsModelLoad; // 0x48
		public bool IsEnterSkip; // 0x49
		public bool IsEntering = false; // 0x4A
		public bool IsLeaving = false; // 0x4B
		public bool IsAloneMotion = true; // 0x4C
		private int AloneVoiceId = -1; // 0x50
		public FlexibleLayoutCamera flexCamera; // 0x54
		public bool IsDivaLeaveMotion; // 0x58
		private bool IsInCamera; // 0x59
		private Camera HomeDivaCamera; // 0x5C

		public bool IsInTransition { get { return m_divaObject.IsInTransition; } } //0x170182C

		// RVA: 0x17032F0 Offset: 0x17032F0 VA: 0x17032F0
		private void Start()
		{
			m_divaManager = MenuScene.Instance.divaManager;
			m_simpleDivaAnimation = GetComponentInChildren<SimpleDivaAnimation>(true);
			m_divaObject = m_simpleDivaAnimation.transform.Find("SimpleDivaPrefab").GetComponent<SimpleDivaObject>();
			HomeDivaCamera = m_divaManager.transform.Find("DivaCamera").GetComponent<Camera>();
		}

		// RVA: 0x17034B4 Offset: 0x17034B4 VA: 0x17034B4
		private void Update()
		{
			return;
		}

		// RVA: 0x17034B8 Offset: 0x17034B8 VA: 0x17034B8
		public void Initialize(bool IsFromHome)
		{
			IsDivaLeaveMotion = false;
			if(m_divaResource == null)
			{
				GameObject go = new GameObject("DivaResourceObject");
				go.transform.SetParent(transform);
				m_divaResource = go.AddComponent<DivaResource>();
			}
			IsAloneMotion = true;
			IsEnterSkip = false;
			HomeDivaCamera.enabled = false;
			if(IsModelLoad)
			{
				m_divaCamera.enabled = true;
				DivaPlayIdle();
			}
			else
			{
				this.StartCoroutineWatched(Co_LoadDivaResource());
			}
		}

		// RVA: 0x1703750 Offset: 0x1703750 VA: 0x1703750
		public void initializeCamera(bool IsFromHome = false)
		{
			IsInCamera = false;
			divaMenuParam = GameManager.Instance.divaResource.divaMenuParam;
			m_divaCamera = Instantiate(HomeDivaCamera);
			m_divaCamera.transform.rotation = Quaternion.Euler(HideCamRot);
			m_divaCamera.transform.position = new Vector3(m_divaCamera.transform.position.x, divaMenuParam.CameraPosY(DivaMenuParam.CameraPosType.Default)[5] + 1000, m_divaCamera.transform.position.z);
			m_divaCamera.transform.SetParent(MenuScene.Instance.transform, false);
			flexCamera = gameObject.GetComponent<FlexibleLayoutCamera>();
			flexCamera.AddCamera(m_divaCamera, 25);
			if(SystemManager.isLongScreenDevice)
			{
				flexCamera.IsEnableFov = false;
				m_divaCamera.fieldOfView = Mathf.CeilToInt(flexCamera.GetDefaultFov(0) * MenuScene.GetLongScreenScale());
			}
		}

		// RVA: 0x1703CE4 Offset: 0x1703CE4 VA: 0x1703CE4
		public void DestroyScene()
		{
			Destroy(m_divaCamera.gameObject);
			flexCamera.CameraListClear();
		}

		// RVA: 0x1703DAC Offset: 0x1703DAC VA: 0x1703DAC
		public void DeleteCash()
		{
			m_simpleDivaAnimation.transform.SetParent(transform, false);
		}

		//// RVA: 0x1703E14 Offset: 0x1703E14 VA: 0x1703E14
		//public void SetVisible(bool isEnable) { }

		//// RVA: 0x1703E64 Offset: 0x1703E64 VA: 0x1703E64
		//private void EnableCamera(bool isEnable) { }

		//// RVA: 0x1701858 Offset: 0x1701858 VA: 0x1701858
		//public void AnimPause() { }

		//// RVA: 0x17019B4 Offset: 0x17019B4 VA: 0x17019B4
		//public void AnimResume() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FB6B4 Offset: 0x6FB6B4 VA: 0x6FB6B4
		//// RVA: 0x170368C Offset: 0x170368C VA: 0x170368C
		private IEnumerator Co_LoadDivaResource()
		{
			//0x17054C0
			IsModelLoad = false;
			yield return this.StartCoroutineWatched(Co_LoadSimpleDivaAnimation());
			m_divaObject.transform.localPosition = new Vector3(0, 1000, 0);
			m_divaCamera.enabled = true;
			m_divaObject.enabled = true;
			m_divaObject.gameObject.SetActive(true);
			m_divaCamera.targetTexture = null;
			m_divaCamera.clearFlags = CameraClearFlags.Nothing;
			m_simpleDivaAnimation.transform.SetParent(MenuScene.Instance.transform, false);
			IsModelLoad = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FB72C Offset: 0x6FB72C VA: 0x6FB72C
		//// RVA: 0x1703F98 Offset: 0x1703F98 VA: 0x1703F98
		private IEnumerator Co_LoadSimpleDivaAnimation()
		{
			//0x170589C
			List<string> lstr = new List<string>();
			lstr.Add("diva_{0:D3}_menu_leave_{1}");
			lstr.Add("diva_{0:D3}_menu_reaction01_{1}");
			lstr.Add("diva_{0:D3}_menu_reaction02_{1}");
			lstr.Add("diva_{0:D3}_menu_reaction03_{1}");
			lstr.Add("diva_{0:D3}_menu_simple_talk01_{1}");
			List<string> lstr2 = new List<string>();
			lstr2.Add("diva_{0:D3}_menu_simple_loop01_{1}");
			lstr2.Add("diva_{0:D3}_menu_simple_loop02_{1}");
			m_simpleDivaAnimation.m_divaResource = m_divaResource;
			m_simpleDivaAnimation.LoadResource(5, 1, 0, lstr, lstr2, "cs_vfo");
			yield return new WaitWhile(() =>
			{
				//0x17048D4
				return m_simpleDivaAnimation.m_IsLoading;
			});
			yield return null;
		}

		// RVA: 0x1703718 Offset: 0x1703718 VA: 0x1703718
		public void DivaPlayIdle()
		{
			if (!IsModelLoad)
				return;
			m_simpleDivaAnimation.StartIdleMotion();
		}

		//// RVA: 0x1704044 Offset: 0x1704044 VA: 0x1704044
		//public void CrossChangeLeaveMotion(Action act) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6FB7A4 Offset: 0x6FB7A4 VA: 0x6FB7A4
		//// RVA: 0x1704074 Offset: 0x1704074 VA: 0x1704074
		//private IEnumerator CoCrossChengeLeave(Action act) { }

		//// RVA: 0x170170C Offset: 0x170170C VA: 0x170170C
		public void CrossChangeIdle(Action ChengeEndAction)
		{
			if (!IsModelLoad)
				return;
			this.StartCoroutineWatched(Co_CrossChengeIdle(ChengeEndAction));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FB81C Offset: 0x6FB81C VA: 0x6FB81C
		//// RVA: 0x170413C Offset: 0x170413C VA: 0x170413C
		private IEnumerator Co_CrossChengeIdle(Action ChengeEndAction)
		{
			//0x1704BB4
			DivaStopVoice();
			m_simpleDivaAnimation.CrossFadeIdel("simple_idle");
			while (!m_simpleDivaAnimation.IsPlayingIdle())
				yield return null;
			if (ChengeEndAction != null)
				ChengeEndAction();
		}

		// RVA: 0x1704204 Offset: 0x1704204 VA: 0x1704204
		public void DivaPlayEntry()
		{
			if (IsDivaLeaveMotion)
				return;
			m_simpleDivaAnimation.StartEntryMotion();
			DivaPlayVoice(OfferVoiceDataTable.VoiceType.Entry);
		}

		//// RVA: 0x1704300 Offset: 0x1704300 VA: 0x1704300
		//public void DivaPlayLeave() { }

		// RVA: 0x1704340 Offset: 0x1704340 VA: 0x1704340
		public void DivaPlayTouchReaction()
		{
			int n = UnityEngine.Random.Range(1, 4);
			m_simpleDivaAnimation.StartSimpleMotion(n);
			DivaPlayVoice(OfferVoiceDataTable.VoiceType.ToIdle3 + n);
		}

		// RVA: 0x1704394 Offset: 0x1704394 VA: 0x1704394
		public void DivaPlayLeaveAlone()
		{
			if(IsAloneMotion && IsModelLoad)
			{
				int n = 0;
				do
				{
					n = UnityEngine.Random.Range(0, 3);
				} while (AloneVoiceId == n);
				if (n + 3 == 5)
					m_simpleDivaAnimation.StartSimpleMotion(4);
				else
					m_simpleDivaAnimation.StartSimpleLoopMotion(0);
				DivaPlayVoice(OfferVoiceDataTable.VoiceType.ToIdle1 + n);
				AloneVoiceId = n;
			}
		}

		//// RVA: 0x170424C Offset: 0x170424C VA: 0x170424C
		public void DivaPlayVoice(OfferVoiceDataTable.VoiceType type)
		{
			m_simpleDivaAnimation.PlayVoiceRandom(OfferVoiceDataTable.VoiceTable(type), -1);
		}

		// RVA: 0x170177C Offset: 0x170177C VA: 0x170177C
		public void DivaStopVoice()
		{
			if (!IsModelLoad)
				return;
			m_simpleDivaAnimation.StopVoice();
		}

		//// RVA: 0x1704428 Offset: 0x1704428 VA: 0x1704428
		//public bool IsPlayingEntry() { }

		// RVA: 0x17017F0 Offset: 0x17017F0 VA: 0x17017F0
		public bool IsPlayingIdle()
		{
			if (!IsModelLoad)
				return false;
			return m_simpleDivaAnimation.IsPlayingIdle();
		}

		//// RVA: 0x1704464 Offset: 0x1704464 VA: 0x1704464
		//public bool IsPlayingLeave() { }

		// RVA: 0x1701740 Offset: 0x1701740 VA: 0x1701740
		public bool IsPlayingDivaVoice()
		{
			if (!IsModelLoad)
				return false;
			return m_simpleDivaAnimation.IsPlayingVoice();
		}

		// RVA: 0x17017B4 Offset: 0x17017B4 VA: 0x17017B4
		public bool IsPlayingIdleMouth()
		{
			if (!IsModelLoad)
				return false;
			return m_simpleDivaAnimation.IsPlayingIdleMouth();
		}

		//// RVA: 0x17044A4 Offset: 0x17044A4 VA: 0x17044A4
		//public void SetDivaVisible(bool isVisible) { }

		// RVA: 0x17044D8 Offset: 0x17044D8 VA: 0x17044D8
		public void DivaEnterCamera()
		{
			if (IsDivaLeaveMotion)
				return;
			IsInCamera = true;
			this.StartCoroutineWatched(Co_DivaEnterCamera());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FB894 Offset: 0x6FB894 VA: 0x6FB894
		//// RVA: 0x1704514 Offset: 0x1704514 VA: 0x1704514
		private IEnumerator Co_DivaEnterCamera()
		{
			float beginNormalizePos; // 0x14
			float endNormalizePos; // 0x18
			float ct; // 0x1C
			float time; // 0x20

			//0x1704D94
			IsEntering = true;
			m_divaCamera.transform.rotation = Quaternion.Euler(HideCamRot);
			beginNormalizePos = DefaultCamRot.y;
			ct = 0;
			endNormalizePos = HideCamRot.y;
			time = 0.25f;
			do
			{
				ct = Mathf.Clamp(ct + Time.deltaTime, 0, time);
				m_divaCamera.transform.rotation = Quaternion.Euler(DefaultCamRot.x, XeSys.Math.Tween.Evaluate(XeSys.Math.Tween.EasingFunc.Liner, endNormalizePos, beginNormalizePos, ct / time), DefaultCamRot.z);
				if (ct >= time)
					break;
				yield return null;
			} while (true);
			IsEntering = false;
		}

		// RVA: 0x17045C0 Offset: 0x17045C0 VA: 0x17045C0
		public void DivaLeaveCamera()
		{
			if (IsInCamera)
			{
				this.StartCoroutineWatched(Co_DivaLeaveCamera());
			}
			else
				IsLeaving = false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FB90C Offset: 0x6FB90C VA: 0x6FB90C
		//// RVA: 0x1704600 Offset: 0x1704600 VA: 0x1704600
		private IEnumerator Co_DivaLeaveCamera()
		{
			float beginNormalizePos; // 0x14
			float endNormalizePos; // 0x18
			float ct; // 0x1C
			float time; // 0x20

			//0x1705170
			IsLeaving = true;
			beginNormalizePos = DefaultCamRot.y;
			ct = 0;
			endNormalizePos = HideCamRot.y;
			time = 0.5f;
			do
			{
				ct = Mathf.Clamp(ct + Time.deltaTime, 0, time);
				m_divaCamera.transform.rotation = Quaternion.Euler(DefaultCamRot.x, XeSys.Math.Tween.Evaluate(XeSys.Math.Tween.EasingFunc.Liner, beginNormalizePos, endNormalizePos, ct / time), DefaultCamRot.z);
				if (ct >= time)
					break;
				yield return null;
			} while (true);
			IsLeaving = false;
		}

		// RVA: 0x17046AC Offset: 0x17046AC VA: 0x17046AC
		public void Release()
		{
			if(m_simpleDivaAnimation != null)
			{
				m_simpleDivaAnimation.Release();
			}
			IsModelLoad = false;
		}
	}
}
