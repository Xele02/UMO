using UnityEngine;
using System.Collections.Generic;

public class UnitSetSaveTextScriptableObject : ScriptableObject
{
	//[TooltipAttribute] // RVA: 0x652370 Offset: 0x652370 VA: 0x652370
	[SerializeField]
	private List<Sprite> m_SaveTextSprites; // 0xC

	// RVA: 0xE0BB98 Offset: 0xE0BB98 VA: 0xE0BB98
	public Sprite GetSaveTextSprite(int modeType)
	{
		if (modeType > -1 && modeType < m_SaveTextSprites.Count)
			return m_SaveTextSprites[modeType];
		return null;
	}
}
