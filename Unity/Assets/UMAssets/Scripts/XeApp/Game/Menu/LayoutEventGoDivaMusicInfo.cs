using XeSys.Gfx;
using XeApp.Game;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System.Text;
using System;
using XeSys;
using XeApp.Game.Menu.EventGoDiva;
using XeApp.Game.Common.uGUI;

namespace XeApp.Game.Menu
{
	public class LayoutEventGoDivaMusicInfo : LayoutUGUIScriptBase
	{
		public enum BonusStatusType
		{
			None = 0,
			Normal = 1,
			Daily = 2,
			Hide = 3,
			Num = 4,
		}

		private static readonly string[] ExpTypeLabel = new string[4]
		{
			"01", "02", "03", "04"
		}; // 0x0
		[SerializeField]
		private TextureListSupport m_textureListSupport; // 0x14
		[SerializeField]
		private RawImageEx m_imageLineIcon; // 0x18
		[SerializeField]
		private ActionButton m_buttonChangeDiva; // 0x1C
		[SerializeField]
		private ActionButton m_buttonChangeMusic; // 0x20
		[SerializeField]
		private ActionButton m_buttonRandomMusic; // 0x24
		[SerializeField]
		private RawImageEx m_imageDifficulty; // 0x28
		[SerializeField]
		private Text[] m_textExpTbl; // 0x2C
		[SerializeField]
		private LayoutEventGoDivaAttrFrame m_attrFrame; // 0x30
		[SerializeField]
		private RawImageEx m_imageJacket; // 0x34
		[SerializeField]
		private ActionButton m_buttonUseBonusItem; // 0x38
		[SerializeField]
		private Text m_textBonusRate; // 0x3C
		[SerializeField]
		private Text[] m_textBonusRemainCountTbl; // 0x40
		[SerializeField]
		private Text m_textBonus; // 0x44
		[SerializeField]
		private MusicSelectPlayButton m_playButton; // 0x48
		[SerializeField]
		private Text m_textLevel; // 0x4C
		[SerializeField]
		private Text m_textHighScore; // 0x50
		[SerializeField]
		private Text m_textTitle; // 0x54
		[SerializeField]
		private Text m_textSinger; // 0x58
		private bool m_isShown; // 0x5C
		private StringBuilder m_stringBuilder = new StringBuilder(); // 0x60
		private int m_jacketLoadingCount; // 0x64
		private int m_currentJacketCoverId = -1; // 0x68
		private TexUVListManager m_uvManager; // 0x6C
		private AbsoluteLayout m_layoutMain; // 0x70
		private AbsoluteLayout m_layoutLineIconOnOff; // 0x74
		private AbsoluteLayout m_layoutBonusIconOnOff; // 0x78
		private AbsoluteLayout m_layoutExpType; // 0x7C
		private AbsoluteLayout m_layoutBonusLotsStatusType; // 0x80
		private AbsoluteLayout m_layoutButtonUseBonusItem; // 0x84
		private AbsoluteLayout m_layoutBonusRateGauge; // 0x88
		private AbsoluteLayout m_layoutBonusTextOnOff; // 0x8C
		private AbsoluteLayout m_layoutPlayButtonType; // 0x90
		private AbsoluteLayout m_layoutScoreRankType; // 0x94
		public Action OnClickChangeDivaButtonListener; // 0x98
		public Action OnClickChangeMusicButtonListener; // 0x9C
		public Action OnClickRandomMusicButtonListener; // 0xA0
		public Action OnClickUseBonusItemButtonListener; // 0xA4
		public Action OnClickPlayButtonListener; // 0xA8
		private const char s_fillChar = '\x30';

		public bool IsLoadingJacket { get { return m_jacketLoadingCount > 0; } } //0x1990E34
 
		// // RVA: 0x1990E48 Offset: 0x1990E48 VA: 0x1990E48
		public void Enter()
		{
			m_isShown = true;
			m_layoutMain.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x1990EDC Offset: 0x1990EDC VA: 0x1990EDC
		public void Leave()
		{
			m_isShown = false;
			m_layoutMain.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x1990F70 Offset: 0x1990F70 VA: 0x1990F70
		public void TryEnter()
		{
			if(!m_isShown)
				Enter();
		}

		// // RVA: 0x1990F80 Offset: 0x1990F80 VA: 0x1990F80
		public void TryLeave()
		{
			if(m_isShown)
				Leave();
		}

		// // RVA: 0x1990F90 Offset: 0x1990F90 VA: 0x1990F90
		// public void Show() { }

		// // RVA: 0x1991014 Offset: 0x1991014 VA: 0x1991014
		public void Hide()
		{
			m_isShown = false;
			m_layoutMain.StartChildrenAnimGoStop("st_wait");
		}

		// RVA: 0x1991098 Offset: 0x1991098 VA: 0x1991098
		public bool IsPlaying()
		{
			return m_layoutMain.IsPlayingChildren();
		}

		// // RVA: 0x19910C4 Offset: 0x19910C4 VA: 0x19910C4
		public void SetBonusLotsStatus(BonusStatusType type, int lotsPercentage, int bonusRemainCount, bool isShowBonusItem, bool canUseBonusItem)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(type == BonusStatusType.None)
			{
				m_stringBuilder.Set("01");
			}
			else if(type == BonusStatusType.Normal)
			{
				bonusRemainCount = 0;
				m_stringBuilder.Set("04");
			}
			else if(type == BonusStatusType.Hide)
			{
				m_stringBuilder.Set("03");
			}
			else
			{
				m_stringBuilder.Set("05");
			}
			m_layoutBonusLotsStatusType.StartChildrenAnimGoStop(m_stringBuilder.ToString());
			m_stringBuilder.Set("");
			if(bonusRemainCount > 0)
			{
				m_stringBuilder.SetFormat(bk.GetMessageByLabel("godiva_music_info_bonus_remain_count"), bonusRemainCount);
			}
			for(int i = 0; i < m_textBonusRemainCountTbl.Length; i++)
			{
				m_textBonusRemainCountTbl[i].text = m_stringBuilder.ToString();
			}
			m_stringBuilder.SetFormat(bk.GetMessageByLabel("godiva_music_info_bonus_lots_rate"), lotsPercentage);
			m_textBonusRate.text = m_stringBuilder.ToString();
			m_layoutBonusRateGauge.StartChildrenAnimGoStop(lotsPercentage, lotsPercentage);
			if(isShowBonusItem)
			{
				if(canUseBonusItem)
				{
					m_buttonUseBonusItem.enabled = true;
					m_layoutButtonUseBonusItem.StartChildrenAnimGoStop("st_bot_decide");
				}
				else
				{
					m_buttonUseBonusItem.enabled = false;
					m_layoutButtonUseBonusItem.StartChildrenAnimGoStop("st_bot_imp");
				}
			}
			else
			{
				m_buttonUseBonusItem.enabled = false;
				m_layoutButtonUseBonusItem.StartChildrenAnimGoStop("st_non");
			}
		}

		// // RVA: 0x1991534 Offset: 0x1991534 VA: 0x1991534
		public void SetMusicInfo(IBJAKJJICBC musicData, Difficulty.Type difficulty, bool is6LineMode, ExpType expType, int expValue, bool isOpenBonus, float bonusValue)
		{
			SetLineIcon(is6LineMode);
			SetDifficulty(difficulty, is6LineMode);
			SetExp(expType, expValue);
			SetAttr((GameAttribute.Type) musicData.FKDCCLPGKDK_JacketAttr);
			SetJacket(musicData.JNCPEGJGHOG_JacketId);
			if(musicData.OGHOPBAKEFE_IsEventSpecial)
			{
				SetBonusOpen(isOpenBonus, bonusValue);
				isOpenBonus = false;
			}
			else
			{
				bonusValue = 0;
				SetBonusOpen(false, 0);
			}
			SetBonusIconOnOff(isOpenBonus);
			if(musicData.MGJKEJHEBPO_DiffInfos[(int)difficulty].HHMLMKAEJBJ_Score != null)
			{
				SetLevel(musicData.MGJKEJHEBPO_DiffInfos[(int)difficulty].HHMLMKAEJBJ_Score.ANAJIAENLNB_MusicLevel, is6LineMode);
			}
			if(musicData.MGJKEJHEBPO_DiffInfos[(int)difficulty].BCGLDMKODLC_IsClear)
			{
				int score = musicData.MGJKEJHEBPO_DiffInfos[(int)difficulty].KNIFCANOHOC_Score;
				SetScoreRank((ResultScoreRank.Type)musicData.MGJKEJHEBPO_DiffInfos[(int)difficulty].BAKLKJLPLOJ.DLPBHJALHCK_GetScoreRank(score));
				SetHighScore(score);
			}
			else
			{
				SetHighScore(0);
				SetScoreRank(ResultScoreRank.Type.Illegal);
			}
			SetTitle(musicData.NEDBBJDAFBH_MusicName, (GameAttribute.Type) musicData.FKDCCLPGKDK_JacketAttr);
			SetSinger(musicData.LJCEDBBNPBB_VocalName);
		}

		// // RVA: 0x1992634 Offset: 0x1992634 VA: 0x1992634
		public void SetPlayButton(IBJAKJJICBC musicData, Difficulty.Type difficulty)
		{
			SetNeedEnergy(musicData.MGJKEJHEBPO_DiffInfos[(int)difficulty].BPLOEAHOPFI_Energy);
			SetPlayButtonType(musicData.IFNPBIJEPBO_IsDlded ? PlayButtonWrapper.Type.PlayEn : PlayButtonWrapper.Type.Download);
		}

		// // RVA: 0x1992844 Offset: 0x1992844 VA: 0x1992844
		private void OnClickChangeDivaButton()
		{
			if(OnClickChangeDivaButtonListener != null)
				OnClickChangeDivaButtonListener();
		}

		// // RVA: 0x1992858 Offset: 0x1992858 VA: 0x1992858
		private void OnClickChangeMusicButton()
		{
			if(OnClickChangeMusicButtonListener != null)
				OnClickChangeMusicButtonListener();
		}

		// // RVA: 0x199286C Offset: 0x199286C VA: 0x199286C
		private void OnClickRandomMusicButton()
		{
			if(OnClickRandomMusicButtonListener != null)
				OnClickRandomMusicButtonListener();
		}

		// // RVA: 0x1992880 Offset: 0x1992880 VA: 0x1992880
		private void OnClickUseBonusItemButton()
		{
			if(OnClickUseBonusItemButtonListener != null)
				OnClickUseBonusItemButtonListener();
		}

		// // RVA: 0x1992894 Offset: 0x1992894 VA: 0x1992894
		private void OnClickPlayButton()
		{
			if(OnClickPlayButtonListener != null)
				OnClickPlayButtonListener();
		}

		// // RVA: 0x1991818 Offset: 0x1991818 VA: 0x1991818
		private void SetLineIcon(bool is6LineMode)
		{
			m_layoutLineIconOnOff.StartChildrenAnimGoStop(is6LineMode ? "01" : "02");
		}

		// // RVA: 0x19920A0 Offset: 0x19920A0 VA: 0x19920A0
		private void SetBonusIconOnOff(bool bOn)
		{
			m_layoutBonusIconOnOff.StartChildrenAnimGoStop(bOn ? "01" : "02");
		}

		// // RVA: 0x19918B0 Offset: 0x19918B0 VA: 0x19918B0
		private void SetDifficulty(Difficulty.Type difficulty, bool is6LineMode)
		{
			if(!is6LineMode)
			{
				m_stringBuilder.SetFormat("cmn_music_diff_{0:D2}", (int)difficulty + 1);
				GameManager.Instance.UnionTextureManager.GetTexture("cmn_tex_pack").Set(m_imageDifficulty);
			}
			else
			{
				m_stringBuilder.SetFormat("cmn_music_diff_{0:D2}", (int)difficulty + 4);
				GameManager.Instance.UnionTextureManager.GetTexture("cmn_tex_02_pack").Set(m_imageDifficulty);
			}
			m_imageDifficulty.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData(m_stringBuilder.ToString()));
		}

		// // RVA: 0x1991B7C Offset: 0x1991B7C VA: 0x1991B7C
		private void SetExp(ExpType type, int value)
		{
			m_layoutExpType.StartChildrenAnimGoStop(ExpTypeLabel[(int)type]);
			for(int i = 0; i < m_textExpTbl.Length; i++)
			{
				m_textExpTbl[i].text = value.ToString();
			}
		}

		// // RVA: 0x1991CF8 Offset: 0x1991CF8 VA: 0x1991CF8
		private void SetAttr(GameAttribute.Type attr)
		{
			m_attrFrame.SetAttribute(attr);
		}

		// // RVA: 0x1991D2C Offset: 0x1991D2C VA: 0x1991D2C
		private void SetJacket(int coverId)
		{
			if(m_currentJacketCoverId == coverId)
				return;
			m_jacketLoadingCount++;
			m_currentJacketCoverId = coverId;
			GameManager.Instance.MusicJacketTextureCache.Load(coverId, (IiconTexture texture) =>
			{
				//0x19934A8
				m_jacketLoadingCount--;
				if(m_currentJacketCoverId != coverId)
				{
					Debug.Log("StringLiteral_16837");
					return;
				}
				texture.Set(m_imageJacket);
			});
		}

		// // RVA: 0x1991EF0 Offset: 0x1991EF0 VA: 0x1991EF0
		private void SetBonusOpen(bool enable, float value)
		{
			m_layoutBonusTextOnOff.StartChildrenAnimGoStop(enable ? "01" : "02");
			m_stringBuilder.SetFormat(MessageManager.Instance.GetMessage("menu", "godiva_music_info_exp_bonus"), value);
			m_textBonus.text = m_stringBuilder.ToString();
		}

		// // RVA: 0x1992778 Offset: 0x1992778 VA: 0x1992778
		private void SetPlayButtonType(PlayButtonWrapper.Type type)
		{
			m_layoutPlayButtonType.StartChildrenAnimGoStop(type <= PlayButtonWrapper.Type.Ok ? new string[6]
			{
				"01", "02", "03", "04", "05", "06"
			}[(int)type] : "");
			m_playButton.SetDLMessage(false);
		}

		// // RVA: 0x1992744 Offset: 0x1992744 VA: 0x1992744
		private void SetNeedEnergy(int energy)
		{
			m_playButton.SetNeedEnergy(energy);
		}

		// // RVA: 0x1992134 Offset: 0x1992134 VA: 0x1992134
		private void SetLevel(int level, bool is6LineMode)
		{
			m_stringBuilder.Set(level.ToString());
			if(is6LineMode)
			{
				m_stringBuilder.Append("+");
			}
			m_textLevel.text = m_stringBuilder.ToString();
		}

		// // RVA: 0x1992240 Offset: 0x1992240 VA: 0x1992240
		private void SetHighScore(int score)
		{
			m_textHighScore.text = MakeFilledValue(score, 8);
		}

		// // RVA: 0x19924BC Offset: 0x19924BC VA: 0x19924BC
		private void SetTitle(string text, GameAttribute.Type attr)
		{
			m_textTitle.text = RichTextUtility.MakeColorTagString(text, GameAttributeTextColor.Colors[(int)attr - 1]);
		}

		// // RVA: 0x19925F8 Offset: 0x19925F8 VA: 0x19925F8
		private void SetSinger(string text)
		{
			m_textSinger.text = text;
		}

		// // RVA: 0x1992284 Offset: 0x1992284 VA: 0x1992284
		private void SetScoreRank(ResultScoreRank.Type scoreRank)
		{
			switch(scoreRank)
			{
				case ResultScoreRank.Type.C:
					m_layoutScoreRankType.StartChildrenAnimGoStop("01");
					break;
				case ResultScoreRank.Type.B:
					m_layoutScoreRankType.StartChildrenAnimGoStop("02");
					break;
				case ResultScoreRank.Type.A:
					m_layoutScoreRankType.StartChildrenAnimGoStop("03");
					break;
				case ResultScoreRank.Type.S:
					m_layoutScoreRankType.StartChildrenAnimGoStop("04");
					break;
				case ResultScoreRank.Type.SS:
					m_layoutScoreRankType.StartChildrenAnimGoStop("05");
					break;
				default:
					Debug.LogError("unexpected RankType : " + scoreRank.ToString());
					break;
				case ResultScoreRank.Type.Illegal:
					m_layoutScoreRankType.StartChildrenAnimGoStop("06");
					break;
			}
		}

		// // RVA: 0x19928B0 Offset: 0x19928B0 VA: 0x19928B0
		private string MakeFilledValue(int value, int length)
		{
			int i4 = 0;
			if(value != 0)
			{
				i4 = 1;
				if(value + 9 > 18)
				{
					int v = value;
					do
					{
						i4++;
						v = v / 10;
					} while(v + 9 > 18);
				}
			}
			m_stringBuilder.Clear();
			if(length - i4 > 0)
			{
				m_stringBuilder.Append('0', length - i4);
				m_stringBuilder.Set(RichTextUtility.MakeColorTagString(m_stringBuilder.ToString(), SystemTextColor.ConservativeColor));
			}
			if(i4 > 0)
			{
				m_stringBuilder.Append(value);
			}
			return m_stringBuilder.ToString();
		}

		// // RVA: 0x1992AB4 Offset: 0x1992AB4 VA: 0x1992AB4
		// private int CalcDigitCount(int value) { }

		// RVA: 0x1992AF0 Offset: 0x1992AF0 VA: 0x1992AF0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_uvManager = uvMan;
			m_layoutMain = layout.FindViewById("sw_sel_me3_music_info_inout_anim") as AbsoluteLayout;
			m_layoutLineIconOnOff = layout.FindViewByExId("sw_sel_me3_music_info_swtexf_sel_me3_icon_rane") as AbsoluteLayout;
			m_layoutBonusIconOnOff = layout.FindViewByExId("sw_sel_me3_btn_c_msc_anim_sw_splive_icon_onoff_anim") as AbsoluteLayout;
			m_layoutExpType = layout.FindViewById("swtbl_s_m_exp_icon") as AbsoluteLayout;
			m_layoutBonusLotsStatusType = layout.FindViewById("sw_sel_me3_bonus_info") as AbsoluteLayout;
			m_layoutButtonUseBonusItem = layout.FindViewById("sw_sel_me3_btn_bns_anim") as AbsoluteLayout;
			m_layoutBonusRateGauge = layout.FindViewById("swfrm_sel_me3_guage_voltage") as AbsoluteLayout;
			m_layoutBonusTextOnOff = layout.FindViewById("swtbl_s_m_bns_icon") as AbsoluteLayout;
			m_layoutPlayButtonType = layout.FindViewById("swtbl_set_deck_btn_play_en") as AbsoluteLayout;
			m_layoutScoreRankType = layout.FindViewById("swtbl_s_m_rank_icon") as AbsoluteLayout;
			m_buttonChangeDiva.AddOnClickCallback(OnClickChangeDivaButton);
			m_buttonChangeMusic.AddOnClickCallback(OnClickChangeMusicButton);
			m_buttonRandomMusic.AddOnClickCallback(OnClickRandomMusicButton);
			m_buttonUseBonusItem.AddOnClickCallback(OnClickUseBonusItemButton);
			m_playButton.AddOnClickCallback(OnClickPlayButton);
			Loaded();
			return true;
		}
	}
}
