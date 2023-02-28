
public class SakashoProductCriteria
{
	public int CurrencyId { get; set; } // 0x8
	public int? Label { get; set; } // 0xC
	public int ProductType { get; set; } // 0x14
	public string MasterGroupName { get; } // 0x18

	// RVA: 0x3081D8C Offset: 0x3081D8C VA: 0x3081D8C
	public SakashoProductCriteria()
	{
		return;
	}
}
