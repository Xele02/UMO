using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using TMPro;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectSeriesButtonGroup : MonoBehaviour
	{
		// private static readonly MusicSelectConsts.SeriesType[] BUTTON_LIST_TYPE = new MusicSelectConsts.SeriesType[6] {DB17E883A647963A26D973378923EF4649801319}; // 0x0
		// public static readonly SeriesAttr.Type[] CONVERT_SERIES_LIST = new SeriesAttr.Type[6] {43455BB18F9D2C51C2C5B74704B48B60579B2E8D}; // 0x4
		[SerializeField]
		private UGUIToggleButtonGroup m_toggleButtonGroup; // 0xC
		[SerializeField]
		private InOutAnime m_inOut; // 0x10
		[SerializeField]
		private UGUIButton m_pullDownButton; // 0x14
		[SerializeField]
		private InOutAnime m_pullDownInOut; // 0x18
		[SerializeField]
		private Sprite[] m_seriesSprites = new Sprite[6]; // 0x1C
		[SerializeField]
		private Image[] m_btnImage = new Image[6]; // 0x20
		[SerializeField]
		private TextMeshProUGUI[] m_btnText = new TextMeshProUGUI[6]; // 0x24
		[SerializeField]
		private Image m_pullDownBtnImage; // 0x28
		[SerializeField]
		private TextMeshProUGUI m_pullDownBtnText; // 0x2C

		// public Action<int> OnButtonClickListener { private get; set; } // 0x30

		// // RVA: 0xAD92EC Offset: 0xAD92EC VA: 0xAD92EC
		private void Awake()
		{
			UnityEngine.Debug.LogError("TODO !!!");
		}

		// // RVA: 0xAD9714 Offset: 0xAD9714 VA: 0xAD9714
		// public void SetSeriesButton(int series) { }

		// // RVA: 0xAD98E4 Offset: 0xAD98E4 VA: 0xAD98E4
		public void Enter()
		{
			m_inOut.ForceEnter(null);
		}

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

		// [CompilerGeneratedAttribute] // RVA: 0x6F7294 Offset: 0x6F7294 VA: 0x6F7294
		// // RVA: 0xAD9C2C Offset: 0xAD9C2C VA: 0xAD9C2C
		// private void <Awake>b__15_0(int index) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F72A4 Offset: 0x6F72A4 VA: 0x6F72A4
		// // RVA: 0xAD9CBC Offset: 0xAD9CBC VA: 0xAD9CBC
		// private void <Awake>b__15_1() { }
	}
}
