using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class GachaDirectionCardFrame : GachaDirectionAnimSetBase
	{
		[SerializeField]
		private List<Texture> m_colorTextureAssets;
		[SerializeField]
		private List<Texture> m_maskTextureAssets;
		[SerializeField]
		private List<Renderer> m_renderers;
		[SerializeField]
		private GameObject m_lowerFrame;
		[SerializeField]
		private GameObject m_higherFrame;
	}
}
