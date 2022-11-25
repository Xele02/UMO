
public class SakashoPlayerCriteria
{
	public string Key { get; set; } // 0x8
	public string EqualTo { get; } // 0xC
	public int? NumberFrom { get; set; } // 0x10
	public int? NumberTo { get; set; } // 0x18
	public string StringStartsWith { get; } // 0x20
	public bool OnlyFriends { get; set; } // 0x24
	public bool ExcludeAccountBan { get; set; } // 0x25

	// RVA: 0x3081CBC Offset: 0x3081CBC VA: 0x3081CBC
	public static SakashoPlayerCriteria NewCriteriaFromTo(string key, int? from, int? to)
	{
		SakashoPlayerCriteria res = new SakashoPlayerCriteria();
		res.Key = key;
		res.NumberFrom = from;
		res.NumberTo = to;
		return res;
	}
}
