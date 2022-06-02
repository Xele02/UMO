using UnityEngine.UI;
using UnityEngine;

public class GradientColor : BaseMeshEffect
{
	public enum GradientMode
	{
		Local = 0,
		GlobalTextArea = 1,
		GlobalFullRect = 2,
	}

	public enum GradientDirection
	{
		Vertical = 0,
		Horizontal = 1,
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
	private GradientMode m_GradientMode;
	[SerializeField]
	private GradientDirection m_GradientDirection;
	[SerializeField]
	private ColorMode m_ColorMode;
	[SerializeField]
	public Color m_FirstColor;
	[SerializeField]
	public Color m_SecondColor;
	[SerializeField]
	private bool m_UseGraphicAlpha;
}
