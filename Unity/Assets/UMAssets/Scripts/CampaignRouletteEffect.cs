using UnityEngine;
using XeApp.Game;

public class CampaignRouletteEffect : MonoBehaviour
{
	[SerializeField]
	private GameObject m_effectGold; // 0xC
	[SerializeField]
	private GameObject m_effectNormal; // 0x10
	[SerializeField]
	private Camera m_systemCanvasCamera; // 0x14

	// RVA: 0x1766B28 Offset: 0x1766B28 VA: 0x1766B28
	private void Awake()
	{
		if(m_systemCanvasCamera == null)
			m_systemCanvasCamera = GameManager.Instance.GetSystemCanvasCamera();
	}

	// RVA: 0x1766C14 Offset: 0x1766C14 VA: 0x1766C14
	public void Play(int rank)
	{
		if(rank < 2)
			m_effectGold.SetActive(true);
		else
			m_effectNormal.SetActive(true);
	}

	// RVA: 0x1766C4C Offset: 0x1766C4C VA: 0x1766C4C
	public void Stop()
	{
		if(m_effectNormal.activeSelf)
			m_effectNormal.SetActive(false);
		if(m_effectGold.activeSelf)
			m_effectGold.SetActive(false);
	}
}
