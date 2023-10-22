using mcrs;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Menu;

namespace XeApp
{
	public abstract class DecorationItemBase : MonoBehaviour
	{
		public enum ControlType
		{
			None = 0,
			Tap = 1,
			LongTap = 2,
			Drag = 4,
			All = 7,
		}

		public delegate void MoveDelegate(DecorationItemBase item, Vector2 touchPostion);

		// Namespace: 
		public delegate void ChangePriorityDelegate(DecorationItemBase item, LayoutDecorationFrameButton.ButtonType type);

		private enum Dir
		{
			None = 0,
			L = 1,
			T = 2,
			R = 4,
			B = 8,
			C = 15,
		}

		private DecorationItemBaseSetting m_setting; // 0x10
		private bool m_isLoaded; // 0x14
		protected KDKFHGHGFEK m_viewDecoItemData = new KDKFHGHGFEK(); // 0x1C
		protected GameObject m_object; // 0x20
		protected Transform m_renderer; // 0x24
		protected DecorationItemController m_decorationContoller; // 0x28
		protected SpriteRenderer m_spriteRenderer; // 0x2C
		public MoveDelegate BeginDragCallback; // 0x30
		public MoveDelegate DragCallback; // 0x34
		public Action<DecorationItemBase, Vector2> PointerDownCallback; // 0x38
		public Action<DecorationItemBase> ClickCallback; // 0x3C
		public Action<DecorationItemBase> TouchButtonCallback; // 0x40
		public Action<DecorationItemBase> PointerUpCallback; // 0x44
		public Action<DecorationItemBase> SerifButtonCallback; // 0x48
		public ChangePriorityDelegate PriorityButtonCallback; // 0x4C
		public Action FlipButtonCallback; // 0x50
		public Action<DecorationItemBase, bool> ChangeKiraCallback; // 0x54
		private Material m_material; // 0x58
		private Material m_materialFlip; // 0x5C
		private Sprite m_sprite; // 0x60
		private Sprite m_spriteFlip; // 0x64
		protected bool m_isFlip; // 0x68
		protected ControlType m_enableControl; // 0x74
		private bool m_useFlipAsset; // 0x78
		private bool m_useFlipShaderParam; // 0x79
		protected Texture m_baseTexture; // 0x7C
		protected Texture m_maskTexture; // 0x80
		protected Texture m_baseTextureFlip; // 0x84
		protected Texture m_maskTextureFlip; // 0x88
		private Image m_hitImage; // 0x8C
		private Transform m_hitObject; // 0x90
		private int m_flipShaderParam = Shader.PropertyToID("_Flip"); // 0x94
		public int m_statusFlag; // 0x98

		protected DecorationCanvas m_decoCanvas { get; private set; } // 0xC
		public virtual bool IsLoaded { get { return m_isLoaded; } private set { m_isLoaded = value; } } //0x1AC3B3C 0x1AD02C0
		protected bool UseRareBrakePosterAnim { get
		{
			if(!m_decoCanvas.DecoLocalSaveData.KOGBMDOONFA.HEKJKLJDHNN_EnablePosterAnim)
				return false;
			return ViewData.OHAMGNMKOII();
		} } //0x1AD02C8
		public string AssetPathFormat { get { return DecorationConstants.GetItemAssetPathFormat(ViewData, UseRareBrakePosterAnim); } } //0x1ACA3EC
		public string FileNameFormat { get { return DecorationConstants.GetItemFileNameFormat(ViewData); } } //0x1AD03D0
		public int AssetId { get { return DecorationConstants.GetItemAssetId(ViewData); } } //0x1AD045C
		public string FileName { get { return FileNameFormat == "" ? "" : string.Format(FileNameFormat, AssetId); } } //0x1AD04E8
		public string BundlePath { get { return DecorationConstants.GetItemBundleName(ViewData, UseRareBrakePosterAnim); } } //0x1AD05C8
		public LayoutDecorationWindow01.SelectItemType ItemType { get
			{
				int a = 3;
				switch(ViewData.NPADACLCNAN_Category)
				{
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara:
						a = 4;
						break;
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif:
						a = 5;
						break;
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp:
						a = 6;
						break;
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.MABCLBNIOFA_ValkyrieItem:
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.LEIMPDPCGNC_Reserve32:
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem:
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.FEHJOHIMAIH_Reserve37:
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.GGEFMAAOMFH_StampItemChara:
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem:
						a = 7;
						break;
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster:
						a = 8;
						break;
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef:
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft:
						a = 9;
						break;
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.HEMGMACMGAB_DecoItemVFFigure:
						a = 10;
						break;
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.NNBMEEPOBIO_DecoItemCostumeTorso:
						a = 11;
						break;
				}
				if (a == 5)
					return LayoutDecorationWindow01.SelectItemType.Serif;
				if (a != 4)
					return LayoutDecorationWindow01.SelectItemType.Object;
				return LayoutDecorationWindow01.SelectItemType.Chara;
			} } //0x1AD0668
		public EKLNMHFCAOI.FKGCBLHOOCL_Category DecorationItemCategory { get { return ViewData.NPADACLCNAN_Category; } } //0x1ACCEA0
		public int ResourceId { get { return EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(DecorationItemCategory, Id); } } //0x1AD074C
		public bool CanEdit { get {
				if(ViewData.NPADACLCNAN_Category == EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp)
				{
					return ViewData.GBJFNGCDKPM != 11;
				}
				return true;
			} } //0x1AD07E4
		public bool CanKira { get {
				if(m_viewDecoItemData.PPFNGGCBJKC_Id != 0)
				{
					return m_viewDecoItemData.FMGBBKHJDEC_CanKira;
				}
				return false;
			} } //0x1AD085C
		public KDKFHGHGFEK ViewData { get {
				//m_viewDecoItemData.PPFNGGCBJKC = ;
				return m_viewDecoItemData;
			} } //0x1AC85C4
		public bool Lock { get; set; } // 0x15
		public DecorationConstants.Attribute.Type AttributeType { get { return m_setting.AttributeType; } } //0x1ABC73C
		public DecorationItemBaseSetting Setting { get { return m_setting; } } //0x1AC40D4
		public int Id { get; protected set; } // 0x18
		public bool IsEnablePost { get; set; } // 0x69
		public bool IsStop { get; set; } // 0x6A
		public bool IsTouch { get; set; } // 0x6B
		public DecorationItemManager.PostType PostType { get; set; } // 0x6C
		public bool IsMoved { get; set; } // 0x70
		protected bool UseFlipTexture { get { return m_useFlipAsset; } } //0x1AD09E8 
		public bool IsKiraPoster { get { return IsStatusFlag(DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.FDEMAPBAFGN.HGJCDIEALPL_IsKira); } set { SetStatusFlag(DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.FDEMAPBAFGN.HGJCDIEALPL_IsKira, value); } } //0x1AD0A34 0x1AD0A40
		//public string Name { get; } 0x1AD2D30 
		public virtual Vector2 Position { get { return m_object.transform.localPosition; } set { m_object.transform.localPosition = value; } } //0x1AD2D5C 0x1AC5E34
		public virtual int SortingOrder { get { return m_spriteRenderer.sortingOrder; } set { m_spriteRenderer.sortingOrder = value; } } //0x1AC61A4 0x1AC616C
		public Vector2 Size { get {
				if(!m_useFlipShaderParam)
				{
					return new Vector2(m_spriteRenderer.sprite.rect.width, m_spriteRenderer.sprite.rect.height);
				}
				else
				{
					return new Vector2(204, 158);
				}
			} } //0x1AC4E2C
		public float Scale { get { return m_object.transform.localScale.x; } } //0x1AC6040
		public float HalfWidth { get { return Size.x * Scale * 0.5f; } } //0x1AD2FE0
		public float HalfHeight { get { return Size.y * Scale * 0.5f; } } //0x1AD2EAC
		
		//// RVA: 0x1AD08CC Offset: 0x1AD08CC VA: 0x1AD08CC
		public bool CheckAttribute(DecorationConstants.Attribute.Type attribute)
		{
			if (attribute == DecorationConstants.Attribute.Type.None)
				return false;
			bool res = false;
			if((attribute & DecorationConstants.Attribute.Type.Wall) != 0)
			{
				res = false;
				if ((Setting.AttributeType & DecorationConstants.Attribute.Type.Wall) != 0)
					res = true;
			}
			if((attribute & DecorationConstants.Attribute.Type.Floor) != 0)
			{
				if ((Setting.AttributeType & DecorationConstants.Attribute.Type.Floor) != 0)
					res = true;
			}
			return res;
		}

		//// RVA: 0x1AD0984 Offset: 0x1AD0984 VA: 0x1AD0984
		public GameObject GetObject()
		{
			return m_object;
		}

		//// RVA: 0x1AD09B4 Offset: 0x1AD09B4 VA: 0x1AD09B4
		public bool IsNewPost()
		{
			return PostType >= DecorationItemManager.PostType.DragNewPost && PostType <= DecorationItemManager.PostType.TapNewPost;
		}

		//// RVA: 0x1AD09DC Offset: 0x1AD09DC VA: 0x1AD09DC
		//public void Moved() { }

		//// RVA: 0x1AC7188 Offset: 0x1AC7188 VA: 0x1AC7188
		public bool CheckEnableControl(ControlType control)
		{
			return (m_enableControl & control) > 0;
		}
		
		//// RVA: 0x1AD09F0 Offset: 0x1AD09F0 VA: 0x1AD09F0
		private bool IsStatusFlag(DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.FDEMAPBAFGN status)
		{
			return (m_statusFlag & (1 << (int)status)) != 0;
		}

		//// RVA: 0x1AD0A0C Offset: 0x1AD0A0C VA: 0x1AD0A0C
		private void SetStatusFlag(DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.FDEMAPBAFGN status, bool on)
		{
			m_statusFlag &= ~(1 << (int)status);
			if(on)
				m_statusFlag |= (1 << (int)status);
		}
		
		//// RVA: 0x1AD0A58 Offset: 0x1AD0A58 VA: 0x1AD0A58
		public void LoadResource(GameObject spriteBase, EKLNMHFCAOI.FKGCBLHOOCL_Category itemCategory, int id, DecorationItemBaseSetting setting, DecorationItemArgsBase args)
		{
			Id = id;
			m_isLoaded = false;
			this.StartCoroutineWatched(Co_LoadResource(spriteBase, setting, PreLoadResource(spriteBase, itemCategory, id, setting, args), args));
			PostLoadResource(spriteBase, itemCategory, id, setting, args);
		}

		//// RVA: 0x1AC41EC Offset: 0x1AC41EC VA: 0x1AC41EC Slot: 5
		protected virtual Action PreLoadResource(GameObject spriteBase, EKLNMHFCAOI.FKGCBLHOOCL_Category itemCategory, int id, DecorationItemBaseSetting setting, DecorationItemArgsBase args)
		{
			m_viewDecoItemData.KHEKNNFCAOI(id, itemCategory);
			return null;
		}

		//// RVA: -1 Offset: -1 Slot: 6
		protected abstract void PostLoadResource(GameObject spriteBase, EKLNMHFCAOI.FKGCBLHOOCL_Category itemCategory, int id, DecorationItemBaseSetting setting, DecorationItemArgsBase args);

		//// RVA: 0x1AD0AFC Offset: 0x1AD0AFC VA: 0x1AD0AFC
		//protected void LoadResource(GameObject spriteBase, int id, DecorationItemBaseSetting setting, Action endCallBack, DecorationItemArgsBase args) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6ABF60 Offset: 0x6ABF60 VA: 0x6ABF60
		//// RVA: 0x1AD0B4C Offset: 0x1AD0B4C VA: 0x1AD0B4C
		private IEnumerator Co_LoadResource(GameObject spriteBase, DecorationItemBaseSetting setting, Action endCallBack, DecorationItemArgsBase args)
		{
			string assetBundlePath;
			AssetBundleLoadAllAssetOperationBase op;

			//0x1AD42B4
			if(FileNameFormat != "")
			{
				assetBundlePath = BundlePath;
				op = AssetBundleManager.LoadDecorationItemAssetAsync(assetBundlePath);
				yield return op;
				if(DecorationItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft ||
					DecorationItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef)
				{
					//LAB_01ad44a8
					if(ViewData.FLJPIHEEKOJ > 5)
						m_useFlipShaderParam = true;
				}
				LoadMaterial(FileName, op, out m_material);
				LoadSprite(FileName, op, out m_sprite);
				LoadTexture(FileName, op, out m_baseTexture, out m_maskTexture);
				LoadMaterial(FileName + "_f", op, out m_materialFlip);
				if(m_materialFlip == null)
				{
					m_materialFlip = new Material(m_material);
				}
				LoadSprite(FileName + "_f", op, out m_spriteFlip);
				LoadTexture(FileName + "_f", op, out m_baseTextureFlip, out m_maskTextureFlip);
				m_useFlipAsset = false;
				if(m_spriteFlip != null)
					m_useFlipAsset = true;
				CreateAppendAsset(args);
				AssetBundleManager.UnloadAssetBundle(assetBundlePath, false);
				op = null;
			}
			InitData(spriteBase, setting);
			yield return this.StartCoroutineWatched(OnObjectCreated());
			if(endCallBack != null)
				endCallBack();
			Hide();
			m_isLoaded = true;
		}

		//// RVA: 0x1AD0C64 Offset: 0x1AD0C64 VA: 0x1AD0C64 Slot: 7
		protected virtual void CreateAppendAsset(DecorationItemArgsBase args)
		{
			return;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6ABFD8 Offset: 0x6ABFD8 VA: 0x6ABFD8
		//// RVA: 0x1AD0C68 Offset: 0x1AD0C68 VA: 0x1AD0C68 Slot: 8
		protected virtual IEnumerator OnObjectCreated()
		{
			//0x1AD4988
			yield return null;
		}

		//// RVA: 0x1AD0CFC Offset: 0x1AD0CFC VA: 0x1AD0CFC
		private void LoadMaterial(string path, AssetBundleLoadAllAssetOperationBase op, out Material material)
		{
			material = op.GetAsset<Material>(path + "_mul");
			if(UseRareBrakePosterAnim)
			{
				if(material == null)
					return;
				material = new Material(material);
			}
		}

		//// RVA: 0x1AD0E44 Offset: 0x1AD0E44 VA: 0x1AD0E44
		private void LoadSprite(string path, AssetBundleLoadAllAssetOperationBase op, out Sprite sprite)
		{
			sprite = op.GetAsset<Sprite>(path + "_base");
		}

		//// RVA: 0x1AD0F04 Offset: 0x1AD0F04 VA: 0x1AD0F04
		private void LoadTexture(string path, AssetBundleLoadAllAssetOperationBase op, out Texture baseTexture, out Texture maskTexture)
		{
			baseTexture = op.GetAsset<Texture>(path + "_base");
			maskTexture = op.GetAsset<Texture>(path + "_mask");
		}

		//// RVA: 0x1AD1034 Offset: 0x1AD1034 VA: 0x1AD1034
		protected void SetTexture(Material material, Texture baseTexture, Texture maskTexture)
		{
			material.SetTexture("_MainTex", baseTexture);
			material.SetTexture("_MaskTex", maskTexture);
		}

		//// RVA: 0x1AD1104 Offset: 0x1AD1104 VA: 0x1AD1104
		private void InitData(GameObject spriteBase, DecorationItemBaseSetting setting)
		{
			m_object = Instantiate(spriteBase, spriteBase.transform.parent);
			m_object.name = name;
			m_setting = setting;
			m_renderer = m_object.transform.Find("SpriteRenderer");
			m_statusFlag = setting.InitStatusFlag;
			Position = setting.InitPosition;
			InitSprite(setting.InitOrder);
			Hide();
			IsTouch = false;
			IsEnablePost = true;
			IsStop = false;
			IsMoved = false;
			Lock = false;
			Flip(setting.InitFlip);
			CreateHit();
		}

		//// RVA: 0x1AD1634 Offset: 0x1AD1634 VA: 0x1AD1634
		public void Prepare(DecorationCanvas canvas)
		{
			m_decoCanvas = canvas;
		}

		//// RVA: 0x1AD163C Offset: 0x1AD163C VA: 0x1AD163C
		//private static bool IntersectLineToLine(ref Vector2 a1, ref Vector2 a2, ref Vector2 b1, ref Vector2 b2) { }

		//// RVA: 0x1AD168C Offset: 0x1AD168C VA: 0x1AD168C
		//private static bool IntersectLineToLine(float a1x, float a1y, float a2x, float a2y, float b1x, float b1y, float b2x, float b2y) { }

		//// RVA: 0x1AD1738 Offset: 0x1AD1738 VA: 0x1AD1738
		//private static DecorationItemBase.Dir IntersectLineToRect(ref Vector2 s, ref Vector2 e, float l, float t, float r, float b) { }

		//// RVA: 0x1AD1954 Offset: 0x1AD1954 VA: 0x1AD1954
		public void InitController()
		{
			m_decorationContoller = m_renderer.GetComponent<DecorationItemController>();
			m_decorationContoller.Setting(Size * Scale);
			m_decorationContoller.onPointerDown = OnPointerDown;
			m_decorationContoller.onBeginDrag = OnBeginDrag;
			m_decorationContoller.onDrag = OnDrag;
			m_decorationContoller.onPointerUp = OnPointerUp;
			m_decorationContoller.onPointerClick = OnClick;
			if(!(this is DecorationChara))
			{
				m_setting.Thickness = (int)(m_setting.Thickness * Size.y * 0.01f);
			}
			PostInitController();
		}

		//// RVA: -1 Offset: -1 Slot: 9
		protected abstract void PostInitController();

		//// RVA: 0x1AD1E50 Offset: 0x1AD1E50 VA: 0x1AD1E50
		private void OnClick(Vector2 touchPosition)
		{
			if(!MenuScene.Instance.IsTransition() && IsDecoScene())
			{
				ClickCallback(this);
			}
		}

		//// RVA: 0x1AD1FFC Offset: 0x1AD1FFC VA: 0x1AD1FFC
		private void OnPointerDown(Vector2 touchPosition)
		{
			if(!MenuScene.Instance.IsTransition() && IsDecoScene())
			{
				PointerDownCallback(this, touchPosition);
			}
		}

		//// RVA: 0x1AD20FC Offset: 0x1AD20FC VA: 0x1AD20FC
		private void OnPointerUp()
		{
			if(!MenuScene.Instance.IsTransition() && IsDecoScene())
			{
				PointerUpCallback(this);
			}
		}

		//// RVA: 0x1AD21E4 Offset: 0x1AD21E4 VA: 0x1AD21E4
		private void OnBeginDrag(Vector2 touchPosition)
		{
			if(!MenuScene.Instance.IsTransition() && IsDecoScene())
			{
				BeginDragCallback(this, touchPosition);
			}
		}

		//// RVA: 0x1AD2ACC Offset: 0x1AD2ACC VA: 0x1AD2ACC
		private void OnDrag(Vector2 touchPosition)
		{
			if(!MenuScene.Instance.IsTransition() && IsDecoScene())
			{
				DragCallback(this, touchPosition);
			}
		}

		//// RVA: 0x1AD1F38 Offset: 0x1AD1F38 VA: 0x1AD1F38
		private bool IsDecoScene()
		{
			return MenuScene.Instance.GetCurrentScene().name == TransitionList.Type.DECO;
		}

		//// RVA: 0x1AD2BB8 Offset: 0x1AD2BB8 VA: 0x1AD2BB8 Slot: 10
		public virtual void PointerUp()
		{
			return;
		}

		//// RVA: 0x1AD2BBC Offset: 0x1AD2BBC VA: 0x1AD2BBC Slot: 11
		public virtual void PointerDown(Vector2 touchPosition)
		{
			return;
		}

		//// RVA: 0x1AD2BC0 Offset: 0x1AD2BC0 VA: 0x1AD2BC0 Slot: 12
		public virtual void Click()
		{
			return;
		}

		//// RVA: 0x1AD2BC4 Offset: 0x1AD2BC4 VA: 0x1AD2BC4 Slot: 13
		public virtual void BeginDrag(Vector2 touchPosition)
		{
			return;
		}

		//// RVA: 0x1AD2BC8 Offset: 0x1AD2BC8 VA: 0x1AD2BC8 Slot: 14
		public virtual void Drag(Vector2 touchPosition)
		{
			return;
		}

		//// RVA: 0x1AD132C Offset: 0x1AD132C VA: 0x1AD132C
		private void InitSprite(int order)
		{
			m_spriteRenderer = m_renderer.GetComponent<SpriteRenderer>();
			m_spriteRenderer.sortingOrder = order;
			m_spriteRenderer.sprite = m_sprite;
			m_spriteRenderer.material = GetCurrentMaterial();
		}

		//// RVA: 0x1AD2BCC Offset: 0x1AD2BCC VA: 0x1AD2BCC
		public void UpdateKiraMaterial()
		{
			if(m_spriteRenderer != null)
				m_spriteRenderer.material = GetCurrentMaterial();
		}

		//// RVA: 0x1AD2C9C Offset: 0x1AD2C9C VA: 0x1AD2C9C Slot: 15
		public virtual int GetSerifId()
		{
			return 0;
		}

		//// RVA: 0x1AC6390 Offset: 0x1AC6390 VA: 0x1AC6390
		public void Destory()
		{
			PreDestroy();
			Destroy(m_decorationContoller);
			Destroy(m_object);
			Destroy(this);
			m_renderer = null;
			PostDestroy();
		}

		//// RVA: -1 Offset: -1 Slot: 16
		protected abstract void PreDestroy();

		//// RVA: -1 Offset: -1 Slot: 17
		protected abstract void PostDestroy();

		//// RVA: 0x1AD2CA4 Offset: 0x1AD2CA4 VA: 0x1AD2CA4
		public bool IsDestoryed()
		{
			return m_object == null;
		}

		//// RVA: 0x1ABC6E8 Offset: 0x1ABC6E8 VA: 0x1ABC6E8
		public Vector3 GetWorldPosition()
		{
			return m_object.transform.position;
		}
		
		//// RVA:  Offset: 0x1AD2E38 VA: 0x1AD2E38
		//public Vector2 GetBottomPosition() { }

		//// RVA: 0x1AD2EF8 Offset: 0x1AD2EF8 VA: 0x1AD2EF8
		//public Vector2 GetTopPosition() { }

		//// RVA: 0x1AD2F6C Offset: 0x1AD2F6C VA: 0x1AD2F6C
		//public Vector2 GetLeftPosition() { }

		//// RVA: 0x1AD302C Offset: 0x1AD302C VA: 0x1AD302C
		//public Vector2 GetRightPosition() { }

		//// RVA: 0x1AD30A0 Offset: 0x1AD30A0 VA: 0x1AD30A0 Slot: 20
		public virtual float GetOrderPositionY()
		{
			return Position.y + Size.y * Scale * -0.5f;
		}
		
		//// RVA: 0x1AD310C Offset: 0x1AD310C VA: 0x1AD310C
		public void EnableController(ControlType control)
		{
			m_decorationContoller.SetEnable(true);
			m_enableControl = control;
		}

		//// RVA: 0x1AD3150 Offset: 0x1AD3150 VA: 0x1AD3150
		public void EnableController(bool isEnable)
		{
			m_decorationContoller.SetEnable(isEnable);
		}

		//// RVA: 0x1AD1434 Offset: 0x1AD1434 VA: 0x1AD1434
		public void Flip(bool flipX)
		{
			m_isFlip = flipX;
			if(m_useFlipAsset)
			{
				m_spriteRenderer.sprite = flipX ? m_spriteFlip : m_sprite;
				m_spriteRenderer.material = GetCurrentMaterial();
			}
			else if(!m_useFlipShaderParam)
			{
				m_spriteRenderer.flipX = flipX;
			}
			else
			{
				m_material.SetFloat(m_flipShaderParam, flipX ? 1 : 0);
			}
		}

		//// RVA: 0x1AD318C Offset: 0x1AD318C VA: 0x1AD318C
		//public void ChangeFlip() { }

		//// RVA: 0x1AD31A0 Offset: 0x1AD31A0 VA: 0x1AD31A0
		public bool IsFlip()
		{
			return m_isFlip;
		}

		//// RVA: 0x1AD31A8 Offset: 0x1AD31A8 VA: 0x1AD31A8 Slot: 23
		protected virtual Material GetCurrentMaterial()
		{
			if (!m_useFlipAsset || !m_isFlip)
				return m_material;
			return m_materialFlip;
		}

		//// RVA: 0x1AD31D0 Offset: 0x1AD31D0 VA: 0x1AD31D0 Slot: 24
		protected virtual void SetKiraCurrentMaterial(bool _isKira, int nameId)
		{
			m_materialFlip.SetFloat(nameId, _isKira ? 1 : 0);
			m_material.SetFloat(nameId, _isKira ? 1 : 0);
		}

		//// RVA: 0x1AD3254 Offset: 0x1AD3254 VA: 0x1AD3254
		public void ButtonCallBack(LayoutDecorationFrameButton.ButtonType type)
		{
			switch (type)
			{
				case LayoutDecorationFrameButton.ButtonType.Flip:
					Flip(!m_isFlip);
					if (FlipButtonCallback != null)
						FlipButtonCallback();
					break;
				case LayoutDecorationFrameButton.ButtonType.Serif:
					if (SerifButtonCallback != null)
						SerifButtonCallback(this);
					break;
				case LayoutDecorationFrameButton.ButtonType.PriDown:
					if (PriorityButtonCallback != null)
						PriorityButtonCallback(this, LayoutDecorationFrameButton.ButtonType.PriDown);
					break;
				case LayoutDecorationFrameButton.ButtonType.PriUp:
					if (PriorityButtonCallback != null)
						PriorityButtonCallback(this, LayoutDecorationFrameButton.ButtonType.PriUp);
					break;
				case LayoutDecorationFrameButton.ButtonType.Kira:
					SetStatusFlag(0, !IsStatusFlag(0));
					m_spriteRenderer.material = GetCurrentMaterial();
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					if (ChangeKiraCallback != null)
						ChangeKiraCallback(this, IsStatusFlag(0));
					break;
				default:
					break;
			}
		}

		//// RVA: 0x1AD3CFC Offset: 0x1AD3CFC VA: 0x1AD3CFC Slot: 25
		public virtual void Show()
		{
			m_spriteRenderer.enabled = true;
		}

		//// RVA: 0x1AD3D2C Offset: 0x1AD3D2C VA: 0x1AD3D2C Slot: 26
		public virtual void Hide()
		{
			m_spriteRenderer.enabled = false;
		}

		//// RVA: 0x1AD3D5C Offset: 0x1AD3D5C VA: 0x1AD3D5C
		public bool HitCheck(DecorationItemBase item, Vector2 position)
		{
			Rect r = new Rect(new Vector2(position.x, -position.y) - item.Size / 2, item.Size);
			Rect r2 = new Rect(new Vector2(item.Position.x, -item.Position.y) - Size / 2, Size);
			return r.Overlaps(r2);
		}

		//// RVA: 0x1AD3F88 Offset: 0x1AD3F88 VA: 0x1AD3F88
		public bool HitCheckThinkness(DecorationItemBase item, Vector2 position)
		{
			Vector2 v2 = Size * Scale;
			Vector2 v1 = item.Size * item.Scale;
			Rect r2 = new Rect(new Vector2(Position.x, -Position.y) - v2 / 2, v2);
			r2.y += v2.y - Scale * Setting.Thickness;
			r2.height = Scale * Setting.Thickness;
			Rect r1 = new Rect(new Vector2(position.x, -position.y) - v1 / 2, v1);
			r1.y += v1.y - item.Scale * item.Setting.Thickness;
			r1.height = item.Setting.Thickness;
			return r2.Overlaps(r1);
		}

		//// RVA: 0x1AD3F38 Offset: 0x1AD3F38 VA: 0x1AD3F38
		//private bool HitCheck(Rect rect1, Rect rect2) { }

		//// RVA: 0x1ABC660 Offset: 0x1ABC660 VA: 0x1ABC660
		public void AutoFlip()
		{
			if(m_setting.IsAutoFlip)
			{
				Flip(Position.x >= 0);
			}
		}

		//// RVA: 0x1AC8094 Offset: 0x1AC8094 VA: 0x1AC8094 Slot: 27
		public virtual void SetInfo(DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.MHODOAJPNHD info)
		{
			Position = new Vector2(info.GHPLINIACBB_PosX, info.PMBEODGMMBB_PosY);
			SortingOrder = info.BNHOEFJAAKK_Prio;
			Flip(info.BDEEIPPDCLE_Rvs);
			m_setting.InitWord = info.BEJGNPAAKNB_Word;
			m_statusFlag = info.PMIPFEJFIHA_StatusFlag;
			IsMoved = false;
		}

		//// RVA: 0x1AD1550 Offset: 0x1AD1550 VA: 0x1AD1550
		private void CreateHit()
		{
			m_hitObject = m_object.transform.Find("HitImage");
			m_hitObject.gameObject.SetActive(false);
		}
	}
}
