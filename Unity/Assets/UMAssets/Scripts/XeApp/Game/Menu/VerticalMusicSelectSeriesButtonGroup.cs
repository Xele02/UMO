using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using TMPro;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectSeriesButtonGroup : MonoBehaviour
	{
		[SerializeField]
		private UGUIToggleButtonGroup m_toggleButtonGroup;
		[SerializeField]
		private InOutAnime m_inOut;
		[SerializeField]
		private UGUIButton m_pullDownButton;
		[SerializeField]
		private InOutAnime m_pullDownInOut;
		[SerializeField]
		private Sprite[] m_seriesSprites;
		[SerializeField]
		private Image[] m_btnImage;
		[SerializeField]
		private TextMeshProUGUI[] m_btnText;
		[SerializeField]
		private Image m_pullDownBtnImage;
		[SerializeField]
		private TextMeshProUGUI m_pullDownBtnText;

		// // Fields
		// private static readonly MusicSelectConsts.SeriesType[] BUTTON_LIST_TYPE; // 0x0
		// public static readonly SeriesAttr.Type[] CONVERT_SERIES_LIST; // 0x4
		// [SerializeField] // RVA: 0x6759D0 Offset: 0x6759D0 VA: 0x6759D0
		// private UGUIToggleButtonGroup m_toggleButtonGroup; // 0xC
		// [SerializeField] // RVA: 0x6759E0 Offset: 0x6759E0 VA: 0x6759E0
		// private InOutAnime m_inOut; // 0x10
		// [SerializeField] // RVA: 0x6759F0 Offset: 0x6759F0 VA: 0x6759F0
		// private UGUIButton m_pullDownButton; // 0x14
		// [SerializeField] // RVA: 0x675A00 Offset: 0x675A00 VA: 0x675A00
		// private InOutAnime m_pullDownInOut; // 0x18
		// [SerializeField] // RVA: 0x675A10 Offset: 0x675A10 VA: 0x675A10
		// private Sprite[] m_seriesSprites; // 0x1C
		// [SerializeField] // RVA: 0x675A20 Offset: 0x675A20 VA: 0x675A20
		// private Image[] m_btnImage; // 0x20
		// [SerializeField] // RVA: 0x675A30 Offset: 0x675A30 VA: 0x675A30
		// private TextMeshProUGUI[] m_btnText; // 0x24
		// [SerializeField] // RVA: 0x675A40 Offset: 0x675A40 VA: 0x675A40
		// private Image m_pullDownBtnImage; // 0x28
		// [SerializeField] // RVA: 0x675A50 Offset: 0x675A50 VA: 0x675A50
		// private TextMeshProUGUI m_pullDownBtnText; // 0x2C
		// [CompilerGeneratedAttribute] // RVA: 0x675A60 Offset: 0x675A60 VA: 0x675A60
		// private Action<int> <OnButtonClickListener>k__BackingField; // 0x30

		// // Properties
		// private Action<int> OnButtonClickListener { get; set; }

		// // Methods

		// [CompilerGeneratedAttribute] // RVA: 0x6F7274 Offset: 0x6F7274 VA: 0x6F7274
		// // RVA: 0xAD92E4 Offset: 0xAD92E4 VA: 0xAD92E4
		// private Action<int> get_OnButtonClickListener() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F7284 Offset: 0x6F7284 VA: 0x6F7284
		// // RVA: 0xAC6074 Offset: 0xAC6074 VA: 0xAC6074
		// public void set_OnButtonClickListener(Action<int> value) { }

		// // RVA: 0xAD92EC Offset: 0xAD92EC VA: 0xAD92EC
		// private void Awake() { }

		// // RVA: 0xAD9714 Offset: 0xAD9714 VA: 0xAD9714
		// public void SetSeriesButton(int series) { }

		// // RVA: 0xAD98E4 Offset: 0xAD98E4 VA: 0xAD98E4
		// public void Enter() { }

		// // RVA: 0xAD9914 Offset: 0xAD9914 VA: 0xAD9914
		// public void Leave() { }

		// // RVA: 0xAD9978 Offset: 0xAD9978 VA: 0xAD9978
		// public bool IsPlaying() { }

		// // RVA: 0xAD99A4 Offset: 0xAD99A4 VA: 0xAD99A4
		// public void SetEnable(bool isEneble) { }

		// // RVA: 0xAD9A28 Offset: 0xAD9A28 VA: 0xAD9A28
		// public void SetPullDownEnable(bool isEneble) { }

		// // RVA: 0xAD94F8 Offset: 0xAD94F8 VA: 0xAD94F8
		// private void SetLogo(Image spriteImage, int btnIndex) { }

		// // RVA: 0xAD9768 Offset: 0xAD9768 VA: 0xAD9768
		// private void SetPullDownText(int btnIndex) { }

		// // RVA: 0xAD9AA4 Offset: 0xAD9AA4 VA: 0xAD9AA4
		// public void .ctor() { }

		// // RVA: 0xAD9B50 Offset: 0xAD9B50 VA: 0xAD9B50
		// private static void .cctor() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F7294 Offset: 0x6F7294 VA: 0x6F7294
		// // RVA: 0xAD9C2C Offset: 0xAD9C2C VA: 0xAD9C2C
		// private void <Awake>b__15_0(int index) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F72A4 Offset: 0x6F72A4 VA: 0x6F72A4
		// // RVA: 0xAD9CBC Offset: 0xAD9CBC VA: 0xAD9CBC
		// private void <Awake>b__15_1() { }
	}
}
