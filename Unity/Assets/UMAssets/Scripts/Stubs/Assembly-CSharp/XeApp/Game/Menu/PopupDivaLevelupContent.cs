using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupDivaLevelupContent : UIBehaviour, IPopupContent
	{
		private LayoutResultPopupDivaLevelup layout; // 0x10
		private bool m_isChangedCueSheet; // 0x14

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0xF81964 Offset: 0xF81964 VA: 0xF81964 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupDivaLevelupSetting s = setting as PopupDivaLevelupSetting;
			Parent = control.transform;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			if(s.Content != null)
			{
				layout = s.Content.GetComponent<LayoutResultPopupDivaLevelup>();
				if(layout != null)
					layout.Setup(s.beforeDivaData, s.afterDivaData);
			}
			m_isChangedCueSheet = false;
			SoundManager.Instance.voDiva.RequestChangeCueSheet(s.afterDivaData.AHHJLDLAPAN_DivaId, () =>
			{
				//0xF81F3C
				m_isChangedCueSheet = true;
			});
			gameObject.SetActive(true);
		}

		// RVA: 0xF81CEC Offset: 0xF81CEC VA: 0xF81CEC Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xF81CF4 Offset: 0xF81CF4 VA: 0xF81CF4 Slot: 19
		public void Show()
		{
			if(layout != null)
				layout.Show();
		}

		// RVA: 0xF81DA8 Offset: 0xF81DA8 VA: 0xF81DA8 Slot: 20
		public void Hide()
		{
			if(layout != null)
				layout.Hide();
		}

		// RVA: 0xF81E5C Offset: 0xF81E5C VA: 0xF81E5C Slot: 21
		public bool IsReady()
		{
			return m_isChangedCueSheet;
		}

		// RVA: 0xF81E64 Offset: 0xF81E64 VA: 0xF81E64 Slot: 22
		public void CallOpenEnd()
		{
			this.StartCoroutineWatched(Co_Play());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x707C44 Offset: 0x707C44 VA: 0x707C44
		// // RVA: 0xF81E88 Offset: 0xF81E88 VA: 0xF81E88
		private IEnumerator Co_Play()
		{
			//0xF81F4C
			while(!m_isChangedCueSheet)
				yield return null;
			SoundManager.Instance.voDiva.Play(DivaVoicePlayer.VoiceCategory.Levelup, 0);
		}
	}
}
