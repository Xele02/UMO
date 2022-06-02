using XeSys.Gfx;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class OfferGetItemLayout : LayoutUGUIScriptBase
	{
		public float nextItemMoveSec;
		public float backItemMoveSec;
		[SerializeField]
		public float itemBonusCountupSec;
		[SerializeField]
		private List<RawImageEx> BonusItemIcon;
		[SerializeField]
		private Text textRareItemNum;
		[SerializeField]
		private Text textNomralItemNum;
		[SerializeField]
		private Text textConfirmItemNum;
		[SerializeField]
		private Text[] textScoreRankBonus;
		[SerializeField]
		private NumberBase numberTotalUC;
		[SerializeField]
		private Text textConvertUC;
		[SerializeField]
		private LayoutUGUIScrollSupport scrollSupporter;
		public bool IsAutoScrolling;
	}
}
