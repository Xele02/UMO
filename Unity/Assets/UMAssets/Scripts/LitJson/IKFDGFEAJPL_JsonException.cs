using System;

public class IKFDGFEAJPL_JsonException : ApplicationException
{
	// RVA: 0x8E451C Offset: 0x8E451C VA: 0x8E451C
	public IKFDGFEAJPL_JsonException() : base() { }

	// // RVA: 0x8E4524 Offset: 0x8E4524 VA: 0x8E4524
	internal IKFDGFEAJPL_JsonException(HEEFEJINJEG_ParserToken JCOGNKFNDEB_token)
		: base(String.Format(
					"Invalid token '{0}' in input string", JCOGNKFNDEB_token))
	{ }

	// // RVA: 0x8E45C4 Offset: 0x8E45C4 VA: 0x8E45C4
	internal IKFDGFEAJPL_JsonException(HEEFEJINJEG_ParserToken JCOGNKFNDEB_token, Exception IJPFPOEGHDE_inner_exception) :
			base(String.Format(
					"Invalid token '{0}' in input string", JCOGNKFNDEB_token),
				IJPFPOEGHDE_inner_exception)
	{ }

	// // RVA: 0x8E466C Offset: 0x8E466C VA: 0x8E466C
	internal IKFDGFEAJPL_JsonException(int CKHEDJODNIP_c) :
			base(String.Format(
					"Invalid character '{0}' in input string", (char)CKHEDJODNIP_c))
	{ }

	// // RVA: 0x8E470C Offset: 0x8E470C VA: 0x8E470C
	internal IKFDGFEAJPL_JsonException(int CKHEDJODNIP_c, Exception IJPFPOEGHDE_inner_exception) :
			base(String.Format(
					"Invalid character '{0}' in input string", (char)CKHEDJODNIP_c),
				IJPFPOEGHDE_inner_exception)
	{ }

	// // RVA: 0x8E47B4 Offset: 0x8E47B4 VA: 0x8E47B4
	public IKFDGFEAJPL_JsonException(string LJGOOOMOMMA_message) : base(LJGOOOMOMMA_message) { }

	// // RVA: 0x8E47BC Offset: 0x8E47BC VA: 0x8E47BC
	public IKFDGFEAJPL_JsonException(string LJGOOOMOMMA_message, Exception IJPFPOEGHDE_inner_exception) :
			base(LJGOOOMOMMA_message, IJPFPOEGHDE_inner_exception)
	{ }
}
