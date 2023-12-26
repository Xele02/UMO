
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Menu;

namespace XeApp.Game.AR
{
    public class ARAcquireMarker : MonoBehaviour
    {
        private const float FADE_TIME = 0.25f;
        private const float WAIT_TIME = 3;
        [SerializeField]
        private RawImage m_iconImage; // 0xC
        [SerializeField]
        private Image m_textImage; // 0x10
        private bool m_isShow; // 0x14
        private ARObject m_arObj; // 0x18

        // RVA: 0x1611384 Offset: 0x1611384 VA: 0x1611384
        public void Start()
        {
            m_arObj = FindObjectOfType<ARObject>();
            SetAlpha(0);
        }

        // // RVA: 0x1611420 Offset: 0x1611420 VA: 0x1611420
        private void SetAlpha(float alpha)
        {
            Graphic[] gs = GetComponentsInChildren<Graphic>(true);
            for(int i = 0; i < gs.Length; i++)
            {
                gs[i].color = new Color(1, 1, 1, alpha);
            }
        }

        // RVA: 0x161155C Offset: 0x161155C VA: 0x161155C
        public void SetShowMarker(ARMarkerMasterData.Data data)
        {
            if(data.stampId == 0)
                return;
            if(m_isShow)
            {
                this.StopAllCoroutinesWatched();
                m_isShow = false;
                SetAlpha(0);
            }
            this.StartCoroutineWatched(Co_ShowMarker(data));
        }

        // [IteratorStateMachineAttribute] // RVA: 0x679504 Offset: 0x679504 VA: 0x679504
        // // RVA: 0x16115D4 Offset: 0x16115D4 VA: 0x16115D4
        private IEnumerator Co_ShowMarker(ARMarkerMasterData.Data data)
        {
            //0x1611AA4
            m_isShow = true;
            bool isLoaded = false;
            ARMenuManager.Instance.arIconCache.LoadStamp(data.eventId, data.stampId, 0, (IiconTexture tex) =>
            {
                //0x16117A0
                if(tex != null)
                {
                    tex.Set(m_iconImage);
                }
                isLoaded = true;
            });
            while(!isLoaded)
                yield return null;
            yield return null;
            while(m_arObj.IsLoading())
                yield return null;
            yield return Co.R(Co_Fade(0, 1));
            yield return new WaitForSeconds(3);
            yield return Co.R(Co_Fade(1, 0));
            m_isShow = false;
        }

        // [IteratorStateMachineAttribute] // RVA: 0x67957C Offset: 0x67957C VA: 0x67957C
        // // RVA: 0x161169C Offset: 0x161169C VA: 0x161169C
        private IEnumerator Co_Fade(float start, float end)
        {
            float elapsed;

            //0x1611898
            elapsed = 0;
            do
            {
                elapsed += Time.deltaTime;
                SetAlpha(Mathf.Lerp(start, end, Mathf.Clamp01(elapsed * 4)));
                yield return null;
            } while(elapsed < 0.25f);
            SetAlpha(end);
        }

        // RVA: 0x161178C Offset: 0x161178C VA: 0x161178C
        public void Update()
        {
            return;
        }
    }
}