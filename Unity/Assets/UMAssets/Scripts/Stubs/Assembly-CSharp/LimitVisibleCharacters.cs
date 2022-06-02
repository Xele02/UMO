using UnityEngine.UI;
using UnityEngine;

public class LimitVisibleCharacters : BaseMeshEffect
{
	public override void ModifyMesh(VertexHelper vh)
	{
	}

	[SerializeField]
	private int m_VisibleCharacterCount;
}
