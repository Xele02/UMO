using UnityEngine;
using UnityEngine.UI;
using System;

namespace XeSys.uGUI
{
	[RequireComponent(typeof(Image))]
	public class UGUIFader : MonoBehaviour
	{
		public Color startColor = Color.black; // 0xC
		public Color endColor = Color.black; // 0x1C
		public Color currentColor = Color.black; // 0x2C
		public Action onFadeEndAction; // 0x3C
		private float mCurrentTime; // 0x40
		private float mTargetTime; // 0x44
		private Action mUpdate; // 0x48
		private Image mImage; // 0x4C

		// public float currentTime { get; } 0x274AEBC
		// public float targetTime { get; }  0x274AEC4
		public bool isFading { get {
			return mUpdate != this.UpdateIdle;
		} } //0x274AECC

		// // RVA: 0x274AEB4 Offset: 0x274AEB4 VA: 0x274AEB4
		public Image GetImage()
		{
			UnityEngine.Debug.LogError("TODO");
			return null;
		}

		// // RVA: 0x274AF64 Offset: 0x274AF64 VA: 0x274AF64
		private void Awake()
		{
			UnityEngine.Debug.LogWarning("TODO UGUIFader Awake");
		}

		// // RVA: 0x274AFEC Offset: 0x274AFEC VA: 0x274AFEC
		private void Update()
		{
			UnityEngine.Debug.LogWarning("TODO UGUIFader Update");
		}

		// // RVA: 0x274B018 Offset: 0x274B018 VA: 0x274B018
		private void UpdateIdle()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x274B01C Offset: 0x274B01C VA: 0x274B01C
		// private void UpdateFade() { }

		// // RVA: 0x274B1D0 Offset: 0x274B1D0 VA: 0x274B1D0
		public void Fade(float time, float targetAlpha)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x274B210 Offset: 0x274B210 VA: 0x274B210
		public void Fade(float time, Color end)
		{
			UnityEngine.Debug.LogWarning("TODO Fade");
		}

		// // RVA: 0x274B254 Offset: 0x274B254 VA: 0x274B254
		// public void Fade(float time, Color start, Color end) { }
	}
}
