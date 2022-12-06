using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class SetDeckSceneSetControl : MonoBehaviour
	{
		//[TooltipAttribute] // RVA: 0x682AEC Offset: 0x682AEC VA: 0x682AEC
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x682AEC Offset: 0x682AEC VA: 0x682AEC
		private Image m_backImage; // 0xC
		//[TooltipAttribute] // RVA: 0x682B64 Offset: 0x682B64 VA: 0x682B64
		[SerializeField]
		private List<SetDeckSceneControl> m_scenes; // 0x10
		//[TooltipAttribute] // RVA: 0x682BBC Offset: 0x682BBC VA: 0x682BBC
		//[HeaderAttribute] // RVA: 0x682BBC Offset: 0x682BBC VA: 0x682BBC
		[SerializeField]
		private DivaColorSetScriptableObject m_divaColors; // 0x14
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x682C2C Offset: 0x682C2C VA: 0x682C2C
		private Color m_emptyColor; // 0x18

		public List<SetDeckSceneControl> Scenes { get { return m_scenes; } } //0xA74B90

		//// RVA: 0xA74B98 Offset: 0xA74B98 VA: 0xA74B98
		public void SetColor(int divaId)
		{
			if(divaId < 1)
			{
				m_backImage.color = new Color(m_emptyColor.r, m_emptyColor.g, m_emptyColor.b, m_backImage.color.a);
			}
			else
			{
				Color col = m_divaColors.GetDivaColor(divaId);
				m_backImage.color = new Color(col.r, col.g, col.b, m_backImage.color.a);
			}
		}

		//// RVA: 0xA74CF4 Offset: 0xA74CF4 VA: 0xA74CF4
		//private Color ColorAlphaMarge(Color targetColor, float a) { }
	}
}
