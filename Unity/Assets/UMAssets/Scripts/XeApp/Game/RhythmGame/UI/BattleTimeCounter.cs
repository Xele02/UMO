using UnityEngine;
using XeApp.Game.UI;

namespace XeApp.Game.RhythmGame.UI
{
	public class BattleTimeCounter : MonoBehaviour
	{
		[SerializeField]
		private Animator m_timerBaseAnimator; // 0xC
		[SerializeField]
		private Animator m_timerNumAnimator; // 0x10
		[SerializeField]
		private NumericMesh m_numericMesh; // 0x14
		[SerializeField]
		private GameObject m_dangerTimeModel; // 0x18
		[SerializeField]
		private GameObject m_normalTimeModel; // 0x1C
		[SerializeField]
		private MeshFilter m_colonMesh; // 0x20
		private readonly int battle_timer_start_Hash = Animator.StringToHash("battle_timer_start"); // 0x24
		private readonly int TimeOverTrigger_Hash = Animator.StringToHash("TimeOverTrigger"); // 0x28
		private readonly int IsEnd_Hash = Animator.StringToHash("IsEnd"); // 0x2C
		private readonly int Battle_Num_nomal_Hash = Animator.StringToHash("Battle_Num_nomal"); // 0x30
		private readonly int Battle_Num_danger_Hash = Animator.StringToHash("Battle_Num_danger"); // 0x34
		private const int m_limitTimeMs = 5000;
		private int m_prevDispMilliSecond; // 0x38
		private int m_diffMilliSecond; // 0x3C
		private Vector2[] m_baseColonUvs; // 0x40
		private Vector2[] m_dengerColonUvs; // 0x44
		private bool m_isFinish; // 0x48
		private const int ColonTextureHeight = -50;

		//// RVA: 0x155A358 Offset: 0x155A358 VA: 0x155A358
		public void Show()
		{
			m_timerBaseAnimator.Play(battle_timer_start_Hash, 0, 0);
			m_timerBaseAnimator.SetBool(IsEnd_Hash, false);
			m_timerBaseAnimator.SetBool(TimeOverTrigger_Hash, false);
			if(m_dengerColonUvs == null)
			{
				Renderer r = m_colonMesh.GetComponent<Renderer>();
				m_baseColonUvs = new Vector2[m_colonMesh.mesh.uv.Length];
				System.Array.Copy(m_colonMesh.mesh.uv, m_baseColonUvs, m_baseColonUvs.Length);
				m_dengerColonUvs = new Vector2[m_baseColonUvs.Length];
				for(int i = 0; i < m_baseColonUvs.Length; i++)
				{
					m_dengerColonUvs[i] = m_baseColonUvs[i];
					m_dengerColonUvs[i].y = -50 / r.sharedMaterial.mainTexture.height - 50 / r.sharedMaterial.mainTexture.height + m_baseColonUvs[i].y;
				}
			}
			m_prevDispMilliSecond = -1;
			m_diffMilliSecond = 0;
			m_isFinish = false;
		}

		//// RVA: 0x155A6CC Offset: 0x155A6CC VA: 0x155A6CC
		public void UpdateTime(int ms)
		{
			if (m_isFinish)
				return;
			m_numericMesh.SetNumber(ms / 100, ms < 5000 ? 1 : 0);
			m_colonMesh.mesh.uv = ms < 5000 ? m_dengerColonUvs : m_baseColonUvs;
			m_dangerTimeModel.SetActive(ms < 5001);
			m_normalTimeModel.SetActive(5000 < ms);
			bool b = false;
			if (ms < 1)
			{
				Finish();
				m_timerBaseAnimator.SetBool(TimeOverTrigger_Hash, true);
			}
			else
			{
				b = true;
				if (4999 >= ms)
				{
					b = false;
					m_timerBaseAnimator.SetBool(TimeOverTrigger_Hash, true);
				}
			}
			if(ms >= 0 && m_diffMilliSecond >= 10)
			{
				m_timerNumAnimator.Play(b ? Battle_Num_nomal_Hash : Battle_Num_danger_Hash, 0, 0);
				m_diffMilliSecond = 0;
			}
			if(m_prevDispMilliSecond > -1)
			{
				m_diffMilliSecond += Mathf.Abs(m_prevDispMilliSecond - ms / 100);
			}
			m_prevDispMilliSecond = ms / 100;
		}

		//// RVA: 0x155A930 Offset: 0x155A930 VA: 0x155A930
		public void Finish()
		{
			m_timerBaseAnimator.SetBool(IsEnd_Hash, true);
			m_isFinish = true;
		}
	}
}
