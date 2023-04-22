using System.Text;
using UnityEngine;
using UnityEngine.UI;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class DivaIconDecorationBehaviour : MonoBehaviour, ILayoutUGUIPaste
	{
		[SerializeField]
		private Text m_text; // 0xC
		private StringBuilder m_strBuilder = new StringBuilder(64); // 0x10

		// RVA: 0x17E3258 Offset: 0x17E3258 VA: 0x17E3258 Slot: 4
		public bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			LayoutUGUIRuntime runtime = GetComponentInParent<LayoutUGUIRuntime>();
			m_text.font = runtime.Font;
			m_text.material = runtime.Font.material;
			m_text.horizontalOverflow = HorizontalWrapMode.Overflow;
			return true;
		}

		// RVA: 0x17E2D1C Offset: 0x17E2D1C VA: 0x17E2D1C
		public void SetLevel(int level)
		{
			m_strBuilder.SetFormat("Lv{0}", level);
			m_text.text = m_strBuilder.ToString();
		}

		// RVA: 0x17E2E0C Offset: 0x17E2E0C VA: 0x17E2E0C
		public void SetValue(int value, bool isSign)
		{
			m_strBuilder.SetFormat("{0}{1}", value >= 1 && isSign ? "+" : "", value);
			m_text.text = m_strBuilder.ToString();
		}
	}
}
