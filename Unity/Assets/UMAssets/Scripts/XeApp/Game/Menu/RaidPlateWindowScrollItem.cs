using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class RaidPlateWindowScrollItem : SwapScrollListContent
	{
		[SerializeField]
		private RawImageEx m_sceneIconImage; // 0x20
		private SceneIconDecoration m_sceneDecoration; // 0x24
		private short m_sceneId; // 0x28
		private short m_evolveId; // 0x2A
		private bool m_isKira; // 0x2C

		// RVA: 0x1BD8CB4 Offset: 0x1BD8CB4 VA: 0x1BD8CB4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_sceneDecoration = new SceneIconDecoration();
			m_sceneDecoration.Initialize(m_sceneIconImage.gameObject, SceneIconDecoration.Size.M, null, null);
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}

		// RVA: 0x1BD8300 Offset: 0x1BD8300 VA: 0x1BD8300
		public void UpdateContent(GCIJNCFDNON_SceneInfo sceneData)
		{
			m_sceneId = (short)sceneData.BCCHOBPJJKE_SceneId;
			m_evolveId = (short)sceneData.CGIELKDLHGE_GetEvolveId();
			m_isKira = sceneData.MBMFJILMOBP_IsKira();
			short sceneId = m_sceneId;
			short evolveId = m_evolveId;
			bool isKira = m_isKira;
			MenuScene.Instance.SceneIconCache.SetLoadingTexture(m_sceneIconImage);
			MenuScene.Instance.SceneIconCache.Load(m_sceneId, m_evolveId, (IiconTexture texture) =>
			{
				//0x1BD8DB8
				if(m_sceneId == sceneId)
				{
					if(m_evolveId == evolveId)
					{
						if(m_isKira == isKira)
						{
							texture.Set(m_sceneIconImage);
							SceneIconTextureCache.ChangeKiraMaterial(m_sceneIconImage, texture as IconTexture, isKira);
						}
					}
				}
			});
			m_sceneDecoration.Change(sceneData, DisplayType.Level);
		}

		// RVA: 0x1BD7C4C Offset: 0x1BD7C4C VA: 0x1BD7C4C
		public void Release()
		{
			m_sceneDecoration.Release();
		}
	}
}
