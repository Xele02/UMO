using UnityEngine.UI;
using UnityEngine;

public class LimitVisibleCharacters : BaseMeshEffect
{
	private void Awake()
	{
		TodoLogger.LogError(0, "Implement monobehaviour");
	}
	public override void ModifyMesh(VertexHelper vh)
	{
	}

	[SerializeField]
	private int m_VisibleCharacterCount;
}
