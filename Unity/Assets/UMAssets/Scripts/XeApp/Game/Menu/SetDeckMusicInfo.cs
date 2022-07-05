using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class SetDeckMusicInfo : MonoBehaviour
	{
		[SerializeField]
		private InOutAnime m_inOut;
		[SerializeField]
		private UGUIPositionTable m_posTable;
		[SerializeField]
		private Image m_musicAttrImage;
		[SerializeField]
		private Image m_musicAttrEffectImage;
		[SerializeField]
		private SpriteAnime m_musicAttrEffectAnime;
		[SerializeField]
		private Image m_difficultyImage;
		[SerializeField]
		private Text m_musicNameText;
		[SerializeField]
		private GameObject m_expectedScoreGaugeObject;
		[SerializeField]
		private SetDeckExpectedScoreGauge m_expectedScoreGauge;
		[SerializeField]
		private UGUIButton m_expectedScoreDescButton;
		[SerializeField]
		private GameObject m_descriptionObject;
		[SerializeField]
		private Text m_descriptionText;
		[SerializeField]
		private ScrollText m_descriptionScroll;
		[SerializeField]
		private MusicAttrIconScriptableObject m_musicAttrSprites;
		[SerializeField]
		private MusicAttrIconScriptableObject m_musicAttrEffectSprites;
		[SerializeField]
		private List<Sprite> m_difficultySprites;
		[SerializeField]
		private List<Sprite> m_difficulty6LineSprites;

		// // Namespace: 
		// public enum SetDeckMusicInfo.BottomType // TypeDefIndex: 16430
		// {
		// 	// Fields
		// 	public int value__; // 0x0
		// 	public const SetDeckMusicInfo.BottomType None = 0;
		// 	public const SetDeckMusicInfo.BottomType ExpectedScoreGauge = 1;
		// 	public const SetDeckMusicInfo.BottomType Description = 2;
		// }

		// // Namespace: 
		// public enum SetDeckMusicInfo.PosType // TypeDefIndex: 16431
		// {
		// 	// Fields
		// 	public int value__; // 0x0
		// 	public const SetDeckMusicInfo.PosType Normal = 0;
		// 	public const SetDeckMusicInfo.PosType SLive = 1;
		// }

		// // Fields
		// [HeaderAttribute] // RVA: 0x681978 Offset: 0x681978 VA: 0x681978
		// [SerializeField] // RVA: 0x681978 Offset: 0x681978 VA: 0x681978
		// [TooltipAttribute] // RVA: 0x681978 Offset: 0x681978 VA: 0x681978
		// private InOutAnime m_inOut; // 0xC
		// [SerializeField] // RVA: 0x6819E8 Offset: 0x6819E8 VA: 0x6819E8
		// [TooltipAttribute] // RVA: 0x6819E8 Offset: 0x6819E8 VA: 0x6819E8
		// private UGUIPositionTable m_posTable; // 0x10
		// [SerializeField] // RVA: 0x681A30 Offset: 0x681A30 VA: 0x681A30
		// [TooltipAttribute] // RVA: 0x681A30 Offset: 0x681A30 VA: 0x681A30
		// private Image m_musicAttrImage; // 0x14
		// [SerializeField] // RVA: 0x681A90 Offset: 0x681A90 VA: 0x681A90
		// [TooltipAttribute] // RVA: 0x681A90 Offset: 0x681A90 VA: 0x681A90
		// private Image m_musicAttrEffectImage; // 0x18
		// [SerializeField] // RVA: 0x681B00 Offset: 0x681B00 VA: 0x681B00
		// [TooltipAttribute] // RVA: 0x681B00 Offset: 0x681B00 VA: 0x681B00
		// private SpriteAnime m_musicAttrEffectAnime; // 0x1C
		// [SerializeField] // RVA: 0x681B48 Offset: 0x681B48 VA: 0x681B48
		// [TooltipAttribute] // RVA: 0x681B48 Offset: 0x681B48 VA: 0x681B48
		// private Image m_difficultyImage; // 0x20
		// [SerializeField] // RVA: 0x681B98 Offset: 0x681B98 VA: 0x681B98
		// [TooltipAttribute] // RVA: 0x681B98 Offset: 0x681B98 VA: 0x681B98
		// private Text m_musicNameText; // 0x24
		// [SerializeField] // RVA: 0x681BE0 Offset: 0x681BE0 VA: 0x681BE0
		// [TooltipAttribute] // RVA: 0x681BE0 Offset: 0x681BE0 VA: 0x681BE0
		// private GameObject m_expectedScoreGaugeObject; // 0x28
		// [SerializeField] // RVA: 0x681C4C Offset: 0x681C4C VA: 0x681C4C
		// [TooltipAttribute] // RVA: 0x681C4C Offset: 0x681C4C VA: 0x681C4C
		// private SetDeckExpectedScoreGauge m_expectedScoreGauge; // 0x2C
		// [SerializeField] // RVA: 0x681CAC Offset: 0x681CAC VA: 0x681CAC
		// [TooltipAttribute] // RVA: 0x681CAC Offset: 0x681CAC VA: 0x681CAC
		// private UGUIButton m_expectedScoreDescButton; // 0x30
		// [SerializeField] // RVA: 0x681D0C Offset: 0x681D0C VA: 0x681D0C
		// [TooltipAttribute] // RVA: 0x681D0C Offset: 0x681D0C VA: 0x681D0C
		// private GameObject m_descriptionObject; // 0x34
		// [SerializeField] // RVA: 0x681D68 Offset: 0x681D68 VA: 0x681D68
		// [TooltipAttribute] // RVA: 0x681D68 Offset: 0x681D68 VA: 0x681D68
		// private Text m_descriptionText; // 0x38
		// [TooltipAttribute] // RVA: 0x681DC0 Offset: 0x681DC0 VA: 0x681DC0
		// [SerializeField] // RVA: 0x681DC0 Offset: 0x681DC0 VA: 0x681DC0
		// private ScrollText m_descriptionScroll; // 0x3C
		// [HeaderAttribute] // RVA: 0x681E2C Offset: 0x681E2C VA: 0x681E2C
		// [SerializeField] // RVA: 0x681E2C Offset: 0x681E2C VA: 0x681E2C
		// [TooltipAttribute] // RVA: 0x681E2C Offset: 0x681E2C VA: 0x681E2C
		// private MusicAttrIconScriptableObject m_musicAttrSprites; // 0x40
		// [SerializeField] // RVA: 0x681EC0 Offset: 0x681EC0 VA: 0x681EC0
		// [TooltipAttribute] // RVA: 0x681EC0 Offset: 0x681EC0 VA: 0x681EC0
		// private MusicAttrIconScriptableObject m_musicAttrEffectSprites; // 0x44
		// [TooltipAttribute] // RVA: 0x681F3C Offset: 0x681F3C VA: 0x681F3C
		// [SerializeField] // RVA: 0x681F3C Offset: 0x681F3C VA: 0x681F3C
		// private List<Sprite> m_difficultySprites; // 0x48
		// [TooltipAttribute] // RVA: 0x681F98 Offset: 0x681F98 VA: 0x681F98
		// [SerializeField] // RVA: 0x681F98 Offset: 0x681F98 VA: 0x681F98
		// private List<Sprite> m_difficulty6LineSprites; // 0x4C
		// public Action OnClickExpectedScoreDescButton; // 0x50

		// // Properties
		// public InOutAnime InOut { get; }
		// public SetDeckExpectedScoreGauge ExpectedScoreGauge { get; }

		// // Methods

		// // RVA: 0xA6F6B0 Offset: 0xA6F6B0 VA: 0xA6F6B0
		// public InOutAnime get_InOut() { }

		// // RVA: 0xA6F6B8 Offset: 0xA6F6B8 VA: 0xA6F6B8
		// public SetDeckExpectedScoreGauge get_ExpectedScoreGauge() { }

		// // RVA: 0xA6F6C0 Offset: 0xA6F6C0 VA: 0xA6F6C0
		// private void Awake() { }

		// // RVA: 0xA6F828 Offset: 0xA6F828 VA: 0xA6F828
		// public void Set(EEDKAACNBBG viewMusicData, GameSetupData.MusicInfo musicInfo, bool isMvMode, SetDeckMusicInfo.BottomType bottomType) { }

		// // RVA: 0xA6FE7C Offset: 0xA6FE7C VA: 0xA6FE7C
		// public void SetPosType(SetDeckMusicInfo.PosType posType) { }

		// // RVA: 0xA6FEB0 Offset: 0xA6FEB0 VA: 0xA6FEB0
		// public void ReStartMusicAttrAnime() { }

		// // RVA: 0xA6FF34 Offset: 0xA6FF34 VA: 0xA6FF34
		// public void ResetDescriptionScroll() { }

		// // RVA: 0xA6FD80 Offset: 0xA6FD80 VA: 0xA6FD80
		// private Sprite GetMusicAttrSprite(int attr) { }

		// // RVA: 0xA6FDB4 Offset: 0xA6FDB4 VA: 0xA6FDB4
		// private Sprite GetMusicAttrEffectSprite(int attr) { }

		// // RVA: 0xA6FDE8 Offset: 0xA6FDE8 VA: 0xA6FDE8
		// private Sprite GetDifficultySprite(Difficulty.Type difficulty, bool is6Line) { }

		// // RVA: 0xA6F7BC Offset: 0xA6F7BC VA: 0xA6F7BC
		// private void ApplyBottomType(SetDeckMusicInfo.BottomType bottomType) { }

		// // RVA: 0xA6FF60 Offset: 0xA6FF60 VA: 0xA6FF60
		// public void .ctor() { }

		// [CompilerGeneratedAttribute] // RVA: 0x730CBC Offset: 0x730CBC VA: 0x730CBC
		// // RVA: 0xA6FF68 Offset: 0xA6FF68 VA: 0xA6FF68
		// private void <Awake>b__24_0() { }
	}
}
