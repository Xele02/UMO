using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class HomeBgSelectListTermsPopup : MonoBehaviour, IPopupContent
	{
		public class Setting : PopupSetting
		{
			public int m_bg_id { get; set; } // 0x34
			public string m_text { get; set; } // 0x38
			public override bool IsPreload { get { return false; } } //0x95C970
			public override bool IsAssetBundle { get { return true; } } //0x95C978
			public override string PrefabPath { get { return ""; } } //0x95C980
			public override string BundleName { get { return "ly/226.xab"; } } //0x95C9DC
			public override string AssetName { get { return "SelectBgListTermPopup"; } } //0x95CA38
			public override GameObject Content { get { return m_content; } } //0x95CA94
		}

		public Text m_text;
		public RawImageEx m_image;

		public Transform Parent => null; //throw new System.NotImplementedException();

		public void CallOpenEnd()
		{
			//throw new System.NotImplementedException();
		}

		public void Hide()
		{
			//throw new System.NotImplementedException();
		}

		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			//throw new System.NotImplementedException();
		}

		public bool IsReady()
		{
			//throw new System.NotImplementedException();
			return true;
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

		private void Awake()
		{
			TodoLogger.LogError(0, "Implement Monobehaviour");
		}
	}
}
