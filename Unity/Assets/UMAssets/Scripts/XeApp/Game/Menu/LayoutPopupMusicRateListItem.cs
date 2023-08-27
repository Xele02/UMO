using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using System.Collections.Generic;
using XeSys;
using XeApp.Game.Common.uGUI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutPopupMusicRateListItem : FlexibleListItemLayout
	{
		public enum AlignType
		{
			tl = 0,
			tc = 1,
			tr = 2,
			cl = 3,
			cr = 4,
			bl = 5,
			bc = 6,
			br = 7,
			_Num = 8,
		}

		private static readonly string[] s_frameAttrUvFormat = new string[5]
			{
				"pop_m_rate_frm_05_{0:D2}",
				"pop_m_rate_frm_01_{0:D2}",
				"pop_m_rate_frm_02_{0:D2}",
				"pop_m_rate_frm_03_{0:D2}",
				"pop_m_rate_frm_04_{0:D2}"
			}; // 0x0
		private static readonly string[] s_iconAttrUvFormat = new string[5]
			{
				"pop_m_zok_01",
				"pop_m_zok_01",
				"pop_m_zok_02",
				"pop_m_zok_03",
				"pop_m_zok_04"
			}; // 0x4
		[SerializeField]
		private Text m_textRank; // 0x18
		[SerializeField]
		private Text m_textName; // 0x1C
		[SerializeField]
		private Text[] m_textRate = new Text[3]; // 0x20
		[SerializeField]
		private RawImageEx m_imageRank; // 0x24
		[SerializeField]
		private RawImageEx m_imageJacket; // 0x28
		[SerializeField]
		private RawImageEx m_imageDifficulty; // 0x2C
		[SerializeField]
		private RawImageEx m_imageAttr; // 0x30
		[SerializeField]
		private List<RawImageEx> m_imageFrame = new List<RawImageEx>(); // 0x34
		private TexUVListManager m_uvMan; // 0x38
		private AbsoluteLayout m_layout; // 0x3C
		private bool m_initialized; // 0x40
		private ECEPJHGMGBJ m_view; // 0x44
		public int m_JacketId; // 0x48

		//public ECEPJHGMGBJ View { get; } 0x17357AC

		//// RVA: 0x17357B4 Offset: 0x17357B4 VA: 0x17357B4
		//public bool IsJacketLoaded() { }

		//// RVA: 0x1735804 Offset: 0x1735804 VA: 0x1735804
		public void SetStatus(int a_index, ECEPJHGMGBJ view)
		{
			m_view = view;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(view.FJOLNJLLJEJ_RankNum < 4)
			{
				m_imageRank.enabled = true;
				m_imageRank.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData("pop_m_rank" + view.FJOLNJLLJEJ_RankNum.ToString("D2")));
				m_textRank.text = "";
			}
			else
			{
				m_imageRank.enabled = false;
				m_textRank.text = view.FJOLNJLLJEJ_RankNum.ToString();
			}
			m_textName.text = RichTextUtility.MakeColorTagString(view.NEDBBJDAFBH_MusicName, GameAttributeTextColor.Colors[Mathf.Clamp(view.FKDCCLPGKDK_JacketAttr - 1, 0, GameAttributeTextColor.Colors.Length)]);
			SetFrameUv(s_frameAttrUvFormat[view.FKDCCLPGKDK_JacketAttr]);
			SetIconUv(s_iconAttrUvFormat[view.FKDCCLPGKDK_JacketAttr]);
			SetRating(view.HKIAHOEEMLC_PrevScore, view.LPALNMHPDKK_Score);
			m_imageDifficulty.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData("cmn_music_diff_" + (view.LFGNLKKFOCD_IsLine6 ? (int)view.AKNELONELJK_Difficulty + 3 : (int)view.AKNELONELJK_Difficulty + 1).ToString("D2")));
			GameManager.Instance.UnionTextureManager.GetTexture(!view.LFGNLKKFOCD_IsLine6 ? "cmn_tex_pack" : "cmn_tex_02_pack").Set(m_imageDifficulty);
			m_imageJacket.enabled = false;
			m_JacketId = view.JNCPEGJGHOG_JacketId;
			int jacketId = m_JacketId;
			GameManager.Instance.MusicJacketTextureCache.Load(m_JacketId, (IiconTexture image) =>
			{
				//0x1736C6C
				if (m_JacketId != jacketId)
					return;
				m_imageJacket.enabled = true;
				image.Set(m_imageJacket);
			});
			m_initialized = true;
		}

		//// RVA: 0x1736300 Offset: 0x1736300 VA: 0x1736300
		public void SetRating(int rate0, int rate)
		{
			m_textRate[1].text = rate.ToString();
			m_textRate[0].text = rate0.ToString();
			m_layout.StartChildrenAnimGoStop(rate0 < rate ? "02" : "01");
		}

		//// RVA: 0x173606C Offset: 0x173606C VA: 0x173606C
		private void SetFrameUv(string uvFormat)
		{
			for(int i = 0; i < m_imageFrame.Count; i++)
			{
				m_imageFrame[i].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData(string.Format(uvFormat, i + 1)));
			}
		}

		//// RVA: 0x1736214 Offset: 0x1736214 VA: 0x1736214
		private void SetIconUv(string uvName)
		{
			m_imageAttr.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData(uvName));
		}

		// RVA: 0x1736470 Offset: 0x1736470 VA: 0x1736470 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_textRate[2].text = bk.GetMessageByLabel("popup_music_rate_up");
			m_textName.horizontalOverflow = HorizontalWrapMode.Wrap;
			m_textName.resizeTextForBestFit = true;
			m_textName.resizeTextMaxSize = m_textName.fontSize;
			m_uvMan = uvMan;
			m_layout = layout.FindViewById("swtbl_rate_txt_03") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
