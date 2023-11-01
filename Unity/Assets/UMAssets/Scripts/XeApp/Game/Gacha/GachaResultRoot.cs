using XeSys.Gfx;
using System.Collections.Generic;
using UnityEngine;
using System;
using XeApp.Game.Common;

namespace XeApp.Game.Gacha
{
	public class GachaResultRoot : LayoutLabelScriptBase
	{
		public delegate void InitNewIconDeco(int index, GameObject go);

		[SerializeField]
		private List<GachaResultCard> m_cards; // 0x18
		private int m_usingCardNum; // 0x1C

		// private bool isMultiCard { get; } 0x98FB24
		public Action<int> onClickCard { private get; set; } // 0x20

		// RVA: 0x98C6D0 Offset: 0x98C6D0 VA: 0x98C6D0
		public void Setup(GachaDirectionResource resource, DirectionInfo directionInfo, InitNewIconDeco initNewIconDeco)
		{
			for(int i = 0; i < directionInfo.cardNum; i++)
			{
				CardInfo info = directionInfo.GetCardInfo(i);
				m_cards[i].SetStyle(info.starNum, info.isNew);
				m_cards[i].SetCardTexture(resource.resultCardTex[i]);
				m_cards[i].SetFrameTexture(resource.resultCardFrameTex[i]);
				m_cards[i].LeaveImmediately();
				initNewIconDeco(i, m_cards[i].newDecoRoot.gameObject);
			}
			m_usingCardNum = directionInfo.cardNum;
		}

		// RVA: 0x98D4F4 Offset: 0x98D4F4 VA: 0x98D4F4
		public bool IsPlaying()
		{
			for(int i = 0; i < m_usingCardNum; i++)
			{
				if(m_cards[i].IsPlaying())
					return true;
			}
			return false;
		}

		// RVA: 0x98877C Offset: 0x98877C VA: 0x98877C
		public void Enter()
		{
			for(int i = 0; i < m_usingCardNum; i++)
			{
				m_cards[i].Enter();
			}
		}

		// RVA: 0x98A37C Offset: 0x98A37C VA: 0x98A37C
		public void Leave()
		{
			for(int i = 0; i < m_usingCardNum; i++)
			{
				m_cards[i].Leave();
			}
		}

		// RVA: 0x990038 Offset: 0x990038 VA: 0x990038 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			for(int i = 0; i < m_cards.Count; i++)
			{
				m_cards[i].onClick = (GachaResultCard card) =>
				{
					//0x990198
					if(onClickCard != null)
						onClickCard(card.cardIndex);
				};
			}
			Loaded();
			return true;
		}
	}
}
