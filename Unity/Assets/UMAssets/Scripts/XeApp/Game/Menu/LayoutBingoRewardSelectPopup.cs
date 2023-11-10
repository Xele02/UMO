using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutBingoRewardSelectPopup : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx SceneIcon; // 0x14
		[SerializeField]
		private Text AttentionText; // 0x18
		private bool m_IsLoaded; // 0x1C

		// RVA: 0x14C98D0 Offset: 0x14C98D0 VA: 0x14C98D0
		private void Start()
		{
			return;
		}

		// RVA: 0x14C98D4 Offset: 0x14C98D4 VA: 0x14C98D4
		private void Update()
		{
			return;
		}

		// RVA: 0x14C98D8 Offset: 0x14C98D8 VA: 0x14C98D8
		public void Setup(int sceneId, int rare, string message)
		{
			m_IsLoaded = false;
			GameManager.Instance.SceneIconCache.Load(sceneId, rare, (IiconTexture scnen) =>
			{
				//0x14C9A5C
				scnen.Set(SceneIcon);
				m_IsLoaded = true;
			});
			AttentionText.text = message;
		}

		// RVA: 0x14C9A34 Offset: 0x14C9A34 VA: 0x14C9A34
		public bool IsLoaded()
		{
			return m_IsLoaded;
		}

		// RVA: 0x14C9A3C Offset: 0x14C9A3C VA: 0x14C9A3C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			return true;
		}
	}
}
