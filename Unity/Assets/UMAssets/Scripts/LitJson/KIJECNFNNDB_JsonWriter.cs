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
	// Fields
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

	// // Properties
	// // RVA: 0x1A00114 Offset: 0x1A00114 VA: 0x1A00114
	// public int NFLBKBBHCEK() { }
	// // RVA: 0x1A0011C Offset: 0x1A0011C VA: 0x1A0011C
	// public void EKMBOPHIGKI(int NANNGLGOFKH) { }
	public int HACADAOCICG_IndentValue { get; set; }

	// // RVA: 0x1A00148 Offset: 0x1A00148 VA: 0x1A00148
	// public bool LJEINOMHCIO() { }
	// // RVA: 0x1A00150 Offset: 0x1A00150 VA: 0x1A00150
	// public void HBHPGCJDHNJ(bool NANNGLGOFKH) { }
	public bool GALFODHMEOL_PrettyPrint { get; set; }
	
	// // RVA: 0x1A00158 Offset: 0x1A00158 VA: 0x1A00158
	// public TextWriter FLHJOFPKGON() { }
	public TextWriter CJNPADFBBBB_TextWriter { get; }

	// // RVA: 0x1A00160 Offset: 0x1A00160 VA: 0x1A00160
	// public bool DBGNLAOMAJN() { }
	// // RVA: 0x1A00168 Offset: 0x1A00168 VA: 0x1A00168
	// public void DNMHCBKDJCK(bool NANNGLGOFKH) { }
	public bool GEJEDJNKBOF_Validate { get; set; }


	// // RVA: 0x1A00170 Offset: 0x1A00170 VA: 0x1A00170
	// static KIJECNFNNDB_JsonWriter() { }

	// // RVA: 0x1A001D8 Offset: 0x1A001D8 VA: 0x1A001D8
	public KIJECNFNNDB_JsonWriter() { }

	// // RVA: 0x1A0038C Offset: 0x1A0038C VA: 0x1A0038C
	public KIJECNFNNDB_JsonWriter(StringBuilder KOHNLDKIKPC_sb) { }

	// // RVA: 0x1A0040C Offset: 0x1A0040C VA: 0x1A0040C
	public KIJECNFNNDB_JsonWriter(TextWriter OMLLGAKPMAN_writer) { }

	// // RVA: 0x1A004D4 Offset: 0x1A004D4 VA: 0x1A004D4
	// private void BOCEOALMNDO_DoValidation(KLCFANODNFB OAFPGJLCNFM_cond) { }

	// // RVA: 0x1A00284 Offset: 0x1A00284 VA: 0x1A00284
	// private void KHEKNNFCAOI_Init() { }

	// // RVA: 0x1A00538 Offset: 0x1A00538 VA: 0x1A00538
	// private static void HFEFFBDCHCJ_IntToHex(int LAJNCHHNLBI_n, char[] GCKIGOGMJIF_hex) { }

	// // RVA: 0x1A005B0 Offset: 0x1A005B0 VA: 0x1A005B0
	// private void DBNKJJOGGGJ_Indent() { }

	// // RVA: 0x1A005CC Offset: 0x1A005CC VA: 0x1A005CC
	// private void LECLCEJCMIK_Put(string JEHFDJPOEFF_str) { }

	// // RVA: 0x1A00684 Offset: 0x1A00684 VA: 0x1A00684
	// private void AIEJNIMDBNF_PutNewline() { }

	// // RVA: 0x1A0068C Offset: 0x1A0068C VA: 0x1A0068C
	// private void AIEJNIMDBNF_PutNewline(bool KPAIIKNEEOF_add_comma) { }

	// // RVA: 0x1A0076C Offset: 0x1A0076C VA: 0x1A0076C
	// private void DCGJDAIPEOE_PutString(string JEHFDJPOEFF_str) { }

	// // RVA: 0x1A00ABC Offset: 0x1A00ABC VA: 0x1A00ABC
	// private void LDEGMOGLEJE_Unindent() { }

	// // RVA: 0x1A00AD8 Offset: 0x1A00AD8 VA: 0x1A00AD8 Slot: 3
	// public override string ToString() { }

	// // RVA: 0x1A00B5C Offset: 0x1A00B5C VA: 0x1A00B5C
	// public void LHPDDGIJKNB() { }

	// // RVA: 0x1A00C5C Offset: 0x1A00C5C VA: 0x1A00C5C
	// public void LCABGAFGNFL() { }

	// // RVA: 0x1A00D48 Offset: 0x1A00D48 VA: 0x1A00D48
	public void FPEKCEGADMG_Write(bool GOOAMNCOICJ_boolean) { }

	// // RVA: 0x1A00DF8 Offset: 0x1A00DF8 VA: 0x1A00DF8
	public void FPEKCEGADMG_Write(Decimal AMFBGBPJEEC_number) { }

	// // RVA: 0x1A00F24 Offset: 0x1A00F24 VA: 0x1A00F24
	public void FPEKCEGADMG_Write(double AMFBGBPJEEC_number) { }

	// // RVA: 0x1A010C4 Offset: 0x1A010C4 VA: 0x1A010C4
	public void FPEKCEGADMG_Write(int AMFBGBPJEEC_number) { }

	// // RVA: 0x1A011D0 Offset: 0x1A011D0 VA: 0x1A011D0
	public void FPEKCEGADMG_Write(long AMFBGBPJEEC_number) { }

	// // RVA: 0x1A012E4 Offset: 0x1A012E4 VA: 0x1A012E4
	public void FPEKCEGADMG_Write(string JEHFDJPOEFF_str) { }

	// // RVA: 0x1A01394 Offset: 0x1A01394 VA: 0x1A01394
	public void FPEKCEGADMG_Write(ulong AMFBGBPJEEC_number) { }

	// // RVA: 0x1A014A8 Offset: 0x1A014A8 VA: 0x1A014A8
	public void KJLDOKNDPCO_WriteArrayEnd() { }

	// // RVA: 0x1A015F0 Offset: 0x1A015F0 VA: 0x1A015F0
	public void PCMFCDODNMB_WriteArrayStart() { }

	// // RVA: 0x1A016F0 Offset: 0x1A016F0 VA: 0x1A016F0
	public void LKJOBFDIMPF_WriteObjectEnd() { }

	// // RVA: 0x1A01838 Offset: 0x1A01838 VA: 0x1A01838
	public void APFBNDGICIA_WriteObjectStart() { }

	// // RVA: 0x1A01938 Offset: 0x1A01938 VA: 0x1A01938
	public void ABKCJDMNIOC_WritePropertyName(string AJDIJOOFOFF_property_name) { }
}
