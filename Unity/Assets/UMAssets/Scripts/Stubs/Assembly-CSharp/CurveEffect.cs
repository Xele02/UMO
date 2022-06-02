using UnityEngine.UI;
using UnityEngine;

public class CurveEffect : BaseMeshEffect
{
	public enum CurveMode
	{
		TextArea = 0,
		FullRect = 1,
	}

	public override void ModifyMesh(VertexHelper vh)
	{
	}

	[SerializeField]
	private CurveMode m_CurveMode;
	[SerializeField]
	private AnimationCurve m_Curve;
	[SerializeField]
	private float m_Strength;
}
