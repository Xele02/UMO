using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.Serialization;

namespace XeApp.Game.Common
{
	public class EffectFactoryBase : MonoBehaviour, IComponentDeepCopy
	{
		public delegate GameObject GetCommonAssetFunc(string assetName);

		[Serializable]
		public class Setting
		{
			[FormerlySerializedAsAttribute("particlePrefab")] // RVA: 0x686AC8 Offset: 0x686AC8 VA: 0x686AC8
			public GameObject effectPrefab; // 0x8
			public string commonAssetName; // 0xC
			public string id; // 0x10
			public bool playOnAwake = true; // 0x14
			public Transform parent; // 0x18
			public Vector3 position; // 0x1C
			public Quaternion rotation; // 0x28
			public Vector3 scale; // 0x38

			// RVA: 0x1C0E45C Offset: 0x1C0E45C VA: 0x1C0E45C
			public Setting()
			{
				effectPrefab = null;
				commonAssetName = string.Empty;
				playOnAwake = false;
				id = string.Empty;
				parent = null;
				position = Vector3.zero;
				rotation = Quaternion.identity;
				scale = Vector3.one;
			}

			// RVA: 0x1C0C06C Offset: 0x1C0C06C VA: 0x1C0C06C
			public string GetEffectName()
			{
				if (!string.IsNullOrEmpty(id))
					return id;
				return effectPrefab.name;
			}
		}
		
		public class Instance
		{
			public string id { get; private set; } // 0x8
			public bool playOnAwake { get; private set; } // 0xC
			public GameObject gameObject { get; private set; } // 0x10
			public ParticleSystem particle { get; private set; } // 0x14
			public List<ParticleSystem> particleList { get; private set; } // 0x18
			public Animator animator { get; private set; } // 0x1C
			public List<Animator> animatorList { get; private set; } // 0x20
			public bool isEmit { get; private set; } // 0x24
			public bool isPause { get; private set; } // 0x25
			public double baseTime { get; private set; } // 0x28
			public bool hasParticle { get { return particle != null; } } //0x1C0E324
			//public bool hasParticleList { get; } 0x1C0E3B0
			public bool hasAnimator { get { return animator != null; } } //0x1C0E3C0
			//public bool hasAnimatorList { get; } 0x1C0E44C

			// RVA: 0x1C0C204 Offset: 0x1C0C204 VA: 0x1C0C204
			public Instance(GameObject go, Setting setting)
			{
				id = setting.GetEffectName();
				gameObject = go;
				particle = go.GetComponent<ParticleSystem>();
				playOnAwake = setting.playOnAwake;
				if(hasParticle)
				{
					particle.playOnAwake = setting.playOnAwake;
				}
				particleList = new List<ParticleSystem>();
				particleList.AddRange(go.GetComponentsInChildren<ParticleSystem>(true));
				animator = go.GetComponent<Animator>();
				if(hasAnimator)
				{
					animator.enabled = setting.playOnAwake;
				}
				animatorList = new List<Animator>();
				animatorList.AddRange(go.GetComponentsInChildren<Animator>(true));
				gameObject.SetActive(setting.playOnAwake);
			}

			//// RVA: 0x1C0BD28 Offset: 0x1C0BD28 VA: 0x1C0BD28
			public void ApplySkinnedMesh(SkinnedMeshRenderer skinnedMesh)
			{
				ParticleSystem[] ps = gameObject.GetComponentsInChildren<ParticleSystem>(true);
				for(int i = 0; i < ps.Length; i++)
				{
					ParticleSystem p = ps[i];
					if (p.shape.shapeType == ParticleSystemShapeType.SkinnedMeshRenderer)
					{
						if(p.shape.skinnedMeshRenderer == null)
						{
							var shape = p.shape;
							shape.skinnedMeshRenderer = skinnedMesh;
						}
					}
				}
			}

			//// RVA: 0x1C0D784 Offset: 0x1C0D784 VA: 0x1C0D784
			public void Setup()
			{
				gameObject.SetActive(playOnAwake);
				if(hasParticle)
				{
					particle.playOnAwake = playOnAwake;
				}
				if(hasAnimator)
				{
					animator.enabled = playOnAwake;
				}
				isEmit = playOnAwake;
				baseTime = playOnAwake ? 0 : -1;
			}

			//// RVA: 0x1C0D6C8 Offset: 0x1C0D6C8 VA: 0x1C0D6C8
			public void Update()
			{
				if (!gameObject.activeSelf)
					return;
				bool toStop = true;
				if(hasParticle)
				{
					toStop = !particle.IsAlive(true);
				}
				if (!toStop || hasAnimator)
					return;
				Disable();
			}

			//// RVA: 0x1C0E004 Offset: 0x1C0E004 VA: 0x1C0E004
			//public void ChangeAnimationTime(double time, double diffTime) { }

			//// RVA: 0x1C0D4F0 Offset: 0x1C0D4F0 VA: 0x1C0D4F0
			public void EmitStart(double syncTime)
			{
				bool wasActive = gameObject.activeSelf;
				gameObject.SetActive(true);
				if(!isPause)
				{
					if(hasParticle)
					{
						particle.Play();
					}
					if(hasAnimator)
					{
						if(wasActive)
						{
							animator.Rebind();
						}
						animator.enabled = true;
						animator.speed = 1;
					}
				}
				isEmit = true;
				baseTime = syncTime;
			}

			//// RVA: 0x1C0E08C Offset: 0x1C0E08C VA: 0x1C0E08C
			public void EmitBurst(int count, double syncTime)
			{
				bool prevActive = gameObject.activeSelf;
				gameObject.SetActive(true);
				if(!isPause)
				{
					if(hasParticle)
					{
						particle.Emit(count);
					}
					if(hasAnimator)
					{
						if(!prevActive)
							animator.Rebind();
						animator.enabled = true;
						animator.speed = 1;
					}
				}
				isEmit = true;
				baseTime = syncTime;
			}

			//// RVA: 0x1C0D888 Offset: 0x1C0D888 VA: 0x1C0D888
			public void EmitStop()
			{
				if(hasParticle)
				{
					particle.Stop();
				}
				if(hasAnimator)
				{
					animator.enabled = false;
					animator.speed = 0;
				}
				isEmit = false;
			}

			//// RVA: 0x1C0D94C Offset: 0x1C0D94C VA: 0x1C0D94C
			public void Disable()
			{
				gameObject.SetActive(false);
				baseTime = -1;
				isEmit = false;
			}

			//// RVA: 0x1C0E1F8 Offset: 0x1C0E1F8 VA: 0x1C0E1F8
			public void PlayAnim(string anim)
			{
				if(!hasAnimator)
					return;
				animator.Play(anim);
			}

			//// RVA: 0x1C0D9BC Offset: 0x1C0D9BC VA: 0x1C0D9BC
			public void Pause()
			{
				if(hasParticle)
				{
					particle.Pause();
				}
				if(particleList != null)
				{
					foreach(var p in particleList)
					{
						p.Pause();
					}
				}
				if(hasAnimator)
				{
					animator.speed = 0;
				}
				if(animatorList != null)
				{
					foreach(var a in animatorList)
					{
						a.speed = 0;
					}
				}
				isPause = true;
			}

			//// RVA: 0x1C0DC9C Offset: 0x1C0DC9C VA: 0x1C0DC9C
			public void Resume()
			{
				if(hasParticle)
				{
					particle.Play();
					if (!isEmit)
						particle.Stop();
				}
				if(particleList != null)
				{
					foreach(var p in particleList)
					{
						if(p.isPaused)
						{
							p.Play();
						}
					}
				}
				if (hasAnimator)
					animator.speed = 1;
				if(animatorList != null)
				{
					foreach(var a in animatorList)
					{
						a.speed = 1;
					}
				}
				isPause = false;
			}
		}

		[SerializeField]
		private List<Setting> m_settings = new List<Setting>(); // 0xC
		private List<Instance> m_instances = new List<Instance>(); // 0x10
		private SkinnedMeshRenderer m_skinnedMesh; // 0x14
		private double m_syncTime = -1; // 0x18

		//protected SkinnedMeshRenderer skinnedMesh { get; } 0x1C0AD20

		// RVA: 0x1C0AD28 Offset: 0x1C0AD28 VA: 0x1C0AD28
		private void Awake()
		{
			m_skinnedMesh = GetComponentInChildren<SkinnedMeshRenderer>(true);
		}

		// RVA: 0x1C0AD94 Offset: 0x1C0AD94 VA: 0x1C0AD94
		private void Update()
		{
			ExecuteAll((Instance instance) =>
			{
				//0x1C0D6A0
				instance.Update();
			});
		}

		//// RVA: 0x1C0AFD0 Offset: 0x1C0AFD0 VA: 0x1C0AFD0
		public void Redirection(EffectFactoryBase.GetCommonAssetFunc getCommonAsset)
		{
			for (int i = 0; i < m_settings.Count; i++)
			{
				if(!string.IsNullOrEmpty(m_settings[i].commonAssetName))
				{
					m_settings[i].effectPrefab = getCommonAsset(m_settings[i].commonAssetName);
				}
			}
		}

		//// RVA: 0x1C0B9D0 Offset: 0x1C0B9D0 VA: 0x1C0B9D0
		public void Instantiate()
		{
			for(int i = 0; i < m_settings.Count; i++)
			{
				Instance instance = Instantiate(m_settings[i]);
				instance.ApplySkinnedMesh(m_skinnedMesh);
				OnInstantiate(instance);
				m_instances.Add(instance);
			}
		}

		//// RVA: 0x1C0BEE0 Offset: 0x1C0BEE0 VA: 0x1C0BEE0
		public void Instantiate(string name)
		{
			for (int i = 0; i < m_settings.Count; i++)
			{
				if(m_settings[i].GetEffectName() == name)
				{
					Instance instance = Instantiate(m_settings[i]);
					instance.ApplySkinnedMesh(m_skinnedMesh);
					OnInstantiate(instance);
					m_instances.Add(instance);
				}
			}
		}

		//// RVA: 0x1C0C0B4 Offset: 0x1C0C0B4 VA: 0x1C0C0B4
		public void Release()
		{
			for(int i = 0; i < m_instances.Count; i++)
			{
				OnRelease(m_instances[i]);
				Destroy(m_instances[i].gameObject);
			}
			m_instances.Clear();
		}

		//// RVA: 0x1C0BB08 Offset: 0x1C0BB08 VA: 0x1C0BB08
		public Instance Instantiate(Setting setting)
		{
			GameObject go = Instantiate<GameObject>(setting.effectPrefab);
#if UNITY_EDITOR || UNITY_STANDALONE
			BundleShaderInfo.Instance.FixMaterialShader(go);
#endif
			go.transform.SetParent(setting.parent, false);
			go.transform.localPosition = setting.position;
			go.transform.localRotation = setting.rotation;
			go.transform.localScale = setting.scale;
			return new Instance(go, setting);
		}

		//// RVA: 0x1C0C4C0 Offset: 0x1C0C4C0 VA: 0x1C0C4C0 Slot: 6
		protected virtual void OnInstantiate(Instance instance)
		{
			return;
		}

		//// RVA: 0x1C0C4C4 Offset: 0x1C0C4C4 VA: 0x1C0C4C4 Slot: 7
		protected virtual void OnRelease(Instance instance)
		{
			return;
		}

		//// RVA: 0x1C0C4C8 Offset: 0x1C0C4C8 VA: 0x1C0C4C8 Slot: 8
		//protected virtual void OnPause(EffectFactoryBase.Instance instance) { }

		//// RVA: 0x1C0C4CC Offset: 0x1C0C4CC VA: 0x1C0C4CC Slot: 9
		//protected virtual void OnResume(EffectFactoryBase.Instance instance) { }

		//// RVA: 0x1C0C4D0 Offset: 0x1C0C4D0 VA: 0x1C0C4D0
		private void Execute(string name, Action<Instance> action)
		{
			for (int i = 0; i < m_instances.Count; i++)
			{
				if (m_instances[i].id == name)
				{
					action(m_instances[i]);
				}
			}
		}

		//// RVA: 0x1C0AED8 Offset: 0x1C0AED8 VA: 0x1C0AED8
		private void ExecuteAll(Action<Instance> action)
		{
			for(int i = 0; i < m_instances.Count; i++)
			{
				action(m_instances[i]);
			}
		}

		//// RVA: 0x1C0C61C Offset: 0x1C0C61C VA: 0x1C0C61C
		public void ChangeAnimationTime(double time)
		{
			ExecuteAll((EffectFactoryBase.Instance instance) =>
			{
				//0x1C0DFA8
				if (instance.baseTime >= 0 && time - instance.baseTime < 0)
					instance.Disable();
			});
			m_syncTime = time;
		}

		//// RVA: 0x1C0C75C Offset: 0x1C0C75C VA: 0x1C0C75C
		public void Setup()
		{
			ExecuteAll((EffectFactoryBase.Instance instance) =>
			{
				//0x1C0D75C
				instance.Setup();
			});
		}

		//// RVA: 0x1C0C8A0 Offset: 0x1C0C8A0 VA: 0x1C0C8A0
		public void EmitStart(string name)
		{
			Execute(name, (Instance instance) =>
			{
				//0x1C0D4B0
				instance.EmitStart(m_syncTime);
			});
		}

		//// RVA: 0x1C0C944 Offset: 0x1C0C944 VA: 0x1C0C944
		public void EmitBurst(string name, int count)
		{
			Execute(name, (Instance instance) =>
			{
				//0x1C0E030
				instance.EmitBurst(count, m_syncTime);
			});
		}

		//// RVA: 0x1C0CA40 Offset: 0x1C0CA40 VA: 0x1C0CA40
		public void EmitStop(string name)
		{
			Execute(name, (Instance instance) =>
			{
				//0x1C0D860
				instance.EmitStop();
			});
		}

		//// RVA: 0x1C0CB8C Offset: 0x1C0CB8C VA: 0x1C0CB8C
		public void Disable(string name)
		{
			Execute(name, (Instance instance) =>
			{
				//0x1C0D924
				instance.Disable();
			});
		}

		//// RVA: 0x1C0CCD8 Offset: 0x1C0CCD8 VA: 0x1C0CCD8
		public void PlayAnim(string id, string anim)
		{
			Execute(id, (Instance instance) =>
			{
				//0x1C0E1C8
				instance.PlayAnim(anim);
			});
		}

		//// RVA: 0x1C0CDBC Offset: 0x1C0CDBC VA: 0x1C0CDBC
		public void Pause()
		{
			ExecuteAll((Instance instance) =>
			{
				//0x1C0D994
				instance.Pause();
			});
		}

		//// RVA: 0x1C0CF00 Offset: 0x1C0CF00 VA: 0x1C0CF00
		public void Resume()
		{
			ExecuteAll((Instance instance) =>
			{
				//0x1C0DC74
				instance.Resume();
			});
		}

		//// RVA: -1 Offset: -1
		public void ForEach<T>(string id, Action<T> action)
		{
			Execute(id, (Instance instance) =>
			{
				// 0x30A5E8C
				T[] comps = instance.gameObject.GetComponentsInChildren<T>(true);
				for(int i = 0; i < comps.Length; i++)
				{
					action(comps[i]);
				}
			});
		}
		///* GenericInstMethod :
		//|
		//|-RVA: 0x1AB47B0 Offset: 0x1AB47B0 VA: 0x1AB47B0
		//|-EffectFactoryBase.ForEach<object>
		//*/

		//// RVA: 0x1C0D044 Offset: 0x1C0D044 VA: 0x1C0D044 Slot: 4
		void IComponentDeepCopy.PreCopy(ComponentDeepCopy impl)
		{
			foreach(Setting s in m_settings)
			{
				impl.RegisterRelative<Transform>(transform, s.parent);
			}
			OnPreCopy(impl);
		}

		//// RVA: 0x1C0D200 Offset: 0x1C0D200 VA: 0x1C0D200 Slot: 5
		void IComponentDeepCopy.PostCopy(ComponentDeepCopy impl)
		{
			int i = 0;
			foreach (Setting s in m_settings)
			{
				impl.FindRelative<Transform>(i, transform, ref s.parent);
				i++;
			}
			OnPostCopy(impl);
		}

		//// RVA: 0x1C0D3D8 Offset: 0x1C0D3D8 VA: 0x1C0D3D8 Slot: 10
		protected virtual void OnPreCopy(ComponentDeepCopy impl)
		{
			return;
		}

		//// RVA: 0x1C0D3DC Offset: 0x1C0D3DC VA: 0x1C0D3DC Slot: 11
		protected virtual void OnPostCopy(ComponentDeepCopy impl)
		{
			return;
		}
	}
}
