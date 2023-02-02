using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.UI
{
	public class LongScreenFrame : MonoBehaviour
	{
		[SerializeField]
		private Image frameImage; // 0xC
		[SerializeField]
		private Sprite[] frameSprite; // 0x10
		[SerializeField]
		private RawImage[] letterBox; // 0x14
		private Canvas parentCanvas; // 0x18

		// RVA: 0x191AF4C Offset: 0x191AF4C VA: 0x191AF4C
		public void SetFrameSprite(int no)
		{
			if(no < frameSprite.Length)
			{
				frameImage.sprite = frameSprite[no];
				frameImage.color = Color.white;
			}
			else
			{
				frameImage.color = Color.black;
			}
			for(int i = 0; i < letterBox.Length; i++)
			{
				letterBox[i].gameObject.SetActive(false);
			}
		}

		// RVA: 0x191B0E4 Offset: 0x191B0E4 VA: 0x191B0E4
		public void ReasetLetterBox()
		{
			if(parentCanvas == null)
			{
				parentCanvas = GetComponentInParent<Canvas>();
				if (parentCanvas == null)
					return;
			}
			Vector2 parentSize = parentCanvas.GetComponent<RectTransform>().sizeDelta;
			Vector2 sizeRoot = parentCanvas.transform.Find("Root").GetComponent<RectTransform>().sizeDelta;
			float margin = (parentSize.x - sizeRoot.x) * 0.5f;
			letterBox[0].GetComponent<RectTransform>().sizeDelta = new Vector2(margin, letterBox[0].GetComponent<RectTransform>().sizeDelta.y);
			letterBox[1].GetComponent<RectTransform>().sizeDelta = new Vector2(margin, letterBox[1].GetComponent<RectTransform>().sizeDelta.y);
			frameImage.gameObject.SetActive(false);
		}
	}
}
