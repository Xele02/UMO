using UnityEngine;
using XeApp.Game.UI;

namespace XeApp.Game.RhythmGame.UI
{
	public class RankGauge : MonoBehaviour
	{
		[SerializeField]
		private GameObject m_gaugeMeshPrefab; // 0xC
		[SerializeField]
		private GameObject m_parentObject; // 0x10
		[SerializeField]
		private GameObject m_effectObject; // 0x14
		[SerializeField]
		private Animator m_rankAnime; // 0x18
		private Animator m_effectAnime; // 0x1C
		private MeshCircle m_meshCircle; // 0x20
		private GameObject m_rootInstance; // 0x24
		private int m_playStateName = -1; // 0x28
		private int[] stateNameTable; // 0x2C
		private int loopAnimeHash; // 0x30
		private int ChangeAnimeHash; // 0x34

		// // RVA: 0x156287C Offset: 0x156287C VA: 0x156287C
		public void Initialize()
		{
			m_rootInstance = RhythmGameHUD.RhythmGameInstantiatePrefab(m_gaugeMeshPrefab);
			m_meshCircle = m_rootInstance.GetComponentsInChildren<MeshCircle>(true)[0];
			m_effectAnime = m_rootInstance.GetComponent<Animator>();
			m_rootInstance.transform.SetParent(m_parentObject.transform, false);
			int[] vals = new int[5];
			vals[0] = Animator.StringToHash("runk_C");
			vals[1] = Animator.StringToHash("runk_B");
			vals[2] = Animator.StringToHash("runk_A");
			vals[3] = Animator.StringToHash("runk_S");
			vals[4] = Animator.StringToHash("runk_SS");
			stateNameTable = vals;
			loopAnimeHash = Animator.StringToHash("Loop");
			ChangeAnimeHash = Animator.StringToHash("Change");
		}

		// // RVA: 0x1562B9C Offset: 0x1562B9C VA: 0x1562B9C
		// public void SetRunk(ResultScoreRank.Type rank) { }

		// // RVA: 0x1562CF0 Offset: 0x1562CF0 VA: 0x1562CF0
		public void SetValue(float value)
		{
			m_meshCircle.Value = value;
		}
	}
}
