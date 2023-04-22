using UnityEngine;
using XeApp.Game.UI;

namespace XeApp.Game.RhythmGame.UI
{
	public class LifeGauge : MonoBehaviour
	{
		[SerializeField]
		private GameObject m_gaugeMeshPrefab; // 0xC
		[SerializeField]
		private GameObject m_parentObject; // 0x10
		[SerializeField]
		private GameObject m_heartMarkObject; // 0x14
		[SerializeField]
		private GameObject m_normalHeartMark; // 0x18
		private MeshCircle m_meshCircle; // 0x1C
		private float m_sleshHold = 0.2f; // 0x20
		private readonly Color m_normalColor = new Color(1, 0.114f, 0.678f); // 0x24
		private readonly Color m_slashHodColor = new Color(0.444f, 0.251f, 0.529f); // 0x34
		private readonly Color m_effectColor = new Color(0.659f, 0.255f, 0.706f); // 0x44
		private readonly Vector3 heartBasePosition = new Vector3(98.81137f, 95.8823f, 0); // 0x54
		private readonly Vector3 heartRotateCenterOffset = new Vector3(0, 50, 0); // 0x60
		private readonly int IdleAnimeStateHash = Animator.StringToHash("Idle"); // 0x6C
		private readonly int LoopAnimeStateHash = Animator.StringToHash("LifeChangeEffect_Loop"); // 0x70

		// // RVA: 0x1562088 Offset: 0x1562088 VA: 0x1562088
		public void Initialize()
		{
			GameObject g = RhythmGameHUD.RhythmGameInstantiatePrefab(m_gaugeMeshPrefab);
			m_meshCircle = g.GetComponent<MeshCircle>();
			g.transform.SetParent(m_parentObject.transform, false);
		}

		// // RVA: 0x15621C0 Offset: 0x15621C0 VA: 0x15621C0
		public void SetValue(float value, bool isWarning)
		{
			m_meshCircle.Value = Mathf.Clamp01(value);
			m_normalHeartMark.SetActive(true);
		}
	}
}
