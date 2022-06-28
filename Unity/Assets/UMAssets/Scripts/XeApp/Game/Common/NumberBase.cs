using XeSys.Gfx;
using UnityEngine;
using System.Text;
using XeSys;

namespace XeApp.Game.Common
{
	public class NumberBase : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx[] m_numberImage; // 0x14
		[SerializeField]
		private string m_texFormat; // 0x18
		[SerializeField]
		private string m_symbolFormat; // 0x1C
		private Rect[] m_numberRect; // 0x20
		private const bool DIGIT = false;
		private int[] m_digit = new int[16]; // 0x24
		private AbsoluteLayout m_abs; // 0x28
		private AbsoluteLayout m_digit_layout; // 0x2C
		private int m_digitMax; // 0x30
		private int m_numberMax; // 0x34
		private int m_numberMin; // 0x38
		private int m_number; // 0x3C

		// public int Number { get; } 0xAF3F14
		// public int DigitMax { get; } 0xAF3F1C

		// RVA: 0xAF3F24 Offset: 0xAF3F24 VA: 0xAF3F24 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			StringBuilder str = new StringBuilder(m_texFormat.Length + 8);
			m_numberRect = new Rect[10];
			for(int i = 0; i < 10; i++)
			{
				str.Clear();
				str.AppendFormat(m_texFormat, i);
				m_numberRect[i] = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData(str.ToString()));
			}
			m_abs = LayoutUGUIUtility.GetParentRuntime(transform).FindViewBase(transform as RectTransform) as AbsoluteLayout;
			m_digitMax = m_numberImage.Length;
			m_numberMax = (int)Mathf.Pow(10.0f, (float)m_digitMax) - 1;
			str = new StringBuilder();
			str.SetFormat(m_symbolFormat, 1);
			m_digit_layout = m_abs.FindViewByExId(str.ToString()) as AbsoluteLayout;
			Loaded();
			return true;
		}

		// // RVA: 0xAF43B4 Offset: 0xAF43B4 VA: 0xAF43B4 Slot: 6
		// public virtual void SetNumber(int number, int minDgit = 0) { }

		// // RVA: 0xAF4618 Offset: 0xAF4618 VA: 0xAF4618 Slot: 7
		// public virtual void SetDigitNuber(int digit, int number) { }

		// // RVA: 0xAF46F8 Offset: 0xAF46F8 VA: 0xAF46F8 Slot: 8
		// public virtual void SetDigitLength(int length, bool isForce = False) { }
	}
}
