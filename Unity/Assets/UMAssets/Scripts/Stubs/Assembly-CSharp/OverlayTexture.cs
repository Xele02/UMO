using UnityEngine.UI;
using UnityEngine;

public class OverlayTexture : BaseMeshEffect, IMaterialModifier
{
	private void Awake()
	{
		UnityEngine.Debug.LogError("Implement monobehaviour");
	}
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

	public Material GetModifiedMaterial(Material baseMaterial)
	{
		throw new System.NotImplementedException();
	}

	[SerializeField]
	private TextureMode m_TextureMode;
	[SerializeField]
	private ColorMode m_ColorMode;
	[SerializeField]
	public Texture2D m_OverlayTexture;
}
