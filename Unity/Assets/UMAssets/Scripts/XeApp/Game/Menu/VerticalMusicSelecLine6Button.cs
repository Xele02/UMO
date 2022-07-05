using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelecLine6Button : MonoBehaviour
	{
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x674344 Offset: 0x674344 VA: 0x674344
		private UGUIButton m_button; // 0xC
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x67438C Offset: 0x67438C VA: 0x67438C
		private InOutAnime m_inOut; // 0x10
		[SerializeField]
		private Image m_4line; // 0x14
		[SerializeField]
		private Image m_6line; // 0x18

		// public Action OnClickButtonListener { private get; set; } // 0x1C

		// // RVA: 0xBDB6EC Offset: 0xBDB6EC VA: 0xBDB6EC
		private void Awake()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xBDB7B4 Offset: 0xBDB7B4 VA: 0xBDB7B4
		// public void SetButtonEnable(bool isEnable) { }

		// // RVA: 0xBDB7E8 Offset: 0xBDB7E8 VA: 0xBDB7E8
		// public void Set4Line() { }

		// // RVA: 0xBDB840 Offset: 0xBDB840 VA: 0xBDB840
		// public void Set6Line() { }

		// // RVA: 0xBDB898 Offset: 0xBDB898 VA: 0xBDB898
		public void Enter()
		{
			m_inOut.ForceEnter(null);
		}

		// // RVA: 0xBDB8C8 Offset: 0xBDB8C8 VA: 0xBDB8C8
		// public void Leave() { }

		// // RVA: 0xBDB8F8 Offset: 0xBDB8F8 VA: 0xBDB8F8
		public bool IsPlaying()
		{
			return m_inOut.IsPlaying();
		}

		// [CompilerGeneratedAttribute] // RVA: 0x6F593C Offset: 0x6F593C VA: 0x6F593C
		// // RVA: 0xBDB92C Offset: 0xBDB92C VA: 0xBDB92C
		// private void <Awake>b__8_0() { }
	}
}
