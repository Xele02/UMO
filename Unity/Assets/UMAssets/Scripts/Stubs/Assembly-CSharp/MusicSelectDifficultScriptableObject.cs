using UnityEngine;
using System;

public class MusicSelectDifficultScriptableObject : ScriptableObject
{
	[Serializable]
	public class SpriteSet
	{
		public Sprite on;
		public Sprite off;
	}

	[SerializeField]
	private SpriteSet[] m_SpriteSets;
}
