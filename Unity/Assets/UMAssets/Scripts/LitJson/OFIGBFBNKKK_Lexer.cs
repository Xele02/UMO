using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

internal class GCCDDJPHNMC_FsmContext
{
	// Fields
	public bool KEBIIAMNKAJ_Return; // 0x8
	public int FJLLOPCNALE_NextState; // 0xC
	public OFIGBFBNKKK_Lexer LHFLKEHHBHH_L; // 0x10
	public int KAGAEHNKCEN_StateStack; // 0x14

}

// Namespace: 
internal class OFIGBFBNKKK_Lexer // TypeDefIndex: 18715
{

	#region Fields
	private delegate bool APAPHJJPDIH_StateHandler(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx);

	private static int[] FCHDCNMNOME_fsm_return_table; // 0x0
	private static APAPHJJPDIH_StateHandler[] PPOAPPJDMKB_fsm_handler_table; // 0x4
	private bool POOCLDIALDJ_allow_comments; // 0x8
	private bool EAJKFKCMFEM_allow_single_quoted_strings; // 0x9
	private bool HMHNDKEOIPF_end_of_input; // 0xA
	private GCCDDJPHNMC_FsmContext PLJAMMLMPPL_fsm_context; // 0xC
	private int PPCDJGBIMAK_input_buffer; // 0x10
	private int PLANKOHCEGK_input_char; // 0x14
	private TextReader CLJIOLIEPNA_reader; // 0x18
	private int LHMDABPNDDH_state; // 0x1C
	private StringBuilder MFMFOGDCLGF_string_buffer; // 0x20
	private string FDDNPBFJMEP_string_value; // 0x24
	private int JCOGNKFNDEB_token; // 0x28
	private int FBLCBJKJDNH_unichar; // 0x2C
	#endregion

	#region Properties
	// // RVA: 0x1DCE574 Offset: 0x1DCE574 VA: 0x1DCE574
	// public bool CELGLBHMGFD() { }
	// // RVA: 0x1DCE57C Offset: 0x1DCE57C VA: 0x1DCE57C
	// public void EBLEFGNMNAK(bool NANNGLGOFKH) { }
	public bool KCAALEDBLEN_AllowComments
	{
		get { return POOCLDIALDJ_allow_comments; }
		set { POOCLDIALDJ_allow_comments = value; }
	}

	// // RVA: 0x1DCE584 Offset: 0x1DCE584 VA: 0x1DCE584
	// public bool IOHEILNOGLK() { }
	// // RVA: 0x1DCE58C Offset: 0x1DCE58C VA: 0x1DCE58C
	// public void NJIGIFMIGLB(bool NANNGLGOFKH) { }
	public bool MOGFDBHPGMG_AllowSingleQuotedStrings
	{
		get { return EAJKFKCMFEM_allow_single_quoted_strings; }
		set { EAJKFKCMFEM_allow_single_quoted_strings = value; }
	}

	// // RVA: 0x1DCE594 Offset: 0x1DCE594 VA: 0x1DCE594
	//public bool PHDFMENIOFF()
	public bool BADOHMHEOHN_EndOfInput
	{
		get { return HMHNDKEOIPF_end_of_input; }
	}

	// // RVA: 0x1DCE59C Offset: 0x1DCE59C VA: 0x1DCE59C
	//public int HEBLJBNFHGA() 
	public int FDPPJPGNCMK_Token
	{
		get { return JCOGNKFNDEB_token; }
	}

	// // RVA: 0x1DCE5A4 Offset: 0x1DCE5A4 VA: 0x1DCE5A4
	// public string JLDDBEBFDDG() { }
	public string OHCPHCODKPN_StringValue
	{
		get { return FDDNPBFJMEP_string_value; }
	}
	#endregion

	#region Constructors
	// // RVA: 0x1DCE5AC Offset: 0x1DCE5AC VA: 0x1DCE5AC
	static OFIGBFBNKKK_Lexer() 
    {
		HJIMBHNPJGI_PopulateFsmTables();
	}

	// // RVA: 0x1DCF608 Offset: 0x1DCF608 VA: 0x1DCF608
	public OFIGBFBNKKK_Lexer(TextReader CLJIOLIEPNA_reader)
	{
		POOCLDIALDJ_allow_comments = true;
		EAJKFKCMFEM_allow_single_quoted_strings = true;

		PPCDJGBIMAK_input_buffer = 0;
		MFMFOGDCLGF_string_buffer = new StringBuilder(128);
		LHMDABPNDDH_state = 1;
		HMHNDKEOIPF_end_of_input = false;
		this.CLJIOLIEPNA_reader = CLJIOLIEPNA_reader;

		PLJAMMLMPPL_fsm_context = new GCCDDJPHNMC_FsmContext();
		PLJAMMLMPPL_fsm_context.LHFLKEHHBHH_L = this;
	}
	#endregion

	#region Static Methods
	// // RVA: 0x1DCF6E4 Offset: 0x1DCF6E4 VA: 0x1DCF6E4
	private static int EDHBDPLKBFM_HexValue(int NDMELJPEKHG_digit)
	{
		switch (NDMELJPEKHG_digit)
		{
			case 'a':
			case 'A':
				return 10;

			case 'b':
			case 'B':
				return 11;

			case 'c':
			case 'C':
				return 12;

			case 'd':
			case 'D':
				return 13;

			case 'e':
			case 'E':
				return 14;

			case 'f':
			case 'F':
				return 15;

			default:
				return NDMELJPEKHG_digit - '0';
		}
	}

	// // RVA: 0x1DCE5B0 Offset: 0x1DCE5B0 VA: 0x1DCE5B0
	private static void HJIMBHNPJGI_PopulateFsmTables()
	{
		// See section A.1. of the manual for details of the finite
		// state machine.
		PPOAPPJDMKB_fsm_handler_table = new APAPHJJPDIH_StateHandler[28] {
				MBNOEEHJENI_State1,
				OKBIDLDAILG_State2,
				LIPJJBCEABN_State3,
				DPMKABIOAMC_State4,
				BNHOIEDLBCE_State5,
				IKPLGHHMAFK_State6,
				EBLBIEMDJLH_State7,
				ANMLKKDJGEM_State8,
				NELNKKBJKMP_State9,
				DCDPNBHGCAL_State10,
				HEJHPEJGHLD_State11,
				DFFKCFDPOPP_State12,
				BJGCDFFAKKB_State13,
				JEMCABBLHEF_State14,
				PHMCFPHNAGE_State15,
				HJPBHIANLAF_State16,
				HIKLJANANCA_State17,
				DMNFALPHBCN_State18,
				NDJIAEANIPN_State19,
				CDIMLBGHLIK_State20,
				ACAOIDIIPHK_State21,
				MEACDDMAICH_State22,
				ANJODFOAFMO_State23,
				FBJIOOHOHEL_State24,
				HGOMFKNHFAE_State25,
				PBGKCCOMGHO_State26,
				MGHJCPJIIEI_State27,
				PKOPLEHBHGM_State28
			};

		FCHDCNMNOME_fsm_return_table = new int[28] {
				(int) HEEFEJINJEG_ParserToken.BOPKLJPPICM_Char,
				0,
				(int) HEEFEJINJEG_ParserToken.EFKGLALIBLD_Number,
				(int) HEEFEJINJEG_ParserToken.EFKGLALIBLD_Number,
				0,
				(int) HEEFEJINJEG_ParserToken.EFKGLALIBLD_Number,
				0,
				(int) HEEFEJINJEG_ParserToken.EFKGLALIBLD_Number,
				0,
				0,
				(int) HEEFEJINJEG_ParserToken.HGMKODAJIDB_True,
				0,
				0,
				0,
				(int) HEEFEJINJEG_ParserToken.PJBFBJHFIGK_False,
				0,
				0,
				(int) HEEFEJINJEG_ParserToken.GMKPJPDCMJM_Null,
				(int) HEEFEJINJEG_ParserToken.KJCGALJGLNF_CharSeq,
				(int) HEEFEJINJEG_ParserToken.BOPKLJPPICM_Char,
				0,
				0,
				(int) HEEFEJINJEG_ParserToken.KJCGALJGLNF_CharSeq,
				(int) HEEFEJINJEG_ParserToken.BOPKLJPPICM_Char,
				0,
				0,
				0,
				0
			};
	}

	// // RVA: 0x1DCF79C Offset: 0x1DCF79C VA: 0x1DCF79C
	private static char APCGBGCKMIF_ProcessEscChar(int EMDBGPOKOMD_esc_char)
	{
		switch (EMDBGPOKOMD_esc_char)
		{
			case '"':
			case '\'':
			case '\\':
			case '/':
				return Convert.ToChar(EMDBGPOKOMD_esc_char);

			case 'n':
				return '\n';

			case 't':
				return '\t';

			case 'r':
				return '\r';

			case 'b':
				return '\b';

			case 'f':
				return '\f';

			default:
				// Unreachable
				return '?';
		}
	}

	// // RVA: 0x1DCF8A8 Offset: 0x1DCF8A8 VA: 0x1DCF8A8
	private static bool MBNOEEHJENI_State1(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
	{
		while (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.GPNJFELBIPF_GetChar())
		{
			if (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char == ' ' ||
				FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char >= '\t' && FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char <= '\r')
				continue;

			if (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char >= '1' && FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char <= '9')
			{
				FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append((char)FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char);
				FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 3;
				return true;
			}

			switch (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char)
			{
				case '"':
					FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 19;
					FNEJPLJCAIF_ctx.KEBIIAMNKAJ_Return = true;
					return true;

				case ',':
				case ':':
				case '[':
				case ']':
				case '{':
				case '}':
					FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 1;
					FNEJPLJCAIF_ctx.KEBIIAMNKAJ_Return = true;
					return true;

				case '-':
					FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append((char)FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char);
					FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 2;
					return true;

				case '0':
					FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append((char)FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char);
					FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 4;
					return true;

				case 'f':
					FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 12;
					return true;

				case 'n':
					FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 16;
					return true;

				case 't':
					FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 9;
					return true;

				case '\'':
					if (!FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.EAJKFKCMFEM_allow_single_quoted_strings)
						return false;

					FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char = '"';
					FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 23;
					FNEJPLJCAIF_ctx.KEBIIAMNKAJ_Return = true;
					return true;

				case '/':
					if (!FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.POOCLDIALDJ_allow_comments)
						return false;

					FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 25;
					return true;

				default:
					return false;
			}
		}

		return true;
	}

	// // RVA: 0x1DCFC48 Offset: 0x1DCFC48 VA: 0x1DCFC48
	private static bool OKBIDLDAILG_State2(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
	{
		FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.GPNJFELBIPF_GetChar();

		if (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char >= '1' && FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char <= '9')
		{
			FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append((char)FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char);
			FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 3;
			return true;
		}

		switch (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char)
		{
			case '0':
				FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append((char)FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char);
				FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 4;
				return true;

			default:
				return false;
		}
	}

	// // RVA: 0x1DCFDB0 Offset: 0x1DCFDB0 VA: 0x1DCFDB0
	private static bool LIPJJBCEABN_State3(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
	{
		while (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.GPNJFELBIPF_GetChar())
		{
			if (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char >= '0' && FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char <= '9')
			{
				FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append((char)FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char);
				continue;
			}

			if (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char == ' ' ||
				FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char >= '\t' && FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char <= '\r')
			{
				FNEJPLJCAIF_ctx.KEBIIAMNKAJ_Return = true;
				FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 1;
				return true;
			}

			switch (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char)
			{
				case ',':
				case ']':
				case '}':
					FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.HBBJBJKFOKN_UngetChar();
					FNEJPLJCAIF_ctx.KEBIIAMNKAJ_Return = true;
					FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 1;
					return true;

				case '.':
					FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append((char)FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char);
					FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 5;
					return true;

				case 'e':
				case 'E':
					FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append((char)FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char);
					FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 7;
					return true;

				default:
					return false;
			}
		}
		return true;
	}

	// // RVA: 0x1DD0040 Offset: 0x1DD0040 VA: 0x1DD0040
	private static bool DPMKABIOAMC_State4(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
	{
		FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.GPNJFELBIPF_GetChar();

		if (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char == ' ' ||
			FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char >= '\t' && FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char <= '\r')
		{
			FNEJPLJCAIF_ctx.KEBIIAMNKAJ_Return = true;
			FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 1;
			return true;
		}

		switch (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char)
		{
			case ',':
			case ']':
			case '}':
				FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.HBBJBJKFOKN_UngetChar();
				FNEJPLJCAIF_ctx.KEBIIAMNKAJ_Return = true;
				FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 1;
				return true;

			case '.':
				FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append((char)FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char);
				FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 5;
				return true;

			case 'e':
			case 'E':
				FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append((char)FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char);
				FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 7;
				return true;

			default:
				return false;
		}
	}

	// // RVA: 0x1DD022C Offset: 0x1DD022C VA: 0x1DD022C
	private static bool BNHOIEDLBCE_State5(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
	{
		FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.GPNJFELBIPF_GetChar();

		if (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char >= '0' && FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char <= '9')
		{
			FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append((char)FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char);
			FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 6;
			return true;
		}

		return false;
	}

	// // RVA: 0x1DD0324 Offset: 0x1DD0324 VA: 0x1DD0324
	private static bool IKPLGHHMAFK_State6(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
	{
		while (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.GPNJFELBIPF_GetChar())
		{
			if (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char >= '0' && FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char <= '9')
			{
				FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append((char)FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char);
				continue;
			}

			if (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char == ' ' ||
				FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char >= '\t' && FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char <= '\r')
			{
				FNEJPLJCAIF_ctx.KEBIIAMNKAJ_Return = true;
				FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 1;
				return true;
			}

			switch (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char)
			{
				case ',':
				case ']':
				case '}':
					FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.HBBJBJKFOKN_UngetChar();
					FNEJPLJCAIF_ctx.KEBIIAMNKAJ_Return = true;
					FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 1;
					return true;

				case 'e':
				case 'E':
					FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append((char)FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char);
					FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 7;
					return true;

				default:
					return false;
			}
		}

		return true;
	}

	// // RVA: 0x1DD054C Offset: 0x1DD054C VA: 0x1DD054C
	private static bool EBLBIEMDJLH_State7(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
	{
		FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.GPNJFELBIPF_GetChar();

		if (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char >= '0' && FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char <= '9')
		{
			FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append((char)FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char);
			FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 8;
			return true;
		}

		switch (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char)
		{
			case '+':
			case '-':
				FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append((char)FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char);
				FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 8;
				return true;

			default:
				return false;
		}
	}

	// // RVA: 0x1DD0668 Offset: 0x1DD0668 VA: 0x1DD0668
	private static bool ANMLKKDJGEM_State8(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
	{
		while (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.GPNJFELBIPF_GetChar())
		{
			if (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char >= '0' && FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char <= '9')
			{
				FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append((char)FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char);
				continue;
			}

			if (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char == ' ' ||
				FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char >= '\t' && FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char <= '\r')
			{
				FNEJPLJCAIF_ctx.KEBIIAMNKAJ_Return = true;
				FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 1;
				return true;
			}

			switch (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char)
			{
				case ',':
				case ']':
				case '}':
					FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.HBBJBJKFOKN_UngetChar();
					FNEJPLJCAIF_ctx.KEBIIAMNKAJ_Return = true;
					FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 1;
					return true;

				default:
					return false;
			}
		}

		return true;
	}

	// // RVA: 0x1DD0810 Offset: 0x1DD0810 VA: 0x1DD0810
	private static bool NELNKKBJKMP_State9(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
	{
		FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.GPNJFELBIPF_GetChar();

		switch (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char)
		{
			case 'r':
				FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 10;
				return true;

			default:
				return false;
		}
	}

	// // RVA: 0x1DD0888 Offset: 0x1DD0888 VA: 0x1DD0888
	private static bool DCDPNBHGCAL_State10(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
	{
		FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.GPNJFELBIPF_GetChar();

		switch (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char)
		{
			case 'u':
				FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 11;
				return true;

			default:
				return false;
		}
	}

	// // RVA: 0x1DD0900 Offset: 0x1DD0900 VA: 0x1DD0900
	private static bool HEJHPEJGHLD_State11(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
	{
		FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.GPNJFELBIPF_GetChar();

		switch (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char)
		{
			case 'e':
				FNEJPLJCAIF_ctx.KEBIIAMNKAJ_Return = true;
				FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 1;
				return true;

			default:
				return false;
		}
	}

	// // RVA: 0x1DD0978 Offset: 0x1DD0978 VA: 0x1DD0978
	private static bool DFFKCFDPOPP_State12(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
	{
		FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.GPNJFELBIPF_GetChar();

		switch (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char)
		{
			case 'a':
				FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 13;
				return true;

			default:
				return false;
		}
	}

	// // RVA: 0x1DD09F0 Offset: 0x1DD09F0 VA: 0x1DD09F0
	private static bool BJGCDFFAKKB_State13(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
	{
		FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.GPNJFELBIPF_GetChar();

		switch (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char)
		{
			case 'l':
				FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 14;
				return true;

			default:
				return false;
		}
	}

	// // RVA: 0x1DD0A68 Offset: 0x1DD0A68 VA: 0x1DD0A68
	private static bool JEMCABBLHEF_State14(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
	{
		FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.GPNJFELBIPF_GetChar();

		switch (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char)
		{
			case 's':
				FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 15;
				return true;

			default:
				return false;
		}
	}

	// // RVA: 0x1DD0AE0 Offset: 0x1DD0AE0 VA: 0x1DD0AE0
	private static bool PHMCFPHNAGE_State15(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
	{
		FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.GPNJFELBIPF_GetChar();

		switch (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char)
		{
			case 'e':
				FNEJPLJCAIF_ctx.KEBIIAMNKAJ_Return = true;
				FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 1;
				return true;

			default:
				return false;
		}
	}

	// // RVA: 0x1DD0B58 Offset: 0x1DD0B58 VA: 0x1DD0B58
	private static bool HJPBHIANLAF_State16(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
	{
		FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.GPNJFELBIPF_GetChar();

		switch (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char)
		{
			case 'u':
				FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 17;
				return true;

			default:
				return false;
		}
	}

	// // RVA: 0x1DD0BD0 Offset: 0x1DD0BD0 VA: 0x1DD0BD0
	private static bool HIKLJANANCA_State17(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
	{
		FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.GPNJFELBIPF_GetChar();

		switch (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char)
		{
			case 'l':
				FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 18;
				return true;

			default:
				return false;
		}
	}

	// // RVA: 0x1DD0C48 Offset: 0x1DD0C48 VA: 0x1DD0C48
	private static bool DMNFALPHBCN_State18(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
	{
		FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.GPNJFELBIPF_GetChar();

		switch (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char)
		{
			case 'l':
				FNEJPLJCAIF_ctx.KEBIIAMNKAJ_Return = true;
				FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 1;
				return true;

			default:
				return false;
		}
	}

	// // RVA: 0x1DD0CC0 Offset: 0x1DD0CC0 VA: 0x1DD0CC0
	private static bool NDJIAEANIPN_State19(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
	{
		while (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.GPNJFELBIPF_GetChar())
		{
			switch (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char)
			{
				case '"':
					FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.HBBJBJKFOKN_UngetChar();
					FNEJPLJCAIF_ctx.KEBIIAMNKAJ_Return = true;
					FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 20;
					return true;

				case '\\':
					FNEJPLJCAIF_ctx.KAGAEHNKCEN_StateStack = 19;
					FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 21;
					return true;

				default:
					FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append((char)FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char);
					continue;
			}
		}

		return true;
	}

	// // RVA: 0x1DD0DDC Offset: 0x1DD0DDC VA: 0x1DD0DDC
	private static bool CDIMLBGHLIK_State20(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
	{
		FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.GPNJFELBIPF_GetChar();

		switch (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char)
		{
			case '"':
				FNEJPLJCAIF_ctx.KEBIIAMNKAJ_Return = true;
				FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 1;
				return true;

			default:
				return false;
		}
	}

	// // RVA: 0x1DD0E54 Offset: 0x1DD0E54 VA: 0x1DD0E54
	private static bool ACAOIDIIPHK_State21(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
	{
		FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.GPNJFELBIPF_GetChar();

		switch (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char)
		{
			case 'u':
				FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 22;
				return true;

			case '"':
			case '\'':
			case '/':
			case '\\':
			case 'b':
			case 'f':
			case 'n':
			case 'r':
			case 't':
				FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append(
					APCGBGCKMIF_ProcessEscChar(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char));
				FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = FNEJPLJCAIF_ctx.KAGAEHNKCEN_StateStack;
				return true;

			default:
				return false;
		}
	}

	// // RVA: 0x1DD102C Offset: 0x1DD102C VA: 0x1DD102C
	private static bool MEACDDMAICH_State22(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
	{
		int counter = 0;
		int mult = 4096;

		FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.FBLCBJKJDNH_unichar = 0;

		while (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.GPNJFELBIPF_GetChar())
		{

			if (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char >= '0' && FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char <= '9' ||
				FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char >= 'A' && FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char <= 'F' ||
				FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char >= 'a' && FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char <= 'f')
			{

				FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.FBLCBJKJDNH_unichar += EDHBDPLKBFM_HexValue(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char) * mult;

				counter++;
				mult /= 16;

				if (counter == 4)
				{
					FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append(
						Convert.ToChar(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.FBLCBJKJDNH_unichar));
					FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = FNEJPLJCAIF_ctx.KAGAEHNKCEN_StateStack;
					return true;
				}

				continue;
			}

			return false;
		}

		return true;
	}

	// // RVA: 0x1DD135C Offset: 0x1DD135C VA: 0x1DD135C
	private static bool ANJODFOAFMO_State23(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
	{
		while (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.GPNJFELBIPF_GetChar())
		{
			switch (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char)
			{
				case '\'':
					FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.HBBJBJKFOKN_UngetChar();
					FNEJPLJCAIF_ctx.KEBIIAMNKAJ_Return = true;
					FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 24;
					return true;

				case '\\':
					FNEJPLJCAIF_ctx.KAGAEHNKCEN_StateStack = 23;
					FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 21;
					return true;

				default:
					FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append((char)FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char);
					continue;
			}
		}

		return true;
	}

	// // RVA: 0x1DD1478 Offset: 0x1DD1478 VA: 0x1DD1478
	private static bool FBJIOOHOHEL_State24(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
	{
		FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.GPNJFELBIPF_GetChar();

		switch (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char)
		{
			case '\'':
				FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char = '"';
				FNEJPLJCAIF_ctx.KEBIIAMNKAJ_Return = true;
				FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 1;
				return true;

			default:
				return false;
		}
	}

	// // RVA: 0x1DD1510 Offset: 0x1DD1510 VA: 0x1DD1510
	private static bool HGOMFKNHFAE_State25(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
	{
		FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.GPNJFELBIPF_GetChar();

		switch (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char)
		{
			case '*':
				FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 27;
				return true;

			case '/':
				FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 26;
				return true;

			default:
				return false;
		}
	}

	// // RVA: 0x1DD159C Offset: 0x1DD159C VA: 0x1DD159C
	private static bool PBGKCCOMGHO_State26(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
	{
		while (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.GPNJFELBIPF_GetChar())
		{
			if (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char == '\n')
			{
				FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 1;
				return true;
			}
		}

		return true;
	}

	// // RVA: 0x1DD161C Offset: 0x1DD161C VA: 0x1DD161C
	private static bool MGHJCPJIIEI_State27(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
	{
		while (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.GPNJFELBIPF_GetChar())
		{
			if (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char == '*')
			{
				FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 28;
				return true;
			}
		}

		return true;
	}

	// // RVA: 0x1DD169C Offset: 0x1DD169C VA: 0x1DD169C
	private static bool PKOPLEHBHGM_State28(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
	{
		while (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.GPNJFELBIPF_GetChar())
		{
			if (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char == '*')
				continue;

			if (FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char == '/')
			{
				FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 1;
				return true;
			}

			FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 27;
			return true;
		}

		return true;
	}
	#endregion

	// // RVA: 0x1DCFC18 Offset: 0x1DCFC18 VA: 0x1DCFC18
	private bool GPNJFELBIPF_GetChar()
	{
		if ((PLANKOHCEGK_input_char = LMOCBDODLCP_NextChar()) != -1)
			return true;

		HMHNDKEOIPF_end_of_input = true;
		return false;
	}

	// // RVA: 0x1DD173C Offset: 0x1DD173C VA: 0x1DD173C
	private int LMOCBDODLCP_NextChar()
	{
		if (PPCDJGBIMAK_input_buffer != 0)
		{
			int tmp = PPCDJGBIMAK_input_buffer;
			PPCDJGBIMAK_input_buffer = 0;

			return tmp;
		}

		return CLJIOLIEPNA_reader.Read();
	}

	// // RVA: 0x1DD1788 Offset: 0x1DD1788 VA: 0x1DD1788
	public bool IMFJMDAHLEJ_NextToken()
	{
		APAPHJJPDIH_StateHandler handler;
		PLJAMMLMPPL_fsm_context.KEBIIAMNKAJ_Return = false;

		while (true)
		{
			handler = PPOAPPJDMKB_fsm_handler_table[LHMDABPNDDH_state - 1];

			if (!handler(PLJAMMLMPPL_fsm_context))
				throw new IKFDGFEAJPL_JsonException(PLANKOHCEGK_input_char);

			if (HMHNDKEOIPF_end_of_input)
				return false;

			if (PLJAMMLMPPL_fsm_context.KEBIIAMNKAJ_Return)
			{
				FDDNPBFJMEP_string_value = MFMFOGDCLGF_string_buffer.ToString();
				MFMFOGDCLGF_string_buffer.Remove(0, MFMFOGDCLGF_string_buffer.Length);
				JCOGNKFNDEB_token = FCHDCNMNOME_fsm_return_table[LHMDABPNDDH_state - 1];

				if (JCOGNKFNDEB_token == (int)HEEFEJINJEG_ParserToken.BOPKLJPPICM_Char)
					JCOGNKFNDEB_token = PLANKOHCEGK_input_char;

				LHMDABPNDDH_state = PLJAMMLMPPL_fsm_context.FJLLOPCNALE_NextState;

				return true;
			}

			LHMDABPNDDH_state = PLJAMMLMPPL_fsm_context.FJLLOPCNALE_NextState;
		}
	}

	// // RVA: 0x1DD0034 Offset: 0x1DD0034 VA: 0x1DD0034
	private void HBBJBJKFOKN_UngetChar()
	{
		PPCDJGBIMAK_input_buffer = PLANKOHCEGK_input_char;
	}
}
