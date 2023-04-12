using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System;
using XeSys;
using System.Collections;
using mcrs;

namespace XeApp.Game.Menu
{
	public class HomeGetSkipTicket : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_buttonClose; // 0x14
		[SerializeField]
		private CheckboxButton m_checkboxReject; // 0x18
		[SerializeField]
		private Text m_textTitle; // 0x1C
		[SerializeField]
		private Text m_textDesc1; // 0x20
		[SerializeField]
		private Text m_textDesc2; // 0x24
		[SerializeField]
		private Text m_textNumLabel; // 0x28
		[SerializeField]
		private Text m_textNumCount; // 0x2C
		[SerializeField]
		private Text m_textReject; // 0x30
		[SerializeField]
		private RawImageEx m_imageIcon; // 0x34
		[SerializeField]
		private LayoutUGUIHitOnly m_touchBlocker; // 0x38
		private AbsoluteLayout m_layoutRoot; // 0x3C
		private int m_typeItemId; // 0x40
		private bool m_isOpen; // 0x44

		public bool IsOpen { get { return m_isOpen; } } //0x963E9C
		public Action onClickCloseButton { private get; set; } // 0x48
		public Action<bool> onClickRejectCheckbox { private get; set; } // 0x4C

		//// RVA: 0x963EC4 Offset: 0x963EC4 VA: 0x963EC4
		public void Enter(bool checkReject = false, bool checkBoxHidden = false, Action callback = null)
		{
			if (m_isOpen)
				return;
			if(checkBoxHidden)
			{
				m_checkboxReject.Hidden = true;
			}
			else
			{
				if (checkReject)
					m_checkboxReject.SetOn();
				else
					m_checkboxReject.SetOff();
			}
			this.StartCoroutineWatched(Co_Enter(callback));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E2474 Offset: 0x6E2474 VA: 0x6E2474
		//// RVA: 0x963F6C Offset: 0x963F6C VA: 0x963F6C
		private IEnumerator Co_Enter(Action callback)
		{
			//0x96521C
			PopupWindowControl.PlayPopupWindowOpenSe(0, SoundManager.Instance.sePlayerBoot);
			m_layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
			yield return Co.R(WaitAnim(m_layoutRoot));
			m_isOpen = true;
			if (callback != null)
				callback();
		}

		//// RVA: 0x964034 Offset: 0x964034 VA: 0x964034
		public void Leave(Action callback)
		{
			if (!m_isOpen)
				return;
			this.StartCoroutineWatched(Co_Leave(callback));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E24EC Offset: 0x6E24EC VA: 0x6E24EC
		//// RVA: 0x964068 Offset: 0x964068 VA: 0x964068
		private IEnumerator Co_Leave(Action callback)
		{
			//0x965434
			PopupWindowControl.PlayPopupWindowOpenSe(PopupWindowControl.SeType.WindowClose, SoundManager.Instance.sePlayerBoot);
			m_layoutRoot.StartChildrenAnimGoStop("go_out", "st_out");
			yield return Co.R(WaitAnim(m_layoutRoot));
			m_isOpen = false;
			if (callback != null)
				callback();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E2564 Offset: 0x6E2564 VA: 0x6E2564
		//// RVA: 0x964130 Offset: 0x964130 VA: 0x964130
		public IEnumerator WaitAnim(AbsoluteLayout layout)
		{
			//0x96564C
			while (layout.IsPlayingChildren())
				yield return null;
		}

		//// RVA: 0x9641DC Offset: 0x9641DC VA: 0x9641DC
		public void Setup(int typeItemId, int getCount)
		{
			m_typeItemId = typeItemId;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			MenuScene.Instance.ItemTextureCache.Load(typeItemId, (IiconTexture texture) =>
			{
				//0x964E78
				texture.Set(m_imageIcon);
			});
			m_textNumLabel.text = bk.GetMessageByLabel("popup_get_liveskip_ticket_count");
			m_textReject.text = bk.GetMessageByLabel("popup_get_liveskip_ticket_checkbox");
			m_textTitle.text = bk.GetMessageByLabel("popup_get_liveskip_ticket_title");
			m_textDesc1.text = string.Format("{0} {1}{2}", EKLNMHFCAOI.INCKKODFJAP(typeItemId), getCount, EKLNMHFCAOI.NDBLEADIDLA(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(typeItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(typeItemId)));
			m_textDesc2.text = string.Format(bk.GetMessageByLabel("popup_get_liveskip_ticket_desc"), getCount);
			m_textNumCount.text = string.Format("{0}/{1}", CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.GJCOJBDOOJG_LimitedCompoItem.HPPKOGKNKMH(1, time), CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.GJCOJBDOOJG_LimitedCompoItem.OPCIHPEIFFE(1));
		}

		//// RVA: 0x964844 Offset: 0x964844 VA: 0x964844 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_layoutRoot = layout.FindViewById("sw_pickup_win2_anim") as AbsoluteLayout;
			m_layoutRoot.StartChildrenAnimGoStop("st_out");
			m_buttonClose.ClearOnClickCallback();
			m_buttonClose.AddOnClickCallback(() =>
			{
				//0x964F58
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				if (onClickCloseButton != null)
					onClickCloseButton();
				Leave(null);
			});
			m_checkboxReject.ClearOnClickCallback();
			m_checkboxReject.AddOnClickCallback(() =>
			{
				//0x964FD4
				TodoLogger.LogNotImplemented("m_checkboxReject");
			});
			Loaded();
			return true;
		}

		//// RVA: 0x964A58 Offset: 0x964A58 VA: 0x964A58
		//private void ShowConfirmWindow(bool isChecked, Action<bool> callback) { }
		
		//[CompilerGeneratedAttribute] // RVA: 0x6E260C Offset: 0x6E260C VA: 0x6E260C
		//// RVA: 0x9650E4 Offset: 0x9650E4 VA: 0x9650E4
		//private void <InitializeFromLayout>b__29_2(bool isChecked) { }
	}
}
