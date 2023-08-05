using mcrs;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;

namespace XeApp.Game.Menu
{
	public class PopupHelpSelect : UIBehaviour, IPopupContent
	{
		private PopupWindowControl m_control; // 0x10

		public Transform Parent { get; set; } // 0xC

		// RVA: 0x17AA920 Offset: 0x17AA920 VA: 0x17AA920 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			HelpSelectPopupSetting s = setting as HelpSelectPopupSetting;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = new Vector3(0, 0, 0);
			HelpSelectWindow w = transform.GetComponent<HelpSelectWindow>();
			w.Init(s.uniqueId, s.IsWiki);
			w.PushButtonHandler -= OnPushButton;
			w.PushButtonHandler += OnPushButton;
			m_control = control;
			if (s.IsDefault)
				Show();
			else
				Hide();
		}

		// RVA: 0x17AAD74 Offset: 0x17AAD74 VA: 0x17AAD74 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x17AAC68 Offset: 0x17AAC68 VA: 0x17AAC68 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
			transform.GetComponent<HelpSelectWindow>().TabChange();
		}

		// RVA: 0x17AAD3C Offset: 0x17AAD3C VA: 0x17AAD3C Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x17AAD7C Offset: 0x17AAD7C VA: 0x17AAD7C Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x17AAD84 Offset: 0x17AAD84 VA: 0x17AAD84 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}

		//// RVA: 0x17AAD88 Offset: 0x17AAD88 VA: 0x17AAD88
		private void OnPushButton(VeiwOptionHelpCategoryData data, int index, bool isWiki)
		{
			if(isWiki)
			{
				NKGJPJPHLIF.HHCJCDFCLOB.NBLAOIPJFGL_OpenURL(data.wikis[index].wikiURL);
				return;
			}
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_ShowTutorial(data.helps[index]));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E20C4 Offset: 0x6E20C4 VA: 0x6E20C4
		//// RVA: 0x17AAF44 Offset: 0x17AAF44 VA: 0x17AAF44
		private IEnumerator Co_ShowTutorial(VeiwOptionHelpContentData data)
		{
			//0x17AB018
			m_control.InputDisable();
			yield return this.StartCoroutineWatched(TutorialManager.ShowTutorial(data.helpId, null));
			m_control.InputEnable();
		}
	}
}
