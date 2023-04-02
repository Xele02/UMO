using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class IntimacyCounter : MonoBehaviour
	{
		// [HeaderAttribute] // RVA: 0x68B044 Offset: 0x68B044 VA: 0x68B044
		[SerializeField]
		private UGUINumController m_numCount; // 0xC
		// [HeaderAttribute] // RVA: 0x68B098 Offset: 0x68B098 VA: 0x68B098
		[SerializeField]
		private ColorGroup m_colorGroup; // 0x10
		// [HeaderAttribute] // RVA: 0x68B0FC Offset: 0x68B0FC VA: 0x68B0FC
		[SerializeField]
		private Text m_textTime; // 0x14
		// [HeaderAttribute] // RVA: 0x68B154 Offset: 0x68B154 VA: 0x68B154
		[SerializeField]
		private InOutAnime m_inOutCount; // 0x18

		public Transform rootMessage { get { return m_inOutCount.transform; } } //0x1101CEC

		// // RVA: 0x1101D18 Offset: 0x1101D18 VA: 0x1101D18
		public void SetEnable(bool enable)
		{
			if(enable)
				m_colorGroup.color = new Color(1, 1, 1);
			else
				m_colorGroup.color = new Color(0.6f, 0.6f, 0.6f);
			m_colorGroup.OnUpdateColor();
		}

		// // RVA: 0x1101E0C Offset: 0x1101E0C VA: 0x1101E0C
		// public void SetCount(int count) { }

		// // RVA: 0x1101E40 Offset: 0x1101E40 VA: 0x1101E40
		// public void SetTime(long time) { }

		// // RVA: 0x11020E0 Offset: 0x11020E0 VA: 0x11020E0
		public void Enter()
		{
			m_inOutCount.Enter(false, null);
		}

		// // RVA: 0x110211C Offset: 0x110211C VA: 0x110211C
		// public void Enter(float animTime) { }

		// // RVA: 0x110215C Offset: 0x110215C VA: 0x110215C
		// public void Leave() { }

		// // RVA: 0x1102198 Offset: 0x1102198 VA: 0x1102198
		// public void Leave(float animTime) { }

		// // RVA: 0x11021D8 Offset: 0x11021D8 VA: 0x11021D8
		// public bool IsPlaying() { }
	}
}
