using UnityEngine;

namespace TMPro
{
	public class TMP_SubMesh : MonoBehaviour
	{
		[SerializeField]
		private TMP_FontAsset m_fontAsset;
		[SerializeField]
		private TMP_SpriteAsset m_spriteAsset;
		[SerializeField]
		private Material m_material;
		[SerializeField]
		private Material m_sharedMaterial;
		[SerializeField]
		private bool m_isDefaultMaterial;
		[SerializeField]
		private float m_padding;
		[SerializeField]
		private Renderer m_renderer;
		[SerializeField]
		private MeshFilter m_meshFilter;
		[SerializeField]
		private TextMeshPro m_TextComponent;
	}
}
