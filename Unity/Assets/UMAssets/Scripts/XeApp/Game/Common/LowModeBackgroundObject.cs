using UnityEngine;
using UnityEngine.UI;
using XeSys.Gfx;

namespace XeApp.Game.Common
{
	public class LowModeBackgroundObject : MonoBehaviour
	{
		private enum DimmerTblIndex
		{
			Intro_Valkyeri = 0,
			Card = 1,
		}

		private LowModeBackgroundResource resource; // 0xC
		[HideInInspector] // RVA: 0x68C12C Offset: 0x68C12C VA: 0x68C12C
		public GameObject intro; // 0x10
		[HideInInspector] // RVA: 0x68C13C Offset: 0x68C13C VA: 0x68C13C
		public GameObject card; // 0x14
		[HideInInspector] // RVA: 0x68C14C Offset: 0x68C14C VA: 0x68C14C
		public GameObject battle; // 0x18
		private bool isInitialized; // 0x1C
		private Material mipmapBiasMaterialInstance; // 0x20
		private readonly byte[,] DimmerTbl = new byte[2, 11] { { 0x6e, 0x78, 0x82, 0x8c, 0x99, 0xaa, 0xb4, 0xbe, 0xc8, 0xd2, 0xdc}, 
			{0x28, 0x32, 0x3c, 0x46, 0x50, 0x64, 0x6e, 0x78, 0x82, 0x8c, 0x96 } }; // 0x24

		// // RVA: 0x1109E08 Offset: 0x1109E08 VA: 0x1109E08
		public void Initialize(LowModeBackgroundResource resource)
		{
			this.resource = resource;
			if(resource != null)
			{
				intro = transform.Find("intro").gameObject;
				card = transform.Find("card").gameObject;
				battle = transform.Find("battle").gameObject;
				intro.GetComponent<RawImage>().texture = resource.introTexture;
				card.GetComponent<RawImage>().texture = resource.cardTexture;
				battle.GetComponent<RawImage>().texture = resource.battleTexture;
				mipmapBiasMaterialInstance = card.GetComponent<RawImage>().material;
				if(!resource.isTitleBg)
				{
					ApplyBackGroundPanelSize(card.GetComponent<RawImage>(), card.GetComponentInParent<Canvas>(), resource.baseRare);
					mipmapBiasMaterialInstance.SetTexture("_MainTex", resource.cardTexture);
					mipmapBiasMaterialInstance.SetTexture("_MaskTex", Texture2D.whiteTexture);
					mipmapBiasMaterialInstance.SetFloat("_MipmapBias", -0.5f);
					card.GetComponent<RawImage>().material = mipmapBiasMaterialInstance;
				}
				else
				{
					card.GetComponent<RawImage>().material = null;
				}
				ApplyDimmer();
				isInitialized = true;
			}
		}

		// // RVA: 0x110A574 Offset: 0x110A574 VA: 0x110A574
		private void ApplyDimmer()
		{
			ApplyDimmer(intro.GetComponent<RawImage>(), GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.FPFAMFOPJDJ_Dimmer2d, DimmerTblIndex.Intro_Valkyeri);
			ApplyDimmer(card.GetComponent<RawImage>(), GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.FPFAMFOPJDJ_Dimmer2d, DimmerTblIndex.Card);
			ApplyDimmer(battle.GetComponent<RawImage>(), GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.FPFAMFOPJDJ_Dimmer2d, DimmerTblIndex.Intro_Valkyeri);
		}

		// // RVA: 0x110A728 Offset: 0x110A728 VA: 0x110A728
		private void ApplyDimmer(RawImage image, int value, DimmerTblIndex index)
		{
			float v = DimmerTbl[(int)index, value] / 255.0f;
			image.color = new Color(v, v, v);
		}

		// // RVA: 0x110A27C Offset: 0x110A27C VA: 0x110A27C
		private void ApplyBackGroundPanelSize(RawImage target, Canvas canvas, int baseRare)
		{
			Vector2 v = canvas.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta;
			target.rectTransform.sizeDelta = new Vector2(v.x, v.x);
			if(baseRare < 4)
			{
				target.uvRect = SceneCardrectRectangle.uvRect;
			}
			else
			{
				target.uvRect = new Rect(0, 0, 1, 1);
			}
		}

		// // RVA: 0x110A814 Offset: 0x110A814 VA: 0x110A814
		public void ChangeIntroBg()
		{
			if (!isInitialized)
				return;
			intro.SetActive(true);
			card.SetActive(false);
			battle.SetActive(false);
		}

		// // RVA: 0x110A89C Offset: 0x110A89C VA: 0x110A89C
		public void ChangeCardBg()
		{
			if (!isInitialized)
				return;
			intro.SetActive(false);
			card.SetActive(true);
			battle.SetActive(false);
		}

		// // RVA: 0x110A924 Offset: 0x110A924 VA: 0x110A924
		public void ChangeBattleBg()
		{
			if (!isInitialized)
				return;
			intro.SetActive(false);
			card.SetActive(false);
			battle.SetActive(true);
		}
	}
}
