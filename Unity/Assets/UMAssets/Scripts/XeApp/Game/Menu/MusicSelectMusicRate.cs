using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace XeApp.Game.Menu
{
	public class MusicSelectMusicRate : LayoutLabelScriptBase
	{
		[SerializeField] // RVA: 0x673BC4 Offset: 0x673BC4 VA: 0x673BC4
		private ActionButton button; // 0x18
		[SerializeField] // RVA: 0x673BD4 Offset: 0x673BD4 VA: 0x673BD4
		private RawImageEx rankImage; // 0x1C
		[SerializeField] // RVA: 0x673BE4 Offset: 0x673BE4 VA: 0x673BE4
		private Text rateText; // 0x20
		private LayoutSymbolData m_rootSymbol; // 0x24
		private bool m_isShow; // 0x28

		public Action onClickButton { private get; set; } // 0x2C

		// // RVA: 0x167C3DC Offset: 0x167C3DC VA: 0x167C3DC
		public void TryEnter()
		{
			if(!m_isShow)
				Enter();
		}

		// // RVA: 0x167C470 Offset: 0x167C470 VA: 0x167C470
		public void TryLeave()
		{
			if(m_isShow)
				Leave();
		}

		// // RVA: 0x167C3EC Offset: 0x167C3EC VA: 0x167C3EC
		public void Enter()
		{
			m_isShow = true;
			m_rootSymbol.StartAnim("enter");
		}

		// // RVA: 0x167C480 Offset: 0x167C480 VA: 0x167C480
		public void Leave()
		{
			m_isShow = false;
			m_rootSymbol.StartAnim("leave");
		}

		// // RVA: 0x167C504 Offset: 0x167C504 VA: 0x167C504
		// public void Show() { }

		// // RVA: 0x167C588 Offset: 0x167C588 VA: 0x167C588
		public void Hide()
		{
			m_isShow = false;
			m_rootSymbol.StartAnim("wait");
		}

		// // RVA: 0x167C60C Offset: 0x167C60C VA: 0x167C60C
		public bool IsPlaying()
		{
			return m_rootSymbol.IsPlaying();
		}

		// // RVA: 0x167C638 Offset: 0x167C638 VA: 0x167C638
		public void ApplyHighScoreRating(HighScoreRatingRank.Type rank, int value)
		{
			SetHighScoreRatingRank(rank);
			SetHighScoreRatingValue(value);
		}

		// // RVA: 0x167C65C Offset: 0x167C65C VA: 0x167C65C
		private void SetHighScoreRatingRank(HighScoreRatingRank.Type rank)
		{
			GameManager.Instance.MusicRatioTextureCache.Load(rank, (IiconTexture texture) =>
			{
				//0x167C928
				(texture as MusicRatioTextureCache.MusicRatioTexture).Set(rankImage, rank);
			});
		}

		// // RVA: 0x167C7BC Offset: 0x167C7BC VA: 0x167C7BC
		private void SetHighScoreRatingValue(int value)
		{
			rateText.text = value.ToString();
		}

		// // RVA: 0x167C818 Offset: 0x167C818 VA: 0x167C818
		private void OnClickButton()
		{
			if(onClickButton != null)
				onClickButton();
		}

		// // RVA: 0x167C82C Offset: 0x167C82C VA: 0x167C82C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			button.AddOnClickCallback(OnClickButton);
			m_rootSymbol = CreateSymbol("main", layout);
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
