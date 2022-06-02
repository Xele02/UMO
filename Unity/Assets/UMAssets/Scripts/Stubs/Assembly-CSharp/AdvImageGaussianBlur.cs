using UnityEngine;

public class AdvImageGaussianBlur : MonoBehaviour
{
	[SerializeField]
	private Material m_sourceMaterial;
	[SerializeField]
	public Texture2D m_texture_src;
	public float m_texel_offset;
	public float m_dispersion;
	public int m_sampling_num;
	public int m_loop_max;
	[SerializeField]
	public Vector2 m_uvOffset;
	public Texture2D m_texture_dst;
}
