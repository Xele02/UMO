using UnityEngine;
using XeSys.Gfx;
using UnityEngine.UI;
using XeSys;

namespace XeApp.Game.Menu
{
	public class BingoRewardContents : MonoBehaviour
	{
		private int xor = GNGMCIAIKMA.FBGGEFFJJHB; // 0xC
		private long xorl = GNGMCIAIKMA.BBEGLBMOBOF; // 0x10
		[SerializeField]
		private RawImageEx SceneIcon; // 0x18
		[SerializeField]
		private RawImageEx DivaIcon; // 0x1C
		[SerializeField]
		private Text SceneDetailText; // 0x20
		[SerializeField]
		private Text BingoDetailText; // 0x24
		[SerializeField]
		private Text CostumeName; // 0x28
		[SerializeField]
		private Text explanationText; // 0x2C
		private AbsoluteLayout AcquiredIcon; // 0x30
		private AbsoluteLayout DivaColorChange; // 0x34
		private AbsoluteLayout episodeReleasable; // 0x38
		private int DivaImageId_ = GNGMCIAIKMA.FBGGEFFJJHB; // 0x3C
		private int ModelImageId_ = GNGMCIAIKMA.FBGGEFFJJHB; // 0x40
		private int SceneImageId_ = GNGMCIAIKMA.FBGGEFFJJHB; // 0x44

		private int DivaImageId { get { return DivaImageId_ ^ xor; } set { DivaImageId_ = value ^ xor; } } //0x10A0E5C 0x10A0E6C
		private int ModelImageId { get { return ModelImageId_ ^ xor; } set { ModelImageId_ = value ^ xor; } } //0x10A0E7C 0x10A0E8C
		private int SceneImageId { get { return SceneImageId_ ^ xor; } set { SceneImageId_ = value ^ xor; } } //0x10A0E9C 0x10A0EAC

		// RVA: 0x10A0EBC Offset: 0x10A0EBC VA: 0x10A0EBC
		private void Start()
		{
			return;
		}

		// RVA: 0x10A0EC0 Offset: 0x10A0EC0 VA: 0x10A0EC0
		private void Update()
		{
			return;
		}

		// RVA: 0x10A0EC4 Offset: 0x10A0EC4 VA: 0x10A0EC4
		public void SetDivaIcon(int _divaId, int _modelId)
		{
			DivaImageId = _divaId;
			ModelImageId = _modelId;
			DivaIcon.enabled = false;
			GameManager.Instance.DivaIconCache.LoadStandingCostumeIcon(_divaId, _modelId, (IiconTexture icon) =>
			{
				//0x10A199C
				if (DivaImageId != _divaId)
					return;
				icon.Set(DivaIcon);
				DivaIcon.enabled = true;
			});
		}

		// RVA: 0x10A10E8 Offset: 0x10A10E8 VA: 0x10A10E8
		public void SetSceneIcon(int _sceneId, int _rare)
		{
			SceneImageId = _sceneId;
			SceneIcon.enabled = false;
			GameManager.Instance.SceneIconCache.Load(_sceneId, _rare, (IiconTexture scnen) =>
			{
				//0x10A1B24
				if (SceneImageId != _sceneId)
					return;
				scnen.Set(SceneIcon);
				SceneIcon.enabled = true;
			});
		}

		// RVA: 0x10A12BC Offset: 0x10A12BC VA: 0x10A12BC
		public void ChengeLayout(int _divaId)
		{
			DivaColorChange.StartChildrenAnimGoStop(_divaId.ToString("D2"));
		}

		// RVA: 0x10A1358 Offset: 0x10A1358 VA: 0x10A1358
		public void SetAcquiredIconEnable(bool _isAcquired)
		{
			AcquiredIcon.StartChildrenAnimGoStop(_isAcquired ? "02" : "01");
		}

		// RVA: 0x10A13EC Offset: 0x10A13EC VA: 0x10A13EC
		public void TextSetting(string cosName, string secneText)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			BingoDetailText.text = bk.GetMessageByLabel("bingo_reward_select_title");
			explanationText.text = bk.GetMessageByLabel("bingo_reward_select_caution_desc");
			CostumeName.text = cosName;
			SceneDetailText.text = secneText;
			SceneDetailText.horizontalOverflow = HorizontalWrapMode.Wrap;
		}

		// RVA: 0x10A15BC Offset: 0x10A15BC VA: 0x10A15BC
		public void SetexplanationText(string _text)
		{
			if (_text == "")
				episodeReleasable.StartChildrenAnimGoStop("02");
			else
			{
				episodeReleasable.StartChildrenAnimGoStop("01");
				explanationText.text = _text;
			}
		}

		// RVA: 0x10A16B0 Offset: 0x10A16B0 VA: 0x10A16B0
		public void initialize(AbsoluteLayout layout)
		{
			AcquiredIcon = layout.FindViewByExId("sw_sel_bingo_frame_swtbl_comp_onoff") as AbsoluteLayout;
			DivaColorChange = layout.FindViewByExId("sw_sel_bingo_frame_swtbl_sel_bingo_frame") as AbsoluteLayout;
			episodeReleasable = layout.FindViewByExId("sw_sel_bingo_frame_swtbl_caution_onoff") as AbsoluteLayout;
			AcquiredIcon.StartChildrenAnimGoStop("01");
			DivaColorChange.StartChildrenAnimGoStop("05");
			episodeReleasable.StartChildrenAnimGoStop("01");
		}
	}
}
