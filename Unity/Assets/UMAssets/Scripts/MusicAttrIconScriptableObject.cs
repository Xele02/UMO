using UnityEngine;
using System.Collections.Generic;

public class MusicAttrIconScriptableObject : ScriptableObject
{
	[SerializeField]
	//[TooltipAttribute] // RVA: 0x6522D0 Offset: 0x6522D0 VA: 0x6522D0
	private List<Sprite> m_musicAttrIconSprites; // 0xC

	// RVA: 0x17BE890 Offset: 0x17BE890 VA: 0x17BE890
	public Sprite GetMusicAttrIconSprite(int musicAttr)
	{
		if((musicAttr - 1) > -1 && (musicAttr - 1) < m_musicAttrIconSprites.Count)
		{
			return m_musicAttrIconSprites[musicAttr - 1];
		}
		return null;
	}
}
