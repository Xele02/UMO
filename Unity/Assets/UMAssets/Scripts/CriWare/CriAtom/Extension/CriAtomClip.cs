/****************************************************************************
 *
 * Copyright (c) 2019 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/

#if UNITY_2018_1_OR_NEWER && CRIWARE_TIMELINE_1_OR_NEWER

using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace CriWare {

namespace CriTimeline.Atom
{
	public class CriAtomClip : PlayableAsset, ITimelineClipAsset {
		public string cueSheet;
		public string cueName;
		public bool stopWithoutRelease = false;
		public bool muted = false;
		public bool ignoreBlend = false;
		public bool loopWithinClip = false;

		public CriAtomBehaviour templateBehaviour = new CriAtomBehaviour();

		[SerializeField, HideInInspector] private double clipDuration = 0.0;

		public ClipCaps clipCaps {
			get { return ClipCaps.Looping | ClipCaps.SpeedMultiplier | ClipCaps.Blending; }
		}

		public override Playable CreatePlayable(PlayableGraph graph, GameObject owner) {
			return ScriptPlayable<CriAtomBehaviour>.Create(graph, templateBehaviour);
		}

		public void SetClipDuration(double clipDuration) {
			this.clipDuration = clipDuration;
		}

		public override double duration {
			get {
				return clipDuration > 0.0 ? clipDuration : 2.0;
			}
		}
	}
}

} //namespace CriWare
#endif