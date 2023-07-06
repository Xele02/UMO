using XeSys.Gfx;
using UnityEngine;
using System.Collections.Generic;
using XeApp.Game.Common;
using UnityEngine.UI;
using System;

namespace XeApp.Game.Menu
{
	public class RankingListElemBase : GeneralListElemBase
	{
		public enum StyleType
		{
			Score = 0,
			Point = 1,
			EventHiScore = 2,
			EventExBattleScore = 3,
			Raid = 4,
			DivaEventRanking = 5,
			DivaTotalRanking = 6,
		}

		public const int InvokeId_Profile = 0;
		[SerializeField]
		private RawImageEx m_divaIconImage; // 0x18
		[SerializeField]
		private RawImageEx m_sceneIconImage; // 0x1C
		[SerializeField]
		private RawImageEx m_scoreLabelImage; // 0x20
		[SerializeField]
		private RawImageEx m_pointUnitImage; // 0x24
		[SerializeField]
		private RawImageEx m_musicRatioIconImage; // 0x28
		[SerializeField]
		private List<RawImageEx> m_rankOrderImages; // 0x2C
		[SerializeField]
		private RawImageEx m_rankOrderUnit; // 0x30
		[SerializeField]
		private ButtonBase m_profileButton; // 0x34
		[SerializeField]
		private Text m_nameText; // 0x38
		[SerializeField]
		private Text m_levelText; // 0x3C
		[SerializeField]
		private Text m_scoreText; // 0x40
		[SerializeField]
		private Text m_damageText; // 0x44
		[SerializeField]
		private Text m_rankOrderText; // 0x48
		[SerializeField]
		private Text m_outOfRangeText; // 0x4C
		[SerializeField]
		private Text m_musicRatioText; // 0x50
		[SerializeField]
		private NumberBase m_numberEventHiScore; // 0x54
		private LayoutSymbolData m_symbolRankType; // 0x58
		private AbsoluteLayout m_animStyle_Score; // 0x5C
		private AbsoluteLayout m_animStyle_Total; // 0x60
		private Rect m_scoreLabelUvRect; // 0x64
		private Rect m_pointLabelUvRect; // 0x74
		private bool m_isKira; // 0x84

		private Func<IiconTexture> divaIconDelegate { get; set; } // 0x88
		private Func<IiconTexture> sceneIconDelegate { get; set; } // 0x8C

		// RVA: 0xCF25F0 Offset: 0xCF25F0 VA: 0xCF25F0
		private void Update()
		{
			if(divaIconDelegate != null)
			{
				IiconTexture t = divaIconDelegate();
				if(t != null)
				{
					SetDivaIcon(t);
					divaIconDelegate = null;
				}
			}
			if(sceneIconDelegate != null)
			{
				IiconTexture t = sceneIconDelegate();
				if(t != null)
				{
					SetSceneIcon(t, m_isKira);
					sceneIconDelegate = null;
				}
			}
		}

		//// RVA: 0xCF2974 Offset: 0xCF2974 VA: 0xCF2974
		//public void SetDivaIconDelegate(Func<IiconTexture> iconDelegate, Action<RawImageEx> loadIconSet) { }

		//// RVA: 0xCF2A38 Offset: 0xCF2A38 VA: 0xCF2A38
		//public void SetSceneIconDelegate(Func<IiconTexture> iconDelegate, Action<RawImageEx> loadIconSet) { }

		//// RVA: 0xCF26B8 Offset: 0xCF26B8 VA: 0xCF26B8
		public void SetDivaIcon(IiconTexture iconTex)
		{
			if(m_divaIconImage != null)
			{
				iconTex.Set(m_divaIconImage);
			}
		}

		//// RVA: 0xCF27E0 Offset: 0xCF27E0 VA: 0xCF27E0
		public void SetSceneIcon(IiconTexture iconTex, bool isKira)
		{
			if(m_sceneIconImage != null)
			{
				iconTex.Set(m_sceneIconImage);
				SceneIconTextureCache.ChangeKiraMaterial(m_sceneIconImage, iconTex as IconTexture, isKira);
			}
		}

		//// RVA: 0xCF2AFC Offset: 0xCF2AFC VA: 0xCF2AFC
		public GameObject GetDivaIconObject()
		{
			if (m_divaIconImage != null)
				return m_divaIconImage.gameObject;
			return null;
		}

		//// RVA: 0xCF2BB4 Offset: 0xCF2BB4 VA: 0xCF2BB4
		public GameObject GetSceneIconObject()
		{
			if (m_sceneIconImage != null)
				return m_sceneIconImage.gameObject;
			return null;
		}

		//// RVA: 0xCF2C6C Offset: 0xCF2C6C VA: 0xCF2C6C
		public void SetStyle(StyleType style)
		{
			switch(style)
			{
				case StyleType.Score:
					m_animStyle_Score.StartChildrenAnimGoStop(0, 0);
					m_scoreLabelImage.uvRect = m_scoreLabelUvRect;
					m_pointUnitImage.enabled = false;
					return;
				case StyleType.Point:
					m_animStyle_Score.StartChildrenAnimGoStop(0, 0);
					m_scoreLabelImage.uvRect = m_pointLabelUvRect;
					m_pointUnitImage.enabled = true;
					return;
				case StyleType.EventHiScore:
				case StyleType.DivaEventRanking:
					m_animStyle_Score.StartChildrenAnimGoStop(1, 1);
					break;
				case StyleType.EventExBattleScore:
					m_animStyle_Score.StartChildrenAnimGoStop(2, 2);
					break;
				case StyleType.Raid:
					m_animStyle_Score.StartChildrenAnimGoStop(3, 3);
					break;
				default:
					break;
			}
		}

		//// RVA: 0xCF2E48 Offset: 0xCF2E48 VA: 0xCF2E48
		//public void SetName(string name) { }

		//// RVA: 0xCF2F0C Offset: 0xCF2F0C VA: 0xCF2F0C
		//public void SetLevel(string level) { }

		//// RVA: 0xCF2FD0 Offset: 0xCF2FD0 VA: 0xCF2FD0
		//public void SetScore(string score) { }

		//// RVA: 0xCF3148 Offset: 0xCF3148 VA: 0xCF3148
		//public void SetDamage(string damage) { }

		//// RVA: 0xCF320C Offset: 0xCF320C VA: 0xCF320C
		//public void SetOutOfRange(string text) { }

		//// RVA: 0xCF32D0 Offset: 0xCF32D0 VA: 0xCF32D0
		//public void SetMusicRatio(string ratio) { }

		//// RVA: 0xCF3394 Offset: 0xCF3394 VA: 0xCF3394
		//public void SetRankOrder(int rankOrder) { }

		//// RVA: 0xCF376C Offset: 0xCF376C VA: 0xCF376C
		//public void SetMusicRank(HighScoreRatingRank.Type rank) { }

		//// RVA: 0xCF391C Offset: 0xCF391C VA: 0xCF391C
		//public void SetKira(bool isKira) { }

		// RVA: 0xCF3924 Offset: 0xCF3924 VA: 0xCF3924 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			if(m_profileButton != null)
			{
				m_profileButton.ClearOnClickCallback();
				m_profileButton.AddOnClickCallback(() =>
				{
					//0xCF3CE8
					InvokeSelectItem(0);
				});
			}
			m_animStyle_Score = layout.FindViewById("swtbl_pt_hiscore") as AbsoluteLayout;
			m_animStyle_Total = layout.FindViewById("swtbl_list_cont_icon_rank_mvp") as AbsoluteLayout;
			m_scoreLabelUvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("sel_list_cont_parts03_01"));
			m_pointLabelUvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("sel_list_cont_parts03_02"));
			m_rankOrderText.horizontalOverflow = HorizontalWrapMode.Wrap;
			m_rankOrderText.resizeTextForBestFit = true;
			m_rankOrderText.resizeTextMinSize = 10;
			m_rankOrderText.resizeTextMaxSize = m_rankOrderText.fontSize;
			Loaded();
			return true;
		}
	}
}
