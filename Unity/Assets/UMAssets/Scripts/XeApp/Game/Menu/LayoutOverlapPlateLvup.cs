using XeSys.Gfx;
using UnityEngine;
using System;
using XeApp.Game.Common;
using mcrs;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class LayoutOverlapPlateLvup : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_before; // 0x14
		[SerializeField]
		private RawImageEx m_beforeEf; // 0x18
		[SerializeField]
		private RawImageEx m_after; // 0x1C
		[SerializeField]
		private RawImageEx m_frameBefore; // 0x20
		[SerializeField]
		private RawImageEx m_frameBeforeEf; // 0x24
		[SerializeField]
		private RawImageEx m_frameAfter; // 0x28
		private AbsoluteLayout m_root; // 0x2C

		public Action CallbackAnimEnd { get; set; } // 0x30
		public bool IsOpen { get; private set; } // 0x34

		// RVA: 0x15D7AB0 Offset: 0x15D7AB0 VA: 0x15D7AB0
		public void SetStatus(GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo info, SceneCardTextureCache sceneCard, SceneFrameTextureCache sceneFrame)
		{
			if(info != null && info.BCCHOBPJJKE_SceneId != 0)
			{
				SetImageInner(sceneCard, m_before, info.BCCHOBPJJKE_SceneId, 1);
				SetImageInner(sceneCard, m_beforeEf, info.BCCHOBPJJKE_SceneId, 1);
				int rank = info.JKGFBFPIMGA_BaseRarity > 3 ? 2 : 1;
				SetImageInner(sceneCard, m_after, info.BCCHOBPJJKE_SceneId, rank);
				SetImageFrameInner(sceneFrame, m_frameBefore, GetSceneCardIdFromAttrId(info.BCCHOBPJJKE_SceneId), info.JKGFBFPIMGA_BaseRarity, 1);
				SetImageFrameInner(sceneFrame, m_frameBeforeEf, GetSceneCardIdFromAttrId(info.BCCHOBPJJKE_SceneId), info.JKGFBFPIMGA_BaseRarity, 1);
				SetImageFrameInner(sceneFrame, m_frameAfter, GetSceneCardIdFromAttrId(info.BCCHOBPJJKE_SceneId), info.JKGFBFPIMGA_BaseRarity, 2);
			}
				
		}

		// // RVA: 0x15D7C20 Offset: 0x15D7C20 VA: 0x15D7C20
		private int GetSceneCardIdFromAttrId(int cardId)
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[cardId - 1].FKDCCLPGKDK_Ma;
		}

		// // RVA: 0x15D7BA8 Offset: 0x15D7BA8 VA: 0x15D7BA8
		// public void SetBefore(SceneCardTextureCache sceneCard, int id, int rank) { }

		// // RVA: 0x15D7BD0 Offset: 0x15D7BD0 VA: 0x15D7BD0
		// public void SetBeforeEf(SceneCardTextureCache sceneCard, int id, int rank) { }

		// // RVA: 0x15D7BF8 Offset: 0x15D7BF8 VA: 0x15D7BF8
		// public void SetAfter(SceneCardTextureCache sceneCard, int id, int rank) { }

		// // RVA: 0x15D7DE0 Offset: 0x15D7DE0 VA: 0x15D7DE0
		private void SetImageInner(SceneCardTextureCache sceneCard, RawImageEx image, int id, int rank)
		{
			if(sceneCard != null)
			{
				if(image != null)
				{
					sceneCard.Load(id, rank, (IiconTexture texture) =>
					{
						//0x15D860C
						if(texture != null)
						{
							texture.Set(image);
						}
					});
				}
			}
		}

		// // RVA: 0x15D7D50 Offset: 0x15D7D50 VA: 0x15D7D50
		// public void SetFrameBefore(SceneFrameTextureCache sceneFrame, int attrId, int rank) { }

		// // RVA: 0x15D7D80 Offset: 0x15D7D80 VA: 0x15D7D80
		// public void SetFrameBeforeEf(SceneFrameTextureCache sceneFrame, int attrId, int rank) { }

		// // RVA: 0x15D7DB0 Offset: 0x15D7DB0 VA: 0x15D7DB0
		// public void SetFrameAfter(SceneFrameTextureCache sceneFrame, int attrId, int rank) { }

		// // RVA: 0x15D7F28 Offset: 0x15D7F28 VA: 0x15D7F28
		private void SetImageFrameInner(SceneFrameTextureCache sceneFrame, RawImageEx image, int attrId, int rank, int evolveId)
		{
			if(sceneFrame != null)
			{
				if(image != null)
				{
					sceneFrame.Load((GameAttribute.Type) attrId, rank, evolveId, (IiconTexture texture) =>
					{
						//0x15D86E8
						if(texture != null)
						{
							texture.Set(image);
						}
					});
				}
			}
		}

		// RVA: 0x15D8074 Offset: 0x15D8074 VA: 0x15D8074
		public void Reset()
		{
			IsOpen = false;
		}

		// RVA: 0x15D8080 Offset: 0x15D8080 VA: 0x15D8080
		public void In()
		{
			if(m_root != null && !IsOpen)
			{
				IsOpen = true;
				m_root.StartChildrenAnimGoStop("go_in", "st_in");
				SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_UNLOCK_005);
				this.StartCoroutineWatched(AnimInWait());
			}
		}

		// // RVA: 0x15D8208 Offset: 0x15D8208 VA: 0x15D8208
		// public void Out() { }

		// [IteratorStateMachineAttribute] // RVA: 0x70B45C Offset: 0x70B45C VA: 0x70B45C
		// // RVA: 0x15D8250 Offset: 0x15D8250 VA: 0x15D8250
		private IEnumerator OutInner()
		{
			//0x15D8A44
			m_root.StartChildrenAnimGoStop("go_out", "st_out");
			yield return Co.R(AnimOutWait());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70B4D4 Offset: 0x70B4D4 VA: 0x70B4D4
		// // RVA: 0x15D817C Offset: 0x15D817C VA: 0x15D817C
		private IEnumerator AnimInWait()
		{
			//0x15D87C8
			while(m_root.IsPlayingChildren())
				yield return null;
			yield return Co.R(OutInner());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70B54C Offset: 0x70B54C VA: 0x70B54C
		// // RVA: 0x15D831C Offset: 0x15D831C VA: 0x15D831C
		private IEnumerator AnimOutWait()
		{
			//0x15D88FC
			while(m_root.IsPlayingChildren())
				yield return null;
			DeleteImage(ref m_before);
			DeleteImage(ref m_beforeEf);
			DeleteImage(ref m_after);
			if(CallbackAnimEnd != null)
				CallbackAnimEnd();
			IsOpen = false;
		}

		// // RVA: 0x15D83C8 Offset: 0x15D83C8 VA: 0x15D83C8
		private void DeleteImage(ref RawImageEx image)
		{
			if(image != null)
			{
				image.material = null;
				image.MaterialMul = null;
				image.MaterialAdd = null;
				image.texture = null;
				image.alphaTexture = null;
			}
		}

		// RVA: 0x15D8518 Offset: 0x15D8518 VA: 0x15D8518 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.Root[0] as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
