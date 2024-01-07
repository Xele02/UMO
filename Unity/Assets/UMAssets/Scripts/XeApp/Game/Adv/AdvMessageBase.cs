using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Adv
{
	public abstract class AdvMessageBase : MonoBehaviour
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
		public abstract void Skip();

		//// RVA: -1 Offset: -1 Slot: 5
		public abstract void StartMessage(string message, float message_spd, AdvMessageBase.TagConvertFunc func);

		//// RVA: -1 Offset: -1 Slot: 6
		public abstract bool IsPlay();

		//// RVA: 0xE55370 Offset: 0xE55370 VA: 0xE55370
		protected void ConvertMessage(StringBuilder strBuilder, TagConvertFunc func)
		{
			m_tmp.Clear();
			for(int i = 0; i < strBuilder.Length; i++)
			{
				char c = strBuilder[i];
				if(c == '<')
				{
					m_str.Clear();
					int j = i + 1;
					for (; j < strBuilder.Length; j++)
					{
						c = strBuilder[j];
						if (c == '>')
						{
							if(func != null)
							{
								string s = func(m_str.ToString());
								if(!string.IsNullOrEmpty(s))
								{
									m_tmp.Append(s);
									i += j;
									break;
								}
							}
							m_tmp.Append(strBuilder.ToString(), i, j + 1 - i);
							i += j;
							break;
						}
						m_str.Append(c);
					}
				}
				else
				{
					m_tmp.Append(strBuilder[i]);
				}
			}
			strBuilder.Clear();
			strBuilder.Append(m_tmp.ToString());
		}

		//// RVA: 0xE56178 Offset: 0xE56178 VA: 0xE56178
		protected bool IsExistRichClose(StringBuilder message, int index)
		{
			for(int i = index; i < message.Length; i++)
			{
				if (message[i] == '>')
					return true;
			}
			return false;
		}

		//// RVA: 0xE56260 Offset: 0xE56260 VA: 0xE56260
		protected bool IsRichTextStart(StringBuilder message, int index)
		{
			bool res = false;
			if(index + 1 <= message.Length)
			{
				res = false;
				char c = message[index];
				if(c == '<')
				{
					res = false;
					if(message[index + 1] != '/' && IsExistRichClose(message, index))
					{
						for(int i = index; i < (message.Length - 1); i++)
						{
							if(message[i] == '<')
							{
								i++;
								if(message[i] == '/' && IsExistRichClose(message, index - 1))
								{
									return true;
								}
							}
						}
					}
				}
			}
			return res;
		}

		//// RVA: 0xE564A8 Offset: 0xE564A8 VA: 0xE564A8
		protected bool IsRichTextEnd(StringBuilder message, int index)
		{
			if(index + 1 <= message.Length)
			{
				if(message[index] == '<')
				{
					if(message[index] == '/' && IsExistRichClose(message, index))
					{
						for(int i = index + 1; i < message.Length; i++)
						{
							if (message[i] == '<' && message[i + 1] != '/' && IsExistRichClose(message, index))
								return true;
						}
					}
				}
			}
			return false;
		}

		//// RVA: 0xE5565C Offset: 0xE5565C VA: 0xE5565C
		protected int GetNotRichTextLength(StringBuilder message)
		{
			int len = 0;
			for (int i = 0; i < message.Length; i++)
			{
				if (IsRichTextStart(message, i) || IsRichTextEnd(message, i))
				{
					i = SeekRichText(message, i);
				}
				len++;
			}
			return len;
		}

		//// RVA: 0xE56790 Offset: 0xE56790 VA: 0xE56790
		public int GetNotRichTextLength(string str)
		{
			StringBuilder strB = new StringBuilder();
			strB.Append(str);
			return GetNotRichTextLength(strB);
		}

		//// RVA: 0xE56890 Offset: 0xE56890 VA: 0xE56890
		protected int SeekRichText(StringBuilder message, int index, ref StringBuilder str)
		{
			int i = index;
			for (; message[index] != '>'; i++)
			{
				if(str != null)
					str.Append(message[index]);
			}
			return i + 1;
		}

		//// RVA: 0xE566D0 Offset: 0xE566D0 VA: 0xE566D0
		protected int SeekRichText(StringBuilder message, int index)
		{
			int i = index;
			for (; message[index] != '>'; i++)
			{
				;
			}
			return i + 1;
		}

		//// RVA: 0xE556E0 Offset: 0xE556E0 VA: 0xE556E0
		protected string ConvartTextStrCount(StringBuilder message, int Length)
		{
			m_str.Clear();
			int cnt = 0;
			int len = 0;
			int i = 0;
			for (; i < message.Length; )
			{
				if (IsRichTextStart(message, i))
				{
					i = SeekRichText(message, i, ref m_str);
					cnt++;
				}
				else if (IsRichTextEnd(message, i))
				{
					i = SeekRichText(message, i, ref m_str);
					cnt--;
				}
				else
				{
					m_str.Append(message[i]);
					len++;
					i++;
				}
				if (Length <= len)
					break;
			}
			for(; i < message.Length;)
			{
				if (cnt < 1)
					break;
				if(IsRichTextEnd(message, i))
				{
					i = SeekRichText(message, i, ref m_str);
					cnt--;
				}
				else
				{
					i++;
				}
			}
			return m_str.ToString();
		}
	}
}
