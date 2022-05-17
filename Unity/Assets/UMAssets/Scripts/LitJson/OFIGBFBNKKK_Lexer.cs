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

    private delegate bool APAPHJJPDIH_StateHandler(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx);

	// Fields
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
	// private int FBLCBJKJDNH_unichar; // 0x2C

	// // Properties
	// // RVA: 0x1DCE574 Offset: 0x1DCE574 VA: 0x1DCE574
	// public bool CELGLBHMGFD() { }
	// // RVA: 0x1DCE57C Offset: 0x1DCE57C VA: 0x1DCE57C
	// public void EBLEFGNMNAK(bool NANNGLGOFKH) { }
	public bool KCAALEDBLEN_AllowComments { get; set; }

	// // RVA: 0x1DCE584 Offset: 0x1DCE584 VA: 0x1DCE584
	// public bool IOHEILNOGLK() { }
	// // RVA: 0x1DCE58C Offset: 0x1DCE58C VA: 0x1DCE58C
	// public void NJIGIFMIGLB(bool NANNGLGOFKH) { }
	public bool MOGFDBHPGMG_AllowSingleQuotedStrings { get; set; }

	// // RVA: 0x1DCE594 Offset: 0x1DCE594 VA: 0x1DCE594
	//public bool PHDFMENIOFF()
	public bool BADOHMHEOHN_EndOfInput { get; }

	// // RVA: 0x1DCE59C Offset: 0x1DCE59C VA: 0x1DCE59C
	//public int HEBLJBNFHGA() 
	public int FDPPJPGNCMK_Token { get; }

	// // RVA: 0x1DCE5A4 Offset: 0x1DCE5A4 VA: 0x1DCE5A4
	// public string JLDDBEBFDDG() { }
	public string OHCPHCODKPN_StringValue { get; }

	// // Methods

	// // RVA: 0x1DCE5AC Offset: 0x1DCE5AC VA: 0x1DCE5AC
	static OFIGBFBNKKK_Lexer() 
    { 
        // TODO
        PPOAPPJDMKB_fsm_handler_table = new APAPHJJPDIH_StateHandler[28];
        int Idx = 0;
        PPOAPPJDMKB_fsm_handler_table[Idx++] = MBNOEEHJENI_State1;
        PPOAPPJDMKB_fsm_handler_table[Idx++] = OKBIDLDAILG_State2;
        PPOAPPJDMKB_fsm_handler_table[Idx++] = LIPJJBCEABN_State3;
        PPOAPPJDMKB_fsm_handler_table[Idx++] = DPMKABIOAMC_State4;
        // Add all static func
        FCHDCNMNOME_fsm_return_table = new int[28] {
            0x00010006, 
            0x00000000, 
            0x00010001,
            0x00010001, 
            0x00000000, 
            0x00010001,
            0x00000000, 
            0x00010001, 
            0x00000000,
            0x00000000, 
            0x00010002, 
            0x00000000,
            0x00000000, 
            0x00000000, 
            0x00010003,
            0x00000000, 
            0x00000000, 
            0x00010004,
            0x00010005, 
            0x00010006, 
            0x00000000,
            0x00000000, 
            0x00010005, 
            0x00010006,
            0x00000000, 
            0x00000000, 
            0x00000000,
            0x00000000
        };

    }

	// // RVA: 0x1DCF608 Offset: 0x1DCF608 VA: 0x1DCF608
	public OFIGBFBNKKK_Lexer(TextReader CLJIOLIEPNA_reader) 
    { 
        // TODO
        PPCDJGBIMAK_input_buffer = 0;
        POOCLDIALDJ_allow_comments = true;
        EAJKFKCMFEM_allow_single_quoted_strings = false;
        HMHNDKEOIPF_end_of_input = false; // true then false ?!
        this.CLJIOLIEPNA_reader = CLJIOLIEPNA_reader;
        LHMDABPNDDH_state = 1;
        MFMFOGDCLGF_string_buffer = new StringBuilder(128);
        PLJAMMLMPPL_fsm_context = new GCCDDJPHNMC_FsmContext();
        PLJAMMLMPPL_fsm_context.LHFLKEHHBHH_L = this;
    }

	// // RVA: 0x1DCF6E4 Offset: 0x1DCF6E4 VA: 0x1DCF6E4
	// private static int EDHBDPLKBFM_HexValue(int NDMELJPEKHG_digit) { }

	// // RVA: 0x1DCE5B0 Offset: 0x1DCE5B0 VA: 0x1DCE5B0
	// private static void HJIMBHNPJGI_PopulateFsmTables() { }

	// // RVA: 0x1DCF79C Offset: 0x1DCF79C VA: 0x1DCF79C
	// private static char APCGBGCKMIF_ProcessEscChar(int EMDBGPOKOMD_esc_char) { }

	// // RVA: 0x1DCF8A8 Offset: 0x1DCF8A8 VA: 0x1DCF8A8
	private static bool MBNOEEHJENI_State1(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
    { 
        do
        {
            do
            {
                FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char = FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.LMOCBDODLCP_NextChar();
                if(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char == -1)
                {
                    FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.HMHNDKEOIPF_end_of_input = true;
                    return true;
                }
            } while(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char == ' ');
            if(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char < 9)
                break;
        } while(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char < 14);
        int f = 0;
        if(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char < '1' || '9' < FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char)
        {
            int readChar = FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char;
            if(readChar < '\\')
            {
                if(readChar < '(')
                {
                    if(readChar == '"')
                    {
                        f = 0x13;
                    }
                    else
                    {
                        if(readChar != '\'')
                        {
                            return false;
                        }
                        if(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.EAJKFKCMFEM_allow_single_quoted_strings == false)
                            return false;
                        FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char = '\"';
                        f = 0x17;
                    }
                    FNEJPLJCAIF_ctx.KEBIIAMNKAJ_Return = true;
                    FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = f;
                    return true;
                }
                bool b = false;
                switch(readChar)
                {
                    case '-':
                        FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char);
                        f = 2;
                        break;
                    case '.':
                        FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = f;
                        return true;
                        break;
                    case '/':
                        if(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.POOCLDIALDJ_allow_comments == false)
                            return false;
                        f = 0x19;
                        break;
                    case '0':
                        FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char);
                        f = 4;
                        break;
                    case ',':
                        FNEJPLJCAIF_ctx.KEBIIAMNKAJ_Return = true;
                        FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 1;
                        return true;
                        break;
                    default:
                        if(readChar != ':' && readChar != '[')
                            return false;
                        FNEJPLJCAIF_ctx.KEBIIAMNKAJ_Return = true;
                        FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 1;
                        return true;
                        break;
                }
            }
            else if(readChar < 'o')
            {
                if(readChar == ']')
                {
                    FNEJPLJCAIF_ctx.KEBIIAMNKAJ_Return = true;
                    FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 1;
                    return true;
                }
                if(readChar == 'f')
                {
                    f = 0xc;
                }
                else
                {
                    if(readChar != 'n')
                    {
                        return false;
                    }
                    f = 0x10;
                }
            }
            else
            {
                if(readChar != 't')
                {
                    if(readChar != '{' && readChar != '}')
                    {
                        return readChar != '}';
                    }
                    FNEJPLJCAIF_ctx.KEBIIAMNKAJ_Return = true;
                    FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 1;
                    return true;
                }
                f = 9;
            }
        }
        else
        {
            FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char);
            f = 3;
        }
        FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = f;
        return true;
    }

	// // RVA: 0x1DCFC48 Offset: 0x1DCFC48 VA: 0x1DCFC48
	private static bool OKBIDLDAILG_State2(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx) 
    { 
        int f = 0;
        FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char = FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.LMOCBDODLCP_NextChar();
        if(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char == -1)
            FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.HMHNDKEOIPF_end_of_input = true;
        if(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char > '0')
        {
            if(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char < ':')
            {
                FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char);
                FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 3;
                return true;
            }
        }
        if(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char != '0')
            return false;
        FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char);
        FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 4;
        return true;
    }

	// // RVA: 0x1DCFDB0 Offset: 0x1DCFDB0 VA: 0x1DCFDB0
	private static bool LIPJJBCEABN_State3(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
    {
        while(true)
        {
            FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char = FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.LMOCBDODLCP_NextChar();
            if(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char == -1)
            {
                FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.HMHNDKEOIPF_end_of_input = true;
                return true;
            }
            if(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char < '0')
                break;
            if(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char > '9')
                break;
            FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char);
        }
        if(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char == ' ')
        {
            FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 1;
            FNEJPLJCAIF_ctx.KEBIIAMNKAJ_Return = true;
            return true;
        }
        if(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char > 8)
        {
            if(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char < 0xe)
            {
                FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 1;
                FNEJPLJCAIF_ctx.KEBIIAMNKAJ_Return = true;
                return true;
            }
        }
        int readChar = FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char;
        if(readChar < 'F')
        {
            if(readChar != ',')
            {
                if(readChar == '.')
                {
                    FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char);
                    FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 5;
                    return true;
                }
                if(readChar != 'E')
                {
                    return false;
                }
                FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char);
                FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 7;
                return true;
            }
        }
        else if(readChar != '}')
        {
            if(readChar == 'e')
            {
                FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char);
                FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 7;
                return true;
            }
            if(readChar != ']')
            {
                return false;
            }
        }
        FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PPCDJGBIMAK_input_buffer = FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char;
        FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 1;
        FNEJPLJCAIF_ctx.KEBIIAMNKAJ_Return = true;
        return true;
    }

	// // RVA: 0x1DD0040 Offset: 0x1DD0040 VA: 0x1DD0040
	private static bool DPMKABIOAMC_State4(GCCDDJPHNMC_FsmContext FNEJPLJCAIF_ctx)
    {
        FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char = FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.LMOCBDODLCP_NextChar();
        if(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char == -1)
        {
            FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.HMHNDKEOIPF_end_of_input = true;
            return true; // ?
        }
        if(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char == ' ')
        {
            FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 1;
            FNEJPLJCAIF_ctx.KEBIIAMNKAJ_Return = true;
            return true;
        }
        if(8 < FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char)
        {
            if(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char < 0xe)
            {
                FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 1;
                FNEJPLJCAIF_ctx.KEBIIAMNKAJ_Return = true;
                return true;
            }
        }
        int readChar = FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char;
        if(readChar < 'F')
        {
            if(readChar != ',')
            {
                if(readChar == '.')
                {
                    FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char);
                    FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 5;
                    return true;
                }
                if(readChar != 'E')
                {
                    return false;
                }
                FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char);
                FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 7;
                return true;
            }
        }
        else if(readChar != '}')
        {
            if(readChar == 'e')
            {
                FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.MFMFOGDCLGF_string_buffer.Append(FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char);
                FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 7;
                return true;
            }
            if(readChar != ']')
            {
                return false;
            }
        }
        FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PPCDJGBIMAK_input_buffer = FNEJPLJCAIF_ctx.LHFLKEHHBHH_L.PLANKOHCEGK_input_char;
        FNEJPLJCAIF_ctx.FJLLOPCNALE_NextState = 1;
        FNEJPLJCAIF_ctx.KEBIIAMNKAJ_Return = true;
        return true;
    }

	// // RVA: 0x1DD022C Offset: 0x1DD022C VA: 0x1DD022C
	// private static bool BNHOIEDLBCE_State5(GCCDDJPHNMC FNEJPLJCAIF_ctx) { }

	// // RVA: 0x1DD0324 Offset: 0x1DD0324 VA: 0x1DD0324
	// private static bool IKPLGHHMAFK_State6(GCCDDJPHNMC FNEJPLJCAIF_ctx) { }

	// // RVA: 0x1DD054C Offset: 0x1DD054C VA: 0x1DD054C
	// private static bool EBLBIEMDJLH_State7(GCCDDJPHNMC FNEJPLJCAIF_ctx) { }

	// // RVA: 0x1DD0668 Offset: 0x1DD0668 VA: 0x1DD0668
	// private static bool ANMLKKDJGEM_State8(GCCDDJPHNMC FNEJPLJCAIF_ctx) { }

	// // RVA: 0x1DD0810 Offset: 0x1DD0810 VA: 0x1DD0810
	// private static bool NELNKKBJKMP_State9(GCCDDJPHNMC FNEJPLJCAIF_ctx) { }

	// // RVA: 0x1DD0888 Offset: 0x1DD0888 VA: 0x1DD0888
	// private static bool DCDPNBHGCAL_State10(GCCDDJPHNMC FNEJPLJCAIF_ctx) { }

	// // RVA: 0x1DD0900 Offset: 0x1DD0900 VA: 0x1DD0900
	// private static bool HEJHPEJGHLD_State11(GCCDDJPHNMC FNEJPLJCAIF_ctx) { }

	// // RVA: 0x1DD0978 Offset: 0x1DD0978 VA: 0x1DD0978
	// private static bool DFFKCFDPOPP_State12(GCCDDJPHNMC FNEJPLJCAIF_ctx) { }

	// // RVA: 0x1DD09F0 Offset: 0x1DD09F0 VA: 0x1DD09F0
	// private static bool BJGCDFFAKKB_State13(GCCDDJPHNMC FNEJPLJCAIF_ctx) { }

	// // RVA: 0x1DD0A68 Offset: 0x1DD0A68 VA: 0x1DD0A68
	// private static bool JEMCABBLHEF_State14(GCCDDJPHNMC FNEJPLJCAIF_ctx) { }

	// // RVA: 0x1DD0AE0 Offset: 0x1DD0AE0 VA: 0x1DD0AE0
	// private static bool PHMCFPHNAGE_State15(GCCDDJPHNMC FNEJPLJCAIF_ctx) { }

	// // RVA: 0x1DD0B58 Offset: 0x1DD0B58 VA: 0x1DD0B58
	// private static bool HJPBHIANLAF_State16(GCCDDJPHNMC FNEJPLJCAIF_ctx) { }

	// // RVA: 0x1DD0BD0 Offset: 0x1DD0BD0 VA: 0x1DD0BD0
	// private static bool HIKLJANANCA_State17(GCCDDJPHNMC FNEJPLJCAIF_ctx) { }

	// // RVA: 0x1DD0C48 Offset: 0x1DD0C48 VA: 0x1DD0C48
	// private static bool DMNFALPHBCN_State18(GCCDDJPHNMC FNEJPLJCAIF_ctx) { }

	// // RVA: 0x1DD0CC0 Offset: 0x1DD0CC0 VA: 0x1DD0CC0
	// private static bool NDJIAEANIPN_State19(GCCDDJPHNMC FNEJPLJCAIF_ctx) { }

	// // RVA: 0x1DD0DDC Offset: 0x1DD0DDC VA: 0x1DD0DDC
	// private static bool CDIMLBGHLIK_State20(GCCDDJPHNMC FNEJPLJCAIF_ctx) { }

	// // RVA: 0x1DD0E54 Offset: 0x1DD0E54 VA: 0x1DD0E54
	// private static bool ACAOIDIIPHK_State21(GCCDDJPHNMC FNEJPLJCAIF_ctx) { }

	// // RVA: 0x1DD102C Offset: 0x1DD102C VA: 0x1DD102C
	// private static bool MEACDDMAICH_State22(GCCDDJPHNMC FNEJPLJCAIF_ctx) { }

	// // RVA: 0x1DD135C Offset: 0x1DD135C VA: 0x1DD135C
	// private static bool ANJODFOAFMO_State23(GCCDDJPHNMC FNEJPLJCAIF_ctx) { }

	// // RVA: 0x1DD1478 Offset: 0x1DD1478 VA: 0x1DD1478
	// private static bool FBJIOOHOHEL_State24(GCCDDJPHNMC FNEJPLJCAIF_ctx) { }

	// // RVA: 0x1DD1510 Offset: 0x1DD1510 VA: 0x1DD1510
	// private static bool HGOMFKNHFAE_State25(GCCDDJPHNMC FNEJPLJCAIF_ctx) { }

	// // RVA: 0x1DD159C Offset: 0x1DD159C VA: 0x1DD159C
	// private static bool PBGKCCOMGHO_State26(GCCDDJPHNMC FNEJPLJCAIF_ctx) { }

	// // RVA: 0x1DD161C Offset: 0x1DD161C VA: 0x1DD161C
	// private static bool MGHJCPJIIEI_State27(GCCDDJPHNMC FNEJPLJCAIF_ctx) { }

	// // RVA: 0x1DD169C Offset: 0x1DD169C VA: 0x1DD169C
	// private static bool PKOPLEHBHGM_State28(GCCDDJPHNMC FNEJPLJCAIF_ctx) { }

	// // RVA: 0x1DCFC18 Offset: 0x1DCFC18 VA: 0x1DCFC18
	// private bool GPNJFELBIPF_GetChar() { }

	// // RVA: 0x1DD173C Offset: 0x1DD173C VA: 0x1DD173C
	private int LMOCBDODLCP_NextChar() 
    { 
        int v = PPCDJGBIMAK_input_buffer;
        if(v != 0)
        {
            PPCDJGBIMAK_input_buffer = 0;
            return v;
        }
        return CLJIOLIEPNA_reader.Read();
    }

	// // RVA: 0x1DD1788 Offset: 0x1DD1788 VA: 0x1DD1788
	public bool IMFJMDAHLEJ_NextToken()
    {
        PLJAMMLMPPL_fsm_context.KEBIIAMNKAJ_Return = false;
        while(true)
        {
            APAPHJJPDIH_StateHandler dgt = PPOAPPJDMKB_fsm_handler_table[LHMDABPNDDH_state-1];
            bool a = dgt.Invoke(PLJAMMLMPPL_fsm_context);
            if(!a)
            {
                // Exception
                return false;
            }
            if(HMHNDKEOIPF_end_of_input)
                return false;
            if(PLJAMMLMPPL_fsm_context.KEBIIAMNKAJ_Return)
                break;
            LHMDABPNDDH_state = PLJAMMLMPPL_fsm_context.FJLLOPCNALE_NextState;
        }
        FDDNPBFJMEP_string_value = MFMFOGDCLGF_string_buffer.ToString();
        JCOGNKFNDEB_token = FCHDCNMNOME_fsm_return_table[LHMDABPNDDH_state-1];
        if(JCOGNKFNDEB_token == 0x10006)
        {
            JCOGNKFNDEB_token = PLANKOHCEGK_input_char;
        }
        LHMDABPNDDH_state = PLJAMMLMPPL_fsm_context.FJLLOPCNALE_NextState;
        return true;
    }

	// // RVA: 0x1DD0034 Offset: 0x1DD0034 VA: 0x1DD0034
	// private void HBBJBJKFOKN_UngetChar() { }
}
