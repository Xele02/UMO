
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Menu;
using XeSys;

namespace XeApp.Game.AR
{
    public class ARHelpMenu : AROverlayMenu
    {
        private enum Direction
        {
            None = -1,
            Left = 0,
            Right = 1,
            Num = 2,
        }

        [SerializeField]
        private GameObject m_imagesObj; // 0x18
        [SerializeField]
        private SwaipTouch m_swaipTouch; // 0x1C
        [SerializeField]
        private Text m_pageCountText; // 0x20
        [SerializeField]
        private Text m_titleText; // 0x24
        [SerializeField]
        private Button m_leftArrowButton; // 0x28
        [SerializeField]
        private Button m_rightArrowButton; // 0x2C
        [SerializeField]
        private Image m_header; // 0x30
        private GameObject m_imagePrefab; // 0x34
        private string m_helpKey = ""; // 0x38
        private List<RectTransform> m_imageObjList = new List<RectTransform>(); // 0x3C
        private const int HelpImageMax = 2;
        private int m_currentImageNo; // 0x40
        private int m_titleChangeIndex; // 0x44
        private bool m_isOpening; // 0x48
        private Dictionary<string, List<string>> m_helpDict; // 0x4C
        private List<string> m_helpPathList = new List<string>(8); // 0x50

        public GameObject imagePrefab { set { m_imagePrefab = value; } } //0x11D6048
        public string HelpKey { get { return m_helpKey; } set { m_helpKey = value; } } //0x11D6050 0x11D6058
        public bool IsOpening { get { return m_isOpening; } } //0x11D6060

        public void Reconstruct()
        {
            m_closeButton = transform.Find("Header/Close").gameObject.GetComponent<Button>();
            m_imagesObj = transform.Find("Images").gameObject;
            m_swaipTouch = transform.Find("SwaipHitCheck").gameObject.GetComponent<SwaipTouch>();
            m_pageCountText = transform.Find("Header/PageCount").gameObject.GetComponent<Text>();
            m_titleText = transform.Find("Header/Text").gameObject.GetComponent<Text>();
            m_leftArrowButton = transform.Find("ArrowButton/LeftButton").gameObject.GetComponent<Button>();
            m_rightArrowButton = transform.Find("ArrowButton/RightButton").gameObject.GetComponent<Button>();
            m_header = transform.Find("Header").gameObject.GetComponent<Image>();
        }

        // RVA: 0x11D6068 Offset: 0x11D6068 VA: 0x11D6068 Slot: 4
        public override void Start()
        {
            return;
        }

        // [IteratorStateMachineAttribute] // RVA: 0x679D84 Offset: 0x679D84 VA: 0x679D84
        // // RVA: 0x11D6070 Offset: 0x11D6070 VA: 0x11D6070 Slot: 5
        protected override IEnumerator Co_Initialize()
        {
            //0x11D8440
            yield return Co.R(base.Co_Initialize());
            m_isInitialized = false;
            for(int i = 0; i < 2; i++)
            {
                GameObject g = Instantiate(m_imagePrefab, m_imagesObj.transform, false);
                m_imageObjList.Add(g.GetComponent<RectTransform>());
                RectTransform r = g.GetComponent<RectTransform>();
                r.anchoredPosition = new Vector2(r.rect.width * i, r.anchoredPosition.y);
            }
            m_leftArrowButton.onClick.RemoveAllListeners();
            m_leftArrowButton.onClick.AddListener(() =>
            {
                //0x11D8108
                SlideImage(Direction.Left);
            });
            m_rightArrowButton.onClick.RemoveAllListeners();
            m_rightArrowButton.onClick.AddListener(() =>
            {
                //0x11D8110
                SlideImage(Direction.Right);
            });
            ApplyShowArrowButton();
            m_swaipTouch.SetMute(true);
            m_isInitialized = true;
        }

        // // RVA: 0x11D611C Offset: 0x11D611C VA: 0x11D611C Slot: 7
        public override void Setup()
        {
            this.StartCoroutineWatched(Co_Initialize());
        }

        // // RVA: 0x11D6150 Offset: 0x11D6150 VA: 0x11D6150
        public void SetEnableOperate(bool isEnable)
        {
            m_swaipTouch.ResetValue();
            m_swaipTouch.ResetInputState();
            m_swaipTouch.Stop(!isEnable);
            m_closeButton.targetGraphic.raycastTarget = isEnable;
            m_leftArrowButton.targetGraphic.raycastTarget = isEnable;
            m_rightArrowButton.targetGraphic.raycastTarget = isEnable;
        }

        // RVA: 0x11D62AC Offset: 0x11D62AC VA: 0x11D62AC
        private void Reset()
        {
            MessageBank bk = MessageManager.Instance.GetBank("menu");
            m_currentImageNo = 0;
            m_titleText.text = bk.GetMessageByLabel(m_titleChangeIndex > 0 ? "ar_help_title_text" : "ar_help_title2_text");
            m_pageCountText.enabled = m_helpPathList.Count > 1;
            m_pageCountText.text = string.Format("{0} / {1}", m_currentImageNo + 1, m_helpPathList.Count);
            ApplyShowArrowButton();
            m_imagesObj.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            m_swaipTouch.ResetValue();
            m_swaipTouch.ResetInputState();
            for(int i = 0; i < m_imageObjList.Count; i++)
            {
                m_imageObjList[i].anchoredPosition = new Vector2(GetComponent<RectTransform>().rect.width * i, m_imageObjList[i].anchoredPosition.y);
            }
        }

        // // RVA: 0x11D6870 Offset: 0x11D6870 VA: 0x11D6870
        public void SetupHelp(Dictionary<string, List<string>> dict)
        {
            m_helpDict = dict;
        }

        // // RVA: 0x11D6878 Offset: 0x11D6878 VA: 0x11D6878
        private void ListupHelp(Dictionary<string, List<string>> helpDict, string helpKey)
        {
            m_helpPathList.Clear();
            if(string.IsNullOrEmpty(helpKey))
            {
                foreach(var k in helpDict)
                {
                    if(k.Key == "howto")
                    {
                        if(ARSaveData.Instance.IsShowHelp())
                        {
                            for(int i = 0; i < k.Value.Count; i++)
                            {
                                m_helpPathList.Add(k.Value[i]);
                            }
                        }
                        m_titleChangeIndex = m_helpPathList.Count;
                    }
                    else
                    {
                        if(ARSaveData.Instance.IsShowMarkerHelp(k.Key))
                        {
                            for(int i = 0; i < k.Value.Count; i++)
                            {
                                m_helpPathList.Add(k.Value[i]);
                            }
                        }
                    }
                }
            }
            else
            {
                m_titleChangeIndex = 0;
                List<string> l = null;
                if(helpDict.TryGetValue(helpKey, out l))
                {
                    for(int i = 0; i < l.Count; i++)
                    {
                        m_helpPathList.Add(l[i]);
                    }
                    if(helpKey == "howto")
                    {
                        m_titleChangeIndex = m_helpPathList.Count;
                    }
                }
            }
        }

        // // RVA: 0x11D7130 Offset: 0x11D7130 VA: 0x11D7130 Slot: 8
        public override void Open()
        {
            ListupHelp(m_helpDict, m_helpKey);
            if(m_helpPathList.Count < 1)
                return;
            Reset();
            this.StartCoroutineWatched(Co_Open());
        }

        // // RVA: 0x11D726C Offset: 0x11D726C VA: 0x11D726C
        public bool IsEnableMarkerHelp(string helpKey)
        {
            List<string> l;
            if(m_helpDict.TryGetValue(helpKey, out l))
            {
                if(l.Count > 0)
                    return true;
                return false;
            }
            return false;
        }

        // [IteratorStateMachineAttribute] // RVA: 0x679DFC Offset: 0x679DFC VA: 0x679DFC
        // // RVA: 0x11D71E0 Offset: 0x11D71E0 VA: 0x11D71E0
        private IEnumerator Co_Open()
        {
            //0x11D93C4
            m_isOpening = true;
            ARMenuManager.Instance.SetEnableOperate(false);
            yield return Co.R(Co_LoadImage(0, m_imageObjList[0].GetComponentInChildren<RawImage>(true)));
            ARMenuManager.Instance.SetEnableOperate(true);
            base.Open();
            m_isOpening = false;
        }

        // [IteratorStateMachineAttribute] // RVA: 0x679E74 Offset: 0x679E74 VA: 0x679E74
        // // RVA: 0x11D7364 Offset: 0x11D7364 VA: 0x11D7364
        private IEnumerator Co_LoadImage(int listIndex, RawImage image)
        {
            //0x11D8A30
            bool isLoaded = false;
            image.enabled = false;
            ARMenuManager.Instance.arIconCache.Load(m_helpPathList[listIndex], (IiconTexture tex) =>
            {
                //0x11D8330
                image.enabled = true;
                if(tex != null)
                {
                    tex.Set(image);
                }
                isLoaded = true;
            });
            while(!isLoaded)
                yield return null;
        }

        // // RVA: 0x11D7444 Offset: 0x11D7444 VA: 0x11D7444 Slot: 9
        public override void Close()
        {
            base.Close();
        }

        // // RVA: 0x11D75C8 Offset: 0x11D75C8 VA: 0x11D75C8
        private void SlideImage(Direction dir)
        {
            float f = GetComponent<RectTransform>().rect.width;
            RectTransform r = m_imagesObj.GetComponent<RectTransform>();
            float start = r.anchoredPosition.x;
            if(dir == Direction.Right)
            {
                if(m_currentImageNo == m_helpPathList.Count - 1)
                    return;
                f = start - f;
                m_currentImageNo++;
            }
            else if(dir == Direction.Left)
            {
                if(m_currentImageNo == 0)
                    return;
                f = f + start;
                m_currentImageNo--;
            }
            else
            {
                f = 0;
            }
            m_imageObjList[1].anchoredPosition = new Vector2(-f, m_imageObjList[1].anchoredPosition.y);
            ApplyShowArrowButton();
            MessageBank bk = MessageManager.Instance.GetBank("menu");
            m_titleText.text = bk.GetMessageByLabel(m_titleChangeIndex > m_currentImageNo ? "ar_help_title_text" : "ar_help_title2_text");
            m_pageCountText.text = string.Format("{0} / {1}", m_currentImageNo + 1, m_helpPathList.Count);
            this.StartCoroutineWatched(Co_MoveX(start, f, 0.25f, m_currentImageNo));
        }

        // // RVA: 0x11D674C Offset: 0x11D674C VA: 0x11D674C
        private void ApplyShowArrowButton()
        {
            if(m_helpPathList.Count < 2)
            {
                HideArrowButton(Direction.Left);
                HideArrowButton(Direction.Right);
            }
            else
            {
                if(m_currentImageNo == 0)
                {
                    HideArrowButton(Direction.Left);
                }
                else
                {
                    if(m_helpPathList.Count - 1 == m_currentImageNo)
                    {
                        HideArrowButton(Direction.Right);
                        HideArrowButton(Direction.Left);
                        return;
                    }
                    ShowArrowButton(Direction.Left);
                }
                ShowArrowButton(Direction.Right);
            }
        }

        // // RVA: 0x11D7C70 Offset: 0x11D7C70 VA: 0x11D7C70
        private void ShowArrowButton(ARHelpMenu.Direction dir)
        {
            if(dir == Direction.Right)
            {
                Graphic[] gs = m_rightArrowButton.GetComponentsInChildren<Graphic>(true);
                for(int i = 0; i < gs.Length; i++)
                {
                    gs[i].enabled = true;
                }
            }
            else if(dir == Direction.Left)
            {
                Graphic[] gs = m_rightArrowButton.GetComponentsInChildren<Graphic>(true);
                for(int i = 0; i < gs.Length; i++)
                {
                    gs[i].enabled = true;
                }
            }   
        }

        // // RVA: 0x11D7AD4 Offset: 0x11D7AD4 VA: 0x11D7AD4
        private void HideArrowButton(Direction dir)
        {
            if(dir == Direction.Right)
            {
                Graphic[] gs = m_rightArrowButton.GetComponentsInChildren<Graphic>(true);
                for(int i = 0; i < gs.Length; i++)
                {
                    gs[i].enabled = false;
                }
            }
            else if(dir == Direction.Left)
            {
                Graphic[] gs = m_rightArrowButton.GetComponentsInChildren<Graphic>(true);
                for(int i = 0; i < gs.Length; i++)
                {
                    gs[i].enabled = false;
                }
            }
        }

        // [IteratorStateMachineAttribute] // RVA: 0x679EEC Offset: 0x679EEC VA: 0x679EEC
        // // RVA: 0x11D79D0 Offset: 0x11D79D0 VA: 0x11D79D0
        private IEnumerator Co_MoveX(float start, float end, float time, int nextIndex)
        {
            RectTransform rt; // 0x24
            Vector2 pos; // 0x28
            float elapsedTime; // 0x30

            //0x11D8D40
            ARMenuManager.Instance.SetEnableOperate(false);
            yield return Co.R(Co_LoadImage(nextIndex, m_imageObjList[1].GetComponentInChildren<RawImage>(true)));
            rt = m_imagesObj.GetComponent<RectTransform>();
            pos = rt.anchoredPosition;
            elapsedTime = 0;
            while(elapsedTime < time)
            {
                rt.anchoredPosition = new Vector2(Mathf.Lerp(start, end, Mathf.Clamp01(Mathf.Sin(elapsedTime / time * 1.570796f))), pos.y);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            rt.anchoredPosition = new Vector2(end, pos.y);
            RectTransform prev = m_imageObjList[0];
            m_imageObjList[0] = m_imageObjList[1];
            m_imageObjList[1] = prev;
            ARMenuManager.Instance.SetEnableOperate(true);
        }

        // RVA: 0x11D7E2C Offset: 0x11D7E2C VA: 0x11D7E2C
        public void Update()
        {
            if(m_isOpened)
            {
                if(m_swaipTouch.IsReady())
                {
                    if(m_swaipTouch.IsStop())
                        return;
                    if(m_swaipTouch.IsSwaip(SwaipTouch.Direction.RIGHT))
                        SlideImage(Direction.Left);
                    else if(m_swaipTouch.IsSwaip(SwaipTouch.Direction.LEFT))
                        SlideImage(Direction.Right);
                }
            }
        }

        // // RVA: 0x11D7F10 Offset: 0x11D7F10 VA: 0x11D7F10
        public void SetheaderSize(Vector2 sizeDiff)
        {
            RectTransform r = m_header.GetComponent<RectTransform>();
            r.sizeDelta += sizeDiff;
        }

        // [CompilerGeneratedAttribute] // RVA: 0x679F84 Offset: 0x679F84 VA: 0x679F84
        // [DebuggerHiddenAttribute] // RVA: 0x679F84 Offset: 0x679F84 VA: 0x679F84
        // // RVA: 0x11D8118 Offset: 0x11D8118 VA: 0x11D8118
        // private IEnumerator <>n__0() { }

        // [DebuggerHiddenAttribute] // RVA: 0x679FB4 Offset: 0x679FB4 VA: 0x679FB4
        // [CompilerGeneratedAttribute] // RVA: 0x679FB4 Offset: 0x679FB4 VA: 0x679FB4
        // // RVA: 0x11D81A8 Offset: 0x11D81A8 VA: 0x11D81A8
        // private void <>n__1() { }
    }
}