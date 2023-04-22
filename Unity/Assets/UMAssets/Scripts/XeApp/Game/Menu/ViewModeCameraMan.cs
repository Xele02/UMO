using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	[RequireComponent(typeof(Camera))] // RVA: 0x64DF8C Offset: 0x64DF8C VA: 0x64DF8C
	public class ViewModeCameraMan : MonoBehaviour
	{ 
		public enum OperationType
		{
			VERTICAL_ROT_X = 0,
			VERTICAL_MOVE_Y = 1,
		}

		public enum TwoPointTapMode
		{
			NONE = -1,
			MOVE_Y = 0,
			ZOOM = 1,
			NUM = 2,
		}

		private readonly string[] camAnimState = new string[3] {
			"B_to_F", "F_to_G", "G_to_B"
		}; // 0xC
		private readonly string[] camAnimClipName = new string[3] {
			"val_cmn_me_f_to_g_cam", "val_cmn_me_g_to_b_cam", "val_cmn_me_b_to_f_cam"
		}; // 0x10
		private readonly float[] camAdjMoveYUp = new float[3] {
			0, 30, 10
		}; // 0x14
		private readonly float[] camAdjMoveYDown = new float[3] {
			0, -20, -20
		}; // 0x18
		private const int LAYER_VALKYRIE = 17;
		private const float CAMERA_FIELD_OF_VIEW = 45;
		private const float CAMERA_FAR_CLIP = 2000;
		private const float CAMERA_NEAR_CLIP = 0.1f;
		private const float ROT_SPEED_RATE_PER_PIXEL_Y = 0.375f;
		private const float ROT_SPEED_RATE_PER_PIXEL_X = -0.25f;
		private const float ROT_SPEED_TO_NEUTRAL = 270;
		private const float ROT_ANGLE_X_MIN = -50;
		private const float ROT_ANGLE_X_MAX = 30;
		private const float FIELD_OF_VIEW_MIN = 20;
		private const float FIELD_OF_VIEW_MAX = 75;
		private const float PINCH_OUT_POWER = 20;
		private const float TWO_POINT_START_DISTANCE = 0.5f;
		private const float TWO_POINT_VECTOR_DOT = 0.8f;
		private const float DONT_MOVE_ANGLE = 30;
		private Vector3[] m_camDefPosList = new Vector3[3]; // 0x1C
		private Quaternion[] m_camDefRotList = new Quaternion[3]; // 0x20
		private Vector3[] m_camDefTgtPosList = new Vector3[3]; // 0x24
		private float m_centerMoveY; // 0x28
		private TwoPointTapMode m_twoPointTapMode = TwoPointTapMode.NONE; // 0x2C
		private GameObject m_targetObj; // 0x30
		private Bounds m_targetBB; // 0x34
		private Vector3 m_targetCenter = Vector3.zero; // 0x4C
		private float m_targetRadius; // 0x58
		private Transform m_targetTr; // 0x5C
		private Vector3 m_center = Vector3.zero; // 0x60
		private Vector3 m_eye = new Vector3(0, 0, 220); // 0x6C
		private Quaternion m_rot = Quaternion.identity; // 0x78
		private Vector3 m_rotSpeed = Vector3.zero; // 0x88
		private Quaternion m_defaultPose = Quaternion.identity; // 0x94
		private Quaternion m_startPose = Quaternion.identity; // 0xA4
		private Vector3 m_defaultAngle = Vector3.zero; // 0xB4
		private Vector3 m_rotAngle = Vector3.zero; // 0xC0
		private float m_defaultDist = 200; // 0xCC
		private float m_targetDist; // 0xD0
		private float m_startFov; // 0xD4
		private Camera m_camera; // 0xD8
		private GameObject m_camObj; // 0xDC
		private GameObject m_camAnimObj; // 0xE0
		private Animator m_camAnim; // 0xE4
		private float m_tgtRotCamZ; // 0xE8
		private float m_rotCamZ; // 0xEC
		private float m_rotCamZLast; // 0xF0
		private float m_time; // 0xF4
		public float m_CameraDistance = 220; // 0xF8
		private bool m_operationFlag; // 0xFC
		private bool m_operationEndFlag; // 0xFD
		private ViewModeCameraMan.OperationType m_operationType; // 0x100
		private bool m_neutralDone; // 0x104
		private float m_nowTime; // 0x108
		public bool IsInfluence = true; // 0x10C
		private static ViewModeCameraMan ms_instance; // 0x0
		private float m_deviceRotateFlag = 1; // 0x110
		private ScreenOrientation m_ScreenOrientation = ScreenOrientation.LandscapeLeft; // 0x114
		private DeviceOrientation m_DeviceOrientation = DeviceOrientation.LandscapeLeft; // 0x118
		private SkinnedMeshRenderer[] m_valkyrieRend = new SkinnedMeshRenderer[3]; // 0x11C
		private SkinnedMeshRenderer m_currentRend; // 0x120
		private float m_currentCamAdjYUp; // 0x124
		private float m_currentCamAdjYDown; // 0x128
		private int m_formType; // 0x12C

		// public static ViewModeCameraMan Instance { get; } 0xADEA30

		// // RVA: 0xADC0DC Offset: 0xADC0DC VA: 0xADC0DC
		public void SetValkyrieRenderer(FKGMGBHBNOC.HPJOCKGKNCC_Form formType, SkinnedMeshRenderer rend)
		{
			m_valkyrieRend[(int)formType] = rend;
		}

		// RVA: 0xADC158 Offset: 0xADC158 VA: 0xADC158
		private void Start()
		{
			m_camera = GetComponent<Camera>();
			if(m_camera == null)
				return;
			m_camera.clearFlags = CameraClearFlags.Nothing;
			m_camera.cullingMask = 0x20000;
			m_camera.fieldOfView = 45;
			m_camera.farClipPlane = 2000;
			m_camera.nearClipPlane = 0.1f;
		}

		// RVA: 0xADC30C Offset: 0xADC30C VA: 0xADC30C
		private void Update()
		{
			if(!IsInfluence)
				return;
			if(!m_operationFlag)
				updateCameraNeutral();
			else
				updateCameraOperation();
			updateCameraCore();
		}

		// RVA: 0xADDE74 Offset: 0xADDE74 VA: 0xADDE74
		public void OnDestroy()
		{
			Destroy(m_camObj);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7342DC Offset: 0x7342DC VA: 0x7342DC
		// // RVA: 0xADDEFC Offset: 0xADDEFC VA: 0xADDEFC
		public IEnumerator Co_loadAssets()
		{
			string bundleName; // 0x14
			AssetBundleLoadAllAssetOperationBase operation; // 0x18

			//0xADF114
			bundleName = "vl/cmn.xab";
			operation = AssetBundleManager.LoadAllAssetAsync(bundleName.ToString());
			yield return operation;

			m_camObj = new GameObject("val_cmn_cam");
			m_camAnimObj = new GameObject("unity_cam");
			m_camAnimObj.transform.SetParent(m_camObj.transform, false);
			m_camAnim = m_camObj.AddComponent<Animator>();
			m_camAnim.runtimeAnimatorController = operation.GetAsset<RuntimeAnimatorController>("val_cmn_cam_animator");
			List<AnimationClip> anims = new List<AnimationClip>();
			for(int i = 0; i < 3; i++)
			{
				anims.Add(operation.GetAsset<AnimationClip>(camAnimClipName[i]));
			}
			GameObject go = new GameObject();
			for(int i = 0; i < 3; i++)
			{
				anims[i].SampleAnimation(m_camObj, 0);

				m_camDefPosList[i] = m_camAnimObj.transform.position;
				m_camDefRotList[i] = m_camAnimObj.transform.rotation;
				m_camDefTgtPosList[i] = Vector3.zero;
				Vector3 v2 = m_camAnimObj.transform.rotation * -Vector3.forward;
				v2 = v2.normalized;
				Vector3 v3 = Vector3.zero - m_camAnimObj.transform.position;
				float f = 1 - Vector3.Dot(v2, Vector3.up) * Vector3.Dot(v2, Vector3.up);
				if(f != 0)
				{
					m_camDefTgtPosList[i] = (m_camAnimObj.transform.position + (Vector3.Dot(v2, v3) - Vector3.Dot(v2, Vector3.up) * Vector3.Dot(Vector3.up, v3)) / f * v2);
				}
			}
			Destroy(go);
			yield return null;
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			yield return null;
		}

		// // RVA: 0xADD93C Offset: 0xADD93C VA: 0xADD93C
		private void updateCameraCore()
		{
			float dt = Time.deltaTime;
			m_center = Vector3.Lerp(m_center, m_targetCenter, dt * 10);
			m_eye.z = Mathf.Lerp(m_eye.z, m_targetDist, dt * 10);
			if(!m_operationFlag && !m_operationEndFlag)
			{
				if(m_camAnimObj != null)
				{
					transform.localPosition = m_camAnimObj.transform.position;
					transform.localRotation = m_camAnimObj.transform.rotation;
					transform.Rotate(0, 180, 0);
				}
			}
			else
			{
				transform.localPosition = m_center + m_rot * m_eye;
				transform.localRotation = Quaternion.LookRotation(new Vector3(m_center.x, m_center.y + m_centerMoveY, m_center.z) - transform.position) * Quaternion.AngleAxis(m_rotCamZ, Vector3.forward);
			}
		}

		// // RVA: 0xADDFA8 Offset: 0xADDFA8 VA: 0xADDFA8
		// private bool IsInCameraValkyrie(bool is_up) { }

		// // RVA: 0xADC350 Offset: 0xADC350 VA: 0xADC350
		private void updateCameraOperation()
		{
			TodoLogger.Log(0, "updateCameraOperation");
		}

		// // RVA: 0xADD3A0 Offset: 0xADD3A0 VA: 0xADD3A0
		private void updateCameraNeutral()
		{
			if(m_neutralDone)
				return;
			float dt = Mathf.Clamp(Time.deltaTime, 0, 0.06666667f);
			m_time += dt;
			float t = Mathf.Clamp01(m_time);
			if(t >= 1)
			{
				m_rot = m_defaultPose;
				m_rotAngle = m_defaultAngle;
			}
			int a = t >= 1 ? 1 : 0;
			m_rot = Quaternion.Lerp(m_rot, m_defaultPose, t);
			m_rotAngle = m_rot.eulerAngles;
			m_rotAngle.x = angleRound180(m_rotAngle.x);
			m_rotAngle.y = angleRound180(m_rotAngle.y);
			m_rotAngle.z = angleRound180(m_rotAngle.z);

			m_rotCamZ = Mathf.Lerp(m_rotCamZLast, 0, t);
			m_eye.z = Mathf.Lerp(m_eye.z, m_defaultDist, dt * 10);
			if(m_eye.z - m_defaultDist < 0.01f)
			{
				m_eye.z = m_defaultDist;
				a++;
			}
			m_camera.fieldOfView = Mathf.Lerp(m_camera.fieldOfView, 45, dt * 10);
			if(m_camera.fieldOfView - 45 < 0.01f)
			{
				m_camera.fieldOfView = 45;
				a++;
			}
			m_centerMoveY = Mathf.Lerp(m_centerMoveY, 0, dt * 10);
			if(Mathf.Abs(m_centerMoveY) < 0.01f)
			{
				m_centerMoveY = 0;
				if(t >= 1 && a >= 3)
				{
					m_operationEndFlag = false;
					m_neutralDone = true;
					m_tgtRotCamZ = 0;
					m_rotCamZ = 0;
					m_rotCamZLast = 0;
					m_rotSpeed = Vector3.zero;
					m_time = 0;
				}
			}

		}

		// // RVA: 0xADE1B4 Offset: 0xADE1B4 VA: 0xADE1B4
		private float angleRound180(float euler)
		{
			if(euler < -180)
				euler += 360;
			else if(euler >= 180)
				euler -= 360;
			return euler;
		}

		// // RVA: 0xADE21C Offset: 0xADE21C VA: 0xADE21C
		public void SetTargetObject(GameObject obj)
		{
			m_targetObj = obj;
		}

		// // RVA: 0xADE224 Offset: 0xADE224 VA: 0xADE224
		// public void SetTargetBB(Bounds bb, Transform targetTr, bool overwriteFlag) { }

		// // RVA: 0xADE4A0 Offset: 0xADE4A0 VA: 0xADE4A0
		public void SetValkyrieForm(int formType, bool changeAnimFlag)
		{
			m_formType = formType;
			Vector3 v = m_camDefRotList[formType].eulerAngles;
			v.x = angleRound180(v.x);
			v.y = angleRound180(v.y);
			SetDefaultAngle(formType, new Vector2(-v.x, v.y));
			m_defaultDist = (m_camDefTgtPosList[formType] - m_camDefPosList[formType]).magnitude; 
			m_targetDist = m_defaultDist;
			m_targetCenter = m_camDefTgtPosList[formType];
			m_neutralDone = false;
			m_currentRend = m_valkyrieRend[formType];
			m_currentCamAdjYUp = camAdjMoveYUp[formType];
			m_currentCamAdjYDown = camAdjMoveYDown[formType];
			m_camAnim.Play(camAnimState[formType], 0, changeAnimFlag ? 0 : 1);
		}

		// // RVA: 0xADE9BC Offset: 0xADE9BC VA: 0xADE9BC
		// public void SetDefaultPose(Quaternion pose) { }

		// // RVA: 0xADE898 Offset: 0xADE898 VA: 0xADE898
		public void SetDefaultAngle(int formType, Vector3 angle)
		{
			m_defaultAngle = angle;
			m_startPose = m_rot;
			m_defaultPose = m_camDefRotList[formType];
			m_camera = GetComponent<Camera>();
			m_startFov = m_camera.fieldOfView;
			if(!m_operationFlag)
			{
				m_rotAngle = angle;
				m_rot = m_defaultPose;
			}
		}

		// // RVA: 0xADE9DC Offset: 0xADE9DC VA: 0xADE9DC
		// public void SetUserOperation(bool ok) { }

		// // RVA: 0xADEA1C Offset: 0xADEA1C VA: 0xADEA1C
		public void SetOperationType(ViewModeCameraMan.OperationType ope)
		{
			m_operationType = ope;
		}

		// // RVA: 0xADEA24 Offset: 0xADEA24 VA: 0xADEA24
		// public void StartNeutralPose() { }
	}
}
