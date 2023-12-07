
using XeApp.Game.Common;
using XeSys;

[System.Obsolete("Use AILHMHMOKKA_BaseLinkage", true)]
public abstract class AILHMHMOKKA { }
public abstract class AILHMHMOKKA_BaseLinkage
{
	public bool JEDJNIKPFLH_IsLinked; // 0x8
	public bool FFGPDGJNCOO; // 0x9
	public bool MOJEDCPFGJJ_IsVersionOk; // 0xA

	//// RVA: -1 Offset: -1 Slot: 4
	public abstract void EMKKJILHOOB_GetLinkageStatus(IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK AOCANKOMKFG);

	//// RVA: -1 Offset: -1 Slot: 5
	public abstract void GGNBIHHFJMP(IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK AOCANKOMKFG);

	//// RVA: -1 Offset: -1 Slot: 6
	public abstract void MOHPODEDIEK(IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK AOCANKOMKFG);

	//// RVA: -1 Offset: -1 Slot: 7
	public abstract void BMJMJCIKALP(IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK AOCANKOMKFG);

	//// RVA: 0xCCB544 Offset: 0xCCB544 VA: 0xCCB544
	protected bool HGOKJBPIDJB(CACGCMBKHDI_Request NHECPMNKEFK)
	{
		if (NHECPMNKEFK.PDAPLCPOCMA)
			return false;
		if(NHECPMNKEFK.CJMFJOMECKI_ErrorId < SakashoErrorId.RANKING_CLOSED)
		{
			if(NHECPMNKEFK.CJMFJOMECKI_ErrorId >= SakashoErrorId.GAME_NOT_FACEBOOK_LINKAGE && NHECPMNKEFK.CJMFJOMECKI_ErrorId < SakashoErrorId.RANKING_CLOSED)
			{
				return ((0x23 >> ((int)NHECPMNKEFK.CJMFJOMECKI_ErrorId - 70)) & 1) != 0;
			}
		}
		else
		{
			if((int)NHECPMNKEFK.CJMFJOMECKI_ErrorId >= 254 && (int)NHECPMNKEFK.CJMFJOMECKI_ErrorId - 254 < 16)
			{
				return ((1 << ((int)NHECPMNKEFK.CJMFJOMECKI_ErrorId - 254)) & 0x87df) != 0;
			}
			if (NHECPMNKEFK.CJMFJOMECKI_ErrorId == SakashoErrorId.ANOTHER_FACEBOOK_USER_ID_ALREADY_EXISTS)
				return true;
			if ((int)NHECPMNKEFK.CJMFJOMECKI_ErrorId >= 336 && (int)NHECPMNKEFK.CJMFJOMECKI_ErrorId - 336 < 6)
				return true;
		}
		return false;
	}

	//// RVA: 0xCCB520 Offset: 0xCCB520 VA: 0xCCB520
	protected bool DGLAMLJFEDB_CheckError(SakashoErrorId KLCMLLLIANB)
	{
		return KLCMLLLIANB == SakashoErrorId.GAME_NOT_TWITTER_LINKAGE ||
			KLCMLLLIANB == SakashoErrorId.GAME_NOT_LINE_LINKAGE ||
			KLCMLLLIANB == SakashoErrorId.GAME_NOT_FACEBOOK_LINKAGE;
	}

	//// RVA: 0xCD1AF4 Offset: 0xCD1AF4 VA: 0xCD1AF4
	//protected bool FDDHFHKIABD(SakashoErrorId KLCMLLLIANB) { }

	//// RVA: 0xCD1B2C Offset: 0xCD1B2C VA: 0xCD1B2C
	protected bool NPOAJHCHJGF(SakashoErrorId KLCMLLLIANB)
	{
		return KLCMLLLIANB == SakashoErrorId.PLAYER_NOT_FOUND;
	}

	//// RVA: 0xCCBC94 Offset: 0xCCBC94 VA: 0xCCBC94
	protected void HLOKAOHAMNC(JFDNPFFOACP NIMPEHIECJH, string JJPJAJEOECI)
	{
		TextPopupSetting s = new TextPopupSetting();
		s.TitleText = MessageManager.Instance.GetMessage("common", "popup_inh_title_005");
		s.Buttons = new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive } };
		s.Text = string.Format(MessageManager.Instance.GetMessage("common", "popup_inh_player_not_found"), JJPJAJEOECI);
		PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0xCD1B44
			NIMPEHIECJH();
		}, null, null, null);
	}
}
