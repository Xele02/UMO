using XeApp.Game.Common;
using System;
using UnityEngine.UI;
using XeSys.Gfx;
using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Menu
{
	internal class UnitBonusContent : SwapScrollListContent
	{
		[Serializable]
		public class BonusCell
		{
			public ActionButton button1;
			public ActionButton button2;
			public ActionButton button3;
			public Text nameText1;
			public Text nameText2;
			public Text nameText3;
			public Text bonusText1;
			public Text bonusText2;
			public Text bonusText3;
			public Text bonusMaxText1;
			public Text bonusMaxText2;
			public Text bonusMaxText3;
			public Text bonusAssist1;
			public RawImageEx sceneImage;
			public RawImageEx cosImage1;
			public RawImageEx cosImage2;
			public RawImageEx cosImage3;
			public RawImageEx valImage1;
			public RawImageEx valImage2;
			public RawImageEx valImage3;
		}

		[SerializeField]
		private List<UnitBonusContent.BonusCell> m_bonusCellList;
	}
}
