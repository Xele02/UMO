
[System.Obsolete("Use LGIOGDIPNGI_RareUpItem", true)]
public class LGIOGDIPNGI { }
public class LGIOGDIPNGI_RareUpItem : NKFJNAANPNP
{
	private const int ECFEMKGFDCE_CurrentVersion = 2;
	public const int EDIEJEICDGP = 9;
	private const int MJFAFEOOEFF = 90;

	// // RVA: 0x17F4078 Offset: 0x17F4078 VA: 0x17F4078
	public LGIOGDIPNGI_RareUpItem()
	{
		DALBFCKKGGA_Version = ECFEMKGFDCE_CurrentVersion;
		FIBFMLMHOGN = EDIEJEICDGP;
		KOICDJCMKEC = 0x76a6ff;
		if (IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database != null)
		{
			CKDOOBKOJBB_RareUpItem rareUp = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.KKIMFMKOHFH_RareUpItem;
			KOICDJCMKEC = rareUp.CDENCMNHNGA_table[0].EIGNPDFHIJA * 0x15180 - 1;
		}
		JKGBOCBNIIG(33, "pd.rareup_item");
	}
}
