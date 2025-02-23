using UnityEngine;
using XeSys;

namespace XeApp.Game.Menu
{
	public class DivaCameraRenderSwitch
	{
		protected static readonly Color s_backgroundColor = new Color(0, 0, 0, 0); // 0x0
		protected bool m_isReady; // 0x8
		protected RenderTexture m_renderTex; // 0xC
		protected GameObject m_bgPlane; // 0x10
		protected CameraClearFlags m_saveClearFlags; // 0x14
		protected Color m_saveBgColor; // 0x18
		protected Transform m_saveBgPlaneParent; // 0x28
		protected int m_saveCullingMask; // 0x2C

		// // RVA: 0x17D14DC Offset: 0x17D14DC VA: 0x17D14DC
		public void Initialize(RenderTexture renderTex, GameObject bgPlane)
		{
			m_renderTex = renderTex;
			m_bgPlane = bgPlane;
			m_isReady = renderTex != null;
		}

		// // RVA: 0x17D1578 Offset: 0x17D1578 VA: 0x17D1578
		// public void Finalize() { }

		// // RVA: 0x17D158C Offset: 0x17D158C VA: 0x17D158C Slot: 4
		public virtual void Apply(Camera camera)
		{
			m_saveClearFlags = camera.clearFlags;
			m_saveBgColor = camera.backgroundColor;
			m_saveBgPlaneParent = m_bgPlane.transform.parent;
			m_saveCullingMask = camera.cullingMask;
			m_renderTex.width = camera.pixelWidth;
			m_renderTex.height = camera.pixelHeight;
			camera.clearFlags = CameraClearFlags.SolidColor;
			camera.backgroundColor = s_backgroundColor;
			camera.targetTexture = m_renderTex;
			camera.cullingMask = 0x40002;
			m_bgPlane.transform.SetParent(camera.transform, false);
			m_bgPlane.transform.localPosition = new Vector3(0, 0, 100);
			float r = ((Mathf.Tan(camera.fieldOfView * 0.5f * 0.01745329f)) * 100) * 2;
			m_bgPlane.transform.localScale = new Vector3(r * camera.aspect, r , 1);
			m_bgPlane.SetActive(false);
		}

		// // RVA: 0x17D1A88 Offset: 0x17D1A88 VA: 0x17D1A88
		public void Revert(Camera camera)
		{
			camera.clearFlags = m_saveClearFlags;
			camera.backgroundColor = m_saveBgColor;
			camera.targetTexture = null;
			camera.cullingMask = m_saveCullingMask;
			m_bgPlane.transform.SetParent(m_saveBgPlaneParent, false);
			m_bgPlane.SetActive(false);
		}
	}

	public class WideScreenDivaCameraRenderSwitch : DivaCameraRenderSwitch
	{
		// // RVA: 0x1CE94D8 Offset: 0x1CE94D8 VA: 0x1CE94D8 Slot: 4
		public override void Apply(Camera camera)
		{
			m_saveClearFlags = camera.clearFlags;
			m_saveBgColor = camera.backgroundColor;
			m_saveBgPlaneParent = m_bgPlane.transform.parent;
			m_saveCullingMask = camera.cullingMask;
			m_renderTex.width = camera.pixelWidth;
			m_renderTex.height = camera.pixelHeight;
			camera.clearFlags = CameraClearFlags.SolidColor;
			camera.backgroundColor = s_backgroundColor;
			camera.targetTexture = m_renderTex;
			camera.cullingMask = 0x40002;
			m_bgPlane.transform.SetParent(camera.transform, false);
			m_bgPlane.transform.localPosition = new Vector3(0, 0, 100);
			float r = ((Mathf.Tan(camera.fieldOfView * 0.5f * 0.01745329f)) * 100) * 2;
			m_bgPlane.transform.localScale = new Vector3((Screen.width * 1.0f / camera.pixelWidth) * r * camera.aspect, r , 1);
			m_bgPlane.SetActive(true);
		}
	}

	public class LongScreenDivaCameraRenderSwitch : DivaCameraRenderSwitch
	{
		private const float ScaleFacter = 1.124142f;

		// // RVA: 0xEBA04C Offset: 0xEBA04C VA: 0xEBA04C Slot: 4
		public override void Apply(Camera camera)
		{
			m_saveClearFlags = camera.clearFlags;
			m_saveBgColor = camera.backgroundColor;
			m_saveBgPlaneParent = m_bgPlane.transform.parent;
			m_saveCullingMask = camera.cullingMask;
			if(SystemManager.HasSafeArea)
			{
				m_renderTex.width = camera.pixelWidth;
				m_renderTex.height = camera.pixelHeight;
			}
			else
			{
				m_renderTex.width = Screen.width;
				m_renderTex.height = Screen.height;
			}
			camera.clearFlags = CameraClearFlags.SolidColor;
			camera.backgroundColor = s_backgroundColor;
			camera.targetTexture = m_renderTex;
			camera.cullingMask = 0x40002;
			camera.rect = new Rect(0, 0, 1, 1);
			camera.fieldOfView = Mathf.CeilToInt(MenuScene.GetLongScreenScale() * 25);
			m_bgPlane.transform.SetParent(camera.transform, false);
			m_bgPlane.transform.localPosition = new Vector3(0, 0, 100);
			float r = ((Mathf.Tan(camera.fieldOfView * 0.5f * 0.01745329f)) * 100) * 2;
			m_bgPlane.transform.localScale = new Vector3(1.124142f * r * camera.aspect, r , 1);
			m_bgPlane.SetActive(true);
		}
	}

}
