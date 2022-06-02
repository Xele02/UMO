using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class CostumeSelectListElem : SwapScrollListContent
	{
		[SerializeField]
		public Text m_text_status;
		[SerializeField]
		public Text m_text_name;
		[SerializeField]
		public RawImageEx m_image_icon01;
		[SerializeField]
		public RawImageEx m_image_icon02;
		[SerializeField]
		public ActionButton m_btn_try;
		[SerializeField]
		public ActionButton m_btn_getinfo;
		public CostumeSelectListWin m_parent;
		public int m_index;
		public int m_diva_id;
		public int m_costume_id;
		public int m_costume_color;
		public int m_costume_model_id;
		public int m_item_id;
		public int m_lv;
		public int m_lv_max;
	}
}
