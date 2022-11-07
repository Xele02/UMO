using System;
using UnityEngine;
using UnityEngine.Events;
using XeApp.Game.Common;
using XeApp.Game.UI;

namespace XeApp.Game.RhythmGame.UI
{
	public class EnemyStatus : MonoBehaviour
	{
		
		public enum LifeType
		{
			Single = 0,
			Double = 1,
		}

		private class LifeInfo
		{
			public float m_now; // 0x8
			public float m_max; // 0xC
			public float m_rate; // 0x10
			public float m_rate_prev; // 0x14
			public bool m_anim; // 0x18
			public MeshTile[] m_mesh; // 0x1C
			public Renderer m_renderer; // 0x20
			public Coroutine m_gaugeAnimeCroutine; // 0x24
			public bool m_isGaugeAnimation; // 0x28
			public float m_gaugeAnimationStartWait; // 0x2C
		}

		private class LifeCtrl
		{
			public static int INFO_MAX = 2; // 0x0
			public static int MESH_MAX = 2; // 0x4
			public LifeType m_type; // 0x8
			public int m_gauge; // 0xC
			public int m_index; // 0x10
			public LifeInfo[] m_info = new LifeInfo[INFO_MAX]; // 0x14

			//// RVA: 0x155B9FC Offset: 0x155B9FC VA: 0x155B9FC
			public void Initialize(LifeType a_type, MeshTile[] a_array_mesh)
			{
				m_type = a_type;
				m_gauge = 0;
				m_index = 0;
				for(int i = 0; i < INFO_MAX; i++)
				{
					m_info[i] = new LifeInfo();
					m_info[i].m_anim = false;
					m_info[i].m_now = 0;
					m_info[i].m_max = 0;
					m_info[i].m_rate = 1;
					m_info[i].m_rate_prev = 1;
					m_info[i].m_mesh = new MeshTile[MESH_MAX];
					m_info[i].m_mesh[0] = a_array_mesh[i * MESH_MAX];
					m_info[i].m_mesh[1] = a_array_mesh[i * MESH_MAX + 1];
					m_info[i].m_renderer = m_info[i].m_mesh[0].GetComponent<Renderer>();
					m_info[i].m_gaugeAnimeCroutine = null;
					m_info[i].m_isGaugeAnimation = false;
					m_info[i].m_gaugeAnimationStartWait = 0.0f;
				}
			}

			//// RVA: 0x155C590 Offset: 0x155C590 VA: 0x155C590
			//public void Update(int a_damage, int a_threshold1) { }
		}

		[SerializeField]
		private NumericMesh m_limitTimeMesh; // 0xC
		[SerializeField]
		private Animator m_rootAnimator; // 0x10
		[SerializeField]
		private Animator m_fadeInAnimator; // 0x14
		[SerializeField]
		private GameObject m_enemyGaugePrefab; // 0x18
		[SerializeField]
		private GameObject[] m_explosionEffectPrefab; // 0x1C
		[SerializeField]
		private ParticleSystem[] m_explosionLoopEffect; // 0x20
		[SerializeField]
		private Renderer[] m_mvHideObjects; // 0x24
		private Renderer m_enemyCutRenderer; // 0x28
		private MaterialPropertyBlock m_materialPropertyBlock; // 0x2C
		private Animator m_enemyGaugeAnimator; // 0x30
		private ParticleSystem m_explosionEffect; // 0x34
		private ParticleSystem m_currentExplosiionEff; // 0x38
		private MeshTile[] m_gaugeMesh; // 0x3C
		private static readonly int target_time_root_wait_Hash = Animator.StringToHash("Wait"); // 0x0
		private static readonly int target_time_root_Hash = Animator.StringToHash("target_time_root"); // 0x4
		private static readonly int chance_time_start_Hash = Animator.StringToHash("chance_time_start"); // 0x8
		private static readonly int ParametersIsEndHash = Animator.StringToHash("IsEnd"); // 0xC
		private static readonly int EnemyGaugeInHash = Animator.StringToHash("EnemyGaugeIn"); // 0x10
		private static readonly int EnemyGaugeOutHash = Animator.StringToHash("EnemyGaugeOut"); // 0x14
		private static readonly int red_ON_Hash = Animator.StringToHash("red_ON"); // 0x18
		private static readonly int red_DIVA_ON_Hash = Animator.StringToHash("red_DIVA_ON"); // 0x1C
		private int m_addColorShaderId; // 0x44
		private bool m_isMvMode; // 0x48
		private const float FlashColor = 0.35f;
		private LifeCtrl m_life_ctrl = new LifeCtrl(); // 0x4C
		private LifeType m_type; // 0x50

		public bool IsChaseMode { get; private set; } // 0x40

		//// RVA: 0x155AFD4 Offset: 0x155AFD4 VA: 0x155AFD4
		public void Initialize(bool isEnemyNoDeath = false, bool isMvMode = false)
		{
			GameObject go = RhythmGameHUD.RhythmGameInstantiatePrefab(m_enemyGaugePrefab);
			go.transform.SetParent(transform, false);
			m_enemyGaugeAnimator = go.GetComponent<Animator>();
			m_gaugeMesh = go.GetComponentsInChildren<MeshTile>();
			for(int i = 0; i < m_gaugeMesh.Length; i++)
			{
				m_gaugeMesh[i].Initialize();
				m_gaugeMesh[i].Value = 1.0f;
			}
			SetupLifeType(m_type);
			m_explosionEffect = RhythmGameHUD.RhythmGameInstantiatePrefab(m_explosionEffectPrefab[isEnemyNoDeath ? 1 : 0]).GetComponent<ParticleSystem>();
			m_explosionEffect.transform.SetParent(transform, false);
			for(int i = 0; i < m_explosionLoopEffect.Length; i++)
			{
				m_explosionLoopEffect[i].gameObject.SetActive(false);
			}
			for(int i = 0; i < m_explosionLoopEffect.Length; i++)
			{
				m_currentExplosiionEff = m_explosionLoopEffect[i];
				m_explosionLoopEffect[i].gameObject.SetActive(false);
			}
			m_materialPropertyBlock = new MaterialPropertyBlock();
			m_addColorShaderId = Shader.PropertyToID("_AddColor");
			if(isMvMode)
			{
				for(int i = 0; i < m_mvHideObjects.Length; i++)
				{
					m_mvHideObjects[i].enabled = false;
				}
				m_enemyGaugeAnimator.gameObject.SetActive(false);
			}
			m_isMvMode = isMvMode;
		}

		//// RVA: 0x155B578 Offset: 0x155B578 VA: 0x155B578
		public void SetupLifeType(LifeType a_type)
		{
			m_life_ctrl.Initialize(a_type, m_gaugeMesh);
			if(a_type == LifeType.Double)
			{
				m_gaugeMesh[0].enabled = true;
				m_gaugeMesh[1].enabled = true;
				m_gaugeMesh[2].enabled = true;
				m_gaugeMesh[3].enabled = true;
			}
			else
			{
				m_gaugeMesh[0].enabled = true;
				m_gaugeMesh[1].enabled = true;
				m_gaugeMesh[2].enabled = false;
				m_gaugeMesh[3].enabled = false;
			}
		}

		//// RVA: 0x155C184 Offset: 0x155C184 VA: 0x155C184
		public void SetEnemyRobotTexture(string cutMeshName, UiReplaceTexture enemyRobotTexture)
		{
			m_enemyCutRenderer = Array.Find(GetComponentsInChildren<Renderer>(true), (Renderer x) =>
			{
				//0x155DBDC
				return cutMeshName == x.name;
			});
			enemyRobotTexture.Set(m_enemyCutRenderer.materials[0]);
		}

		//// RVA: 0x155C314 Offset: 0x155C314 VA: 0x155C314
		//public void ResetParam() { }

		//// RVA: 0x155C4E4 Offset: 0x155C4E4 VA: 0x155C4E4
		//public void UpdateTime(int ms) { }

		//// RVA: 0x155C52C Offset: 0x155C52C VA: 0x155C52C
		//public void UpdateFrameColor(int hash) { }

		//// RVA: 0x155C530 Offset: 0x155C530 VA: 0x155C530
		//public void UpdateEnemyLifeGauge(int damage, int threshold1, bool isLowSpec) { }

		//// RVA: 0x155CF80 Offset: 0x155CF80 VA: 0x155CF80
		//private void UpdateEnemyLifeGauge(int a_gauge, bool isLowSpec) { }

		//[IteratorStateMachineAttribute] // RVA: 0x746FDC Offset: 0x746FDC VA: 0x746FDC
		//// RVA: 0x155D194 Offset: 0x155D194 VA: 0x155D194
		//private IEnumerator ColorAnimeCoroutine(Renderer renderer) { }

		//[IteratorStateMachineAttribute] // RVA: 0x747054 Offset: 0x747054 VA: 0x747054
		//// RVA: 0x155D23C Offset: 0x155D23C VA: 0x155D23C
		//private IEnumerator BackGaugeAnimation(int a_gauge, bool isLowSpec) { }

		//// RVA: 0x155D33C Offset: 0x155D33C VA: 0x155D33C
		public void TryChaseMode(int damage, int threshold, bool isLowSpec, UnityAction callback)
		{
			if(threshold <= damage)
			{
				if (IsChaseMode)
					return;
				if(!isLowSpec)
				{
					m_explosionEffect.Play();
					m_currentExplosiionEff.Play();
				}
				SoundManager.Instance.sePlayerGame.Play(18);
				PlayChaseEffect();
				IsChaseMode = true;
				if (callback != null)
					callback();
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7470CC Offset: 0x7470CC VA: 0x7470CC
		//// RVA: 0x155D534 Offset: 0x155D534 VA: 0x155D534
		//private IEnumerator WaitParticleCoroutine(ParticleSystem particle, Action end) { }

		//// RVA: 0x155D420 Offset: 0x155D420 VA: 0x155D420
		private void PlayChaseEffect()
		{
			m_fadeInAnimator.Play(chance_time_start_Hash, 0, 0);
			SoundManager.Instance.sePlayerGame.Play(17);
		}

		//// RVA: 0x155D5E0 Offset: 0x155D5E0 VA: 0x155D5E0
		public void ShowEnemyIcon()
		{
			if(!IsChaseMode)
			{
				m_fadeInAnimator.Play(target_time_root_Hash, 0, 0);
			}
			m_enemyGaugeAnimator.Play(EnemyGaugeInHash, 0, 0);
		}

		//// RVA: 0x155D728 Offset: 0x155D728 VA: 0x155D728
		//public void ChangeFaild(int hash) { }

		//// RVA: 0x155D830 Offset: 0x155D830 VA: 0x155D830
		public void Show()
		{
			m_rootAnimator.Play(target_time_root_wait_Hash, 0, 0);
			m_fadeInAnimator.SetBool(ParametersIsEndHash, false);
			IsChaseMode = false;
		}
	}
}
