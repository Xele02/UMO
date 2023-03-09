using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Adv
{
	public class AdvMessageBase : MonoBehaviour
	{
		public delegate string TagConvertFunc(string tag);
		
		private Text m_text; // 0xC
		protected StringBuilder m_message = new StringBuilder(); // 0x10
		protected StringBuilder m_str = new StringBuilder(); // 0x14
		protected StringBuilder m_tmp = new StringBuilder(); // 0x18

		public Text Text { get
			{
				if(m_text == null)
				{
					m_text = GetComponent<Text>();
				}
				return m_text;
			}
		} //0xE54D88

		//// RVA: -1 Offset: -1 Slot: 4
		//public abstract void Skip();

		//// RVA: -1 Offset: -1 Slot: 5
		//public abstract void StartMessage(string message, float message_spd, AdvMessageBase.TagConvertFunc func);

		//// RVA: -1 Offset: -1 Slot: 6
		//public abstract bool IsPlay();

		//// RVA: 0xE55370 Offset: 0xE55370 VA: 0xE55370
		//protected void ConvertMessage(StringBuilder strBuilder, AdvMessageBase.TagConvertFunc func) { }

		//// RVA: 0xE56178 Offset: 0xE56178 VA: 0xE56178
		//protected bool IsExistRichClose(StringBuilder message, int index) { }

		//// RVA: 0xE56260 Offset: 0xE56260 VA: 0xE56260
		//protected bool IsRichTextStart(StringBuilder message, int index) { }

		//// RVA: 0xE564A8 Offset: 0xE564A8 VA: 0xE564A8
		//protected bool IsRichTextEnd(StringBuilder message, int index) { }

		//// RVA: 0xE5565C Offset: 0xE5565C VA: 0xE5565C
		//protected int GetNotRichTextLength(StringBuilder message) { }

		//// RVA: 0xE56790 Offset: 0xE56790 VA: 0xE56790
		//public int GetNotRichTextLength(string str) { }

		//// RVA: 0xE56890 Offset: 0xE56890 VA: 0xE56890
		//protected int SeekRichText(StringBuilder message, int index, ref StringBuilder str) { }

		//// RVA: 0xE566D0 Offset: 0xE566D0 VA: 0xE566D0
		//protected int SeekRichText(StringBuilder message, int index) { }

		//// RVA: 0xE556E0 Offset: 0xE556E0 VA: 0xE556E0
		//protected string ConvartTextStrCount(StringBuilder message, int Length) { }
	}
}
