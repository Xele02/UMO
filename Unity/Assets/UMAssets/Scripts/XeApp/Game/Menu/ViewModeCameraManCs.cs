using UnityEngine;
using XeSys;

namespace XeApp.Game.Menu
{
	[RequireComponent(typeof(Camera))] // RVA: 0x63EF88 Offset: 0x63EF88 VA: 0x63EF88
	public class ViewModeCameraManCs : MonoBehaviour
	{
		public enum OperationType
		{
			VERTICAL_ROT_X = 0,
			VERTICAL_MOVE_Y = 1,
			VERTICAL_PAN_X = 2,
		}

		public static readonly float TRANSITION_TIME = 0.5f; // 0x0
		private const float CAMERA_FAR_CLIP = 100;
		private const float CAMERA_NEAR_CLIP = 0.1f;
		public float ROT_SPEED_RATE_PER_PIXEL_Y = 0.14f; // 0xC
		public float ROT_SPEED_DIVA = 0.02f; // 0x10
		private const float ROT_SPEED_RATE_PER_PIXEL_X = -0.25f;
		private const float DIST_RANGE_RATE_MIN = 0.2f;
		private const float DIST_RANGE_RATE_MAX = 1.8f;
		private const float FIELD_OF_VIEW_MIN = 10;
		private const float FIELD_OF_VIEW_MAX = 37;
		private const float DEFAULT_DIVA_CENTER_Y = 12;
		private float m_diva_center_y = 12; // 0x14
		private float m_default_diva_center_y = 12; // 0x18
		private const float PINCH_OUT_POWER = 20;
		private GameObject m_targetObj; // 0x1C
		private Vector3 m_targetCenter = Vector3.zero; // 0x20
		private float m_targetRadius = 1.0f; // 0x2C
		private Transform m_targetTr; // 0x30
		private Vector3 m_center = Vector3.zero; // 0x34
		private Vector3 m_eye = new Vector3(0, 0, 220); // 0x40
		private Quaternion m_rot = Quaternion.identity; // 0x4C
		private Vector3 m_rotSpeed = Vector3.zero; // 0x5C
		private Vector3 m_rotAngle = Vector3.zero; // 0x68
		private float m_defaultDist = 200; // 0x74
		private Vector3 m_moveSpeed = Vector3.zero; // 0x78
		private Vector3 m_baseEye = Vector3.zero; // 0x84
		private Quaternion m_divaRot = Quaternion.identity; // 0x90
		private float m_tgtRotCamZ; // 0xA0
		private float m_rotCamZ; // 0xA4
		private Vector3 m_bbMax; // 0xA8
		private Vector3 m_bbMin; // 0xB4
		private Camera m_camera; // 0xC0
		private OperationType m_operationType = OperationType.VERTICAL_MOVE_Y; // 0xC4
		private Camera m_referenceCamera; // 0xC8
		private Vector3 m_originalPosition = Vector3.zero; // 0xCC
		private Quaternion m_originalRotation = Quaternion.identity; // 0xD8
		private Vector3 m_originalCenter = Vector3.zero; // 0xE8
		private Quaternion m_originalRotateRev = Quaternion.identity; // 0xF4
		private Vector3 m_viewCenter = Vector3.zero; // 0x104
		private Quaternion m_viewRotateRev = Quaternion.identity; // 0x110
		private float m_leapAlpha; // 0x120
		private Vector3 m_targetPosition = Vector3.zero; // 0x124
		private Quaternion m_targetRotation = Quaternion.identity; // 0x130
		private float m_targetFov; // 0x140
		private Vector3 m_baseCenter = Vector3.up * 12; // 0x144
		private int m_state; // 0x150
		private float m_time; // 0x154
		private bool m_endFlag; // 0x158
		private bool m_is_input; // 0x159
		private bool m_is_update; // 0x15A
		private float m_deviceRotateFlag; // 0x15C
		private Quaternion m_divaOriginalRot = Quaternion.identity; // 0x160

		// RVA: 0xADFD74 Offset: 0xADFD74 VA: 0xADFD74
		private void Awake()
		{
			GetComponent<Camera>().enabled = false;
		}

		// RVA: 0xADFDFC Offset: 0xADFDFC VA: 0xADFDFC
		private void Start()
		{
			m_camera = GetComponent<Camera>();
			if(m_camera != null)
			{
				m_camera.enabled = true;
				m_camera.clearFlags = m_referenceCamera.clearFlags;
				m_camera.cullingMask = m_referenceCamera.cullingMask;
				m_camera.fieldOfView = m_referenceCamera.fieldOfView;
				m_camera.farClipPlane = m_referenceCamera.farClipPlane;
				m_camera.nearClipPlane = m_referenceCamera.nearClipPlane;
				m_camera.transform.position = m_referenceCamera.transform.position;
				m_camera.transform.rotation = m_referenceCamera.transform.rotation;
				m_default_diva_center_y = m_referenceCamera.transform.position.y;
				Init(m_referenceCamera.transform.position, m_referenceCamera.transform.rotation);
			}
			m_referenceCamera.enabled = false;
			MenuScene.Instance.divaManager.LockBoneSpring();
		}

		// RVA: 0xAE077C Offset: 0xAE077C VA: 0xAE077C
		private void Update()
		{
			if (!m_is_update)
				return;
			switch (m_state)
			{
				case 0:
					{
						m_time += Time.deltaTime;
						float r = Mathf.Clamp01(m_time / TRANSITION_TIME);
						float f = Mathf.Sin(r * 1.570796f);
						transform.localPosition = Vector3.Lerp(m_originalPosition, m_targetPosition, f);
						transform.localRotation = Quaternion.Lerp(m_originalRotation, m_targetRotation, f);
						if (r < 1)
							return;
						m_targetCenter = m_targetTr.TransformPoint(Vector3.up * m_default_diva_center_y);
						m_eye = Vector3.forward * (m_targetCenter - m_targetPosition).magnitude;
						m_viewCenter = transform.TransformPoint(m_eye);
						m_viewRotateRev = m_targetRotation * Quaternion.AngleAxis(180, Vector3.up);
						m_state++;
						MenuScene.Instance.divaManager.UnlockBoneSpring();
					}
					return;
				case 1:
					if (!m_is_input)
					{
						m_state = -1;
						return;
					}
					break;
				case 2:
					{
						m_time += Time.deltaTime;
						float r = Mathf.Clamp01(m_time / TRANSITION_TIME);
						float f = Mathf.Sin(r * 1.570796f);
						m_eye = Vector3.Lerp(m_eye, m_baseEye, f);
						transform.localPosition = Vector3.Lerp(m_center, m_originalCenter, f) + (Quaternion.Lerp(m_rot, m_originalRotateRev, f) * m_eye);
						transform.localRotation = ((Quaternion.LookRotation((Vector3.Lerp(m_center, m_originalCenter, f) - transform.position))) * Quaternion.AngleAxis(Mathf.Lerp(m_rotCamZ, 0, f), Vector3.forward));
						m_camera.fieldOfView = Mathf.Lerp(m_targetFov, m_referenceCamera.fieldOfView, f);
						m_targetObj.transform.localRotation = m_divaOriginalRot * Quaternion.Lerp(m_divaRot, Quaternion.identity, f);
						if (r < 1)
							return;
						MenuScene.Instance.divaManager.UnlockBoneSpring();
						m_state = -1;
						m_referenceCamera.enabled = true;
						m_camera.enabled = false;
						m_endFlag = true;
					}
					return;
				case 3:
					{
						m_time += Time.deltaTime;
						float r = Mathf.Clamp01(m_time / TRANSITION_TIME);
						float f = Mathf.Sin(r * 1.570796f);
						m_eye = Vector3.Lerp(m_eye, m_baseEye, f);
						transform.localPosition = Vector3.Lerp(m_center, m_viewCenter, f) + m_rot * m_eye;
						transform.localRotation = Quaternion.LookRotation(Vector3.Lerp(m_center, m_viewCenter, f) - transform.position) * Quaternion.AngleAxis(Mathf.Lerp(m_rotCamZ, 0, f), Vector3.forward);
						if (r < 1)
							return;
						MenuScene.Instance.divaManager.UnlockBoneSpring();
						m_targetCenter = m_targetTr.TransformPoint(Vector3.up * m_default_diva_center_y);
						m_baseCenter = m_targetTr.TransformPoint(Vector3.up * m_diva_center_y);
						m_rotAngle = Vector3.zero;
						m_baseEye = Vector3.forward * m_targetRadius;
						m_center = m_targetCenter;
						m_eye = m_baseEye;
						m_rotAngle.x = Mathf.Atan2(m_diva_center_y - m_default_diva_center_y, m_eye.z) * -180 / 3.141593f;
						m_rot = Quaternion.Euler(m_rotAngle.x, m_rotAngle.y, 0);
						m_divaRot = Quaternion.identity;
						m_state = -1;
					}
					return;
				default:
					return;
			}
			if(Screen.orientation == ScreenOrientation.LandscapeRight || Screen.orientation == ScreenOrientation.LandscapeLeft)
			{
				m_deviceRotateFlag = Screen.orientation == ScreenOrientation.LandscapeRight ? 1 : -1;
			}
			if(Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight)
			{
				m_tgtRotCamZ = 0;
			}
			else if(Input.deviceOrientation == DeviceOrientation.Portrait)
			{
				m_tgtRotCamZ = m_deviceRotateFlag * 90;
			}
			else if(Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown)
			{
				m_tgtRotCamZ = m_deviceRotateFlag * - 90;
			}
			m_rotCamZ = Mathf.Lerp(m_rotCamZ, m_tgtRotCamZ, Time.deltaTime * 10.0f);
			updateCameraOperation();
			updateCameraCore();
		}

		// RVA: 0xAE2820 Offset: 0xAE2820 VA: 0xAE2820
		private void OnDestroy()
		{
			if(m_referenceCamera != null)
			{
				m_referenceCamera.enabled = true;
			}
			if(m_camera != null)
			{
				m_camera.enabled = false;
			}
		}

		//// RVA: 0xAE2548 Offset: 0xAE2548 VA: 0xAE2548
		private void updateCameraCore()
		{
			m_center = Vector3.Lerp(m_center, m_targetCenter, Time.deltaTime * 10);
			transform.position = m_baseCenter + Quaternion.Euler(0, m_rotAngle.y, 0) * m_eye;
			transform.localRotation = Quaternion.LookRotation(m_center - transform.position) * Quaternion.AngleAxis(m_rotCamZ, Vector3.forward);
		}

		//// RVA: 0xAE1C00 Offset: 0xAE1C00 VA: 0xAE1C00
		private void updateCameraOperation()
		{
			if(InputManager.Instance != null)
			{
				float f = 0.9f;
				if (InputManager.Instance.GetInScreenTouchCount() == 1)
				{
					TouchInfo touch = InputManager.Instance.GetFirstInScreenTouchRecord().FindRecentInfo(0);
					if (IsTouchPoisitionInScreen(touch.GetSceneInnerPosition()) && touch.isMoved)
					{
						TouchInfo touch2 = InputManager.Instance.GetFirstInScreenTouchRecord().FindRecentInfo(0);

						Quaternion v2 = Quaternion.AngleAxis(-m_rotCamZ, Vector3.forward);
						Vector3 v1 = v2 * new Vector3(touch2.x, touch2.y, 0);
						Vector3 v = v2 * new Vector3(touch.x, touch.y, 0);
						m_rotSpeed = new Vector3(m_operationType == OperationType.VERTICAL_ROT_X ? (v.y - v1.y) * -0.25f : 0
											, (v.x - v1.x) * ROT_SPEED_RATE_PER_PIXEL_Y
											, (v.x - v1.x) * ROT_SPEED_DIVA);
						if (m_operationType != OperationType.VERTICAL_MOVE_Y)
							m_moveSpeed.y = 0;
						else
						{
							f = (v.y - v2.y) * 0.02f * ((m_eye.z + 5) / (m_defaultDist + 5));
							m_moveSpeed.y = f;
						}
					}
					else
					{
						f = 0.5f;
						m_rotSpeed *= f;
						m_moveSpeed.y *= f;
					}
				}
				else
				{
					m_rotSpeed *= f;
					m_moveSpeed.y *= f;
				}
				m_rotAngle += m_rotSpeed;
				m_rotAngle.x = Mathf.Clamp(m_rotAngle.x, -80, 80);
				m_rot = Quaternion.Euler(m_rotAngle.x, m_rotAngle.y, 0);
				m_divaRot = Quaternion.Euler(0, -m_rotAngle.z, 0);
				m_targetObj.transform.localRotation = m_divaOriginalRot * m_divaRot;
				if(InputManager.Instance.GetInScreenTouchCount() > 1)
				{
					m_targetFov = Mathf.Clamp(m_camera.fieldOfView + InputManager.Instance.pinchDelta * -20, 10, 37);
					m_camera.fieldOfView = m_targetFov;
				}
				m_targetCenter = m_targetCenter + m_moveSpeed;
				float f2 = m_eye.z * Mathf.Tan((m_camera.fieldOfView * 0.5f * 3.141593f) / 180) * 0.7f;
				m_targetCenter.y = Mathf.Clamp(m_targetCenter.y, f2 + m_bbMin.y, m_bbMax.y - f2);
			}
		}

		//// RVA: 0xAE2A88 Offset: 0xAE2A88 VA: 0xAE2A88
		public void SetTargetObject(GameObject obj)
		{
			m_targetObj = obj;
			Vector3 max = Vector3.negativeInfinity;
			Vector3 min = Vector3.positiveInfinity;
			SkinnedMeshRenderer[] sr = m_targetObj.GetComponentsInChildren<SkinnedMeshRenderer>();
			for(int i = 0; i < sr.Length; i++)
			{
				max = Vector3.Max(max, sr[i].bounds.max);
				min = Vector3.Max(min, sr[i].bounds.min);
				m_targetTr = sr[i].transform;
			}
			m_bbMax = max;
			m_bbMin = min;
			m_diva_center_y = m_referenceCamera.transform.localPosition.y;
			m_default_diva_center_y = m_diva_center_y;
		}

		//// RVA: 0xAE2D88 Offset: 0xAE2D88 VA: 0xAE2D88
		//private Transform findTransformByNameInChildren(string theName, GameObject obj) { }

		//// RVA: 0xAE2EC0 Offset: 0xAE2EC0 VA: 0xAE2EC0
		public void SetReferenceCamera(Camera camera)
		{
			m_referenceCamera = camera;
		}

		//// RVA: 0xAE2EC8 Offset: 0xAE2EC8 VA: 0xAE2EC8
		public void SetOperationType(OperationType ope)
		{
			m_operationType = ope;
		}

		//// RVA: 0xAE2ED0 Offset: 0xAE2ED0 VA: 0xAE2ED0
		public void Restore()
		{
			m_state = 2;
			m_time = 0;
			m_targetPosition = transform.localPosition;
			m_targetRotation = transform.localRotation;
			m_targetFov = m_camera.fieldOfView;
		}

		//// RVA: 0xAE2FA0 Offset: 0xAE2FA0 VA: 0xAE2FA0
		//public void Reinstate() { }

		//// RVA: 0xAE30A8 Offset: 0xAE30A8 VA: 0xAE30A8
		//public void InputOn() { }

		//// RVA: 0xAE30C8 Offset: 0xAE30C8 VA: 0xAE30C8
		//public void InputOff() { }

		//// RVA: 0xAE30D4 Offset: 0xAE30D4 VA: 0xAE30D4
		//public void StartUpdate() { }

		//// RVA: 0xAE30E0 Offset: 0xAE30E0 VA: 0xAE30E0
		public bool IsEntered()
		{
			return m_state > 0;
		}

		//// RVA: 0xAE30F4 Offset: 0xAE30F4 VA: 0xAE30F4
		public bool IsFinished()
		{
			return m_endFlag;
		}

		//// RVA: 0xAE30FC Offset: 0xAE30FC VA: 0xAE30FC
		//public int GetState() { }

		//// RVA: 0xAE3104 Offset: 0xAE3104 VA: 0xAE3104
		//public void InitCamera() { }

		//// RVA: 0xAE31B0 Offset: 0xAE31B0 VA: 0xAE31B0
		//public void InitCameraRot() { }

		//// RVA: 0xAE31BC Offset: 0xAE31BC VA: 0xAE31BC
		//public void ClearCameraRot() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6CD75C Offset: 0x6CD75C VA: 0x6CD75C
		//// RVA: 0xAE3128 Offset: 0xAE3128 VA: 0xAE3128
		//private IEnumerator InitDivaChange() { }

		//// RVA: 0xAE0278 Offset: 0xAE0278 VA: 0xAE0278
		private void Init(Vector3 pos, Quaternion rot)
		{
			m_originalRotation = rot;
			m_originalPosition = pos;
			m_targetCenter = m_targetTr.TransformPoint(Vector3.up * m_default_diva_center_y);
			m_baseCenter = m_targetTr.TransformPoint(Vector3.up * m_diva_center_y);
			m_targetRadius = (m_targetCenter - m_originalPosition).magnitude;
			m_rotAngle = Vector3.zero;
			m_eye = Vector3.forward * m_targetRadius;
			m_baseEye = m_eye;
			m_defaultDist = m_targetRadius;
			m_originalCenter = transform.TransformPoint(m_eye);
			m_center = m_targetCenter;
			m_originalRotateRev = m_originalRotation * Quaternion.AngleAxis(180, Vector3.up);
			m_rotAngle.x = Mathf.Atan2(m_diva_center_y - m_default_diva_center_y, m_eye.z) * -180 / 3.141593f;
			m_rot = Quaternion.Euler(m_rotAngle.x, m_rotAngle.y, 0);
			m_targetPosition = m_targetCenter + m_rot * m_eye;
			m_targetRotation = Quaternion.LookRotation(m_targetTr.TransformPoint(Vector3.up * m_default_diva_center_y) - m_targetPosition);
		}

		//// RVA: 0xAE2944 Offset: 0xAE2944 VA: 0xAE2944
		private bool IsTouchPoisitionInScreen(Vector2 screenPosition)
		{
			return screenPosition.x > SystemManager.rawAppScreenRect.xMin &&
				screenPosition.x <= SystemManager.rawAppScreenRect.xMax &&
				screenPosition.y > SystemManager.rawAppScreenRect.yMin &&
				screenPosition.y <= SystemManager.rawAppScreenRect.yMax;

		}

		//// RVA: 0xAE31CC Offset: 0xAE31CC VA: 0xAE31CC
		//public float GetTgtRotCamZ() { }
	}
}
