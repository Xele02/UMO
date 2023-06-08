using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class PopupItemDetail : LayoutUGUIScriptBase, IPopupContent
	{
		public class PopupItemDetailSetting : PopupSetting
		{
			public int ItemId { get; set; } // 0x34
			public int SubId { get; set; } // 0x38
			public int Count { get; set; } // 0x3C
			public string OverrideText { get; set; } // 0x40
			public string OverrideName { get; set; } // 0x44
			public bool IsShop { get; set; } // 0x48
			public override bool IsPreload { get { return true; } } //0xAFB298
			public override bool IsAssetBundle { get { return true; } } //0xAFB2A0
			public override string PrefabPath { get { return ""; } } //0xAFB2A8
			public override string BundleName { get { return "ly/061.xab"; } } //0xAFB304
			public override string AssetName { get { return "root_pop_item_detail_layout_root"; } } //0xAFB360
			public override GameObject Content { get { return m_content; } } //0xAFB3BC
		}

    public void Awake() { TodoLogger.Log(0, "Implement LayoutUGUIScriptBase"); }

		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			//throw new System.NotImplementedException();
		}

		public bool IsScrollable()
		{
			//throw new System.NotImplementedException();
			return true;
		}

		public void Show()
		{
			//throw new System.NotImplementedException();
		}

		public void Hide()
		{
			//throw new System.NotImplementedException();
		}

		public bool IsReady()
		{
			//throw new System.NotImplementedException();
			return true;
		}

		public void CallOpenEnd()
		{
			//throw new System.NotImplementedException();
		}

		[SerializeField]
		private RawImageEx m_itemIconImage;
		[SerializeField]
		private Text m_itemNameText;
		[SerializeField]
		private Text m_itemDescriptionText;
		[SerializeField]
		private Text m_decoSetCautionText;

		public Transform Parent => null; //throw new System.NotImplementedException();
	}
}
