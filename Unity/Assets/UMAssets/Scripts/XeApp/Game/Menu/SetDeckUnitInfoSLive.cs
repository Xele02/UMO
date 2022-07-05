using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class SetDeckUnitInfoSLive : MonoBehaviour
	{
		[SerializeField]
		private UGUIEnterLeave m_animeControl;
		[SerializeField]
		private List<SetDeckDivaCardControl> m_divas;
		[SerializeField]
		private List<SetDeckDivaCardControl> m_additionDivas;

		// // Namespace: 
		// public enum SetDeckUnitInfoSLive.ModeType // TypeDefIndex: 16470
		// {
		// 	// Fields
		// 	public int value__; // 0x0
		// 	public const SetDeckUnitInfoSLive.ModeType Simulation = 0;
		// 	public const SetDeckUnitInfoSLive.ModeType Prism = 1;
		// }

		// // Namespace: 
		// public sealed class SetDeckUnitInfoSLive.EventOnClickItem : MulticastDelegate // TypeDefIndex: 16471
		// {
		// 	// Methods

		// 	// RVA: 0xC37E30 Offset: 0xC37E30 VA: 0xC37E30
		// 	public void .ctor(object object, IntPtr method) { }

		// 	// RVA: 0xC377F0 Offset: 0xC377F0 VA: 0xC377F0 Slot: 12
		// 	public virtual void Invoke(PopupMvModeSelectListContent.SelectTarget target, int divaSlotNumber) { }

		// 	// RVA: 0xC37E44 Offset: 0xC37E44 VA: 0xC37E44 Slot: 13
		// 	public virtual IAsyncResult BeginInvoke(PopupMvModeSelectListContent.SelectTarget target, int divaSlotNumber, AsyncCallback callback, object object) { }

		// 	// RVA: 0xC37F00 Offset: 0xC37F00 VA: 0xC37F00 Slot: 14
		// 	public virtual void EndInvoke(IAsyncResult result) { }
		// }

		// // Fields
		// [TooltipAttribute] // RVA: 0x6846D8 Offset: 0x6846D8 VA: 0x6846D8
		// [SerializeField] // RVA: 0x6846D8 Offset: 0x6846D8 VA: 0x6846D8
		// private UGUIEnterLeave m_animeControl; // 0xC
		// [TooltipAttribute] // RVA: 0x684720 Offset: 0x684720 VA: 0x684720
		// [SerializeField] // RVA: 0x684720 Offset: 0x684720 VA: 0x684720
		// private List<SetDeckDivaCardControl> m_divas; // 0x10
		// [TooltipAttribute] // RVA: 0x684770 Offset: 0x684770 VA: 0x684770
		// [SerializeField] // RVA: 0x684770 Offset: 0x684770 VA: 0x684770
		// private List<SetDeckDivaCardControl> m_additionDivas; // 0x14
		// public SetDeckUnitInfoSLive.EventOnClickItem OnClickItem; // 0x18
		// private List<FFHPBEPOMAK> m_divaDatas; // 0x1C

		// // Properties
		// public UGUIEnterLeave AnimeControl { get; }

		// // Methods

		// // RVA: 0xC36818 Offset: 0xC36818 VA: 0xC36818
		// public UGUIEnterLeave get_AnimeControl() { }

		// // RVA: 0xC36820 Offset: 0xC36820 VA: 0xC36820
		// private void Awake() { }

		// // RVA: 0xC36D44 Offset: 0xC36D44 VA: 0xC36D44
		// public void UpdateContent(AOJGDNFAIJL.AMIECPBIALP prismData, GameSetupData.MusicInfo musicInfo) { }

		// // RVA: 0xC37444 Offset: 0xC37444 VA: 0xC37444
		// public bool IsUpdatingContent() { }

		// // RVA: 0xC3739C Offset: 0xC3739C VA: 0xC3739C
		// private SetDeckDivaCardControl GetDivaControlBySlotNumber(int divaSlotNumber) { }

		// // RVA: 0xC377D8 Offset: 0xC377D8 VA: 0xC377D8
		// private void OnClickDivaButton(int divaSlotNumber) { }

		// // RVA: 0xC37C74 Offset: 0xC37C74 VA: 0xC37C74
		// private void OnClickCostumeButton(int divaSlotNumber) { }

		// // RVA: 0xC37CCC Offset: 0xC37CCC VA: 0xC37CCC
		// public void .ctor() { }
	}
}
