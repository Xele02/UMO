using UnityEngine;

public class CampaignRouletteEffect : MonoBehaviour
{
	[SerializeField]
	private GameObject m_effectGold;
	[SerializeField]
	private GameObject m_effectNormal;
	[SerializeField]
	private Camera m_systemCanvasCamera;
	private void Awake()
	{
		TodoLogger.LogError(0, "Implement Monobehaviour");
	}
}
