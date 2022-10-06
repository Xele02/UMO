using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class ValkyrieObject : MonoBehaviour
	{
		private struct ShaderNameId
		{
			public int m_speed; // 0x0
		}

		private class VernierMaterialInfo
		{
			public Material m_material; // 0x8
			public int m_speed; // 0xC
		}

		protected static readonly int BaseLayer = 0; // 0x0
		protected static readonly int ShootLayer = 1; // 0x4
		private ValkyrieShaderController m_valkyrie_shader_ctrl = new ValkyrieShaderController(); // 0xC
		private ShaderNameId m_shader_nameid; // 0x10
		private List<VernierMaterialInfo> m_list_material_vernier = new List<VernierMaterialInfo>(); // 0x14
		private GameObject m_valkyrie; // 0x18
		private int m_activateCount; // 0x30

		protected AnimatorOverrideController overrideController { get; private set; } // 0x1C
		public GameObject instance { get { return m_valkyrie; } } //0xD27E9C
		public Animator animator { get; private set; } // 0x20
		public GameObject fighter { get; private set; } // 0x24
		public GameObject gerwalk { get; private set; } // 0x28
		public GameObject battroid { get; private set; } // 0x2C
		protected EffectFactoryCollector effectFactories { get; private set; } // 0x34
		protected ValkyrieSoundOrderer soundOrderer { get; private set; } // 0x38
		protected ValkyrieEventListener eventListener { get; private set; } // 0x3C
		protected virtual bool usingEffectFactory { get { return true; } } //0xD27F0C Slot: 4
		protected virtual bool usingQualitySetting { get { return true; } } //0xD27F14  Slot: 5

		// // RVA: 0xD27F1C Offset: 0xD27F1C VA: 0xD27F1C
		public void SetChangeExplosionEffect(bool a_enable)
		{
			if (eventListener == null)
				return;
			if(!a_enable)
			{
				eventListener.m_list_change_effect.Remove("EF_explosion");
				soundOrderer.m_list_change_sound.Remove("se_game_012");
			}
			else
			{
				eventListener.m_list_change_effect.Add("EF_explosion", "EF_explosion_alive");
				soundOrderer.m_list_change_sound.Add("se_game_012", "se_game_022");
			}
		}

		// // RVA: 0xD280E8 Offset: 0xD280E8 VA: 0xD280E8
		public void SetEnableAwakeEffect(bool a_enable)
		{
			if (eventListener == null)
				return;
			if(a_enable)
			{
				eventListener.onAwakeEffectStart = this.OnAwakeEffectEmitStart;
				eventListener.onAwakeEffectStop = this.OnAwakeEffectEmitStop;
				eventListener.onAwakeEffectDisable = this.OnAwakeEffectEmitDisable;
			}
			else
			{
				eventListener.onAwakeEffectStart = null;
				eventListener.onAwakeEffectStop = null;
				eventListener.onAwakeEffectDisable = null;
			}
		}

		// // RVA: 0xD28300 Offset: 0xD28300 VA: 0xD28300
		private void Awake()
		{
			return;
		}

		// // RVA: 0xD28304 Offset: 0xD28304 VA: 0xD28304
		public void Initialize(ValkyrieResource resource)
		{
			InstantiateValkyrie(resource);
			if (usingEffectFactory)
			{
				ValkyrieSetting settings = m_valkyrie.GetComponent<ValkyrieSetting>();
				settings.ResetVernierMeshesColor();
				effectFactories.RegisterSettingAll(settings);
				InstantiateEffect();
			}
			eventListener.Initialize();
			ShaderInitialize();
			OnInitialize(resource);
		}

		// // RVA: 0xD29140 Offset: 0xD29140 VA: 0xD29140 Slot: 6
		protected virtual void InstantiateEffect()
		{
			effectFactories.InstantiateAll();
		}

		// // RVA: 0xD2843C Offset: 0xD2843C VA: 0xD2843C
		private void InstantiateValkyrie(ValkyrieResource resource)
		{
			Destroy(m_valkyrie);
			m_valkyrie = Instantiate(resource.prefab);
			m_valkyrie.transform.SetParent(transform, false);
			ILDKBCLAFPB.MPHNGGECENI_Option saveOption = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options;
			string ShaderName = "";
			string ShaderMultiName = "";
			if(usingQualitySetting)
			{
				ShaderName = "MCRS/Valkyrie_Low";
				ShaderMultiName = "MCRS/ValkyrieMulti_Low";
				if(saveOption.DKECHCHOMEL_GetValkyrieQuality())
				{
					ShaderMultiName = "MCRS/ValkyrieMulti_High";
					ShaderName = "MCRS/Valkyrie_High";
				}
			}
			else
			{
				ShaderName = "MCRS/Valkyrie_High";
				ShaderMultiName = "MCRS/ValkyrieMulti_High";
			}
			Shader shader = Shader.Find(ShaderName);
			Shader shaderMulti = Shader.Find(ShaderMultiName);
			Renderer[] rs = m_valkyrie.GetComponentsInChildren<Renderer>();
			for(int i = 0; i < rs.Length; i++)
			{
				for(int j = 0; j < rs[i].materials.Length; j++)
				{
					if(rs[i].materials[j].shader.name == "MCRS/Valkyrie_High")
					{
						rs[i].materials[j].shader = shader;
					}
					else if (rs[i].materials[j].shader.name == "MCRS/ValkyrieMulti_High")
					{
						rs[i].materials[j].shader = shaderMulti;
					}
				}
			}
			m_valkyrie_shader_ctrl.Initialize(rs, resource);
			effectFactories = m_valkyrie.GetComponent<EffectFactoryCollector>();
			soundOrderer = m_valkyrie.GetComponent<ValkyrieSoundOrderer>();
			eventListener = m_valkyrie.GetComponent<ValkyrieEventListener>();
			animator = m_valkyrie.GetComponent<Animator>();
			animator.runtimeAnimatorController = resource.animatorController;
			overrideController = new AnimatorOverrideController();
			overrideController.name = "val_override_controller";
			overrideController.runtimeAnimatorController = animator.runtimeAnimatorController;
			animator.runtimeAnimatorController = overrideController;
			fighter = m_valkyrie.transform.Find("F").gameObject;
			gerwalk = m_valkyrie.transform.Find("G").gameObject;
			battroid = m_valkyrie.transform.Find("B").gameObject;
		}

		// // RVA: 0xD29C38 Offset: 0xD29C38 VA: 0xD29C38 Slot: 7
		protected virtual void OnInitialize(ValkyrieResource resource)
		{
			return;
		}

		// // RVA: 0xD29C3C Offset: 0xD29C3C VA: 0xD29C3C
		// public void Release() { }

		// // RVA: 0xD29D7C Offset: 0xD29D7C VA: 0xD29D7C Slot: 8
		// protected virtual void OnRelease() { }

		// // RVA: 0xD29CC4 Offset: 0xD29CC4 VA: 0xD29CC4
		// private void DestroyValkyrie() { }

		// // RVA: 0xD29D80 Offset: 0xD29D80 VA: 0xD29D80
		public void Activate(bool toActive)
		{
			if (toActive)
				m_activateCount++;
			else
			{
				m_activateCount--;
				if (m_activateCount < 0)
					m_activateCount = 0;
			}
			m_valkyrie.SetActive(m_activateCount > 0);
			animator.enabled = m_activateCount > 0;
			if(m_activateCount == 0)
			{
				soundOrderer.StopSoundAllPlayback();
			}
			effectFactories.SetupAll();
		}

		// // RVA: 0xD29E54 Offset: 0xD29E54 VA: 0xD29E54
		// public void Pause() { }

		// // RVA: 0xD2A158 Offset: 0xD2A158 VA: 0xD2A158
		// public void Resume() { }

		// [IteratorStateMachineAttribute] // RVA: 0x73C3A8 Offset: 0x73C3A8 VA: 0x73C3A8
		// // RVA: 0xD2A25C Offset: 0xD2A25C VA: 0xD2A25C
		protected IEnumerator Co_WaitAnimationEnd(int stateHash, Action onEnd)
		{
			//0xD2B6D8
			yield return new WaitForSeconds(0.1f);
			while (true)
			{
				AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
				if(state.shortNameHash != stateHash || (!state.loop && state.normalizedTime >= 1))
				{
					break;
				}
				yield return null;
			}
			if (onEnd != null)
				onEnd();
		}

		// // RVA: 0xD2A33C Offset: 0xD2A33C VA: 0xD2A33C
		public bool OnAwakeEffectEmitStart(string name)
		{
			m_valkyrie_shader_ctrl.SetAwakeMaterial(true);
			return true;
		}

		// // RVA: 0xD2A898 Offset: 0xD2A898 VA: 0xD2A898
		public bool OnAwakeEffectEmitStop(string name)
		{
			return true;
		}

		// // RVA: 0xD2A8A0 Offset: 0xD2A8A0 VA: 0xD2A8A0
		public bool OnAwakeEffectEmitDisable(string name)
		{
			m_valkyrie_shader_ctrl.SetAwakeMaterial(false);
			return true;
		}

		// // RVA: 0xD2A8D0 Offset: 0xD2A8D0 VA: 0xD2A8D0
		public void SetIBLColor(ValkyrieColorParam a_color_param)
		{
			if(m_valkyrie != null)
			{
				m_valkyrie_shader_ctrl.SetIBLColor(a_color_param);
			}
		}

		// // RVA: 0xD28DA4 Offset: 0xD28DA4 VA: 0xD28DA4
		private void ShaderInitialize()
		{
			m_list_material_vernier.Clear();
			m_shader_nameid.m_speed = Shader.PropertyToID("_speed");
			string[] str = new string[2];
			str[0] = "vernier_a";
			str[1] = "vernier_b";
			Renderer[] rs = m_valkyrie.GetComponentsInChildren<Renderer>();
			for(int i = 0; i < rs.Length; i++)
			{
				for(int j = 0; j < str.Length; j++)
				{
					if(rs[i].name == str[j])
					{
						VernierMaterialInfo info = new VernierMaterialInfo();
						info.m_material = rs[i].material;
						info.m_speed = info.m_material.GetInt(m_shader_nameid.m_speed);
						m_list_material_vernier.Add(info);
					}
				}
			}
		}

		// // RVA: 0xD29F58 Offset: 0xD29F58 VA: 0xD29F58
		// private void ShaderPause(bool a_pause) { }
	}
}
