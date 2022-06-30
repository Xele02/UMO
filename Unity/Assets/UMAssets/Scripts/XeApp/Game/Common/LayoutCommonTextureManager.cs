using System.Collections.Generic;
using System.IO;
using XeSys.Gfx;

namespace XeApp.Game.Common
{
	public class LayoutCommonTextureManager
	{
		// private const string BundleName = "ly/ct.xab";
		// private string[] TexUvListAssetName = new string[2] { "cmn_tex_pack_uvlist", "cmn_tex_02_pack_uvlist" }; // 0x8
		// private string[] TexListAssetName = new string[2] { "cmn_tex_pack", "cmn_tex_02_pack" }; // 0xC
		private Dictionary<string, TexUVList> m_unionTextureUVDict = new Dictionary<string, TexUVList>(); // 0x10
		// private Dictionary<string, LayoutCommonTextureManager.CommonTexture> m_unionTextureDict = new Dictionary<string, LayoutCommonTextureManager.CommonTexture>(); // 0x14
		// private StringBuilder m_stringBuilder = new StringBuilder(); // 0x18
		// private List<Rect> m_gameAttributeRects = new List<Rect>(GameAttribute.ArrayNum); // 0x1C
		// private List<Rect> m_difficultyRects = new List<Rect>(5); // 0x20
		// private List<Rect> m_skillRankRects = new List<Rect>(4); // 0x24
		// private List<Rect> m_liveSkillTypeRects = new List<Rect>(2); // 0x28

		// public bool IsReady { get; private set; } // 0x2C

		// [IteratorStateMachineAttribute] // RVA: 0x73969C Offset: 0x73969C VA: 0x73969C
		// // RVA: 0x1103F64 Offset: 0x1103F64 VA: 0x1103F64
		// public IEnumerator LoadUnionTexture() { }

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
		// public LayoutCommonTextureManager.CommonTexture GetTexture(string path) { }

		// // RVA: 0x1104310 Offset: 0x1104310 VA: 0x1104310
		// public Rect GetGameAttributeUvRect(GameAttribute.Type attr) { }

		// // RVA: 0x1104398 Offset: 0x1104398 VA: 0x1104398
		// public Rect GetDifficultyUvRect(Difficulty.Type diff) { }

		// // RVA: 0x1104420 Offset: 0x1104420 VA: 0x1104420
		// public Rect GetSkillRankUvRect(SkillRank.Type rank) { }

		// // RVA: 0x11044A8 Offset: 0x11044A8 VA: 0x11044A8
		// public Rect GetLiveSkillTypeUvRect(LiveSkillType.Type skillType) { }

		// // RVA: 0x1104530 Offset: 0x1104530 VA: 0x1104530
		// public void SetImageSkillRank(RawImageEx image, SkillRank.Type rank) { }

		// // RVA: 0x1104580 Offset: 0x1104580 VA: 0x1104580
		// public void SetImageLiveSkillType(RawImageEx image, LiveSkillType.Type skillType) { }

		// // RVA: 0x11045D0 Offset: 0x11045D0 VA: 0x11045D0
		// private TexUVData GetTexUvData(string key) { }

		// // RVA: 0x1104790 Offset: 0x1104790 VA: 0x1104790
		// private void MakeUvRects(List<Rect> uvRects, string format, int beginIndex, int count) { }
	}
}
