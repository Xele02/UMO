using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

namespace XeApp.Game.Adv
{
	public class AdvCharacterData : ScriptableObject
	{
		[Serializable]
		private struct Parts
		{
			public Sprite[] _sprites; // 0x0
		}

		[SerializeField]
		private List<Parts> _blinkPattern = new List<Parts>(); // 0xC
		[SerializeField]
		private List<Parts> _mouthPattern = new List<Parts>(); // 0x10
		[SerializeField]
		private Texture _texture; // 0x14
		[SerializeField]
		private Sprite _base; // 0x18
		[SerializeField]
		private Material _material; // 0x1C
		[SerializeField]
		private Vector2 _eyePosition; // 0x20
		[SerializeField]
		private Vector2 _mouthPosition; // 0x28
		[SerializeField]
		private Vector2 _centerOffset = new Vector2(0.5f, 0.58f); // 0x30
		private Texture2D _blurTexture; // 0x38

		// // RVA: 0xBC07D4 Offset: 0xBC07D4 VA: 0xBC07D4
		public void Set(Image body, Image eye, Image mouth, int faceId)
		{
			body.sprite = _base;
			eye.sprite = _blinkPattern[faceId - 1]._sprites[0];
			mouth.sprite = _mouthPattern[faceId - 1]._sprites[0];
			mouth.material = _material;
			eye.material = _material;
			body.material = _material;
			body.SetNativeSize();
			eye.SetNativeSize();
			mouth.SetNativeSize();
			eye.rectTransform.anchoredPosition = _eyePosition;
			mouth.rectTransform.anchoredPosition = _mouthPosition;
			body.rectTransform.pivot = _centerOffset;
		}

		// // RVA: 0xBC2AE0 Offset: 0xBC2AE0 VA: 0xBC2AE0
		public int GetEyePatternLength(int faceId)
		{
			return _blinkPattern[faceId - 1]._sprites.Length;
		}

		// // RVA: 0xBC35DC Offset: 0xBC35DC VA: 0xBC35DC
		// public int GetMouthPatternLenght(int faceId) { }

		// // RVA: 0xBC14A4 Offset: 0xBC14A4 VA: 0xBC14A4
		public void SetEyePattern(Image eye, int faceId, int pattern)
		{
			eye.sprite = _blinkPattern[faceId - 1]._sprites[pattern];
			eye.SetNativeSize();
		}

		// // RVA: 0xBC15FC Offset: 0xBC15FC VA: 0xBC15FC
		// public void SetMouthPattern(Image mouth, int faceId, int pattern) { }

		// // RVA: 0xBC46E4 Offset: 0xBC46E4 VA: 0xBC46E4
		public void SetBlurTexture(Texture2D texture)
		{
			_blurTexture = texture;
		}

		// // RVA: 0xBC0AEC Offset: 0xBC0AEC VA: 0xBC0AEC
		public Texture2D GetBlurTexture()
		{
			return _blurTexture;
		}

		// // RVA: 0xBC46EC Offset: 0xBC46EC VA: 0xBC46EC
		// public void Release() { }

		public Material GetMaterial() { return _material; } // UMO
	}
}
