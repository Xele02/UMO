using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class SetDeckMusicInfo : MonoBehaviour
	{
		public enum BottomType
		{
			None = 0,
			ExpectedScoreGauge = 1,
			Description = 2,
		}

		public enum PosType
		{
			Normal = 0,
			SLive = 1,
		}

		// [HeaderAttribute] // RVA: 0x681978 Offset: 0x681978 VA: 0x681978
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x681978 Offset: 0x681978 VA: 0x681978
		private InOutAnime m_inOut; // 0xC
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x6819E8 Offset: 0x6819E8 VA: 0x6819E8
		private UGUIPositionTable m_posTable; // 0x10
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x681A30 Offset: 0x681A30 VA: 0x681A30
		private Image m_musicAttrImage; // 0x14
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x681A90 Offset: 0x681A90 VA: 0x681A90
		private Image m_musicAttrEffectImage; // 0x18
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x681B00 Offset: 0x681B00 VA: 0x681B00
		private SpriteAnime m_musicAttrEffectAnime; // 0x1C
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x681B48 Offset: 0x681B48 VA: 0x681B48
		private Image m_difficultyImage; // 0x20
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x681B98 Offset: 0x681B98 VA: 0x681B98
		private Text m_musicNameText; // 0x24
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x681BE0 Offset: 0x681BE0 VA: 0x681BE0
		private GameObject m_expectedScoreGaugeObject; // 0x28
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x681C4C Offset: 0x681C4C VA: 0x681C4C
		private SetDeckExpectedScoreGauge m_expectedScoreGauge; // 0x2C
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x681CAC Offset: 0x681CAC VA: 0x681CAC
		private UGUIButton m_expectedScoreDescButton; // 0x30
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x681D0C Offset: 0x681D0C VA: 0x681D0C
		private GameObject m_descriptionObject; // 0x34
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x681D68 Offset: 0x681D68 VA: 0x681D68
		private Text m_descriptionText; // 0x38
		// [TooltipAttribute] // RVA: 0x681DC0 Offset: 0x681DC0 VA: 0x681DC0
		[SerializeField]
		private ScrollText m_descriptionScroll; // 0x3C
		// [HeaderAttribute] // RVA: 0x681E2C Offset: 0x681E2C VA: 0x681E2C
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x681E2C Offset: 0x681E2C VA: 0x681E2C
		private MusicAttrIconScriptableObject m_musicAttrSprites; // 0x40
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x681EC0 Offset: 0x681EC0 VA: 0x681EC0
		private MusicAttrIconScriptableObject m_musicAttrEffectSprites; // 0x44
		// [TooltipAttribute] // RVA: 0x681F3C Offset: 0x681F3C VA: 0x681F3C
		[SerializeField]
		private List<Sprite> m_difficultySprites; // 0x48
		// [TooltipAttribute] // RVA: 0x681F98 Offset: 0x681F98 VA: 0x681F98
		[SerializeField]
		private List<Sprite> m_difficulty6LineSprites; // 0x4C
		// public Action OnClickExpectedScoreDescButton; // 0x50

		public InOutAnime InOut { get { return m_inOut; } } //0xA6F6B0
		// public SetDeckExpectedScoreGauge ExpectedScoreGauge { get; } 0xA6F6B8

		// // RVA: 0xA6F6C0 Offset: 0xA6F6C0 VA: 0xA6F6C0
		private void Awake()
		{
			TodoLogger.Log(0, "SetDeckMusicInfo Awake");
		}

		// // RVA: 0xA6F828 Offset: 0xA6F828 VA: 0xA6F828
		public void Set(EEDKAACNBBG viewMusicData, GameSetupData.MusicInfo musicInfo, bool isMvMode, SetDeckMusicInfo.BottomType bottomType)
		{
			TodoLogger.Log(0, "Music Info Set");
			m_musicNameText.text = Database.Instance.musicText.Get(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.INJDLHAEPEK_GetMusicInfo(musicInfo.freeMusicId, musicInfo.musicId).KNMGEEFGDNI_Nam).musicName;
		}

		// // RVA: 0xA6FE7C Offset: 0xA6FE7C VA: 0xA6FE7C
		public void SetPosType(SetDeckMusicInfo.PosType posType)
		{
			TodoLogger.Log(0, "SetPosType");
		}

		// // RVA: 0xA6FEB0 Offset: 0xA6FEB0 VA: 0xA6FEB0
		// public void ReStartMusicAttrAnime() { }

		// // RVA: 0xA6FF34 Offset: 0xA6FF34 VA: 0xA6FF34
		public void ResetDescriptionScroll()
		{
			TodoLogger.Log(0, "ResetDescriptionScroll");
		}

		// // RVA: 0xA6FD80 Offset: 0xA6FD80 VA: 0xA6FD80
		// private Sprite GetMusicAttrSprite(int attr) { }

		// // RVA: 0xA6FDB4 Offset: 0xA6FDB4 VA: 0xA6FDB4
		// private Sprite GetMusicAttrEffectSprite(int attr) { }

		// // RVA: 0xA6FDE8 Offset: 0xA6FDE8 VA: 0xA6FDE8
		// private Sprite GetDifficultySprite(Difficulty.Type difficulty, bool is6Line) { }

		// // RVA: 0xA6F7BC Offset: 0xA6F7BC VA: 0xA6F7BC
		// private void ApplyBottomType(SetDeckMusicInfo.BottomType bottomType) { }

		// [CompilerGeneratedAttribute] // RVA: 0x730CBC Offset: 0x730CBC VA: 0x730CBC
		// // RVA: 0xA6FF68 Offset: 0xA6FF68 VA: 0xA6FF68
		// private void <Awake>b__24_0() { }
	}
}
