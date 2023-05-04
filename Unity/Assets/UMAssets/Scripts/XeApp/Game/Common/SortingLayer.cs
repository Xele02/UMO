using UnityEngine;

namespace XeApp.Game.Common
{
	internal class SortingLayerAttribute : PropertyAttribute { }

	[RequireComponent(typeof(Renderer))] // RVA: 0x64E9E8 Offset: 0x64E9E8 VA: 0x64E9E8
	[ExecuteInEditMode] // RVA: 0x64E9E8 Offset: 0x64E9E8 VA: 0x64E9E8
	public class SortingLayer : MonoBehaviour
	{
		[SerializeField]
		[SortingLayerAttribute]
		private string m_layerName = "Default"; // 0xC
		[SerializeField]
		private int m_orderInLayer; // 0x10
		private Renderer _renderer; // 0x14

		// RVA: 0x1395690 Offset: 0x1395690 VA: 0x1395690
		private void Awake()
		{
			SetSortingLayer(m_layerName, m_orderInLayer);
		}

		// RVA: 0x13957A0 Offset: 0x13957A0 VA: 0x13957A0
		private void OnValidate()
		{
			SetSortingLayer(m_layerName, m_orderInLayer);
		}

		// RVA: 0x139569C Offset: 0x139569C VA: 0x139569C
		private void SetSortingLayer(string a_name, int a_order)
		{
			Renderer[] rs = GetComponents<Renderer>();
			for(int i = 0; i < rs.Length; i++)
			{
				rs[i].sortingLayerName = a_name;
				rs[i].sortingOrder = a_order;
			}
		}
	}
}
