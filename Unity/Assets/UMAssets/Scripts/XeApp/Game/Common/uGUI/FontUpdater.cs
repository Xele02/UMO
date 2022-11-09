using UnityEngine;
using UnityEngine.UI;
using XeSys.Gfx;

namespace XeApp.Game.Common.uGUI
{
	public class FontUpdater : MonoBehaviour, ILayoutUGUIPaste
	{
		[SerializeField]
		private Text[] m_textComponents; // 0xC

		// RVA: 0xD35EF4 Offset: 0xD35EF4 VA: 0xD35EF4 Slot: 4
		public bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			return true;
		}

		// RVA: 0xD35EFC Offset: 0xD35EFC VA: 0xD35EFC
		private void Awake()
		{
			Font.textureRebuilt += this.OnFontTextureRebuilt;
		}

		// RVA: 0xD35F98 Offset: 0xD35F98 VA: 0xD35F98
		private void OnDestroy()
		{
			Font.textureRebuilt -= this.OnFontTextureRebuilt;
		}

		//// RVA: 0xD36034 Offset: 0xD36034 VA: 0xD36034
		private void OnFontTextureRebuilt(Font font)
		{
			for(int i = 0; i < m_textComponents.Length; i++)
			{
				if(m_textComponents[i].font == font)
				{
					m_textComponents[i].FontTextureChanged();
				}
			}
		}
	}
}
