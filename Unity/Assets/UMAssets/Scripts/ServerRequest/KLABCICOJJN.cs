
using System.Collections.Generic;

[System.Obsolete("Use KLABCICOJJN_SendPushNotification", true)]
public class KLABCICOJJN {}
public class KLABCICOJJN_SendPushNotification : CACGCMBKHDI_Request
{
	public SakashoFCMPushNotificationPayload DBBNIEHJGHH; // 0x7C
	public List<int> IFMENOJDKBF; // 0x80

	public override bool BNCFONNOHFO { get { return true; } } //0x1A0B498 NPLNAJFJPEE

	// RVA: 0x1A0B4A0 Offset: 0x1A0B4A0 VA: 0x1A0B4A0
	public static SakashoFCMPushNotificationPayload FMMLHEIOFBO()
    {
        SakashoFCMPushNotificationPayload res = new SakashoFCMPushNotificationPayload();
        res.AndroidCollapseKey = JDDGPJDKHNE.GPLMOKEIOLE();
        res.AndroidChannelId = "info";
        res.AndroidIconName = "icon";
        res.TimeToLive = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA("push_notification_time_to_live", 600);
        res.IOSCategory = "myNotificationCategory";
        return res;
    }

	// RVA: 0x1A0B6E0 Offset: 0x1A0B6E0 VA: 0x1A0B6E0 Slot: 12
	public override void DHLDNIEELHO()
    {
        EBGACDGNCAA_CallContext = SakashoFCMPushNotification.SendPushNotification(IFMENOJDKBF.ToArray(), DBBNIEHJGHH, DCKLDDCAJAP, MEOCKCJBDAD);
    }
}
