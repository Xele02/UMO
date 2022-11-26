using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
	public class PauseButton : MonoBehaviour
	{
		[SerializeField]
		private GameObject m_onGameObject; // 0xC
		[SerializeField]
		private GameObject m_offGameObject; // 0x10
		private bool state; // 0x14
		private bool _isDisable; // 0x15

		public bool IsDisable { get { return _isDisable; } set
			{
				if (_isDisable == value)
					return;
				_isDisable = value;
				ChangeMode();
			} } //0x15626F8 0x1562784
		//public bool IsOn { get; } 0x156278C

		//// RVA: 0x1562794 Offset: 0x1562794 VA: 0x1562794
		public void SetOff()
		{
			m_onGameObject.SetActive(false);
			m_offGameObject.SetActive(true);
			state = false;
		}

		//// RVA: 0x15627F4 Offset: 0x15627F4 VA: 0x15627F4
		public void SetOn()
		{
			m_onGameObject.SetActive(true);
			m_offGameObject.SetActive(false);
			state = true;
		}

		//// RVA: 0x1562854 Offset: 0x1562854 VA: 0x1562854
		//public void SetDisable() { }

		//// RVA: 0x1562860 Offset: 0x1562860 VA: 0x1562860
		//public void SetEnable() { }

		//// RVA: 0x1562714 Offset: 0x1562714 VA: 0x1562714
		private void ChangeMode()
		{
			if(!_isDisable)
			{
				SetOff();
			}
			else
			{
				m_onGameObject.SetActive(false);
				m_offGameObject.SetActive(false);
			}
		}
	}
}
