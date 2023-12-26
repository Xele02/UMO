
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Menu;
using XeSys;

namespace XeApp.Game.AR
{
    public class ARCollectionMenu : AROverlayMenu
    { 
        private enum ShowType
        {
            None = -1,
            EventSelect = 0,
            Collection = 1,
            Num = 2,
        }

        [SerializeField]
        private Button m_backButton; // 0x18
        [SerializeField]
        private RectTransform m_menu; // 0x1C
        [SerializeField]
        private RectTransform m_eventSelect; // 0x20
        [SerializeField]
        private RectTransform m_stampCollection; // 0x24
        [SerializeField]
        private Text m_titleText; // 0x28
        [SerializeField]
        private Text m_eventNameText; // 0x2C
        [SerializeField]
        private Text m_stampCountText; // 0x30
        [SerializeField]
        private Image m_header; // 0x34
        private GameObject m_eventInfoPrefab; // 0x38
        private GameObject m_stampPrefab; // 0x3C
        private GameObject m_stampGroupPrefab; // 0x40
        private int m_eventInfoDefaultFontSize; // 0x44
        private int m_stampInfoDefaultFontSize; // 0x48
        private int m_stampGroupDefaultFontSize; // 0x4C
        private ScrollRect m_scrollEventSelect; // 0x50
        private ScrollRect m_scrollCollection; // 0x54
        private List<GameObject> m_eventObjList = new List<GameObject>(); // 0x58
        private List<GameObject> m_stampObjList = new List<GameObject>(); // 0x5C
        private List<GameObject> m_stampGroupObjList = new List<GameObject>(); // 0x60
        private ARCollectionMenu.ShowType m_showType = ShowType.None; // 0x64
        private static readonly ARDivaPatternId[] PATTERN_TABLE = new ARDivaPatternId[3]
        {
            ARDivaPatternId.Present, ARDivaPatternId.Miniature, ARDivaPatternId.LifeSize
        }; // 0x0

        public GameObject eventInfoPrefab { set { m_eventInfoPrefab = value; } } //0x161613C
        public GameObject stampPrefab { set { m_stampPrefab = value; } } //0x1616144
        public GameObject stampGroupPrefab { set { m_stampGroupPrefab = value; } } //0x161614C

        // RVA: 0x1616154 Offset: 0x1616154 VA: 0x1616154 Slot: 4
        public override void Start()
        {
            base.Start();
        }

        // [IteratorStateMachineAttribute] // RVA: 0x679AFC Offset: 0x679AFC VA: 0x679AFC
        // // RVA: 0x161615C Offset: 0x161615C VA: 0x161615C Slot: 5
        protected override IEnumerator Co_Initialize()
        {
            //0x161B154
            yield return Co.R(base.Co_Initialize());
            m_isInitialized = false;
            List<ScrollRect> l = new List<ScrollRect>(GetComponentsInChildren<ScrollRect>(true));
            m_scrollCollection = l.Find((ScrollRect _) =>
            {
                //0x161A858
                return _.name == "ScrollCollection";
            });
            m_scrollEventSelect = l.Find((ScrollRect _) =>
            {
                //0x161A8F0
                return _.name == "ScrollEventSelect";
            });
            float f = GetComponent<RectTransform>().rect.width;
            m_stampCollection.anchoredPosition = new Vector2(f, m_stampCollection.anchoredPosition.y);
            m_stampCollection.sizeDelta = new Vector2(f, m_stampCollection.sizeDelta.y);
            m_backButton.gameObject.SetActive(false);
            m_backButton.onClick.AddListener(OnClickBackButton);
            m_eventInfoDefaultFontSize = m_eventInfoPrefab.transform.Find("EventName").GetComponent<Text>().fontSize;
            m_stampInfoDefaultFontSize = m_eventNameText.fontSize;
            m_stampGroupDefaultFontSize = m_stampGroupPrefab.transform.Find("GroupName").GetComponent<Text>().fontSize;
            m_isInitialized = true;
        }

        // // RVA: 0x1616208 Offset: 0x1616208 VA: 0x1616208 Slot: 7
        public override void Setup()
        {
            this.StartCoroutineWatched(Co_Initialize());
        }

        // // RVA: 0x161623C Offset: 0x161623C VA: 0x161623C
        public void SetEnableOperate(bool isEnable)
        {
            m_closeButton.targetGraphic.raycastTarget = isEnable;
            m_backButton.targetGraphic.raycastTarget = isEnable;
            if(m_scrollEventSelect != null)
                m_scrollEventSelect.enabled = isEnable;
            if(m_scrollCollection != null)
                m_scrollCollection.enabled = isEnable;
            for(int i = 0; i < m_eventObjList.Count; i++)
            {
                m_eventObjList[i].GetComponent<Button>().targetGraphic.raycastTarget = isEnable;
            }
        }

        // // RVA: 0x16164EC Offset: 0x16164EC VA: 0x16164EC
        private void SetupEventSelect()
        {
            m_titleText.text = MessageManager.Instance.GetMessage("menu", "ar_collection_title_text");
            m_scrollEventSelect.verticalNormalizedPosition = 1;
            List<AREventMasterData.Data> l = AREventMasterData.Instance.GetEventList(false);
            l.Sort(EventListSortFunc);
            for(int i = 0; i < m_eventObjList.Count; i++)
            {
                m_eventObjList[i].SetActive(false);
            }
            RectTransform rt = m_scrollEventSelect.content;
            Vector2 size = m_eventInfoPrefab.GetComponent<RectTransform>().sizeDelta;
            float y = 0;
            for(int i = 0; i < l.Count; i++)
            {
                AREventMasterData.Data eventData = l[i];
                List<ARMarkerMasterData.Data> l2 = ARMarkerMasterData.Instance.GetEventStartingMarkerList(eventData.eventId);
                if(l2 != null && l2.Count != 0)
                {
                    int total = 0;
                    int cnt = 0;
                    for(int j = 0; j < l2.Count; j++)
                    {
                        if(l2[i].stampId != 0)
                        {
                            total++;
                            if(ARSaveData.Instance.IsHaveStamp(l2[i].markerId))
                                cnt++;
                        }
                    }
                    if(total != 0)
                    {
                        if(i < m_eventObjList.Count)
                        {
                            m_eventObjList[i].SetActive(true);
                        }
                        else
                        {
                            GameObject g = Instantiate(m_eventInfoPrefab, rt, false);
                            m_eventObjList.Add(g);
                        }
                        Image[] imgs = m_eventObjList[i].GetComponentsInChildren<Image>();
                        Image im = Array.Find(imgs, (Image x) =>
                        {
                            //0x161A988
                            return x.name == "ArrowImage";
                        });
                        if(im != null)
                            im.enabled = true;
                        List<Text> lText = new List<Text>(m_eventObjList[i].GetComponentsInChildren<Text>(true));
                        Text txt = lText.Find((Text _) =>
                        {
                            //0x161AA08
                            return _.name.Contains("EventName");
                        });
                        ApplyBestFitText(txt, m_eventInfoDefaultFontSize, eventData.eventName);
                        txt = lText.Find((Text _) =>
                        {
                            //0x161AAA0
                            return _.name.Contains("StampCount");
                        });
                        txt.text = string.Format(MessageManager.Instance.GetMessage("menu", "ar_common_count_text"), cnt, total);
                        RectTransform rt2 = m_eventObjList[i].GetComponent<RectTransform>();
                        rt2.anchoredPosition = new Vector2(size.x, -y);
                        Button btn = m_eventObjList[i].GetComponent<Button>();
                        btn.onClick.RemoveAllListeners();
                        btn.onClick.AddListener(() =>
                        {
                            //0x161AF48
                            OnClickEventButton(eventData.eventId);
                        });
                        y += size.y;
                    }
                }
            }
            if(l.Count < m_eventObjList.Count)
            {
                for(int i = 0; i < m_eventObjList.Count; i++)
                {
                    if(l.Count <= i)
                    {
                        m_eventObjList[i].SetActive(false);
                    }
                }
            }
            m_scrollEventSelect.content.sizeDelta = new Vector2(m_scrollEventSelect.content.sizeDelta.x, y);
        }

        // // RVA: 0x1617784 Offset: 0x1617784 VA: 0x1617784
        public void SetupEventHelpList()
        {
            m_titleText.text = MessageManager.Instance.GetMessage("menu", "ar_help_title2_text");
            m_scrollEventSelect.verticalNormalizedPosition = 1;
            List<AREventMasterData.Data> l = AREventMasterData.Instance.GetEventList(false);
            RectTransform content = m_scrollEventSelect.content;
            Vector2 size = m_eventInfoPrefab.GetComponent<RectTransform>().sizeDelta;
            l.Sort(EventListSortFunc);
            for(int i = 0; i < m_eventObjList.Count; i++)
            {
                m_eventObjList[i].SetActive(false);
            }
            float y = 0;
            for(int i = 0; i < l.Count; i++)
            {
                AREventMasterData.Data eventData = l[i];
                List<ARMarkerMasterData.Data> l2 = ARMarkerMasterData.Instance.GetEventStartingMarkerList(eventData.eventId);
                if(l2 != null && l2.Count != 0)
                {
                    if(ARMenuManager.Instance.helpMenu.IsEnableMarkerHelp(eventData.eventId))
                    {
                        if(i < m_eventObjList.Count)
                        {
                            m_eventObjList[i].SetActive(true);
                        }
                        else
                        {
                            m_eventObjList.Add(Instantiate(m_eventInfoPrefab, content, false));
                        }
                        Image[] ims = m_eventObjList[i].GetComponentsInChildren<Image>(true);
                        Image im = Array.Find(ims, (Image x) =>
                        {
                            //0x161AB38
                            return x.name == "ArrowImage";
                        });
                        if(im != null)
                        {
                            im.enabled = false;
                        }
                        List<Text> ltxts = new List<Text>(m_eventObjList[i].GetComponentsInChildren<Text>(true));
                        ApplyBestFitText(ltxts.Find((Text _) =>
                        {
                            //0x161ABB8
                            return _.name.Contains("EventName");
                        }), m_eventInfoDefaultFontSize, eventData.eventName);
                        ltxts.Find((Text _) =>
                        {
                            //0x161AC50
                            return _.name.Contains("StampCount");
                        }).text = "";
                        RectTransform rt = m_eventObjList[i].GetComponent<RectTransform>();
                        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, -y);
                        Button btn = m_eventObjList[i].GetComponent<Button>();
                        btn.onClick.RemoveAllListeners();
                        btn.onClick.AddListener(() =>
                        {
                            //0x161AF8C
                            OnClickEventHelpButton(eventData.eventId);
                        });
                        y += size.y;
                    }
                }
            }
            if(l.Count < m_eventObjList.Count)
            {
                for(int i = 0; i < m_eventObjList.Count; i++)
                {
                    if(l.Count <= i)
                    {
                        m_eventObjList[i].SetActive(false);
                    }
                }
            }
            m_scrollEventSelect.content.sizeDelta = new Vector2(m_scrollEventSelect.content.sizeDelta.x, y);
        }

        // // RVA: 0x16186F0 Offset: 0x16186F0 VA: 0x16186F0
        private int EventListSortFunc(AREventMasterData.Data left, AREventMasterData.Data right)
        {
            return right.no - left.no;
        }

        // // RVA: 0x1618730 Offset: 0x1618730 VA: 0x1618730
        private void SetupStampCollection(string eventId)
        {
            m_scrollCollection.verticalNormalizedPosition = 1;
            List<ARMarkerMasterData.Data> l = ARMarkerMasterData.Instance.GetEventStartingMarkerList(eventId);
            if(l != null)
            {
                MessageBank bk = MessageManager.Instance.GetBank("menu");
                List<AREventMasterData.Data> l2 = AREventMasterData.Instance.GetEventList(false);
                AREventMasterData.Data d = l2.Find((AREventMasterData.Data _) =>
                {
                    //0x161AFCC
                    return _.eventId.Contains(eventId);
                });
                ARIconTextureCache iconCache = ARMenuManager.Instance.arIconCache;
                Rect rect = m_scrollCollection.content.rect;
                Transform t = m_scrollCollection.content.Find("Stamps");
                Vector2 size = m_stampPrefab.GetComponent<RectTransform>().sizeDelta;
                float f5 = size.y;
                float f4 = size.x;
                float f1 = (rect.width + size.x * -3) * 0.5f * 0.5f;
                int a3 = 0;
                int a2 = 0;
                float y = 0;
                int a1 = 0;
                for(int i = 0; i < 3; i++)
                {
                    ARDivaPatternId pattern = PATTERN_TABLE[i];
                    List<ARMarkerMasterData.Data> l3 = l.FindAll((ARMarkerMasterData.Data _) =>
                    {
                        //0x161B018
                        return _.pattern == pattern;
                    });
                    if(l3.Count != 0)
                    {
                        GameObject glast = null;
                        int f3 = 0;
                        int f6 = 0;
                        for(int j = 0; j < l3.Count; j++)
                        {
                            if(l3[j].stampId == 0)
                            {
                                if(j != l3.Count - 1 || f3 < 1)
                                    ;//f2 = y;
                                else
                                    y += f1 + f5;
                            }
                            else
                            {
                                if(f3 == 0)
                                {
                                    if(a1 < m_stampGroupObjList.Count)
                                    {
                                        m_stampGroupObjList[a1].SetActive(true);
                                    }
                                    else
                                    {
                                        m_stampGroupObjList.Add(Instantiate(m_stampGroupPrefab, t, false));
                                    }
                                    glast = m_stampGroupObjList[a1];
                                    RectTransform rt = m_stampGroupObjList[a1].GetComponent<RectTransform>();
                                    rt.anchoredPosition = new Vector2(0, -y);
                                    y += m_stampGroupPrefab.GetComponent<RectTransform>().sizeDelta.y;
                                }
                                if(f3 + a2 < m_stampObjList.Count)
                                {
                                    m_stampObjList[f3 + a2].SetActive(true);
                                }
                                else
                                {
                                    m_stampObjList.Add(Instantiate(m_stampPrefab, t, false));
                                }
                                RawImage image = m_stampObjList[f3 + a2].GetComponentInChildren<RawImage>(true);
                                image.enabled = false;
                                iconCache.LoadStamp(eventId, l3[j].stampId, ARSaveData.Instance.IsHaveStamp(l3[j].markerId) ? 0 : 1, (IiconTexture tex) =>
                                {
                                    //0x161B050
                                    image.enabled = true;
                                    if(tex == null)
                                        return;
                                    tex.Set(image);
                                });
                                m_stampObjList[f3 + a2].GetComponent<RectTransform>().anchoredPosition = new Vector2(f1 + (f1 + f4) * (f3 % 3), -y);
                                if(f3 % 3 == 2 || j == l3.Count - 1)
                                    y += f1 + f5;
                                if(ARSaveData.Instance.IsHaveStamp(l3[j].markerId))
                                    f6++;
                                f3++;
                            }
                        }
                        if(f3 != 0)
                        {
                            List<Text> ltxts = new List<Text>(glast.GetComponentsInChildren<Text>(true));
                            Text txt = ltxts.Find((Text _) =>
                            {
                                //0x161ACE8
                                return _.name.Contains("GroupName");
                            });
                            ApplyBestFitText(txt, m_stampGroupDefaultFontSize, string.Format(bk.GetMessageByLabel("ar_collection_pattern_format"), d.eventName, bk.GetMessageByLabel(string.Format("ar_collection_pattern_text_{0}", pattern))));
                            txt = ltxts.Find((Text _) =>
                            {
                                //0x161AD80
                                return _.name.Contains("StampCount");
                            });
                            txt.text = string.Format(bk.GetMessageByLabel("ar_common_count_text"), f6, f3);
                            a2 += f3;
                            a3 += f6;
                            a1++;
                        }
                    }
                }
                List<Text> ltxts2 = new List<Text>(m_stampCollection.Find("EventInfo").GetComponentsInChildren<Text>(true));
                ApplyBestFitText(ltxts2.Find((Text _) =>
                {
                    //0x161AE18
                    return _.name.Contains("EventName");
                }), m_stampInfoDefaultFontSize, d.eventName);
                ltxts2.Find((Text _) =>
                {
                    //0x161AEB0
                    return _.name.Contains("StampCount");
                }).text = string.Format(bk.GetMessageByLabel("ar_common_count_text"), a3, a2);
                if(a2 < m_stampObjList.Count)
                {
                    for(int i = 0; i < m_stampObjList.Count; i++)
                    {
                        if(a2 <= m_stampObjList.Count)
                        {
                            m_stampObjList[i].SetActive(false);
                        }
                    }
                }
                if(a1 < m_stampGroupObjList.Count)
                {
                    for(int i = 0; i < m_stampGroupObjList.Count; i++)
                    {
                        if(a1 <= m_stampGroupObjList.Count)
                        {
                            m_stampGroupObjList[i].SetActive(false);
                        }
                    }
                }
                m_scrollCollection.content.sizeDelta = new Vector2(m_scrollCollection.content.sizeDelta.x, y);
            }
        }

        // // RVA: 0x16175F8 Offset: 0x16175F8 VA: 0x16175F8
        private void ApplyBestFitText(Text text, int defaultFontSize, string str)
        {
            text.resizeTextForBestFit = false;
            text.horizontalOverflow = HorizontalWrapMode.Overflow;
            text.fontSize = defaultFontSize;
            text.text = str;
            if(!string.IsNullOrEmpty(str))
            {
                do
                {
                    if(text.preferredWidth < text.rectTransform.rect.width)
                        return;
                    text.fontSize = text.fontSize - 1;
                } while(text.fontSize > 1);
            }
        }

        // // RVA: 0x1619F6C Offset: 0x1619F6C VA: 0x1619F6C Slot: 8
        public override void Open()
        {
            m_showType = ShowType.EventSelect;
            SetupEventSelect();
            base.Open();
        }

        // // RVA: 0x1619F98 Offset: 0x1619F98 VA: 0x1619F98
        public void OpenEventInfo()
        {
            SetupEventHelpList();
            base.Open();
        }

        // // RVA: 0x1619FB8 Offset: 0x1619FB8 VA: 0x1619FB8
        private void ShowStampCollection()
        {
            m_showType = ShowType.Collection;
            m_closeButton.gameObject.SetActive(false);
            m_backButton.gameObject.SetActive(true);
            this.StartCoroutineWatched(Co_MoveX(0, -GetComponent<RectTransform>().rect.width, 0.25f));
        }

        // // RVA: 0x161A20C Offset: 0x161A20C VA: 0x161A20C
        private void OnClickBackButton()
        {
            m_showType = ShowType.EventSelect;
            m_closeButton.gameObject.SetActive(true);
            m_backButton.gameObject.SetActive(false);
            this.StartCoroutineWatched(Co_MoveX(-GetComponent<RectTransform>().rect.width, 0, 0.25f));
        }

        // [IteratorStateMachineAttribute] // RVA: 0x679B74 Offset: 0x679B74 VA: 0x679B74
        // // RVA: 0x161A120 Offset: 0x161A120 VA: 0x161A120
        private IEnumerator Co_MoveX(float start, float end, float time)
        {
            Vector2 pos; // 0x20
            float elapsedTime; // 0x28

            //0x161B8BC
            ARMenuManager.Instance.SetEnableOperate(false);
            pos = m_menu.anchoredPosition;
            elapsedTime = 0;
            while(elapsedTime < time)
            {
                m_menu.anchoredPosition = new Vector2(Mathf.Lerp(start, end, Mathf.Clamp01(Mathf.Sin(elapsedTime / time * 1.570796f))), pos.y);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            m_menu.anchoredPosition = new Vector2(end, pos.y);
            ARMenuManager.Instance.SetEnableOperate(true);
        }

        // // RVA: 0x161A394 Offset: 0x161A394 VA: 0x161A394
        private void OnClickEventButton(string eventId)
        {
            if(m_showType != ShowType.EventSelect)
                return;
            SetupStampCollection(eventId);
            ShowStampCollection();
        }

        // // RVA: 0x161A3C0 Offset: 0x161A3C0 VA: 0x161A3C0
        private void OnClickEventHelpButton(string eventId)
        {
            ARMenuManager.Instance.helpMenu.HelpKey = eventId;
            ARMenuManager.Instance.helpMenu.Open();
        }

        // // RVA: 0x161A46C Offset: 0x161A46C VA: 0x161A46C
        public void SetheaderSize(Vector2 sizeDiff)
        {
            RectTransform r = m_header.GetComponent<RectTransform>();
            r.sizeDelta += sizeDiff;
        }

        // // RVA: 0x161A57C Offset: 0x161A57C VA: 0x161A57C Slot: 6
        protected override void OnBackButton()
        {
            if(m_backButton.gameObject.activeSelf && m_backButton.targetGraphic.raycastTarget)
                OnClickBackButton();
            else
                base.OnBackButton();
        }

        // [CompilerGeneratedAttribute] // RVA: 0x679BEC Offset: 0x679BEC VA: 0x679BEC
        // [DebuggerHiddenAttribute] // RVA: 0x679BEC Offset: 0x679BEC VA: 0x679BEC
        // // RVA: 0x161A7D4 Offset: 0x161A7D4 VA: 0x161A7D4
        // private IEnumerator <>n__0() { }
    }
}