/****************************************************************************
 *
 * Copyright (c) 2019 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/

#if UNITY_2018_1_OR_NEWER && CRIWARE_TIMELINE_1_OR_NEWER

using System;
using System.Threading;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace CriWare {

namespace CriTimeline.Atom
{
	public struct CriAtomClipPlayConfig {
		readonly public string cueSheetName;
		readonly public string cueName;
		readonly public long startTimeMs;
		readonly public double speedRate;
		readonly public bool loop;

		public CriAtomClipPlayConfig(
			string cueSheetName,
			string cueName,
			long startTimeMs,
			double speedRate,
			bool loop
			) {
			this.cueSheetName = cueSheetName;
			this.cueName = cueName;
			this.startTimeMs = startTimeMs;
			this.speedRate = speedRate;
			this.loop = loop;
	}
	}

	[Serializable]
	public class CriAtomBehaviour : PlayableBehaviour {
		[Range(0.0f, 1.0f)]
		public float volume = 1f;
		[Range(-1200.0f, 1200.0f)]
		public float pitch = 0f;
		[Range(0.0f, 1.0f)]
		public float AISACValue = 0f;

		static private int cPreviewStopTimeMs = 500;

		private CriAtomExAcb m_acb = null;
		private string m_lastCueSheetName = null;

		public CriAtomExPlayback playback { get; private set; }
		private bool _IsClipPlaying = false;
		public bool IsClipPlaying { get { return _IsClipPlaying; } private set { _IsClipPlaying = value; } }
		private double _CueLength = 0;
		public double CueLength { get { return _CueLength; } private set { _CueLength = value; } }

		public override void OnGraphStop(Playable playable) {
			base.OnGraphStop(playable);

			this.Stop(true);
		}

		public void Play(CriAtomSource atomSource, CriAtomClipPlayConfig config) {
			this.IsClipPlaying = true;

			if (atomSource == null) {
				return;
			}

			if (config.cueSheetName != m_lastCueSheetName) {
				m_acb = CriAtom.GetAcb(config.cueSheetName);
			}
			if (m_acb != null) {
				atomSource.player.SetCue(m_acb, config.cueName);
				this.CueLength = GetCueLengthSec(m_acb, config.cueName);
				m_lastCueSheetName = config.cueSheetName;

				if (this.playback.status != CriAtomExPlayback.Status.Removed) {
					this.playback.Stop();
				}

				if (this.CueLength > 0) {
					atomSource.player.SetStartTime(config.startTimeMs);
					atomSource.player.Loop(config.loop);
					this.playback = atomSource.player.Start();
				}
			}
		}

		public void PreviewPlay(Guid trackId, bool instantStop, CriAtomClipPlayConfig config) {
			this.IsClipPlaying = true;

			if (config.cueSheetName != m_lastCueSheetName) {
				m_acb = CriAtomTimelinePreviewer.Instance.GetAcb(config.cueSheetName);
			}
			if (m_acb != null) {
				CriAtomTimelinePreviewer.Instance.SetCue(trackId, m_acb, config.cueName);
				this.CueLength = GetCueLengthSec(m_acb, config.cueName);
				m_lastCueSheetName = config.cueSheetName;

				if (this.playback.status != CriAtomExPlayback.Status.Removed) {
					this.playback.Stop();
				}

				if (this.CueLength > 0) {
					CriAtomTimelinePreviewer.Instance.SetStartTime(trackId, config.startTimeMs);
					CriAtomTimelinePreviewer.Instance.SetLoop(trackId, config.loop);
					this.playback = CriAtomTimelinePreviewer.Instance.Play(trackId);
					if (instantStop) {
						WaitAndStop();
					}
				}
			}
		}

		private void WaitAndStop() {
			var thread = new Thread(() => {
				Thread.Sleep(cPreviewStopTimeMs);
				this.Stop(true);
			});
			thread.Start();
		}

		public void Stop(bool noReleaseTime = false) {
			this.playback.Stop(noReleaseTime);
			this.IsClipPlaying = false;
		}

		private double GetCueLengthSec(CriAtomExAcb acb, string cueName) {
			CriAtomEx.WaveformInfo waveInfo;
			if (acb != null && acb.GetWaveFormInfo(cueName, out waveInfo) == true) {
				return waveInfo.numSamples / (double)waveInfo.samplingRate;
			} else {
				return 0;
			}
		}
	}
}

} //namespace CriWare

#endif