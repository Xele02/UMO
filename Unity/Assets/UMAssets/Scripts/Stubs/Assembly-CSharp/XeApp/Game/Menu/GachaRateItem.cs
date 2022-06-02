using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class GachaRateItem : GachaRateElemBase
	{
		[SerializeField]
		private RawImageEx m_attributeImage;
		[SerializeField]
		private Text m_name;
		[SerializeField]
		private Text m_percent;
		[SerializeField]
		private Text m_pickup;
	}
}
