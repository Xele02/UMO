using XeSys;
using UnityEngine.Audio;
using UnityEngine;

namespace XeApp.Core
{
	public class SoundController : SingletonBehaviour<SoundController>
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		public int maxSeChannels;
		public int maxLoopSeChannels;
		[SerializeField]
		protected AudioMixer mixer;
		[SerializeField]
		private AudioClip[] bgmClips;
		[SerializeField]
		private AudioClip[] seClips;
	}
}
