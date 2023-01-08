using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeSys.Gfx;
using XeSys;

namespace XeApp.Game.Common
{
	public class LayoutCommonTextureManager
	{
		public class CommonTexture
		{
			public Material Material { get; set; } // 0x8
			public Texture2D BaseTexture { get; set; } // 0xC
			public Texture2D MaskTexture { get; set; } // 0x10

			// RVA: 0x1105018 Offset: 0x1105018 VA: 0x1105018
			public void Create(AssetBundleLoadAllAssetOperationBase a_operation, string a_path)
			{
				Material = new Material(Shader.Find("XeSys/Unlit/SplitTexture"));
				string path = Path.GetFileNameWithoutExtension(a_path);
				BaseTexture = a_operation.GetAsset<Texture2D>(path + "_base");
				MaskTexture = a_operation.GetAsset<Texture2D>(path + "_mask");
			}

			// // RVA: 0x110528C Offset: 0x110528C VA: 0x110528C
			// public void Release() { }

			// // RVA: 0x110541C Offset: 0x110541C VA: 0x110541C
			public void Set(RawImageEx image)
			{
				if(Material == null)
					return;
				if(image == null)
					return;
				image.material = Material;
				image.MaterialMul = Material;
				image.texture = BaseTexture;
				image.material.SetTexture("_MainTex", BaseTexture);
				image.material.SetTexture("_MaskTex", MaskTexture);
			}

			// // RVA: 0x1105634 Offset: 0x1105634 VA: 0x1105634
			// public void Set(RawImage image) { }
		}

		private const string BundleName = "ly/ct.xab";
		private string[] TexUvListAssetName = new string[2] { "cmn_tex_pack_uvlist", "cmn_tex_02_pack_uvlist" }; // 0x8
		private string[] TexListAssetName = new string[2] { "cmn_tex_pack", "cmn_tex_02_pack" }; // 0xC
		private Dictionary<string, TexUVList> m_unionTextureUVDict = new Dictionary<string, TexUVList>(); // 0x10
		private Dictionary<string, LayoutCommonTextureManager.CommonTexture> m_unionTextureDict = new Dictionary<string, LayoutCommonTextureManager.CommonTexture>(); // 0x14
		private StringBuilder m_stringBuilder = new StringBuilder(); // 0x18
		private List<Rect> m_gameAttributeRects = new List<Rect>(GameAttribute.ArrayNum); // 0x1C
		private List<Rect> m_difficultyRects = new List<Rect>(5); // 0x20
		private List<Rect> m_skillRankRects = new List<Rect>(4); // 0x24
		private List<Rect> m_liveSkillTypeRects = new List<Rect>(2); // 0x28

		public bool IsReady { get; private set; } // 0x2C

		// [IteratorStateMachineAttribute] // RVA: 0x73969C Offset: 0x73969C VA: 0x73969C
		// // RVA: 0x1103F64 Offset: 0x1103F64 VA: 0x1103F64
		public IEnumerator LoadUnionTexture()
		{
			//0x1104C84
			if(IsReady)
				yield break;

			AssetBundleLoadAllAssetOperationBase operation = AssetBundleManager.LoadAllAssetAsync(BundleName);
			yield return operation;

			for(int i = 0; i < TexUvListAssetName.Length; i++)
			{
				m_unionTextureUVDict.Add(TexUvListAssetName[i], operation.GetAsset<TexUVList>(TexUvListAssetName[i]));
			}
			for(int i = 0; i < TexListAssetName.Length; i++)
			{
				CommonTexture tex = new CommonTexture();
				tex.Create(operation, TexListAssetName[i]);
				m_unionTextureDict.Add(TexListAssetName[i], tex);
			}
			MakeUvRects(m_gameAttributeRects, "cmn_zok_{0:D2}", 1, GameAttribute.ArrayNum);
			MakeUvRects(m_difficultyRects, "cmn_music_diff_{0:D2}", 1, 5);
			MakeUvRects(m_skillRankRects, "cmn_skill_rank_icon_{0:D2}", 1, 5);
			MakeUvRects(m_liveSkillTypeRects, "cmn_icon_skill_{0:D2}", 1, 2);
			IsReady = true;
		}

		// // RVA: 0x1104010 Offset: 0x1104010 VA: 0x1104010
		// public void Release() { }

		// // RVA: 0x1104168 Offset: 0x1104168 VA: 0x1104168
		public TexUVList GetTexUvList(string path)
		{
			TexUVList res = null;
			m_unionTextureUVDict.TryGetValue(Path.GetFileNameWithoutExtension(path), out res);
			return res;
		}

		// // RVA: 0x110423C Offset: 0x110423C VA: 0x110423C
		public LayoutCommonTextureManager.CommonTexture GetTexture(string path)
		{
			CommonTexture t = null;
			m_unionTextureDict.TryGetValue(Path.GetFileNameWithoutExtension(path), out t);
			return t;
		}

		// // RVA: 0x1104310 Offset: 0x1104310 VA: 0x1104310
		// public Rect GetGameAttributeUvRect(GameAttribute.Type attr) { }

		// // RVA: 0x1104398 Offset: 0x1104398 VA: 0x1104398
		// public Rect GetDifficultyUvRect(Difficulty.Type diff) { }

		// // RVA: 0x1104420 Offset: 0x1104420 VA: 0x1104420
		public Rect GetSkillRankUvRect(SkillRank.Type rank)
		{
			return m_skillRankRects[(int)rank];
		}

		// // RVA: 0x11044A8 Offset: 0x11044A8 VA: 0x11044A8
		// public Rect GetLiveSkillTypeUvRect(LiveSkillType.Type skillType) { }

		// // RVA: 0x1104530 Offset: 0x1104530 VA: 0x1104530
		public void SetImageSkillRank(RawImageEx image, SkillRank.Type rank)
		{
			image.uvRect = GetSkillRankUvRect(rank);
		}

		// // RVA: 0x1104580 Offset: 0x1104580 VA: 0x1104580
		// public void SetImageLiveSkillType(RawImageEx image, LiveSkillType.Type skillType) { }

		// // RVA: 0x11045D0 Offset: 0x11045D0 VA: 0x11045D0
		private TexUVData GetTexUvData(string key)
		{
			foreach(var k in m_unionTextureUVDict)
			{
				TexUVData data = k.Value.GetUVData(key);
				if(data != null)
					return data;
			}
			return null;
		}

		// // RVA: 0x1104790 Offset: 0x1104790 VA: 0x1104790
		private void MakeUvRects(List<Rect> uvRects, string format, int beginIndex, int count)
		{
			for(int i = beginIndex; i < count; i++)
			{
				m_stringBuilder.SetFormat(format, i);
				uvRects.Add(LayoutUGUIUtility.MakeUnityUVRect(GetTexUvData(m_stringBuilder.ToString())));
			}
		}
	}
}
