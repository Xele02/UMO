using UnityEngine.UI;
using UnityEngine;

public class InnerOutline : BaseMeshEffect
{
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
	private ColorMode m_ColorMode;
	[SerializeField]
	public Color m_OutlineColor;
	[SerializeField]
	private float m_OutlineThickness;
}
