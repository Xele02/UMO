using UnityEngine.UI;
using UnityEngine;

public class ToJShadow : BaseMeshEffect
{
	public override void ModifyMesh(VertexHelper vh)
	{
	}

	[SerializeField]
	private Color m_EffectColor;
	[SerializeField]
	private Vector2 m_EffectDistance;
	[SerializeField]
	private bool m_UseGraphicAlpha;
}
