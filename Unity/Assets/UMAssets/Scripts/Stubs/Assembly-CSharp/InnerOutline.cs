using UnityEngine.UI;
using UnityEngine;

public class InnerOutline : BaseMeshEffect, IMaterialModifier
{
	private void Awake()
	{
		TodoLogger.LogError(0, "Implement monobehaviour");
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
		//throw new System.NotImplementedException();
		return null;
	}

	[SerializeField]
	private ColorMode m_ColorMode;
	[SerializeField]
	public Color m_OutlineColor;
	[SerializeField]
	private float m_OutlineThickness;
}
