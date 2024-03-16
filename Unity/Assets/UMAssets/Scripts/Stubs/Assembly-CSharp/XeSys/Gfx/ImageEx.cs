using UnityEngine.UI;
using UnityEngine;

namespace XeSys.Gfx
{
	public class ImageEx : Image, IAlphaTexture
	{
		[SerializeField]
		private Texture m_AlphaTexture; // 0x8C
		[SerializeField]
		private Material m_MaterialMul; // 0x90
		[SerializeField]
		private Material m_MaterialAdd; // 0x94
		[SerializeField]
		private string m_TextureName; // 0x98

		public Material MaterialMul { get { return m_MaterialMul; } set { m_MaterialMul = value; } } //0x2049098 0x20490A0
		public Material MaterialAdd { get { return m_MaterialAdd; } set { m_MaterialAdd = value; } } //0x20490A8 0x20490B0
		public Texture alphaTexture { get { return m_AlphaTexture; } set { if(m_AlphaTexture != value) m_AlphaTexture = value; } } //0x20490B8 0x20490C0
		public string TextureName { get { return m_TextureName; } set { m_TextureName = value; } } //0x20491E4 0x20491EC

		// // RVA: 0x2049158 Offset: 0x2049158 VA: 0x2049158 Slot: 101
		// public bool IsUseAlphaTexture() { }

		// // RVA: 0x20491F4 Offset: 0x20491F4 VA: 0x20491F4 Slot: 102
		// public void SetTexture(Texture tex) { }
	}
}
