using System.Collections;
using UnityEngine;
using XeApp.Game.Menu;
using XeSys.Gfx;

namespace XeApp
{
	public class DecorationSp : DecorationItemBase
	{
		private enum LevelupIconStatus
		{
			Wait = 0,
			Active = 1,
		}

		private LayoutDecorationItemCollection m_popupIcon; // 0x9C
		protected LayoutDecorationItemCollection m_layoutDecorationItemCollection; // 0xA0
		private LayoutUGUIRuntime m_levelUpObject; // 0xA4
		private AbsoluteLayout m_levelUpAnime; // 0xA8
		private bool IsLoadedSpResource; // 0xAC
		protected IiconTexture m_texture; // 0xB0
		protected int m_num; // 0xB4
		private LevelupIconStatus m_levelupIconStatus; // 0xB8

		public override bool IsLoaded { get { return IsLoaded && IsLoadedSpResource; } } //0xBB2E5C
		public NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC SpType { get { return (NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC)ViewData.GBJFNGCDKPM; } } //0xBB2E90

		// RVA: 0xBB2EC4 Offset: 0xBB2EC4 VA: 0xBB2EC4 Slot: 6
		protected override void PostLoadResource(GameObject spriteBase, EKLNMHFCAOI.FKGCBLHOOCL_Category itemCategory, int id, DecorationItemBaseSetting setting, DecorationItemArgsBase args)
		{
			IsLoadedSpResource = false;
			this.StartCoroutineWatched(Co_LoadSpResource());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6AC5B8 Offset: 0x6AC5B8 VA: 0x6AC5B8
		// // RVA: 0xBB2EF4 Offset: 0xBB2EF4 VA: 0xBB2EF4
		private IEnumerator Co_LoadSpResource()
		{
			//0xBB49CC
			yield return new WaitUntil(() =>
			{
				//0xBB4418
				return IsLoaded;
			});
			m_texture = null;
			yield return this.StartCoroutineWatched(Co_LoadTexture());
			yield return this.StartCoroutineWatched(Co_LoadLayout());
			IsLoadedSpResource = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6AC630 Offset: 0x6AC630 VA: 0x6AC630
		// // RVA: 0xBB2FA0 Offset: 0xBB2FA0 VA: 0xBB2FA0
		protected IEnumerator Co_LoadTexture()
		{
			//0xBB4C5C
			bool isLoadedTexture = true;
			if(SpType == NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.JPPOGMHJKKJ_11/*11*/)
			{
				isLoadedTexture = false;
				MenuScene.Instance.ItemTextureCache.Load(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 8), (IiconTexture texture) =>
				{
					//0xBB4490
					m_texture = texture;
					isLoadedTexture = true;
				});
			}
			else if(SpType == NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.JJNIMNEJPOF_3/*3*/)
			{
				isLoadedTexture = false;
				MenuScene.Instance.ItemTextureCache.Load(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 8), (IiconTexture texture) =>
				{
					//0xBB445C
					m_texture = texture;
					isLoadedTexture = true;
				});
			}
			else if(SpType == NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.IOEGFJMNDBM_2/*2*/)
			{
				isLoadedTexture = false;
				MenuScene.Instance.ItemTextureCache.Load(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ICICKEBMEFA_Medal.DNEKJCKEOHL_GetMonthlyItemFullId(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime()), (IiconTexture texture) =>
				{
					//0xBB4428
					m_texture = texture;
					isLoadedTexture = true;
				});
			}
			yield return new WaitUntil(() =>
			{
				//0xBB44C4
				return isLoadedTexture;
			});
			yield return null;
		}

		// RVA: 0xBB304C Offset: 0xBB304C VA: 0xBB304C Slot: 9
		protected override void PostInitController()
		{
			if(SpType != NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.JPPOGMHJKKJ_11/*11*/)
				return;
			m_decorationContoller.onBeginDrag = null;
			m_decorationContoller.onDrag = null;
			m_decorationContoller.onPointerUp = null;
		}

		// RVA: 0xBB30B8 Offset: 0xBB30B8 VA: 0xBB30B8 Slot: 16
		protected override void PreDestroy()
		{
			if(m_levelUpObject != null)
			{
				m_decoCanvas.ItemManager.FreeCache(DecorationItemManager.LayoutCachaName.SpItemLeveupIcon, m_levelUpObject.gameObject);
			}
			if(m_layoutDecorationItemCollection != null)
			{
				m_decoCanvas.ItemManager.FreeCache(DecorationItemManager.LayoutCachaName.SpItemPopIcon, m_layoutDecorationItemCollection.gameObject);
			}
			FreePopupIcon();
		}

		// RVA: 0xBB33A0 Offset: 0xBB33A0 VA: 0xBB33A0 Slot: 17
		protected override void PostDestroy()
		{
			return;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6AC6A8 Offset: 0x6AC6A8 VA: 0x6AC6A8
		// // RVA: 0xBB33A4 Offset: 0xBB33A4 VA: 0xBB33A4
		public IEnumerator Co_LoadLayout()
		{
			//0xBB44D0
			if(SpType < NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.JJNIMNEJPOF_3/*3*/)
			{
				m_levelUpObject = m_decoCanvas.ItemManager.AllocCache(DecorationItemManager.LayoutCachaName.SpItemLeveupIcon).GetComponent<LayoutUGUIRuntime>();
				m_levelUpObject.transform.SetParent(m_object.transform, false);
				m_layoutDecorationItemCollection = m_decoCanvas.ItemManager.AllocCache(DecorationItemManager.LayoutCachaName.SpItemPopIcon).GetComponent<LayoutDecorationItemCollection>();
				m_layoutDecorationItemCollection.transform.SetParent(m_object.transform, false);
			}
			else if(SpType == NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.JPPOGMHJKKJ_11/*11*/)
			{
				m_layoutDecorationItemCollection = m_decoCanvas.ItemManager.AllocCache(DecorationItemManager.LayoutCachaName.SpItemPopIcon).GetComponent<LayoutDecorationItemCollection>();
				m_layoutDecorationItemCollection.transform.SetParent(m_object.transform, false);
				m_layoutDecorationItemCollection.Off();
			}
			SettingAfterLoadLayout();
			m_levelupIconStatus = LevelupIconStatus.Wait;
			IsLoadedSpResource = true;
			yield break;
		}

		// // RVA: 0xBB3450 Offset: 0xBB3450 VA: 0xBB3450
		protected void SettingAfterLoadLayout()
		{
			if(SpType == NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.FIHMIDDLAKH_1/*1*/)
			{
				m_layoutDecorationItemCollection.SetSetting(SpType, Size.y * 0.5f);
			}
			else if(SpType == NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.IOEGFJMNDBM_2/*2*/)
			{
				m_layoutDecorationItemCollection.SetSetting(SpType, Size.y * 0.5f);
				m_layoutDecorationItemCollection.SetMedalTexture(m_texture);
			}
			else if(SpType == NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.JJNIMNEJPOF_3/*3*/
				|| SpType == NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.JPPOGMHJKKJ_11/*11*/)
			{
				m_layoutDecorationItemCollection.SetSetting(SpType, Size.y * 0.5f);
				m_layoutDecorationItemCollection.SetPointTexture(m_texture);
			}
		}

		// // RVA: 0xBB35E0 Offset: 0xBB35E0 VA: 0xBB35E0
		public void ShowReceiveAnime(int value)
		{
			if(m_layoutDecorationItemCollection != null)
				m_layoutDecorationItemCollection.Receive(value, m_texture);
		}

		// // RVA: 0xBB36A4 Offset: 0xBB36A4 VA: 0xBB36A4
		public void HideLevelUpIcon()
		{
			if(m_levelUpObject != null)
				m_levelUpObject.gameObject.SetActive(false);
			m_levelupIconStatus = 0;
		}

		// // RVA: 0xBB3784 Offset: 0xBB3784 VA: 0xBB3784
		private void AllocPopupIcon()
		{
			if(m_popupIcon == null)
			{
				m_popupIcon = m_decoCanvas.ItemManager.AllocCache(DecorationItemManager.LayoutCachaName.SpItemPopIcon).GetComponent<LayoutDecorationItemCollection>();
				m_popupIcon.transform.SetParent(m_object.transform, false);
				m_popupIcon.Off();
				m_popupIcon.SetSetting(SpType, Size.y * 0.5f);
			}
		}

		// // RVA: 0xBB328C Offset: 0xBB328C VA: 0xBB328C
		private void FreePopupIcon()
		{
			if(m_popupIcon != null)
			{
				m_decoCanvas.ItemManager.FreeCache(DecorationItemManager.LayoutCachaName.SpItemPopIcon, m_popupIcon.gameObject);
				m_popupIcon = null;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6AC720 Offset: 0x6AC720 VA: 0x6AC720
		// // RVA: 0xBB3984 Offset: 0xBB3984 VA: 0xBB3984
		private IEnumerator Co_WaitAndFreePopupIcon()
		{
			//0xBB523C
			while(m_popupIcon != null && m_popupIcon.IsLeavngAnime)
				yield return null;
			FreePopupIcon();
		}

		// // RVA: 0xBB3A30 Offset: 0xBB3A30 VA: 0xBB3A30
		public void ShowPopupIcon()
		{
			AllocPopupIcon();
			if(m_popupIcon == null)
				return;
			m_popupIcon.gameObject.SetActive(true);
			m_popupIcon.Show();
		}

		// // RVA: 0xBB3B30 Offset: 0xBB3B30 VA: 0xBB3B30
		public void LeavePopupIcon()
		{
			if(m_popupIcon == null)
				return;
			m_popupIcon.Leave();
			this.StartCoroutineWatched(Co_WaitAndFreePopupIcon());
		}

		// // RVA: 0xBB3BFC Offset: 0xBB3BFC VA: 0xBB3BFC
		public void HidePopupIcon()
		{
			if(m_popupIcon != null)
			{
				m_popupIcon.Off();
				m_popupIcon.gameObject.SetActive(false);
				this.StartCoroutineWatched(Co_WaitAndFreePopupIcon());
			}
		}

		// // RVA: 0xBB3D0C Offset: 0xBB3D0C VA: 0xBB3D0C
		public void SetIconHide()
		{
			if(m_layoutDecorationItemCollection != null)
				m_layoutDecorationItemCollection.Off();
		}

		// // RVA: 0xBB3DC0 Offset: 0xBB3DC0 VA: 0xBB3DC0
		public bool IsShowIcon()
		{
			if(m_layoutDecorationItemCollection != null)
				return m_layoutDecorationItemCollection.IsShow();
			return false;
		}

		// // RVA: 0xBB3E78 Offset: 0xBB3E78 VA: 0xBB3E78
		public bool IsPlayingReceiveAnime()
		{
			if(m_layoutDecorationItemCollection != null)
				return m_layoutDecorationItemCollection.IsPlayingReceiveAnime;
			return false;
		}

		// RVA: 0xBB3F30 Offset: 0xBB3F30 VA: 0xBB3F30
		private void Update()
		{
			if(IsLoaded)
			{
				if(m_decoCanvas.ItemManager.m_controlType == DecorationItemManager.EnableControlType.Unique)
				{
					if(m_layoutDecorationItemCollection != null)
					{
						if(!m_layoutDecorationItemCollection.IsPlayingReceiveAnime && IsReceivableSpItem())
						{
							m_layoutDecorationItemCollection.gameObject.SetActive(true);
							m_layoutDecorationItemCollection.Show();
						}
					}
					if(m_levelupIconStatus == LevelupIconStatus.Wait)
					{
						if(!IsAvailableLevelUp())
							return;
						m_levelUpObject.gameObject.SetActive(true);
						m_levelUpObject.Layout.StartAllAnimLoop("logo_on", "loen_on");
						m_levelupIconStatus = LevelupIconStatus.Active;
					}
				}
			}
		}

		// // RVA: 0xBB419C Offset: 0xBB419C VA: 0xBB419C
		public bool IsReceivableSpItem()
		{
			if(SpType == NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.HJNNKCMLGFL/*0*/ || 
				SpType > NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.JJNIMNEJPOF_3/*3*/)
			{
				return SpType == NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.JPPOGMHJKKJ_11/*11*/;
			}
			return KDKFHGHGFEK.HMDOAKPBLFL(ResourceId, KDKFHGHGFEK.DFMGMEDILKB(ResourceId), NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
		}

		// // RVA: 0xBB4328 Offset: 0xBB4328 VA: 0xBB4328
		protected bool IsAvailableLevelUp()
		{
			return KDKFHGHGFEK.HMAOJBKJIOJ(ResourceId, KDKFHGHGFEK.DFMGMEDILKB(ResourceId), m_decoCanvas.GetHaveDecorationItemCount());
		}
	}
}
