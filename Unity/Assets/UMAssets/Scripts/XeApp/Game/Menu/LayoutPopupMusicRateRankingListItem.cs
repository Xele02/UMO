using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using XeApp.Game.Common;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutPopupMusicRateRankingListItem : FlexibleListItemLayout
	{
		[SerializeField]
		private Text m_textName; // 0x18
		[SerializeField]
		private Text m_textRank; // 0x1C
		[SerializeField]
		private Text m_textGradeName; // 0x20
		[SerializeField]
		private Text m_textRateNum; // 0x24
		[SerializeField]
		private Text m_textRanking; // 0x28
		[SerializeField]
		private RawImageEx m_imageDiva; // 0x2C
		[SerializeField]
		private RawImageEx m_imageScene; // 0x30
		[SerializeField]
		private RawImageEx m_imageGrade; // 0x34
		[SerializeField]
		private ButtonBase m_buttonProf; // 0x38
		private AbsoluteLayout m_layoutRanking; // 0x3C
		private RankingListInfo m_view; // 0x40
		private DivaIconDecoration m_divaDeco; // 0x44
		private SceneIconDecoration m_sceneDeco; // 0x48
		private bool m_initialized; // 0x4C
		private HighScoreRatingRank.Type m_gradeId; // 0x54

		public Action<RankingListInfo> OnClickButton { get; set; } // 0x50

		//// RVA: 0x1738EF4 Offset: 0x1738EF4 VA: 0x1738EF4
		//public bool IsLoaded() { }

		//// RVA: 0x1738FA0 Offset: 0x1738FA0 VA: 0x1738FA0
		public void SetStatus(RankingListInfo view)
		{
			m_view = view;
			m_imageDiva.enabled = false;
			GameManager.Instance.DivaIconCache.Load(view.divaId, view.divaCostumeId, view.divaCostumeColorId, (IiconTexture texture) =>
			{
				//0x1739E48
				texture.Set(m_imageDiva);
				m_imageDiva.enabled = true;
			});
			m_imageScene.enabled = false;
			GameManager.Instance.SceneIconCache.Load(view.sceneId, view.sceneRank, (IiconTexture texture) =>
			{
				//0x1739F74
				texture.Set(m_imageScene);
				SceneIconTextureCache.ChangeKiraMaterial(m_imageScene, texture as IconTexture, view.isKira);
				m_imageScene.enabled = true;
			});
			m_textName.text = view.name;
			m_textRank.text = view.playerLevel.ToString();
			m_textGradeName.text = HighScoreRatingRank.GetRankName(view.scoreRatingRank);
			SetGradeImage(view.scoreRatingRank);
			m_textRateNum.text = view.score.ToString();
			SetRanking(view.rankingOrder);
			m_divaDeco.SetActive(true);
			m_divaDeco.Change(view.friend.JIGONEMPPNP_Diva, view.friend, DisplayType.Level, view.friend.AFBMEMCHJCL_MainScene);
			m_sceneDeco.SetActive(true);
			m_sceneDeco.Change(view.friend.AFBMEMCHJCL_MainScene, DisplayType.Level);
			m_initialized = true;
		}

		//// RVA: 0x1739644 Offset: 0x1739644 VA: 0x1739644
		private void SetGradeImage(HighScoreRatingRank.Type gradeId)
		{
			m_gradeId = gradeId;
			m_imageGrade.enabled = false;
			GameManager.Instance.MusicRatioTextureCache.Load(gradeId, (IiconTexture texture) =>
			{
				//0x173A12C
				if(m_gradeId == gradeId)
				{
					m_imageGrade.enabled = true;
					(texture as MusicRatioTextureCache.MusicRatioTexture).Set(m_imageGrade, m_gradeId);
				}
			});
		}

		//// RVA: 0x17399D0 Offset: 0x17399D0 VA: 0x17399D0
		public void InitializeDecos()
		{
			if(m_divaDeco == null)
			{
				m_divaDeco = new DivaIconDecoration(m_imageDiva.gameObject, DivaIconDecoration.Size.S, true, true, null, null);
			}
			if(m_sceneDeco == null)
			{
				m_sceneDeco = new SceneIconDecoration(m_imageScene.gameObject, SceneIconDecoration.Size.M, null, null);
			}
		}

		//// RVA: 0x1739B00 Offset: 0x1739B00 VA: 0x1739B00
		public void ReleaseDecos()
		{
			if(m_divaDeco != null)
			{
				m_divaDeco.Release();
				m_divaDeco = null;
			}
			if(m_sceneDeco != null)
			{
				m_sceneDeco.Release();
				m_sceneDeco = null;
			}
		}

		//// RVA: 0x17397F4 Offset: 0x17397F4 VA: 0x17397F4
		private void SetRanking(int ranking)
		{
			if(ranking == 3)
			{
				m_layoutRanking.StartChildrenAnimGoStop("03");
			}
			else if(ranking == 2)
			{
				m_layoutRanking.StartChildrenAnimGoStop("02");
			}
			else if(ranking != 1)
			{
				m_layoutRanking.StartChildrenAnimGoStop("04");
				m_textRanking.text = string.Format(MessageManager.Instance.GetMessage("menu", "popup_music_rate_rank_unit"), ranking);
			}
			else
			{
				m_layoutRanking.StartChildrenAnimGoStop("01");
			}
		}

		//// RVA: 0x1739B48 Offset: 0x1739B48 VA: 0x1739B48
		public void UpdateLayoutDisplay()
		{
			m_layoutRanking.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
			m_layoutRanking.UpdateAll(new Matrix23(), Color.white);
		}

		// RVA: 0x1739C04 Offset: 0x1739C04 VA: 0x1739C04 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_textName.horizontalOverflow = HorizontalWrapMode.Wrap;
			m_textName.resizeTextForBestFit = true;
			m_textName.resizeTextMaxSize = m_textName.fontSize;
			m_layoutRanking = layout.FindViewById("swtbl_list_cont_icon_rank_mvp") as AbsoluteLayout;
			m_buttonProf.AddOnClickCallback(() =>
			{
				//0x1739DD8
				if (OnClickButton != null)
					OnClickButton(m_view);
			});
			Loaded();
			return true;
		}
	}
}
