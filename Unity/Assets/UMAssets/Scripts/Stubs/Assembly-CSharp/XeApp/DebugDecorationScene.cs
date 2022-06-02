using XeApp.Core;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp
{
	public class DebugDecorationScene : MainSceneBase
	{
		[SerializeField]
		private DebugDecorationTexture m_decorationTexture;
		[SerializeField]
		private List<Vector2> m_attributeSpawnPostion;
	}
}
