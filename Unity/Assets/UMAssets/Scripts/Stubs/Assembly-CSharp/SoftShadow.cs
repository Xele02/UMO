using UnityEngine.UI;
using UnityEngine;

public class SoftShadow : Shadow
{
	private void Awake()
	{
		TodoLogger.LogError(0, "Implement monobehaviour");
	}
	[SerializeField]
	private float m_BlurSpread;
	[SerializeField]
	private bool m_OnlyInitialCharactersDropShadow;
}
