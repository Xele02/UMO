using UnityEngine.UI;
using UnityEngine;

public class SkewEffect : BaseMeshEffect
{
	private void Awake()
	{
		TodoLogger.LogError(0, "Implement monobehaviour");
	}
	public enum SkewMode
	{
		TextArea = 0,
		FullRect = 1,
	}

	public override void ModifyMesh(VertexHelper vh)
	{
	}

	[SerializeField]
	private SkewMode m_SkewMode;
	[SerializeField]
	private Vector2 m_UpperLeftOffset;
	[SerializeField]
	private Vector2 m_UpperRightOffset;
	[SerializeField]
	private Vector2 m_LowerLeftOffset;
	[SerializeField]
	private Vector2 m_LowerRightOffset;
}
