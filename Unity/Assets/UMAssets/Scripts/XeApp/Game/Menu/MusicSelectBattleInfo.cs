using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using System.Collections.Generic;
using System;

namespace XeApp.Game.Menu
{
	public class MusicSelectBattleInfo : LayoutLabelScriptBase
	{
		public enum PlayButtonType
		{
			PlayEn = 0,
			Play = 1,
			Download = 2,
		}

		public enum RivalRankType
		{
			B = 0,
			A = 1,
			S = 2,
			EX = 3,
			_Num = 4,
		}

		[SerializeField]
		private MusicSelectPlayButton m_playButton; // 0x18
		[SerializeField]
		private RawImageEx m_dropItemIcon; // 0x1C
		[SerializeField]
		private Text m_selfPlayerTitle; // 0x20
		[SerializeField]
		private Text m_rivalPlayerTitle; // 0x24
		[SerializeField]
		private RawImageEx m_selfDivaIcon; // 0x28
		[SerializeField]
		private RawImageEx m_rivalDivaIcon; // 0x2C
		[SerializeField]
		private RawImageEx m_selfSceneIcon; // 0x30
		[SerializeField]
		private RawImageEx m_rivalSceneIcon; // 0x34
		[SerializeField]
		private RawImageEx m_rivalRankIcon; // 0x38
		[SerializeField]
		private NumberBase m_rivalScore; // 0x3C
		private LayoutSymbolData m_symbolMain; // 0x40
		private LayoutSymbolData m_symbolPlayButtonType; // 0x44
		private LayoutSymbolData m_symbolDropItemInfo; // 0x48
		private List<Rect> m_rankIconUvList; // 0x4C
		private bool m_isShow; // 0x54

		public Action onClickPlayButton { private get; set; } // 0x50

		// RVA: 0x1667E20 Offset: 0x1667E20 VA: 0x1667E20
		public void TryEnter()
		{
			if(!m_isShow)
				Enter();
		}

		// RVA: 0x1667EB4 Offset: 0x1667EB4 VA: 0x1667EB4
		public void TryLeave()
		{
			if(m_isShow)
				Leave();
		}

		// // RVA: 0x1667E30 Offset: 0x1667E30 VA: 0x1667E30
		public void Enter()
		{
			m_isShow = true;
			m_symbolMain.StartAnim("enter");
		}

		// // RVA: 0x1667EC4 Offset: 0x1667EC4 VA: 0x1667EC4
		public void Leave()
		{
			m_isShow = false;
			m_symbolMain.StartAnim("leave");
		}

		// // RVA: 0x1667F48 Offset: 0x1667F48 VA: 0x1667F48
		// public void Show() { }

		// // RVA: 0x1667FCC Offset: 0x1667FCC VA: 0x1667FCC
		public void Hide()
		{
			m_isShow = false;
			m_symbolMain.StartAnim("wait");
		}

		// RVA: 0x1668050 Offset: 0x1668050 VA: 0x1668050
		public bool IsPlaying()
		{
			return m_symbolMain.IsPlaying();
		}

		// // RVA: 0x166807C Offset: 0x166807C VA: 0x166807C
		public void SetPlayButtonType(PlayButtonType type)
		{
			if(type == PlayButtonType.Download)
			{
				m_symbolPlayButtonType.StartAnim("dl");
				m_playButton.SetDLMessage(true);
			}
			else if(type == PlayButtonType.Play)
			{
				m_symbolPlayButtonType.StartAnim("play");
				m_playButton.SetDLMessage(false);
			}
			else if(type == PlayButtonType.PlayEn)
			{
				m_symbolPlayButtonType.StartAnim("play_en");
				m_playButton.SetDLMessage(false);
			}
			else
			{
				m_symbolPlayButtonType.StartAnim("");
				m_playButton.SetDLMessage(false);
			}
		}

		// // RVA: 0x16681AC Offset: 0x16681AC VA: 0x16681AC
		public void SetPlayButtonDisable(bool isDisable)
		{
			m_playButton.Disable = isDisable;
		}

		// // RVA: 0x16681E0 Offset: 0x16681E0 VA: 0x16681E0
		public void SetNeedEnergy(int energy)
		{
			m_playButton.SetNeedEnergy(energy);
		}

		// // RVA: 0x16682D8 Offset: 0x16682D8 VA: 0x16682D8
		public void SetDropIconType(bool enable)
		{
			m_symbolDropItemInfo.StartAnim(enable ? "drop" : "none" );
		}

		// // RVA: 0x1668370 Offset: 0x1668370 VA: 0x1668370
		public void ApplySelfTitle(string title)
		{
			m_selfPlayerTitle.text = title;
		}

		// // RVA: 0x16683AC Offset: 0x16683AC VA: 0x16683AC
		public void ApplySelfDivaIcon(IiconTexture iconTex)
		{
			iconTex.Set(m_selfDivaIcon);
		}

		// // RVA: 0x166848C Offset: 0x166848C VA: 0x166848C
		public void ApplySelfSceneIcon(IiconTexture iconTex, bool isKira)
		{
			iconTex.Set(m_selfSceneIcon);
			SceneIconTextureCache.ChangeKiraMaterial(m_selfSceneIcon, iconTex as IconTexture, isKira);
		}

		// // RVA: 0x16685D0 Offset: 0x16685D0 VA: 0x16685D0
		public GameObject GetSelfDivaIconObject()
		{
			return m_selfDivaIcon.gameObject;
		}

		// // RVA: 0x16685FC Offset: 0x16685FC VA: 0x16685FC
		public GameObject GetSelfSceneIconObject()
		{
			return m_selfSceneIcon.gameObject;
		}

		// // RVA: 0x1668628 Offset: 0x1668628 VA: 0x1668628
		public void ApplyRivalRank(RivalRankType type)
		{
			m_rivalRankIcon.uvRect = m_rankIconUvList[(int)type];
		}

		// // RVA: 0x16686E4 Offset: 0x16686E4 VA: 0x16686E4
		public void ApplyRivalTitle(string title)
		{
			m_rivalPlayerTitle.text = title;
		}

		// // RVA: 0x1668720 Offset: 0x1668720 VA: 0x1668720
		public void ApplyRivalScore(int score)
		{
			m_rivalScore.SetNumber(Mathf.Max(0, score), 0);
		}

		// // RVA: 0x16687E0 Offset: 0x16687E0 VA: 0x16687E0
		public void ApplyRivalDivaIcon(IiconTexture iconTex)
		{
			iconTex.Set(m_rivalDivaIcon);
		}

		// // RVA: 0x16688C0 Offset: 0x16688C0 VA: 0x16688C0
		public void ApplyRivalSceneIcon(IiconTexture iconTex, bool isKira)
		{
			iconTex.Set(m_rivalSceneIcon);
			SceneIconTextureCache.ChangeKiraMaterial(m_rivalSceneIcon, iconTex as IconTexture, isKira);
		}

		// // RVA: 0x1668A04 Offset: 0x1668A04 VA: 0x1668A04
		public void ApplyDropItemIcon(IiconTexture iconTex)
		{
			iconTex.Set(m_dropItemIcon);
		}

		// // RVA: 0x1668AE4 Offset: 0x1668AE4 VA: 0x1668AE4
		public GameObject GetRivalDivaIconObject()
		{
			return m_rivalDivaIcon.gameObject;
		}

		// // RVA: 0x1668B10 Offset: 0x1668B10 VA: 0x1668B10
		public GameObject GetRivalSceneIconObject()
		{
			return m_rivalSceneIcon.gameObject;
		}

		// RVA: 0x1668B3C Offset: 0x1668B3C VA: 0x1668B3C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_symbolMain = CreateSymbol("main", layout);
			m_symbolPlayButtonType = CreateSymbol("btn_play_type", layout);
			m_symbolDropItemInfo = CreateSymbol("drop_info", layout);
			m_symbolDropItemInfo.StartAnim("none");
			m_rankIconUvList = new List<Rect>();
			for(int i = 1; i < 5; i++)
			{
				m_rankIconUvList.Add(LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData(string.Format("sel_music_btl_rival_{0:D2}", i))));
			}
			m_playButton.ClearOnClickCallback();
			m_playButton.AddOnClickCallback(() =>
			{
				//0x1668E10
				if(onClickPlayButton != null)
					onClickPlayButton();
			});
			Loaded();
			return true;
		}
	}
}
