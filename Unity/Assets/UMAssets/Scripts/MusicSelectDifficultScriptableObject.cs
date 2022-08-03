using UnityEngine;
using System;

public class MusicSelectDifficultScriptableObject : ScriptableObject
{
	[Serializable]
	public class SpriteSet
	{
		public Sprite on; // 0x8
		public Sprite off; // 0xC
	}

	[SerializeField]
	private SpriteSet[] m_SpriteSets; // 0xC

	// RVA: 0x17BE964 Offset: 0x17BE964 VA: 0x17BE964
	public SpriteSet GetSpriteSet(int iconType)
	{
		if(iconType > -1)
		{
			if(iconType < m_SpriteSets.Length)
			{
				return m_SpriteSets[iconType];
			}
		}
		return null;
	}
}
