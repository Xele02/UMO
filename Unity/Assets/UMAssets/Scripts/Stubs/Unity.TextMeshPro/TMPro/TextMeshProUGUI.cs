using UnityEngine;

namespace TMPro
{
	public class TextMeshProUGUI : TMP_Text
	{
		[SerializeField]
		private bool m_hasFontAssetChanged;
		[SerializeField]
		protected TMP_SubMeshUI[] m_subTextObjects;
		[SerializeField]
		private Material m_baseMaterial;
		[SerializeField]
		private Vector4 m_maskOffset;
	}
}
