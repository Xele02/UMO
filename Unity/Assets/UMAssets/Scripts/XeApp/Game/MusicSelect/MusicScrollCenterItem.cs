using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using TMPro;
using XeSys.Gfx;
using System;

namespace XeApp.Game.MusicSelect
{
	public class MusicScrollCenterItem : MonoBehaviour
	{
		//[HeaderAttribute] // RVA: 0x665A54 Offset: 0x665A54 VA: 0x665A54
		[SerializeField]
		private Text m_musicName; // 0xC
		//[HeaderAttribute] // RVA: 0x665A9C Offset: 0x665A9C VA: 0x665A9C
		[SerializeField]
		private Text m_singerNameText; // 0x10
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x665AE8 Offset: 0x665AE8 VA: 0x665AE8
		private UGUIButton m_rewardButton; // 0x14
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x665B30 Offset: 0x665B30 VA: 0x665B30
		private UGUIButton m_rankingButton; // 0x18
		//[HeaderAttribute] // RVA: 0x665B78 Offset: 0x665B78 VA: 0x665B78
		[SerializeField]
		private UGUIButton m_musicInfoButton; // 0x1C
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x665BD0 Offset: 0x665BD0 VA: 0x665BD0
		private UGUIButton m_enemyInfoButton; // 0x20
		[SerializeField]
		private XeSys.Gfx.ScrollText m_musicNameScroll; // 0x24
		[SerializeField]
		private XeSys.Gfx.ScrollText m_singerNameScroll; // 0x28
		[SerializeField]
		private XeSys.Gfx.ScrollText m_eventNameScroll; // 0x2C
		[SerializeField]
		private XeSys.Gfx.ScrollText m_eventDescScroll; // 0x30
		[SerializeField]
		private Image m_newIcon; // 0x34
		[SerializeField]
		private TextMeshProUGUI m_musicListNo; // 0x38
		[SerializeField]
		private MusicScrollItemLabelGroup m_labelGroup; // 0x3C
		[SerializeField]
		private RawImageEx m_seriesLogo; // 0x40
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x665CA4 Offset: 0x665CA4 VA: 0x665CA4
		private Image m_attrIcon; // 0x44
		[SerializeField]
		private MusicAttrIconScriptableObject m_attrIconSet; // 0x48
		//[HeaderAttribute] // RVA: 0x665CFC Offset: 0x665CFC VA: 0x665CFC
		[SerializeField]
		private Image m_attrBack; // 0x4C
		[SerializeField]
		private MusicAttrIconScriptableObject m_attrBackSet; // 0x50
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x665D5C Offset: 0x665D5C VA: 0x665D5C
		private Image m_attrArrow; // 0x54
		[SerializeField]
		private MusicAttrIconScriptableObject m_attrArrowSet; // 0x58
		//[HeaderAttribute] // RVA: 0x665DBC Offset: 0x665DBC VA: 0x665DBC
		[SerializeField]
		private CanvasGroup m_lockObj; // 0x5C
		[SerializeField]
		private Image m_unlockableImage; // 0x60
		//[HeaderAttribute] // RVA: 0x665E14 Offset: 0x665E14 VA: 0x665E14
		[SerializeField]
		private CanvasGroup m_rewardObj; // 0x64
		[SerializeField]
		private Image m_scoreReward; // 0x68
		[SerializeField]
		private Image m_comboReward; // 0x6C
		[SerializeField]
		private Image m_clearCountReward; // 0x70
		//[HeaderAttribute] // RVA: 0x665E8C Offset: 0x665E8C VA: 0x665E8C
		[SerializeField]
		private Text m_eventName; // 0x74
		[SerializeField]
		private Text m_eventDesc; // 0x78
		[SerializeField]
		private Text m_eventPeriod; // 0x7C
		//[HeaderAttribute] // RVA: 0x665EF4 Offset: 0x665EF4 VA: 0x665EF4
		[SerializeField]
		private CanvasGroup m_highLevelObj; // 0x80
		[SerializeField]
		private Text m_highLevelMusicName; // 0x84
		[SerializeField]
		private Text m_highLevelSingerName; // 0x88
		[SerializeField]
		private XeSys.Gfx.ScrollText m_highLevelMusicNameScroll; // 0x8C
		[SerializeField]
		private XeSys.Gfx.ScrollText m_highLevelSingerNameScroll; // 0x90
		//private StringBuilder m_musicNumSb = new StringBuilder(); // 0xA4
		//private string m_musicNumSign = " / "; // 0xA8

		//public MusicScrollItemLabelGroup LabelGroup { get; } 0xC9C80C
		public Action OnRewardButtonClickListener { private get; set; } // 0x94
		public Action OnRankingButtonClickListener { private get; set; } // 0x98
		public Action OnMusicInfoButtonClickListener { private get; set; } // 0x9C
		//public Action OnEnemyInfoButtonClickListener { private get; set; } // 0xA0

		//// RVA: 0xC9C854 Offset: 0xC9C854 VA: 0xC9C854
		private void Awake()
		{
			UnityEngine.Debug.LogError("TODO MusicScrollCenterItem Awake");
		}

		//// RVA: 0xC9CA90 Offset: 0xC9CA90 VA: 0xC9CA90
		//public void ResetScroll() { }

		//// RVA: 0xC9CB60 Offset: 0xC9CB60 VA: 0xC9CB60
		//public void SetSeries(int logoType) { }

		//// RVA: 0xC9CC78 Offset: 0xC9CC78 VA: 0xC9CC78
		public void SetTitle(string title)
		{
			m_musicName.text = title;
		}

		//// RVA: 0xC9CCB4 Offset: 0xC9CCB4 VA: 0xC9CCB4
		public void SetHighLevelMusicTitle(string title)
		{
			m_highLevelMusicName.text = title;
		}

		//// RVA: 0xC9CCF0 Offset: 0xC9CCF0 VA: 0xC9CCF0
		//public void SetEventName(string text) { }

		//// RVA: 0xC9CD2C Offset: 0xC9CD2C VA: 0xC9CD2C
		//public void SetEventDescription(string text) { }

		//// RVA: 0xC9CD68 Offset: 0xC9CD68 VA: 0xC9CD68
		//public void SetEventPeriod(string text) { }

		//// RVA: 0xC9CDA4 Offset: 0xC9CDA4 VA: 0xC9CDA4
		//public void SetLockIcon(bool isOpen, bool isUnlockable) { }

		//// RVA: 0xC9CE7C Offset: 0xC9CE7C VA: 0xC9CE7C
		//public void SetNewIcon(bool isNew) { }

		//// RVA: 0xC9CEB0 Offset: 0xC9CEB0 VA: 0xC9CEB0
		//public void SetAttribute(int attr) { }

		//// RVA: 0xC9D090 Offset: 0xC9D090 VA: 0xC9D090
		//public void SetRewardState(bool score, bool combo, bool clearCount) { }

		//// RVA: 0xC9D118 Offset: 0xC9D118 VA: 0xC9D118
		//public void SetMusicNo(int index, int count) { }

		//// RVA: 0xC9D210 Offset: 0xC9D210 VA: 0xC9D210
		//public void SetSingerName(string singerName) { }

		//// RVA: 0xC9D24C Offset: 0xC9D24C VA: 0xC9D24C
		//public void SetHighLevelSingerName(string singerName) { }

		//// RVA: 0xC9D288 Offset: 0xC9D288 VA: 0xC9D288
		//public void SetRankingButton(bool isEnable) { }

		//// RVA: 0xC9D2DC Offset: 0xC9D2DC VA: 0xC9D2DC
		//public void SetListType(MusicScrollCenterItem.ListType listType) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6B4A98 Offset: 0x6B4A98 VA: 0x6B4A98
		//// RVA: 0xC9DCDC Offset: 0xC9DCDC VA: 0xC9DCDC
		//private void <Awake>b__55_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6B4AA8 Offset: 0x6B4AA8 VA: 0x6B4AA8
		//// RVA: 0xC9DCF0 Offset: 0xC9DCF0 VA: 0xC9DCF0
		//private void <Awake>b__55_1() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6B4AB8 Offset: 0x6B4AB8 VA: 0x6B4AB8
		//// RVA: 0xC9DD04 Offset: 0xC9DD04 VA: 0xC9DD04
		//private void <Awake>b__55_2() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6B4AC8 Offset: 0x6B4AC8 VA: 0x6B4AC8
		//// RVA: 0xC9DD18 Offset: 0xC9DD18 VA: 0xC9DD18
		//private void <Awake>b__55_3() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6B4AD8 Offset: 0x6B4AD8 VA: 0x6B4AD8
		//// RVA: 0xC9DD2C Offset: 0xC9DD2C VA: 0xC9DD2C
		//private void <SetSeries>b__57_0(IiconTexture texture) { }
	}
}
