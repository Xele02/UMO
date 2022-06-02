using UnityEngine;
using System;

namespace XeApp.Game.RhythmGame
{
	public class EffectBundleController : MonoBehaviour
	{
		[Serializable]
		public struct Animation
		{
			public Animator animator;
			public int layerIndex;
			public string stateName;
			public EffectBundleController.AnimeState state;
		}

		[Serializable]
		public struct Particle
		{
			public ParticleSystem particle;
			public EffectBundleController.ParticleState state;
		}

		[Serializable]
		public struct Param
		{
			public string groupName;
			public EffectBundleController.Animation[] Animations;
			public EffectBundleController.Particle[] particles;
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
		public Param[] m_params;
	}
}
