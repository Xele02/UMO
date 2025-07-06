using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class PopupCampaignRegistSetting : PopupSetting
	{
		public OLLAFCBLMIJ View { get; set; } // 0x34
		public override string PrefabPath { get { return ""; } } //0x133E5B8
		public override string BundleName { get { return "ly/119.xab"; } } //0x133E614
		public override string AssetName { get { return "root_pop_cpn_live_01_layout_root"; } } //0x133E670
		public override bool IsAssetBundle { get { return true; } } //0x133E6CC
		public override bool IsPreload { get { return false; } } //0x133E6D4
		public override GameObject Content { get { return m_content; } } //0x133E6DC

		// // RVA: 0x133E6E4 Offset: 0x133E6E4 VA: 0x133E6E4
		// public void SetContent(GameObject obj) { }
	}

	public class PopupCampaignRegistContent : UIBehaviour, IPopupContent
	{
		private PopupCampaignRegistSetting setup; // 0x10
		private PopupWindowControl control; // 0x14
		private LayoutPopupCampaignRegist layout; // 0x18

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x133DC9C Offset: 0x133DC9C VA: 0x133DC9C Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			this.control = control;
			setup = setting as PopupCampaignRegistSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			layout = setup.Content.GetComponent<LayoutPopupCampaignRegist>();
			layout.Setup(NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId, setup.View);
			layout.OnClickButtonIDCopy = OnClickIDCopy;
		}

		// RVA: 0x133DF6C Offset: 0x133DF6C VA: 0x133DF6C
		private void OnClickIDCopy()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			ClipboardSupport.CopyText(NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId.ToString());
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent("", SizeType.Small, MessageManager.Instance.GetMessage("menu", "popup_myid_copy_msg"), new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}, false, true), (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x133E5A8
				return;
			}, null, null, null, true, true, false, null, () =>
			{
				//0x133E5AC
				return;
			});
		}

		// RVA: 0x133E3EC Offset: 0x133E3EC VA: 0x133E3EC Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x133E3F4 Offset: 0x133E3F4 VA: 0x133E3F4
		public void Update()
		{
			return;
		}

		// RVA: 0x133E3F8 Offset: 0x133E3F8 VA: 0x133E3F8 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x133E430 Offset: 0x133E430 VA: 0x133E430 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x133E468 Offset: 0x133E468 VA: 0x133E468 Slot: 21
		public bool IsReady()
		{
			return layout != null && layout.IsLoaded();
		}

		// RVA: 0x133E520 Offset: 0x133E520 VA: 0x133E520 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
