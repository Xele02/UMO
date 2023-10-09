using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class DivaFriendIconDecorationBehaviour : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_degreeIconImage; // 0x14
		[SerializeField]
		private RawImageEx m_friendIconImage; // 0x18
		[SerializeField]
		private RawImageEx m_fanIconImage; // 0x1C
		[SerializeField]
		private NumberBase m_degreeNumber; // 0x20
		[SerializeField]
		private List<RawImageEx> m_numberImages; // 0x24
		private AbsoluteLayout m_frienFanIcon; // 0x28
		private AbsoluteLayout m_frienFanAnimation; // 0x2C

		// RVA: 0x17DEA0C Offset: 0x17DEA0C VA: 0x17DEA0C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			ClearLoadedCallback();
			m_frienFanIcon = layout.FindViewById("swtbl_frefan_icon") as AbsoluteLayout;
			m_frienFanAnimation = layout.FindViewById("frefan_anim") as AbsoluteLayout;
			return true;
		}

		//// RVA: 0x17DEB5C Offset: 0x17DEB5C VA: 0x17DEB5C
		private void SetFriendIcon(bool isFriend)
		{
			m_friendIconImage.enabled = isFriend;
		}

		//// RVA: 0x17DEB90 Offset: 0x17DEB90 VA: 0x17DEB90
		private void SetFanIcon(bool isFan)
		{
			m_fanIconImage.enabled = isFan;
		}

		//// RVA: 0x17DEBC4 Offset: 0x17DEBC4 VA: 0x17DEBC4
		public void SetFriendFavoriteIcon(bool isFriend, bool isFavorite)
		{
			if(!isFriend || !isFavorite)
			{
				if(isFriend)
				{
					SetFriendIcon(true);
					SetFanIcon(false);
					m_frienFanIcon.StartChildrenAnimGoStop(0, 0);
				}
				else if(isFavorite)
				{
					SetFriendIcon(false);
					SetFanIcon(true);
					m_frienFanIcon.StartChildrenAnimGoStop(1, 1);
				}
				else
				{
					SetFriendIcon(false);
					SetFanIcon(false);
					m_frienFanIcon.StartChildrenAnimGoStop(3, 3);
				}
				return;
			}
			SetFriendIcon(true);
			SetFanIcon(true);
			m_frienFanIcon.StartChildrenAnimGoStop(2, 2);
			m_frienFanAnimation.StartChildrenAnimLoop(233, 1, 404);
		}

		//// RVA: 0x17DED18 Offset: 0x17DED18 VA: 0x17DED18
		public void FadeFrienFanAnimationSetFrame(int frame)
		{
			m_frienFanAnimation.StartChildrenAnimLoop(frame, 1, 404);
		}

		//// RVA: 0x17DED60 Offset: 0x17DED60 VA: 0x17DED60
		public void SetDegreeNumber(int number)
		{
			if(number < 1)
			{
				SetNumberImagesVisible(false);
				return;
			}
			SetNumberImagesVisible(true);
			m_degreeNumber.SetNumber(number, 0);
		}

		//// RVA: 0x17DEEAC Offset: 0x17DEEAC VA: 0x17DEEAC
		public void SetDegreeIcon(int emblemId)
		{
			if(emblemId != 1)
			{
				GameManager.Instance.ItemTextureCache.LoadEmblem(emblemId, (IiconTexture texture) =>
				{
					//0x17DF044
					m_degreeIconImage.enabled = true;
					texture.Set(m_degreeIconImage);
				});
				return;
			}
			m_degreeIconImage.enabled = false;
			m_degreeIconImage.material = null;
			m_degreeIconImage.texture = null;
		}

		//// RVA: 0x17DEDC8 Offset: 0x17DEDC8 VA: 0x17DEDC8
		private void SetNumberImagesVisible(bool isVisible)
		{
			for(int i = 0; i < m_numberImages.Count; i++)
			{
				m_numberImages[i].enabled = isVisible;
			}
		}
	}
}
