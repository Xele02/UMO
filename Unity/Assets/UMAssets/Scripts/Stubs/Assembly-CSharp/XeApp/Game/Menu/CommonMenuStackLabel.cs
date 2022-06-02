using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class CommonMenuStackLabel : LayoutLabelScriptBase
	{
		public enum LabelType
		{
			_None = -2,
			_Undefined = -1,
			Home = 0,
			Present = 1,
			Friend = 2,
			Setting = 3,
			Unit = 4,
			Diva = 5,
			Plate = 6,
			Episode = 7,
			Story = 8,
			Free = 9,
			Quest = 10,
			Event = 11,
			Gacha = 12,
			Menu = 13,
			SimulationLive = 14,
			Shop = 15,
			CostumeUpgrade = 16,
			Operation = 17,
			BingoMission = 18,
			ValkyrieTuneUp = 19,
			LobbyMember = 20,
			BastStorage = 21,
			StampMaker = 22,
			Visit = 23,
			BlockList = 24,
			Search = 25,
			_Num = 26,
		}

		[SerializeField]
		private RawImageEx m_labelImage;
		[SerializeField]
		private RectTransform m_labelImageRect;
		[SerializeField]
		private Vector2 m_labelTexSize;
		[SerializeField]
		private Text m_description;
	}
}
