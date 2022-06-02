using UnityEngine.UI;
using UnityEngine;

public class CharacterSpacing : BaseMeshEffect
{
	public override void ModifyMesh(VertexHelper vh)
	{
	}

	[SerializeField]
	private float m_Offset;
}
