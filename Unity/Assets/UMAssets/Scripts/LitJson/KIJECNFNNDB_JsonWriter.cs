using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

// Namespace: 
internal enum KLCFANODNFB_Condition // TypeDefIndex: 18711
{
	// Fields
	JCPOGOIDAHP_InArray,
	PODKMAMAKOK_InObject,
	CKDOPEGLBHB_NotAProperty,
	AOMCHCLBOBO_Property,
	BLNDFNMPILA_Value
}

// Namespace: 
internal class LHOMBAJMBDN_WriterContext // TypeDefIndex: 18712
{
	// Fields
	public int HNBFOAJIIAL_Count; // 0x8
	public bool JCPOGOIDAHP_InArray; // 0xC
	public bool PODKMAMAKOK_InObject; // 0xD
	public bool PDGOJNHEABE_ExpectingValue; // 0xE
	public int HPCFOIINKJI_Padding; // 0x10

	// Methods

	// RVA: 0x17F7414 Offset: 0x17F7414 VA: 0x17F7414
	//public void .ctor() { }
}

public class KIJECNFNNDB_JsonWriter // TypeDefIndex: 18713
{
	#region Fields
	private static NumberFormatInfo JCHAHJIDEHM_number_format; // 0x0
	private LHOMBAJMBDN_WriterContext PHKJOMLDNOB_context; // 0x8
	private Stack<LHOMBAJMBDN_WriterContext> OKHBNEMHONG_ctx_stack; // 0xC
	private bool HAPJMMMLGPJ_has_reached_end; // 0x10
	private char[] IIEALPMBFDE_hex_seq; // 0x14
	private int JOKMGOGDNDP_indentation; // 0x18
	private int LKLPPIPLNOK_indent_value; // 0x1C
	private StringBuilder BPJEEBHPGDJ_inst_string_builder; // 0x20
	private bool ALHHKDHPEPC_pretty_print; // 0x24
	private bool CNIIGLNMFGC_validate; // 0x25
	private TextWriter OMLLGAKPMAN_writer; // 0x28
	#endregion

	#region Properties
	// // RVA: 0x1A00114 Offset: 0x1A00114 VA: 0x1A00114
	// public int NFLBKBBHCEK() { }
	// // RVA: 0x1A0011C Offset: 0x1A0011C VA: 0x1A0011C
	// public void EKMBOPHIGKI(int NANNGLGOFKH) { }
	public int HACADAOCICG_IndentValue
	{
		get { return LKLPPIPLNOK_indent_value; }
		set
		{
			JOKMGOGDNDP_indentation = (JOKMGOGDNDP_indentation / LKLPPIPLNOK_indent_value) * value;
			LKLPPIPLNOK_indent_value = value;
		}
	}

	// // RVA: 0x1A00148 Offset: 0x1A00148 VA: 0x1A00148
	// public bool LJEINOMHCIO() { }
	// // RVA: 0x1A00150 Offset: 0x1A00150 VA: 0x1A00150
	// public void HBHPGCJDHNJ(bool NANNGLGOFKH) { }
	public bool GALFODHMEOL_PrettyPrint
	{
		get { return ALHHKDHPEPC_pretty_print; }
		set { ALHHKDHPEPC_pretty_print = value; }
	}

	// // RVA: 0x1A00158 Offset: 0x1A00158 VA: 0x1A00158
	// public TextWriter FLHJOFPKGON() { }
	public TextWriter CJNPADFBBBB_TextWriter
	{
		get { return OMLLGAKPMAN_writer; }
	}

	// // RVA: 0x1A00160 Offset: 0x1A00160 VA: 0x1A00160
	// public bool DBGNLAOMAJN() { }
	// // RVA: 0x1A00168 Offset: 0x1A00168 VA: 0x1A00168
	// public void DNMHCBKDJCK(bool NANNGLGOFKH) { }
	public bool GEJEDJNKBOF_Validate
	{
		get { return CNIIGLNMFGC_validate; }
		set { CNIIGLNMFGC_validate = value; }
	}
	#endregion

	#region Constructors
	// // RVA: 0x1A00170 Offset: 0x1A00170 VA: 0x1A00170
	static KIJECNFNNDB_JsonWriter()
	{
		JCHAHJIDEHM_number_format = NumberFormatInfo.InvariantInfo;
	}

	// // RVA: 0x1A001D8 Offset: 0x1A001D8 VA: 0x1A001D8
	public KIJECNFNNDB_JsonWriter()
	{
		BPJEEBHPGDJ_inst_string_builder = new StringBuilder();
		OMLLGAKPMAN_writer = new StringWriter(BPJEEBHPGDJ_inst_string_builder);

		KHEKNNFCAOI_Init();
	}

	// // RVA: 0x1A0038C Offset: 0x1A0038C VA: 0x1A0038C
	public KIJECNFNNDB_JsonWriter(StringBuilder KOHNLDKIKPC_sb) :
			this(new StringWriter(KOHNLDKIKPC_sb))
	{
	}

	// // RVA: 0x1A0040C Offset: 0x1A0040C VA: 0x1A0040C
	public KIJECNFNNDB_JsonWriter(TextWriter OMLLGAKPMAN_writer)
	{
		if (OMLLGAKPMAN_writer == null)
			throw new ArgumentNullException("writer");

		this.OMLLGAKPMAN_writer = OMLLGAKPMAN_writer;

		KHEKNNFCAOI_Init();
	}
	#endregion

	#region Private Methods
	// // RVA: 0x1A004D4 Offset: 0x1A004D4 VA: 0x1A004D4
	private void BOCEOALMNDO_DoValidation(KLCFANODNFB_Condition OAFPGJLCNFM_cond)
	{
		if (!PHKJOMLDNOB_context.PDGOJNHEABE_ExpectingValue)
			PHKJOMLDNOB_context.HNBFOAJIIAL_Count++;

		if (!CNIIGLNMFGC_validate)
			return;

		if (HAPJMMMLGPJ_has_reached_end)
			throw new IKFDGFEAJPL_JsonException(
				"A complete JSON symbol has already been written");

		switch (OAFPGJLCNFM_cond)
		{
			case KLCFANODNFB_Condition.JCPOGOIDAHP_InArray:
				if (!PHKJOMLDNOB_context.JCPOGOIDAHP_InArray)
					throw new IKFDGFEAJPL_JsonException(
						"Can't close an array here");
				break;

			case KLCFANODNFB_Condition.PODKMAMAKOK_InObject:
				if (!PHKJOMLDNOB_context.PODKMAMAKOK_InObject || PHKJOMLDNOB_context.PDGOJNHEABE_ExpectingValue)
					throw new IKFDGFEAJPL_JsonException(
						"Can't close an object here");
				break;

			case KLCFANODNFB_Condition.CKDOPEGLBHB_NotAProperty:
				if (PHKJOMLDNOB_context.PODKMAMAKOK_InObject && !PHKJOMLDNOB_context.PDGOJNHEABE_ExpectingValue)
					throw new IKFDGFEAJPL_JsonException(
						"Expected a property");
				break;

			case KLCFANODNFB_Condition.AOMCHCLBOBO_Property:
				if (!PHKJOMLDNOB_context.PODKMAMAKOK_InObject || PHKJOMLDNOB_context.PDGOJNHEABE_ExpectingValue)
					throw new IKFDGFEAJPL_JsonException(
						"Can't add a property here");
				break;

			case KLCFANODNFB_Condition.BLNDFNMPILA_Value:
				if (!PHKJOMLDNOB_context.JCPOGOIDAHP_InArray &&
					(!PHKJOMLDNOB_context.PODKMAMAKOK_InObject || !PHKJOMLDNOB_context.PDGOJNHEABE_ExpectingValue))
					throw new IKFDGFEAJPL_JsonException(
						"Can't add a value here");

				break;
		}
	}

	// // RVA: 0x1A00284 Offset: 0x1A00284 VA: 0x1A00284
	private void KHEKNNFCAOI_Init()
	{
		HAPJMMMLGPJ_has_reached_end = false;
		IIEALPMBFDE_hex_seq = new char[4];
		JOKMGOGDNDP_indentation = 0;
		LKLPPIPLNOK_indent_value = 4;
		ALHHKDHPEPC_pretty_print = false;
		CNIIGLNMFGC_validate = true;

		OKHBNEMHONG_ctx_stack = new Stack<LHOMBAJMBDN_WriterContext>();
		PHKJOMLDNOB_context = new LHOMBAJMBDN_WriterContext();
		OKHBNEMHONG_ctx_stack.Push(PHKJOMLDNOB_context);
	}

	// // RVA: 0x1A00538 Offset: 0x1A00538 VA: 0x1A00538
	private static void HFEFFBDCHCJ_IntToHex(int LAJNCHHNLBI_n, char[] GCKIGOGMJIF_hex)
	{
		int num;

		for (int i = 0; i < 4; i++)
		{
			num = LAJNCHHNLBI_n % 16;

			if (num < 10)
				GCKIGOGMJIF_hex[3 - i] = (char)('0' + num);
			else
				GCKIGOGMJIF_hex[3 - i] = (char)('A' + (num - 10));

			LAJNCHHNLBI_n >>= 4;
		}
	}

	// // RVA: 0x1A005B0 Offset: 0x1A005B0 VA: 0x1A005B0
	private void DBNKJJOGGGJ_Indent()
	{
		if (ALHHKDHPEPC_pretty_print)
			JOKMGOGDNDP_indentation += LKLPPIPLNOK_indent_value;
	}

	// // RVA: 0x1A005CC Offset: 0x1A005CC VA: 0x1A005CC
	private void LECLCEJCMIK_Put(string JEHFDJPOEFF_str)
	{
		if (ALHHKDHPEPC_pretty_print && !PHKJOMLDNOB_context.PDGOJNHEABE_ExpectingValue)
			for (int i = 0; i < JOKMGOGDNDP_indentation; i++)
				OMLLGAKPMAN_writer.Write(' ');

		OMLLGAKPMAN_writer.Write(JEHFDJPOEFF_str);
	}

	// // RVA: 0x1A00684 Offset: 0x1A00684 VA: 0x1A00684
	private void AIEJNIMDBNF_PutNewline()
	{
		AIEJNIMDBNF_PutNewline(true);
	}

	// // RVA: 0x1A0068C Offset: 0x1A0068C VA: 0x1A0068C
	private void AIEJNIMDBNF_PutNewline(bool KPAIIKNEEOF_add_comma)
	{
		if (KPAIIKNEEOF_add_comma && !PHKJOMLDNOB_context.PDGOJNHEABE_ExpectingValue &&
			PHKJOMLDNOB_context.HNBFOAJIIAL_Count > 1)
			OMLLGAKPMAN_writer.Write(',');

		if (ALHHKDHPEPC_pretty_print && !PHKJOMLDNOB_context.PDGOJNHEABE_ExpectingValue)
			OMLLGAKPMAN_writer.Write('\n');
	}

	// // RVA: 0x1A0076C Offset: 0x1A0076C VA: 0x1A0076C
	private void DCGJDAIPEOE_PutString(string JEHFDJPOEFF_str)
	{
		LECLCEJCMIK_Put(String.Empty);

		OMLLGAKPMAN_writer.Write('"');

		int n = JEHFDJPOEFF_str.Length;
		for (int i = 0; i < n; i++)
		{
			switch (JEHFDJPOEFF_str[i])
			{
				case '\n':
					OMLLGAKPMAN_writer.Write("\\n");
					continue;

				case '\r':
					OMLLGAKPMAN_writer.Write("\\r");
					continue;

				case '\t':
					OMLLGAKPMAN_writer.Write("\\t");
					continue;

				case '"':
				case '\\':
					OMLLGAKPMAN_writer.Write('\\');
					OMLLGAKPMAN_writer.Write(JEHFDJPOEFF_str[i]);
					continue;

				case '\f':
					OMLLGAKPMAN_writer.Write("\\f");
					continue;

				case '\b':
					OMLLGAKPMAN_writer.Write("\\b");
					continue;
			}

			if ((int)JEHFDJPOEFF_str[i] >= 32 && (int)JEHFDJPOEFF_str[i] <= 126)
			{
				OMLLGAKPMAN_writer.Write(JEHFDJPOEFF_str[i]);
				continue;
			}

			// Default, turn into a \uXXXX sequence
			HFEFFBDCHCJ_IntToHex((int)JEHFDJPOEFF_str[i], IIEALPMBFDE_hex_seq);
			OMLLGAKPMAN_writer.Write("\\u");
			OMLLGAKPMAN_writer.Write(IIEALPMBFDE_hex_seq);
		}

		OMLLGAKPMAN_writer.Write('"');
	}

	// // RVA: 0x1A00ABC Offset: 0x1A00ABC VA: 0x1A00ABC
	private void LDEGMOGLEJE_Unindent()
	{
		if (ALHHKDHPEPC_pretty_print)
			JOKMGOGDNDP_indentation -= LKLPPIPLNOK_indent_value;
	}
	#endregion

	// // RVA: 0x1A00AD8 Offset: 0x1A00AD8 VA: 0x1A00AD8 Slot: 3
	public override string ToString()
	{
		if (BPJEEBHPGDJ_inst_string_builder == null)
			return String.Empty;

		return BPJEEBHPGDJ_inst_string_builder.ToString();
	}

	// RVA: 0x1A00B5C Offset: 0x1A00B5C VA: 0x1A00B5C
	public void LHPDDGIJKNB_Reset()
	{
		HAPJMMMLGPJ_has_reached_end = false;

		OKHBNEMHONG_ctx_stack.Clear();
		PHKJOMLDNOB_context = new LHOMBAJMBDN_WriterContext();
		OKHBNEMHONG_ctx_stack.Push(PHKJOMLDNOB_context);

		if (BPJEEBHPGDJ_inst_string_builder != null)
			BPJEEBHPGDJ_inst_string_builder.Remove(0, BPJEEBHPGDJ_inst_string_builder.Length);
	}

	// // RVA: 0x1A00C5C Offset: 0x1A00C5C VA: 0x1A00C5C
	public void LCABGAFGNFL() { }

	// // RVA: 0x1A00D48 Offset: 0x1A00D48 VA: 0x1A00D48
	public void FPEKCEGADMG_Write(bool GOOAMNCOICJ_boolean)
	{
		BOCEOALMNDO_DoValidation(KLCFANODNFB_Condition.BLNDFNMPILA_Value);
		AIEJNIMDBNF_PutNewline();

		LECLCEJCMIK_Put(GOOAMNCOICJ_boolean ? "true" : "false");

		PHKJOMLDNOB_context.PDGOJNHEABE_ExpectingValue = false;
	}

	// // RVA: 0x1A00DF8 Offset: 0x1A00DF8 VA: 0x1A00DF8
	public void FPEKCEGADMG_Write(Decimal AMFBGBPJEEC_number)
	{
		BOCEOALMNDO_DoValidation(KLCFANODNFB_Condition.BLNDFNMPILA_Value);
		AIEJNIMDBNF_PutNewline();

		LECLCEJCMIK_Put(Convert.ToString(AMFBGBPJEEC_number, JCHAHJIDEHM_number_format));

		PHKJOMLDNOB_context.PDGOJNHEABE_ExpectingValue = false;
	}

	// // RVA: 0x1A00F24 Offset: 0x1A00F24 VA: 0x1A00F24
	public void FPEKCEGADMG_Write(double AMFBGBPJEEC_number)
	{
		BOCEOALMNDO_DoValidation(KLCFANODNFB_Condition.BLNDFNMPILA_Value);
		AIEJNIMDBNF_PutNewline();

		string str = Convert.ToString(AMFBGBPJEEC_number, JCHAHJIDEHM_number_format);
		LECLCEJCMIK_Put(str);

		if (str.IndexOf('.') == -1 &&
			str.IndexOf('E') == -1)
			OMLLGAKPMAN_writer.Write(".0");

		PHKJOMLDNOB_context.PDGOJNHEABE_ExpectingValue = false;
	}

	// // RVA: 0x1A010C4 Offset: 0x1A010C4 VA: 0x1A010C4
	public void FPEKCEGADMG_Write(int AMFBGBPJEEC_number)
	{
		BOCEOALMNDO_DoValidation(KLCFANODNFB_Condition.BLNDFNMPILA_Value);
		AIEJNIMDBNF_PutNewline();

		LECLCEJCMIK_Put(Convert.ToString(AMFBGBPJEEC_number, JCHAHJIDEHM_number_format));

		PHKJOMLDNOB_context.PDGOJNHEABE_ExpectingValue = false;
	}

	// // RVA: 0x1A011D0 Offset: 0x1A011D0 VA: 0x1A011D0
	public void FPEKCEGADMG_Write(long AMFBGBPJEEC_number)
	{
		BOCEOALMNDO_DoValidation(KLCFANODNFB_Condition.BLNDFNMPILA_Value);
		AIEJNIMDBNF_PutNewline();

		LECLCEJCMIK_Put(Convert.ToString(AMFBGBPJEEC_number, JCHAHJIDEHM_number_format));

		PHKJOMLDNOB_context.PDGOJNHEABE_ExpectingValue = false;
	}

	// // RVA: 0x1A012E4 Offset: 0x1A012E4 VA: 0x1A012E4
	public void FPEKCEGADMG_Write(string JEHFDJPOEFF_str)
	{
		BOCEOALMNDO_DoValidation(KLCFANODNFB_Condition.BLNDFNMPILA_Value);
		AIEJNIMDBNF_PutNewline();

		if (JEHFDJPOEFF_str == null)
			LECLCEJCMIK_Put("null");
		else
			DCGJDAIPEOE_PutString(JEHFDJPOEFF_str);

		PHKJOMLDNOB_context.PDGOJNHEABE_ExpectingValue = false;
	}


	// // RVA: 0x1A01394 Offset: 0x1A01394 VA: 0x1A01394
	public void FPEKCEGADMG_Write(ulong AMFBGBPJEEC_number)
	{
		BOCEOALMNDO_DoValidation(KLCFANODNFB_Condition.BLNDFNMPILA_Value);
		AIEJNIMDBNF_PutNewline();

		LECLCEJCMIK_Put(Convert.ToString(AMFBGBPJEEC_number, JCHAHJIDEHM_number_format));

		PHKJOMLDNOB_context.PDGOJNHEABE_ExpectingValue = false;
	}

	// // RVA: 0x1A014A8 Offset: 0x1A014A8 VA: 0x1A014A8
	public void KJLDOKNDPCO_WriteArrayEnd()
	{
		BOCEOALMNDO_DoValidation(KLCFANODNFB_Condition.JCPOGOIDAHP_InArray);
		AIEJNIMDBNF_PutNewline(false);

		OKHBNEMHONG_ctx_stack.Pop();
		if (OKHBNEMHONG_ctx_stack.Count == 1)
			HAPJMMMLGPJ_has_reached_end = true;
		else
		{
			PHKJOMLDNOB_context = OKHBNEMHONG_ctx_stack.Peek();
			PHKJOMLDNOB_context.PDGOJNHEABE_ExpectingValue = false;
		}

		LDEGMOGLEJE_Unindent();
		LECLCEJCMIK_Put("]");
	}

	// // RVA: 0x1A015F0 Offset: 0x1A015F0 VA: 0x1A015F0
	public void PCMFCDODNMB_WriteArrayStart()
	{
		BOCEOALMNDO_DoValidation(KLCFANODNFB_Condition.CKDOPEGLBHB_NotAProperty);
		AIEJNIMDBNF_PutNewline();

		LECLCEJCMIK_Put("[");

		PHKJOMLDNOB_context = new LHOMBAJMBDN_WriterContext();
		PHKJOMLDNOB_context.JCPOGOIDAHP_InArray = true;
		OKHBNEMHONG_ctx_stack.Push(PHKJOMLDNOB_context);

		DBNKJJOGGGJ_Indent();
	}

	// // RVA: 0x1A016F0 Offset: 0x1A016F0 VA: 0x1A016F0
	public void LKJOBFDIMPF_WriteObjectEnd()
	{
		BOCEOALMNDO_DoValidation(KLCFANODNFB_Condition.PODKMAMAKOK_InObject);
		AIEJNIMDBNF_PutNewline(false);

		OKHBNEMHONG_ctx_stack.Pop();
		if (OKHBNEMHONG_ctx_stack.Count == 1)
			HAPJMMMLGPJ_has_reached_end = true;
		else
		{
			PHKJOMLDNOB_context = OKHBNEMHONG_ctx_stack.Peek();
			PHKJOMLDNOB_context.PDGOJNHEABE_ExpectingValue = false;
		}

		LDEGMOGLEJE_Unindent();
		LECLCEJCMIK_Put("}");
	}


	// // RVA: 0x1A01838 Offset: 0x1A01838 VA: 0x1A01838
	public void APFBNDGICIA_WriteObjectStart()
	{
		BOCEOALMNDO_DoValidation(KLCFANODNFB_Condition.CKDOPEGLBHB_NotAProperty);
		AIEJNIMDBNF_PutNewline();

		LECLCEJCMIK_Put("{");

		PHKJOMLDNOB_context = new LHOMBAJMBDN_WriterContext();
		PHKJOMLDNOB_context.PODKMAMAKOK_InObject = true;
		OKHBNEMHONG_ctx_stack.Push(PHKJOMLDNOB_context);

		DBNKJJOGGGJ_Indent();
	}

	// // RVA: 0x1A01938 Offset: 0x1A01938 VA: 0x1A01938
	public void ABKCJDMNIOC_WritePropertyName(string AJDIJOOFOFF_property_name)
	{
		BOCEOALMNDO_DoValidation(KLCFANODNFB_Condition.AOMCHCLBOBO_Property);
		AIEJNIMDBNF_PutNewline();

		DCGJDAIPEOE_PutString(AJDIJOOFOFF_property_name);

		if (ALHHKDHPEPC_pretty_print)
		{
			if (AJDIJOOFOFF_property_name.Length > PHKJOMLDNOB_context.HPCFOIINKJI_Padding)
				PHKJOMLDNOB_context.HPCFOIINKJI_Padding = AJDIJOOFOFF_property_name.Length;

			for (int i = PHKJOMLDNOB_context.HPCFOIINKJI_Padding - AJDIJOOFOFF_property_name.Length;
				 i >= 0; i--)
				OMLLGAKPMAN_writer.Write(' ');

			OMLLGAKPMAN_writer.Write(": ");
		}
		else
			OMLLGAKPMAN_writer.Write(':');

		PHKJOMLDNOB_context.PDGOJNHEABE_ExpectingValue = true;
	}
}
