using UnityEngine;
using XeSys;

namespace XeApp.Game.Common
{
	public class StageExtensionObjectSetupDiva : MonoBehaviour
	{
		private BoneSpringController m_bsp_ctrl; // 0xC

		// RVA: 0x13A13B4 Offset: 0x13A13B4 VA: 0x13A13B4
		public void SetupDivaObject()
		{
			Transform root = gameObject.transform.Find("mesh_root");
			Renderer[] rs = root.GetComponentsInChildren<Renderer>();
			if(!GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.PKEMELMMEKM_GetDivaQuality())
			{
				TodoLogger.Log(0, "SetupDivaObject switch to low shader");
			}
			BoneSpringController controller = gameObject.GetComponentInChildren<BoneSpringController>();
			if(controller != null)
			{
				controller.Initialize(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.INPHNKJPJFN() ? BoneSpringController.PerformanceMode.High : BoneSpringController.PerformanceMode.Low);
			}
		}

		// RVA: 0x13A2E28 Offset: 0x13A2E28 VA: 0x13A2E28
		public void Pause()
		{
			m_bsp_ctrl.Lock(0);
		}

		//// RVA: 0x13A32B0 Offset: 0x13A32B0 VA: 0x13A32B0
		public void Resume()
		{
			m_bsp_ctrl.Unlock(0);
		}
	}
}
