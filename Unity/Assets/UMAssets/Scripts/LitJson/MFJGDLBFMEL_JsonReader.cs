using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public enum LIMGNGJNDAK{}
public enum LIMGNGJNDAK_JsonToken
{
	HJNNKCMLGFL_None = 0,
	EKHMLPGOKGB_ObjectStart = 1,
	LPHOANHJJNH_PropertyName = 2,
	EANBLFODAJI_ObjectEnd = 3,
	LNNBLGKFCCA_ArrayStart = 4,
	HCCMCHLILCI_ArrayEnd = 5,
	CEIBAFOCNCA_Int = 6,
	HJBKGEBNJMP_Long = 7,
	PFOFBNKFKCA_Double = 8,
	IAAHPCHFCFB_String = 9,
	JIJLIKNGOOH_Boolean = 10,
	GMKPJPDCMJM_Null = 11
}

// https://github.com/LitJSON/litjson/blob/cd646def20af4aff19a02f8e7bcdd28b54fc850f/src/LitJson/JsonReader.cs

public class MFJGDLBFMEL_JsonReader
{
	#region Fields
	private static IDictionary<int, IDictionary<int, int[]>> IECLGGPCKDD_parse_table; // 0x0
	private Stack<int> MPOFLJNAOEA_automaton_stack; // 0x8
	private int JBCHENGIGOP_current_input; // 0xC
	private int KFKNLCDJAAB_current_symbol; // 0x10
	private bool NPNHFHOJLCC_end_of_json; // 0x14
	private bool HMHNDKEOIPF_end_of_input; // 0x15
	private OFIGBFBNKKK_Lexer IMIGLMKHEMM_lexer; // 0x18
	private bool NKPNFFJBDEG_parser_in_string; // 0x1C
	private bool HENOKDJPHKL_parser_return; // 0x1D
	private bool EOJDFDKGCME_read_started; // 0x1E
	private TextReader CLJIOLIEPNA_reader; // 0x20
	private bool KDJKICGGOOD_reader_is_owned; // 0x24
	private object PADBJIMKLDG_token_value; // 0x28
	private LIMGNGJNDAK_JsonToken JCOGNKFNDEB_token; // 0x2C
	#endregion

	#region Public Properties
	// RVA: 0x131369C Offset: 0x131369C VA: 0x131369C
	//public bool CELGLBHMGFD() { }
	// RVA: 0x13136C8 Offset: 0x13136C8 VA: 0x13136C8
	//public void EBLEFGNMNAK(bool NANNGLGOFKH) { }
	public bool KCAALEDBLEN_AllowComments {
		get { return IMIGLMKHEMM_lexer.KCAALEDBLEN_AllowComments; }
		set { IMIGLMKHEMM_lexer.KCAALEDBLEN_AllowComments = value; }
	}
	// RVA: 0x13136FC Offset: 0x13136FC VA: 0x13136FC
	//public bool IOHEILNOGLK() { }
	// RVA: 0x1313728 Offset: 0x1313728 VA: 0x1313728
	//public void NJIGIFMIGLB(bool NANNGLGOFKH) { }
	public bool MOGFDBHPGMG_AllowSingleQuotedStrings {
		get { return IMIGLMKHEMM_lexer.MOGFDBHPGMG_AllowSingleQuotedStrings; }
		set { IMIGLMKHEMM_lexer.MOGFDBHPGMG_AllowSingleQuotedStrings = value; }
	}
	// RVA: 0x131375C Offset: 0x131375C VA: 0x131375C
	//public bool PHDFMENIOFF() { }
	public bool BADOHMHEOHN_EndOfInput { get { return HMHNDKEOIPF_end_of_input; } }
	// RVA: 0x1313764 Offset: 0x1313764 VA: 0x1313764
	//public bool AAPFEAAPCLJ() { }
	public bool PBDIDOBJELC_EndOfJson { get { return NPNHFHOJLCC_end_of_json; } }
	// RVA: 0x131376C Offset: 0x131376C VA: 0x131376C
	//public LIMGNGJNDAK HEBLJBNFHGA() { }
	public LIMGNGJNDAK_JsonToken FDPPJPGNCMK_Token { get { return JCOGNKFNDEB_token; } }
	// RVA: 0x1313774 Offset: 0x1313774 VA: 0x1313774
	//public object CCPMBFFCDMJ() { }
	public object BLNDFNMPILA_Value { get { return PADBJIMKLDG_token_value; } }
	#endregion

	#region Constructors
	// RVA: 0x131377C Offset: 0x131377C VA: 0x131377C
	static MFJGDLBFMEL_JsonReader()
	{
		IEFNCAMFDGO_PopulateParseTable ();
	}

	// RVA: 0x1314110 Offset: 0x1314110 VA: 0x1314110
	public MFJGDLBFMEL_JsonReader(string KNADCEBNNIO_json_text) :
		this (new StringReader (KNADCEBNNIO_json_text), true)
	{
	}

	// RVA: 0x1314330 Offset: 0x1314330 VA: 0x1314330
	public MFJGDLBFMEL_JsonReader(TextReader CLJIOLIEPNA_reader) :
		this (CLJIOLIEPNA_reader, false)
	{
	}

	// RVA: 0x1314194 Offset: 0x1314194 VA: 0x1314194
	private MFJGDLBFMEL_JsonReader(TextReader CLJIOLIEPNA_reader, bool BGEEMIIBLIO_owned)
	{
		if (CLJIOLIEPNA_reader == null)
			throw new ArgumentNullException ("reader");

		NKPNFFJBDEG_parser_in_string = false;
		HENOKDJPHKL_parser_return = false;

		EOJDFDKGCME_read_started = false;
		MPOFLJNAOEA_automaton_stack = new Stack<int> ();
		MPOFLJNAOEA_automaton_stack.Push ((int) HEEFEJINJEG_ParserToken.OLCLJKOKJCD_End);
		MPOFLJNAOEA_automaton_stack.Push ((int) HEEFEJINJEG_ParserToken.LNEGGPJJDLF_Text);

		IMIGLMKHEMM_lexer = new OFIGBFBNKKK_Lexer (CLJIOLIEPNA_reader);

		HMHNDKEOIPF_end_of_input = false;
		NPNHFHOJLCC_end_of_json  = false;

		this.CLJIOLIEPNA_reader = CLJIOLIEPNA_reader;
		KDJKICGGOOD_reader_is_owned = BGEEMIIBLIO_owned;
	}
	#endregion

	#region Static Methods
	// RVA: 0x1313780 Offset: 0x1313780 VA: 0x1313780
	private static void IEFNCAMFDGO_PopulateParseTable()
	{
		IECLGGPCKDD_parse_table = new Dictionary<int, IDictionary<int, int[]>> ();

		PKNJHMHGKOC_TableAddRow (HEEFEJINJEG_ParserToken.BDHGEFMCJDF_Array);
		KAEEEGFJHPK_TableAddCol (HEEFEJINJEG_ParserToken.BDHGEFMCJDF_Array, '[',
					 '[',
					 (int) HEEFEJINJEG_ParserToken.OBGLMJBOILP_ArrayPrime);

		PKNJHMHGKOC_TableAddRow (HEEFEJINJEG_ParserToken.OBGLMJBOILP_ArrayPrime);
		KAEEEGFJHPK_TableAddCol (HEEFEJINJEG_ParserToken.OBGLMJBOILP_ArrayPrime, '"',
					 (int) HEEFEJINJEG_ParserToken.BLNDFNMPILA_Value,

					 (int) HEEFEJINJEG_ParserToken.AFFKPGEIBOE_ValueRest,
					 ']');
		KAEEEGFJHPK_TableAddCol (HEEFEJINJEG_ParserToken.OBGLMJBOILP_ArrayPrime, '[',
					 (int) HEEFEJINJEG_ParserToken.BLNDFNMPILA_Value,
					 (int) HEEFEJINJEG_ParserToken.AFFKPGEIBOE_ValueRest,
					 ']');
		KAEEEGFJHPK_TableAddCol (HEEFEJINJEG_ParserToken.OBGLMJBOILP_ArrayPrime, ']',
					 ']');
		KAEEEGFJHPK_TableAddCol (HEEFEJINJEG_ParserToken.OBGLMJBOILP_ArrayPrime, '{',
					 (int) HEEFEJINJEG_ParserToken.BLNDFNMPILA_Value,
					 (int) HEEFEJINJEG_ParserToken.AFFKPGEIBOE_ValueRest,
					 ']');
		KAEEEGFJHPK_TableAddCol (HEEFEJINJEG_ParserToken.OBGLMJBOILP_ArrayPrime, (int) HEEFEJINJEG_ParserToken.EFKGLALIBLD_Number,
					 (int) HEEFEJINJEG_ParserToken.BLNDFNMPILA_Value,
					 (int) HEEFEJINJEG_ParserToken.AFFKPGEIBOE_ValueRest,
					 ']');
		KAEEEGFJHPK_TableAddCol (HEEFEJINJEG_ParserToken.OBGLMJBOILP_ArrayPrime, (int) HEEFEJINJEG_ParserToken.HGMKODAJIDB_True,
					 (int) HEEFEJINJEG_ParserToken.BLNDFNMPILA_Value,
					 (int) HEEFEJINJEG_ParserToken.AFFKPGEIBOE_ValueRest,
					 ']');
		KAEEEGFJHPK_TableAddCol (HEEFEJINJEG_ParserToken.OBGLMJBOILP_ArrayPrime, (int) HEEFEJINJEG_ParserToken.PJBFBJHFIGK_False,
					 (int) HEEFEJINJEG_ParserToken.BLNDFNMPILA_Value,
					 (int) HEEFEJINJEG_ParserToken.AFFKPGEIBOE_ValueRest,
					 ']');
		KAEEEGFJHPK_TableAddCol (HEEFEJINJEG_ParserToken.OBGLMJBOILP_ArrayPrime, (int) HEEFEJINJEG_ParserToken.GMKPJPDCMJM_Null,
					 (int) HEEFEJINJEG_ParserToken.BLNDFNMPILA_Value,
					 (int) HEEFEJINJEG_ParserToken.AFFKPGEIBOE_ValueRest,
					 ']');

		PKNJHMHGKOC_TableAddRow (HEEFEJINJEG_ParserToken.JKMLKAMHJIF_Object);
		KAEEEGFJHPK_TableAddCol (HEEFEJINJEG_ParserToken.JKMLKAMHJIF_Object, '{',
					 '{',
					 (int) HEEFEJINJEG_ParserToken.PMCPHBPMPDE_ObjectPrime);

		PKNJHMHGKOC_TableAddRow (HEEFEJINJEG_ParserToken.PMCPHBPMPDE_ObjectPrime);
		KAEEEGFJHPK_TableAddCol (HEEFEJINJEG_ParserToken.PMCPHBPMPDE_ObjectPrime, '"',
					 (int) HEEFEJINJEG_ParserToken.ABMFPJDCCFJ_Pair,
					 (int) HEEFEJINJEG_ParserToken.GAPFJMMAJHD_PairRest,
					 '}');
		KAEEEGFJHPK_TableAddCol (HEEFEJINJEG_ParserToken.PMCPHBPMPDE_ObjectPrime, '}',
					 '}');

		PKNJHMHGKOC_TableAddRow (HEEFEJINJEG_ParserToken.ABMFPJDCCFJ_Pair);
		KAEEEGFJHPK_TableAddCol (HEEFEJINJEG_ParserToken.ABMFPJDCCFJ_Pair, '"',
					 (int) HEEFEJINJEG_ParserToken.IAAHPCHFCFB_String,
					 ':',
					 (int) HEEFEJINJEG_ParserToken.BLNDFNMPILA_Value);

		PKNJHMHGKOC_TableAddRow (HEEFEJINJEG_ParserToken.GAPFJMMAJHD_PairRest);
		KAEEEGFJHPK_TableAddCol (HEEFEJINJEG_ParserToken.GAPFJMMAJHD_PairRest, ',',
					 ',',
					 (int) HEEFEJINJEG_ParserToken.ABMFPJDCCFJ_Pair,
					 (int) HEEFEJINJEG_ParserToken.GAPFJMMAJHD_PairRest);
		KAEEEGFJHPK_TableAddCol (HEEFEJINJEG_ParserToken.GAPFJMMAJHD_PairRest, '}',
					 (int) HEEFEJINJEG_ParserToken.HMBHHJPKNKI_Epsilon);

		PKNJHMHGKOC_TableAddRow (HEEFEJINJEG_ParserToken.IAAHPCHFCFB_String);
		KAEEEGFJHPK_TableAddCol (HEEFEJINJEG_ParserToken.IAAHPCHFCFB_String, '"',
					 '"',
					 (int) HEEFEJINJEG_ParserToken.KJCGALJGLNF_CharSeq,
					 '"');

		PKNJHMHGKOC_TableAddRow (HEEFEJINJEG_ParserToken.LNEGGPJJDLF_Text);
		KAEEEGFJHPK_TableAddCol (HEEFEJINJEG_ParserToken.LNEGGPJJDLF_Text, '[',
					 (int) HEEFEJINJEG_ParserToken.BDHGEFMCJDF_Array);
		KAEEEGFJHPK_TableAddCol (HEEFEJINJEG_ParserToken.LNEGGPJJDLF_Text, '{',
					 (int) HEEFEJINJEG_ParserToken.JKMLKAMHJIF_Object);

		PKNJHMHGKOC_TableAddRow (HEEFEJINJEG_ParserToken.BLNDFNMPILA_Value);
		KAEEEGFJHPK_TableAddCol (HEEFEJINJEG_ParserToken.BLNDFNMPILA_Value, '"',
					 (int) HEEFEJINJEG_ParserToken.IAAHPCHFCFB_String);
		KAEEEGFJHPK_TableAddCol (HEEFEJINJEG_ParserToken.BLNDFNMPILA_Value, '[',
					 (int) HEEFEJINJEG_ParserToken.BDHGEFMCJDF_Array);
		KAEEEGFJHPK_TableAddCol (HEEFEJINJEG_ParserToken.BLNDFNMPILA_Value, '{',
					 (int) HEEFEJINJEG_ParserToken.JKMLKAMHJIF_Object);
		KAEEEGFJHPK_TableAddCol (HEEFEJINJEG_ParserToken.BLNDFNMPILA_Value, (int) HEEFEJINJEG_ParserToken.EFKGLALIBLD_Number,
					 (int) HEEFEJINJEG_ParserToken.EFKGLALIBLD_Number);
		KAEEEGFJHPK_TableAddCol (HEEFEJINJEG_ParserToken.BLNDFNMPILA_Value, (int) HEEFEJINJEG_ParserToken.HGMKODAJIDB_True,
					 (int) HEEFEJINJEG_ParserToken.HGMKODAJIDB_True);
		KAEEEGFJHPK_TableAddCol (HEEFEJINJEG_ParserToken.BLNDFNMPILA_Value, (int) HEEFEJINJEG_ParserToken.PJBFBJHFIGK_False,
					 (int) HEEFEJINJEG_ParserToken.PJBFBJHFIGK_False);
		KAEEEGFJHPK_TableAddCol (HEEFEJINJEG_ParserToken.BLNDFNMPILA_Value, (int) HEEFEJINJEG_ParserToken.GMKPJPDCMJM_Null,
					 (int) HEEFEJINJEG_ParserToken.GMKPJPDCMJM_Null);

		PKNJHMHGKOC_TableAddRow (HEEFEJINJEG_ParserToken.AFFKPGEIBOE_ValueRest);
		KAEEEGFJHPK_TableAddCol (HEEFEJINJEG_ParserToken.AFFKPGEIBOE_ValueRest, ',',
					 ',',
					 (int) HEEFEJINJEG_ParserToken.BLNDFNMPILA_Value,
					 (int) HEEFEJINJEG_ParserToken.AFFKPGEIBOE_ValueRest);
		KAEEEGFJHPK_TableAddCol (HEEFEJINJEG_ParserToken.AFFKPGEIBOE_ValueRest, ']',
					 (int) HEEFEJINJEG_ParserToken.HMBHHJPKNKI_Epsilon);
	}


	// RVA: 0x1314488 Offset: 0x1314488 VA: 0x1314488
	private static void KAEEEGFJHPK_TableAddCol (HEEFEJINJEG_ParserToken LGOIONKNCIO_row, int IJMAKKFPAJP_col, params int[] JEOOFBDDEEI_symbols)
	{
		IECLGGPCKDD_parse_table[(int) LGOIONKNCIO_row].Add (IJMAKKFPAJP_col, JEOOFBDDEEI_symbols);
	}

	// RVA: 0x1314338 Offset: 0x1314338 VA: 0x1314338
	private static void PKNJHMHGKOC_TableAddRow (HEEFEJINJEG_ParserToken NKGJOAEDCPH_rule)
	{
		IECLGGPCKDD_parse_table.Add ((int) NKGJOAEDCPH_rule, new Dictionary<int, int[]> ());
	}
	#endregion

	#region Private Methods
	// RVA: 0x1314648 Offset: 0x1314648 VA: 0x1314648
	private void NHLLGPEEFGE_ProcessNumber(string AMFBGBPJEEC_number)
	{
		if (AMFBGBPJEEC_number.IndexOf ('.') != -1 ||
			AMFBGBPJEEC_number.IndexOf ('e') != -1 ||
			AMFBGBPJEEC_number.IndexOf ('E') != -1) {

			double n_double;
			if (Double.TryParse (AMFBGBPJEEC_number, out n_double)) {
				JCOGNKFNDEB_token = LIMGNGJNDAK_JsonToken.PFOFBNKFKCA_Double;
				PADBJIMKLDG_token_value = n_double;

				return;
			}
		}

		int n_int32;
		if (Int32.TryParse (AMFBGBPJEEC_number, out n_int32)) {
			JCOGNKFNDEB_token = LIMGNGJNDAK_JsonToken.CEIBAFOCNCA_Int;
			PADBJIMKLDG_token_value = n_int32;

			return;
		}

		long n_int64;
		if (Int64.TryParse (AMFBGBPJEEC_number, out n_int64)) {
			JCOGNKFNDEB_token = LIMGNGJNDAK_JsonToken.HJBKGEBNJMP_Long;
			PADBJIMKLDG_token_value = n_int64;

			return;
		}

		// Shouldn't happen, but just in case, return something
		JCOGNKFNDEB_token = LIMGNGJNDAK_JsonToken.CEIBAFOCNCA_Int;
		PADBJIMKLDG_token_value = 0;
	}

	// RVA: 0x1314838 Offset: 0x1314838 VA: 0x1314838
	private void DDCNOPIBJDM_ProcessSymbol ()
	{
		if (KFKNLCDJAAB_current_symbol == '[')  {
			JCOGNKFNDEB_token = LIMGNGJNDAK_JsonToken.LNNBLGKFCCA_ArrayStart;
			HENOKDJPHKL_parser_return = true;

		} else if (KFKNLCDJAAB_current_symbol == ']')  {
			JCOGNKFNDEB_token = LIMGNGJNDAK_JsonToken.HCCMCHLILCI_ArrayEnd;
			HENOKDJPHKL_parser_return = true;

		} else if (KFKNLCDJAAB_current_symbol == '{')  {
			JCOGNKFNDEB_token = LIMGNGJNDAK_JsonToken.EKHMLPGOKGB_ObjectStart;
			HENOKDJPHKL_parser_return = true;

		} else if (KFKNLCDJAAB_current_symbol == '}')  {
			JCOGNKFNDEB_token = LIMGNGJNDAK_JsonToken.EANBLFODAJI_ObjectEnd;
			HENOKDJPHKL_parser_return = true;

		} else if (KFKNLCDJAAB_current_symbol == '"')  {
			if (NKPNFFJBDEG_parser_in_string) {
				NKPNFFJBDEG_parser_in_string = false;

				HENOKDJPHKL_parser_return = true;

			} else {
				if (JCOGNKFNDEB_token == LIMGNGJNDAK_JsonToken.HJNNKCMLGFL_None)
					JCOGNKFNDEB_token = LIMGNGJNDAK_JsonToken.IAAHPCHFCFB_String;

				NKPNFFJBDEG_parser_in_string = true;
			}

		} else if (KFKNLCDJAAB_current_symbol == (int) HEEFEJINJEG_ParserToken.KJCGALJGLNF_CharSeq) {
			PADBJIMKLDG_token_value = IMIGLMKHEMM_lexer.OHCPHCODKPN_StringValue;

		} else if (KFKNLCDJAAB_current_symbol == (int) HEEFEJINJEG_ParserToken.PJBFBJHFIGK_False)  {
			JCOGNKFNDEB_token = LIMGNGJNDAK_JsonToken.JIJLIKNGOOH_Boolean;
			PADBJIMKLDG_token_value = false;
			HENOKDJPHKL_parser_return = true;

		} else if (KFKNLCDJAAB_current_symbol == (int) HEEFEJINJEG_ParserToken.GMKPJPDCMJM_Null)  {
			JCOGNKFNDEB_token = LIMGNGJNDAK_JsonToken.GMKPJPDCMJM_Null;
			HENOKDJPHKL_parser_return = true;

		} else if (KFKNLCDJAAB_current_symbol == (int) HEEFEJINJEG_ParserToken.EFKGLALIBLD_Number)  {
			NHLLGPEEFGE_ProcessNumber (IMIGLMKHEMM_lexer.OHCPHCODKPN_StringValue);

			HENOKDJPHKL_parser_return = true;

		} else if (KFKNLCDJAAB_current_symbol == (int) HEEFEJINJEG_ParserToken.ABMFPJDCCFJ_Pair)  {
			JCOGNKFNDEB_token = LIMGNGJNDAK_JsonToken.LPHOANHJJNH_PropertyName;

		} else if (KFKNLCDJAAB_current_symbol == (int) HEEFEJINJEG_ParserToken.HGMKODAJIDB_True)  {
			JCOGNKFNDEB_token = LIMGNGJNDAK_JsonToken.JIJLIKNGOOH_Boolean;
			PADBJIMKLDG_token_value = true;
			HENOKDJPHKL_parser_return = true;

		}
	}

	// RVA: 0x1314A60 Offset: 0x1314A60 VA: 0x1314A60
	private bool AEDKONGFAAH_ReadToken()
	{
		if (HMHNDKEOIPF_end_of_input)
			return false;

		IMIGLMKHEMM_lexer.IMFJMDAHLEJ_NextToken ();

		if (IMIGLMKHEMM_lexer.BADOHMHEOHN_EndOfInput) {
			MDFLPFDFDAO_Close ();

			return false;
		}

		JBCHENGIGOP_current_input = IMIGLMKHEMM_lexer.FDPPJPGNCMK_Token;

		return true;
	}
	#endregion

	// RVA: 0x1314B04 Offset: 0x1314B04 VA: 0x1314B04
	public void MDFLPFDFDAO_Close ()
    {
		if (HMHNDKEOIPF_end_of_input)
			return;

		HMHNDKEOIPF_end_of_input = true;
		NPNHFHOJLCC_end_of_json  = true;

		if (KDJKICGGOOD_reader_is_owned)
			CLJIOLIEPNA_reader.Close ();

		CLJIOLIEPNA_reader = null;
	}

	// RVA: 0x1314B64 Offset: 0x1314B64 VA: 0x1314B64
	public bool FKGBNKPHCJL_Read()
	{
		if (HMHNDKEOIPF_end_of_input)
			return false;

		if (NPNHFHOJLCC_end_of_json) {
			NPNHFHOJLCC_end_of_json = false;
			MPOFLJNAOEA_automaton_stack.Clear ();
			MPOFLJNAOEA_automaton_stack.Push ((int) HEEFEJINJEG_ParserToken.OLCLJKOKJCD_End);
			MPOFLJNAOEA_automaton_stack.Push ((int) HEEFEJINJEG_ParserToken.LNEGGPJJDLF_Text);
		}

		NKPNFFJBDEG_parser_in_string = false;
		HENOKDJPHKL_parser_return    = false;

		JCOGNKFNDEB_token       = LIMGNGJNDAK_JsonToken.HJNNKCMLGFL_None;
		PADBJIMKLDG_token_value = null;

		if (! EOJDFDKGCME_read_started) {
			EOJDFDKGCME_read_started = true;

			if (! AEDKONGFAAH_ReadToken ())
				return false;
		}


		int[] entry_symbols;

		while (true) {
			if (HENOKDJPHKL_parser_return) {
				if (MPOFLJNAOEA_automaton_stack.Peek () == (int) HEEFEJINJEG_ParserToken.OLCLJKOKJCD_End)
					NPNHFHOJLCC_end_of_json = true;

				return true;
			}

			KFKNLCDJAAB_current_symbol = MPOFLJNAOEA_automaton_stack.Pop ();

			DDCNOPIBJDM_ProcessSymbol ();

			if (KFKNLCDJAAB_current_symbol == JBCHENGIGOP_current_input) {
				if (! AEDKONGFAAH_ReadToken ()) {
					if (MPOFLJNAOEA_automaton_stack.Peek () != (int) HEEFEJINJEG_ParserToken.OLCLJKOKJCD_End)
						throw new IKFDGFEAJPL_JsonException (
							"Input doesn't evaluate to proper JSON text");

					if (HENOKDJPHKL_parser_return)
						return true;

					return false;
				}

				continue;
			}

			try {

				entry_symbols =
					IECLGGPCKDD_parse_table[KFKNLCDJAAB_current_symbol][JBCHENGIGOP_current_input];

			} catch (KeyNotFoundException e) {
				throw new IKFDGFEAJPL_JsonException ((HEEFEJINJEG_ParserToken) JBCHENGIGOP_current_input, e);
			}

			if (entry_symbols[0] == (int) HEEFEJINJEG_ParserToken.HMBHHJPKNKI_Epsilon)
				continue;

			for (int i = entry_symbols.Length - 1; i >= 0; i--)
				MPOFLJNAOEA_automaton_stack.Push (entry_symbols[i]);
		}
	}

}
