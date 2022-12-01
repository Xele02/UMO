using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class GuestListElem : GeneralListElemBase
	{
		public enum SkillMask
		{
			None = 0,
			MisMatchSeries = 1,
			MisMatchAttr = 2,
		}

		public const int InvokeId_Select = 0;
		public const int InvokeId_Profile = 1;
		[SerializeField]
		private RawImageEx m_divaIconImage; // 0x18
		[SerializeField]
		private RawImageEx m_sceneIconImage; // 0x1C
		[SerializeField]
		private RawImageEx m_skillRankImage; // 0x20
		[SerializeField]
		private RawImageEx m_musicRatioIconImage; // 0x24
		[SerializeField]
		private Text m_nameText; // 0x28
		[SerializeField]
		private Text m_levelText; // 0x2C
		[SerializeField]
		private Text m_totalText; // 0x30
		[SerializeField]
		private Text m_lifeText; // 0x34
		[SerializeField]
		private Text m_luckText; // 0x38
		[SerializeField]
		private Text m_skillText; // 0x3C
		[SerializeField]
		private Text m_skillLevelText; // 0x40
		[SerializeField]
		private Text m_supportText; // 0x44
		[SerializeField]
		private Text m_foldText; // 0x48
		[SerializeField]
		private Text m_soulText; // 0x4C
		[SerializeField]
		private Text m_voiceText; // 0x50
		[SerializeField]
		private Text m_charmText; // 0x54
		[SerializeField]
		private Text m_musicRatioText; // 0x58
		[SerializeField]
		private Text m_musicRateRankText; // 0x5C
		[SerializeField]
		private ScrollListButton m_selectButton; // 0x60
		[SerializeField]
		private ButtonBase m_profileButton; // 0x64
		private LayoutSymbolData m_symbolStatus; // 0x68
		private LayoutSymbolData m_symbolButtonType; // 0x6C
		private LayoutSymbolData m_symbolPlayerRank; // 0x70
		private AbsoluteLayout m_layoutSkillMask; // 0x74
		private Matrix23 m_identity; // 0x78
		private bool m_statusIsTotal; // 0x90
		private bool m_isKira; // 0x91

		private Func<IiconTexture> divaIconDelegate { get; set; } // 0x94
		private Func<IiconTexture> sceneIconDelegate { get; set; } // 0x98
		//private DivaIconTextureCache divaTexCache { get; } 0xE2732C
		//private SceneIconTextureCache sceneTexCache { get; } 0xE273C8
		public ScrollListButton Button { get { return m_selectButton; } } //0xE27464

		// RVA: 0xE2746C Offset: 0xE2746C VA: 0xE2746C
		private void Update()
		{
			if(divaIconDelegate != null)
			{
				IiconTexture tex = divaIconDelegate();
				if (tex != null)
				{
					SetDivaIcon(tex);
					divaIconDelegate = null;
				}
			}
			if(sceneIconDelegate != null)
			{
				IiconTexture tex = sceneIconDelegate();
				if(tex != null)
				{
					SetSceneIcon(tex, m_isKira);
					sceneIconDelegate = null;
				}
			}
		}

		//// RVA: 0xE27758 Offset: 0xE27758 VA: 0xE27758
		//public void SetupButton(ScrollRect scrollRect, Action onClick) { }

		//// RVA: 0xE2775C Offset: 0xE2775C VA: 0xE2775C
		public void SwapStatus(bool immediate = false)
		{
			ChangeStatus(!m_statusIsTotal, immediate);
		}

		//// RVA: 0xE27774 Offset: 0xE27774 VA: 0xE27774
		public void ChangeStatus(bool toTotal, bool immediate = false)
		{
			TodoLogger.Log(0, "ChangeStatus");
		}

		//// RVA: 0xE27830 Offset: 0xE27830 VA: 0xE27830
		public void ToggleMusicRatio(SortItem sortItem)
		{
			m_symbolPlayerRank.GoToFrame("rank", sortItem == SortItem.HighScoreRating ? 1 : 0);
		}

		//// RVA: 0xE278C4 Offset: 0xE278C4 VA: 0xE278C4
		//public bool IsPlayingStatus() { }

		//// RVA: 0xE278F0 Offset: 0xE278F0 VA: 0xE278F0
		public GameObject GetDivaIconObject()
		{
			return m_divaIconImage.gameObject;
		}

		//// RVA: 0xE2791C Offset: 0xE2791C VA: 0xE2791C
		public GameObject GetSceneIconObject()
		{
			return m_sceneIconImage.gameObject;
		}

		//// RVA: 0xE27948 Offset: 0xE27948 VA: 0xE27948
		public void SetDivaIconDelegate(Func<IiconTexture> iconDelegate)
		{
			divaIconDelegate = iconDelegate;
			if (iconDelegate == null)
				return;
			IiconTexture tex = iconDelegate();
			if (tex != null)
			{
				SetDivaIcon(tex);
				divaIconDelegate = null;
				return;
			}
			GameManager.Instance.DivaIconCache.SetLoadingIcon(m_divaIconImage);
		}

		//// RVA: 0xE27A58 Offset: 0xE27A58 VA: 0xE27A58
		public void SetSceneIconDelegate(Func<IiconTexture> iconDelegate)
		{
			sceneIconDelegate = iconDelegate;
			if (iconDelegate == null)
				return;
			IiconTexture tex = iconDelegate();
			if(tex != null)
			{
				SetSceneIcon(tex, m_isKira);
				sceneIconDelegate = null;
				return;
			}
			GameManager.Instance.SceneIconCache.SetLoadingTexture(m_sceneIconImage);
		}

		//// RVA: 0xE27534 Offset: 0xE27534 VA: 0xE27534
		public void SetDivaIcon(IiconTexture iconTex)
		{
			iconTex.Set(m_divaIconImage);
		}

		//// RVA: 0xE27614 Offset: 0xE27614 VA: 0xE27614
		public void SetSceneIcon(IiconTexture iconTex, bool isKira)
		{
			iconTex.Set(m_sceneIconImage);
			SceneIconTextureCache.ChangeKiraMaterial(m_sceneIconImage, iconTex as IconTexture, isKira);
		}

		//// RVA: 0xE27B6C Offset: 0xE27B6C VA: 0xE27B6C
		public void SetName(string name)
		{
			m_nameText.text = name;
		}

		//// RVA: 0xE27BA8 Offset: 0xE27BA8 VA: 0xE27BA8
		public void SetLevel(string level)
		{
			m_levelText.text = level;
		}

		//// RVA: 0xE27BE4 Offset: 0xE27BE4 VA: 0xE27BE4
		public void SetTotal(string total)
		{
			m_totalText.text = total;
		}

		//// RVA: 0xE27C20 Offset: 0xE27C20 VA: 0xE27C20
		public void SetLife(string life)
		{
			m_lifeText.text = life;
		}

		//// RVA: 0xE27C5C Offset: 0xE27C5C VA: 0xE27C5C
		public void SetLuck(string luck)
		{
			m_luckText.text = luck;
		}

		//// RVA: 0xE27C98 Offset: 0xE27C98 VA: 0xE27C98
		public void SetSkill(string skill)
		{
			if(string.IsNullOrEmpty(skill))
			{
				UnitWindowConstant.SetInvalidText(m_skillText, TextAnchor.MiddleCenter);
				return;
			}
			m_skillText.alignment = TextAnchor.MiddleLeft;
			m_skillText.text = skill;
		}

		//// RVA: 0xE27D8C Offset: 0xE27D8C VA: 0xE27D8C
		public void SetSkillLevel(int level)
		{
			if (level > 0)
			{
				m_skillLevelText.text = level.ToString();
			}
			else
				m_skillLevelText.text = "";
		}

		//// RVA: 0xE27E90 Offset: 0xE27E90 VA: 0xE27E90
		public void SetSkillRank(SkillRank.Type rank)
		{
			GameManager.Instance.UnionTextureManager.SetImageSkillRank(m_skillRankImage, rank);
		}

		//// RVA: 0xE27F60 Offset: 0xE27F60 VA: 0xE27F60
		public void SetSkillMask(SkillMask mask)
		{
			if(mask == SkillMask.MisMatchSeries)
			{
				m_layoutSkillMask.StartChildrenAnimGoStop("01");
			}
			else if(mask == SkillMask.MisMatchAttr)
			{
				m_layoutSkillMask.StartChildrenAnimGoStop("03");
			}
			else
			{
				m_layoutSkillMask.StartChildrenAnimGoStop("02");
			}
			m_layoutSkillMask.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
			m_layoutSkillMask.UpdateAll(m_identity, Color.white);
		}

		//// RVA: 0xE280FC Offset: 0xE280FC VA: 0xE280FC
		public void SetSupport(string support)
		{
			m_supportText.text = support;
		}

		//// RVA: 0xE28138 Offset: 0xE28138 VA: 0xE28138
		public void SetFold(string fold)
		{
			m_foldText.text = fold;
		}

		//// RVA: 0xE28174 Offset: 0xE28174 VA: 0xE28174
		public void SetSoul(string soul)
		{
			m_soulText.text = soul;
		}

		//// RVA: 0xE281B0 Offset: 0xE281B0 VA: 0xE281B0
		public void SetVoice(string voice)
		{
			m_voiceText.text = voice;
		}

		//// RVA: 0xE281EC Offset: 0xE281EC VA: 0xE281EC
		public void SetCharm(string charm)
		{
			m_charmText.text = charm;
		}

		//// RVA: 0xE28228 Offset: 0xE28228 VA: 0xE28228
		public void SetMusicRatio(string ratio)
		{
			m_musicRatioText.text = ratio;
		}

		//// RVA: 0xE28264 Offset: 0xE28264 VA: 0xE28264
		public void SetMusicRank(HighScoreRatingRank.Type rank)
		{
			GameManager.Instance.MusicRatioTextureCache.Load(rank, (IiconTexture texture) =>
			{
				//0xE28750
				if(texture != null)
				{
					(texture as MusicRatioTextureCache.MusicRatioTexture).Set(m_musicRatioIconImage, rank);
				}
			});
		}

		//// RVA: 0xE283CC Offset: 0xE283CC VA: 0xE283CC
		public void SetMusicRateRank(IBIGBMDANNM a_friend_data)
		{
			m_musicRateRankText.text = OEGIPPCADNA.GEEFFAEGHAH(OEGIPPCADNA.BFKAHKBKBJE(a_friend_data.AHEFHIMGIBI_ServerData.MHEAEGMIKIE_PublicStatus.AILEOFKIELL_UtaRateRank, a_friend_data.AJECHDLMKOE_LastLogin), true);
		}

		//// RVA: 0xE284A8 Offset: 0xE284A8 VA: 0xE284A8
		public void SetKira(bool isKira)
		{
			m_isKira = isKira;
		}

		//// RVA: 0xE284B0 Offset: 0xE284B0 VA: 0xE284B0
		private void OnClickSelectCallback()
		{
			InvokeSelectItem(0);
		}

		//// RVA: 0xE284BC Offset: 0xE284BC VA: 0xE284BC
		private void OnClickProfileCallback()
		{
			TodoLogger.Log(0, "OnClickProfileCallback");
		}

		// RVA: 0xE284C8 Offset: 0xE284C8 VA: 0xE284C8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_selectButton.ClearLoadedCallback();
			m_selectButton.AddOnClickCallback(this.OnClickSelectCallback);
			m_profileButton.ClearLoadedCallback();
			m_profileButton.AddOnClickCallback(this.OnClickProfileCallback);
			m_symbolStatus = CreateSymbol("status", layout);
			m_symbolButtonType = CreateSymbol("btn_type", layout);
			m_symbolPlayerRank = CreateSymbol("rank", layout);
			m_layoutSkillMask = layout.FindViewById("swtbl_sel_list_series_limit_fnt") as AbsoluteLayout;
			m_layoutSkillMask.StartChildrenAnimGoStop("02");
			Loaded();
			return true;
		}
	}
}
