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
			return mImage;
		}

		// // RVA: 0x274AF64 Offset: 0x274AF64 VA: 0x274AF64
		private void Awake()
		{
			mUpdate = this.UpdateIdle;
		}

		// // RVA: 0x274AFEC Offset: 0x274AFEC VA: 0x274AFEC
		private void Update()
		{
			mUpdate();
		}

		// // RVA: 0x274B018 Offset: 0x274B018 VA: 0x274B018
		private void UpdateIdle()
		{
			return;
		}

		// // RVA: 0x274B01C Offset: 0x274B01C VA: 0x274B01C
		private void UpdateFade()
		{
			float time = mCurrentTime + TimeWrapper.deltaTime;
			float percent = time / mTargetTime;
			mCurrentTime = time;
			if(percent >= 0.995f)
			{
				if(endColor.a <= 0.0f)
				{
					mImage.enabled = false;
				}
				if(onFadeEndAction != null)
					onFadeEndAction();
				percent = 1.0f;
				mUpdate = this.UpdateIdle;
			}
			currentColor = Color.Lerp(startColor, endColor, percent);
			mImage.color = currentColor;
		}

		// // RVA: 0x274B1D0 Offset: 0x274B1D0 VA: 0x274B1D0
		public void Fade(float time, float targetAlpha)
		{
			Fade(time, currentColor, new Color(currentColor.r, currentColor.g, currentColor.b, targetAlpha));
		}

		// // RVA: 0x274B210 Offset: 0x274B210 VA: 0x274B210
		public void Fade(float time, Color end)
		{
			Fade(time, currentColor, end);
		}

		// // RVA: 0x274B254 Offset: 0x274B254 VA: 0x274B254
		public void Fade(float time, Color start, Color end)
		{
			mImage = GetComponent<Image>();
			if(time <= 0)
			{
				currentColor = end;
				startColor = end;
				endColor = end;
				mCurrentTime = time;
				mTargetTime = time;
				mImage.color = end;
				mImage.enabled = end.a > 0;
				mUpdate = this.UpdateIdle;
			}
			else
			{
				currentColor = start;
				startColor = start;
				endColor = end;
				mTargetTime = time;
				mCurrentTime = 0.0f;
				mImage.color = start;
				mImage.enabled = true;
				mUpdate = this.UpdateFade;
			}
		}
	}
}
