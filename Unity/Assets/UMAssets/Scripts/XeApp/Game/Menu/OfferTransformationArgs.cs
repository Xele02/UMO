
namespace XeApp.Game.Menu
{ 
	public class OfferTransformationArgs : TransitionArgs
	{
		public OfferHaveItemCheck itemCheckButton; // 0x10

		public HEFCLPGPMLK.ANKPCIEKPAH valData { get; private set; } // 0x8
		public OfferInfoLayout offerInfo { get; private set; } // 0xC
		public int plattonId { get; private set; } // 0x14

		// RVA: 0x17121FC Offset: 0x17121FC VA: 0x17121FC
		public OfferTransformationArgs(HEFCLPGPMLK.ANKPCIEKPAH _valData, OfferInfoLayout _offerInfo, OfferHaveItemCheck _itemCheckButton, int _plattonId)
		{
			valData = _valData;
			offerInfo = _offerInfo;
			_itemCheckButton = itemCheckButton;
			plattonId = _plattonId;
		}
	}
}
