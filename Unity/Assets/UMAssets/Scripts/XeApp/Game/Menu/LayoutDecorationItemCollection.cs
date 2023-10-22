using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationItemCollection : LayoutUGUIScriptBase
	{
		public enum BaseFrame
		{
			Exclamation = 0,
			Medal = 1,
			Point = 2,
			Item = 3,
			None = 4,
			Voice = 5,
		}

		public static readonly string AssetName = "root_deco_item_collection_layout_root"; // 0x0
		[SerializeField]
		private NumberBase m_itemNum; // 0x14
		[SerializeField]
		private NumberBase m_pointNum; // 0x18
		[SerializeField]
		private RawImageEx m_medalImage; // 0x1C
		[SerializeField]
		private RawImageEx m_pointImage; // 0x20
		[SerializeField]
		private ActionButton m_button; // 0x24
		private AbsoluteLayout m_base; // 0x28
		private AbsoluteLayout m_exclamationAnim; // 0x2C
		private AbsoluteLayout m_medalAnim; // 0x30
		private AbsoluteLayout m_itemAnim; // 0x34
		private AbsoluteLayout m_pointAnim; // 0x38
		private AbsoluteLayout m_voiceAnim; // 0x3C
		private NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC m_type; // 0x40
		private int m_num; // 0x44
		private bool IsEnter; // 0x48
		private Vector2 m_position; // 0x4C
		private Coroutine m_positionMoveCoroutine; // 0x54
		private RectTransform m_rectTransform; // 0x58
		//[CompilerGeneratedAttribute] // RVA: 0x66BC08 Offset: 0x66BC08 VA: 0x66BC08
		public Action PushButtonListener; // 0x5C

		public bool IsPlayingReceiveAnime { get; private set; } // 0x60
		public bool IsLeavngAnime { get; private set; } // 0x61

		// RVA: 0x19F15DC Offset: 0x19F15DC VA: 0x19F15DC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_rectTransform = GetComponent<RectTransform>();
			m_base = layout.FindViewById("swtbl_deco_sp_al") as AbsoluteLayout;
			m_exclamationAnim = layout.FindViewById("sw_deco_sp_frm_02_01_anim") as AbsoluteLayout;
			m_medalAnim = layout.FindViewById("sw_deco_sp_frm_02_02_anim") as AbsoluteLayout;
			m_itemAnim = layout.FindViewById("sw_b02_24p_item_anim") as AbsoluteLayout;
			m_pointAnim = layout.FindViewById("sw_b02_24p_anim") as AbsoluteLayout;
			m_voiceAnim = layout.FindViewById("sw_deco_sp_icon_02_anim") as AbsoluteLayout;
			return true;
		}

		// // RVA: 0x19F191C Offset: 0x19F191C VA: 0x19F191C
		public void Show()
		{
			if(IsEnter)
				return;
			int start = 0;
			if(m_type < NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.JJNIMNEJPOF_3/*3*/)
			{
				if(m_type == NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.FIHMIDDLAKH_CanonFillSp/*1*/)
					start = 0;
				else
				{
					start = 1;
					if(m_type != NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.IOEGFJMNDBM_2/*2*/)
					{
						start = 5;
						if(m_type != NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.FKEDBMECLJG_12/*12*/)
							start = 4;
					}
				}
			}
			else if(m_type == NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.JJNIMNEJPOF_3/*3*/ ||
				m_type == NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.JPPOGMHJKKJ_VisitItemSp/*11*/)
			{
				start = 0;
			}
			else
			{
				start = 5;
				if(m_type != NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.FKEDBMECLJG_12/*12*/)
					start = 4;
			}
			m_base.StartChildrenAnimGoStop(start, start);
			switch(m_type)
			{
				case NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.FIHMIDDLAKH_CanonFillSp/*1*/:
				case NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.JJNIMNEJPOF_3/*3*/:
				case NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.JPPOGMHJKKJ_VisitItemSp/*11*/:
					m_exclamationAnim.StartChildrenAnimLoop("logo_on", "loen_on");
					break;
				case NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.IOEGFJMNDBM_2/*2*/:
					m_medalAnim.StartChildrenAnimLoop("logo_on", "loen_on");
					break;
				default:
					break;
				case NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.FKEDBMECLJG_12/*12*/:
					m_voiceAnim.StartChildrenAnimGoStop("go_in", "st_in");
					break;
			}
			IsEnter = true;
			if(m_positionMoveCoroutine != null)
				return;
			this.StartCoroutineWatched(Co_PositionMove());
		}

		// // RVA: 0x19F1BE8 Offset: 0x19F1BE8 VA: 0x19F1BE8
		public bool IsShow()
		{
			return IsEnter;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6D6464 Offset: 0x6D6464 VA: 0x6D6464
		// // RVA: 0x19F1B5C Offset: 0x19F1B5C VA: 0x19F1B5C
		private IEnumerator Co_PositionMove()
		{
			//0x19F255C
			m_position = m_rectTransform.anchoredPosition;
			m_rectTransform.anchoredPosition = new Vector2(0, 1000);
			yield return null;
			m_rectTransform.anchoredPosition = m_position;
			m_positionMoveCoroutine = null;
		}

		// // RVA: 0x19F1C10 Offset: 0x19F1C10 VA: 0x19F1C10
		public void Leave()
		{
			if(!IsEnter)
				return;
			if(IsLeavngAnime)
				return;
			this.StartCoroutineWatched(Co_Leave());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6D64DC Offset: 0x6D64DC VA: 0x6D64DC
		// // RVA: 0x19F1C5C Offset: 0x19F1C5C VA: 0x19F1C5C
		private IEnumerator Co_Leave()
		{
			//0x19F2298
			if(m_type == NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.FKEDBMECLJG_12)
			{
				AbsoluteLayout playingLayout = m_voiceAnim;
				m_voiceAnim.StartChildrenAnimGoStop("go_out", "st_out");
				yield return new WaitWhile(() =>
				{
					//0x19F2258
					return playingLayout != null && playingLayout.IsPlayingChildren();
				});
				IsLeavngAnime = false;
				Off();
			}
			else
			{
				IsLeavngAnime = false;
				Off();
			}
		}

		// // RVA: 0x19F1D08 Offset: 0x19F1D08 VA: 0x19F1D08
		public void Receive(int value, IiconTexture texture)
		{
			BaseFrame frame = BaseFrame.None;
			if(m_type < NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.JJNIMNEJPOF_3)
			{
				if(m_type == NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.FIHMIDDLAKH_CanonFillSp)
				{
					IsPlayingReceiveAnime = false;
					Off();
					return;
				}
				if(m_type == NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.IOEGFJMNDBM_2)
				{
					m_pointNum.SetNumber(value, 0);
					frame = BaseFrame.Point;
				}
			}
			else if(m_type == NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.JJNIMNEJPOF_3 || m_type == NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.JPPOGMHJKKJ_VisitItemSp)
			{
				m_itemNum.SetNumber(value, 0);
				frame = BaseFrame.Item;
			}
			this.StartCoroutineWatched(Co_Receive(frame));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6D6554 Offset: 0x6D6554 VA: 0x6D6554
		// // RVA: 0x19F1E24 Offset: 0x19F1E24 VA: 0x19F1E24
		private IEnumerator Co_Receive(BaseFrame frame)
		{
			AbsoluteLayout currentLayout;

			//0x19F2738
			IsPlayingReceiveAnime = true;
			m_base.StartChildrenAnimGoStop((int)frame, (int)frame);
			currentLayout = null;
			if(m_type >= NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.FIHMIDDLAKH_CanonFillSp && m_type < NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.JJNIMNEJPOF_3)
			{
				m_pointAnim.StartChildrenAnimGoStop("st_wait", "st_out");
				currentLayout = m_pointAnim;
			}
			else if(((int)m_type | 8) == 11)
			{
				m_itemAnim.StartChildrenAnimGoStop("st_wait", "st_out");
				currentLayout = m_itemAnim;
			}
			else yield break;
			while(currentLayout.IsPlayingChildren())
				yield return null;
			IsPlayingReceiveAnime = false;
			Off();
		}

		// // RVA: 0x19F1DE0 Offset: 0x19F1DE0 VA: 0x19F1DE0
		public void Off()
		{
			m_base.StartChildrenAnimGoStop(4, 4);
			IsLeavngAnime = false;
			IsEnter = false;
		}

		// // RVA: 0x19F1EEC Offset: 0x19F1EEC VA: 0x19F1EEC
		public void SetSetting(NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC type, float offsetY)
		{
			m_type = type;
			transform.localPosition = new Vector2(0, offsetY);
			IsEnter = false;
		}

		// // RVA: 0x19F2000 Offset: 0x19F2000 VA: 0x19F2000
		public void SetMedalTexture(IiconTexture texture)
		{
			texture.Set(m_medalImage);
		}

		// // RVA: 0x19F20E0 Offset: 0x19F20E0 VA: 0x19F20E0
		public void SetPointTexture(IiconTexture texture)
		{
			texture.Set(m_pointImage);
		}

		// // RVA: 0x19F1B14 Offset: 0x19F1B14 VA: 0x19F1B14
		// private LayoutDecorationItemCollection.BaseFrame GetBaseFrame() { }

		// // RVA: 0x19F21C0 Offset: 0x19F21C0 VA: 0x19F21C0
		// private void OnPushButton() { }
	}
}
