using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using System.Collections.Generic;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutPopupMusicGradeListItem : FlexibleListItemLayout
	{
		public enum FrameType
		{
			White = 0,
			Pink = 1,
			Num = 2,
		}

		private static readonly string[] s_frameAttrUvFormat = new string[2] { "p_mrate_win_b_{0:D2}", "p_mrate_win_p_{0:D2}" }; // 0x0
		[SerializeField]
		private Text m_text01; // 0x18
		[SerializeField]
		private Text m_text02; // 0x1C
		[SerializeField]
		private Text m_text03; // 0x20
		[SerializeField]
		private RawImageEx m_image01; // 0x24
		[SerializeField]
		private List<RawImageEx> m_imageFrame = new List<RawImageEx>(); // 0x28
		private TexUVListManager m_uvMan; // 0x2C
		private AbsoluteLayout m_layout; // 0x30
		private bool m_initialized; // 0x34
		private ECEPJHGMGBJ m_view; // 0x38
		private bool m_my_self; // 0x3C
		private HighScoreRatingRank.Type m_grade; // 0x40
		private string m_str01; // 0x44
		private string m_str02; // 0x48
		private string m_str03; // 0x4C

		//public ECEPJHGMGBJ View { get; } 0x1733ABC

		//// RVA: 0x1733AC4 Offset: 0x1733AC4 VA: 0x1733AC4
		//public bool IsJacketLoaded() { }

		//// RVA: 0x1733ACC Offset: 0x1733ACC VA: 0x1733ACC
		public void SetStatus(LayoutMusicRateList.FlexibleListItem_Grade a_item)
		{
			m_my_self = a_item.MySelf;
			m_grade = a_item.MusicGrade;
			HighScoreRatingRank.Type t_grade = m_grade;
			m_str01 = ReplaceSpace(a_item.MusicGradeName);
			m_str03 = a_item.MusicMustRate;
			UpdateText();
			m_image01.enabled = false;
			GameManager.Instance.MusicRatioTextureCache.Load(m_grade, (IiconTexture texture) =>
			{
				//0x173465C
				if(m_grade == t_grade)
				{
					MusicRatioTextureCache.MusicRatioTexture tex = texture as MusicRatioTextureCache.MusicRatioTexture;
					if(tex != null)
					{
						m_image01.enabled = true;
						tex.Set(m_image01, m_grade);
					}
				}
			});
			SetFrameUv(m_my_self ? FrameType.Pink : FrameType.White);
			m_initialized = true;
		}

		//// RVA: 0x1733DEC Offset: 0x1733DEC VA: 0x1733DEC
		private void UpdateText()
		{
			if (!m_my_self)
			{
				m_text01.text = m_str01;
				m_text02.text = m_str02;
				m_text03.text = m_str03;
			}
			else
			{
				m_text01.text = TextColorChange(m_str01);
				m_text02.text = TextColorChange(m_str02);
				m_text03.text = TextColorChange(m_str03);
			}
		}

		//// RVA: 0x173426C Offset: 0x173426C VA: 0x173426C
		private string TextColorChange(string a_str)
		{
			return "<color=#ffffff>" + a_str + "</color>";
		}

		//// RVA: 0x1733D24 Offset: 0x1733D24 VA: 0x1733D24
		private string ReplaceSpace(string a_str)
		{
			return a_str.Replace(JpStringLiterals.StringLiteral_12037, "").Replace(" ", "");
		}

		//// RVA: 0x1733F18 Offset: 0x1733F18 VA: 0x1733F18
		private void SetFrameUv(FrameType a_type)
		{
			for(int i = 0; i < m_imageFrame.Count; i++)
			{
				m_imageFrame[i].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData(string.Format(s_frameAttrUvFormat[(int)a_type], i + 1)));
			}
			m_text01.color = new Color(1, 1, 1, 1);
			m_text02.color = new Color(1, 1, 1, 1);
			m_text03.color = new Color(1, 1, 1, 1);
		}

		// RVA: 0x17342E4 Offset: 0x17342E4 VA: 0x17342E4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_str02 = bk.GetMessageByLabel("popup_music_rate_must");
			m_str03 = JpStringLiterals.StringLiteral_17446;
			UpdateText();
			m_uvMan = uvMan;
			m_layout = layout.FindViewById("swtbl_rate_txt_03") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
