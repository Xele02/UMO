using UnityEngine;

namespace TMPro
{
	public class TextMeshPro : TMP_Text
	{
		[SerializeField]
		private bool m_hasFontAssetChanged;
		[SerializeField]
		private Renderer m_renderer;
		[SerializeField]
		protected TMP_SubMesh[] m_subTextObjects;
		[SerializeField]
		private MaskingTypes m_maskType;
	}
}
