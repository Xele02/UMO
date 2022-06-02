using UnityEngine;
using System;
using System.Collections.Generic;

namespace XeApp.Game.Adv
{
	public class AdvCharacterData : ScriptableObject
	{
		[Serializable]
		private struct Parts
		{
			public Sprite[] _sprites;
		}

		[SerializeField]
		private List<AdvCharacterData.Parts> _blinkPattern;
		[SerializeField]
		private List<AdvCharacterData.Parts> _mouthPattern;
		[SerializeField]
		private Texture _texture;
		[SerializeField]
		private Sprite _base;
		[SerializeField]
		private Material _material;
		[SerializeField]
		private Vector2 _eyePosition;
		[SerializeField]
		private Vector2 _mouthPosition;
		[SerializeField]
		private Vector2 _centerOffset;
	}
}
