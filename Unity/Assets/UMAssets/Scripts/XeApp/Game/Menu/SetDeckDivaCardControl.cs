using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System;

namespace XeApp.Game.Menu
{
	public class SetDeckDivaCardControl : MonoBehaviour
	{
		//[TooltipAttribute] // RVA: 0x680544 Offset: 0x680544 VA: 0x680544
		//[HeaderAttribute] // RVA: 0x680544 Offset: 0x680544 VA: 0x680544
		[SerializeField]
		private UGUIStayButton m_divaButton; // 0xC
		//[TooltipAttribute] // RVA: 0x6805BC Offset: 0x6805BC VA: 0x6805BC
		[SerializeField]
		private Image m_emptyBackImage; // 0x10
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x680614 Offset: 0x680614 VA: 0x680614
		private Image m_divaBackImage; // 0x14
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x68066C Offset: 0x68066C VA: 0x68066C
		private Image m_emptyImage; // 0x18
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x6806B4 Offset: 0x6806B4 VA: 0x6806B4
		private RawImage m_divaImage; // 0x1C
		//[TooltipAttribute] // RVA: 0x680704 Offset: 0x680704 VA: 0x680704
		[SerializeField]
		private RawImage m_divaIconImage; // 0x20
		//[TooltipAttribute] // RVA: 0x680760 Offset: 0x680760 VA: 0x680760
		[SerializeField]
		private Image m_divaFrameImage; // 0x24
		//[TooltipAttribute] // RVA: 0x6807B4 Offset: 0x6807B4 VA: 0x6807B4
		[SerializeField]
		private Image m_divaFrontImage; // 0x28
		//[TooltipAttribute] // RVA: 0x68082C Offset: 0x68082C VA: 0x68082C
		[SerializeField]
		private Image m_unitIconImage; // 0x2C
		//[TooltipAttribute] // RVA: 0x68088C Offset: 0x68088C VA: 0x68088C
		[SerializeField]
		private SetDeckDivaStatusControl m_divaStatus; // 0x30
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x6808E8 Offset: 0x6808E8 VA: 0x6808E8
		private UGUIButton m_costumeButton; // 0x34
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x680938 Offset: 0x680938 VA: 0x680938
		private RawImage m_costumeImage; // 0x38
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x680988 Offset: 0x680988 VA: 0x680988
		private GameObject m_costumeImpObject; // 0x3C
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x6809F0 Offset: 0x6809F0 VA: 0x6809F0
		private GameObject m_divaImpObject; // 0x40
		//[TooltipAttribute] // RVA: 0x680A58 Offset: 0x680A58 VA: 0x680A58
		[SerializeField]
		private Image m_prismImpImage; // 0x44
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x680ABC Offset: 0x680ABC VA: 0x680ABC
		private Text m_messageText; // 0x48
		//[HeaderAttribute] // RVA: 0x680B04 Offset: 0x680B04 VA: 0x680B04
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x680B04 Offset: 0x680B04 VA: 0x680B04
		private DivaColorSetScriptableObject m_divaColors; // 0x4C
		public Action OnClickDivaButton; // 0x50
		//public Action OnStayDivaButton; // 0x54
		public Action OnClickCostumeButton; // 0x58
		//private FFHPBEPOMAK m_divaData; // 0x5C
		//private DFKGGBMFFGB m_playerData; // 0x60
		//private int m_musicId; // 0x64
		//private bool m_isStory; // 0x68
		//private bool m_isGoDivaSub; // 0x69
		//private int m_divaTextureLoadingCount; // 0x6C
		//private int m_costumeTextureLoadingCount; // 0x70

		//public bool IsLoading { get; } 0xA68268
		//public FFHPBEPOMAK DivaData { get; } 0xA6A0C0
		//public UGUIStayButton DivaButton { get; } 0xA6A0C8
		//private bool IsEmpty { get; } 0xA6A0D0

		//// RVA: 0xA6A0E4 Offset: 0xA6A0E4 VA: 0xA6A0E4
		private void Awake()
		{
			UnityEngine.Debug.LogError("TODO DivaCardControl Awake");
		}

		//// RVA: 0xA6A3A8 Offset: 0xA6A3A8 VA: 0xA6A3A8
		//public void Set(FFHPBEPOMAK divaData, DFKGGBMFFGB playerData, bool isCenter, bool isGoDiva, int musicId = 0, bool isStory = False) { }

		//// RVA: 0xA6B4F8 Offset: 0xA6B4F8 VA: 0xA6B4F8
		//public void SetForPrism(FFHPBEPOMAK divaData) { }

		//// RVA: 0xA68D84 Offset: 0xA68D84 VA: 0xA68D84
		//public void SetForAssist(FFHPBEPOMAK divaData) { }

		//// RVA: 0xA6B6E0 Offset: 0xA6B6E0 VA: 0xA6B6E0
		//public void SetStatusDisplayType(DisplayType type) { }

		//// RVA: 0xA6A2EC Offset: 0xA6A2EC VA: 0xA6A2EC
		//public void SetShowMultiIcon(bool isShow) { }

		//// RVA: 0xA68A30 Offset: 0xA68A30 VA: 0xA68A30
		//public void SetImp(SetDeckDivaCardControl.ImpType type) { }

		//// RVA: 0xA6A648 Offset: 0xA6A648 VA: 0xA6A648
		//private void SetDivaImageAndColor(FFHPBEPOMAK divaData, bool isGoDivaSub = False) { }

		//// RVA: 0xA6B280 Offset: 0xA6B280 VA: 0xA6B280
		//private void SetCostumeImage(FFHPBEPOMAK divaData) { }

		//// RVA: 0xA6BB74 Offset: 0xA6BB74 VA: 0xA6BB74
		//private Color ColorAlphaMarge(Color targetColor, float a) { }

		//[CompilerGeneratedAttribute] // RVA: 0x730BCC Offset: 0x730BCC VA: 0x730BCC
		//// RVA: 0xA6BBBC Offset: 0xA6BBBC VA: 0xA6BBBC
		//private void <Awake>b__36_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x730BDC Offset: 0x730BDC VA: 0x730BDC
		//// RVA: 0xA6BBD0 Offset: 0xA6BBD0 VA: 0xA6BBD0
		//private void <Awake>b__36_1() { }

		//[CompilerGeneratedAttribute] // RVA: 0x730BEC Offset: 0x730BEC VA: 0x730BEC
		//// RVA: 0xA6BBE4 Offset: 0xA6BBE4 VA: 0xA6BBE4
		//private void <Awake>b__36_2() { }

		//[CompilerGeneratedAttribute] // RVA: 0x730BFC Offset: 0x730BFC VA: 0x730BFC
		//// RVA: 0xA6BBF8 Offset: 0xA6BBF8 VA: 0xA6BBF8
		//private void <SetDivaImageAndColor>b__43_0(IiconTexture texture) { }

		//[CompilerGeneratedAttribute] // RVA: 0x730C0C Offset: 0x730C0C VA: 0x730C0C
		//// RVA: 0xA6BCE4 Offset: 0xA6BCE4 VA: 0xA6BCE4
		//private void <SetDivaImageAndColor>b__43_1(IiconTexture texture, Rect rect) { }

		//[CompilerGeneratedAttribute] // RVA: 0x730C1C Offset: 0x730C1C VA: 0x730C1C
		//// RVA: 0xA6BE1C Offset: 0xA6BE1C VA: 0xA6BE1C
		//private void <SetCostumeImage>b__44_0(IiconTexture icon) { }
	}
}
