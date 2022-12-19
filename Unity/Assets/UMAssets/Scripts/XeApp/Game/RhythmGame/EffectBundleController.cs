using UnityEngine;
using System;
using System.Collections.Generic;

namespace XeApp.Game.RhythmGame
{
	public class EffectBundleController : MonoBehaviour
	{
		[Serializable]
		public struct Animation
		{
			public Animator animator; // 0x0
			public int layerIndex; // 0x4
			public string stateName; // 0x8
			public AnimeState state; // 0xC
			public int hash; // 0x10
		}

		[Serializable]
		public struct Particle
		{
			public ParticleSystem particle;
			public ParticleState state;
		}

		[Serializable]
		public struct Param
		{
			public string groupName;
			public Animation[] Animations;
			public Particle[] particles;
		}

		public enum AnimeState
		{
			Play = 0,
			End = 1,
		}

		public enum ParticleState
		{
			Play = 0,
			Stop = 1,
		}

		[SerializeField]
		public Param[] m_params; // 0xC
		private Dictionary<int, int> m_searchDict = new Dictionary<int, int>(); // 0x10

		//// RVA: 0xF70BB4 Offset: 0xF70BB4 VA: 0xF70BB4
		public void Awake()
		{
			for(int i = 0; i < m_params.Length; i++)
			{
				for(int j = 0; j < m_params[i].Animations.Length; j++)
				{
					m_params[i].Animations[j].hash = Animator.StringToHash(m_params[i].Animations[j].stateName);
				}
				m_searchDict.Add(m_params[i].groupName.GetHashCode(), i);
			}
		}

		//// RVA: 0xF70E20 Offset: 0xF70E20 VA: 0xF70E20
		public void Play(string groupName)
		{
			Play(groupName.GetHashCode(), 0);
		}

		//// RVA: 0xF6075C Offset: 0xF6075C VA: 0xF6075C
		public void Play(int groupHash, float normalizeTime = 0)
		{
			int idx = 0;
			if(m_searchDict.TryGetValue(groupHash, out idx))
			{
				for (int j = 0; j < m_params[idx].Animations.Length; j++)
				{
					if (m_params[idx].Animations[j].animator != null)
					{
						m_params[idx].Animations[j].animator.Play(m_params[idx].Animations[j].hash, m_params[idx].Animations[j].layerIndex, m_params[idx].Animations[j].state == AnimeState.Play ? normalizeTime : 1.0f);
					}
				}
				for (int j = 0; j < m_params[idx].particles.Length; j++)
				{
					if (m_params[idx].particles[j].particle != null)
					{
						if (m_params[idx].particles[j].state == ParticleState.Play)
						{
							m_params[idx].particles[j].particle.Play(true);
						}
						else
						{
							m_params[idx].particles[j].particle.Stop(true);
						}
					}
				}
			}
		}

		//// RVA: 0xF70E68 Offset: 0xF70E68 VA: 0xF70E68
		//public float GetNormalizedTime(int hashCode, int animeIndex) { }

		//// RVA: 0xF71068 Offset: 0xF71068 VA: 0xF71068
		//public int GetStateHashCode(int hashCode, int animeIndex) { }

		//// RVA: 0xF7125C Offset: 0xF7125C VA: 0xF7125C
		//public void Stop(string groupName) { }

		//// RVA: 0xF712A0 Offset: 0xF712A0 VA: 0xF712A0
		//public void Stop(int groupHash) { }

		//// RVA: 0xF716C0 Offset: 0xF716C0 VA: 0xF716C0
		public bool IsPlaying(string groupName)
		{
			return IsPlaying(groupName.GetHashCode());
		}

		//// RVA: 0xF71704 Offset: 0xF71704 VA: 0xF71704
		public bool IsPlaying(int groupHash)
		{
			int idx;
			if (m_searchDict.TryGetValue(groupHash, out idx))
			{
				for (int i = 0; i < m_params[idx].Animations.Length; i++)
				{
					if (m_params[idx].Animations[i].animator != null)
					{
						if (m_params[idx].Animations[i].animator.GetCurrentAnimatorStateInfo(m_params[idx].Animations[i].layerIndex).shortNameHash == m_params[idx].Animations[i].hash
							 && m_params[idx].Animations[i].animator.GetCurrentAnimatorStateInfo(m_params[idx].Animations[i].layerIndex).normalizedTime < 1)
							return true;
					}
				}
				for (int i = 0; i < m_params[idx].particles.Length; i++)
				{
					if(m_params[idx].particles[i].particle != null)
					{
						if(m_params[idx].particles[i].particle.isPlaying)
							return true;
					}
				}
			}
			return false;
		}

		//// RVA: 0xF71CA8 Offset: 0xF71CA8 VA: 0xF71CA8
		//public bool IsSameState(string groupName) { }

		//// RVA: 0xF71CEC Offset: 0xF71CEC VA: 0xF71CEC
		public bool IsSameState(int groupHash)
		{
			int idx;
			if(m_searchDict.TryGetValue(groupHash, out idx))
			{
				for(int i = 0; i < m_params[idx].Animations.Length; i++)
				{
					if(m_params[idx].Animations[i].animator != null)
					{
						if (m_params[idx].Animations[i].animator.GetCurrentAnimatorStateInfo(m_params[idx].Animations[i].layerIndex).shortNameHash == m_params[idx].Animations[i].hash)
							return true;
					}
				}
			}
			return false;
		}

		//// RVA: 0xF720A0 Offset: 0xF720A0 VA: 0xF720A0
		//public int GetAnimatorLoopCount(int groupHash) { }
	}
}
