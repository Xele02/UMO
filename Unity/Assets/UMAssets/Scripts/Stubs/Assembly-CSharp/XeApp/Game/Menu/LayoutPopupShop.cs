using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutPopupShop : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_textName;
		[SerializeField]
		private Text m_textRemain;
		[SerializeField]
		private Text m_textCount;
		[SerializeField]
		private Text[] m_textOwn4d;
		[SerializeField]
		private Text[] m_textOwn8d;
		[SerializeField]
		private Text[] m_textContent;
		[SerializeField]
		private Text m_textOwnCoin;
		[SerializeField]
		private Text m_textOwnCoinNum;
		[SerializeField]
		private Text m_textCostCoin;
		[SerializeField]
		private Text m_textCostCoinNum;
		[SerializeField]
		private Text[] m_textWarning;
		[SerializeField]
		private RawImageEx[] m_imageItem;
		[SerializeField]
		private RawImageEx m_imagePlate;
		[SerializeField]
		private RawImageEx m_imageCost;
		[SerializeField]
		private ActionButton m_buttonItem;
		[SerializeField]
		private ActionButton m_buttonPlate;
		[SerializeField]
		private ActionButton m_buttonPuls1;
		[SerializeField]
		private ActionButton m_buttonPuls10;
		[SerializeField]
		private ActionButton m_buttonMinus1;
		[SerializeField]
		private ActionButton m_buttonMinus10;
		[SerializeField]
		private SwapScrollList m_swapScrollList;
	}
}
