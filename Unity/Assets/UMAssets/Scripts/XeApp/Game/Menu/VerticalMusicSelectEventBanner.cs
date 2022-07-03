using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using TMPro;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectEventBanner : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroup m_canvasGroup;
		[SerializeField]
		private UGUIButton m_uGUIButton;
		[SerializeField]
		private InOutAnime m_inOut;
		[SerializeField]
		private RawImage m_eventBunnerImage;
		[SerializeField]
		private GameObject m_countingObj;
		[SerializeField]
		private GameObject m_openObj;
		[SerializeField]
		private TextMeshProUGUI m_limitTime;
		[SerializeField]
		private InOutAnime m_pullDownInOut;
		[SerializeField]
		private UGUIButton m_pullDownButton;

		// // Fields
		// [SerializeField] // RVA: 0x67482C Offset: 0x67482C VA: 0x67482C
		// private CanvasGroup m_canvasGroup; // 0xC
		// [SerializeField] // RVA: 0x67483C Offset: 0x67483C VA: 0x67483C
		// private UGUIButton m_uGUIButton; // 0x10
		// [SerializeField] // RVA: 0x67484C Offset: 0x67484C VA: 0x67484C
		// private InOutAnime m_inOut; // 0x14
		// [SerializeField] // RVA: 0x67485C Offset: 0x67485C VA: 0x67485C
		// private RawImage m_eventBunnerImage; // 0x18
		// [SerializeField] // RVA: 0x67486C Offset: 0x67486C VA: 0x67486C
		// private GameObject m_countingObj; // 0x1C
		// [SerializeField] // RVA: 0x67487C Offset: 0x67487C VA: 0x67487C
		// private GameObject m_openObj; // 0x20
		// [SerializeField] // RVA: 0x67488C Offset: 0x67488C VA: 0x67488C
		// private TextMeshProUGUI m_limitTime; // 0x24
		// [SerializeField] // RVA: 0x67489C Offset: 0x67489C VA: 0x67489C
		// private InOutAnime m_pullDownInOut; // 0x28
		// [SerializeField] // RVA: 0x6748AC Offset: 0x6748AC VA: 0x6748AC
		// private UGUIButton m_pullDownButton; // 0x2C
		// private string m_musicEventRemainPrefix; // 0x30
		// private string m_musicEventRemainTime; // 0x34
		// [CompilerGeneratedAttribute] // RVA: 0x6748BC Offset: 0x6748BC VA: 0x6748BC
		// private Action <OnButtonClickListener>k__BackingField; // 0x38

		// // Properties
		// private Action OnButtonClickListener { get; set; }

		// // Methods

		// [CompilerGeneratedAttribute] // RVA: 0x6F59AC Offset: 0x6F59AC VA: 0x6F59AC
		// // RVA: 0xBDD218 Offset: 0xBDD218 VA: 0xBDD218
		// public void set_OnButtonClickListener(Action value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F59BC Offset: 0x6F59BC VA: 0x6F59BC
		// // RVA: 0xBDD220 Offset: 0xBDD220 VA: 0xBDD220
		// private Action get_OnButtonClickListener() { }

		// // RVA: 0xBDD228 Offset: 0xBDD228 VA: 0xBDD228
		// private void Awake() { }

		// // RVA: 0xBDD36C Offset: 0xBDD36C VA: 0xBDD36C
		// private void ApplyRemainTime() { }

		// // RVA: 0xBDD3B4 Offset: 0xBDD3B4 VA: 0xBDD3B4
		// public void ChangeEventBanner(int eventId) { }

		// // RVA: 0xBDD4F0 Offset: 0xBDD4F0 VA: 0xBDD4F0
		// public void SetMusicEventRemainPrefix(string text) { }

		// // RVA: 0xBDD4F8 Offset: 0xBDD4F8 VA: 0xBDD4F8
		// public void SetLimitTimeLabel(string label) { }

		// // RVA: 0xBDD500 Offset: 0xBDD500 VA: 0xBDD500
		// public void SetType(VerticalMusicSelectEventBanner.ButtonType type) { }

		// // RVA: 0xBDD8A8 Offset: 0xBDD8A8 VA: 0xBDD8A8
		// public void SetTicketCount(int count) { }

		// // RVA: 0xBDD8AC Offset: 0xBDD8AC VA: 0xBDD8AC
		// public void Enter() { }

		// // RVA: 0xBDD8DC Offset: 0xBDD8DC VA: 0xBDD8DC
		// public void Leave() { }

		// // RVA: 0xBDD90C Offset: 0xBDD90C VA: 0xBDD90C
		// public bool IsPlaying() { }

		// // RVA: 0xBDD938 Offset: 0xBDD938 VA: 0xBDD938
		// public void Show() { }

		// // RVA: 0xBDD968 Offset: 0xBDD968 VA: 0xBDD968
		// public void Hide() { }

		// // RVA: 0xBDD998 Offset: 0xBDD998 VA: 0xBDD998
		// public void SetEnable(bool isEneble) { }

		// // RVA: 0xBDDA1C Offset: 0xBDDA1C VA: 0xBDDA1C
		// public void .ctor() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F59CC Offset: 0x6F59CC VA: 0x6F59CC
		// // RVA: 0xBDDA8C Offset: 0xBDDA8C VA: 0xBDDA8C
		// private void <Awake>b__16_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F59DC Offset: 0x6F59DC VA: 0x6F59DC
		// // RVA: 0xBDDAA0 Offset: 0xBDDAA0 VA: 0xBDDAA0
		// private void <Awake>b__16_1() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F59EC Offset: 0x6F59EC VA: 0x6F59EC
		// // RVA: 0xBDDB58 Offset: 0xBDDB58 VA: 0xBDDB58
		// private void <ChangeEventBanner>b__18_0(IiconTexture image) { }
	}
}
