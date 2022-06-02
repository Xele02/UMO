using UnityEngine.UI;
using UnityEngine;

public class OverlayTexture : BaseMeshEffect
{
	public enum TextureMode
	{
		Local = 0,
		GlobalTextArea = 1,
		GlobalFullRect = 2,
	}

	public enum ColorMode
	{
		Override = 0,
		Additive = 1,
		Multiply = 2,
	}

	public override void ModifyMesh(VertexHelper vh)
	{
	}

	[SerializeField]
	private TextureMode m_TextureMode;
	[SerializeField]
	private ColorMode m_ColorMode;
	[SerializeField]
	public Texture2D m_OverlayTexture;
}
