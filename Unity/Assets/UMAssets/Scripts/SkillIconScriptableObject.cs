using UnityEngine;
using System.Collections.Generic;

public class SkillIconScriptableObject : ScriptableObject
{
	[SerializeField]
	//[TooltipAttribute] // RVA: 0x652328 Offset: 0x652328 VA: 0x652328
	private List<Sprite> m_skillIconSprites; // 0xC

	// RVA: 0xDFFF7C Offset: 0xDFFF7C VA: 0xDFFF7C
	public Sprite GetSkillIconSprite(int iconId)
	{
		if(iconId > -1 && iconId < m_skillIconSprites.Count)
		{
			return m_skillIconSprites[iconId];
		}
		return null;
	}
}
