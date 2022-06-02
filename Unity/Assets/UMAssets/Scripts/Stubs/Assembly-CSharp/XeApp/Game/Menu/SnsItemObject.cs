using UnityEngine;

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

		public eLayoutType type;
		public eAnimType animType;
		public Vector3 pos;
		public Vector3 size;
		public LayoutSNSRoomItem entranceItem;
		public LayoutSNSTalkRight talkWindowR;
		public LayoutSNSTalkLeft talkWindowL;
		public LayoutSNSHeadline headLine;
		public LayoutSNSNextButton nextButton;
		public LayoutSNSUnopened Unopened;
		public LayoutSNSBase layoutBase;
		public bool isPlaySe;
		public bool isPlaySeItemIn;
	}
}
