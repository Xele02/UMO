using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using CriWare;

namespace XeApp.Game.Menu
{
	public class MusicSelectBattleExGauge : LayoutLabelScriptBase
	{
		[SerializeField]
		private Text m_textWinPoint; // 0x18
		[SerializeField]
		private Text m_textLosePoint; // 0x1C
		[SerializeField]
		private Text m_textValue; // 0x20
		[SerializeField]
		private RawImageEx m_imageClass; // 0x24
		[SerializeField]
		private LayoutBattleExGauge m_layoutGauge; // 0x28
		private LayoutSymbolData m_symbolMain; // 0x2C
		private LayoutSymbolData m_symbolType; // 0x30
		private CriAtomExPlayback m_countUpSEPlayback; // 0x34
		private bool m_isShow; // 0x38

		// RVA: 0x1667338 Offset: 0x1667338 VA: 0x1667338
		private void OnDisable()
		{
			m_countUpSEPlayback.Stop(false);
		}

		// // RVA: 0x1667350 Offset: 0x1667350 VA: 0x1667350
		public void Setup(int emblemId, int win, int lose, int now, int max)
		{
			SetClass(emblemId);
			SetWinPoint(win);
			SetLosePoint(lose);
			if(now < max)
			{
				m_symbolType.StartAnim("normal");
				SetGaugeValue(now, max);
			}
			else
			{
				m_symbolType.StartAnim("max");
				SetGaugeValue(max, max);
				now = max;
			}
			m_layoutGauge.Setup(now, max, 0);
		}

		// RVA: 0x1667838 Offset: 0x1667838 VA: 0x1667838
		public void TryEnter()
		{
			if(!m_isShow)
				Enter();
		}

		// RVA: 0x16678CC Offset: 0x16678CC VA: 0x16678CC
		public void TryLeave()
		{
			if(m_isShow)
				Leave();
		}

		// // RVA: 0x1667848 Offset: 0x1667848 VA: 0x1667848
		public void Enter()
		{
			m_isShow = true;
			m_symbolMain.StartAnim("enter");
		}

		// // RVA: 0x16678DC Offset: 0x16678DC VA: 0x16678DC
		public void Leave()
		{
			m_isShow = false;
			m_symbolMain.StartAnim("leave");
		}

		// // RVA: 0x1667960 Offset: 0x1667960 VA: 0x1667960
		// public void Show() { }

		// // RVA: 0x16679E4 Offset: 0x16679E4 VA: 0x16679E4
		public void Hide()
		{
			m_isShow = false;
			m_symbolMain.StartAnim("wait");
		}

		// RVA: 0x1667A68 Offset: 0x1667A68 VA: 0x1667A68
		public bool IsPlaying()
		{
			return m_symbolMain.IsPlaying();
		}

		// // RVA: 0x16674A8 Offset: 0x16674A8 VA: 0x16674A8
		private void SetClass(int emblemId)
		{
			m_imageClass.enabled = false;
			GameManager.Instance.ItemTextureCache.LoadEmblem(emblemId, (IiconTexture icon) =>
			{
				//0x1667D0C
				m_imageClass.enabled = true;
				icon.Set(m_imageClass);
			});
		}

		// // RVA: 0x166775C Offset: 0x166775C VA: 0x166775C
		private void SetGaugeValue(int now, int max)
		{
			m_textValue.text = now + "/" + max;
		}

		// // RVA: 0x16675DC Offset: 0x16675DC VA: 0x16675DC
		private void SetWinPoint(int value)
		{
			m_textWinPoint.text = "WIN " + value.ToString("+#;-#;");
		}

		// // RVA: 0x166769C Offset: 0x166769C VA: 0x166769C
		private void SetLosePoint(int value)
		{
			m_textLosePoint.text = "LOSE " + value.ToString("+#;-#;");
		}

		// // RVA: 0x1667A94 Offset: 0x1667A94 VA: 0x1667A94
		// private void PlayCountUpLoopSE() { }

		// // RVA: 0x1667344 Offset: 0x1667344 VA: 0x1667344
		// private void StopCountUpLoopSE() { }

		// RVA: 0x1667AF4 Offset: 0x1667AF4 VA: 0x1667AF4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutGauge.layoutMain = layout.FindViewByExId("swfrm_exgauge_ga_col") as AbsoluteLayout;
			m_layoutGauge.layoutDiff = layout.FindViewByExId("swfrm_exgauge_ga_col_ef") as AbsoluteLayout;
			m_symbolMain = CreateSymbol("main", layout);
			m_symbolType = CreateSymbol("type", layout);
			m_symbolMain.StartAnim("wait");
			Loaded();
			return true;
		}

		// [CompilerGeneratedAttribute] // RVA: 0x6EECA4 Offset: 0x6EECA4 VA: 0x6EECA4
		// // RVA: 0x1667D0C Offset: 0x1667D0C VA: 0x1667D0C
		// private void <SetClass>b__18_0(IiconTexture icon) { }
	}
}
