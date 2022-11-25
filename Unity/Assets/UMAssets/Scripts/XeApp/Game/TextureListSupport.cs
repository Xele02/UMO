using XeSys.Gfx;
using System;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game
{
	public class TextureListSupport : LayoutUGUIScriptBase
	{
		[Serializable]
		public class Data
		{
			[SerializeField]
			private string m_texName; // 0x8
			[SerializeField]
			private Texture m_baseTex; // 0xC
			[SerializeField]
			private Texture m_maskTex; // 0x10
			[SerializeField]
			private Material m_mulMat; // 0x14
			[SerializeField]
			private Material m_addMat; // 0x18

			public string texName { get { return m_texName; } } //0x1571398
			//public Texture baseTex { get; } 0x15713A0
			//public Texture maskTex { get; } 0x15713A8
			//public Material mulMat { get; } 0x15713B0
			//public Material addMat { get; } 0x15713B8

			//// RVA: 0x15713C0 Offset: 0x15713C0 VA: 0x15713C0
			//public void .ctor(string texName, Texture baseTex, Texture maskTex, Material mulMat, Material addMat) { }

			//// RVA: 0x1571400 Offset: 0x1571400 VA: 0x1571400
			//public void .ctor(RawImageEx image) { }

			//// RVA: 0x1571218 Offset: 0x1571218 VA: 0x1571218
			public void Set(RawImageEx image)
			{
				image.TextureName = m_texName;
				image.texture = m_baseTex;
				image.alphaTexture = m_maskTex;
				image.MaterialMul = m_mulMat;
				image.MaterialAdd = m_addMat;
			}

			//// RVA: 0x1571024 Offset: 0x1571024 VA: 0x1571024
			internal bool IsVerbose(RawImageEx image)
			{
				if (image.texture == m_baseTex)
				{
					if(image.alphaTexture == m_maskTex)
					{
						if(image.MaterialMul == m_mulMat)
						{
							if(image.MaterialAdd == m_addMat)
							{
								return true;
							}
						}
					}
				}
				return false;
			}
		}
		
		[SerializeField]
		private List<TextureListSupport.Data> m_refs; // 0x14
		private TexUVListManager m_uvMan; // 0x18

		//// RVA: 0x1570E20 Offset: 0x1570E20 VA: 0x1570E20
		public void SetImage(RawImageEx image, string uvName)
		{
			TexUVList uvList;
			TexUVData data = m_uvMan.GetTextureData(uvName, out uvList);
			Data d = m_refs.Find((Data _) =>
			{
				//0x1571340
				return uvList.name == _.texName;
			});
			if(!d.IsVerbose(image))
			{
				d.Set(image);
			}
			image.uvRect = LayoutUGUIUtility.MakeUnityUVRect(data);
		}

		// RVA: 0x1571308 Offset: 0x1571308 VA: 0x1571308 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_uvMan = uvMan;
			Loaded();
			return true;
		}
	}
}
