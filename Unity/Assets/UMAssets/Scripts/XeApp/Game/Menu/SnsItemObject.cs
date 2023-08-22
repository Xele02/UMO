using mcrs;
using System;
using System.Collections;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class SnsItemObject
	{
		public enum eLayoutType
		{
			None = 0,
			EntranceItem = 1,
			HeaderLine = 2,
			TalkR = 3,
			TalkL = 4,
			NextButton = 5,
			Unopened = 6,
		}

		public enum eAnimType
		{
			None = 0,
			Wait = 1,
			In = 2,
		}
		
		public eLayoutType type; // 0x8
		public eAnimType animType = eAnimType.Wait; // 0xC
		public Vector3 pos; // 0x10
		public Vector3 size; // 0x1C
		public SNSTalkCreater.ViewTalk viewTalk; // 0x28
		public GAKAAIHLFKI viewDataRoom; // 0x2C
		public LayoutSNSRoomItem entranceItem; // 0x30
		public LayoutSNSTalkRight talkWindowR; // 0x34
		public LayoutSNSTalkLeft talkWindowL; // 0x38
		public LayoutSNSHeadline headLine; // 0x3C
		public LayoutSNSNextButton nextButton; // 0x40
		public LayoutSNSUnopened Unopened; // 0x44
		public LayoutSNSBase layoutBase; // 0x48
		public Action<int> entranceCallback; // 0x4C
		public bool isPlaySe; // 0x50
		public bool isPlaySeItemIn; // 0x51

		//// RVA: 0x12D0AA8 Offset: 0x12D0AA8 VA: 0x12D0AA8
		public void SetStatus(SnsItemObject obj)
		{
			if(type == eLayoutType.EntranceItem)
			{
				if(layoutBase != null)
				{
					layoutBase.SetPosition(obj.pos.x, obj.pos.y, obj.size.y);
					layoutBase.SetStatus(viewDataRoom, entranceCallback);
					return;
				}
			}
			else if(type >= eLayoutType.HeaderLine && type <= eLayoutType.Unopened)
			{
				if(layoutBase != null)
				{
					layoutBase.SetPosition(obj.pos.x, obj.pos.y);
					layoutBase.SetStatus(viewTalk);
				}
			}
		}

		//// RVA: 0x12D0D04 Offset: 0x12D0D04 VA: 0x12D0D04
		public void Show()
		{
			if (type < eLayoutType.EntranceItem || type > eLayoutType.Unopened)
				return;
			if (layoutBase == null)
				return;
			if(animType == eAnimType.In)
			{
				layoutBase.SePlayEnable = isPlaySe;
				isPlaySe = false;
				animType = eAnimType.Wait;
				layoutBase.In();
			}
			else
			{
				layoutBase.Show();
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72A5BC Offset: 0x72A5BC VA: 0x72A5BC
		//// RVA: 0x12D0E40 Offset: 0x12D0E40 VA: 0x12D0E40
		public IEnumerator PlayInItemSe()
		{
			//0x12D10F0
			if (type >= eLayoutType.HeaderLine && type < eLayoutType.NextButton && isPlaySeItemIn)
				SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_SNS_002);
			yield break;
		}

		//// RVA: 0x12D0EEC Offset: 0x12D0EEC VA: 0x12D0EEC
		public void Hide()
		{
			if(type >= eLayoutType.EntranceItem && type <= eLayoutType.Unopened)
			{
				if (layoutBase != null)
					layoutBase.Hide();
			}
			if (type >= eLayoutType.HeaderLine && type <= eLayoutType.TalkL)
				isPlaySeItemIn = true;
		}

		//// RVA: 0x12D0FCC Offset: 0x12D0FCC VA: 0x12D0FCC
		public void Clear()
		{
			type = eLayoutType.None;
			animType = eAnimType.Wait;
			pos = Vector3.zero;
			size = Vector3.zero;
			if(viewTalk != null)
			{
				viewTalk.talk = null;
				viewTalk.chara = null;
			}
			layoutBase = null;
			viewTalk = null;
			isPlaySe = false;
			nextButton = null;
			entranceItem = null;
			talkWindowR = null;
			talkWindowL = null;
			headLine = null;
		}
	}
}
