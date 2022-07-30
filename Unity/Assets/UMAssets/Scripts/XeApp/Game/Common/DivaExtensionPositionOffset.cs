using UnityEngine;

namespace XeApp.Game.Common
{
	public class DivaExtensionPositionOffset : MonoBehaviour
	{
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x6868E0 Offset: 0x6868E0 VA: 0x6868E0
		public Vector3 m_Diva01_Freyja; // 0xC
		[SerializeField]
		public Vector3 m_Diva02_Mikumo; // 0x18
		[SerializeField]
		public Vector3 m_Diva03_Kaname; // 0x24
		[SerializeField]
		public Vector3 m_Diva04_Makina; // 0x30
		[SerializeField]
		public Vector3 m_Diva05_Reina; // 0x3C
		[SerializeField]
		public Vector3 m_Diva06_Ranka; // 0x48
		[SerializeField]
		public Vector3 m_Diva07_Sheryl; // 0x54
		[SerializeField]
		public Vector3 m_Diva08_Mylene; // 0x60
		[SerializeField]
		public Vector3 m_Diva09_Basara; // 0x6C
		[SerializeField]
		public Vector3 m_Diva10_Minmay; // 0x78
		private DivaObject m_diva_obj; // 0x84
		private int m_diva_index; // 0x88
		private Transform m_target_trans; // 0x8C

		// RVA: 0x1BED1CC Offset: 0x1BED1CC VA: 0x1BED1CC
		public void Initialize(DivaObject a_diva_obj)
		{
			m_diva_obj = a_diva_obj;
			m_diva_index = a_diva_obj.divaId - 1;
			m_target_trans = a_diva_obj.divaPrefab.transform;
		}

		// RVA: 0x1BEEF98 Offset: 0x1BEEF98 VA: 0x1BEEF98
		public void LateUpdate()
		{
			if(m_diva_obj == null)
				return;
			Vector3 vec = Vector3.zero;
			switch(m_diva_index)
			{
				case 0: vec = m_Diva01_Freyja; break;
				case 1: vec = m_Diva02_Mikumo; break;
				case 2: vec = m_Diva03_Kaname; break;
				case 3: vec = m_Diva04_Makina; break;
				case 4: vec = m_Diva05_Reina; break;
				case 5: vec = m_Diva06_Ranka; break;
				case 6: vec = m_Diva07_Sheryl; break;
				case 7: vec = m_Diva08_Mylene; break;
				case 8: vec = m_Diva09_Basara; break;
				case 9: vec = m_Diva10_Minmay; break;
				default: break;
			}
			m_target_trans.position = vec;
		}
	}
}
