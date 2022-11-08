using XeApp.Core;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp
{
	public class DebugDecorationScene : MainSceneBase
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private DebugDecorationTexture m_decorationTexture;
		[SerializeField]
		private List<Vector2> m_attributeSpawnPostion;
	}
}
