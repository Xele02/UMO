using XeSys;
using UnityEngine.Audio;
using UnityEngine;

namespace XeApp.Core
{
	public class SoundController : SingletonBehaviour<SoundController>
	{
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
