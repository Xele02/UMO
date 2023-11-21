
namespace XeApp.Game.Menu
{ 
	public class OfferFormationArgs : TransitionArgs
	{
		public HEFCLPGPMLK.AAOPGOGGMID viewOfferData { get; private set; } // 0x8
		public OfferHaveItemCheck itemCheckButton { get; private set; } // 0xC
		public OfferSelectDivaController DivaController { get; private set; } // 0x10

		// RVA: 0x1522D0C Offset: 0x1522D0C VA: 0x1522D0C
		public OfferFormationArgs(HEFCLPGPMLK.AAOPGOGGMID offerdata, OfferHaveItemCheck itemCheckButton, OfferSelectDivaController DivaController)
		{
			viewOfferData = offerdata;
			this.itemCheckButton = itemCheckButton;
			this.DivaController = DivaController;
		}
	}
}
