using UnityEngine.UI;
using UnityEngine;

namespace XeSys.Gfx
{
	public class RawImageEx : RawImage, IAlphaTexture
	{
		[SerializeField]
		private Texture m_AlphaTexture; // 0x78
		[SerializeField]
		private Material m_MaterialMul; // 0x7C
		[SerializeField]
		private Material m_MaterialAdd; // 0x80
		[SerializeField]
		private string m_TextureName; // 0x84

		public Material MaterialMul { get { return m_MaterialMul; } set { m_MaterialMul = value; } } //0x1F0FF50 0x1EFF810
		public Material MaterialAdd { get { return m_MaterialAdd; } set { m_MaterialAdd = value; } } //0x1F0FF58 0x1EFF818
		// public Texture alphaTexture { get; set; } 0x1F0FF60 0x1EFF6B8
		// public string TextureName { get; set; } 0x1F0FFF4 0x1EFF820

		// // RVA: 0x1F0FF68 Offset: 0x1F0FF68 VA: 0x1F0FF68 Slot: 77
		// public bool IsUseAlphaTexture() { }

		// // RVA: 0x1F0FFFC Offset: 0x1F0FFFC VA: 0x1F0FFFC Slot: 78
		// public void SetTexture(Texture tex) { }

		// // RVA: 0x1F10004 Offset: 0x1F10004 VA: 0x1F10004
		// public void SetRaycastTarget(bool flag) { }
	}
}
