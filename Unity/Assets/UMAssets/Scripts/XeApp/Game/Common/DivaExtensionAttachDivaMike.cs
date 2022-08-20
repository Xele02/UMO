using UnityEngine;

namespace XeApp.Game.Common
{
	public class DivaExtensionAttachDivaMike : MonoBehaviour
	{
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x68681C Offset: 0x68681C VA: 0x68681C
		private Transform m_target_node; // 0xC
		private GameObject m_mike_obj; // 0x10

		// RVA: 0x1BEBAE0 Offset: 0x1BEBAE0 VA: 0x1BEBAE0
		public void Initialize(DivaObject a_divaObject)
		{
			if(m_target_node == null)
				return;
			a_divaObject.AttachMikeToObject(m_target_node);
		}
	}
}
