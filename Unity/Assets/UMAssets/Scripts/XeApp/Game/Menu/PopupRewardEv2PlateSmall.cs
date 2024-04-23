using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupRewardEv2PlateSmall : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text info; // 0x14
		[SerializeField]
		private Text plateName; // 0x18
		[SerializeField]
		private RawImageEx plateImage; // 0x1C
		[SerializeField]
		private StayButton btn; // 0x20

		// RVA: 0x1A642F4 Offset: 0x1A642F4 VA: 0x1A642F4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			return true;
		}

		// RVA: 0x1A642FC Offset: 0x1A642FC VA: 0x1A642FC
		public void Setup(PopupRewardEv2ItemLayout.ViewPlateData data)
		{
			MenuScene.Instance.SceneIconCache.Load(data.plateNo, data.data.JOKJBMJBLBB_Single ? 2 : 1, (IiconTexture texture) =>
			{
				//0x1A64590
				texture.Set(plateImage);
			});
			GCIJNCFDNON_SceneInfo scene = new GCIJNCFDNON_SceneInfo();
			scene.KHEKNNFCAOI(data.plateNo, null, null, 0, 0, 0, false, 0, 0);
			plateName.text = scene.OPFGFINHFCE_SceneName;
			info.text = JpStringLiterals.StringLiteral_19433;
		}

		// RVA: 0x1A64580 Offset: 0x1A64580 VA: 0x1A64580
		public StayButton GetBtn()
		{
			return btn;
		}
	}
}
