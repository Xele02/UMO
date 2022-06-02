using UnityEngine.UI;
using UnityEngine;

public class Bevel : BaseMeshEffect
{
	public override void ModifyMesh(VertexHelper vh)
	{
	}

	[SerializeField]
	private Color m_HighlightColor;
	[SerializeField]
	private Color m_ShadowColor;
	[SerializeField]
	private Vector2 m_BevelDirectionAndDepth;
	[SerializeField]
	private bool m_UseGraphicAlpha;
}
