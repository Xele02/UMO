
public class SakashoInventoryCriteria
{
	public const int TYPE_ALL = -1;

	public bool OnlyUnreceived { get; set; } // 0x8
	public int Type { get; set; } // 0xC
	public int[] Types { get; } // 0x10

	// RVA: 0x3081B60 Offset: 0x3081B60 VA: 0x3081B60
	public SakashoInventoryCriteria()
    {
        Type = 1;
    }
}