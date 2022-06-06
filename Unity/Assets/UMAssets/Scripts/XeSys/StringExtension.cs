using System.Text;

namespace XeSys
{
	public static class StringExtension
	{
		// // RVA: 0x23A2114 Offset: 0x23A2114 VA: 0x23A2114
		public static void Clear(this StringBuilder str)
		{
			str.Length = 0;
		}

		// // RVA: 0x23A2144 Offset: 0x23A2144 VA: 0x23A2144
		public static void Set(this StringBuilder str, string inputStr)
		{
			if(str != null)
			{
				str.Length = 0;
				str.Append(inputStr);
			}
		}

		// // RVA: 0x23A21A4 Offset: 0x23A21A4 VA: 0x23A21A4
		public static void Set(this StringBuilder str, char inputChar)
		{
			if(str != null)
			{
				str.Length = 0;
				str.Append(inputChar);
			}
		}

		// // RVA: 0x23A2204 Offset: 0x23A2204 VA: 0x23A2204
		public static void SetFormat(this StringBuilder str, string format, object arg0)
		{
			if(str != null)
			{
				str.Length = 0;
				str.AppendFormat(format, arg0);
			}
		}

		// // RVA: 0x23A226C Offset: 0x23A226C VA: 0x23A226C
		public static void SetFormat(this StringBuilder str, string format, object arg0, object arg1)
		{
			if(str != null)
			{
				str.Length = 0;
				str.AppendFormat(format, arg0, arg1);
			}
		}

		// // RVA: 0x23A22E8 Offset: 0x23A22E8 VA: 0x23A22E8
		public static void SetFormat(this StringBuilder str, string format, object arg0, object arg1, object arg2)
		{
			if(str != null)
			{
				str.Length = 0;
				str.AppendFormat(format, arg0, arg1, arg2);
			}
		}

		// // RVA: 0x23A236C Offset: 0x23A236C VA: 0x23A236C
		public static void SetFormat(this StringBuilder str, string format, object[] args)
		{
			if(str != null)
			{
				str.Length = 0;
				str.AppendFormat(format, args);
			}
		}
	}
}
