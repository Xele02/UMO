using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Playables;
using XeApp.Game.RhythmGame;
using XeSys;

namespace XeApp.Game.Common
{
	public class BoneSpringAnimObject : MonoBehaviour
	{
		private struct StPressetListItem
		{
			public GameObject m_preset_obj; // 0x0
			public BoneSpringSuppressor m_suppressor; // 0x4
		}

		public const int MAX_PRESET = 10;
		[SerializeField] // RVA: 0x68629C Offset: 0x68629C VA: 0x68629C
		private Animator m_animator; // 0xC
		[SerializeField] // RVA: 0x6862AC Offset: 0x6862AC VA: 0x6862AC
		private GameObject m_preset_default; // 0x10
		private AnimatorOverrideController m_animator_override; // 0x14
		private List<BoneSpringAnimObject.StPressetListItem> m_list_preset; // 0x18
		private BoneSpringController m_bsp_ctrl; // 0x1C

		public Animator animator { get { return m_animator; } } //0xE61C0C

		// RVA: 0xE61C14 Offset: 0xE61C14 VA: 0xE61C14
		public void Awake()
		{
			m_animator = GetComponentInChildren<Animator>();
		}

		// RVA: 0xE61C7C Offset: 0xE61C7C VA: 0xE61C7C
		public void Start()
		{
			return;
		}

		// RVA: 0xE61C80 Offset: 0xE61C80 VA: 0xE61C80
		public void Update()
		{
			return;
		}

		// RVA: 0xE61C84 Offset: 0xE61C84 VA: 0xE61C84
		public void LateUpdate()
		{
			if(m_bsp_ctrl != null)
			{
				m_bsp_ctrl.influence = 1.0f - m_preset_default.transform.position.x;
			}
			if(m_list_preset != null)
			{
				for(int i = 0; i < m_list_preset.Count; i++)
				{
					m_list_preset[i].m_suppressor.SetSuppressValue(m_list_preset[i].m_preset_obj.transform.position.x);
					m_list_preset[i].m_suppressor.UpdateSuppress();
				}
			}
		}

		// RVA: 0xE62014 Offset: 0xE62014 VA: 0xE62014
		private void OnDestroy()
		{
			UnityEngine.Debug.LogError("TODO BoneSpringAnimObject OnDestroy");
		}

		// RVA: 0xE62168 Offset: 0xE62168 VA: 0xE62168
		public void Initialize(RhythmGameResource a_resource, GameObject a_diva_prefab, int index, int divaId = 0)
		{
			if (!a_resource.musicBoneSpringResource[index].isUnused)
			{
				StringBuilder str = new StringBuilder();
				m_list_preset = new List<StPressetListItem>();
				DivaResource dres = a_resource.divaResource;
				if (index > 0)
					dres = a_resource.subDivaResource[index - 1];
				GameObject root = a_diva_prefab.transform.Find("joint_root").gameObject;
				m_bsp_ctrl = root.GetComponentInChildren<BoneSpringController>(true);
				foreach (var p in dres.boneSpringResource.suppress.presets)
				{
					str.SetFormat("preset_{0:D2}", (int)p.Key + 1);
					BoneSpringSuppressor suppressor = new BoneSpringSuppressor();
					suppressor.Load(root, p.Value, p.Key);
					GameObject presetObj = Instantiate(m_preset_default);
					presetObj.name = str.ToString();
					presetObj.transform.SetParent(transform);
					m_list_preset.Add(new StPressetListItem() { m_preset_obj = presetObj, m_suppressor = suppressor });
				}
				OverrideAnimClip(a_resource, index, divaId);
			}
		}

		//// RVA: 0xE62CD8 Offset: 0xE62CD8 VA: 0xE62CD8
		public void OverrideAnimClip(RhythmGameResource a_resource, int index, int divaId)
		{
			if(m_list_preset != null)
			{
				if(a_resource.musicBoneSpringResource[index].animatorController != null)
				{
					m_animator.runtimeAnimatorController = a_resource.musicBoneSpringResource[index].animatorController;
					m_animator_override = new AnimatorOverrideController();
					m_animator_override.name = "bs_anim_override_controller";
					m_animator_override.runtimeAnimatorController = m_animator.runtimeAnimatorController;
					m_animator.runtimeAnimatorController = m_animator_override;
					if(a_resource.musicBoneSpringResource[index].clip != null)
					{
						m_animator_override["game_cmn_bs_music"] = a_resource.musicBoneSpringResource[index].clip;
					}
					foreach(var dcr in a_resource.divaCutinResource)
					{
						if(dcr.divaId == divaId)
						{
							if(dcr.clipBoneSpring != null)
							{
								m_animator_override["game_cmn_bs_music"] = dcr.clipBoneSpring;
							}
							StringBuilder str = new StringBuilder();
							for (int i = 0; i < dcr.cutinBoneSpringClips.Length; i++)
							{
								if (dcr.cutinBoneSpringClips[i] != null)
								{
									str.SetFormat("game_cmn_bs_cut_{0:D2}", i + 1);
									m_animator_override[str.ToString()] = dcr.cutinBoneSpringClips[i];
								}
							}
							break;
						}
					}
				}
			}
		}

		//// RVA: 0xE63358 Offset: 0xE63358 VA: 0xE63358
		public void SetTime(double time)
		{
			m_animator.speed = 1;
			if (m_animator.playableGraph.IsValid())
			{
				m_animator.playableGraph.Evaluate((float)(time - PlayableExtensions.GetTime<Playable>(m_animator.playableGraph.GetRootPlayable(0))));
			}
		}
	}
}
