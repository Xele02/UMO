using System.Collections;

namespace XeApp.Game.Adv
{
	public class AdvMessage : AdvMessageBase
	{
		private bool m_is_play; // 0x1C
		private IEnumerator coroutine; // 0x20
		private float m_message_spd = 0.2f; // 0x24

		//// RVA: 0xE54CEC Offset: 0xE54CEC VA: 0xE54CEC Slot: 6
		//public override bool IsPlay() { }

		//// RVA: 0xE54CF4 Offset: 0xE54CF4 VA: 0xE54CF4 Slot: 4
		//public override void Skip() { }

		//// RVA: 0xE54E5C Offset: 0xE54E5C VA: 0xE54E5C Slot: 5
		//public override void StartMessage(string message, float message_spd, AdvMessageBase.TagConvertFunc func) { }

		//[IteratorStateMachineAttribute] // RVA: 0x743914 Offset: 0x743914 VA: 0x743914
		//// RVA: 0xE54F58 Offset: 0xE54F58 VA: 0xE54F58
		//private IEnumerator UpdateMessage(string message, AdvMessageBase.TagConvertFunc func) { }
	}
}
