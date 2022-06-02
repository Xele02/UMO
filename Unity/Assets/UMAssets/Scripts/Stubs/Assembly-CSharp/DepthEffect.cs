using UnityEngine.UI;
using UnityEngine;

public class DepthEffect : BaseMeshEffect
{
	public override void ModifyMesh(VertexHelper vh)
	{
	}

	[SerializeField]
	private Color m_EffectColor;
	[SerializeField]
	private Vector2 m_EffectDirectionAndDepth;
	[SerializeField]
	private Vector2 m_DepthPerspectiveStrength;
	[SerializeField]
	private bool m_OnlyInitialCharactersGenerateDepth;
	[SerializeField]
	private bool m_UseGraphicAlpha;
}
