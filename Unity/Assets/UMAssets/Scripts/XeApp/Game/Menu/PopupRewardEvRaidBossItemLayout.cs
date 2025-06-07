using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupRewardEvRaidBossItemLayout : SwapScrollListContent
	{
		private RawImageEx m_utaGradeImage; // 0x20
		private Text m_utaGradeText; // 0x24
		private Text m_lotCountText; // 0x28
		private AbsoluteLayout m_bossRankLower; // 0x2C
		private AbsoluteLayout m_bossRankUppwer; // 0x30
		private RawImageEx[] m_frameImages; // 0x34
		private Rect[] m_uvDataB; // 0x38
		private Rect[] m_uvDataP; // 0x3C

		// RVA: 0x1A76B78 Offset: 0x1A76B78 VA: 0x1A76B78 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			LayoutUGUIRuntime lt = GetComponent<LayoutUGUIRuntime>();
			RawImageEx[] imgs = lt.GetComponentsInChildren<RawImageEx>();
			m_utaGradeImage = imgs.Where((RawImageEx _) =>
			{
				//0x1A77F40
				return _.name == "cmn_musicrate (ImageView)";
			}).First();
			m_frameImages = imgs.Where((RawImageEx _) =>
			{
				//0x1A77FC0
				return _.name.Contains("frame_b");
			}).ToArray();
			Text[] txts = lt.GetComponentsInChildren<Text>();
			m_utaGradeText = txts.Where((Text _) =>
			{
				//0x1A78058
				return _.name == "rate (TextView)";
			}).First();
			m_lotCountText = txts.Where((Text _) =>
			{
				//0x1A780D8
				return _.name == "num (TextView)";
			}).First();
			m_bossRankLower = layout.FindViewByExId("sw_utarate_frm_swtbl_raid_boss_rank_01") as AbsoluteLayout;
			m_bossRankUppwer = layout.FindViewByExId("sw_utarate_frm_swtbl_raid_boss_rank_02") as AbsoluteLayout;
			string[] s = new string[4]
			{
				"frame_b_01", "frame_b_02", "frame_b_03", "frame_b_04"
			};
			string[] s2 = new string[4]
			{
				"frame_p_01", "frame_p_02", "frame_p_03", "frame_p_04"
			};
			m_uvDataB = new Rect[s.Length];
			m_uvDataP = new Rect[s2.Length];
			for(int i = 0; i < s.Length; i++)
			{
				m_uvDataB[i] = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData(s[i]));
			}
			for(int i = 0; i < s.Length; i++)
			{
				m_uvDataP[i] = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData(s2[i]));
			}
			Loaded();
			return true;
		}

		// // RVA: 0x1A77804 Offset: 0x1A77804 VA: 0x1A77804
		public void SetRewardData(IIMNHDGFDAG info, HighScoreRatingRank.Type playerUtaGrade, string utaGradeMoreText)
		{
			SetHighScoreRatingRank((HighScoreRatingRank.Type)info.ILELGGCCGMJ_HighscoreRank);
			m_utaGradeText.text = HighScoreRatingRank.GetRankName((HighScoreRatingRank.Type)info.ILELGGCCGMJ_HighscoreRank);
			if(!info.DJEMBILEBFP_IsPlayerRank)
			{
				SetFrameColor(info.ILELGGCCGMJ_HighscoreRank == (int)playerUtaGrade);
			}
			else
			{
				SetFrameColor(info.ILELGGCCGMJ_HighscoreRank <= (int)playerUtaGrade);
				m_utaGradeText.text += utaGradeMoreText;
			}
			m_bossRankLower.StartChildrenAnimGoStop(string.Format("{0:D2}", info.IOBJDNEGEBB_BossRankLower));
			m_bossRankUppwer.StartChildrenAnimGoStop(string.Format("{0:D2}", info.PKLKOMIAKNL_BossRankUpper));
			m_lotCountText.text = string.Format(JpStringLiterals.StringLiteral_19505, info.CHOIMPLAOCO_RewardCountLower, info.EAOBPKJDDKC_RewardCountUpper);
		}

		// // RVA: 0x1A77B08 Offset: 0x1A77B08 VA: 0x1A77B08
		private void SetHighScoreRatingRank(HighScoreRatingRank.Type rank)
		{
			GameManager.Instance.MusicRatioTextureCache.Load(rank, (IiconTexture texture) =>
			{
				//0x1A78158
				if(texture != null)
				{
					MusicRatioTextureCache.MusicRatioTexture t = texture as MusicRatioTextureCache.MusicRatioTexture;
					if(t != null)
					{
						t.Set(m_utaGradeImage, rank);
					}
				}
			});
		}

		// // RVA: 0x1A77C68 Offset: 0x1A77C68 VA: 0x1A77C68
		private void SetFrameColor(bool isPink)
		{
			for(int i = 0; i < m_frameImages.Length; i++)
			{
				if(m_frameImages[i].name.Contains(string.Format("frame_b_{0:D2}", i + 1)))
				{
					m_frameImages[i].uvRect = isPink ? m_uvDataP[i] : m_uvDataB[i];
				}
			}
		}
	}
}
