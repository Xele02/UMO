using UnityEngine;
using System.Collections.Generic;

public class DivaColorSetScriptableObject : ScriptableObject
{
	[SerializeField]
	// [TooltipAttribute] // RVA: 0x652288 Offset: 0x652288 VA: 0x652288
	private List<Color> m_divaColors; // 0xC

	// RVA: 0x1242DC0 Offset: 0x1242DC0 VA: 0x1242DC0
	public Color GetDivaColor(int divaId)
	{
		int index = divaId + 1;
		if(index > -1)
		{
			if(index < m_divaColors.Count)
			{
				return m_divaColors[index];
			}
		}
		return Color.white;
	}
}
